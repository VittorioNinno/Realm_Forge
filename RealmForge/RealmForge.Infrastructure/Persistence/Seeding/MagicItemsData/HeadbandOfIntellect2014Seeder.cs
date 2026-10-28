using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Headband of Intellect (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class HeadbandOfIntellect2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("headband-of-intellect", null, 0, MagicItemType.WondrousItem, ItemRarity.Uncommon, true, ContentSource.Srd51,
			Magic(Ability(MagicEffectKind.SetAbilityScore, 19, AbilityScore.Intelligence)),
			("Fascia dell'intelletto", "Oggetto meraviglioso, non comune (richiede sintonia)",
			"Finché il personaggio indossa questa fascia, il suo punteggio di Intelligenza è pari a 19. Se il suo punteggio di Intelligenza è già pari o superiore a 19, la fascia non ha alcun effetto.", null),
			("Headband of Intellect", "Wondrous item, uncommon (requires attunement)",
			"Your Intelligence score is 19 while you wear this headband. It has no effect on you if your Intelligence is already 19 or higher.", null));
	}
}
