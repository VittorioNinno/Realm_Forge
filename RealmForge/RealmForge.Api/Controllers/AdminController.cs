using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealmForge.Api.Campaigns;
using RealmForge.Api.Security;
using RealmForge.Infrastructure.Identity;
using RealmForge.Infrastructure.Persistence;
using RealmForge.Shared.DTOs;
using RealmForge.Shared.Enums;

namespace RealmForge.Api.Controllers
{
	///	<summary>
	///	Administration (only the accounts listed in "Auth:AdminEmails"): figures of the site, the accounts (suspend,
	///	reactivate, delete with the same rules as the deletion by the person) and the moderation of the Homebrew
	///	(visibility; editing and deleting go through the ordinary pages, where administrators may change anything).
	///	</summary>
	[ApiController]
	[Route("api/admin")]
	[Authorize]
	public class AdminController : ControllerBase
	{
		//	A suspension longer than this is "until reactivated"
		public const int MaxLockDays = 3650;

		private readonly RealmForgeDbContext _context;
		private readonly UserManager<ApplicationUser> _users;
		private readonly ContentAccess _access;
		private readonly HomebrewLookup _homebrew;

		public AdminController(RealmForgeDbContext context, UserManager<ApplicationUser> users, ContentAccess access, HomebrewLookup homebrew)
		{
			_context = context;
			_users = users;
			_access = access;
			_homebrew = homebrew;
		}

		private string UserId => ContentAccess.GetUserId(User) ?? string.Empty;

		//	GET: api/admin/stats
		[HttpGet("stats")]
		public async Task<ActionResult<AdminStatsDto>> GetStats()
		{
			if (!_access.IsAdmin(User))
			{
				return Forbid();
			}
			var now = DateTimeOffset.UtcNow;
			var homebrew = (await _homebrew.AllAsync(LanguageCode.En)).ToList();
			return Ok(new AdminStatsDto(
				await _context.Users.CountAsync(),
				await _context.Users.CountAsync(u => u.EmailConfirmed),
				await _context.Users.CountAsync(u => u.LockoutEnd != null && u.LockoutEnd > now),
				await _context.Characters.CountAsync(),
				await _context.Campaigns.CountAsync(),
				homebrew.Count,
				homebrew.Count(h => h.Visibility == ContentVisibility.Public)));
		}

		//	GET: api/admin/users?q=… — newest first, filtered by e-mail or nickname
		[HttpGet("users")]
		public async Task<ActionResult<List<AdminUserDto>>> GetUsers([FromQuery] string? q)
		{
			if (!_access.IsAdmin(User))
			{
				return Forbid();
			}
			var query = _context.Users.AsNoTracking();
			if (q?.Trim() is { Length: > 0 } text)
			{
				var pattern = "%" + text.Replace("\\", "\\\\").Replace("%", "\\%").Replace("_", "\\_") + "%";
				query = query.Where(u => EF.Functions.ILike(u.Email ?? string.Empty, pattern) || EF.Functions.ILike(u.Nickname ?? string.Empty, pattern));
			}
			var users = await query.OrderByDescending(u => u.RegisteredAt).Take(200).ToListAsync();
			var ids = users.Select(u => u.Id).ToList();

			var characters = await _context.Characters.Where(c => ids.Contains(c.OwnerId)).GroupBy(c => c.OwnerId)
				.Select(g => new { g.Key, Count = g.Count() }).ToDictionaryAsync(x => x.Key, x => x.Count);
			var campaigns = await _context.CampaignMembers.Where(m => ids.Contains(m.UserId)).GroupBy(m => m.UserId)
				.Select(g => new { g.Key, Count = g.Count() }).ToDictionaryAsync(x => x.Key, x => x.Count);
			var homebrew = (await _homebrew.AllAsync(LanguageCode.En)).Where(h => h.AuthorId is not null)
				.GroupBy(h => h.AuthorId!).ToDictionary(g => g.Key, g => g.Count());

			var now = DateTimeOffset.UtcNow;
			return Ok(users.Select(u => new AdminUserDto(
				u.Id,
				u.Email ?? u.UserName ?? string.Empty,
				u.Nickname,
				u.EmailConfirmed,
				u.RegisteredAt,
				u.LockoutEnd is { } end && end > now ? end : null,
				_access.IsAdminEmail(u.Email),
				u.Id == UserId,
				characters.GetValueOrDefault(u.Id),
				homebrew.GetValueOrDefault(u.Id),
				campaigns.GetValueOrDefault(u.Id))).ToList());
		}

