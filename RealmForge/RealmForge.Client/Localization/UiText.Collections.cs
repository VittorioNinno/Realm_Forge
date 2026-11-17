using RealmForge.Shared.Enums;

namespace RealmForge.Client.Localization
{
	///	<summary>Texts of the collections of Homebrew: one link for many entries, switched on in a campaign as a block.</summary>
	public static partial class UiText
	{
		public static string CollectionsTitle(LanguageCode lang) => T(lang, "Raccolte", "Collections");
		public static string CollectionsHint(LanguageCode lang) => T(lang,
			"Riunisci più contenuti sotto un unico link: chi lo apre può aggiungerli tutti alla propria raccolta o attivarli in blocco in una campagna.",
			"Gather several entries under one link: whoever opens it can add them all to their collection or switch them on as a block in a campaign.");
		public static string CollectionsEmpty(LanguageCode lang) => T(lang, "Nessuna raccolta ancora.", "No collections yet.");
		public static string CollectionNewFromSelection(int count, LanguageCode lang) => T(lang, $"Nuova raccolta con la selezione ({count})", $"New collection from the selection ({count})");
		public static string CollectionSelectFirst(LanguageCode lang) => T(lang, "Seleziona i contenuti da riunire, poi crea la raccolta.", "Select the entries to gather, then create the collection.");
		public static string CollectionName(LanguageCode lang) => T(lang, "Nome della raccolta", "Collection name");
		public static string CollectionDescription(LanguageCode lang) => T(lang, "Descrizione", "Description");
		public static string CollectionEntries(int count, LanguageCode lang) => T(lang, $"{count} {(count == 1 ? "contenuto" : "contenuti")}", $"{count} {(count == 1 ? "entry" : "entries")}");
		public static string CollectionCopyLink(LanguageCode lang) => T(lang, "Copia link", "Copy link");
		public static string CollectionLinkCopied(LanguageCode lang) => T(lang, "Link copiato.", "Link copied.");
		public static string CollectionReplace(int count, LanguageCode lang) => T(lang, $"Sostituisci con la selezione ({count})", $"Replace with the selection ({count})");
		public static string CollectionBy(string author, LanguageCode lang) => T(lang, $"Raccolta di {author}", $"Collection by {author}");
		public static string CollectionNotFound(LanguageCode lang) => T(lang, "Raccolta non trovata: il link non è valido o è stata eliminata.", "Collection not found: the link is not valid or it was deleted.");
		public static string CollectionCollect(LanguageCode lang) => T(lang, "Aggiungi tutto alla mia raccolta", "Add all to my collection");
		public static string CollectionCollected(int count, LanguageCode lang) => T(lang, $"Aggiunti {count} contenuti alla tua raccolta.", $"{count} entries added to your collection.");
		public static string CollectionEnableIn(LanguageCode lang) => T(lang, "Attiva in una campagna", "Switch on in a campaign");
		public static string CollectionEnable(LanguageCode lang) => T(lang, "Attiva", "Switch on");
		public static string CollectionEnabled(string name, int added, int skipped, bool pending, LanguageCode lang) => T(lang,
			$"«{name}» attivata: {added} contenuti{(skipped > 0 ? $", {skipped} esclusi (altra edizione o limite)" : string.Empty)}{(pending ? ", in attesa dei master" : string.Empty)}.",
			$"“{name}” switched on: {added} entries{(skipped > 0 ? $", {skipped} left out (other edition or limit)" : string.Empty)}{(pending ? ", waiting for the masters" : string.Empty)}.");
		public static string CampaignCollectionsTitle(LanguageCode lang) => T(lang, "Raccolte attive", "Collections switched on");
		public static string CampaignCollectionsHint(LanguageCode lang) => T(lang, "Incolla il link di una raccolta di Homebrew per attivarne tutti i contenuti insieme; disattivandola li rimuovi in blocco.",
			"Paste the link of a Homebrew collection to switch all its entries on together; switching it off removes them as a block.");
		public static string CampaignCollectionCode(LanguageCode lang) => T(lang, "Link o codice della raccolta", "Collection link or code");
		public static string CampaignCollectionBy(string who, int count, LanguageCode lang) => T(lang, $"{CollectionEntries(count, lang)} · attivata da {who}", $"{CollectionEntries(count, lang)} · switched on by {who}");
		public static string CampaignCollectionOff(LanguageCode lang) => T(lang, "Disattiva", "Switch off");
		public static string CollectionFailed(string? reason, LanguageCode lang) => T(lang, $"Non è stato possibile{(reason is null ? "." : $": {reason}")}", $"That did not work{(reason is null ? "." : $": {reason}")}");
	}
}
