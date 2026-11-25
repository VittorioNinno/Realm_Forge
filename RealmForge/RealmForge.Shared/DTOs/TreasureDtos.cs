using RealmForge.Shared.Characters;

namespace RealmForge.Shared.DTOs
{
	///	<summary>
	///	The party's chest: the coins not shared out, the items (unidentified ones as the players see them) and the
	///	characters at the table who can receive them (CanTake: the reader can give to them).
	///	</summary>
	public record CampaignTreasureDto(CoinPurse Coins, List<TreasureItemDto> Items, List<TreasureCharacterDto> Characters);

	//	Name: the real one once identified (for the masters always); Appearance: what it looks like
	public record TreasureItemDto(Guid Id, string Kind, Guid? EntryId, string Name, string Appearance, bool Identified, int Quantity, int? ValueInCopper,
		string? TrueName = null);

	public record TreasureCharacterDto(Guid Id, string Name, bool Active, bool CanTake);

	public class SaveTreasureItemDto
	{
		public Guid? EquipmentId { get; set; }
		public Guid? MagicItemId { get; set; }
		public string? Name { get; set; }
		public string? Appearance { get; set; }
		public bool Identified { get; set; } = true;
		public int Quantity { get; set; } = 1;
		public int? ValueInCopper { get; set; }
	}

	public class GiveTreasureDto
	{
		public Guid CharacterId { get; set; }
		public int Quantity { get; set; } = 1;
	}

	//	An item of the chest put on a token of a map (a chest, a creature that carries it)
	public class PlaceTreasureDto
	{
		public Guid MapId { get; set; }
		public Guid TokenId { get; set; }
		public int Quantity { get; set; } = 1;
	}

	//	The coins shared out among these characters (none: every active character at the table)
	public class SplitTreasureDto
	{
		public List<Guid>? CharacterIds { get; set; }
	}

	public record TreasureSplitDto(CoinPurse Each, CoinPurse Left, List<string> Characters);
}
