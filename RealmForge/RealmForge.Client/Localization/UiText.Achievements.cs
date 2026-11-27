using RealmForge.Shared.Enums;

namespace RealmForge.Client.Localization
{
	///	<summary>Texts of the achievements (each one unlocks a die).</summary>
	public static partial class UiText
	{
		public static string AchievementsTitle(LanguageCode lang) => T(lang, "Trofei", "Achievements");
		public static string AchievementsHint(LanguageCode lang) => T(lang,
			"Completa le missioni per sbloccare nuovi dadi. Alcune sono segrete: le scopri solo completandole.",
			"Complete the missions to unlock new dice. Some are secret: you find them only by completing them.");
		public static string AchievementsSecretLeft(LanguageCode lang) => T(lang, "Altri trofei segreti ti aspettano mentre giochi…", "More secret achievements await you as you play…");
		public static string AchievementsOf(int earned, int total, LanguageCode lang) => T(lang, $"{earned} / {total} ottenuti", $"{earned} / {total} earned");
		public static string AchievementsCompletion(LanguageCode lang) => T(lang, "Completamento", "Completion");
		public static string AchievementsFilterAll(LanguageCode lang) => T(lang, "Tutti", "All");
		public static string AchievementsFilterEarned(LanguageCode lang) => T(lang, "Ottenuti", "Earned");
		public static string AchievementsFilterLocked(LanguageCode lang) => T(lang, "Bloccati", "Locked");
		public static string AchievementsFilterHidden(LanguageCode lang) => T(lang, "Segreti nascosti", "Hidden secrets");
		public static string AchievementsNone(LanguageCode lang) => T(lang, "Nessun trofeo qui, per ora.", "No achievements here, for now.");
		public static string AchievementLocked(LanguageCode lang) => T(lang, "Bloccato", "Locked");
		public static string AchievementNotYet(LanguageCode lang) => T(lang, "Non ancora ottenuto", "Not earned yet");
		public static string AchievementSealedName(LanguageCode lang) => T(lang, "Trofeo segreto", "Secret achievement");
		public static string AchievementSealedGoal(LanguageCode lang) => T(lang, "Completa una missione nascosta per rivelare questo trofeo.", "Complete a hidden mission to reveal this achievement.");
		public static string AchievementSealedWhen(LanguageCode lang) => T(lang, "Scoprilo giocando", "Find it as you play");
		public static string AchievementSealedReward(LanguageCode lang) => T(lang, "Ricompensa sconosciuta", "Unknown reward");
		public static string AchievementEarnedOn(DateTimeOffset at, LanguageCode lang) => T(lang, $"Ottenuto il {at.ToLocalTime():dd/MM/yyyy}", $"Earned on {at.ToLocalTime():MMM d, yyyy}");
		public static string AchievementGiven(LanguageCode lang) => T(lang, "Assegnato", "Given");
		public static string AchievementRevoked(LanguageCode lang) => T(lang, "Revocato", "Revoked");
		public static string AchievementSecret(LanguageCode lang) => T(lang, "Segreto", "Secret");
		public static string AchievementUnlocks(string die, LanguageCode lang) => T(lang, $"Sblocca: {die}", $"Unlocks: {die}");
		public static string AchievementProgress(int progress, int target, LanguageCode lang) => $"{progress} / {target}";
		public static string AchievementNoticeTitle(string name, LanguageCode lang) => T(lang, $"Trofeo ottenuto: {name}", $"Achievement earned: {name}");
		public static string AchievementNoticeDie(string die, LanguageCode lang) => T(lang, $"Nuovo dado sbloccato: {die}", $"New die unlocked: {die}");
		public static string AchievementNoticeOpen(LanguageCode lang) => T(lang, "Vedi i trofei", "See the achievements");
		public static string AchievementNoticeClose(LanguageCode lang) => T(lang, "Chiudi", "Close");

