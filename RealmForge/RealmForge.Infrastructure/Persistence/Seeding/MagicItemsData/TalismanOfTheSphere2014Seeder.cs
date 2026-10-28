using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Talisman of the Sphere (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class TalismanOfTheSphere2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("talisman-of-the-sphere", null, 0, MagicItemType.WondrousItem, ItemRarity.Legendary, true, ContentSource.Srd51,
			null,
			("Talismano della sfera", "Oggetto meraviglioso, leggendario (richiede sintonia)",
			"Quando il personaggio effettua una prova di Intelligenza (Arcano) per controllare una *sfera annientatrice* mentre impugna il talismano, il suo bonus di competenza a quella prova raddoppia. Inoltre, quando il personaggio inizia il proprio turno mentre controlla una *sfera annientatrice,* può usare un'azione per farla levitare di 3 metri più una distanza aggiuntiva pari a 3 m × il suo modificatore di Intelligenza.", null),
			("Talisman of the Sphere", "Wondrous item, legendary (requires attunement)",
			"When you make an Intelligence (Arcana) check to control a sphere of annihilation while you are holding this talisman, you double your proficiency bonus on the check. In addition, when you start your turn with control over a sphere of annihilation, you can use an action to levitate it 10 feet plus a number of additional feet equal to 10 × your Intelligence modifier.", null));
	}
}
