using RealmForge.Shared.DTOs;
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
		public static string SearchPlaceholder(LanguageCode lang) => T(lang, "Cerca nel compendio (es. Palla di Fuoco, Fireball, Goblin, Guaritore)…",
			"Search the compendium (e.g. Fireball, Palla di Fuoco, Goblin, Healer)…");
		public static string SearchRandom(LanguageCode lang) => T(lang, "Voce casuale", "Random entry");
		public static string SearchRandomHint(LanguageCode lang) => T(lang, "Apri una voce a caso del compendio (della categoria scelta)", "Open a random entry of the compendium (of the chosen kind)");
		public static string SearchSlashHint(LanguageCode lang) => T(lang, "Premi / da qualsiasi punto della pagina per cercare", "Press / anywhere on the page to search");
		public static string SearchChipName(string key, LanguageCode lang) => (key, lang == LanguageCode.It) switch
		{
			("spell", true) => "Incantesimi", ("spell", false) => "Spells",
			("monster", true) => "Mostri", ("monster", false) => "Monsters",
			("item", true) => "Oggetti", ("item", false) => "Items",
			("class", true) => "Classi", ("class", false) => "Classes",
			("species", true) => "Specie", ("species", false) => "Species",
			("feat", true) => "Talenti", ("feat", false) => "Feats",
			("background", _) => "Background",
			("rule", true) => "Regole", ("rule", false) => "Rules",
			_ => key
		};
		public static string SearchExplore(LanguageCode lang) => T(lang, "Esplora il compendio", "Explore the compendium");
		public static string SearchEdition(LanguageCode lang) => T(lang, "Edizione", "Edition");
		public static string SearchCategoryName(string kind, LanguageCode lang) => (kind, lang == LanguageCode.It) switch
		{
			("spell", true) => "Incantesimi", ("spell", false) => "Spells",
			("monster", true) => "Mostri e PNG", ("monster", false) => "Monsters and NPCs",
			("equipment", true) => "Equipaggiamento e oggetti", ("equipment", false) => "Equipment and items",
			("class", true) => "Classi e sottoclassi", ("class", false) => "Classes and subclasses",
			("species", true) => "Specie e lignaggi", ("species", false) => "Species and lineages",
			("feat", true) => "Talenti", ("feat", false) => "Feats",
			("background", _) => "Background",
			("rule", true) => "Glossario regole", ("rule", false) => "Rules glossary",
			_ => kind
		};
		public static string SearchCategoryText(string kind, LanguageCode lang) => (kind, lang == LanguageCode.It) switch
		{
			("spell", true) => "Trucchetti e incantesimi fino al 9° livello per tutte le classi.",
			("spell", false) => "Cantrips and spells up to 9th level for every class.",
			("monster", true) => "Statistiche complete, grado di sfida, tratti e azioni leggendarie.",
			("monster", false) => "Full stat blocks, challenge rating, traits and legendary actions.",
			("equipment", true) => "Armi, armature, strumenti, dotazioni e oggetti magici.",
			("equipment", false) => "Weapons, armor, tools, packs and magic items.",
			("class", true) => "Progressioni dal 1° al 20° livello, privilegi e tabelle di classe.",
			("class", false) => "Progressions from 1st to 20th level, features and class tables.",
			("species", true) => "Tratti ancestrali, taglie, velocità e capacità innate.",
			("species", false) => "Ancestral traits, sizes, speeds and innate abilities.",
			("feat", true) => "Talenti di origine, generali, stili di combattimento e doni epici.",
			("feat", false) => "Origin and general feats, fighting styles and epic boons.",
			("background", true) => "Incrementi di caratteristica, competenze, talento di origine ed equipaggiamento.",
			("background", false) => "Ability increases, proficiencies, origin feat and equipment.",
			("rule", true) => "Definizioni per combattimento, magia, esplorazione e condizioni.",
			("rule", false) => "Definitions for combat, magic, exploration and conditions.",
			_ => string.Empty
		};
		public static string SearchCategoryFilters(string kind, LanguageCode lang) => (kind, lang == LanguageCode.It) switch
		{
			("spell", true) => "Filtra per: livello • scuola • classe", ("spell", false) => "Filter by: level • school • class",
			("monster", true) => "Filtra per: GS • tipo • taglia", ("monster", false) => "Filter by: CR • type • size",
			("equipment", true) => "Filtra per: categoria • maestria • rarità", ("equipment", false) => "Filter by: category • mastery • rarity",
			("class", true) => "Mago • Chierico • Guerriero • Druido…", ("class", false) => "Wizard • Cleric • Fighter • Druid…",
			("species", true) => "Elfo • Nano • Tiefling • Umano…", ("species", false) => "Elf • Dwarf • Tiefling • Human…",
			("feat", true) => "Filtra per: categoria • prerequisito", ("feat", false) => "Filter by: category • prerequisite",
			("background", true) => "Accolito • Criminale • Sapiente…", ("background", false) => "Acolyte • Criminal • Sage…",
			("rule", true) => "Azioni • Condizioni • Copertura • Riposi", ("rule", false) => "Actions • Conditions • Cover • Rests",
			_ => string.Empty
		};
		public static string SearchQuickTitle(LanguageCode lang) => T(lang, "Consultazione rapida al tavolo", "Quick reference at the table");
		public static string SearchQuickMeta(LanguageCode lang) => T(lang, "Condizioni e regole", "Conditions and rules");
		public static string SearchRecentTitle(LanguageCode lang) => T(lang, "Visti di recente", "Recently viewed");
		public static string SearchRecentClear(LanguageCode lang) => T(lang, "Pulisci", "Clear");
		public static string SearchRecentEmpty(LanguageCode lang) => T(lang, "Le voci che apri da qui compaiono in questa lista (solo su questo browser).",
			"The entries you open from here show in this list (in this browser only).");

		//	"1° livello · Invocazione", "GS 1/4 · Umanoide", "Raro", "Arma", "Talento generale", "Condizione"
		public static string SearchDetail(SearchResultDto hit, LanguageCode lang)
		{
			if (hit.Detail is not { } d)
			{
				return string.Empty;
			}
			var parts = new List<string>();
			if (d.SpellLevel is { } level)
			{
				parts.Add(level == 0 ? T(lang, "Trucchetto", "Cantrip") : T(lang, $"{level}° livello", $"Level {level}"));
			}
			if (d.School is { } school)
			{
				parts.Add(Shared.Localization.GameTerms.SchoolName(school, lang));
			}
			if (d.Challenge is { } cr)
			{
				parts.Add(T(lang, "GS ", "CR ") + Shared.Monsters.MonsterMath.FormatChallenge(cr));
			}
			if (d.Creature is { } creature)
			{
				parts.Add(FormatCreatureType(creature, lang));
			}
			if (d.Rarity is { } rarity)
			{
				parts.Add(RarityName(rarity, lang));
			}
			if (d.Equipment is { } category)
			{
				parts.Add(Shared.Localization.EquipmentTerms.CategoryName(category, lang));
			}
			if (d.Feat is { } feat)
			{
				parts.Add(FormatFeatCategory(feat, lang));
			}
			if (d.Rule is { } rule)
			{
				parts.Add(RuleCategoryName(rule, lang));
			}
			return string.Join(" · ", parts);
		}

		public static string SearchRecentDetail(SearchResultDto hit, LanguageCode lang) =>
			SearchDetail(hit, lang) is { Length: > 0 } detail ? detail : (hit.OtherName ?? string.Empty);
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
