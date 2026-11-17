using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealmForge.Api.Security;
using RealmForge.Domain.Entities;
using RealmForge.Infrastructure.Persistence;
using RealmForge.Shared.Campaigns;
using RealmForge.Shared.DTOs;
using RealmForge.Shared.Enums;

namespace RealmForge.Api.Controllers
{
	///	<summary>
	///	The handouts of a campaign: letters, clues, pictures the masters prepare and reveal to the players during a
	///	session. The players see the revealed ones only, in their language; a reveal opens it on their screens at the
	///	table (the table of the map shown wakes up with it).
	///	</summary>
	[ApiController]
	[Route("api/campaigns/{campaignId:guid}/handouts")]
	[Authorize]
	public class HandoutsController : ControllerBase
	{
		public const int MaxHandouts = 200;

		private readonly RealmForgeDbContext _context;

		public HandoutsController(RealmForgeDbContext context)
		{
			_context = context;
		}

		private string UserId => ContentAccess.GetUserId(User) ?? string.Empty;

		//	GET: api/campaigns/{campaignId}/handouts?lang=2 — the masters every one, a player the revealed ones
		[HttpGet]
		public async Task<ActionResult<List<CampaignHandoutDto>>> GetHandouts(Guid campaignId, [FromQuery] LanguageCode lang = LanguageCode.It)
		{
			if (await CampaignAccess.RoleAsync(_context, campaignId, UserId) is not { } role)
			{
				return NotFound();
			}
			var runs = CampaignRules.RunsTheTable(role);
			var handouts = await _context.CampaignHandouts.AsNoTracking()
				.Where(h => h.CampaignId == campaignId && (runs || h.RevealedAt != null))
				.OrderByDescending(h => h.RevealedAt ?? h.CreatedAt)
				.ToListAsync();
			var scene = await _context.Campaigns.AsNoTracking().Where(c => c.Id == campaignId).Select(c => c.SceneHandoutId).FirstOrDefaultAsync();
			return Ok(handouts.Select(h => ToDto(h, lang, runs) with { IsScene = h.Id == scene }).ToList());
		}

		//	GET: api/campaigns/{campaignId}/handouts/{id}?lang=2
		[HttpGet("{id:guid}")]
		public async Task<ActionResult<CampaignHandoutDto>> GetHandout(Guid campaignId, Guid id, [FromQuery] LanguageCode lang = LanguageCode.It)
		{
			if (await CampaignAccess.RoleAsync(_context, campaignId, UserId) is not { } role)
			{
				return NotFound();
			}
			var runs = CampaignRules.RunsTheTable(role);
			var handout = await _context.CampaignHandouts.AsNoTracking().FirstOrDefaultAsync(h => h.Id == id && h.CampaignId == campaignId && (runs || h.RevealedAt != null));
			return handout is null ? NotFound() : Ok(ToDto(handout, lang, runs));
		}

