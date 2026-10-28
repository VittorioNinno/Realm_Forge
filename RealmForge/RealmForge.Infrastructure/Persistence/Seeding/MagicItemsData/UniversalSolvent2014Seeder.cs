using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Universal Solvent (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class UniversalSolvent2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("universal-solvent", null, 0, MagicItemType.WondrousItem, ItemRarity.Legendary, false, ContentSource.Srd51,
			null,
			("Solvente universale", "Oggetto meraviglioso, leggendario",
			"Questa fiala contiene un liquido lattiginoso che emana un forte odore di alcool. Il personaggio può usare un'azione per versare il contenuto della fiala su una superficie entro portata. Il liquido dissolve istantaneamente qualsiasi materiale o sostanza adesiva toccata, inclusa la *colla meravigliosa,* ed è in grado di coprire fino a una superficie quadrata con lato di 30 cm."),
			("Universal Solvent", "Wondrous item, legendary",
			"This tube holds milky liquid with a strong alcohol smell. You can use an action to pour the contents of the tube onto a surface within reach. The liquid instantly dissolves up to 1 square foot of adhesive it touches, including sovereign glue.", null));
	}
}
