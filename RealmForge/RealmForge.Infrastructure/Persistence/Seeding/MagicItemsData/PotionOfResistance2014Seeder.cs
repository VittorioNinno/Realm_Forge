using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Potion of Resistance (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class PotionOfResistance2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("potion-of-resistance", null, 0, MagicItemType.Potion, ItemRarity.Uncommon, false, ContentSource.Srd51,
			null,
			("Pozione di resistenza", "Pozione, non comune",
			"Quando beve questa pozione, il personaggio ottiene resistenza per 1 ora a un tipo di danno che il GM sceglie o determina casualmente tra le opzioni sottostanti.\n\n| d10 | Tipo di danno | d10 | Tipo di danno |\n|---|---|---|---|\n| 1 | Acido | 6 | Necrotico |\n| 2 | Forza | 7 | Psichico |\n| 3 | Freddo | 8 | Radioso |\n| 4 | Fulmine | 9 | Tuono |\n| 5 | Fuoco | 10 | Veleno |"),
			("Potion of Resistance", "Potion, uncommon",
			"When you drink this potion, you gain resistance to one type of damage for 1 hour. The GM chooses the type or determines it randomly from the options below.\n\n| d10 | Damage Type |\n|---|---|\n| 1 | Acid |\n| 2 | Cold |\n| 3 | Fire |\n| 4 | Force |\n| 5 | Lightning |\n| 6 | Necrotic |\n| 7 | Poison |\n| 8 | Psychic |\n| 9 | Radiant |\n| 10 | Thunder |", null));
		yield return Item("potion-of-resistance-acid", "potion-of-resistance", 1, MagicItemType.Potion, ItemRarity.Uncommon, false, ContentSource.Srd51,
			null,
			("Pozione di resistenza (acido)", "Pozione, non comune",
			""),
			("Potion of Acid Resistance", "Potion, uncommon",
			"", null));
		yield return Item("potion-of-resistance-cold", "potion-of-resistance", 2, MagicItemType.Potion, ItemRarity.Uncommon, false, ContentSource.Srd51,
			null,
			("Pozione di resistenza (freddo)", "Pozione, non comune",
			""),
			("Potion of Cold Resistance", "Potion, uncommon",
			"", null));
		yield return Item("potion-of-resistance-fire", "potion-of-resistance", 3, MagicItemType.Potion, ItemRarity.Uncommon, false, ContentSource.Srd51,
			null,
			("Pozione di resistenza (fuoco)", "Pozione, non comune",
			""),
			("Potion of Fire Resistance", "Potion, uncommon",
			"", null));
		yield return Item("potion-of-resistance-force", "potion-of-resistance", 4, MagicItemType.Potion, ItemRarity.Uncommon, false, ContentSource.Srd51,
			null,
			("Pozione di resistenza (forza)", "Pozione, non comune",
			""),
			("Potion of Force Resistance", "Potion, uncommon",
			"", null));
		yield return Item("potion-of-resistance-lightning", "potion-of-resistance", 5, MagicItemType.Potion, ItemRarity.Uncommon, false, ContentSource.Srd51,
			null,
			("Pozione di resistenza (fulmine)", "Pozione, non comune",
			""),
			("Potion of Lightning Resistance", "Potion, uncommon",
			"", null));
		yield return Item("potion-of-resistance-necrotic", "potion-of-resistance", 6, MagicItemType.Potion, ItemRarity.Uncommon, false, ContentSource.Srd51,
			null,
			("Pozione di resistenza (necrotico)", "Pozione, non comune",
			""),
			("Potion of Necrotic Resistance", "Potion, uncommon",
			"", null));
		yield return Item("potion-of-resistance-poison", "potion-of-resistance", 7, MagicItemType.Potion, ItemRarity.Uncommon, false, ContentSource.Srd51,
			null,
			("Pozione di resistenza (veleno)", "Pozione, non comune",
			""),
			("Potion of Poison Resistance", "Potion, uncommon",
			"", null));
		yield return Item("potion-of-resistance-psychic", "potion-of-resistance", 8, MagicItemType.Potion, ItemRarity.Uncommon, false, ContentSource.Srd51,
			null,
			("Pozione di resistenza (psichico)", "Pozione, non comune",
			""),
			("Potion of Psychic Resistance", "Potion, uncommon",
			"", null));
		yield return Item("potion-of-resistance-radiant", "potion-of-resistance", 9, MagicItemType.Potion, ItemRarity.Uncommon, false, ContentSource.Srd51,
			null,
			("Pozione di resistenza (radioso)", "Pozione, non comune",
			""),
			("Potion of Radiant Resistance", "Potion, uncommon",
			"", null));
		yield return Item("potion-of-resistance-thunder", "potion-of-resistance", 10, MagicItemType.Potion, ItemRarity.Uncommon, false, ContentSource.Srd51,
			null,
			("Pozione di resistenza (tuono)", "Pozione, non comune",
			""),
			("Potion of Thunder Resistance", "Potion, uncommon",
			"", null));
	}
}
