using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Ring of the Ram (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class RingOfTheRam2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("ring-of-the-ram", null, 0, MagicItemType.Ring, ItemRarity.Rare, true, ContentSource.Srd51,
			Charges(3, ItemRecharge.LongRest, "1d3"),
			("Anello dell'ariete", "Anello, raro (richiede sintonia)",
			"Questo anello possiede 3 cariche e recupera 1d3 cariche consumate all'alba di ogni giorno. Mentre il personaggio lo indossa, può usare un'azione per consumare da 1 a 3 cariche e attaccare una creatura che è in grado di vedere entro 18 metri da lui. L'anello crea una testa d'ariete spettrale ed effettua il suo tiro per colpire con un bonus di +7. Se il colpo va a segno, per ogni carica consumata il bersaglio subisce 2d10 danni da forza e viene spinto lontano dal personaggio per 1,5 metri.\n\nIn alternativa, il personaggio può usare un'azione per consumare da 1 a 3 cariche dell'anello e tentare di rompere un oggetto che è in grado di vedere situato entro 18 metri da lui e che non sia indossato o trasportato. L'anello effettua una prova di Forza con un bonus di +5 per ogni carica consumata."),
			("Ring of the Ram", "Ring, rare (requires attunement)",
			"This ring has 3 charges, and it regains 1d3 expended charges daily at dawn. While wearing the ring, you can use an action to expend 1 to 3 of its charges to attack one creature you can see within 60 feet of you. The ring produces a spectral ram's head and makes its attack roll with a +7 bonus. On a hit, for each charge you spend, the target takes 2d10 force damage and is pushed 5 feet away from you.\n\nAlternatively, you can expend 1 to 3 of the ring's charges as an action to try to break an object you can see within 60 feet of you that isn't being worn or carried. The ring makes a Strength check with a +5 bonus for each charge you spend.", null));
	}
}
