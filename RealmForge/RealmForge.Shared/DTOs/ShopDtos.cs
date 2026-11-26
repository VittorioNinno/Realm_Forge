using RealmForge.Shared.Characters;

namespace RealmForge.Shared.DTOs
{
	///	<summary>
	///	The shops of a campaign the reader sees (a player: the open ones) and the characters they can buy for, with
	///	their purse.
	///	</summary>
	public record CampaignShopsDto(List<CampaignShopDto> Shops, List<ShopBuyerDto> Buyers);

	///	<summary>
	///	A shop: Name and Description in the reader's language (the other one when it has only that); the masters get
	///	both languages too.
	///	</summary>
	public record CampaignShopDto(
		Guid Id,
		string Name,
		string Description,
		int PricePercent,
		bool Open,
		List<ShopItemDto> Items,
		string? NameIt = null,
		string? NameEn = null,
		string? DescriptionIt = null,
		string? DescriptionEn = null,
		Guid? FactionId = null,
		string? Faction = null,
		int? EffectivePercent = null,
		Guid? NpcId = null,
		string? Npc = null);

	///	<summary>
	///	An item on sale: ListPrice of one piece before the shop's multiplier (the master's own when CustomPrice, else
	///	StandardPrice), Price what a piece costs in the shop after the multiplier and its Discount (copper pieces);
	///	Stock null: as many as wanted. Kind: equipment, magic-item or free.
	///	</summary>
	public record ShopItemDto(Guid Id, string Kind, Guid? EntryId, string Name, int ListPrice, int Price, int? Stock, ItemRarity? Rarity = null,
		int StandardPrice = 0, bool CustomPrice = false, int Discount = 0);

	public record ShopBuyerDto(Guid CharacterId, string Name, CoinPurse Coins);

	///	<summary>A procedural shop or tavern of a kind; Seed: the same seed, the same shop (tests).</summary>
	public class GenerateShopDto
	{
		public RealmForge.Shared.Campaigns.ShopKind Kind { get; set; } = RealmForge.Shared.Campaigns.ShopKind.General;
		public int? Seed { get; set; }
	}

	public class SaveCampaignShopDto
	{
		public string NameIt { get; set; } = string.Empty;
		public string NameEn { get; set; } = string.Empty;
		public string DescriptionIt { get; set; } = string.Empty;
		public string DescriptionEn { get; set; } = string.Empty;
		public int PricePercent { get; set; } = 100;
		public bool Open { get; set; }
		//	The faction the shop belongs to: its standing moves the prices
		public Guid? FactionId { get; set; }
		//	The merchant: an NPC shared with the campaign
		public Guid? NpcId { get; set; }
	}

	///	<summary>
	///	An item put on sale: equipment or a magic item of the compendium, or a free entry (Name and PriceInCopper). A
	///	null price takes the list price (of a magic item: the usual one of its rarity).
	///	</summary>
	public class SaveShopItemDto
	{
		public Guid? EquipmentId { get; set; }
		public Guid? MagicItemId { get; set; }
		public string? Name { get; set; }
		public int? PriceInCopper { get; set; }
		public int? Stock { get; set; }
		//	On an update: a discount on this item (0 to 90%); Reset: back to the standard price, no discount
		public int? Discount { get; set; }
		public bool Reset { get; set; }
	}

	public class BuyShopItemDto
	{
		public Guid CharacterId { get; set; }
		public int Quantity { get; set; } = 1;
	}

	//	A purchase made: what, how many, the copper paid and the purse left; StockLeft null: no limit
	public record ShopPurchaseDto(string Item, int Quantity, int Paid, CoinPurse Coins, int? StockLeft);
}
