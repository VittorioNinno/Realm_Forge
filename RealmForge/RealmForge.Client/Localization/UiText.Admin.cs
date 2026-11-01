using RealmForge.Shared.Enums;

namespace RealmForge.Client.Localization
{
	///	<summary>
	///	Texts of the global search and of the administration page.
	///	</summary>
	public static partial class UiText
	{
		// ===== Global search =====
		public static string SearchTitle(LanguageCode lang) => T(lang, "Cerca", "Search");
		public static string SearchPlaceholder(LanguageCode lang) => T(lang, "Cerca nel compendio…", "Search the compendium…");
		public static string SearchHint(LanguageCode lang) => T(lang,
			"Incantesimi, mostri, oggetti, classi, specie, talenti e regole, in italiano o in inglese.",
			"Spells, monsters, items, classes, species, feats and rules, in Italian or English.");
		public static string SearchTooShort(LanguageCode lang) => T(lang, "Scrivi almeno 2 caratteri.", "Type at least 2 characters.");
		public static string SearchNone(string text, LanguageCode lang) => T(lang, $"Nessun risultato per «{text}».", $"No results for “{text}”.");
		public static string SearchCount(int count, LanguageCode lang) => count switch
		{
			1 => T(lang, "1 risultato", "1 result"),
			_ => T(lang, $"{count} risultati", $"{count} results")
		};
		public static string SearchKindName(string kind, LanguageCode lang) => kind == "rule" ? T(lang, "Regola", "Rule") : CampaignKindName(kind, lang);
		public static string SearchMine(LanguageCode lang) => T(lang, "tuo", "yours");

		// ===== Administration =====
		public static string AdminTitle(LanguageCode lang) => T(lang, "Amministrazione", "Administration");
		public static string AdminSubtitle(LanguageCode lang) => T(lang, "Account, contenuti Homebrew e numeri del sito", "Accounts, Homebrew content and site figures");
		public static string AdminDenied(LanguageCode lang) => T(lang, "Questa pagina è riservata agli amministratori.", "This page is for administrators only.");
		public static string BtnAdmin(LanguageCode lang) => T(lang, "Apri l'amministrazione", "Open the administration");
		public static string AdminTabUsers(LanguageCode lang) => T(lang, "Account", "Accounts");
		public static string AdminTabHomebrew(LanguageCode lang) => T(lang, "Homebrew", "Homebrew");
		public static string AdminStatUsers(LanguageCode lang) => T(lang, "account", "accounts");
		public static string AdminStatConfirmed(LanguageCode lang) => T(lang, "email verificate", "verified e-mails");
		public static string AdminStatLocked(LanguageCode lang) => T(lang, "sospesi", "suspended");
		public static string AdminStatCharacters(LanguageCode lang) => T(lang, "personaggi", "characters");
		public static string AdminStatCampaigns(LanguageCode lang) => T(lang, "campagne", "campaigns");
		public static string AdminStatHomebrew(LanguageCode lang) => T(lang, "Homebrew", "Homebrew");
		public static string AdminStatPublic(LanguageCode lang) => T(lang, "pubblici", "public");
		public static string AdminUserSearch(LanguageCode lang) => T(lang, "Cerca per email o nickname", "Search by e-mail or nickname");
		public static string AdminUserOwns(int characters, int homebrew, int campaigns, LanguageCode lang) => T(lang,
			$"{characters} personaggi · {homebrew} Homebrew · {campaigns} campagne", $"{characters} characters · {homebrew} Homebrew · {campaigns} campaigns");
		public static string AdminRegistered(DateTimeOffset at, LanguageCode lang) => T(lang, $"dal {FormatDate(at.ToLocalTime(), lang)}", $"since {FormatDate(at.ToLocalTime(), lang)}");
		public static string AdminUnverified(LanguageCode lang) => T(lang, "email da verificare", "e-mail not verified");
		public static string AdminLockedUntil(DateTimeOffset until, LanguageCode lang) => until > DateTimeOffset.UtcNow.AddYears(5)
			? T(lang, "sospeso", "suspended")
			: T(lang, $"sospeso fino al {FormatDate(until.ToLocalTime(), lang)}", $"suspended until {FormatDate(until.ToLocalTime(), lang)}");
		public static string AdminBadge(LanguageCode lang) => T(lang, "admin", "admin");
		public static string AdminYou(LanguageCode lang) => T(lang, "tu", "you");
		public static string BtnSuspend(LanguageCode lang) => T(lang, "Sospendi", "Suspend");
		public static string BtnReactivate(LanguageCode lang) => T(lang, "Riattiva", "Reactivate");
		public static string AdminSuspendTitle(string who, LanguageCode lang) => T(lang, $"Sospendere {who}?", $"Suspend {who}?");
		public static string AdminSuspendHint(LanguageCode lang) => T(lang,
			"L'account non potrà accedere per il periodo scelto; le sessioni aperte scadono entro un'ora. I suoi contenuti restano.",
			"The account cannot sign in for the chosen period; open sessions expire within an hour. Its content stays.");
		public static string AdminSuspendDays(int days, LanguageCode lang) => days switch
		{
			>= 3650 => T(lang, "Fino a riattivazione", "Until reactivated"),
			1 => T(lang, "1 giorno", "1 day"),
			_ => T(lang, $"{days} giorni", $"{days} days")
		};
		public static string AdminDeleteTitle(string who, LanguageCode lang) => T(lang, $"Eliminare l'account {who}?", $"Delete the account {who}?");
		public static string AdminDeleteHint(LanguageCode lang) => T(lang,
			"Come quando la persona elimina il proprio account: personaggi e dati personali vengono eliminati, l'Homebrew usato da altri resta senza autore, le campagne passano a un altro membro. Non si può annullare.",
			"As when the person deletes their own account: characters and personal data are deleted, Homebrew used by others stays without an author, campaigns pass to another member. It cannot be undone.");
		public static string AdminHomebrewFilterAll(LanguageCode lang) => T(lang, "Tutti", "All");
		public static string AdminHomebrewEmpty(LanguageCode lang) => T(lang, "Nessun contenuto.", "No content.");
		public static string AdminHomebrewBy(string author, LanguageCode lang) => string.IsNullOrEmpty(author) ? T(lang, "senza autore", "no author") : T(lang, $"di {author}", $"by {author}");
		public static string AdminHomebrewShared(int people, int campaigns, LanguageCode lang) => T(lang,
			$"condiviso con {people} persone e {campaigns} campagne", $"shared with {people} people and {campaigns} campaigns");
		public static string AdminHomebrewHint(LanguageCode lang) => T(lang,
			"Rendere privato un contenuto lo toglie dagli elenchi pubblici senza eliminarlo; per modificarlo o eliminarlo aprilo: gli amministratori possono farlo su qualsiasi contenuto.",
			"Making an entry private takes it out of the public lists without deleting it; open it to edit or delete it: administrators can do it on any entry.");
		public static string AdminActionFailed(System.Net.HttpStatusCode? status, LanguageCode lang) => status switch
		{
			System.Net.HttpStatusCode.Forbidden => AdminDenied(lang),
			System.Net.HttpStatusCode.BadRequest => T(lang, "Operazione non consentita su questo account.", "Not allowed on this account."),
			System.Net.HttpStatusCode.NotFound => T(lang, "Non trovato: forse è già stato eliminato.", "Not found: maybe it was already deleted."),
			_ => T(lang, "Operazione non riuscita, riprova.", "It did not work, try again.")
		};
	}
}
