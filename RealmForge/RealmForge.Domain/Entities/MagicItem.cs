using RealmForge.Domain.Common;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;

namespace RealmForge.Domain.Entities
{
	///	<summary>
	///	A magic item of the treasure chapter. Category, rarity and attunement are structured (used by the filters);
	///	Mechanics holds the rules the character sheet applies on its own (MagicItemProperties as JSON: effects, charges,
	///	recharge, healing). An item can have variants (ParentId): the healing potions, the giant strength belts, the
	///	+1/+2/+3 weapons… each with its own name, rarity and mechanics, and the text of the parent item.
	///	</summary>
	public class MagicItem : GameEntity
	{
		public MagicItemType Type { get; set; }

		//	Null when the rarity varies with the variant
		public ItemRarity? Rarity { get; set; }

		public bool RequiresAttunement { get; set; }

		//	JSON of MagicItemProperties; null when the sheet has nothing to apply
		public string? Mechanics { get; set; }

		public Guid? ParentId { get; set; }
		public MagicItem? Parent { get; set; }
		public ICollection<MagicItem> Variants { get; set; } = new List<MagicItem>();

		//	Order of the variants inside their item (the order of the book table)
		public int SortOrder { get; set; }

		public ICollection<MagicItemTranslation> Translations { get; set; } = new List<MagicItemTranslation>();
	}

	///	<summary>
	///	Texts of a magic item in one language (unique per item and language). Description is Markdown and is empty for
	///	variants; Subtitle is the item line ("Oggetto meraviglioso, raro (richiede sintonia)"); Alias is another name the
	///	item is known by (the 2014 Dungeon Master's Guide names of some SRD items).
	///	</summary>
	public class MagicItemTranslation : ITranslation
	{
		public Guid Id { get; set; } = Guid.NewGuid();

		public Guid MagicItemId { get; set; }
		public MagicItem MagicItem { get; set; } = null!;

		public LanguageCode Language { get; set; }

		public string Name { get; set; } = string.Empty;
		public string Subtitle { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public string? Alias { get; set; }
	}
}
