using RealmForge.Shared.Enums;

namespace RealmForge.Client.Localization
{
	///	<summary>Texts of the handouts: letters, clues and pictures revealed to the players.</summary>
	public static partial class UiText
	{
		public static string CampaignTabHandouts(LanguageCode lang) => T(lang, "Handout", "Handouts");
		public static string HandoutsHintMaster(LanguageCode lang) => T(lang,
			"Prepara lettere, indizi, ritratti e mappe non tattiche; rivelali durante la sessione: si aprono sullo schermo dei giocatori al tavolo, ognuno nella propria lingua.",
			"Prepare letters, clues, portraits and maps that are not tactical; reveal them during the session: they open on the players' screens at the table, each in their own language.");
		public static string HandoutsHintPlayer(LanguageCode lang) => T(lang, "I documenti e gli indizi che il master vi ha mostrato.", "The documents and clues the master showed you.");
		public static string HandoutsEmptyMaster(LanguageCode lang) => T(lang, "Nessun handout ancora.", "No handouts yet.");
		public static string HandoutsEmptyPlayer(LanguageCode lang) => T(lang, "Il master non vi ha ancora mostrato nessun handout.", "The master has not shown you any handout yet.");
		public static string HandoutNew(LanguageCode lang) => T(lang, "Nuovo handout", "New handout");
		public static string HandoutTitle(LanguageCode lang) => T(lang, "Titolo", "Title");
		public static string HandoutBody(LanguageCode lang) => T(lang, "Testo (Markdown)", "Text (Markdown)");
		public static string HandoutImage(LanguageCode lang) => T(lang, "Immagine", "Picture");
		public static string HandoutLanguagesHint(LanguageCode lang) => T(lang, "Basta una lingua: chi legge nell'altra vede quella scritta.", "One language is enough: whoever reads the other one sees the one written.");
		public static string HandoutNeedsTitle(LanguageCode lang) => T(lang, "Serve un titolo, in almeno una lingua.", "A title is needed, in one language at least.");
		public static string HandoutReveal(LanguageCode lang) => T(lang, "Rivela", "Reveal");
		public static string HandoutRevealAgain(LanguageCode lang) => T(lang, "Mostra di nuovo", "Show again");
		public static string HandoutHide(LanguageCode lang) => T(lang, "Nascondi ai giocatori", "Hide from the players");
		public static string HandoutHidden(LanguageCode lang) => T(lang, "Dietro lo schermo", "Behind the screen");
		public static string HandoutRevealedAt(DateTimeOffset at, LanguageCode lang) => T(lang, $"Rivelato {FormatDateTime(at, lang)}", $"Revealed {FormatDateTime(at, lang)}");
		public static string VttToolHandouts(LanguageCode lang) => T(lang, "Handout", "Handouts");
	}
}
