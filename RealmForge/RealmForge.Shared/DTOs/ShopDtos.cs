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
		string? DescriptionEn = null);

	///	<summary>
	///	An item on sale: ListPrice of one piece before the shop's multiplier, Price what a piece costs in the shop
	///	(copper pieces); Stock null: as many as wanted. Kind: equipment, magic-item or free.
	///	</summary>
	public record ShopItemDto(Guid Id, string Kind, Guid? EntryId, string Name, int ListPrice, int Price, int? Stock, ItemRarity? Rarity = null);

	public record ShopBuyerDto(Guid CharacterId, string Name, CoinPurse Coins);

	public class SaveCampaignShopDto
	{
		public string NameIt { get; set; } = string.Empty;
		public string NameEn { get; set; } = string.Empty;
		public string DescriptionIt { get; set; } = string.Empty;
		public string DescriptionEn { get; set; } = string.Empty;
		public int PricePercent { get; set; } = 100;
		public bool Open { get; set; }
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
	}

	public class BuyShopItemDto
	{
		public Guid CharacterId { get; set; }
		public int Quantity { get; set; } = 1;
	}

	//	A purchase made: what, how many, the copper paid and the purse left; StockLeft null: no limit
	public record ShopPurchaseDto(string Item, int Quantity, int Paid, CoinPurse Coins, int? StockLeft);
}
