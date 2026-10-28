using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Brazier of Commanding Fire Elementals (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class BrazierOfCommandingFireElementals2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("brazier-of-commanding-fire-elementals", null, 0, MagicItemType.WondrousItem, ItemRarity.Rare, false, ContentSource.Srd51,
			null,
			("Braciere del comando degli elementali del fuoco", "Oggetto meraviglioso, raro",
			"Quando un fuoco arde in questo braciere di ottone, il personaggio può usare un'azione per pronunciarne la parola d'ordine ed evocare un elementale del fuoco, come se avesse lanciato l'incantesimo *evoca elementale.* Il braciere non può essere riutilizzato in questo modo fino all'alba successiva.\n\nIl braciere pesa 2,5 kg."),
			("Brazier of Commanding Fire Elementals", "Wondrous item, rare",
			"While a fire burns in this brass brazier, you can use an action to speak the brazier's command word and summon a fire elemental, as if you had cast the conjure elemental spell. The brazier can't be used this way again until the next dawn.\n\nThe brazier weighs 5 pounds.", null));
	}
}
