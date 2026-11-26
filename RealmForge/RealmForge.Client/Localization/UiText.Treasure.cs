using RealmForge.Shared.Enums;

namespace RealmForge.Client.Localization
{
	///	<summary>Texts of the party's chest.</summary>
	public static partial class UiText
	{
		public static string CampaignTabTreasure(LanguageCode lang) => T(lang, "Tesori", "Treasure");
		public static string TreasureHintMaster(LanguageCode lang) => T(lang,
			"Il forziere del gruppo: deposita monete, gemme e oggetti dopo uno scontro. Gli oggetti non identificati mostrano ai giocatori solo il loro aspetto finché qualcuno non li identifica; le monete si dividono in parti uguali tra i personaggi, con il resto in monete più piccole.",
			"The party's chest: put coins, gems and items in it after a fight. Unidentified items show the players only what they look like until someone identifies them; the coins are shared out evenly among the characters, the change in smaller coins.");
		public static string TreasureHintPlayer(LanguageCode lang) => T(lang,
			"Il forziere del gruppo: prendi gli oggetti per il tuo personaggio; identificali con un incantesimo o un riposo breve.",
			"The party's chest: take items for your character; identify them with a spell or a short rest.");
		public static string TreasureCoins(LanguageCode lang) => T(lang, "Monete nel forziere", "Coins in the chest");
		public static string TreasureSaveCoins(LanguageCode lang) => T(lang, "Salva monete", "Save coins");
		public static string TreasureSplit(LanguageCode lang) => T(lang, "Dividi monete", "Share the coins");
		public static string TreasureSplitAmong(LanguageCode lang) => T(lang, "Dividi tra", "Share among");
		public static string TreasureSplitDone(string each, string left, int count, LanguageCode lang) => T(lang,
			$"Diviso tra {count} personaggi: {each} a testa{(left.Length > 0 ? $"; restano {left}" : string.Empty)}.",
			$"Shared among {count} characters: {each} each{(left.Length > 0 ? $"; {left} left" : string.Empty)}.");
		public static string TreasureItems(LanguageCode lang) => T(lang, "Oggetti", "Items");
		public static string TreasureEmpty(LanguageCode lang) => T(lang, "Il forziere è vuoto.", "The chest is empty.");
		public static string TreasurePurseEmpty(LanguageCode lang) => T(lang, "Borsa vuota", "Empty purse");
		public static string TreasureEach(string purse, LanguageCode lang) => T(lang, $"{purse} a testa", $"{purse} each");
		public static string TreasureItemCount(int count, LanguageCode lang) => T(lang, count == 1 ? "1 oggetto" : $"{count} oggetti", count == 1 ? "1 item" : $"{count} items");
		public static string TreasureAddSearch(LanguageCode lang) => T(lang, "Aggiungi dal compendio (equipaggiamento, oggetti magici)…", "Add from the compendium (equipment, magic items)…");
		public static string TreasureAddFree(LanguageCode lang) => T(lang, "Oggetto libero o gemma", "Free item or gem");
		public static string TreasureName(LanguageCode lang) => T(lang, "Nome", "Name");
		public static string TreasureAppearance(LanguageCode lang) => T(lang, "Aspetto (ciò che vedono i giocatori)", "Appearance (what the players see)");
		public static string TreasureValueGp(LanguageCode lang) => T(lang, "Valore (mo)", "Value (GP)");
		public static string TreasureQuantity(LanguageCode lang) => T(lang, "Quantità", "Quantity");
		public static string TreasureUnidentified(LanguageCode lang) => T(lang, "Non identificato", "Unidentified");
		public static string TreasureAddUnidentified(LanguageCode lang) => T(lang, "Da identificare", "To be identified");
		public static string TreasureUnknownName(LanguageCode lang) => T(lang, "Oggetto sconosciuto", "Unknown item");
		public static string TreasureIdentify(LanguageCode lang) => T(lang, "Identifica", "Identify");
		public static string TreasureTrueName(string name, LanguageCode lang) => T(lang, $"in realtà: {name}", $"truly: {name}");
		public static string TreasureGive(LanguageCode lang) => T(lang, "Dai a", "Give to");
		public static string TreasureTake(LanguageCode lang) => T(lang, "Prendi", "Take");
		public static string TreasurePlace(LanguageCode lang) => T(lang, "Sul tavolo", "On the table");
		public static string TreasurePlaceHint(LanguageCode lang) => T(lang, "Mettilo su un segnalino della mappa: un forziere, una creatura che lo porta", "Put it on a token of the map: a chest, a creature that carries it");
		public static string TreasurePlaceOn(LanguageCode lang) => T(lang, "Su", "On");
		public static string TreasurePlaced(string item, string token, LanguageCode lang) => T(lang, $"{item} è su {token}: lo prende chi lo apre o lo perquisisce.", $"{item} is on {token}: whoever opens or loots it takes it.");
		public static string TreasureGiven(string item, string character, LanguageCode lang) => T(lang, $"{item} è nell'inventario di {character}.", $"{item} is in {character}'s inventory.");
		public static string TreasureNoCharacters(LanguageCode lang) => T(lang, "Nessun personaggio al tavolo.", "No characters at the table.");
		public static string TreasureFailed(LanguageCode lang) => T(lang, "Non è stato possibile.", "That did not work.");
		public static string TreasureInactive(LanguageCode lang) => T(lang, "inattivo", "inactive");
	}
}
