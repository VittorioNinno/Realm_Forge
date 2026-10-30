using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;

namespace RealmForge.Shared.DTOs
{
	///	<summary>
	///	Magic item in the localized list. Variants (a Potion of Greater Healing, a Belt of Frost Giant Strength…) are listed
	///	too, with the id of their item; Mechanics are the rules the character sheet applies on its own (null: none).
	///	Rarity null means it varies with the variant.
	///	</summary>
	public record MagicItemResponseDto(
		Guid Id,
		string Name,
		RulesetVersion Ruleset,
		bool IsOfficialSRD,
		MagicItemType Type,
		ItemRarity? Rarity,
		bool RequiresAttunement,
		string Subtitle,
		string ShortDescription,
		Guid? ParentId,
		MagicItemProperties? Mechanics,
		string? Alias = null,
		ContentSource? Source = null,
		ContentVisibility Visibility = ContentVisibility.Public
	);

	///	<summary>
	///	A variant of an item, shown in the item's detail.
	///	</summary>
	public record MagicItemVariantDto(Guid Id, string Name, ItemRarity? Rarity, bool RequiresAttunement, string Subtitle, MagicItemProperties? Mechanics);

	///	<summary>
	///	Item detail in one language. A variant has no text of its own: Description is the one of its item (ParentId).
	///	</summary>
	public record MagicItemDetailResponseDto(
		Guid Id,
		string Name,
		RulesetVersion Ruleset,
		bool IsOfficialSRD,
		MagicItemType Type,
		ItemRarity? Rarity,
		bool RequiresAttunement,
		string Subtitle,
		string Description,
		MagicItemProperties? Mechanics,
		Guid? ParentId,
		string? ParentName,
		List<MagicItemVariantDto> Variants,
		string? Alias = null,
		bool CanEdit = false,
		ContentSource? Source = null,
		ContentVisibility Visibility = ContentVisibility.Public
	);

	///	<summary>
	///	Texts of a Homebrew magic item in one language: Subtitle is the item line ("Oggetto meraviglioso, raro"),
	///	Description is Markdown.
	///	</summary>
	public class MagicItemTextDto
	{
		public LanguageCode Language { get; set; }
		public string Name { get; set; } = string.Empty;
		public string? Alias { get; set; }
		public string Subtitle { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
	}

	///	<summary>
	///	Creation or update of a Homebrew magic item. VariantOfId makes it a variant of another item (listed under it,
	///	with its own name, rarity and rules); Mechanics are the rules the sheet applies (rarity and attunement are the
	///	ones of the item).
	///	</summary>
	public class SaveMagicItemDto
	{
		public RulesetVersion Ruleset { get; set; } = RulesetVersion.Dnd5e_2014;
		public ContentVisibility Visibility { get; set; } = ContentVisibility.Private;
		public MagicItemType Type { get; set; } = MagicItemType.WondrousItem;
		public ItemRarity? Rarity { get; set; } = ItemRarity.Uncommon;
		public bool RequiresAttunement { get; set; }
		public MagicItemProperties? Mechanics { get; set; }
		public Guid? VariantOfId { get; set; }
		public List<MagicItemTextDto> Translations { get; set; } = new();
	}
}
