using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealmForge.Api.Security;
using RealmForge.Domain.Entities;
using RealmForge.Infrastructure.Persistence;
using RealmForge.Shared.Campaigns;
using RealmForge.Shared.Characters;
using RealmForge.Shared.DTOs;
using RealmForge.Shared.Enums;

namespace RealmForge.Api.Controllers
{
	///	<summary>
	///	The clock of a campaign: the time inside the game, which the masters move on (ten minutes, an hour, a long rest,
	///	days of travel). The effects of the characters that last on it end when it passes them (the concentration on
	///	their spell with them); days of travel can eat a ration a day from each character at the table.
	///	</summary>
	[ApiController]
	[Route("api/campaigns/{campaignId:guid}/clock")]
	[Authorize]
	public class ClockController : ControllerBase
	{
		private readonly RealmForgeDbContext _context;

		public ClockController(RealmForgeDbContext context)
		{
			_context = context;
		}

		private string UserId => ContentAccess.GetUserId(User) ?? string.Empty;

		//	GET: api/campaigns/{campaignId}/clock — the time and the effects running at the table
		[HttpGet]
		public async Task<ActionResult<CampaignClockDto>> GetClock(Guid campaignId)
		{
			if (await CampaignAccess.RoleAsync(_context, campaignId, UserId) is null)
			{
				return NotFound();
			}
			var minutes = await _context.Campaigns.AsNoTracking().Where(c => c.Id == campaignId).Select(c => c.GameMinutes).FirstAsync();
			var effects = new List<ClockEffectDto>();
			foreach (var character in await CharactersAsync(campaignId, tracking: false))
			{
				effects.AddRange(CharactersController.ReadSheet(character.Sheet).TimedEffects
					.Where(e => e.CampaignId == campaignId && e.Until > minutes)
					.Select(e => new ClockEffectDto(character.Id, character.Name, e.Name, e.Until)));
			}
			return Ok(new CampaignClockDto(minutes, effects.OrderBy(e => e.Until).ToList()));
		}

		//	POST: api/campaigns/{campaignId}/clock — a master moves the time on (or sets it: Set); with Rations, each day that
		//	begins eats a ration from every active character at the table
		[HttpPost]
		public async Task<ActionResult<ClockMovedDto>> Move(Guid campaignId, [FromBody] MoveClockDto dto)
		{
			if (await CampaignAccess.RoleAsync(_context, campaignId, UserId) is not { } role)
			{
				return NotFound();
			}
			if (!CampaignRules.RunsTheTable(role))
			{
				return Forbid();
			}
			if (dto.Set is null && dto.Minutes is < 1 or > GameClock.MaxStep || dto.Set is < 0 or > GameClock.MaxMinutes)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: $"A step from 1 to {GameClock.MaxStep} minutes, or a time from 0.");
			}
			var campaign = await _context.Campaigns.FirstAsync(c => c.Id == campaignId);
			var from = campaign.GameMinutes;
			var to = dto.Set ?? Math.Min(GameClock.MaxMinutes, from + dto.Minutes);
			campaign.GameMinutes = to;

			var days = dto.Rations && dto.Set is null ? GameClock.DaysCrossed(from, to) : 0;
			var characters = await CharactersAsync(campaignId, tracking: true);
			var english = days > 0 ? await EnglishNamesAsync(characters) : new Dictionary<Guid, string>();
			var expired = new List<ClockEffectDto>();
			var hungry = new List<ClockHungerDto>();
			foreach (var character in characters)
			{
				var sheet = CharactersController.ReadSheet(character.Sheet);
				var ended = sheet.TimedEffects.Where(e => e.CampaignId == campaignId && e.Until <= to).ToList();
				var changed = false;
				if (ended.Count > 0)
				{
					sheet.TimedEffects.RemoveAll(ended.Contains);
					if (sheet.Concentration is { } concentration && ended.Any(e => e.SpellId == concentration))
					{
						sheet.Concentration = null;
					}
					sheet.VitalsStamp++;
					expired.AddRange(ended.Select(e => new ClockEffectDto(character.Id, character.Name, e.Name, e.Until)));
					changed = true;
				}
				if (days > 0 && !inactive.Contains(character.Id))
				{
					var missing = InventoryRules.EatRations(sheet, i => i.EquipmentId is { } id ? english.GetValueOrDefault(id) : null, days);
					if (missing > 0)
					{
						hungry.Add(new ClockHungerDto(character.Id, character.Name, missing));
					}

					//	Only an inventory that lost rations is written (and wins over the copies open)
					if (missing < days)
					{
						sheet.StoreStamp++;
						changed = true;
					}
				}
				if (changed)
				{
					character.Sheet = JsonSerializer.Serialize(sheet, CharactersController.Json);
					character.UpdatedAt = DateTimeOffset.UtcNow;
					character.UpdatedById = UserId;
				}
			}

			//	The table of the map shown wakes up: the clock on the players' screens follows
			var now = DateTimeOffset.UtcNow;
			foreach (var map in await _context.CampaignMaps.Where(m => m.CampaignId == campaignId && m.Shown).ToListAsync())
			{
				map.UpdatedAt = now;
			}
			await _context.SaveChangesAsync();
			return Ok(new ClockMovedDto(to, days, expired, hungry));
		}

		private HashSet<Guid> inactive = new();

		//	The characters at the table (the inactive ones noted: they sit out the journey)
		private async Task<List<Character>> CharactersAsync(Guid campaignId, bool tracking)
		{
			var rows = await _context.CampaignCharacters.AsNoTracking().Where(cc => cc.CampaignId == campaignId)
				.Select(cc => new { cc.CharacterId, cc.Inactive }).ToListAsync();
			inactive = rows.Where(r => r.Inactive).Select(r => r.CharacterId).ToHashSet();
			var ids = rows.Select(r => r.CharacterId).ToList();
			var query = _context.Characters.Where(c => ids.Contains(c.Id));
			return await (tracking ? query : query.AsNoTracking()).OrderBy(c => c.Name).ToListAsync();
		}

		//	The English names of the compendium items in the inventories (to find the rations)
		private async Task<Dictionary<Guid, string>> EnglishNamesAsync(IEnumerable<Character> characters)
		{
			var ids = characters.SelectMany(c => CharactersController.ReadSheet(c.Sheet).Inventory)
				.Where(i => i.EquipmentId != null).Select(i => i.EquipmentId!.Value).Distinct().ToList();
			return await _context.Equipment.AsNoTracking().Where(e => ids.Contains(e.Id))
				.Select(e => new { e.Id, Name = e.Translations.Where(t => t.Language == LanguageCode.En).Select(t => t.Name).FirstOrDefault() })
				.ToDictionaryAsync(e => e.Id, e => e.Name ?? string.Empty);
		}
	}
}
