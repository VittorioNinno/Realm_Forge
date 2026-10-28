using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Weapon of Warning (2014 ruleset). Item of the 2014 Dungeon Master's Guide outside the SRD: name and texts written by RealmForge (Italian and English).
///	</summary>
public static class WeaponOfWarning2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("weapon-of-warning", null, 0, MagicItemType.Weapon, ItemRarity.Uncommon, true, ContentSource.RealmForge,
			null,
			("Arma dell'avvertimento", "Arma (qualsiasi), non comune (richiede sintonia)",
			"Questa arma magica avverte il personaggio dei pericoli. Finché l'arma è a portata di mano, il personaggio dispone di vantaggio ai tiri di iniziativa. Inoltre, né lui né i suoi compagni entro 9 metri possono essere sorpresi, a meno che non siano incapacitati da qualcosa di diverso dal sonno naturale. Quando inizia un combattimento, l'arma sveglia magicamente il personaggio e i compagni entro gittata che stanno dormendo di sonno naturale.", null),
			("Weapon of Warning", "Weapon (any), uncommon (requires attunement)",
			"This magic weapon warns you of danger. While the weapon is within reach, you have advantage on initiative rolls. In addition, you and your companions within 30 feet of you can't be surprised, unless incapacitated by something other than natural sleep. When combat begins, the weapon magically wakes you and any companions within range who are sleeping naturally.", null));
	}
}
