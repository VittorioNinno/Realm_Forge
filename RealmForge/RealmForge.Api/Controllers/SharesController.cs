using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealmForge.Api.Security;
using RealmForge.Domain.Common;
using RealmForge.Domain.Entities;
using RealmForge.Infrastructure.Identity;
using RealmForge.Infrastructure.Persistence;
using RealmForge.Shared.DTOs;
using RealmForge.Shared.Enums;

namespace RealmForge.Api.Controllers
{
	///	<summary>
	///	Homebrew shared with chosen accounts: the author adds people by e-mail (whatever the visibility), anyone can add a
	///	link-only entry to their own collection. Shared entries are listed for those people, also in character creation.
	///	</summary>
	[ApiController]
	[Route("api/shares")]
	[Authorize]
	public class SharesController : ControllerBase
	{
		public const int MaxSharesPerEntry = 50;

		private readonly RealmForgeDbContext _context;
		private readonly ContentAccess _access;
		private readonly UserManager<ApplicationUser> _users;

		public SharesController(RealmForgeDbContext context, ContentAccess access, UserManager<ApplicationUser> users)
		{
			_context = context;
			_access = access;
			_users = users;
		}

		private string UserId => ContentAccess.GetUserId(User) ?? string.Empty;

		//	GET: api/shares/content/mine — entries shared with me
		[HttpGet("content/mine")]
		public async Task<ActionResult<List<SharedEntryDto>>> GetMine()
		{
			var rows = await _context.ContentShares.AsNoTracking().Where(s => s.UserId == UserId).ToListAsync();
			return Ok(rows.Select(s => new SharedEntryDto(s.EntityId, s.GrantedById == s.UserId)).ToList());
		}

		//	GET: api/shares/content/{id} — the people the author shared the entry with
		[HttpGet("content/{id:guid}")]
		public async Task<ActionResult<List<ShareUserDto>>> GetShares(Guid id)
		{
			var entity = await FindAsync(id);
			if (entity is null || !_access.CanModify(entity, User))
			{
				return NotFound();
			}
			var rows = await _context.ContentShares.AsNoTracking().Where(s => s.EntityId == id && s.GrantedById != s.UserId).ToListAsync();
			return Ok(await ToUsersAsync(rows.Select(r => r.UserId)));
		}

		//	POST: api/shares/content/{id} — share with an account by e-mail
		[HttpPost("content/{id:guid}")]
		public async Task<ActionResult<ShareUserDto>> Share(Guid id, [FromBody] ShareRequestDto request)
		{
			var entity = await FindAsync(id);
			if (entity is null || !_access.CanModify(entity, User))
			{
				return NotFound();
			}
			var (target, problem) = await FindUserAsync(request.Email);
			if (target is null)
			{
				return problem!;
			}
			if (target.Id == entity.AuthorId)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "This is the author of the entry.");
			}
			if (await _context.ContentShares.CountAsync(s => s.EntityId == id) >= MaxSharesPerEntry)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: $"At most {MaxSharesPerEntry} people per entry.");
			}

			var existing = await _context.ContentShares.FirstOrDefaultAsync(s => s.EntityId == id && s.UserId == target.Id);
			if (existing is null)
			{
				_context.ContentShares.Add(new ContentShare { EntityId = id, UserId = target.Id, GrantedById = UserId });
			}
			else
			{
				existing.GrantedById = UserId;
			}
			await _context.SaveChangesAsync();
			return Ok(new ShareUserDto(target.Id, target.Email ?? string.Empty));
		}

		//	POST: api/shares/content/{id}/collect — a link-only entry added to my collection
		[HttpPost("content/{id:guid}/collect")]
		public async Task<IActionResult> Collect(Guid id)
		{
			var entity = await FindAsync(id);
			if (entity is null || entity.IsOfficialSRD || entity.Visibility != ContentVisibility.Link || entity.AuthorId == UserId)
			{
				return NotFound();
			}
			if (!await _context.ContentShares.AnyAsync(s => s.EntityId == id && s.UserId == UserId))
			{
				_context.ContentShares.Add(new ContentShare { EntityId = id, UserId = UserId, GrantedById = UserId });
				await _context.SaveChangesAsync();
			}
			return NoContent();
		}

		//	DELETE: api/shares/content/{id}/{userId} — the author removes a person, or a person leaves ("me")
		[HttpDelete("content/{id:guid}/{userId}")]
		public async Task<IActionResult> Unshare(Guid id, string userId)
		{
			var target = userId == "me" ? UserId : userId;
			var share = await _context.ContentShares.FirstOrDefaultAsync(s => s.EntityId == id && s.UserId == target);
			if (share is null)
			{
				return NotFound();
			}
			if (target != UserId)
			{
				var entity = await FindAsync(id);
				if (entity is null || !_access.CanModify(entity, User))
				{
					return NotFound();
				}
			}
			_context.ContentShares.Remove(share);
			await _context.SaveChangesAsync();
			return NoContent();
		}

		// ===== Helpers =====

		//	The Homebrew entry with this id, whatever its kind
		private async Task<GameEntity?> FindAsync(Guid id) =>
			(GameEntity?)await _context.Species.FirstOrDefaultAsync(e => e.Id == id)
			?? (GameEntity?)await _context.Subspecies.FirstOrDefaultAsync(e => e.Id == id)
			?? (GameEntity?)await _context.Classes.FirstOrDefaultAsync(e => e.Id == id)
			?? (GameEntity?)await _context.Subclasses.FirstOrDefaultAsync(e => e.Id == id)
			?? (GameEntity?)await _context.Backgrounds.FirstOrDefaultAsync(e => e.Id == id)
			?? (GameEntity?)await _context.Feats.FirstOrDefaultAsync(e => e.Id == id)
			?? (GameEntity?)await _context.Spells.FirstOrDefaultAsync(e => e.Id == id)
			?? (GameEntity?)await _context.Equipment.FirstOrDefaultAsync(e => e.Id == id)
			?? (GameEntity?)await _context.Monsters.FirstOrDefaultAsync(e => e.Id == id)
			?? await _context.MagicItems.FirstOrDefaultAsync(e => e.Id == id);

		internal async Task<(ApplicationUser? User, ActionResult? Problem)> FindUserAsync(string? email)
		{
			var address = email?.Trim();
			if (string.IsNullOrEmpty(address) || address.Length > 256 || !address.Contains('@'))
			{
				return (null, Problem(statusCode: StatusCodes.Status400BadRequest, title: "Invalid e-mail address."));
			}
			var user = await _users.FindByEmailAsync(address);
			if (user is null)
			{
				return (null, Problem(statusCode: StatusCodes.Status404NotFound, title: "No account with this e-mail address."));
			}
			if (user.Id == UserId)
			{
				return (null, Problem(statusCode: StatusCodes.Status400BadRequest, title: "You cannot share with yourself."));
			}
			return (user, null);
		}

		internal async Task<List<ShareUserDto>> ToUsersAsync(IEnumerable<string> ids)
		{
			var list = ids.Distinct().ToList();
			var users = await _context.Users.AsNoTracking().Where(u => list.Contains(u.Id)).Select(u => new { u.Id, u.Email }).ToListAsync();
			return users.Select(u => new ShareUserDto(u.Id, u.Email ?? string.Empty)).OrderBy(u => u.Email).ToList();
		}
	}
}
