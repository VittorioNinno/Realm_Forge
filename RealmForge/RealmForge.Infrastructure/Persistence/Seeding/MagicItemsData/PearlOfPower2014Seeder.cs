using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Pearl of Power (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class PearlOfPower2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("pearl-of-power", null, 0, MagicItemType.WondrousItem, ItemRarity.Uncommon, true, ContentSource.Srd51,
			null,
			("Perla del potere", "Oggetto meraviglioso, non comune (richiede sintonia con un incantatore)",
			"Finché il personaggio porta questa perla sulla sua persona, può usare un'azione per pronunciarne la parola d'ordine e recuperare uno slot incantesimo consumato. Se lo slot consumato era di livello pari o superiore al 4°, il nuovo slot sarà di 3° livello. Una volta usata, la perla non può essere riutilizzata fino all'alba successiva."),
			("Pearl of Power", "Wondrous item, uncommon (requires attunement by a spellcaster)",
			"While this pearl is on your person, you can use an action to speak its command word and regain one expended spell slot. If the expended slot was of 4th level or higher, the new slot is 3rd level. Once you use the pearl, it can't be used again until the next dawn.", null));
	}
}
