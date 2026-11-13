using RealmForge.Shared.Campaigns;
using RealmForge.Shared.Enums;

namespace RealmForge.Client.Localization
{
	///	<summary>
	///	Texts of the sessions of a campaign and of its shared dice log.
	///	</summary>
	public static partial class UiText
	{
		// ===== Sessions =====
		public static string CampaignTabSessions(LanguageCode lang) => T(lang, "Sessioni", "Sessions");
		public static string SessionsHint(bool manage, LanguageCode lang) => manage
			? T(lang, "Fissa la data, scrivi cosa devono sapere i giocatori e, dopo la serata, il riassunto. Le note del master restano dietro lo schermo.",
				"Set the date, write what the players should know and, after the game, the recap. The GM notes stay behind the screen.")
			: T(lang, "Le date, il programma e i riassunti delle serate, scritti dai master.", "Dates, plans and recaps of the games, written by the GMs.");
		public static string BtnNewSession(LanguageCode lang) => T(lang, "Nuova sessione", "New session");
		public static string SessionsEmpty(LanguageCode lang) => T(lang, "Ancora nessuna sessione.", "No sessions yet.");
		public static string SessionNumber(int number, LanguageCode lang) => T(lang, $"Sessione {number}", $"Session {number}");
		public static string SessionTitle(LanguageCode lang) => T(lang, "Titolo (facoltativo)", "Title (optional)");
		public static string SessionWhen(LanguageCode lang) => T(lang, "Data e ora", "Date and time");
		public static string SessionNoDate(LanguageCode lang) => T(lang, "data da decidere", "date to be set");
		public static string SessionStatusLabel(LanguageCode lang) => T(lang, "Stato", "Status");
		public static string SessionStatusName(CampaignSessionStatus status, LanguageCode lang) => status switch
		{
			CampaignSessionStatus.Played => T(lang, "Giocata", "Played"),
			CampaignSessionStatus.Cancelled => T(lang, "Annullata", "Cancelled"),
			_ => T(lang, "In programma", "Planned")
		};
		public static string SessionPlan(LanguageCode lang) => T(lang, "Programma per i giocatori", "Plan for the players");
		public static string SessionPlanHint(LanguageCode lang) => T(lang, "Cosa portare, dove si gioca, a che punto riprende la storia…", "What to bring, where you play, where the story picks up…");
		public static string SessionRecap(LanguageCode lang) => T(lang, "Riassunto", "Recap");
		public static string SessionRecapHint(LanguageCode lang) => T(lang, "Cosa è successo: lo leggono tutti.", "What happened: everyone reads it.");
		public static string SessionMasterNotes(LanguageCode lang) => T(lang, "Note del master", "GM notes");
		public static string SessionMasterNotesHint(LanguageCode lang) => T(lang, "Solo per master e co-master.", "Masters and co-masters only.");
		public static string SessionNext(LanguageCode lang) => T(lang, "Prossima sessione", "Next session");
		public static string SessionUpdatedBy(string name, DateTimeOffset at, LanguageCode lang) => T(lang, $"Aggiornata da {name} il {FormatDate(at.ToLocalTime(), lang)}",
			$"Updated by {name} on {FormatDate(at.ToLocalTime(), lang)}");
		public static string SessionDeleteConfirm(LanguageCode lang) => T(lang, "Rimuovere la sessione? Il riassunto e le note andranno persi.", "Remove the session? Its recap and notes will be lost.");

		//	"sabato 14 novembre 2026, 21:00": days by hand, like the months
		private static readonly string[] DaysIt = ["domenica", "lunedì", "martedì", "mercoledì", "giovedì", "venerdì", "sabato"];
		private static readonly string[] DaysEn = ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"];

		public static string FormatDateTime(DateTimeOffset utc, LanguageCode lang)
		{
			var local = utc.ToLocalTime();
			var day = lang == LanguageCode.It ? DaysIt[(int)local.DayOfWeek] : DaysEn[(int)local.DayOfWeek];
			return $"{day} {FormatDate(local, lang)}, {local.ToString("HH':'mm", System.Globalization.CultureInfo.InvariantCulture)}";
		}

		public static string SessionCountdown(DateTimeOffset utc, LanguageCode lang)
		{
			var days = (utc.ToLocalTime().Date - DateTimeOffset.Now.Date).Days;
			return days switch
			{
				< 0 => string.Empty,
				0 => T(lang, "oggi", "today"),
				1 => T(lang, "domani", "tomorrow"),
				_ => T(lang, $"tra {days} giorni", $"in {days} days")
			};
		}

