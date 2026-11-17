using RealmForge.Shared.Enums;

namespace RealmForge.Client.Localization
{
	///	<summary>Texts of the JSON files: characters and Homebrew exported and imported, the author's Homebrew page.</summary>
	public static partial class UiText
	{
		public static string BtnDownloadJson(LanguageCode lang) => T(lang, "Scarica il personaggio come file JSON (backup o un altro RealmForge)", "Download the character as a JSON file (a backup, or another RealmForge)");
		public static string BtnImport(LanguageCode lang) => T(lang, "Importa", "Import");
		public static string ImportCharacterHint(LanguageCode lang) => T(lang, "Un personaggio da un file JSON di RealmForge", "A character from a RealmForge JSON file");
		public static string ImportHomebrewHint(LanguageCode lang) => T(lang, "Homebrew da un file JSON di RealmForge: ogni voce diventa una tua voce privata", "Homebrew from a RealmForge JSON file: each entry becomes a private entry of yours");
		public static string TransferFailed(LanguageCode lang) => T(lang, "Non è stato possibile preparare il file.", "The file could not be made.");
		public static string TransferLoading(LanguageCode lang) => T(lang, "Caricamento...", "Loading...");
		public static string TransferSignIn(LanguageCode lang) => T(lang, "Accedi per vedere il tuo Homebrew.", "Sign in to see your Homebrew.");

		public static string ImportFailed(string? reason, string? title, LanguageCode lang) => reason switch
		{
			"format" => T(lang, "Il file non è un file JSON di RealmForge.", "The file is not a RealmForge JSON file."),
			"empty" => T(lang, "Il file non contiene niente da importare.", "The file has nothing to import."),
			"full" => T(lang, "Hai raggiunto il numero massimo di personaggi.", "You have reached the most characters."),
			"size" => T(lang, "Il file è vuoto o troppo grande.", "The file is empty or too big."),
			"rules" => T(lang, $"Il personaggio non segue le regole con i contenuti di questo RealmForge (manca un Homebrew?). {title}", $"The character does not follow the rules with the content of this RealmForge (a missing Homebrew?). {title}"),
			"network" => T(lang, "Connessione non riuscita: riprova.", "The connection failed: try again."),
			_ => T(lang, "Importazione non riuscita.", "The import failed.") + (string.IsNullOrEmpty(title) ? string.Empty : $" {title}")
		};

		public static string ImportMissing(string? missing, LanguageCode lang) => missing switch
		{
			"type" or "format" => T(lang, "voce non riconosciuta", "entry not recognised"),
			null => string.Empty,
			_ => T(lang, $"manca quello da cui dipende ({TrashKind(missing, lang)})", $"what it depends on is missing ({TrashKind(missing, lang)})")
		};

		public static string MyHomebrewTitle(LanguageCode lang) => T(lang, "Il mio Homebrew", "My Homebrew");
		public static string MyHomebrewSubtitle(LanguageCode lang) => T(lang, "Tutto ciò che hai creato, le lingue in cui è scritto, i file per salvarlo o portarlo altrove", "Everything you created, the languages it is written in, the files to keep it or take it elsewhere");
		public static string MyHomebrewEmpty(LanguageCode lang) => T(lang, "Non hai ancora creato Homebrew. Puoi importarne da un file.", "You have not created any Homebrew yet. You can import some from a file.");
		public static string MyHomebrewFilter(LanguageCode lang) => T(lang, "Mostra", "Show");
		public static string ToTranslate(LanguageCode language, LanguageCode lang) => language == LanguageCode.It
			? T(lang, "Da tradurre in IT", "To translate into IT")
			: T(lang, "Da tradurre in EN", "To translate into EN");
		public static string ClearSelection(LanguageCode lang) => T(lang, "Deseleziona", "Clear selection");
		public static string ExportSelected(int count, LanguageCode lang) => T(lang, $"Esporta {count} selezionati", $"Export {count} selected");
		public static string ExportAll(LanguageCode lang) => T(lang, "Esporta tutto", "Export everything");
		public static string Exported(int count, LanguageCode lang) => T(lang, count == 1 ? "1 voce esportata." : $"{count} voci esportate.", count == 1 ? "1 entry exported." : $"{count} entries exported.");
		public static string Imported(int done, int total, LanguageCode lang) => T(lang, $"Importate {done} voci su {total}: le trovi qui sotto, private.", $"{done} of {total} entries imported: they are below, private.");
		public static string ForkButton(LanguageCode lang) => T(lang, "Clona e personalizza", "Clone and customise");
		public static string ForkHint(LanguageCode lang) => T(lang, "Una copia privata da modificare per le tue campagne: ricorda da dove viene", "A private copy to change for your campaigns: it remembers where it comes from");
		public static string ForkBasedOn(LanguageCode lang) => T(lang, "Basato su", "Based on");
		public static string ForkFailed(string? missing, LanguageCode lang) => missing is { Length: > 0 } and not "network"
			? T(lang, $"Non è stato possibile clonarlo: manca {TrashKind(missing, lang)}.", $"It could not be cloned: the {TrashKind(missing, lang)} it needs is missing.")
			: T(lang, "Non è stato possibile clonarlo. Hai confermato la tua email?", "It could not be cloned. Have you confirmed your e-mail?");
		public static string NavHomebrew(LanguageCode lang) => T(lang, "Il mio Homebrew", "My Homebrew");
	}
}