		public static string AchievementName(string key, LanguageCode lang) => key switch
		{
			"ember" => T(lang, "Prima scintilla", "First spark"),
			"stardust" => T(lang, "Sotto una buona stella", "Under a lucky star"),
			"dawn" => T(lang, "Nuova alba", "A new dawn"),
			"frost" => T(lang, "Lungo inverno", "Long winter"),
			"storm" => T(lang, "Fulmine a ciel sereno", "Bolt from the blue"),
			"bone" => T(lang, "Il morto risponde", "The dead answer"),
			"hoard" => T(lang, "Il tesoro del drago", "The dragon's hoard"),
			"abyss" => T(lang, "Sguardo nell'abisso", "Gazing into the abyss"),
			"fey" => T(lang, "Radici profonde", "Deep roots"),
			"acid" => T(lang, "L'alchimista", "The alchemist"),
			"arcane" => T(lang, "Il custode delle rune", "Keeper of the runes"),
			"tide" => T(lang, "Marea di dadi", "A tide of dice"),
			"blood" => T(lang, "Figlio della notte", "Child of the night"),
			"gear" => T(lang, "Il cartografo", "The cartographer"),
			"sands" => T(lang, "Sabbie del tempo", "Sands of time"),
			_ => key
		};

		public static string AchievementGoal(string key, LanguageCode lang) => key switch
		{
			"ember" => T(lang, "Fai 100 tiri al tavolo.", "Make 100 rolls at the table."),
			"stardust" => T(lang, "Ottieni 5 venti naturali al tavolo.", "Roll 5 natural 20s at the table."),
			"dawn" => T(lang, "Partecipa alla tua prima sessione segnata come giocata.", "Take part in your first session marked as played."),
			"frost" => T(lang, "Partecipa a 10 sessioni giocate.", "Take part in 10 played sessions."),
			"storm" => T(lang, "Ottieni due venti naturali nella stessa sessione.", "Roll two natural 20s in the same session."),
			"bone" => T(lang, "Ottieni 13 uno naturali al tavolo.", "Roll 13 natural 1s at the table."),
			"hoard" => T(lang, "Un tuo personaggio possiede 1.000 monete d'oro.", "One of your characters owns 1,000 gold pieces."),
			"abyss" => T(lang, "Ottieni un 1 naturale seguito subito da un 20 naturale.", "Roll a natural 1 followed right away by a natural 20."),
			"fey" => T(lang, "Porta un personaggio al livello 5.", "Bring a character to level 5."),
			"acid" => T(lang, "Crea 5 contenuti Homebrew.", "Create 5 Homebrew entries."),
			"arcane" => T(lang, "Fai da master in 5 sessioni giocate.", "Run 5 played sessions as the master."),
			"tide" => T(lang, "Fai 1.000 tiri al tavolo.", "Make 1,000 rolls at the table."),
			"blood" => T(lang, "Ottieni un 20 naturale dopo la mezzanotte (tra le 00:00 e le 04:59).", "Roll a natural 20 after midnight (between 00:00 and 04:59)."),
			"gear" => T(lang, "Crea 3 mappe.", "Create 3 maps."),
			"sands" => T(lang, "Gioca sessioni in 6 mesi diversi.", "Play sessions in 6 different months."),
			_ => string.Empty
		};

		//	Administration
		public static string AdminAchievements(LanguageCode lang) => T(lang, "Trofei", "Achievements");
		public static string AdminAchievementsTitle(string who, LanguageCode lang) => T(lang, $"Trofei di {who}", $"Achievements of {who}");
		public static string AdminAchievementsHint(LanguageCode lang) => T(lang,
			"Assegna o revoca un trofeo: con il trofeo si sblocca (o si toglie) anche il suo dado. Un trofeo revocato non si ottiene più da solo finché non lo riassegni.",
			"Give or revoke an achievement: its die is unlocked (or taken away) with it. A revoked achievement is not earned again on its own until you give it back.");
		public static string BtnGrant(LanguageCode lang) => T(lang, "Assegna", "Give");
		public static string BtnRevoke(LanguageCode lang) => T(lang, "Revoca", "Revoke");
	}
}
