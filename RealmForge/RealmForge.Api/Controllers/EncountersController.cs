using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealmForge.Api.Security;
using RealmForge.Domain.Entities;
using RealmForge.Infrastructure.Persistence;
using RealmForge.Shared.Campaigns;
using RealmForge.Shared.DTOs;

namespace RealmForge.Api.Controllers
{
	///	<summary>
	///	Encounters of a campaign. Masters and co-masters prepare them (monsters from the compendium, the characters of the
	///	campaign, anything else) and run them (initiative, hit points, conditions, rounds); the players see only the
	///	encounters under way that were shown to them, without the hidden combatants, the notes and the monsters' numbers.
	///	The characters on the field show their sheet (hit points, temporary hit points, armor class, conditions) and what
	///	a master changes on them is written to the sheet (<see cref="EncounterSheetSync"/>). Non-members get 404, like
	///	the campaign itself.
	///	</summary>
	[ApiController]
	[Route("api/campaigns/{campaignId:guid}/encounters")]
	[Authorize]
	public class EncountersController : ControllerBase
	{
		private static readonly JsonSerializerOptions Json = new(JsonSerializerDefaults.Web);

		private readonly RealmForgeDbContext _context;

		public EncountersController(RealmForgeDbContext context)
		{
			_context = context;
		}

		private string UserId => ContentAccess.GetUserId(User) ?? string.Empty;

		//	GET: api/campaigns/{campaignId}/encounters
		[HttpGet]
		public async Task<ActionResult<List<EncounterSummaryDto>>> GetEncounters(Guid campaignId)
		{
			var role = await RoleAsync(campaignId);
			if (role is not { } me)
			{
				return NotFound();
			}

			var rows = await _context.CampaignEncounters.AsNoTracking()
				.Where(e => e.CampaignId == campaignId)
				.OrderByDescending(e => e.UpdatedAt)
				.ToListAsync();

			return Ok(rows
				.Where(e => EncounterRules.CanSee(me, e.Status, e.Shown))
				.Select(e =>
				{
					var visible = Read(e.Combatants).Where(c => EncounterRules.CanManage(me) || !c.Hidden).ToList();
					var monsters = visible.Where(c => c.Kind == CombatantKind.Monster).ToList();
					return new EncounterSummaryDto(e.Id, e.Name, e.Status, e.Round, monsters.Count,
						EncounterRules.CanManage(me) ? monsters.Sum(c => c.Xp) : 0, e.Shown, e.UpdatedAt);
				})
				.ToList());
		}

		//	GET: api/campaigns/{campaignId}/encounters/{id}
		[HttpGet("{id:guid}")]
		public async Task<ActionResult<EncounterDto>> GetEncounter(Guid campaignId, Guid id)
		{
			var role = await RoleAsync(campaignId);
			if (role is not { } me)
			{
				return NotFound();
			}
			var encounter = await _context.CampaignEncounters.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id && e.CampaignId == campaignId);
			if (encounter is null || !EncounterRules.CanSee(me, encounter.Status, encounter.Shown))
			{
				return NotFound();
			}
			return Ok(await ToDtoAsync(encounter, me));
		}

