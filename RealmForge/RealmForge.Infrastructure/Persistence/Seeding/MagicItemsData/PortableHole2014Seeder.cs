using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Portable Hole (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class PortableHole2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("portable-hole", null, 0, MagicItemType.WondrousItem, ItemRarity.Rare, false, ContentSource.Srd51,
			null,
			("Buco portatile", "Oggetto meraviglioso, raro",
			"Quando è piegato, questo panno di elegante tessuto nero morbido come la seta ha le dimensioni di un fazzoletto. Una volta spiegato, copre una superficie circolare di 1,8 metri di diametro.\n\nIl personaggio può usare un'azione per spiegare il *buco portatile* e collocarlo su una superficie solida o contro di essa, creando un buco extradimensionale profondo 3 metri. Lo spazio cilindrico all'interno del buco esiste su un diverso piano di esistenza, quindi non può essere usato per creare passaggi da attraversare. Ogni creatura all'interno di un buco portatile aperto può uscirne arrampicandosi sulle sue pareti.\n\nIl personaggio può usare un'azione per chiudere il *buco portatile* afferrandone i lembi e ripiegandoli. In questo modo, il buco si chiude e tutti gli oggetti e le creature al suo interno restano nello spazio extradimensionale. A prescindere dal suo contenuto, il buco ha un peso irrilevante.\n\nSe il buco è ripiegato, una creatura all'interno del suo spazio extradimensionale può usare un'azione per effettuare una prova di Forza con CD 10. Se la prova viene superata, la creatura riesce a uscire e compare entro 1,5 metri dal *buco portatile* o da chi lo trasporta. Una creatura che necessita di respirare può sopravvivere per un massimo di 10 minuti all'interno del *buco portatile,* dopodiché inizia a soffocare.\n\nCollocare un *buco portatile* all'interno di uno spazio extradimensionale, come quello creato da uno *zainetto pratico,* da una *borsa conservante* o da altri oggetti simili, distrugge istantaneamente entrambi gli oggetti e apre un portale sul Piano Astrale. Il portale ha origine nel punto in cui uno dei due oggetti è stato inserito nell'altro. Tutte le creature entro 3 metri dal portale vengono attirate al suo interno e depositate in un luogo casuale del Piano Astrale, dopodiché il portale si chiude. Il portale è a senso unico e non può essere riaperto.", null),
			("Portable Hole", "Wondrous item, rare",
			"This fine black cloth, soft as silk, is folded up to the dimensions of a handkerchief. It unfolds into a circular sheet 6 feet in diameter.\n\nYou can use an action to unfold a portable hole and place it on or against a solid surface, whereupon the portable hole creates an extradimensional hole 10 feet deep. The cylindrical space within the hole exists on a different plane, so it can't be used to create open passages. Any creature inside an open portable hole can exit the hole by climbing out of it.\n\nYou can use an action to close a portable hole by taking hold of the edges of the cloth and folding it up. Folding the cloth closes the hole, and any creatures or objects within remain in the extradimensional space. No matter what's in it, the hole weighs next to nothing.\n\nIf the hole is folded up, a creature within the hole's extradimensional space can use an action to make a DC 10 Strength check. On a successful check, the creature forces its way out and appears within 5 feet of the portable hole or the creature carrying it. A breathing creature within a closed portable hole can survive for up to 10 minutes, after which time it begins to suffocate.\n\nPlacing a portable hole inside an extradimensional space created by a bag of holding, handy haversack, or similar item instantly destroys both items and opens a gate to the Astral Plane. The gate originates where the one item was placed inside the other. Any creature within 10 feet of the gate is sucked through it and deposited in a random location on the Astral Plane. The gate then closes. The gate is one-way only and can't be reopened.", null));
	}
}
