using RealmForge.Shared.Enums;

namespace RealmForge.Client.Localization
{
	///	<summary>Texts of the table screen (the second window of a master's table, for the players round it).</summary>
	public static partial class UiText
	{
		public static string TableScreenName(LanguageCode lang) => T(lang, "Schermo del tavolo", "Table screen");
		public static string TableScreenOpen(LanguageCode lang) => T(lang, "Schermo del tavolo", "Table screen");
		public static string TableScreenOpenHint(LanguageCode lang) => T(lang,
			"Apre una seconda finestra da portare sul monitor (o sullo schermo touch) del tavolo: i giocatori ci giocano i propri turni mentre tu continui a gestire tutto da qui.",
			"Opens a second window to move to the table's monitor (or touch screen): the players play their turns on it while you keep running everything from here.");
		public static string TableScreenActing(string name, LanguageCode lang) => T(lang, $"Agisce: {name}", $"Acting: {name}");
		public static string TableScreenActingHint(LanguageCode lang) => T(lang,
			"Le azioni fatte qui sono di questo giocatore: tocca un altro personaggio per passare a lui; in combattimento agisce chi è di turno.",
			"What is done here is this player's: tap another character to switch to them; in combat whoever's turn it is acts.");
		public static string TableScreenTouch(LanguageCode lang) => T(lang, "Touch", "Touch");
		public static string TableScreenTouchHint(LanguageCode lang) => T(lang,
			"Schermo touch: pulsanti e segnalini più grandi da toccare; trascina con un dito, sposta e ingrandisci la mappa con due.",
			"Touch screen: bigger buttons and tokens to tap; drag with one finger, move and zoom the map with two.");
		public static string TableScreenFullscreen(LanguageCode lang) => T(lang, "Schermo intero", "Full screen");
	}
}
