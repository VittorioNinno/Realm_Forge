using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;

namespace RealmForge.Client.Localization
{
	///	<summary>Texts of the shops: merchants the masters stock and the players buy from.</summary>
	public static partial class UiText
	{
		public static string CampaignTabShops(LanguageCode lang) => T(lang, "Negozi", "Shops");
		public static string ShopsHintMaster(LanguageCode lang) => T(lang,
			"Prepara mercanti con oggetti del compendio o tuoi e un moltiplicatore di prezzo; aprili quando i personaggi entrano: i giocatori comprano, le monete escono dalla borsa e l'oggetto finisce nell'inventario.",
			"Prepare merchants with items of the compendium or your own and a price multiplier; open them when the characters walk in: the players buy, the coins leave the purse and the item lands in the inventory.");
		public static string ShopsHintPlayer(LanguageCode lang) => T(lang, "I negozi aperti dal master: scegli il personaggio e compra.", "The shops the master opened: pick the character and buy.");
		public static string ShopsEmptyMaster(LanguageCode lang) => T(lang, "Nessun negozio ancora.", "No shops yet.");
		public static string ShopsEmptyPlayer(LanguageCode lang) => T(lang, "Nessun negozio aperto in questo momento.", "No shop is open right now.");
		public static string ShopNew(LanguageCode lang) => T(lang, "Nuovo negozio", "New shop");
		public static string ShopName(LanguageCode lang) => T(lang, "Nome", "Name");
		public static string ShopDescription(LanguageCode lang) => T(lang, "Descrizione", "Description");
		public static string ShopPercent(LanguageCode lang) => T(lang, "Prezzi (% del listino)", "Prices (% of the list price)");
		public static string ShopOpen(LanguageCode lang) => T(lang, "Aperto ai giocatori", "Open to the players");
		public static string ShopClosed(LanguageCode lang) => T(lang, "Chiuso", "Closed");
		public static string ShopNeedsName(LanguageCode lang) => T(lang, "Serve un nome, in almeno una lingua.", "A name is needed, in one language at least.");
		public static string ShopPercentBadge(int percent, LanguageCode lang) => percent == 100 ? T(lang, "Prezzi di listino", "List prices") : $"{percent}%";
		public static string ShopEmpty(LanguageCode lang) => T(lang, "Scaffali vuoti.", "Empty shelves.");
		public static string ShopAddSearch(LanguageCode lang) => T(lang, "Aggiungi dal compendio (equipaggiamento, oggetti magici)…", "Add from the compendium (equipment, magic items)…");
		public static string ShopAddFree(LanguageCode lang) => T(lang, "Oggetto libero", "Free item");
		public static string ShopFreeName(LanguageCode lang) => T(lang, "Nome dell'oggetto", "Item name");
		public static string ShopPriceGp(LanguageCode lang) => T(lang, "Prezzo (mo)", "Price (GP)");
		public static string ShopStock(LanguageCode lang) => T(lang, "Scorte", "Stock");
		public static string ShopStockHint(LanguageCode lang) => T(lang, "vuoto: illimitate", "empty: unlimited");
		public static string ShopStockLeft(int stock, LanguageCode lang) => stock == 0 ? T(lang, "Esaurito", "Sold out") : T(lang, $"{stock} disponibili", $"{stock} available");
		public static string ShopItemsTitle(int count, LanguageCode lang) => T(lang, $"Oggetti in vendita ({count})", $"Items on sale ({count})");
		public static string ShopItemsHint(LanguageCode lang) => T(lang, "Modifica il prezzo per sovrascrivere il listino", "Change the price to override the list");
		public static string ShopItemsAfterSave(LanguageCode lang) => T(lang, "Conferma il negozio: poi aggiungi gli oggetti dalla sua scheda o riaprendolo qui.", "Confirm the shop: then add its items from its card or by opening it here again.");
		public static string ShopManualWins(LanguageCode lang) => T(lang, "I prezzi scritti a mano prevalgono sul moltiplicatore del negozio.", "Prices written by hand win over the shop's multiplier.");
		public static string ShopDetails(LanguageCode lang) => T(lang, "Dettagli del negozio e mercante", "Shop and merchant");
		public static string ShopNpc(LanguageCode lang) => T(lang, "Mercante (PNG collegato)", "Merchant (linked NPC)");
		public static string ShopNoNpc(LanguageCode lang) => T(lang, "— Nessun PNG collegato —", "— No linked NPC —");
		public static string ShopNpcHint(LanguageCode lang) => T(lang, "Condividi un PNG con la campagna per farne il mercante.", "Share an NPC with the campaign to make them the merchant.");
		public static string ShopNpcLinked(LanguageCode lang) => T(lang, "Collegato", "Linked");
		public static string ShopStandardPrice(string price, LanguageCode lang) => T(lang, $"std {price}", $"std {price}");
		public static string ShopDiscount(LanguageCode lang) => T(lang, "Sconto %", "Discount %");
		public static string ShopDiscountHint(LanguageCode lang) => T(lang, "Sconto su questo oggetto, dopo il moltiplicatore del negozio (0–90%)", "Discount on this item, after the shop's multiplier (0–90%)");
		public static string ShopResetPrice(LanguageCode lang) => T(lang, "Ripristina il prezzo standard", "Back to the standard price");
		public static string ShopListPrice(string price, LanguageCode lang) => T(lang, $"listino {price}", $"list {price}");
		public static string ShopBuy(LanguageCode lang) => T(lang, "Compra", "Buy");
		public static string ShopBuyFor(LanguageCode lang) => T(lang, "Per", "For");
		public static string ShopNoBuyer(LanguageCode lang) => T(lang, "Porta un tuo personaggio al tavolo per comprare.", "Bring a character of yours to the table to buy.");
		public static string ShopQuantity(LanguageCode lang) => T(lang, "Quantità", "Quantity");
		public static string ShopTotal(string price, LanguageCode lang) => T(lang, $"Totale {price}", $"Total {price}");
		public static string ShopBought(string item, int quantity, string price, LanguageCode lang) => T(lang,
			$"Comprato: {item} ×{quantity} per {price}. È nell'inventario.", $"Bought: {item} ×{quantity} for {price}. It is in the inventory.");
		public static string ShopNoMoney(LanguageCode lang) => T(lang, "Le monete non bastano.", "Not enough coins.");
		public static string ShopSoldOut(LanguageCode lang) => T(lang, "Non ne restano abbastanza.", "Not enough left in stock.");
		public static string ShopFailed(LanguageCode lang) => T(lang, "Non è stato possibile.", "That did not work.");
		public static string ShopKindMagic(LanguageCode lang) => T(lang, "Magico", "Magic");

