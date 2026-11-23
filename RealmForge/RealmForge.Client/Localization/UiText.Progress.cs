using RealmForge.Shared.Enums;

namespace RealmForge.Client.Localization
{
	///	<summary>Texts of the progress clocks and of the factions.</summary>
	public static partial class UiText
	{
		public static string CampaignTabProgress(LanguageCode lang) => T(lang, "Orologi e fazioni", "Clocks and factions");
		public static string ProgressHintMaster(LanguageCode lang) => T(lang,
			"Gli orologi segnano una minaccia o un progetto che avanza: riempi un segmento a ogni fallimento o lascia che si riempiano da soli con il tempo di gioco. La reputazione con una fazione cambia i prezzi dei negozi collegati.",
			"Clocks track a threat or a project that moves on: fill a segment at each failure or let them fill by themselves with the game time. The standing with a faction changes the prices of the shops tied to it.");
		public static string ProgressHintPlayer(LanguageCode lang) => T(lang,
			"Gli orologi e le fazioni che il master ha reso visibili.",
			"The clocks and the factions the master has shown.");
		public static string ProgressClocks(LanguageCode lang) => T(lang, "Orologi di progresso", "Progress clocks");
		public static string ProgressClockName(LanguageCode lang) => T(lang, "Nome dell'orologio (es. Il rituale si compie)", "Clock name (e.g. The ritual is completed)");
		public static string ProgressSegments(LanguageCode lang) => T(lang, "Segmenti", "Segments");
		public static string ProgressSegmentsOption(int n, LanguageCode lang) => T(lang, $"{n} segmenti", $"{n} segments");
		public static string ProgressTick(LanguageCode lang) => T(lang, "Avanzamento", "Advances");
		public static string ProgressByHand(LanguageCode lang) => T(lang, "A mano", "By hand");
		public static string ProgressEvery(int hours, LanguageCode lang) => hours % 24 == 0
			? T(lang, hours == 24 ? "Ogni giorno di gioco" : $"Ogni {hours / 24} giorni di gioco", hours == 24 ? "Every game day" : $"Every {hours / 24} game days")
			: T(lang, hours == 1 ? "Ogni ora di gioco" : $"Ogni {hours} ore di gioco", hours == 1 ? "Every game hour" : $"Every {hours} game hours");
		public static string ProgressColor(LanguageCode lang) => T(lang, "Colore", "Colour");
		public static string ProgressShown(LanguageCode lang) => T(lang, "Visibile ai giocatori", "Shown to the players");
		public static string ProgressHidden(LanguageCode lang) => T(lang, "Nascosto", "Hidden");
		public static string ProgressShow(LanguageCode lang) => T(lang, "Mostra ai giocatori", "Show to the players");
		public static string ProgressHide(LanguageCode lang) => T(lang, "Nascondi ai giocatori", "Hide from the players");
		public static string ProgressAddClock(LanguageCode lang) => T(lang, "Aggiungi orologio", "Add clock");
		public static string ProgressNoClocks(LanguageCode lang) => T(lang, "Nessun orologio.", "No clocks.");
		public static string ProgressClockLabel(string name, int filled, int segments, LanguageCode lang) => T(lang, $"{name}: {filled} segmenti su {segments}", $"{name}: {filled} of {segments} segments");
		public static string ProgressMore(LanguageCode lang) => T(lang, "Riempi un segmento", "Fill a segment");
		public static string ProgressLess(LanguageCode lang) => T(lang, "Svuota un segmento", "Empty a segment");
		public static string ProgressFactions(LanguageCode lang) => T(lang, "Fazioni", "Factions");
		public static string ProgressFactionName(LanguageCode lang) => T(lang, "Nome della fazione", "Faction name");
		public static string ProgressFactionDescription(LanguageCode lang) => T(lang, "Descrizione (facoltativa)", "Description (optional)");
		public static string ProgressAddFaction(LanguageCode lang) => T(lang, "Aggiungi fazione", "Add faction");
		public static string ProgressNoFactions(LanguageCode lang) => T(lang, "Nessuna fazione.", "No factions.");
		public static string ProgressBetter(LanguageCode lang) => T(lang, "Migliora la reputazione", "Improve the standing");
		public static string ProgressWorse(LanguageCode lang) => T(lang, "Peggiora la reputazione", "Worsen the standing");
		public static string ProgressStanding(int standing, LanguageCode lang) => standing switch
		{
			<= -3 => T(lang, "Ostile", "Hostile"),
			-2 => T(lang, "Avversa", "Unfriendly"),
			-1 => T(lang, "Diffidente", "Wary"),
			0 => T(lang, "Neutrale", "Neutral"),
			1 => T(lang, "Cordiale", "Friendly"),
			2 => T(lang, "Fidata", "Trusted"),
			_ => T(lang, "Alleata", "Allied")
		};
		public static string ProgressPrices(int percent, LanguageCode lang) => T(lang,
			$"Prezzi nei suoi negozi: {(percent > 100 ? "+" : string.Empty)}{percent - 100}%",
			$"Prices in its shops: {(percent > 100 ? "+" : string.Empty)}{percent - 100}%");
		public static string ProgressFailed(LanguageCode lang) => T(lang, "Operazione non riuscita.", "That didn't work.");
		public static string ShopFaction(LanguageCode lang) => T(lang, "Fazione", "Faction");
		public static string ShopNoFaction(LanguageCode lang) => T(lang, "Nessuna", "None");
	}
}
