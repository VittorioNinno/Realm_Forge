using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealmForge.Api.Security;
using RealmForge.Infrastructure.Identity;
using RealmForge.Infrastructure.Persistence;
using RealmForge.Shared.DTOs;

namespace RealmForge.Api.Controllers
{
	///	<summary>
	///	Account information for the signed-in user. Sign-in, registration and password changes
	///	are served by the Identity endpoints under /api/auth.
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
				await _context.Backgrounds.CountAsync(b => b.AuthorId == user.Id));

			return new AccountSummaryDto(
				user.Email ?? user.UserName ?? string.Empty,
				user.EmailConfirmed,
				_access.IsAdmin(User),
				user.RegisteredAt,
				counts);
		}
	}
}
