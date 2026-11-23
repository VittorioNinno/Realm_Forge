using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealmForge.Api.Campaigns;
using RealmForge.Api.Security;
using RealmForge.Domain.Common;
using RealmForge.Domain.Entities;
using RealmForge.Infrastructure.Persistence;
using RealmForge.Shared.Campaigns;
using RealmForge.Shared.Characters;
using RealmForge.Shared.DTOs;
using RealmForge.Shared.Enums;

namespace RealmForge.Api.Controllers
{
	///	<summary>
	///	The party's chest after a fight: the masters put coins, gems and items in it (magic ones can stay unidentified:
	///	the players see only what they look like until someone identifies them); the coins are shared out among the
	///	characters at the table, the change in smaller coins, and the items given to a character go to its inventory.
	///	</summary>
	[ApiController]
	[Route("api/campaigns/{campaignId:guid}/treasure")]
	[Authorize]
	public class TreasureController : ControllerBase
	{
		public const int MaxItems = 200;
		public const int MaxCoins = 10_000_000;

		private static readonly JsonSerializerOptions Json = new(JsonSerializerDefaults.Web);

		private readonly RealmForgeDbContext _context;
		private readonly ShareService _shares;

		public TreasureController(RealmForgeDbContext context, ShareService shares)
		{
			_context = context;
			_shares = shares;
		}

		private string UserId => ContentAccess.GetUserId(User) ?? string.Empty;

		//	GET: api/campaigns/{campaignId}/treasure?lang=2
		[HttpGet]
		public async Task<ActionResult<CampaignTreasureDto>> Get(Guid campaignId, [FromQuery] LanguageCode lang = LanguageCode.It)
		{
			if (await CampaignAccess.RoleAsync(_context, campaignId, UserId) is not { } role)
			{
				return NotFound();
			}
			var runs = CampaignRules.RunsTheTable(role);
			var coins = await _context.Campaigns.AsNoTracking().Where(c => c.Id == campaignId).Select(c => c.TreasureCoins).FirstAsync();
			var items = await _context.CampaignLoot.AsNoTracking().Where(l => l.CampaignId == campaignId).OrderBy(l => l.CreatedAt).ToListAsync();
			var names = await NamesAsync(items, lang);
			var characters = await (from cc in _context.CampaignCharacters.AsNoTracking()
									join c in _context.Characters.AsNoTracking() on cc.CharacterId equals c.Id
									where cc.CampaignId == campaignId
									orderby c.Name
									select new TreasureCharacterDto(c.Id, c.Name, !cc.Inactive, runs || c.OwnerId == UserId)).ToListAsync();
			return Ok(new CampaignTreasureDto(ReadCoins(coins), items.Select(i => ToDto(i, names, runs)).ToList(), characters));
		}

