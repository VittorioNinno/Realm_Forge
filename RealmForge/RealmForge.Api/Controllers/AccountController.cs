using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using RealmForge.Api.Email;
using RealmForge.Api.Security;
using RealmForge.Infrastructure.Identity;
using RealmForge.Infrastructure.Persistence;
using RealmForge.Shared.DTOs;
using RealmForge.Shared.Text;

namespace RealmForge.Api.Controllers
{
	///	<summary>
	///	Account information for the signed-in user and the deletion of the account. Sign-in, registration, password
	///	and e-mail changes are served by the Identity endpoints under /api/auth.
	///	</summary>
	[ApiController]
	[Route("api/[controller]")]
	[Authorize]
	public class AccountController : ControllerBase
	{
		private readonly RealmForgeDbContext _context;
		private readonly UserManager<ApplicationUser> _users;
		private readonly ContentAccess _access;

		public AccountController(RealmForgeDbContext context, UserManager<ApplicationUser> users, ContentAccess access)
		{
			_context = context;
			_users = users;
			_access = access;
		}

		//	GET: api/account/summary
		[HttpGet("summary")]
		public async Task<ActionResult<AccountSummaryDto>> GetSummary()
		{
			var user = await _users.GetUserAsync(User);

			if (user == null)
			{
				return Unauthorized();
			}

			//	Sequential queries: a DbContext does not support concurrent operations
			var counts = new HomebrewCountsDto(
				await _context.Feats.CountAsync(f => f.AuthorId == user.Id),
				await _context.Species.CountAsync(s => s.AuthorId == user.Id),
				await _context.Subspecies.CountAsync(s => s.AuthorId == user.Id),
				await _context.Backgrounds.CountAsync(b => b.AuthorId == user.Id),
				await _context.Spells.CountAsync(s => s.AuthorId == user.Id),
				await _context.Classes.CountAsync(c => c.AuthorId == user.Id),
				await _context.Subclasses.CountAsync(s => s.AuthorId == user.Id),
				await _context.Equipment.CountAsync(e => e.AuthorId == user.Id),
				await _context.Monsters.CountAsync(m => m.AuthorId == user.Id),
				await _context.MagicItems.CountAsync(m => m.AuthorId == user.Id));

			return new AccountSummaryDto(
				user.Email ?? user.UserName ?? string.Empty,
				user.EmailConfirmed,
				_access.IsAdmin(User),
				user.RegisteredAt,
				counts,
				user.Nickname);
		}

		//	PUT: api/account/nickname — the public name (empty removes it); 409 when another account uses it
		[HttpPut("nickname")]
		public async Task<IActionResult> SetNickname([FromBody] NicknameRequestDto request)
		{
			var user = await _users.GetUserAsync(User);
			if (user == null)
			{
				return Unauthorized();
			}

			var nickname = Nicknames.Clean(request.Nickname);
			if (nickname is not null && !Nicknames.IsValid(nickname))
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest,
					title: $"A nickname has {Nicknames.MinLength}-{Nicknames.MaxLength} letters, digits, spaces, dots, dashes or underscores.");
			}

			var normalized = nickname is null ? null : Nicknames.Normalize(nickname);
			if (normalized is not null && await _context.Users.AnyAsync(u => u.NormalizedNickname == normalized && u.Id != user.Id))
			{
				return Problem(statusCode: StatusCodes.Status409Conflict, title: "This nickname is already taken.");
			}

			user.Nickname = nickname;
			user.NormalizedNickname = normalized;
			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateException)
			{
				//	Taken at the same moment by someone else: the unique index decides
				return Problem(statusCode: StatusCodes.Status409Conflict, title: "This nickname is already taken.");
			}
			return Ok(new NicknameRequestDto { Nickname = nickname });
		}

		//	DELETE: api/account — the password confirms it; the data goes as AccountDeletion describes, then the account
		[HttpDelete]
		[EnableRateLimiting(Program.AuthRateLimit)]
		public async Task<ActionResult<AccountDeletedDto>> DeleteAccount([FromBody] DeleteAccountRequestDto request, [FromServices] AccountDeletion deletion,
			[FromServices] AccountNotices notices)
		{
			var user = await _users.GetUserAsync(User);
			if (user == null)
			{
				return Unauthorized();
			}
			if (string.IsNullOrEmpty(request.Password) || !await _users.CheckPasswordAsync(user, request.Password))
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "Wrong password.");
			}

			var email = user.Email;
			var outcome = await deletion.RemoveDataAsync(user.Id);
			var result = await _users.DeleteAsync(user);
			if (!result.Succeeded)
			{
				return Problem(statusCode: StatusCodes.Status500InternalServerError, title: "The account could not be deleted.");
			}
			if (email is { Length: > 0 })
			{
				await notices.DeletedAsync(email, byAdministrator: false);
			}
			return Ok(new AccountDeletedDto(outcome.Characters, outcome.HomebrewDeleted, outcome.HomebrewKept, outcome.CampaignsDeleted, outcome.CampaignsHandedOver));
		}
	}
}
