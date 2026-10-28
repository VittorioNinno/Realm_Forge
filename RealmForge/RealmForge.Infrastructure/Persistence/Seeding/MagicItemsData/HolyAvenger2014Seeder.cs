using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Holy Avenger (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class HolyAvenger2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("holy-avenger", null, 0, MagicItemType.Weapon, ItemRarity.Legendary, true, ContentSource.Srd51,
			Magic(Effect(MagicEffectKind.AttackAndDamage, 3)),
			("Sacro vendicatore", "Arma (qualsiasi spada), leggendaria (richiede sintonia con un paladino)",
			"Il personaggio ottiene un bonus di +3 ai tiri per colpire e ai tiri per i danni effettuati con quest'arma magica. Quando colpisce con quest'arma un immondo o un non morto, quella creatura subisce 2d10 danni radiosi extra.\n\nFinché il personaggio impugna la spada sguainata, essa emana intorno a sé un'aura del raggio 3 metri. Il personaggio e tutte le creature amichevoli nei suoi confronti situate all'interno dell'aura dispongono di vantaggio ai tiri salvezza contro gli incantesimi e gli altri effetti magici. Se il personaggio possiede 17 o più livelli nella classe del paladino, il raggio dell'aura aumenta a 9 metri."),
			("Holy Avenger", "Weapon (any sword), legendary (requires attunement by a paladin)",
			"You gain a +3 bonus to attack and damage rolls made with this magic weapon. When you hit a fiend or an undead with it, that creature takes an extra 2d10 radiant damage.\n\nWhile you hold the drawn sword, it creates an aura in a 10-foot radius around you. You and all creatures friendly to you in the aura have advantage on saving throws against spells and other magical effects. If you have 17 or more levels in the paladin class, the radius of the aura increases to 30 feet.", null));
	}
}
