using RealmForge.Shared.Enums;

namespace RealmForge.Client.Localization
{
	///	<summary>Texts of the equivalences between the 2014 and 2024 editions.</summary>
	public static partial class UiText
	{
		public static string EquivalentIn(RulesetVersion ruleset, LanguageCode lang) =>
			T(lang, $"Nell'edizione {(ruleset == RulesetVersion.Dnd5e_2014 ? "2014" : "2024")}:", $"In the {(ruleset == RulesetVersion.Dnd5e_2014 ? "2014" : "2024")} edition:");
		public static string EquivalentHint(LanguageCode lang) => T(lang,
			"La voce corrispondente nell'altra edizione (stesso nome inglese): utile per convertire personaggi e avventure.",
			"The corresponding entry in the other edition (same English name): useful to convert characters and adventures.");
	}
}
