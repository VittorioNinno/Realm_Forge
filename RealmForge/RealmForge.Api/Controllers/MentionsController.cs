using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealmForge.Api.Security;
using RealmForge.Infrastructure.Persistence;
using RealmForge.Shared.Campaigns;
using RealmForge.Shared.DTOs;
using RealmForge.Shared.Enums;

namespace RealmForge.Api.Controllers
{
	///	<summary>
	///	What a note of the campaign can mention with @, as the reader sees it: the characters, the NPCs shared with the
	///	campaign, the shops (a player: the open ones), the factions and the handouts shown to them, the maps (masters) and
	///	the pages of the journal.
	///	</summary>
	[ApiController]
	[Route("api/campaigns/{campaignId:guid}/mentions")]
	[Authorize]
	public class MentionsController : ControllerBase
	{
		private readonly RealmForgeDbContext _context;

		public MentionsController(RealmForgeDbContext context)
		{
			_context = context;
		}

		private string UserId => ContentAccess.GetUserId(User) ?? string.Empty;

		[HttpGet]
		public async Task<ActionResult<List<MentionDto>>> Get(Guid campaignId, [FromQuery] LanguageCode lang = LanguageCode.It)
		{
			if (await CampaignAccess.RoleAsync(_context, campaignId, UserId) is not { } role)
			{
				return NotFound();
			}
			var runs = CampaignRules.RunsTheTable(role);
			var en = lang == LanguageCode.En;
			var list = new List<MentionDto>();

			list.AddRange((await _context.CampaignCharacters.AsNoTracking().Where(c => c.CampaignId == campaignId)
				.Select(c => new { c.CharacterId, c.Character.Name }).ToListAsync())
				.Select(c => new MentionDto("character", c.CharacterId, c.Name)));

			var npcIds = await _context.CampaignContents.AsNoTracking()
				.Where(c => c.CampaignId == campaignId && (runs || c.Status == CampaignContentStatus.Approved)).Select(c => c.EntityId).ToListAsync();
			var npcs = await _context.Monsters.AsNoTracking().Include(m => m.Translations).Where(m => m.IsNpc && npcIds.Contains(m.Id)).ToListAsync();
			list.AddRange(npcs.Select(m => new MentionDto("npc", m.Id,
				(m.Translations.FirstOrDefault(t => t.Language == lang) ?? m.Translations.FirstOrDefault())?.Name ?? "?")));

			list.AddRange((await _context.CampaignShops.AsNoTracking().Where(s => s.CampaignId == campaignId && (runs || s.Open)).ToListAsync())
				.Select(s => new MentionDto("shop", s.Id, Either(en ? s.NameEn : s.NameIt, en ? s.NameIt : s.NameEn))));

			list.AddRange((await _context.CampaignFactions.AsNoTracking().Where(f => f.CampaignId == campaignId && (runs || f.Shown)).ToListAsync())
				.Select(f => new MentionDto("faction", f.Id, f.Name)));

			list.AddRange((await _context.CampaignHandouts.AsNoTracking().Where(h => h.CampaignId == campaignId && (runs || h.RevealedAt != null)).ToListAsync())
				.Select(h => new MentionDto("handout", h.Id, Either(en ? h.TitleEn : h.TitleIt, en ? h.TitleIt : h.TitleEn))));

			if (runs)
			{
				list.AddRange((await _context.CampaignMaps.AsNoTracking().Where(m => m.CampaignId == campaignId).Select(m => new { m.Id, m.Name }).ToListAsync())
					.Select(m => new MentionDto("map", m.Id, m.Name)));
			}

			list.AddRange((await _context.CampaignNotes.AsNoTracking()
				.Where(n => n.CampaignId == campaignId && n.Kind == CampaignNoteKind.Journal && n.Title != string.Empty)
				.Select(n => new { n.Id, n.Title }).ToListAsync())
				.Select(n => new MentionDto("note", n.Id, n.Title)));

			return Ok(list.Where(m => !string.IsNullOrWhiteSpace(m.Name))
				.OrderBy(m => m.Name, StringComparer.CurrentCultureIgnoreCase).Take(500).ToList());
		}

		private static string Either(string first, string second) => string.IsNullOrWhiteSpace(first) ? second : first;
	}
}
