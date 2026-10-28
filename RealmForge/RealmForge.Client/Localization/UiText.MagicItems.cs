using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;

namespace RealmForge.Client.Localization
{
	///	<summary>
	///	Texts of the magic items compendium and of the compendium picker of the sheet.
	///	</summary>
	public static partial class UiText
	{
		public static string MagicItemsTitle(LanguageCode lang) => T(lang, "Oggetti magici", "Magic items");
		public static string MagicItemsSubtitle(LanguageCode lang) =>
			T(lang, "Armi, armature, anelli, pozioni e meraviglie, pronti per la scheda", "Weapons, armor, rings, potions and wonders, ready for the sheet");
		public static string LoadingMagicItems(LanguageCode lang) => T(lang, "Caricamento oggetti magici...", "Loading magic items...");
		public static string NoMagicItemsFound(LanguageCode lang) => T(lang, "Nessun oggetto magico trovato.", "No magic items found.");
		public static string MagicItemCount(int count, LanguageCode lang) => lang == LanguageCode.It
			? (count == 1 ? "1 oggetto" : $"{count} oggetti")
			: (count == 1 ? "1 item" : $"{count} items");
		public static string LabelSearchMagicItem(LanguageCode lang) => T(lang, "Cerca", "Search");
		public static string PlaceholderSearchMagicItems(LanguageCode lang) => T(lang, "Nome o testo...", "Name or text...");
		public static string LabelMagicType(LanguageCode lang) => T(lang, "Categoria", "Category");
		public static string LabelRarity(LanguageCode lang) => T(lang, "Rarità", "Rarity");
		public static string FilterAllMagicTypes(LanguageCode lang) => T(lang, "Tutte le categorie", "All categories");
		public static string FilterAllRarities(LanguageCode lang) => T(lang, "Tutte le rarità", "All rarities");
		public static string FilterAttunement(LanguageCode lang) => T(lang, "Richiede sintonia", "Requires attunement");
		public static string FilterNoAttunement(LanguageCode lang) => T(lang, "Senza sintonia", "No attunement");
		public static string FilterAppliedOnSheet(LanguageCode lang) => T(lang, "Effetti sulla scheda", "Effects on the sheet");
		public static string RarityVaries(LanguageCode lang) => T(lang, "Rarità variabile", "Rarity varies");
		public static string MagicVariants(LanguageCode lang) => T(lang, "Varianti", "Variants");
		public static string MagicVariantOf(LanguageCode lang) => T(lang, "Variante di", "Variant of");
		public static string MagicAlsoKnownAs(LanguageCode lang) => T(lang, "Noto anche come", "Also known as");
		public static string MagicOnSheet(LanguageCode lang) => T(lang, "Sulla scheda", "On the sheet");
		public static string MagicChargesCount(int charges, LanguageCode lang) => T(lang, $"{charges} cariche", $"{charges} charges");
		public static string MagicChargesBack(string? dice, LanguageCode lang) => dice is null
			? T(lang, "tutte all'alba", "all at dawn")
			: T(lang, $"{dice} all'alba", $"{dice} at dawn");

		public static string MagicTypeName(MagicItemType type, LanguageCode lang) => (type, lang == LanguageCode.It) switch
		{
			(MagicItemType.Armor, true) => "Armature",
			(MagicItemType.Potion, true) => "Pozioni",
			(MagicItemType.Ring, true) => "Anelli",
			(MagicItemType.Rod, true) => "Verghe",
			(MagicItemType.Scroll, true) => "Pergamene",
			(MagicItemType.Staff, true) => "Bastoni",
			(MagicItemType.Wand, true) => "Bacchette",
			(MagicItemType.Weapon, true) => "Armi",
			(MagicItemType.WondrousItem, true) => "Oggetti meravigliosi",
			(MagicItemType.Armor, false) => "Armor",
			(MagicItemType.Potion, false) => "Potions",
			(MagicItemType.Ring, false) => "Rings",
			(MagicItemType.Rod, false) => "Rods",
			(MagicItemType.Scroll, false) => "Scrolls",
			(MagicItemType.Staff, false) => "Staffs",
			(MagicItemType.Wand, false) => "Wands",
			(MagicItemType.Weapon, false) => "Weapons",
			_ => "Wondrous items"
		};

		//	Sheet: items taken from the compendium
		public static string MagicFromCompendium(LanguageCode lang) => T(lang, "Dal compendio", "From the compendium");
		public static string MagicCompendiumSearch(LanguageCode lang) => T(lang, "Cerca un oggetto magico...", "Search a magic item...");
		public static string MagicCompendiumNone(LanguageCode lang) => T(lang, "Nessun oggetto trovato.", "No item found.");
		public static string MagicCompendiumChosen(LanguageCode lang) => T(lang, "Preso dal compendio", "Taken from the compendium");
		public static string MagicOpenDetail(LanguageCode lang) => T(lang, "Dettagli", "Details");
	}
}
