using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealmForge.Api.Achievements;
using RealmForge.Api.Security;
using RealmForge.Infrastructure.Persistence;
using RealmForge.Shared.Dice;
using RealmForge.Shared.DTOs;

namespace RealmForge.Api.Controllers
{
	///	<summary>
	///	The special looks of the 3D dice of the user and the achievements that unlock them: what has been reached, the ones
	///	earned and not told yet (the notices), and the person's own clock (for the achievements made at night).
	///	</summary>
	[ApiController]
	[Route("api/account")]
	[Authorize]
	public class DiceController : ControllerBase
	{
		private readonly RealmForgeDbContext _context;
		private readonly AchievementService _achievements;

		public DiceController(RealmForgeDbContext context, AchievementService achievements)
		{
			_context = context;
			_achievements = achievements;
		}

		private string UserId => ContentAccess.GetUserId(User) ?? string.Empty;

		//	GET: api/account/dice — the special dice of the user (what was reached in the meantime counts)
		[HttpGet("dice")]
		public async Task<ActionResult<DiceSkinsDto>> Get()
		{
			await _achievements.EvaluateAsync(UserId, full: false);
			var mine = await _context.UserDiceSkins.AsNoTracking().Where(s => s.UserId == UserId).Select(s => s.Skin).ToListAsync();
			return Ok(new DiceSkinsDto(DiceSkins.Unlockable.Where(mine.Contains).ToList()));
		}

		//	GET: api/account/achievements — the achievements of the profile (the hidden ones only once earned)
		[HttpGet("achievements")]
		public async Task<ActionResult<List<AchievementDto>>> GetAchievements() =>
			Ok(await _achievements.ListAsync(UserId, all: false));

		//	GET: api/account/achievements/news — earned and not told yet
		[HttpGet("achievements/news")]
		public async Task<ActionResult<List<AchievementDto>>> GetNews() =>
			Ok(await _achievements.NewsAsync(UserId));

		//	POST: api/account/achievements/seen — told
		[HttpPost("achievements/seen")]
		public async Task<IActionResult> Seen([FromBody] AchievementsSeenDto dto)
		{
			await _achievements.SeenAsync(UserId, dto.Keys.Take(50).ToList());
			return NoContent();
		}

		//	PUT: api/account/timezone — the person's own clock
		[HttpPut("timezone")]
		public async Task<IActionResult> SetTimeZone([FromBody] TimeZoneDto dto) =>
			await _achievements.SetTimeZoneAsync(UserId, dto.TimeZone?.Trim()) ? NoContent() : BadRequest();
	}
}
