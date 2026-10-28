using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Tome of Understanding (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class TomeOfUnderstanding2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("tome-of-understanding", null, 0, MagicItemType.WondrousItem, ItemRarity.VeryRare, false, ContentSource.Srd51,
			null,
			("Tomo della comprensione", "Oggetto meraviglioso, molto raro",
			"Questo libro contiene la descrizione di una serie di esercizi di intuizione e percezione, e le sue parole sono cariche di magia. Se il personaggio trascorre 48 ore in un periodo massimo di 6 giorni a studiare il contenuto del libro e ad applicarne i precetti, il suo punteggio di Saggezza aumenta di 2, come anche il massimo ottenibile in quel punteggio. Una volta letto, il libro perde il suo potere: lo riacquisterà dopo un secolo.", null),
			("Tome of Understanding", "Wondrous item, very rare",
			"This book contains intuition and insight exercises, and its words are charged with magic. If you spend 48 hours over a period of 6 days or fewer studying the book's contents and practicing its guidelines, your Wisdom score increases by 2, as does your maximum for that score. The manual then loses its magic, but regains it in a century.", null));
	}
}
