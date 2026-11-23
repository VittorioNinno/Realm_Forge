using RealmForge.Shared.Enums;

namespace RealmForge.Client.Localization
{
	///	<summary>Texts of the background assistant of the wizard.</summary>
	public static partial class UiText
	{
		public static string BgAssistant(LanguageCode lang) => T(lang, "Assistente del passato", "Backstory assistant");
		public static string BgAssistantHint(LanguageCode lang) => T(lang,
			"Tre idee per il passato del personaggio, pensate per la sua classe, il suo allineamento e il suo background: scegline una e modificala nei Dettagli.",
			"Three ideas for the character's past, shaped by class, alignment and background: pick one and edit it in Details.");
		public static string BgAssistantPropose(LanguageCode lang) => T(lang, "Proponi 3 idee", "Suggest 3 ideas");
		public static string BgAssistantAgain(LanguageCode lang) => T(lang, "Altre 3 idee", "3 more ideas");
		public static string BgAssistantUse(LanguageCode lang) => T(lang, "Usa questa", "Use this one");
		public static string BgAssistantUsed(LanguageCode lang) => T(lang, "Scelta", "Chosen");
	}
}
