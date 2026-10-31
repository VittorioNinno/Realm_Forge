using RealmForge.Shared.Enums;
using RealmForge.Shared.Trash;

namespace RealmForge.Client.Localization
{
	///	<summary>
	///	Texts of the bin: what was deleted in the last days, restored or deleted for good.
	///	</summary>
	public static partial class UiText
	{
		public static string TrashTitle(LanguageCode lang) => T(lang, "Cestino", "Bin");
		public static string TrashSubtitle(LanguageCode lang) => T(lang,
			$"Quello che elimini resta qui per {TrashRules.RetentionDays} giorni: puoi ripristinarlo o eliminarlo subito per sempre",
			$"What you delete stays here for {TrashRules.RetentionDays} days: restore it, or delete it for good right away");
		public static string TrashEmpty(LanguageCode lang) => T(lang, "Il cestino è vuoto.", "The bin is empty.");
		public static string TrashLoading(LanguageCode lang) => T(lang, "Caricamento del cestino...", "Loading the bin...");
		public static string BtnRestore(LanguageCode lang) => T(lang, "Ripristina", "Restore");
		public static string BtnDeleteForever(LanguageCode lang) => T(lang, "Elimina per sempre", "Delete for good");
		public static string BtnOpenTrash(LanguageCode lang) => T(lang, "Apri il cestino", "Open the bin");
		public static string BtnOpenRestored(LanguageCode lang) => T(lang, "Apri", "Open");
		public static string AccountTrashHint(LanguageCode lang) => T(lang,
			$"Personaggi, campagne e contenuti Homebrew eliminati restano recuperabili per {TrashRules.RetentionDays} giorni.",
			$"Deleted characters, campaigns and Homebrew content can be restored for {TrashRules.RetentionDays} days.");
		public static string TrashDeletedOn(DateTimeOffset when, LanguageCode lang) => T(lang,
			$"Eliminato il {when.ToLocalTime():dd/MM/yyyy} alle {when.ToLocalTime():HH:mm}",
			$"Deleted on {when.ToLocalTime():yyyy-MM-dd} at {when.ToLocalTime():HH:mm}");

		//	Time left before the entry is gone: hours under a day, days above
		public static string TrashExpiresIn(DateTimeOffset expires, LanguageCode lang)
		{
			var left = expires - DateTimeOffset.UtcNow;
			if (left.TotalHours < 1)
			{
				return T(lang, "si elimina tra meno di un'ora", "gone in less than an hour");
			}
			if (left.TotalHours < 24)
			{
				var hours = (int)Math.Floor(left.TotalHours);
				return T(lang, hours == 1 ? "si elimina tra 1 ora" : $"si elimina tra {hours} ore", hours == 1 ? "gone in 1 hour" : $"gone in {hours} hours");
			}
			var days = (int)Math.Ceiling(left.TotalDays);
			return T(lang, days == 1 ? "si elimina tra 1 giorno" : $"si elimina tra {days} giorni", days == 1 ? "gone in 1 day" : $"gone in {days} days");
		}

		public static string TrashKind(string kind, LanguageCode lang) => (kind, lang == LanguageCode.It) switch
		{
			("character", true) => "Personaggio",
			("campaign", true) => "Campagna",
			("species", true) => "Specie",
			("subspecies", true) => "Sottospecie",
			("class", true) => "Classe",
			("subclass", true) => "Sottoclasse",
			("background", true) => "Background",
			("feat", true) => "Talento",
			("spell", true) => "Incantesimo",
			("equipment", true) => "Equipaggiamento",
			("monster", true) => "Mostro",
			("magic-item", true) => "Oggetto magico",
			("character", false) => "Character",
			("campaign", false) => "Campaign",
			("species", false) => "Species",
			("subspecies", false) => "Subspecies",
			("class", false) => "Class",
			("subclass", false) => "Subclass",
			("background", false) => "Background",
			("feat", false) => "Feat",
			("spell", false) => "Spell",
			("equipment", false) => "Equipment",
			("monster", false) => "Monster",
			("magic-item", false) => "Magic item",
			_ => kind
		};

		public static string TrashRestored(string name, LanguageCode lang) => T(lang, $"«{name}» è stato ripristinato.", $"“{name}” was restored.");
		public static string TrashRestoreMissing(string? kind, LanguageCode lang) => kind is null
			? T(lang, "Non si può ripristinare: esiste già oppure dipende da qualcosa che non c'è più.", "It cannot be restored: it already exists or depends on something that is gone.")
			: T(lang, $"Non si può ripristinare: dipende da un elemento ({TrashKind(kind, lang).ToLowerInvariant()}) che non esiste più. Se è nel cestino, ripristina prima quello.",
				$"It cannot be restored: it depends on an entry ({TrashKind(kind, lang).ToLowerInvariant()}) that is gone. If it is in the bin, restore that first.");
		public static string TrashActionFailed(LanguageCode lang) => T(lang, "Qualcosa è andato storto. Riprova.", "Something went wrong. Try again.");
	}
}