		// ===== Dice log =====
		public static string CampaignTabRolls(LanguageCode lang) => T(lang, "Tiri", "Rolls");
		public static string RollsHint(LanguageCode lang) => T(lang,
			"Il tavolo dei dadi condiviso: qui compaiono i tiri di tutti, anche quelli fatti dalle schede dei personaggi della campagna.",
			"The shared dice table: everyone's rolls show here, including the ones made on the sheets of the campaign's characters.");
		public static string RollExpression(LanguageCode lang) => T(lang, "Dadi (es. 1d20+5, 2d6+3, 2d20kh1)", "Dice (e.g. 1d20+5, 2d6+3, 2d20kh1)");
		public static string RollLabel(LanguageCode lang) => T(lang, "Per cosa (facoltativo)", "What for (optional)");
		public static string RollAs(LanguageCode lang) => T(lang, "Tira come", "Roll as");
		public static string RollAsMe(LanguageCode lang) => T(lang, "Me stesso", "Myself");
		public static string RollDeletedAccount(LanguageCode lang) => T(lang, "Account eliminato", "Deleted account");
		public static string RollMyColor(LanguageCode lang) => T(lang, "Il tuo colore in questa campagna", "Your colour in this campaign");
		public static string BtnRoll(LanguageCode lang) => T(lang, "Tira", "Roll");
		public static string RollHidden(LanguageCode lang) => T(lang, "Dietro lo schermo", "Behind the screen");
		public static string RollHiddenBadge(LanguageCode lang) => T(lang, "nascosto", "hidden");
		public static string RollInvalid(LanguageCode lang) => T(lang, "Espressione non valida: usa ad esempio 1d20+5 o 2d6 + 1d4.", "Invalid expression: try for example 1d20+5 or 2d6 + 1d4.");
		public static string RollsEmpty(LanguageCode lang) => T(lang, "Ancora nessun tiro.", "No rolls yet.");
		public static string BtnClearRolls(LanguageCode lang) => T(lang, "Svuota il registro", "Clear the log");
		public static string RollsClearConfirm(LanguageCode lang) => T(lang, "Svuotare il registro dei tiri per tutti?", "Clear the dice log for everyone?");
		public static string RollTime(DateTimeOffset at, LanguageCode lang)
		{
			var local = at.ToLocalTime();
			return local.Date == DateTimeOffset.Now.Date ? $"{local.ToString("HH':'mm", System.Globalization.CultureInfo.InvariantCulture)}" : $"{FormatDate(local, lang)} {local.ToString("HH':'mm", System.Globalization.CultureInfo.InvariantCulture)}";
		}
		public static string DiceConsole(LanguageCode lang) => T(lang, "Console di lancio", "Roller");
		public static string DiceHiddenShort(LanguageCode lang) => T(lang, "Nascosto", "Hidden");
		public static string DiceResetShort(LanguageCode lang) => T(lang, "Azzera", "Reset");
		public static string DiceSynced(LanguageCode lang) => T(lang, "Sincronizzato in tempo reale", "Synced in real time");
		public static string BtnClearAll(LanguageCode lang) => T(lang, "Svuota tutto", "Clear all");
		public static string CardMinimize(LanguageCode lang) => T(lang, "Riduci", "Minimize");
		public static string CardExpand(LanguageCode lang) => T(lang, "Espandi", "Expand");
		public static string DiceReset(LanguageCode lang) => T(lang, "Azzera selezione", "Clear selection");
		public static string DiceVisibility(LanguageCode lang) => T(lang, "Visibilità del tiro", "Roll visibility");
		public static string DicePublic(LanguageCode lang) => T(lang, "Pubblico", "Public");
		public static string DicePick(LanguageCode lang) => T(lang, "Seleziona i dadi", "Pick the dice");
		public static string DicePickHint(LanguageCode lang) => T(lang, "Clic per aggiungere un dado, clic destro per toglierlo", "Click to add a die, right click to remove one");
		public static string DiceModifier(LanguageCode lang) => T(lang, "Modificatore", "Modifier");
		public static string DiceModifierShort(LanguageCode lang) => T(lang, "Mod", "Mod");
		public static string DiceMode(LanguageCode lang) => T(lang, "Modalità del d20", "d20 mode");
		public static string DiceFormula(LanguageCode lang) => T(lang, "Formula (modificabile)", "Formula (editable)");
		public static string DiceReasonHint(LanguageCode lang) => T(lang, "Es. Percezione, Iniziativa, Tiro salvezza…", "E.g. Perception, Initiative, Saving throw…");
		public static string[] DiceQuickReasons(LanguageCode lang) => lang == LanguageCode.It
			? new[] { "Iniziativa", "Percezione", "Tiro salvezza", "Attacco", "Danni" }
			: new[] { "Initiative", "Perception", "Saving throw", "Attack", "Damage" };
		public static string DiceRollButton(string expression, bool hidden, LanguageCode lang) =>
			T(lang, $"Lancia {expression}", $"Roll {expression}") + (hidden ? T(lang, " (nascosto)", " (hidden)") : string.Empty);
		public static string DiceLogTitle(LanguageCode lang) => T(lang, "Cronologia dei tiri al tavolo", "Rolls at the table");
		public static string DiceFilterAll(int count, LanguageCode lang) => T(lang, $"Tutti ({count})", $"All ({count})");
		public static string DiceFilterPlayers(LanguageCode lang) => T(lang, "Giocatori", "Players");
		public static string DiceFilterMaster(LanguageCode lang) => T(lang, "Master", "Master");
		public static string DiceFilterHidden(int count, LanguageCode lang) => T(lang, $"Solo nascosti ({count})", $"Hidden only ({count})");
		public static string DiceHiddenBadge(LanguageCode lang) => T(lang, "Nascosto dietro lo schermo", "Hidden behind the screen");
		public static string DiceNatural20(LanguageCode lang) => T(lang, "20 naturale", "Natural 20");
		public static string DiceNatural1(LanguageCode lang) => T(lang, "1 naturale", "Natural 1");
		public static string DiceReveal(LanguageCode lang) => T(lang, "Rivela al tavolo", "Show to the table");
		public static string DiceReroll(LanguageCode lang) => T(lang, "Ritira", "Roll again");
		public static string SheetRollShared(LanguageCode lang) => T(lang, "Condiviso con la campagna", "Shared with the campaign");
	}
}
