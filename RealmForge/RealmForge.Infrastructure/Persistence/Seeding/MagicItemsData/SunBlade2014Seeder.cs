using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Sun Blade (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class SunBlade2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("sun-blade", null, 0, MagicItemType.Weapon, ItemRarity.Rare, true, ContentSource.Srd51,
			Magic(Effect(MagicEffectKind.AttackAndDamage, 2)),
			("Lama del sole", "Arma (spada lunga), rara (richiede sintonia)",
			"Quest'oggetto sembra l'elsa di una spada lunga. Mentre il personaggio impugna l'elsa, può far comparire (o scomparire) una lama di pura energia radiosa usando un'azione bonus. Finché la lama è presente, questa spada lunga magica possiede la proprietà accurata. Se il personaggio è competente nelle spade corte o lunghe, è competente anche nell'uso della *lama del sole.*\n\nIl personaggio ottiene un bonus di +2 ai tiri per colpire e ai tiri per i danni effettuati con quest'arma, che infligge danni radiosi anziché taglienti. Quando l'arma colpisce un non morto, il bersaglio subisce 1d8 danni radiosi extra.\n\nLa lama luminosa di questa spada proietta luce intensa in un raggio di 4,5 metri e luce fioca per altri 4,5 metri. La luce è considerata luce solare. Finché la lama permane, il personaggio può usare un'azione per ampliare o ridurre il raggio della luce intensa e fioca di 1,5 metri per ognuna, fino a un massimo di 9 metri o a un minimo di 3 metri per ognuna.", null),
			("Sun Blade", "Weapon (longsword), rare (requires attunement)",
			"This item appears to be a longsword hilt. While grasping the hilt, you can use a bonus action to cause a blade of pure radiance to spring into existence, or make the blade disappear. While the blade exists, this magic longsword has the finesse property. If you are proficient with shortswords or longswords, you are proficient with the sun blade.\n\nYou gain a +2 bonus to attack and damage rolls made with this weapon, which deals radiant damage instead of slashing damage. When you hit an undead with it, that target takes an extra 1d8 radiant damage.\n\nThe sword's luminous blade emits bright light in a 15-foot radius and dim light for an additional 15 feet. The light is sunlight. While the blade persists, you can use an action to expand or reduce its radius of bright and dim light by 5 feet each, to a maximum of 30 feet each or a minimum of 10 feet each.", null));
	}
}
