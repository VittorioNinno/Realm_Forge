using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Bowl of Commanding Water Elementals (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class BowlOfCommandingWaterElementals2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("bowl-of-commanding-water-elementals", null, 0, MagicItemType.WondrousItem, ItemRarity.Rare, false, ContentSource.Srd51,
			null,
			("Boccia del comando degli elementali dell'acqua", "Oggetto meraviglioso, raro",
			"Quando la boccia è piena d'acqua, il personaggio può usare un'azione per pronunciare la sua parola d'ordine ed evocare un elementale dell'acqua, come se avesse lanciato l'incantesimo *evoca elementale.* La boccia non può essere riutilizzata in questo modo fino all'alba successiva.\n\nLa boccia ha un diametro di circa 30 cm ed è profonda 15 cm. Pesa 1,5 kg e ha una capienza di 12 litri circa.", null),
			("Bowl of Commanding Water Elementals", "Wondrous item, rare",
			"While this bowl is filled with water, you can use an action to speak the bowl's command word and summon a water elemental, as if you had cast the conjure elemental spell. The bowl can't be used this way again until the next dawn.\n\nThe bowl is about 1 foot in diameter and half as deep. It weighs 3 pounds and holds about 3 gallons.", null));
	}
}