		//	POST: api/campaigns/{campaignId}/handouts — masters and co-masters
		[HttpPost]
		public async Task<ActionResult<CampaignHandoutDto>> AddHandout(Guid campaignId, [FromBody] SaveCampaignHandoutDto dto, [FromQuery] LanguageCode lang = LanguageCode.It)
		{
			if (await CampaignAccess.RoleAsync(_context, campaignId, UserId) is not { } role)
			{
				return NotFound();
			}
			if (!CampaignRules.RunsTheTable(role))
			{
				return Forbid();
			}
			if (Validate(dto) is { } error)
			{
				return error;
			}
			if (await _context.CampaignHandouts.CountAsync(h => h.CampaignId == campaignId) >= MaxHandouts)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: $"At most {MaxHandouts} handouts per campaign.");
			}
			var handout = new CampaignHandout { CampaignId = campaignId, AuthorId = UserId };
			Apply(handout, dto);
			_context.CampaignHandouts.Add(handout);
			await _context.SaveChangesAsync();
			return Ok(ToDto(handout, lang, true));
		}

		//	PUT: api/campaigns/{campaignId}/handouts/{id}
		[HttpPut("{id:guid}")]
		public async Task<IActionResult> UpdateHandout(Guid campaignId, Guid id, [FromBody] SaveCampaignHandoutDto dto)
		{
			var (handout, error) = await MastersHandoutAsync(campaignId, id);
			if (handout is null)
			{
				return error!;
			}
			if (Validate(dto) is { } invalid)
			{
				return invalid;
			}
			Apply(handout, dto);
			handout.UpdatedAt = DateTimeOffset.UtcNow;
			await _context.SaveChangesAsync();
			return NoContent();
		}

		//	DELETE: api/campaigns/{campaignId}/handouts/{id}
		[HttpDelete("{id:guid}")]
		public async Task<IActionResult> DeleteHandout(Guid campaignId, Guid id)
		{
			var (handout, error) = await MastersHandoutAsync(campaignId, id);
			if (handout is null)
			{
				return error!;
			}
			if (await _context.Campaigns.FirstAsync(c => c.Id == campaignId) is { } campaign && campaign.SceneHandoutId == handout.Id)
			{
				campaign.SceneHandoutId = null;
				await WakeTableAsync(campaignId);
			}
			_context.CampaignHandouts.Remove(handout);
			await _context.SaveChangesAsync();
			return NoContent();
		}

		//	POST: api/campaigns/{campaignId}/handouts/{id}/reveal — shown to the players now (again, when it was already)
		[HttpPost("{id:guid}/reveal")]
		public Task<IActionResult> Reveal(Guid campaignId, Guid id) => SetRevealedAsync(campaignId, id, true);

		//	POST: api/campaigns/{campaignId}/handouts/{id}/hide — back behind the screen
		[HttpPost("{id:guid}/hide")]
		public Task<IActionResult> Hide(Guid campaignId, Guid id) => SetRevealedAsync(campaignId, id, false);

		//	POST: api/campaigns/{campaignId}/handouts/{id}/scene — the handout in place of the map for the whole table
		//	(revealed with it); DELETE api/campaigns/{campaignId}/handouts/scene — back to the map
		[HttpPost("{id:guid}/scene")]
		public async Task<IActionResult> ShowScene(Guid campaignId, Guid id)
		{
			var (handout, error) = await MastersHandoutAsync(campaignId, id);
			if (handout is null)
			{
				return error!;
			}
			var campaign = await _context.Campaigns.FirstAsync(c => c.Id == campaignId);
			campaign.SceneHandoutId = handout.Id;
			handout.RevealedAt ??= DateTimeOffset.UtcNow;
			await WakeTableAsync(campaignId);
			await _context.SaveChangesAsync();
			return NoContent();
		}

		[HttpDelete("scene")]
		public async Task<IActionResult> EndScene(Guid campaignId)
		{
			if (await CampaignAccess.RoleAsync(_context, campaignId, UserId) is not { } role)
			{
				return NotFound();
			}
			if (!CampaignRules.RunsTheTable(role))
			{
				return Forbid();
			}
			var campaign = await _context.Campaigns.FirstAsync(c => c.Id == campaignId);
			campaign.SceneHandoutId = null;
			await WakeTableAsync(campaignId);
			await _context.SaveChangesAsync();
			return NoContent();
		}

		//	The table of the map shown wakes up: the players' screens follow at once
		private async Task WakeTableAsync(Guid campaignId)
		{
			var now = DateTimeOffset.UtcNow;
			foreach (var map in await _context.CampaignMaps.Where(m => m.CampaignId == campaignId && m.Shown).ToListAsync())
			{
				map.UpdatedAt = now;
			}
		}

		private async Task<IActionResult> SetRevealedAsync(Guid campaignId, Guid id, bool revealed)
		{
			var (handout, error) = await MastersHandoutAsync(campaignId, id);
			if (handout is null)
			{
				return error!;
			}
			var now = DateTimeOffset.UtcNow;
			handout.RevealedAt = revealed ? now : null;
			handout.UpdatedAt = now;
			if (!revealed && await _context.Campaigns.FirstAsync(c => c.Id == campaignId) is { } campaign && campaign.SceneHandoutId == handout.Id)
			{
				campaign.SceneHandoutId = null;
			}

			//	The table of the map shown wakes up: the players' screens open the handout
			await WakeTableAsync(campaignId);
			await _context.SaveChangesAsync();
			return NoContent();
		}

		private async Task<(CampaignHandout? Handout, IActionResult? Error)> MastersHandoutAsync(Guid campaignId, Guid id)
		{
			if (await CampaignAccess.RoleAsync(_context, campaignId, UserId) is not { } role)
			{
				return (null, NotFound());
			}
			if (!CampaignRules.RunsTheTable(role))
			{
				return (null, Forbid());
			}
			var handout = await _context.CampaignHandouts.FirstOrDefaultAsync(h => h.Id == id && h.CampaignId == campaignId);
			return handout is null ? (null, NotFound()) : (handout, null);
		}

		private ActionResult? Validate(SaveCampaignHandoutDto dto)
		{
			var titleIt = (dto.TitleIt ?? string.Empty).Trim();
			var titleEn = (dto.TitleEn ?? string.Empty).Trim();
			if (titleIt.Length + titleEn.Length == 0 || titleIt.Length > 120 || titleEn.Length > 120
				|| (dto.BodyIt ?? string.Empty).Length > 8000 || (dto.BodyEn ?? string.Empty).Length > 8000)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "A title (up to 120 characters) and texts up to 8000 characters.");
			}
			return null;
		}

		private static void Apply(CampaignHandout handout, SaveCampaignHandoutDto dto)
		{
			handout.TitleIt = (dto.TitleIt ?? string.Empty).Trim();
			handout.TitleEn = (dto.TitleEn ?? string.Empty).Trim();
			handout.BodyIt = (dto.BodyIt ?? string.Empty).Trim();
			handout.BodyEn = (dto.BodyEn ?? string.Empty).Trim();
			handout.ImageId = dto.ImageId;
		}

		//	The texts in the language asked, the other one when it has only that
		public static CampaignHandoutDto ToDto(CampaignHandout h, LanguageCode lang, bool runs)
		{
			static string Pick(string first, string second) => first.Length > 0 ? first : second;
			var it = lang == LanguageCode.It;
			var title = it ? Pick(h.TitleIt, h.TitleEn) : Pick(h.TitleEn, h.TitleIt);
			var body = it ? Pick(h.BodyIt, h.BodyEn) : Pick(h.BodyEn, h.BodyIt);
			return runs
				? new CampaignHandoutDto(h.Id, title, body, h.ImageId, h.RevealedAt, h.UpdatedAt, h.TitleIt, h.TitleEn, h.BodyIt, h.BodyEn)
				: new CampaignHandoutDto(h.Id, title, body, h.ImageId, h.RevealedAt, h.UpdatedAt);
		}
	}
}
