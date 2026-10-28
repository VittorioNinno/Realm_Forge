using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Instrument of the Bards (2014 ruleset). Item of the 2014 Dungeon Master's Guide outside the SRD: name and texts written by RealmForge (Italian and English).
///	</summary>
public static class InstrumentOfTheBards2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("instrument-of-the-bards", null, 0, MagicItemType.WondrousItem, null, true, ContentSource.RealmForge,
			null,
			("Strumento dei bardi", "Oggetto meraviglioso, rarità variabile (richiede sintonia con un bardo)",
			"Uno strumento musicale di fattura eccezionale, migliore di qualsiasi strumento comune. Ne esistono sette tipi, ognuno chiamato come un leggendario collegio bardico. Una creatura che tenta di suonarlo senza essere in sintonia con esso deve superare un tiro salvezza su Saggezza con CD 15, altrimenti subisce 2d4 danni psichici.\n\nIl personaggio può usare un'azione per suonare lo strumento e lanciare uno dei suoi incantesimi, usando la propria caratteristica da incantatore e la propria CD dei tiri salvezza. Dopo aver lanciato un incantesimo con lo strumento, non può lanciare di nuovo quello stesso incantesimo fino all'alba successiva.\n\nTutti gli strumenti permettono di lanciare *invisibilità*, *levitazione*, *protezione dal bene e dal male* e *volare*, più gli incantesimi indicati per il singolo strumento. Quando il personaggio usa lo strumento per lanciare un incantesimo che rende affascinati i bersagli che falliscono il tiro salvezza, questi subiscono svantaggio al tiro salvezza; vale sia quando lo strumento è la fonte dell'incantesimo sia quando è usato come focus.\n\n| Strumento | Rarità | Incantesimi |\n|---|---|---|\n| Arpa di Anstruth | Molto rara | *controllare tempo atmosferico*, *cura ferite* (5° livello), *muro di spine* |\n| Mandolino di Canaith | Rara | *cura ferite* (3° livello), *dissolvi magie*, *protezione dall'energia* (solo fulmine) |\n| Lira di Cli | Rara | *muro di fuoco*, *muro di vento*, *scolpire pietra* |\n| Liuto di Doss | Non comune | *amicizia con gli animali*, *protezione dai veleni*, *protezione dall'energia* (solo fuoco) |\n| Bandura di Fochlucan | Non comune | *intralciare*, *luminescenza*, *parlare con gli animali*, *randello incantato* |\n| Cetra di Mac-Fuirmidh | Non comune | *cura ferite*, *nube di nebbia*, *pelle coriacea* |\n| Arpa di Ollamh | Leggendaria | *confusione*, *controllare tempo atmosferico*, *tempesta di fuoco* |"),
			("Instrument of the Bards", "Wondrous item, rarity varies (requires attunement by a bard)",
			"A musical instrument of exceptional make, better than any ordinary one. Seven kinds exist, each named after a legendary bard college. A creature that tries to play it without being attuned to it must succeed on a DC 15 Wisdom saving throw or take 2d4 psychic damage.\n\nYou can use an action to play the instrument and cast one of its spells, using your own spellcasting ability and spell save DC. Once you have cast a spell with the instrument, you can't cast that same spell with it again until the next dawn.\n\nEvery instrument can cast *fly*, *invisibility*, *levitate* and *protection from evil and good*, plus the spells listed for that instrument. When you use the instrument to cast a spell that charms the targets that fail their save, they have disadvantage on that saving throw, whether the instrument is the source of the spell or your spellcasting focus.\n\n| Instrument | Rarity | Spells |\n|---|---|---|\n| Anstruth harp | Very rare | *control weather*, *cure wounds* (5th level), *wall of thorns* |\n| Canaith mandolin | Rare | *cure wounds* (3rd level), *dispel magic*, *protection from energy* (lightning only) |\n| Cli lyre | Rare | *stone shape*, *wall of fire*, *wind wall* |\n| Doss lute | Uncommon | *animal friendship*, *protection from energy* (fire only), *protection from poison* |\n| Fochlucan bandore | Uncommon | *entangle*, *faerie fire*, *shillelagh*, *speak with animals* |\n| Mac-Fuirmidh cittern | Uncommon | *barkskin*, *cure wounds*, *fog cloud* |\n| Ollamh harp | Legendary | *confusion*, *control weather*, *fire storm* |", null));
		yield return Item("instrument-of-the-bards-anstruth-harp", "instrument-of-the-bards", 1, MagicItemType.WondrousItem, ItemRarity.VeryRare, true, ContentSource.RealmForge,
			null,
			("Arpa di Anstruth", "Oggetto meraviglioso, molto raro (richiede sintonia con un bardo)",
			""),
			("Anstruth Harp", "Wondrous item, very rare (requires attunement by a bard)",
			"", null));
		yield return Item("instrument-of-the-bards-canaith-mandolin", "instrument-of-the-bards", 2, MagicItemType.WondrousItem, ItemRarity.Rare, true, ContentSource.RealmForge,
			null,
			("Mandolino di Canaith", "Oggetto meraviglioso, raro (richiede sintonia con un bardo)",
			""),
			("Canaith Mandolin", "Wondrous item, rare (requires attunement by a bard)",
			"", null));
		yield return Item("instrument-of-the-bards-cli-lyre", "instrument-of-the-bards", 3, MagicItemType.WondrousItem, ItemRarity.Rare, true, ContentSource.RealmForge,
			null,
			("Lira di Cli", "Oggetto meraviglioso, raro (richiede sintonia con un bardo)",
			""),
			("Cli Lyre", "Wondrous item, rare (requires attunement by a bard)",
			"", null));
		yield return Item("instrument-of-the-bards-doss-lute", "instrument-of-the-bards", 4, MagicItemType.WondrousItem, ItemRarity.Uncommon, true, ContentSource.RealmForge,
			null,
			("Liuto di Doss", "Oggetto meraviglioso, non comune (richiede sintonia con un bardo)",
			""),
			("Doss Lute", "Wondrous item, uncommon (requires attunement by a bard)",
			"", null));
		yield return Item("instrument-of-the-bards-fochlucan-bandore", "instrument-of-the-bards", 5, MagicItemType.WondrousItem, ItemRarity.Uncommon, true, ContentSource.RealmForge,
			null,
			("Bandura di Fochlucan", "Oggetto meraviglioso, non comune (richiede sintonia con un bardo)",
			""),
			("Fochlucan Bandore", "Wondrous item, uncommon (requires attunement by a bard)",
			"", null));
		yield return Item("instrument-of-the-bards-mac-fuirmidh-cittern", "instrument-of-the-bards", 6, MagicItemType.WondrousItem, ItemRarity.Uncommon, true, ContentSource.RealmForge,
			null,
			("Cetra di Mac-Fuirmidh", "Oggetto meraviglioso, non comune (richiede sintonia con un bardo)",
			""),
			("Mac-Fuirmidh Cittern", "Wondrous item, uncommon (requires attunement by a bard)",
			"", null));
		yield return Item("instrument-of-the-bards-ollamh-harp", "instrument-of-the-bards", 7, MagicItemType.WondrousItem, ItemRarity.Legendary, true, ContentSource.RealmForge,
			null,
			("Arpa di Ollamh", "Oggetto meraviglioso, leggendario (richiede sintonia con un bardo)",
			""),
			("Ollamh Harp", "Wondrous item, legendary (requires attunement by a bard)",
			"", null));
	}
}
