using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Belt of Giant Strength (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class BeltOfGiantStrength2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("belt-of-giant-strength", null, 0, MagicItemType.WondrousItem, null, true, ContentSource.Srd51,
			null,
			("Cintura della forza dei giganti", "Oggetto meraviglioso, rarità variabile (richiede sintonia)",
			"Mentre il personaggio indossa questa cintura, il suo punteggio di Forza cambia in un determinato punteggio conferito dalla cintura. Se il punteggio di Forza del personaggio senza cintura è pari o superiore a quello conferito dall'oggetto, non ha alcun effetto.\n\nEsistono sei varietà di questa cintura, corrispondenti per tipo e rarità ai sei tipi di giganti puri esistenti. La *cintura della forza dei giganti delle pietre* e la *cintura della forza dei giganti del gelo* sono diverse nell'aspetto, ma hanno lo stesso effetto.\n\n| Tipo | Forza | Rarità |\n|---|---|---|\n| Giganti delle colline | 21 | Rara |\n| Giganti delle pietre/del gelo | 23 | Molto rara |\n| Giganti del fuoco | 25 | Molto rara |\n| Giganti delle nuvole | 27 | Leggendaria |\n| Giganti delle tempeste | 29 | Leggendaria |", null),
			("Belt of Giant Strength", "Wondrous item, rarity varies (requires attunement)",
			"While wearing this belt, your Strength score changes to a score granted by the belt. If your Strength is already equal to or greater than the belt's score, the item has no effect on you.\n\nSix varieties of this belt exist, corresponding with and having rarity according to The Six kinds of true Giants. The belt of Stone Giant Strength and the belt of Frost Giant Strength look different, but they have the same effect.\n\n| Type | Strength | Rarity |\n|---|---|---|\n| Hill Giant | 21 | Rare |\n| Stone Giant / Frost Giant | 23 | Very Rare |\n| Fire Giant | 25 | Very Rare |\n| Cloud Giant | 27 | Legendary |\n| Storm Giant | 29 | Legendary |", null));
		yield return Item("belt-of-giant-strength-hill", "belt-of-giant-strength", 1, MagicItemType.WondrousItem, ItemRarity.Rare, true, ContentSource.Srd51,
			Magic(Ability(MagicEffectKind.SetAbilityScore, 21, AbilityScore.Strength)),
			("Cintura della forza dei giganti delle colline", "Oggetto meraviglioso, raro (richiede sintonia)",
			"", null),
			("Belt of Hill Giant Strength", "Wondrous item, rare (requires attunement)",
			"", null));
		yield return Item("belt-of-giant-strength-stone", "belt-of-giant-strength", 2, MagicItemType.WondrousItem, ItemRarity.VeryRare, true, ContentSource.Srd51,
			Magic(Ability(MagicEffectKind.SetAbilityScore, 23, AbilityScore.Strength)),
			("Cintura della forza dei giganti delle pietre", "Oggetto meraviglioso, molto raro (richiede sintonia)",
			"", null),
			("Belt of Stone Giant Strength", "Wondrous item, very rare (requires attunement)",
			"", null));
		yield return Item("belt-of-giant-strength-frost", "belt-of-giant-strength", 3, MagicItemType.WondrousItem, ItemRarity.VeryRare, true, ContentSource.Srd51,
			Magic(Ability(MagicEffectKind.SetAbilityScore, 23, AbilityScore.Strength)),
			("Cintura della forza dei giganti del gelo", "Oggetto meraviglioso, molto raro (richiede sintonia)",
			"", null),
			("Belt of Frost Giant Strength", "Wondrous item, very rare (requires attunement)",
			"", null));
		yield return Item("belt-of-giant-strength-fire", "belt-of-giant-strength", 4, MagicItemType.WondrousItem, ItemRarity.VeryRare, true, ContentSource.Srd51,
			Magic(Ability(MagicEffectKind.SetAbilityScore, 25, AbilityScore.Strength)),
			("Cintura della forza dei giganti del fuoco", "Oggetto meraviglioso, molto raro (richiede sintonia)",
			"", null),
			("Belt of Fire Giant Strength", "Wondrous item, very rare (requires attunement)",
			"", null));
		yield return Item("belt-of-giant-strength-cloud", "belt-of-giant-strength", 5, MagicItemType.WondrousItem, ItemRarity.Legendary, true, ContentSource.Srd51,
			Magic(Ability(MagicEffectKind.SetAbilityScore, 27, AbilityScore.Strength)),
			("Cintura della forza dei giganti delle nuvole", "Oggetto meraviglioso, leggendario (richiede sintonia)",
			"", null),
			("Belt of Cloud Giant Strength", "Wondrous item, legendary (requires attunement)",
			"", null));
		yield return Item("belt-of-giant-strength-storm", "belt-of-giant-strength", 6, MagicItemType.WondrousItem, ItemRarity.Legendary, true, ContentSource.Srd51,
			Magic(Ability(MagicEffectKind.SetAbilityScore, 29, AbilityScore.Strength)),
			("Cintura della forza dei giganti delle tempeste", "Oggetto meraviglioso, leggendario (richiede sintonia)",
			"", null),
			("Belt of Storm Giant Strength", "Wondrous item, legendary (requires attunement)",
			"", null));
	}
}
