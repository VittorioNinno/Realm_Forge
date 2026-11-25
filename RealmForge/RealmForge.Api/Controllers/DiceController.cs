using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using RealmForge.Api.Security;
using RealmForge.Domain.Entities;
using RealmForge.Infrastructure.Persistence;
using RealmForge.Shared.Dice;
using RealmForge.Shared.DTOs;

namespace RealmForge.Api.Controllers
{
	///	<summary>
	///	The special looks of the 3D dice unlocked by the user: an easter egg, a code that unlocks one. The codes are kept
	///	as hashes (DiceUnlockCodes); trying them is limited like a login, against guessing.
	///	</summary>
	[ApiController]
	[Route("api/account/dice")]
	[Authorize]
	public class DiceController : ControllerBase
	{
		private readonly RealmForgeDbContext _context;

		public DiceController(RealmForgeDbContext context)
		{
			_context = context;
		}

		private string UserId => ContentAccess.GetUserId(User) ?? string.Empty;

		//	GET: api/account/dice — the special dice of the user
		[HttpGet]
		public async Task<ActionResult<DiceSkinsDto>> Get() =>
			Ok(new DiceSkinsDto(await UnlockedAsync()));

		//	POST: api/account/dice/unlock — a code; the right one unlocks its dice for good
		[HttpPost("unlock")]
		[EnableRateLimiting(Program.AuthRateLimit)]
		public async Task<ActionResult<DiceUnlockResultDto>> Unlock([FromBody] DiceUnlockDto dto)
		{
			var normalized = DiceSkins.Normalize(dto.Code);
			if (normalized.Length is < 4 or > 64)
			{
				return Ok(new DiceUnlockResultDto(null, false, await UnlockedAsync()));
			}
			var hash = DiceSkins.Hash(normalized);
			var code = await _context.DiceUnlockCodes.AsNoTracking().FirstOrDefaultAsync(c => c.CodeHash == hash && c.Active);
			if (code is null || !DiceSkins.IsKnown(code.Skin))
			{
				return Ok(new DiceUnlockResultDto(null, false, await UnlockedAsync()));
			}
			var already = await _context.UserDiceSkins.AnyAsync(s => s.UserId == UserId && s.Skin == code.Skin);
			if (!already)
			{
				_context.UserDiceSkins.Add(new UserDiceSkin { UserId = UserId, Skin = code.Skin });
				await _context.SaveChangesAsync();
			}
			return Ok(new DiceUnlockResultDto(code.Skin, !already, await UnlockedAsync()));
		}

		private async Task<List<string>> UnlockedAsync()
		{
			var mine = await _context.UserDiceSkins.AsNoTracking().Where(s => s.UserId == UserId).Select(s => s.Skin).ToListAsync();
			return DiceSkins.Unlockable.Where(mine.Contains).ToList();
		}
	}
}
