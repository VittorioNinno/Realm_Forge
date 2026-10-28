using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Dagger of Venom (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class DaggerOfVenom2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("dagger-of-venom", null, 0, MagicItemType.Weapon, ItemRarity.Rare, false, ContentSource.Srd51,
			null,
			("Pugnale avvelenato", "Arma (pugnale), rara",
			"Il personaggio ottiene un bonus di +1 ai tiri per colpire e ai tiri per i danni effettuati con quest'arma magica.\n\nPuò usare un'azione per fare in modo che la lama del coltello si ricopra di uno spesso strato di veleno nero. Il veleno resta sulla lama per 1 minuto o finché un attacco sferrato con quest'arma non colpisce una creatura. La creatura colpita deve superare un tiro salvezza su Costituzione con CD 15, altrimenti subisce 2d10 danni da veleno e diventa avvelenata per 1 minuto. Il pugnale non può più essere utilizzato in questo modo fino all'alba successiva."),
			("Dagger of Venom", "Weapon (dagger), rare",
			"You gain a +1 bonus to attack and damage rolls made with this magic weapon.\n\nYou can use an action to cause thick, black poison to coat the blade. The poison remains for 1 minute or until an attack using this weapon hits a creature. That creature must succeed on a DC 15 Constitution saving throw or take 2d10 poison damage and become poisoned for 1 minute. The dagger can't be used this way again until the next dawn.", null));
	}
}