		//	POST: api/campaigns/{campaignId}/encounters
		[HttpPost]
		public async Task<ActionResult<EncounterDto>> CreateEncounter(Guid campaignId, [FromBody] SaveEncounterDto dto)
		{
			var role = await RoleAsync(campaignId);
			if (role is not { } me)
			{
				return NotFound();
			}
			if (!EncounterRules.CanManage(me))
			{
				return Forbid();
			}
			if (await _context.CampaignEncounters.CountAsync(e => e.CampaignId == campaignId) >= EncounterRules.MaxEncounters)
			{
				return Problem(statusCode: StatusCodes.Status409Conflict, title: $"At most {EncounterRules.MaxEncounters} encounters per campaign.");
			}
			var error = Validate(dto);
			if (error is not null)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: error);
			}

			var encounter = new CampaignEncounter { CampaignId = campaignId, CreatedById = UserId };
			await ApplyAsync(encounter, dto);

			//	A new encounter is balanced for every character of the campaign unless told otherwise
			if (dto.PartyIds.Count == 0)
			{
				encounter.PartyIds = await _context.CampaignCharacters.Where(c => c.CampaignId == campaignId && !c.Inactive).Select(c => c.CharacterId).ToListAsync();
			}

			_context.CampaignEncounters.Add(encounter);
			await _context.SaveChangesAsync();
			return CreatedAtAction(nameof(GetEncounter), new { campaignId, id = encounter.Id }, await ToDtoAsync(encounter, me));
		}

		//	PUT: api/campaigns/{campaignId}/encounters/{id} — 409 with the current encounter when someone saved it meanwhile
		[HttpPut("{id:guid}")]
		public async Task<ActionResult<EncounterDto>> UpdateEncounter(Guid campaignId, Guid id, [FromBody] SaveEncounterDto dto)
		{
			var role = await RoleAsync(campaignId);
			if (role is not { } me)
			{
				return NotFound();
			}
			var encounter = await _context.CampaignEncounters.FirstOrDefaultAsync(e => e.Id == id && e.CampaignId == campaignId);
			if (encounter is null || !EncounterRules.CanSee(me, encounter.Status, encounter.Shown))
			{
				return NotFound();
			}
			if (!EncounterRules.CanManage(me))
			{
				return Forbid();
			}
			if (dto.Version is { } version && version != encounter.Version)
			{
				return Conflict(await ToDtoAsync(encounter, me));
			}
			var error = Validate(dto);
			if (error is not null)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: error);
			}

			await ApplyAsync(encounter, dto);
			encounter.Version++;
			encounter.UpdatedAt = DateTimeOffset.UtcNow;
			await _context.SaveChangesAsync();
			return Ok(await ToDtoAsync(encounter, me));
		}

		//	DELETE: api/campaigns/{campaignId}/encounters/{id}
		[HttpDelete("{id:guid}")]
		public async Task<IActionResult> DeleteEncounter(Guid campaignId, Guid id)
		{
			var role = await RoleAsync(campaignId);
			if (role is not { } me)
			{
				return NotFound();
			}
			var encounter = await _context.CampaignEncounters.FirstOrDefaultAsync(e => e.Id == id && e.CampaignId == campaignId);
			if (encounter is null || !EncounterRules.CanSee(me, encounter.Status, encounter.Shown))
			{
				return NotFound();
			}
			if (!EncounterRules.CanManage(me))
			{
				return Forbid();
			}
			_context.CampaignEncounters.Remove(encounter);
			await _context.SaveChangesAsync();
			return NoContent();
		}

		// ===== Helpers =====

		private async Task<CampaignRole?> RoleAsync(Guid campaignId) =>
			await _context.CampaignMembers.Where(m => m.CampaignId == campaignId && m.UserId == UserId).Select(m => (CampaignRole?)m.Role).FirstOrDefaultAsync();

		internal static List<EncounterCombatant> Read(string? json)
		{
			if (string.IsNullOrWhiteSpace(json))
			{
				return new List<EncounterCombatant>();
			}
			try
			{
				return JsonSerializer.Deserialize<List<EncounterCombatant>>(json, Json) ?? new List<EncounterCombatant>();
			}
			catch (JsonException)
			{
				return new List<EncounterCombatant>();
			}
		}

		private async Task ApplyAsync(CampaignEncounter encounter, SaveEncounterDto dto)
		{
			//	Only the characters of this campaign can be in the party or on the field
			var characters = (await _context.CampaignCharacters.Where(c => c.CampaignId == encounter.CampaignId).Select(c => c.CharacterId).ToListAsync()).ToHashSet();

			var onField = dto.Combatants
				.Where(c => c.Kind != CombatantKind.Character || (c.CharacterId is { } cid && characters.Contains(cid)))
				.ToList();
			await WriteSheetsAsync(onField);

			var combatants = onField
				.Select(c => new EncounterCombatant
				{
					Id = c.Id == Guid.Empty ? Guid.NewGuid() : c.Id,
					Kind = Enum.IsDefined(c.Kind) ? c.Kind : CombatantKind.Other,
					MonsterId = c.Kind == CombatantKind.Monster ? c.MonsterId : null,
					CharacterId = c.Kind == CombatantKind.Character ? c.CharacterId : null,
					Name = c.Name.Trim(),
					Initiative = c.Initiative is { } i ? Math.Clamp(i, -10, 60) : null,
					InitiativeBonus = Math.Clamp(c.InitiativeBonus, -10, 30),
					ArmorClass = Math.Clamp(c.ArmorClass, 0, 50),
					MaxHp = Math.Clamp(c.MaxHp, 0, 10000),
					Hp = Math.Clamp(c.Hp, -10000, 10000),
					TempHp = Math.Clamp(c.TempHp, 0, 10000),
					Xp = Math.Clamp(c.Xp, 0, 1000000),
					ChallengeRating = c.ChallengeRating,
					Conditions = (c.Conditions ?? new List<string>()).Where(k => EncounterRules.Conditions.Contains(k)).Distinct().ToList(),
					Note = string.IsNullOrWhiteSpace(c.Note) ? null : c.Note.Trim(),
					Hidden = c.Hidden
				})
				.ToList();

			encounter.Name = dto.Name.Trim();
			encounter.Notes = dto.Notes?.Trim() ?? string.Empty;
			encounter.Status = Enum.IsDefined(dto.Status) ? dto.Status : EncounterStatus.Planned;
			encounter.Round = Math.Clamp(dto.Round, 0, 10000);
			encounter.CurrentId = dto.CurrentId is { } current && combatants.Any(c => c.Id == current) ? current : null;
			encounter.Shown = dto.Shown;
			encounter.Combatants = JsonSerializer.Serialize(combatants, Json);
			encounter.PartyIds = dto.PartyIds.Where(characters.Contains).Distinct().ToList();
		}

		//	What a master changed on the characters goes to their sheets (only what differs from the values the encounter
		//	was read with, so the changes made on the sheet meanwhile stay)
		private async Task WriteSheetsAsync(List<EncounterCombatant> combatants)
		{
			var changed = combatants
				.Where(c => c.Kind == CombatantKind.Character && c.CharacterId is not null && c.SheetHp is not null)
				.Where(c => c.Conditions is not null)
				.ToList();
			if (changed.Count == 0)
			{
				return;
			}
			var ids = changed.Select(c => c.CharacterId!.Value).Distinct().ToList();
			var rows = await _context.Characters.Where(c => ids.Contains(c.Id)).ToListAsync();
			foreach (var c in changed)
			{
				var character = rows.FirstOrDefault(r => r.Id == c.CharacterId);
				if (character is null)
				{
					continue;
				}
				c.Conditions = c.Conditions.Where(k => EncounterRules.Conditions.Contains(k)).Distinct().ToList();
				var sheet = CharactersController.ReadSheet(character.Sheet);
				if (EncounterSheetSync.Apply(sheet, character.MaxHitPoints, c))
				{
					character.Sheet = JsonSerializer.Serialize(sheet, CharactersController.Json);
					character.UpdatedAt = DateTimeOffset.UtcNow;
					character.UpdatedById = UserId;
				}
			}
		}

		private static string? Validate(SaveEncounterDto dto)
		{
			if (string.IsNullOrWhiteSpace(dto.Name) || dto.Name.Trim().Length > EncounterRules.MaxNameLength)
			{
				return $"The encounter needs a name (at most {EncounterRules.MaxNameLength} characters).";
			}
			if ((dto.Notes?.Trim().Length ?? 0) > EncounterRules.MaxNotesLength)
			{
				return $"Notes: at most {EncounterRules.MaxNotesLength} characters.";
			}
			if (dto.Combatants is null || dto.Combatants.Count > EncounterRules.MaxCombatants)
			{
				return $"At most {EncounterRules.MaxCombatants} combatants.";
			}
			if (dto.Combatants.Any(c => string.IsNullOrWhiteSpace(c.Name) || c.Name.Trim().Length > EncounterRules.MaxNameLength
				|| (c.Note?.Trim().Length ?? 0) > EncounterRules.MaxNoteLength))
			{
				return "Every combatant needs a name (at most 100 characters) and notes of at most 300 characters.";
			}
			dto.PartyIds ??= new List<Guid>();
			return null;
		}

		//	The players' view leaves out what the masters keep for themselves
		private async Task<EncounterDto> ToDtoAsync(CampaignEncounter e, CampaignRole role)
		{
			var manage = EncounterRules.CanManage(role);
			var combatants = Read(e.Combatants);
			if (!manage)
			{
				combatants = combatants
					.Where(c => !c.Hidden)
					.Select(c => c.Kind == CombatantKind.Character ? c : new EncounterCombatant
					{
						Id = c.Id,
						Kind = c.Kind,
						MonsterId = null,
						Name = c.Name,
						Initiative = c.Initiative,
						InitiativeBonus = c.InitiativeBonus,
						Conditions = c.Conditions,
						Health = EncounterRules.HealthOf(c.Hp, c.MaxHp)
					})
					.ToList();
			}

			var campaign = await _context.Campaigns.AsNoTracking().Where(c => c.Id == e.CampaignId).Select(c => new { c.Ruleset }).FirstAsync();

			//	The characters of the campaign, with their level, for the party picker and the difficulty
			var characters = await _context.Characters.AsNoTracking()
				.Where(c => _context.CampaignCharacters.Any(cc => cc.CampaignId == e.CampaignId && cc.CharacterId == c.Id))
				.Select(c => new { c.Id, c.Name, c.Level, c.OwnerId })
				.ToListAsync();
			var owners = await PublicNames.LoadAsync(_context, characters.Select(c => c.OwnerId));
			var party = characters
				.Select(c => new EncounterPartyMemberDto(c.Id, c.Name, c.Level, owners.GetValueOrDefault(c.OwnerId) ?? string.Empty))
				.OrderBy(c => c.Name, StringComparer.CurrentCultureIgnoreCase)
				.ToList();

			//	The characters on the field as their sheets are now
			var onField = combatants.Where(c => c.Kind == CombatantKind.Character && c.CharacterId is not null).Select(c => c.CharacterId!.Value).Distinct().ToList();
			if (onField.Count > 0)
			{
				var sheets = await _context.Characters.AsNoTracking()
					.Where(c => onField.Contains(c.Id))
					.Select(c => new { c.Id, c.Sheet, c.MaxHitPoints, c.ArmorClass })
					.ToDictionaryAsync(c => c.Id);
				foreach (var c in combatants.Where(c => c.Kind == CombatantKind.Character))
				{
					if (c.CharacterId is { } characterId && sheets.TryGetValue(characterId, out var row))
					{
						EncounterSheetSync.Show(c, CharactersController.ReadSheet(row.Sheet), row.MaxHitPoints, row.ArmorClass);
					}
				}
			}

			//	A hidden combatant's turn looks like nobody's to the players
			var current = e.CurrentId is { } id && combatants.Any(c => c.Id == id) ? e.CurrentId : null;

			return new EncounterDto(e.Id, e.CampaignId, e.Name, manage ? e.Notes : string.Empty, e.Status, e.Round, current, e.Shown,
				combatants, e.PartyIds.ToList(), party, manage, campaign.Ruleset, e.Version, e.UpdatedAt);
		}
	}
}
