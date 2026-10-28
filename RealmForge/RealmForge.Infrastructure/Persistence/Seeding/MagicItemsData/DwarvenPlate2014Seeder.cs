using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Dwarven Plate (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class DwarvenPlate2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("dwarven-plate", null, 0, MagicItemType.Armor, ItemRarity.VeryRare, false, ContentSource.Srd51,
			Magic(Effect(MagicEffectKind.ArmorClass, 2)),
			("Armatura completa nanica", "Armatura (armatura a piastre), molto rara",
			"Mentre il personaggio indossa quest'armatura, ottiene un bonus di +2 alla CA. Inoltre, se un effetto lo fa muovere sul terreno contro la sua volontà, il personaggio può usare la sua reazione per ridurre la distanza di cui viene mosso di un massimo di 3 metri."),
			("Dwarven Plate", "Armor (plate), very rare",
			"While wearing this armor, you gain a +2 bonus to AC. In addition, if an effect moves you against your will along the ground, you can use your reaction to reduce the distance you are moved by up to 10 feet.", null));
	}
}
