using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Ring of Resistance (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class RingOfResistance2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("ring-of-resistance", null, 0, MagicItemType.Ring, ItemRarity.Rare, true, ContentSource.Srd51,
			null,
			("Anello di resistenza", "Anello, raro (richiede sintonia)",
			"Finché il personaggio indossa questo anello, ottiene resistenza a un tipo di danno. La gemma dell'anello indica il tipo di danno, che il GM può scegliere liberamente o determinare casualmente.\n\n| d10 | Tipo di danno | Gemma |\n|---|---|---|\n| 1 | Acido | Perla |\n| 2 | Forza | Zaffiro |\n| 3 | Freddo | Tormalina |\n| 4 | Fulmine | Citrino |\n| 5 | Fuoco | Granato |\n| 6 | Necrotico | Giaietto |\n| 7 | Psichico | Giada |\n| 8 | Radioso | Topazio |\n| 9 | Tuono | Spinello |\n| 10 | Veleno | Ametista |", null),
			("Ring of Resistance", "Ring, rare (requires attunement)",
			"You have resistance to one damage type while wearing this ring. The gem in the ring indicates the type, which the GM chooses or determines randomly.\n\n| d10 | Damage Type | Gem |\n|---|---|---|\n| 1 | Acid | Pearl |\n| 2 | Cold | Tourmaline |\n| 3 | Fire | Garnet |\n| 4 | Force | Sapphire |\n| 5 | Lightning | Citrine |\n| 6 | Necrotic | Jet |\n| 7 | Poison | Amethyst |\n| 8 | Psychic | Jade |\n| 9 | Radiant | Topaz |\n| 10 | Thunder | Spinel |", null));
		yield return Item("ring-of-resistance-acid", "ring-of-resistance", 1, MagicItemType.Ring, ItemRarity.Rare, true, ContentSource.Srd51,
			Magic(Resist(DamageType.Acid)),
			("Anello di resistenza (acido)", "Anello, raro (richiede sintonia)",
			"", null),
			("Ring of Acid Resistance", "Ring, rare (requires attunement)",
			"", null));
		yield return Item("ring-of-resistance-cold", "ring-of-resistance", 2, MagicItemType.Ring, ItemRarity.Rare, true, ContentSource.Srd51,
			Magic(Resist(DamageType.Cold)),
			("Anello di resistenza (freddo)", "Anello, raro (richiede sintonia)",
			"", null),
			("Ring of Cold Resistance", "Ring, rare (requires attunement)",
			"", null));
		yield return Item("ring-of-resistance-fire", "ring-of-resistance", 3, MagicItemType.Ring, ItemRarity.Rare, true, ContentSource.Srd51,
			Magic(Resist(DamageType.Fire)),
			("Anello di resistenza (fuoco)", "Anello, raro (richiede sintonia)",
			"", null),
			("Ring of Fire Resistance", "Ring, rare (requires attunement)",
			"", null));
		yield return Item("ring-of-resistance-force", "ring-of-resistance", 4, MagicItemType.Ring, ItemRarity.Rare, true, ContentSource.Srd51,
			Magic(Resist(DamageType.Force)),
			("Anello di resistenza (forza)", "Anello, raro (richiede sintonia)",
			"", null),
			("Ring of Force Resistance", "Ring, rare (requires attunement)",
			"", null));
		yield return Item("ring-of-resistance-lightning", "ring-of-resistance", 5, MagicItemType.Ring, ItemRarity.Rare, true, ContentSource.Srd51,
			Magic(Resist(DamageType.Lightning)),
			("Anello di resistenza (fulmine)", "Anello, raro (richiede sintonia)",
			"", null),
			("Ring of Lightning Resistance", "Ring, rare (requires attunement)",
			"", null));
		yield return Item("ring-of-resistance-necrotic", "ring-of-resistance", 6, MagicItemType.Ring, ItemRarity.Rare, true, ContentSource.Srd51,
			Magic(Resist(DamageType.Necrotic)),
			("Anello di resistenza (necrotico)", "Anello, raro (richiede sintonia)",
			"", null),
			("Ring of Necrotic Resistance", "Ring, rare (requires attunement)",
			"", null));
		yield return Item("ring-of-resistance-poison", "ring-of-resistance", 7, MagicItemType.Ring, ItemRarity.Rare, true, ContentSource.Srd51,
			Magic(Resist(DamageType.Poison)),
			("Anello di resistenza (veleno)", "Anello, raro (richiede sintonia)",
			"", null),
			("Ring of Poison Resistance", "Ring, rare (requires attunement)",
			"", null));
		yield return Item("ring-of-resistance-psychic", "ring-of-resistance", 8, MagicItemType.Ring, ItemRarity.Rare, true, ContentSource.Srd51,
			Magic(Resist(DamageType.Psychic)),
			("Anello di resistenza (psichico)", "Anello, raro (richiede sintonia)",
			"", null),
			("Ring of Psychic Resistance", "Ring, rare (requires attunement)",
			"", null));
		yield return Item("ring-of-resistance-radiant", "ring-of-resistance", 9, MagicItemType.Ring, ItemRarity.Rare, true, ContentSource.Srd51,
			Magic(Resist(DamageType.Radiant)),
			("Anello di resistenza (radioso)", "Anello, raro (richiede sintonia)",
			"", null),
			("Ring of Radiant Resistance", "Ring, rare (requires attunement)",
			"", null));
		yield return Item("ring-of-resistance-thunder", "ring-of-resistance", 10, MagicItemType.Ring, ItemRarity.Rare, true, ContentSource.Srd51,
			Magic(Resist(DamageType.Thunder)),
			("Anello di resistenza (tuono)", "Anello, raro (richiede sintonia)",
			"", null),
			("Ring of Thunder Resistance", "Ring, rare (requires attunement)",
			"", null));
	}
}
