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
	///	The shops of a campaign: the masters stock them (equipment and magic items of the compendium, free entries) with a
	///	price multiplier and open them to the players; a player buys for one of their characters at the table, the coins
	///	come off its purse (with change) and the item goes to its inventory.
	///	</summary>
	[ApiController]
	[Route("api/campaigns/{campaignId:guid}/shops")]
	[Authorize]
	public class ShopsController : ControllerBase
	{
		public const int MaxShops = 30;
		public const int MaxItems = 100;
		public const int MaxPrice = 100_000_000;
		public const int MaxInventory = 300;


		private readonly RealmForgeDbContext _context;
		private readonly ShareService _shares;

		public ShopsController(RealmForgeDbContext context, ShareService shares)
		{
			_context = context;
			_shares = shares;
		}

		private string UserId => ContentAccess.GetUserId(User) ?? string.Empty;

		//	The factions of the campaign of this request (name and standing), read once
		private Dictionary<Guid, (string Name, int Standing)> factions = new();

		private async Task LoadFactionsAsync(Guid campaignId) =>
			factions = await _context.CampaignFactions.AsNoTracking().Where(f => f.CampaignId == campaignId)
				.ToDictionaryAsync(f => f.Id, f => (f.Name, f.Standing));

		//	The prices of a shop, moved by the standing of its faction
		private int PercentOf(CampaignShop shop) =>
			FactionRules.Effective(shop.PricePercent, shop.FactionId is { } f && factions.TryGetValue(f, out var faction) ? faction.Standing : null);

		//	The usual price of a magic item of each rarity, in gold pieces (the masters change it item by item)
		public static int? RarityPrice(ItemRarity? rarity) => rarity switch
		{
			ItemRarity.Common => 100,
			ItemRarity.Uncommon => 400,
			ItemRarity.Rare => 4_000,
			ItemRarity.VeryRare => 40_000,
			ItemRarity.Legendary => 200_000,
			_ => null
		};

		//	The price of one piece in a shop: the list price times the multiplier, rounded to the copper piece
		public static int PriceOf(int listPrice, int percent) => (int)Math.Min(MaxPrice, Math.Round(listPrice * (long)percent / 100m, MidpointRounding.AwayFromZero));

		//	GET: api/campaigns/{campaignId}/shops?lang=2 — the masters every shop, a player the open ones; with the
		//	characters the reader can buy for
		[HttpGet]
		public async Task<ActionResult<CampaignShopsDto>> GetShops(Guid campaignId, [FromQuery] LanguageCode lang = LanguageCode.It)
		{
			if (await CampaignAccess.RoleAsync(_context, campaignId, UserId) is not { } role)
			{
				return NotFound();
			}
			var runs = CampaignRules.RunsTheTable(role);
			var shops = await _context.CampaignShops.AsNoTracking().Include(s => s.Items)
				.Where(s => s.CampaignId == campaignId && (runs || s.Open))
				.OrderBy(s => s.CreatedAt)
				.ToListAsync();
			var names = await NamesAsync(shops.SelectMany(s => s.Items), lang);
			await LoadFactionsAsync(campaignId);
			var buyers = await BuyersQuery(campaignId, runs).OrderBy(c => c.Name).ToListAsync();
			return Ok(new CampaignShopsDto(
				shops.Select(s => ToDto(s, lang, runs, names)).ToList(),
				buyers.Select(c => new ShopBuyerDto(c.Id, c.Name, CharactersController.ReadSheet(c.Sheet).Coins)).ToList()));
		}

		//	POST: api/campaigns/{campaignId}/shops — masters and co-masters
		[HttpPost]
		public async Task<ActionResult<CampaignShopDto>> AddShop(Guid campaignId, [FromBody] SaveCampaignShopDto dto, [FromQuery] LanguageCode lang = LanguageCode.It)
		{
			if (await MasterAsync(campaignId) is { } denied)
			{
				return denied;
			}
			if (Validate(dto) is { } error)
			{
				return error;
			}
			if (await _context.CampaignShops.CountAsync(s => s.CampaignId == campaignId) >= MaxShops)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: $"At most {MaxShops} shops per campaign.");
			}
			await LoadFactionsAsync(campaignId);
			if (dto.FactionId is { } factionId && !factions.ContainsKey(factionId))
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "Unknown faction.");
			}
			var shop = new CampaignShop { CampaignId = campaignId, AuthorId = UserId };
			Apply(shop, dto);
			_context.CampaignShops.Add(shop);
			await _context.SaveChangesAsync();
			return Ok(ToDto(shop, lang, true, new()));
		}

		//	PUT: api/campaigns/{campaignId}/shops/{id}
		//	POST: api/campaigns/{campaignId}/shops/generate?lang=2 — a procedural shop or tavern: name, keeper, look, prices and
		//	shelves filled from the official compendium (closed, for the master to look over before opening it)
		[HttpPost("generate")]
		public async Task<ActionResult<CampaignShopDto>> Generate(Guid campaignId, [FromBody] GenerateShopDto dto, [FromQuery] LanguageCode lang = LanguageCode.It)
		{
			if (await MasterAsync(campaignId) is { } denied)
			{
				return denied;
			}
			if (!Enum.IsDefined(dto.Kind))
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "Unknown kind of shop.");
			}
			if (await _context.CampaignShops.CountAsync(s => s.CampaignId == campaignId) >= MaxShops)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: $"At most {MaxShops} shops per campaign.");
			}
			var random = dto.Seed is { } seed ? new Random(seed) : Random.Shared;
			var plan = ShopGenerator.For(dto.Kind, random);
			var shop = new CampaignShop
			{
				CampaignId = campaignId, AuthorId = UserId, NameIt = plan.NameIt, NameEn = plan.NameEn,
				DescriptionIt = plan.DescriptionIt, DescriptionEn = plan.DescriptionEn, PricePercent = plan.PricePercent, Open = false
			};
			var en = lang == LanguageCode.En;
			var categories = plan.Stock.Categories;
			if (plan.Stock.Mundane > 0 && categories.Length > 0)
			{
				var pool = await _context.Equipment.AsNoTracking().Include(e => e.Translations)
					.Where(e => e.IsOfficialSRD && categories.Contains(e.Category) && e.CostInCopper != null && e.CostInCopper > 0).ToListAsync();
				foreach (var equipment in pool.OrderBy(_ => random.Next()).Take(plan.Stock.Mundane).OrderBy(e => e.CostInCopper))
				{
					shop.Items.Add(new CampaignShopItem
					{
						EquipmentId = equipment.Id, Name = Pick(equipment.Translations, LanguageCode.En)?.Name ?? string.Empty,
						PriceInCopper = equipment.CostInCopper ?? 0
					});
				}
			}
			if (plan.Stock.Magic > 0)
			{
				var types = plan.Stock.MagicTypes;
				var rarities = plan.Stock.Rarities.Cast<ItemRarity?>().ToArray();
				var pool = await _context.MagicItems.AsNoTracking().Include(m => m.Translations)
					.Where(m => m.IsOfficialSRD && m.ParentId == null && types.Contains(m.Type) && rarities.Contains(m.Rarity)).ToListAsync();
				foreach (var magic in pool.OrderBy(_ => random.Next()).Take(plan.Stock.Magic))
				{
					if (RarityPrice(magic.Rarity) is not { } gold)
					{
						continue;
					}
					shop.Items.Add(new CampaignShopItem
					{
						MagicItemId = magic.Id, Name = Pick(magic.Translations, LanguageCode.En)?.Name ?? string.Empty,
						PriceInCopper = gold * 100, Stock = 1 + random.Next(3)
					});
				}
			}
			foreach (var extra in plan.Extras)
			{
				shop.Items.Add(new CampaignShopItem { Name = en ? extra.En : extra.It, PriceInCopper = extra.PriceInCopper });
			}
			_context.CampaignShops.Add(shop);
			await _context.SaveChangesAsync();
			var names = await NamesAsync(shop.Items, lang);
			await LoadFactionsAsync(campaignId);
			return Ok(ToDto(shop, lang, true, names));
		}

		[HttpPut("{id:guid}")]
		public async Task<IActionResult> UpdateShop(Guid campaignId, Guid id, [FromBody] SaveCampaignShopDto dto)
		{
			var (shop, error) = await MastersShopAsync(campaignId, id);
			if (shop is null)
			{
				return error!;
			}
			if (Validate(dto) is { } invalid)
			{
				return invalid;
			}
			await LoadFactionsAsync(campaignId);
			if (dto.FactionId is { } factionId && !factions.ContainsKey(factionId))
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "Unknown faction.");
			}
			Apply(shop, dto);
			shop.UpdatedAt = DateTimeOffset.UtcNow;
			await _context.SaveChangesAsync();
			return NoContent();
		}

		//	DELETE: api/campaigns/{campaignId}/shops/{id}
		[HttpDelete("{id:guid}")]
		public async Task<IActionResult> DeleteShop(Guid campaignId, Guid id)
		{
			var (shop, error) = await MastersShopAsync(campaignId, id);
			if (shop is null)
			{
				return error!;
			}
			_context.CampaignShops.Remove(shop);
			await _context.SaveChangesAsync();
			return NoContent();
		}

		//	POST: api/campaigns/{campaignId}/shops/{id}/items — an item put on sale
		[HttpPost("{id:guid}/items")]
		public async Task<ActionResult<ShopItemDto>> AddItem(Guid campaignId, Guid id, [FromBody] SaveShopItemDto dto, [FromQuery] LanguageCode lang = LanguageCode.It)
		{
			var (shop, error) = await MastersShopAsync(campaignId, id);
			if (shop is null)
			{
				return error!;
			}
			if (shop.Items.Count >= MaxItems)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: $"At most {MaxItems} items per shop.");
			}
			var item = new CampaignShopItem { ShopId = shop.Id };
			var shared = await _shares.SharedWithAsync(User);
			if (dto.EquipmentId is { } equipmentId)
			{
				var equipment = await ContentAccess.ListedFor(_context.Equipment.AsNoTracking().Include(e => e.Translations), User, shared)
					.FirstOrDefaultAsync(e => e.Id == equipmentId);
				if (equipment is null)
				{
					return Problem(statusCode: StatusCodes.Status400BadRequest, title: "Unknown equipment.");
				}
				item.EquipmentId = equipment.Id;
				item.Name = Pick(equipment.Translations, LanguageCode.En)?.Name ?? string.Empty;
				item.PriceInCopper = dto.PriceInCopper ?? equipment.CostInCopper ?? 0;
			}
			else if (dto.MagicItemId is { } magicId)
			{
				var magic = await ContentAccess.ListedFor(_context.MagicItems.AsNoTracking().Include(m => m.Translations), User, shared)
					.FirstOrDefaultAsync(m => m.Id == magicId);
				if (magic is null)
				{
					return Problem(statusCode: StatusCodes.Status400BadRequest, title: "Unknown magic item.");
				}
				var price = dto.PriceInCopper ?? RarityPrice(magic.Rarity) * 100;
				if (price is null)
				{
					return Problem(statusCode: StatusCodes.Status400BadRequest, title: "This item has no usual price: give one.");
				}
				item.MagicItemId = magic.Id;
				item.Name = Pick(magic.Translations, LanguageCode.En)?.Name ?? string.Empty;
				item.PriceInCopper = price.Value;
			}
			else
			{
				var name = (dto.Name ?? string.Empty).Trim();
				if (name.Length is 0 or > 120 || dto.PriceInCopper is null)
				{
					return Problem(statusCode: StatusCodes.Status400BadRequest, title: "A free item needs a name (up to 120 characters) and a price.");
				}
				item.Name = name;
				item.PriceInCopper = dto.PriceInCopper.Value;
			}
			if (item.PriceInCopper is < 0 or > MaxPrice || dto.Stock is < 0 or > 9999)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "Prices from 0 and stock from 0 to 9999.");
			}
			item.Name = item.Name.Length > 120 ? item.Name[..120] : item.Name;
			item.Stock = dto.Stock;
			_context.CampaignShopItems.Add(item);
			shop.UpdatedAt = DateTimeOffset.UtcNow;
			await _context.SaveChangesAsync();
			var names = await NamesAsync(new[] { item }, lang);
			await LoadFactionsAsync(campaignId);
			return Ok(ItemDto(item, PercentOf(shop), names));
		}

		//	PUT: api/campaigns/{campaignId}/shops/{id}/items/{itemId} — its price and stock (a free item: its name too)
		[HttpPut("{id:guid}/items/{itemId:guid}")]
		public async Task<IActionResult> UpdateItem(Guid campaignId, Guid id, Guid itemId, [FromBody] SaveShopItemDto dto)
		{
			var (shop, error) = await MastersShopAsync(campaignId, id);
			if (shop is null)
			{
				return error!;
			}
			var item = shop.Items.FirstOrDefault(i => i.Id == itemId);
			if (item is null)
			{
				return NotFound();
			}
			if (dto.PriceInCopper is < 0 or > MaxPrice || dto.Stock is < 0 or > 9999)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "Prices from 0 and stock from 0 to 9999.");
			}
			if (item.EquipmentId is null && item.MagicItemId is null && (dto.Name ?? string.Empty).Trim() is { Length: > 0 and <= 120 } name)
			{
				item.Name = name;
			}
			item.PriceInCopper = dto.PriceInCopper ?? item.PriceInCopper;
			item.Stock = dto.Stock;
			shop.UpdatedAt = DateTimeOffset.UtcNow;
			await _context.SaveChangesAsync();
			return NoContent();
		}

		//	DELETE: api/campaigns/{campaignId}/shops/{id}/items/{itemId}
		[HttpDelete("{id:guid}/items/{itemId:guid}")]
		public async Task<IActionResult> DeleteItem(Guid campaignId, Guid id, Guid itemId)
		{
			var (shop, error) = await MastersShopAsync(campaignId, id);
			if (shop is null)
			{
				return error!;
			}
			var item = shop.Items.FirstOrDefault(i => i.Id == itemId);
			if (item is null)
			{
				return NotFound();
			}
			_context.CampaignShopItems.Remove(item);
			shop.UpdatedAt = DateTimeOffset.UtcNow;
			await _context.SaveChangesAsync();
			return NoContent();
		}

		//	POST: api/campaigns/{campaignId}/shops/{id}/items/{itemId}/buy?lang=2 — for one of the reader's characters at the
		//	table (a master: any of them); 409 when the purse is not enough or the stock is out
		[HttpPost("{id:guid}/items/{itemId:guid}/buy")]
		public async Task<ActionResult<ShopPurchaseDto>> Buy(Guid campaignId, Guid id, Guid itemId, [FromBody] BuyShopItemDto dto, [FromQuery] LanguageCode lang = LanguageCode.It)
		{
			if (await CampaignAccess.RoleAsync(_context, campaignId, UserId) is not { } role)
			{
				return NotFound();
			}
			var runs = CampaignRules.RunsTheTable(role);
			var shop = await _context.CampaignShops.Include(s => s.Items).FirstOrDefaultAsync(s => s.Id == id && s.CampaignId == campaignId && (runs || s.Open));
			var item = shop?.Items.FirstOrDefault(i => i.Id == itemId);
			if (shop is null || item is null)
			{
				return NotFound();
			}
			if (dto.Quantity is < 1 or > 99)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "From 1 to 99 pieces.");
			}
			var character = await BuyersQuery(campaignId, runs).FirstOrDefaultAsync(c => c.Id == dto.CharacterId);
			if (character is null)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "Not a character of yours at this table.");
			}
			if (item.Stock is { } stock && stock < dto.Quantity)
			{
				return Problem(statusCode: StatusCodes.Status409Conflict, title: "Not enough pieces in stock.");
			}
			var sheet = CharactersController.ReadSheet(character.Sheet);
			await LoadFactionsAsync(campaignId);
			var total = (int)Math.Min(int.MaxValue, (long)PriceOf(item.PriceInCopper, PercentOf(shop)) * dto.Quantity);
			if (!InventoryRules.Pay(sheet.Coins, total))
			{
				return Problem(statusCode: StatusCodes.Status409Conflict, title: "Not enough coins.");
			}
			var names = await NamesAsync(new[] { item }, lang);
			var name = names.GetValueOrDefault(item.Id) ?? item.Name;
			if (!await InventoryStow.StowAsync(_context, sheet, item.EquipmentId, item.MagicItemId, name, dto.Quantity))
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: $"At most {MaxInventory} entries in the inventory.");
			}
			if (item.Stock is not null)
			{
				item.Stock -= dto.Quantity;
			}
			sheet.StoreStamp++;
			character.Sheet = JsonSerializer.Serialize(sheet, CharactersController.Json);
			character.UpdatedAt = DateTimeOffset.UtcNow;
			character.UpdatedById = UserId;
			await _context.SaveChangesAsync();
			return Ok(new ShopPurchaseDto(name, dto.Quantity, total, sheet.Coins, item.Stock));
		}

		// ----- Helpers -----

		//	The characters the reader buys for: their own at the table (a master: every one at the table)
		private IQueryable<Character> BuyersQuery(Guid campaignId, bool runs) => _context.Characters
			.Where(c => _context.CampaignCharacters.Any(cc => cc.CampaignId == campaignId && cc.CharacterId == c.Id) && (runs || c.OwnerId == UserId));

		//	The names of the compendium items in the language asked (the other one when it has only that)
		private async Task<Dictionary<Guid, string>> NamesAsync(IEnumerable<CampaignShopItem> items, LanguageCode lang)
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

		private async Task<(CampaignShop? Shop, ActionResult? Error)> MastersShopAsync(Guid campaignId, Guid id)
		{
			if (await MasterAsync(campaignId) is { } denied)
			{
				return (null, denied);
			}
			var shop = await _context.CampaignShops.Include(s => s.Items).FirstOrDefaultAsync(s => s.Id == id && s.CampaignId == campaignId);
			return shop is null ? (null, NotFound()) : (shop, null);
		}

		private ActionResult? Validate(SaveCampaignShopDto dto)
		{
			var nameIt = (dto.NameIt ?? string.Empty).Trim();
			var nameEn = (dto.NameEn ?? string.Empty).Trim();
			if (nameIt.Length + nameEn.Length == 0 || nameIt.Length > 120 || nameEn.Length > 120
				|| (dto.DescriptionIt ?? string.Empty).Length > 2000 || (dto.DescriptionEn ?? string.Empty).Length > 2000
				|| dto.PricePercent is < 0 or > 1000)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "A name (up to 120 characters), descriptions up to 2000 characters, prices from 0% to 1000%.");
			}
			return null;
		}

		private static void Apply(CampaignShop shop, SaveCampaignShopDto dto)
		{
			shop.NameIt = (dto.NameIt ?? string.Empty).Trim();
			shop.NameEn = (dto.NameEn ?? string.Empty).Trim();
			shop.DescriptionIt = (dto.DescriptionIt ?? string.Empty).Trim();
			shop.DescriptionEn = (dto.DescriptionEn ?? string.Empty).Trim();
			shop.PricePercent = dto.PricePercent;
			shop.FactionId = dto.FactionId;
			shop.Open = dto.Open;
		}

		private static string Either(string mine, string other) => mine.Length > 0 ? mine : other;

		private CampaignShopDto ToDto(CampaignShop s, LanguageCode lang, bool runs, Dictionary<Guid, string> names)
		{
			var en = lang == LanguageCode.En;
			var items = s.Items.OrderBy(i => i.CreatedAt).Select(i => ItemDto(i, PercentOf(s), names)).ToList();
			return new CampaignShopDto(
				s.Id,
				en ? Either(s.NameEn, s.NameIt) : Either(s.NameIt, s.NameEn),
				en ? Either(s.DescriptionEn, s.DescriptionIt) : Either(s.DescriptionIt, s.DescriptionEn),
				s.PricePercent, s.Open, items,
				runs ? s.NameIt : null, runs ? s.NameEn : null, runs ? s.DescriptionIt : null, runs ? s.DescriptionEn : null,
				s.FactionId, s.FactionId is { } f && factions.TryGetValue(f, out var faction) ? faction.Name : null, PercentOf(s));
		}

		private static ShopItemDto ItemDto(CampaignShopItem i, int percent, Dictionary<Guid, string> names) => new(
			i.Id,
			i.EquipmentId is not null ? "equipment" : i.MagicItemId is not null ? "magic-item" : "free",
			i.EquipmentId ?? i.MagicItemId,
			names.GetValueOrDefault(i.Id) ?? i.Name,
			i.PriceInCopper,
			PriceOf(i.PriceInCopper, percent),
			i.Stock);
	}
}
