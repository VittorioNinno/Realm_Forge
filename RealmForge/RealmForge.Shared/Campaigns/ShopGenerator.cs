using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;

namespace RealmForge.Shared.Campaigns;

///	<summary>
///	The kinds of place the shop generator builds.
///	</summary>
public enum ShopKind
{
	General = 1,
	Blacksmith = 2,
	Armorer = 3,
	Alchemist = 4,
	Arcane = 5,
	Tavern = 6
}

///	<summary>
///	Procedural shops and taverns: a name, a keeper with a manner, a look of the place (and, in a tavern, a rumour), a
///	price multiplier and what goes on the shelves. The tables are written for RealmForge, in Italian and English; the
///	server fills the shelves from the compendium following Stock.
///	</summary>
public static class ShopGenerator
{
	///	<summary>What a kind of shop sells: equipment categories, magic item types and rarities, how many of each.</summary>
	public sealed record Stock(EquipmentCategory[] Categories, int Mundane, MagicItemType[] MagicTypes, ItemRarity[] Rarities, int Magic);

	public sealed record Plan(string NameIt, string NameEn, string DescriptionIt, string DescriptionEn, int PricePercent, Stock Stock,
		List<(string It, string En, int PriceInCopper)> Extras);

	private static readonly string[] Keepers =
	[
		"Bruna Ferracane", "Osvald", "Mirta la Rossa", "Teodoro Quercia", "Ilse", "Gualtiero", "Nadia Sette Chiavi", "Borin",
		"Agata Brace", "Fiorenzo", "Hesper", "Ruggero Mezzaluna", "Sibilla", "Tamar", "Ottone", "Vera Cenere"
	];

	private static readonly (string It, string En)[] Manners =
	[
		("accoglie tutti con un inchino esagerato e un prezzo esagerato", "greets everyone with an overdone bow and an overdone price"),
		("non alza mai gli occhi dal lavoro, ma sente ogni parola", "never looks up from the work, but hears every word"),
		("contratta per divertimento e si offende se nessuno ci prova", "haggles for fun and takes offence when nobody tries"),
		("tiene un registro di ogni cliente, con soprannomi poco lusinghieri", "keeps a ledger of every customer, with unflattering nicknames"),
		("parla del tempo e delle tasse con chiunque, per ore", "talks weather and taxes with anyone, for hours"),
		("diffida delle armi in bottega e chiede di lasciarle alla porta", "distrusts weapons in the shop and asks for them at the door"),
		("regala un piccolo portafortuna a chi spende più di dieci monete d'oro", "gives a small charm to anyone spending over ten gold"),
		("è appena arrivato in città e non conosce ancora i prezzi giusti", "has just come to town and does not know the fair prices yet")
	];

	private static readonly Dictionary<ShopKind, (string It, string En)[]> Names = new()
	{
		[ShopKind.General] = [("L'Emporio del Crocevia", "The Crossroads Emporium"), ("Tutto per la Strada", "All for the Road"), ("La Bisaccia Piena", "The Full Satchel"), ("Bazar della Lanterna", "Lantern Bazaar")],
		[ShopKind.Blacksmith] = [("La Forgia del Martello Storto", "The Crooked Hammer Forge"), ("Incudine e Brace", "Anvil and Ember"), ("La Lama Paziente", "The Patient Blade"), ("Ferri di Confine", "Borderland Irons")],
		[ShopKind.Armorer] = [("Maglie e Piastre", "Mail and Plate"), ("Lo Scudo d'Ottone", "The Brass Shield"), ("Il Corsetto di Ferro", "The Iron Bodice"), ("Cuoio Bollito", "Boiled Leather")],
		[ShopKind.Alchemist] = [("L'Alambicco Verde", "The Green Alembic"), ("Fiale e Fumi", "Vials and Fumes"), ("Il Mortaio d'Argento", "The Silver Mortar"), ("Erbe della Strega Buona", "The Good Witch's Herbs")],
		[ShopKind.Arcane] = [("La Pergamena Inquieta", "The Restless Scroll"), ("Curiosità Arcane", "Arcane Curiosities"), ("L'Occhio di Vetro", "The Glass Eye"), ("Bottega dell'Astrolabio", "The Astrolabe Shop")],
		[ShopKind.Tavern] = [("Il Drago Ubriaco", "The Drunken Dragon"), ("La Pentola Che Ride", "The Laughing Pot"), ("Al Grifone Zoppo", "The Limping Griffin"), ("La Locanda della Nebbia", "The Fog Inn"), ("Il Boccale Sbeccato", "The Chipped Tankard")]
	};