		//	PUT: api/campaigns/{campaignId}/treasure/coins — the masters set the coins of the chest
		[HttpPut("coins")]
		public async Task<IActionResult> SetCoins(Guid campaignId, [FromBody] CoinPurse coins)
		{
			if (await MasterAsync(campaignId) is { } denied)
			{
				return denied;
			}
			if (new[] { coins.Cp, coins.Sp, coins.Ep, coins.Gp, coins.Pp }.Any(v => v is < 0 or > MaxCoins))
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: $"Coins from 0 to {MaxCoins}.");
			}
			var campaign = await _context.Campaigns.FirstAsync(c => c.Id == campaignId);
			campaign.TreasureCoins = JsonSerializer.Serialize(coins, Json);
			await _context.SaveChangesAsync();
			return NoContent();
		}

		//	POST: api/campaigns/{campaignId}/treasure/split — the coins shared out among the characters given (none: the
		//	active ones at the table); what does not divide stays in the chest
		[HttpPost("split")]
		public async Task<ActionResult<TreasureSplitDto>> Split(Guid campaignId, [FromBody] SplitTreasureDto dto)
		{
			if (await MasterAsync(campaignId) is { } denied)
			{
				return denied;
			}
			var rows = await _context.CampaignCharacters.Where(cc => cc.CampaignId == campaignId).ToListAsync();
			var chosen = dto.CharacterIds is { Count: > 0 } ids ? rows.Where(r => ids.Contains(r.CharacterId)).ToList() : rows.Where(r => !r.Inactive).ToList();
			if (chosen.Count == 0)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "No character to share the coins with.");
			}
			var campaign = await _context.Campaigns.FirstAsync(c => c.Id == campaignId);
			var pool = ReadCoins(campaign.TreasureCoins);
			var (each, left) = TreasureRules.Split(pool, chosen.Count);
			var characterIds = chosen.Select(r => r.CharacterId).ToList();
			var characters = await _context.Characters.Where(c => characterIds.Contains(c.Id)).OrderBy(c => c.Name).ToListAsync();
			foreach (var character in characters)
			{
				var sheet = CharactersController.ReadSheet(character.Sheet);
				TreasureRules.Add(sheet.Coins, each);
				Stored(character, sheet);
			}
			campaign.TreasureCoins = JsonSerializer.Serialize(left, Json);
			await _context.SaveChangesAsync();
			return Ok(new TreasureSplitDto(each, left, characters.Select(c => c.Name).ToList()));
		}

		//	POST: api/campaigns/{campaignId}/treasure/items — an item put in the chest
		[HttpPost("items")]
		public async Task<ActionResult<TreasureItemDto>> AddItem(Guid campaignId, [FromBody] SaveTreasureItemDto dto, [FromQuery] LanguageCode lang = LanguageCode.It)
		{
			if (await MasterAsync(campaignId) is { } denied)
			{
				return denied;
			}
			if (await _context.CampaignLoot.CountAsync(l => l.CampaignId == campaignId) >= MaxItems)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: $"At most {MaxItems} items in the chest.");
			}
			var item = new CampaignLoot { CampaignId = campaignId };
			var shared = await _shares.SharedWithAsync(User);
			if (dto.EquipmentId is { } equipmentId)
			{
				var equipment = await ContentAccess.ListedFor(_context.Equipment.AsNoTracking().Include(e => e.Translations), User, shared).FirstOrDefaultAsync(e => e.Id == equipmentId);
				if (equipment is null)
				{
					return Problem(statusCode: StatusCodes.Status400BadRequest, title: "Unknown equipment.");
				}
				item.EquipmentId = equipment.Id;
				item.ValueInCopper = dto.ValueInCopper ?? equipment.CostInCopper;
			}
			else if (dto.MagicItemId is { } magicId)
			{
				var magic = await ContentAccess.ListedFor(_context.MagicItems.AsNoTracking().Include(m => m.Translations), User, shared).FirstOrDefaultAsync(m => m.Id == magicId);
				if (magic is null)
				{
					return Problem(statusCode: StatusCodes.Status400BadRequest, title: "Unknown magic item.");
				}
				item.MagicItemId = magic.Id;
				item.ValueInCopper = dto.ValueInCopper ?? ShopsController.RarityPrice(magic.Rarity) * 100;
			}
			else if (string.IsNullOrWhiteSpace(dto.Name))
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "A free item needs a name.");
			}
			else
			{
				item.ValueInCopper = dto.ValueInCopper;
			}
			if (Apply(item, dto) is { } error)
			{
				return error;
			}
			_context.CampaignLoot.Add(item);
			await _context.SaveChangesAsync();
			return Ok(ToDto(item, await NamesAsync(new[] { item }, lang), true));
		}

		//	PUT: api/campaigns/{campaignId}/treasure/items/{id} — its name, look, quantity, value, identified
		[HttpPut("items/{id:guid}")]
		public async Task<IActionResult> UpdateItem(Guid campaignId, Guid id, [FromBody] SaveTreasureItemDto dto)
		{
			var (item, error) = await MastersItemAsync(campaignId, id);
			if (item is null)
			{
				return error!;
			}
			if (item.EquipmentId is null && item.MagicItemId is null && string.IsNullOrWhiteSpace(dto.Name))
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "A free item needs a name.");
			}
			item.ValueInCopper = dto.ValueInCopper;
			if (Apply(item, dto) is { } invalid)
			{
				return invalid;
			}
			await _context.SaveChangesAsync();
			return NoContent();
		}

		//	DELETE: api/campaigns/{campaignId}/treasure/items/{id}
		[HttpDelete("items/{id:guid}")]
		public async Task<IActionResult> DeleteItem(Guid campaignId, Guid id)
		{
			var (item, error) = await MastersItemAsync(campaignId, id);
			if (item is null)
			{
				return error!;
			}
			_context.CampaignLoot.Remove(item);
			await _context.SaveChangesAsync();
			return NoContent();
		}

		//	POST: api/campaigns/{campaignId}/treasure/items/{id}/identify — anyone at the table (an Identify cast, a short
		//	rest spent studying it)
		[HttpPost("items/{id:guid}/identify")]
		public async Task<IActionResult> Identify(Guid campaignId, Guid id)
		{
			if (await CampaignAccess.RoleAsync(_context, campaignId, UserId) is null)
			{
				return NotFound();
			}
			var item = await _context.CampaignLoot.FirstOrDefaultAsync(l => l.Id == id && l.CampaignId == campaignId);
			if (item is null)
			{
				return NotFound();
			}
			item.Identified = true;
			await _context.SaveChangesAsync();
			return NoContent();
		}

		//	POST: api/campaigns/{campaignId}/treasure/items/{id}/give?lang=2 — to a character at the table (a player: one of
		//	their own), into its inventory
		[HttpPost("items/{id:guid}/give")]
		public async Task<IActionResult> Give(Guid campaignId, Guid id, [FromBody] GiveTreasureDto dto, [FromQuery] LanguageCode lang = LanguageCode.It)
		{
			if (await CampaignAccess.RoleAsync(_context, campaignId, UserId) is not { } role)
			{
				return NotFound();
			}
			var runs = CampaignRules.RunsTheTable(role);
			var item = await _context.CampaignLoot.FirstOrDefaultAsync(l => l.Id == id && l.CampaignId == campaignId);
			if (item is null)
			{
				return NotFound();
			}
			var character = await _context.Characters.FirstOrDefaultAsync(c => c.Id == dto.CharacterId
				&& _context.CampaignCharacters.Any(cc => cc.CampaignId == campaignId && cc.CharacterId == c.Id) && (runs || c.OwnerId == UserId));
			if (character is null)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "Not a character of yours at this table.");
			}
			if (dto.Quantity < 1 || dto.Quantity > item.Quantity)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "Not that many in the chest.");
			}
			var sheet = CharactersController.ReadSheet(character.Sheet);
			bool stowed;
			if (item.Identified)
			{
				var names = await NamesAsync(new[] { item }, lang);
				stowed = await InventoryStow.StowAsync(_context, sheet, item.EquipmentId, item.MagicItemId, names.GetValueOrDefault(item.Id) ?? item.Name, dto.Quantity,
					item.Appearance.Length > 0 ? item.Appearance : null);
			}
			else
			{
				//	Not identified yet: a free entry with what it looks like (the master tells the rest)
				stowed = await InventoryStow.StowAsync(_context, sheet, null, null, item.Name, dto.Quantity, item.Appearance.Length > 0 ? item.Appearance : null);
			}
			if (!stowed)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: $"At most {InventoryStow.MaxInventory} entries in the inventory.");
			}
			Stored(character, sheet);
			item.Quantity -= dto.Quantity;
			if (item.Quantity == 0)
			{
				_context.CampaignLoot.Remove(item);
			}
			await _context.SaveChangesAsync();
			return NoContent();
		}

		// ----- Helpers -----

		//	A sheet changed here: written back, its stamp moved (an open copy of the sheet takes the server's inventory)
		private void Stored(Character character, CharacterSheetState sheet)
		{
			sheet.StoreStamp++;
			character.Sheet = JsonSerializer.Serialize(sheet, CharactersController.Json);
			character.UpdatedAt = DateTimeOffset.UtcNow;
			character.UpdatedById = UserId;
		}

		private static CoinPurse ReadCoins(string? json)
		{
			if (string.IsNullOrWhiteSpace(json))
			{
				return new CoinPurse();
			}
			try
			{
				return JsonSerializer.Deserialize<CoinPurse>(json, Json) ?? new CoinPurse();
			}
			catch (JsonException)
			{
				return new CoinPurse();
			}
		}

		private ActionResult? Apply(CampaignLoot item, SaveTreasureItemDto dto)
		{
			var name = (dto.Name ?? string.Empty).Trim();
			var appearance = (dto.Appearance ?? string.Empty).Trim();
			if (name.Length > 120 || appearance.Length > 1000 || dto.Quantity is < 1 or > 9999 || item.ValueInCopper is < 0 or > ShopsController.MaxPrice)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "A name up to 120 characters, a look up to 1000, a quantity from 1 to 9999.");
			}
			item.Name = name;
			item.Appearance = appearance;
			item.Identified = dto.Identified;
			item.Quantity = dto.Quantity;
			return null;
		}

		private TreasureItemDto ToDto(CampaignLoot i, Dictionary<Guid, string> names, bool runs)
		{
			var trueName = names.GetValueOrDefault(i.Id) ?? i.Name;
			var shown = i.Identified ? trueName : i.Name.Length > 0 ? i.Name : string.Empty;
			return new TreasureItemDto(
				i.Id,
				i.EquipmentId is not null ? "equipment" : i.MagicItemId is not null ? "magic-item" : "free",
				i.Identified || runs ? i.EquipmentId ?? i.MagicItemId : null,
				shown,
				i.Appearance,
				i.Identified,
				i.Quantity,
				i.Identified || runs ? i.ValueInCopper : null,
				runs ? trueName : null);
		}

		//	The names of the compendium items in the language asked
		private async Task<Dictionary<Guid, string>> NamesAsync(IEnumerable<CampaignLoot> items, LanguageCode lang)
		{
			var list = items.ToList();
			var equipmentIds = list.Where(i => i.EquipmentId != null).Select(i => i.EquipmentId!.Value).Distinct().ToList();
			var magicIds = list.Where(i => i.MagicItemId != null).Select(i => i.MagicItemId!.Value).Distinct().ToList();
			var equipment = equipmentIds.Count == 0 ? new() : await _context.Equipment.AsNoTracking().Include(e => e.Translations)
				.Where(e => equipmentIds.Contains(e.Id)).ToDictionaryAsync(e => e.Id, e => Pick(e.Translations, lang)?.Name);
			var magic = magicIds.Count == 0 ? new() : await _context.MagicItems.AsNoTracking().Include(m => m.Translations)
				.Where(m => magicIds.Contains(m.Id)).ToDictionaryAsync(m => m.Id, m => Pick(m.Translations, lang)?.Name);
			var names = new Dictionary<Guid, string>();
			foreach (var item in list)
			{
				var name = item.EquipmentId is { } e ? equipment.GetValueOrDefault(e) : item.MagicItemId is { } m ? magic.GetValueOrDefault(m) : null;
				if (!string.IsNullOrEmpty(name))
				{
					names[item.Id] = name;
				}
			}
			return names;
		}

		private static T? Pick<T>(IEnumerable<T> translations, LanguageCode lang) where T : ITranslation =>
			translations.FirstOrDefault(t => t.Language == lang) ?? translations.FirstOrDefault();

		private async Task<ActionResult?> MasterAsync(Guid campaignId)
		{
			if (await CampaignAccess.RoleAsync(_context, campaignId, UserId) is not { } role)
			{
				return NotFound();
			}
			return CampaignRules.RunsTheTable(role) ? null : Forbid();
		}

		private async Task<(CampaignLoot? Item, ActionResult? Error)> MastersItemAsync(Guid campaignId, Guid id)
		{
			if (await MasterAsync(campaignId) is { } denied)
			{
				return (null, denied);
			}
			var item = await _context.CampaignLoot.FirstOrDefaultAsync(l => l.Id == id && l.CampaignId == campaignId);
			return item is null ? (null, NotFound()) : (item, null);
		}
	}
}
