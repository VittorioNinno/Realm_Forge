using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Gloves of Missile Snaring (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class GlovesOfMissileSnaring2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("gloves-of-missile-snaring", null, 0, MagicItemType.WondrousItem, ItemRarity.Uncommon, true, ContentSource.Srd51,
			null,
			("Guanti catturaproiettili", "Oggetto meraviglioso, non comune (richiede sintonia)",
			"Questi guanti sembrano quasi fondersi con le mani del personaggio nel momento in cui li indossa. Quando il personaggio viene colpito da un attacco con arma a distanza, può usare la sua reazione per ridurre i danni di 1d10 + il suo modificatore di Destrezza, purché abbia una mano libera. Se riduce i danni a 0, può afferrare il proiettile, purché si tratti di un oggetto abbastanza piccolo da essere tenuto in mano.", null),
			("Gloves of Missile Snaring", "Wondrous item, uncommon (requires attunement)",
			"These gloves seem to almost meld into your hands when you don them. When a ranged weapon attack hits you while you're wearing them, you can use your reaction to reduce the damage by 1d10 + your Dexterity modifier, provided that you have a free hand. If you reduce the damage to 0, you can catch the missile if it is small enough for you to hold in that hand.", null));
	}
}
