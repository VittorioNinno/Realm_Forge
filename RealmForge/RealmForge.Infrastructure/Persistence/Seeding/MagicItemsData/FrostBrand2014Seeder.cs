using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Frost Brand (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class FrostBrand2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("frost-brand", null, 0, MagicItemType.Weapon, ItemRarity.VeryRare, true, ContentSource.Srd51,
			Magic(Resist(DamageType.Fire)),
			("Spadone del gelo", "Arma (qualsiasi spada), molto rara (richiede sintonia)",
			"Quando il personaggio colpisce con un attacco effettuato con questa spada magica, il bersaglio subisce 1d6 danni da freddo extra. Inoltre, finché impugna la spada, il personaggio ha resistenza ai danni da fuoco.\n\nA temperature gelide, la lama proietta luce intensa in un raggio di 3 metri e luce fioca per altri 3 metri.\n\nQuando il personaggio sfodera quest'arma, può estinguere tutte le fiamme non magiche entro un raggio di 9 metri da lui. Questa proprietà non può essere utilizzata più di una volta ogni ora.", null),
			("Frost Brand", "Weapon (any sword), very rare (requires attunement)",
			"When you hit with an attack using this magic sword, the target takes an extra 1d6 cold damage. In addition, while you hold the sword, you have resistance to fire damage.\n\nIn freezing temperatures, the blade sheds bright light in a 10-foot radius and dim light for an additional 10 feet.\n\nWhen you draw this weapon, you can extinguish all nonmagical flames within 30 feet of you. This property can be used no more than once per hour.", null));
	}
}