		//	PUT: api/admin/users/{id}/lock — suspends the sign-in for some days (0 reactivates); never oneself or an administrator
		[HttpPut("users/{id}/lock")]
		public async Task<IActionResult> Lock(string id, [FromBody] AdminLockDto dto)
		{
			if (!_access.IsAdmin(User))
			{
				return Forbid();
			}
			var user = await _users.FindByIdAsync(id);
			if (user is null)
			{
				return NotFound();
			}
			if (user.Id == UserId || _access.IsAdminEmail(user.Email))
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "An administrator cannot be suspended.");
			}
			if (dto.Days < 0 || dto.Days > MaxLockDays)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: $"From 0 to {MaxLockDays} days.");
			}
			await _users.SetLockoutEnabledAsync(user, true);
			await _users.SetLockoutEndDateAsync(user, dto.Days == 0 ? null : DateTimeOffset.UtcNow.AddDays(dto.Days));
			if (dto.Days > 0)
			{
				//	The sessions already open can no longer be renewed
				await _users.UpdateSecurityStampAsync(user);
			}
			else
			{
				await _users.ResetAccessFailedCountAsync(user);
			}
			return NoContent();
		}

		//	DELETE: api/admin/users/{id} — the account and its data, as when the person deletes it
		[HttpDelete("users/{id}")]
		public async Task<ActionResult<AccountDeletedDto>> DeleteUser(string id, [FromServices] AccountDeletion deletion)
		{
			if (!_access.IsAdmin(User))
			{
				return Forbid();
			}
			var user = await _users.FindByIdAsync(id);
			if (user is null)
			{
				return NotFound();
			}
			if (user.Id == UserId || _access.IsAdminEmail(user.Email))
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "An administrator cannot be deleted here.");
			}
			var outcome = await deletion.RemoveDataAsync(user.Id);
			var result = await _users.DeleteAsync(user);
			if (!result.Succeeded)
			{
				return Problem(statusCode: StatusCodes.Status500InternalServerError, title: "The account could not be deleted.");
			}
			return Ok(new AccountDeletedDto(outcome.Characters, outcome.HomebrewDeleted, outcome.HomebrewKept, outcome.CampaignsDeleted, outcome.CampaignsHandedOver));
		}

		//	GET: api/admin/homebrew?visibility=0&q=… — every Homebrew entry (public ones by default), newest authors' names
		[HttpGet("homebrew")]
		public async Task<ActionResult<List<AdminHomebrewDto>>> GetHomebrew([FromQuery] ContentVisibility? visibility, [FromQuery] string? q,
			[FromQuery] LanguageCode lang = LanguageCode.It)
		{
			if (!_access.IsAdmin(User))
			{
				return Forbid();
			}
			var entries = (await _homebrew.AllAsync(lang))
				.Where(e => visibility is null || e.Visibility == visibility)
				.Where(e => q is not { Length: > 0 } || e.Name.Contains(q.Trim(), StringComparison.OrdinalIgnoreCase))
				.ToList();
			var ids = entries.Select(e => e.Id).ToList();
			var shares = await _context.ContentShares.Where(s => ids.Contains(s.EntityId)).GroupBy(s => s.EntityId)
				.Select(g => new { g.Key, Count = g.Count() }).ToDictionaryAsync(x => x.Key, x => x.Count);
			var campaigns = await _context.CampaignContents.Where(c => ids.Contains(c.EntityId)).GroupBy(c => c.EntityId)
				.Select(g => new { g.Key, Count = g.Count() }).ToDictionaryAsync(x => x.Key, x => x.Count);
			var names = await PublicNames.LoadAsync(_context, entries.Select(e => e.AuthorId));
			return Ok(entries
				.OrderBy(e => e.Kind).ThenBy(e => e.Name, StringComparer.CurrentCultureIgnoreCase)
				.Select(e => new AdminHomebrewDto(e.Id, e.Kind, e.Name, e.Link, e.Ruleset, e.Visibility, e.AuthorId,
					e.AuthorId is null ? string.Empty : names.GetValueOrDefault(e.AuthorId, "•••"),
					shares.GetValueOrDefault(e.Id), campaigns.GetValueOrDefault(e.Id)))
				.ToList());
		}

		//	PUT: api/admin/homebrew/{id}/visibility — e.g. takes an inappropriate public entry out of the lists
		[HttpPut("homebrew/{id:guid}/visibility")]
		public async Task<IActionResult> SetVisibility(Guid id, [FromBody] AdminVisibilityDto dto)
		{
			if (!_access.IsAdmin(User))
			{
				return Forbid();
			}
			if (!Enum.IsDefined(dto.Visibility))
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "Unknown visibility.");
			}
			var entity = await _homebrew.FindEntityAsync(id);
			if (entity is null)
			{
				return NotFound();
			}
			entity.Visibility = dto.Visibility;
			await _context.SaveChangesAsync();
			return NoContent();
		}
	}
}