	private static readonly Dictionary<ShopKind, (string It, string En)[]> Looks = new()
	{
		[ShopKind.General] = [("Scaffali fino al soffitto, un gatto che dorme sulle corde.", "Shelves up to the ceiling, a cat asleep on the ropes."), ("Odore di cera e cuoio, un campanello che suona fuori tempo.", "A smell of wax and leather, a bell that rings out of time.")],
		[ShopKind.Blacksmith] = [("Il calore della forgia arriva fino in strada; scintille a ogni colpo.", "The forge's heat reaches the street; sparks at every blow."), ("Lame appese come prosciutti, un apprendista che fischietta stonato.", "Blades hung like hams, an apprentice whistling off key.")],
		[ShopKind.Armorer] = [("Manichini in armatura montano la guardia all'ingresso.", "Armoured mannequins stand guard at the door."), ("Il tintinnio della maglia riempie la stanza a ogni passo.", "The jingle of mail fills the room at every step.")],
		[ShopKind.Alchemist] = [("Vapori colorati e barattoli con etichette scritte a mano.", "Coloured vapours and hand-labelled jars."), ("Un calderone borbotta in un angolo; meglio non chiedere cosa contiene.", "A cauldron bubbles in a corner; better not ask what is in it.")],
		[ShopKind.Arcane] = [("Candele che non si consumano e un orologio che va all'indietro.", "Candles that never burn down and a clock that runs backwards."), ("Libri incatenati agli scaffali; uno di loro sussurra.", "Books chained to the shelves; one of them whispers.")],
		[ShopKind.Tavern] = [("Fumo di camino, tavoli incisi da generazioni di coltelli.", "Hearth smoke, tables carved by generations of knives."), ("Un bardo stanco e un cane enorme che decide chi entra.", "A tired bard and a huge dog that decides who comes in.")]
	};

	private static readonly (string It, string En)[] Rumours =
	[
		("Dicono che al vecchio mulino si sentano campane, ma il mulino non ha campane.", "They say bells ring at the old mill, but the mill has no bells."),
		("Una carovana è partita tre giorni fa e nessuno l'ha vista arrivare.", "A caravan left three days ago and nobody saw it arrive."),
		("Il figlio del borgomastro paga in monete d'oro di un regno che non esiste più.", "The mayor's son pays in gold from a kingdom that no longer exists."),
		("Qualcuno compra tutte le candele nere della città.", "Someone is buying every black candle in town."),
		("Nelle fogne c'è una porta nuova. Nessuno l'ha costruita.", "There is a new door in the sewers. Nobody built it."),
		("Il fabbro giura di aver forgiato una chiave per una serratura che si muove.", "The smith swears he forged a key for a lock that moves.")
	];

	private static readonly (string It, string En, int Copper)[] Menu =
	[
		("Zuppa del giorno con pane nero", "Soup of the day with black bread", 5), ("Stufato di montone", "Mutton stew", 30),
		("Boccale di birra scura", "Tankard of dark ale", 4), ("Caraffa di vino della casa", "Jug of house wine", 20),
		("Liquore di prugne della locandiera", "The innkeeper's plum liquor", 15), ("Torta di mele e miele", "Apple and honey pie", 8),
		("Letto nella sala comune (una notte)", "Bed in the common room (one night)", 50), ("Stanza privata (una notte)", "Private room (one night)", 200),
		("Bagno caldo", "Hot bath", 10), ("Stalla e biada (una notte)", "Stable and feed (one night)", 50)
	];

	public static Stock StockOf(ShopKind kind) => kind switch
	{
		ShopKind.Blacksmith => new([EquipmentCategory.Weapon, EquipmentCategory.Ammunition], 10, [MagicItemType.Weapon], [ItemRarity.Uncommon], 1),
		ShopKind.Armorer => new([EquipmentCategory.Armor], 8, [MagicItemType.Armor], [ItemRarity.Uncommon], 1),
		ShopKind.Alchemist => new([], 0, [MagicItemType.Potion], [ItemRarity.Common, ItemRarity.Uncommon], 5),
		ShopKind.Arcane => new([EquipmentCategory.SpellcastingFocus], 3, [MagicItemType.Scroll, MagicItemType.Wand, MagicItemType.Ring, MagicItemType.WondrousItem], [ItemRarity.Common, ItemRarity.Uncommon], 5),
		ShopKind.Tavern => new([], 0, [], [], 0),
		_ => new([EquipmentCategory.AdventuringGear, EquipmentCategory.Tool, EquipmentCategory.EquipmentPack], 12, [MagicItemType.Potion], [ItemRarity.Common], 1)
	};

	public static Plan For(ShopKind kind, Random? random = null)
	{
		random ??= Random.Shared;
		T One<T>(IReadOnlyList<T> list) => list[random.Next(list.Count)];
		var name = One(Names.GetValueOrDefault(kind) ?? Names[ShopKind.General]);
		var keeper = One(Keepers);
		var manner = One(Manners);
		var look = One(Looks.GetValueOrDefault(kind) ?? Looks[ShopKind.General]);
		var keeperIt = kind == ShopKind.Tavern ? "Oste" : "Bottega di";
		var keeperEn = kind == ShopKind.Tavern ? "Kept by" : "Run by";
		var descriptionIt = $"{look.It} {keeperIt} {keeper}, che {manner.It}.";
		var descriptionEn = $"{look.En} {keeperEn} {keeper}, who {manner.En}.";
		var extras = new List<(string It, string En, int PriceInCopper)>();
		if (kind == ShopKind.Tavern)
		{
			var rumour = One(Rumours);
			descriptionIt += $" Si mormora: «{rumour.It}»";
			descriptionEn += $" Word is: “{rumour.En}”";
			foreach (var dish in Menu.OrderBy(_ => random.Next()).Take(6).OrderBy(d => d.Copper))
			{
				extras.Add((dish.It, dish.En, dish.Copper));
			}
		}
		//	Prices from 90% to 120%, in steps of 5
		var percent = 90 + 5 * random.Next(0, 7);
		return new Plan(name.It, name.En, descriptionIt, descriptionEn, percent, StockOf(kind), extras);
	}
}