		//	A purse in short: "12 mo · 5 ma · 3 mr" (the coins there are)
		public static string PurseText(CoinPurse purse, LanguageCode lang)
		{
			var parts = new (int Amount, CoinType Type)[] { (purse.Pp, CoinType.Pp), (purse.Gp, CoinType.Gp), (purse.Ep, CoinType.Ep), (purse.Sp, CoinType.Sp), (purse.Cp, CoinType.Cp) }
				.Where(p => p.Amount > 0).Select(p => $"{p.Amount} {CoinName(p.Type, lang)}").ToList();
			return parts.Count == 0 ? T(lang, "borsa vuota", "empty purse") : string.Join(" · ", parts);
		}

		//	The shop generator
		public static string ShopOr(LanguageCode lang) => T(lang, "oppure", "or");
		public static string ShopGenerateKind(LanguageCode lang) => T(lang, "Tipo di negozio", "Kind of shop");
		public static string ShopGenerate(LanguageCode lang) => T(lang, "Genera", "Generate");
		public static string ShopGenerateHint(LanguageCode lang) => T(lang,
			"Nome, gestore, atmosfera, prezzi e scaffali presi dal compendio ufficiale: il negozio nasce chiuso, per controllarlo prima di aprirlo",
			"Name, keeper, atmosphere, prices and shelves from the official compendium: the shop starts closed, to check it before opening");
		public static string ShopGenerated(string name, int items, LanguageCode lang) => T(lang,
			$"Creato «{name}» con {items} articoli (chiuso).", $"Made “{name}” with {items} items (closed).");
		public static string ShopKindName(RealmForge.Shared.Campaigns.ShopKind kind, LanguageCode lang) => kind switch
		{
			RealmForge.Shared.Campaigns.ShopKind.Blacksmith => T(lang, "Fabbro", "Blacksmith"),
			RealmForge.Shared.Campaigns.ShopKind.Armorer => T(lang, "Armaiolo", "Armorer"),
			RealmForge.Shared.Campaigns.ShopKind.Alchemist => T(lang, "Alchimista", "Alchemist"),
			RealmForge.Shared.Campaigns.ShopKind.Arcane => T(lang, "Bottega arcana", "Arcane shop"),
			RealmForge.Shared.Campaigns.ShopKind.Tavern => T(lang, "Taverna", "Tavern"),
			_ => T(lang, "Emporio", "General store")
		};
	}
}
