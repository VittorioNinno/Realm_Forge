using RealmForge.Shared.Campaigns;
using RealmForge.Shared.Enums;

namespace RealmForge.Client.Localization
{
	///	<summary>Texts of the game clock, the effects that last on it and the supplies of the journey.</summary>
	public static partial class UiText
	{
		//	"Giorno 3 · 14:20"
		public static string ClockText(long minutes, LanguageCode lang) =>
			T(lang, $"Giorno {GameClock.Day(minutes)} · {GameClock.Hour(minutes):00}:{GameClock.Minute(minutes):00}", $"Day {GameClock.Day(minutes)} · {GameClock.Hour(minutes):00}:{GameClock.Minute(minutes):00}");

		//	"G3 14:20" (the bar of the table)
		public static string ClockShort(long minutes, LanguageCode lang) =>
			T(lang, $"G{GameClock.Day(minutes)} {GameClock.Hour(minutes):00}:{GameClock.Minute(minutes):00}", $"D{GameClock.Day(minutes)} {GameClock.Hour(minutes):00}:{GameClock.Minute(minutes):00}");

		//	"2 g 3 h", "45 min"
		public static string ClockSpan(long minutes, LanguageCode lang)
		{
			if (minutes < 60)
			{
				return $"{Math.Max(0, minutes)} min";
			}
			var days = minutes / GameClock.MinutesPerDay;
			var hours = minutes % GameClock.MinutesPerDay / 60;
			var rest = minutes % 60;
			var parts = new List<string>();
			if (days > 0)
			{
				parts.Add(T(lang, $"{days} g", $"{days} d"));
			}
			if (hours > 0)
			{
				parts.Add($"{hours} h");
			}
			if (days == 0 && rest > 0)
			{
				parts.Add($"{rest} min");
			}
			return string.Join(" ", parts);
		}

		public static string ClockTitle(LanguageCode lang) => T(lang, "Tempo di gioco", "Game time");
		public static string ClockHintMaster(LanguageCode lang) => T(lang,
			"Fai scorrere il tempo: gli incantesimi lunghi dei personaggi scadono da soli e, con i giorni di viaggio, ognuno consuma una razione al giorno.",
			"Move the time on: the characters' long spells end on their own and, with days of travel, each one eats a ration a day.");
		public static string ClockHintPlayer(LanguageCode lang) => T(lang, "Il master fa scorrere il tempo della campagna.", "The master moves the time of the campaign on.");
		public static string ClockPlus10(LanguageCode lang) => "+10 min";
		public static string ClockPlusHour(LanguageCode lang) => "+1 h";
		public static string ClockLongRest(LanguageCode lang) => T(lang, "+8 h (riposo lungo)", "+8 h (long rest)");
		public static string ClockPlusDay(LanguageCode lang) => T(lang, "+1 giorno", "+1 day");
		public static string ClockCustom(LanguageCode lang) => T(lang, "Avanza di", "Move on by");
		public static string ClockHours(LanguageCode lang) => T(lang, "ore", "hours");
		public static string ClockDays(LanguageCode lang) => T(lang, "giorni", "days");
		public static string ClockGo(LanguageCode lang) => T(lang, "Avanza", "Move on");
		public static string ClockRations(LanguageCode lang) => T(lang, "Consuma una razione al giorno", "Eat a ration a day");
		public static string ClockSet(LanguageCode lang) => T(lang, "Imposta", "Set");
		public static string ClockSetShort(LanguageCode lang) => T(lang, "Imposta", "Set");
		public static string ClockApply(LanguageCode lang) => T(lang, "Applica", "Apply");
		public static string ClockMinutes(LanguageCode lang) => T(lang, "minuti", "minutes");
		public static string ClockActive(int count, LanguageCode lang) => T(lang, count == 1 ? "1 attivo" : $"{count} attivi", $"{count} active");
		public static string ClockPhase(string phase, LanguageCode lang) => phase switch
		{
			"morning" => T(lang, "Mattina", "Morning"),
			"afternoon" => T(lang, "Pomeriggio", "Afternoon"),
			"evening" => T(lang, "Sera", "Evening"),
			_ => T(lang, "Notte", "Night")
		};
		public static string ClockDay(LanguageCode lang) => T(lang, "Giorno", "Day");
		public static string ClockTime(LanguageCode lang) => T(lang, "Ora", "Time");
		public static string ClockEffects(LanguageCode lang) => T(lang, "Effetti in corso", "Running effects");
		public static string ClockNoEffects(LanguageCode lang) => T(lang, "Nessun effetto in corso.", "No running effects.");
		public static string ClockLeft(long minutes, LanguageCode lang) => T(lang, $"ancora {ClockSpan(minutes, lang)}", $"{ClockSpan(minutes, lang)} left");
		public static string ClockExpired(string character, string effect, LanguageCode lang) => T(lang, $"{character}: {effect} è terminato.", $"{character}: {effect} has ended.");
		public static string ClockHungry(string character, int days, LanguageCode lang) => T(lang,
			$"{character} è rimasto senza razioni per {days} {(days == 1 ? "giorno" : "giorni")}.", $"{character} went without rations for {days} {(days == 1 ? "day" : "days")}.");
		public static string ClockAte(int days, LanguageCode lang) => T(lang, $"Razioni consumate per {days} {(days == 1 ? "giorno" : "giorni")}.", $"Rations eaten for {days} {(days == 1 ? "day" : "days")}.");
		public static string ClockFailed(LanguageCode lang) => T(lang, "Non è stato possibile spostare il tempo.", "The time could not be moved.");

		// ----- The sheet -----

		public static string SuppliesTitle(LanguageCode lang) => T(lang, "Scorte", "Supplies");
		public static string SuppliesRations(LanguageCode lang) => T(lang, "Razioni", "Rations");
		public static string SuppliesTorches(LanguageCode lang) => T(lang, "Torce", "Torches");
		public static string SuppliesEmpty(LanguageCode lang) => T(lang, "Nessuna razione, torcia o munizione nell'inventario.", "No rations, torches or ammunition in the inventory.");
		public static string SuppliesRecover(int pieces, LanguageCode lang) => T(lang, $"Recupera metà delle munizioni ({pieces / 2} di {pieces})", $"Recover half the ammunition ({pieces / 2} of {pieces})");
		public static string SuppliesRecovered(int pieces, LanguageCode lang) => T(lang, $"Recuperate {pieces} munizioni.", $"{pieces} pieces of ammunition recovered.");
		public static string SuppliesUseOne(LanguageCode lang) => T(lang, "Usa una", "Use one");
		public static string SuppliesAddOne(LanguageCode lang) => T(lang, "Aggiungi una", "Add one");
		public static string SheetEffectsTitle(LanguageCode lang) => T(lang, "Effetti a tempo", "Timed effects");
		public static string SheetEffectsHint(long now, LanguageCode lang) => T(lang, $"Sull'orologio della campagna: {ClockText(now, lang)}.", $"On the campaign clock: {ClockText(now, lang)}.");
		public static string SheetEffectEnd(LanguageCode lang) => T(lang, "Termina", "End");
		public static string SheetStoreChanged(LanguageCode lang) => T(lang, "Inventario e monete aggiornati dal tavolo (negozio, scorte o bottino).", "Inventory and coins updated from the table (shop, supplies or loot).");
		public static string VttClock(LanguageCode lang) => T(lang, "Tempo di gioco", "Game time");
	}
}
