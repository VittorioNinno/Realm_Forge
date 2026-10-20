using RealmForge.Shared.Enums;

namespace RealmForge.Shared.Characters;

public enum LanguageGroup
{
	Standard = 1,

	//	2014: "Exotic Languages" (Linguaggi esotici); 2024: "Rare Languages" (Lingue rare)
	Exotic = 2,

	//	2014: secret languages taught by a class (Druidic, Thieves' Cant)
	Secret = 3
}

///	<summary>
///	A language of the Player's Handbook tables: official names in both languages and its typical speakers (2014)
///	or origin (2024).
///	</summary>
public sealed record LanguageEntry(string Key, LanguageGroup Group, string NameEn, string NameIt, string OriginEn, string OriginIt);

///	<summary>
///	Language tables of the Player's Handbook: 2014 (chapter 4, Standard and Exotic Languages; Druidic and Thieves' Cant
///	are secret class languages) and 2024 (chapter 2, Standard and Rare Languages). Characters store the keys.
///	</summary>
public static class CharacterLanguages
{
	public const string Common = "common";
	public const string Druidic = "druidic";
	public const string ThievesCant = "thieves-cant";

	private static readonly IReadOnlyList<LanguageEntry> Languages2014 = new[]
	{
		new LanguageEntry("common", LanguageGroup.Standard, "Common", "Comune", "Humans", "Umani"),
		new LanguageEntry("dwarvish", LanguageGroup.Standard, "Dwarvish", "Nanico", "Dwarves", "Nani"),
		new LanguageEntry("elvish", LanguageGroup.Standard, "Elvish", "Elfico", "Elves", "Elfi"),
		new LanguageEntry("giant", LanguageGroup.Standard, "Giant", "Gigante", "Ogres, giants", "Ogre, giganti"),
		new LanguageEntry("gnomish", LanguageGroup.Standard, "Gnomish", "Gnomesco", "Gnomes", "Gnomi"),
		new LanguageEntry("goblin", LanguageGroup.Standard, "Goblin", "Goblin", "Goblinoids", "Goblinoidi"),
		new LanguageEntry("halfling", LanguageGroup.Standard, "Halfling", "Halfling", "Halflings", "Halfling"),
		new LanguageEntry("orc", LanguageGroup.Standard, "Orc", "Orchesco", "Orcs", "Orchi"),
		new LanguageEntry("abyssal", LanguageGroup.Exotic, "Abyssal", "Abissale", "Demons", "Demoni"),
		new LanguageEntry("celestial", LanguageGroup.Exotic, "Celestial", "Celestiale", "Celestials", "Celestiali"),
		new LanguageEntry("draconic", LanguageGroup.Exotic, "Draconic", "Draconico", "Dragons, dragonborn", "Draghi, dragonidi"),
		new LanguageEntry("deep-speech", LanguageGroup.Exotic, "Deep Speech", "Gergo delle Profondità", "Aboleths, cloakers", "Aboleth, mantelli"),
		new LanguageEntry("infernal", LanguageGroup.Exotic, "Infernal", "Infernale", "Devils", "Diavoli"),
		new LanguageEntry("primordial", LanguageGroup.Exotic, "Primordial", "Primordiale", "Elementals", "Elementali"),
		new LanguageEntry("sylvan", LanguageGroup.Exotic, "Sylvan", "Silvano", "Fey creatures", "Creature fatate"),
		new LanguageEntry("undercommon", LanguageGroup.Exotic, "Undercommon", "Sottocomune", "Underdark traders", "Mercanti del Sottosuolo"),
		new LanguageEntry("druidic", LanguageGroup.Secret, "Druidic", "Druidico", "Druids", "Druidi"),
		new LanguageEntry("thieves-cant", LanguageGroup.Secret, "Thieves' Cant", "Gergo Ladresco", "Rogues", "Ladri")
	};

	private static readonly IReadOnlyList<LanguageEntry> Languages2024 = new[]
	{
		new LanguageEntry("common", LanguageGroup.Standard, "Common", "Comune", "Sigil", "Sigil"),
		new LanguageEntry("common-sign-language", LanguageGroup.Standard, "Common Sign Language", "Lingua dei Segni Comune", "Sigil", "Sigil"),
		new LanguageEntry("draconic", LanguageGroup.Standard, "Draconic", "Draconico", "Dragons", "Draghi"),
		new LanguageEntry("dwarvish", LanguageGroup.Standard, "Dwarvish", "Nanico", "Dwarves", "Nani"),
		new LanguageEntry("elvish", LanguageGroup.Standard, "Elvish", "Elfico", "Elves", "Elfi"),
		new LanguageEntry("giant", LanguageGroup.Standard, "Giant", "Gigante", "Giants", "Giganti"),
		new LanguageEntry("gnomish", LanguageGroup.Standard, "Gnomish", "Gnomesco", "Gnomes", "Gnomi"),
		new LanguageEntry("goblin", LanguageGroup.Standard, "Goblin", "Goblin", "Goblinoids", "Goblinoidi"),
		new LanguageEntry("halfling", LanguageGroup.Standard, "Halfling", "Halfling", "Halflings", "Halfling"),
		new LanguageEntry("orc", LanguageGroup.Standard, "Orc", "Orchesco", "Orcs", "Orchi"),
		new LanguageEntry("abyssal", LanguageGroup.Exotic, "Abyssal", "Abissale", "Demons of the Abyss", "Demoni dell'Abisso"),
		new LanguageEntry("celestial", LanguageGroup.Exotic, "Celestial", "Celestiale", "Celestials", "Celestiali"),
		new LanguageEntry("deep-speech", LanguageGroup.Exotic, "Deep Speech", "Gergo delle Profondità", "Aberrations", "Aberrazioni"),
		new LanguageEntry("druidic", LanguageGroup.Exotic, "Druidic", "Druidico", "Druidic circles", "Circoli druidici"),
		new LanguageEntry("infernal", LanguageGroup.Exotic, "Infernal", "Infernale", "Devils of the Nine Hells", "Diavoli dei Nove Inferi"),
		new LanguageEntry("primordial", LanguageGroup.Exotic, "Primordial", "Primordiale", "Elementals", "Elementali"),
		new LanguageEntry("sylvan", LanguageGroup.Exotic, "Sylvan", "Silvano", "The Feywild", "La Selva Fatata"),
		new LanguageEntry("thieves-cant", LanguageGroup.Exotic, "Thieves' Cant", "Gergo Ladresco", "Various criminal guilds", "Gilde criminali varie"),
		new LanguageEntry("undercommon", LanguageGroup.Exotic, "Undercommon", "Sottocomune", "The Underdark", "Il Sottosuolo")
	};

	public static IReadOnlyList<LanguageEntry> All(RulesetVersion ruleset) =>
		ruleset == RulesetVersion.Dnd5e_2024 ? Languages2024 : Languages2014;

	public static LanguageEntry? Find(RulesetVersion ruleset, string key) =>
		All(ruleset).FirstOrDefault(l => l.Key == key);

	public static bool IsKnown(RulesetVersion ruleset, string key) => Find(ruleset, key) is not null;

	public static string Name(RulesetVersion ruleset, string key, LanguageCode lang) =>
		Find(ruleset, key) is { } entry ? (lang == LanguageCode.It ? entry.NameIt : entry.NameEn) : key;

	//	Languages a player can pick freely (the secret 2014 ones come only from their class)
	public static IEnumerable<LanguageEntry> Choosable(RulesetVersion ruleset) =>
		All(ruleset).Where(l => l.Group != LanguageGroup.Secret && l.Key != Common);
}
