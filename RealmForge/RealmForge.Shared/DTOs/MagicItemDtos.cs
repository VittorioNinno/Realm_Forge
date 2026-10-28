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
}
