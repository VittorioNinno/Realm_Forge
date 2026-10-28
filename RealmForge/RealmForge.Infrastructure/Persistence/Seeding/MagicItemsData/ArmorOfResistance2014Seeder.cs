using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Armor of Resistance (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class ArmorOfResistance2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("armor-of-resistance", null, 0, MagicItemType.Armor, ItemRarity.Rare, true, ContentSource.Srd51,
			null,
			("Armatura della resistenza", "Armatura (leggera, media o pesante), rara (richiede sintonia)",
			"Il personaggio che indossa questa armatura ottiene resistenza a un tipo di danno che il GM sceglie o determina casualmente tra le opzioni sottostanti.\n\n| d10 | Tipo di danno | d10 | Tipo di danno |\n|---|---|---|---|\n| 1 | Acido | 6 | Necrotico |\n| 2 | Forza | 7 | Psichico |\n| 3 | Freddo | 8 | Radioso |\n| 4 | Fulmine | 9 | Tuono |\n| 5 | Fuoco | 10 | Veleno |"),
			("Armor of Resistance", "Armor (light, medium, or heavy), rare (requires attunement)",
			"You have resistance to one type of damage while you wear this armor. The GM chooses the type or determines it randomly from the options below.\n\n| d10 | Damage Type |\n|---|---|\n| 1 | Acid |\n| 2 | Cold |\n| 3 | Fire |\n| 4 | Force |\n| 5 | Lightning |\n| 6 | Necrotic |\n| 7 | Poison |\n| 8 | Psychic |\n| 9 | Radiant |\n| 10 | Thunder |", null));
	}
}
