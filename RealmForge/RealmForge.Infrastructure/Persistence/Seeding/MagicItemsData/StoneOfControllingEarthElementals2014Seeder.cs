using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Stone of Controlling Earth Elementals (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class StoneOfControllingEarthElementals2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("stone-of-controlling-earth-elementals", null, 0, MagicItemType.WondrousItem, ItemRarity.Rare, false, ContentSource.Srd51,
			null,
			("Pietra del controllo degli elementali della terra", "Oggetto meraviglioso, raro",
			"Se la pietra tocca il terreno, il personaggio può usare un'azione per pronunciare la parola d'ordine ed evocare un elementale della terra, come se avesse lanciato l'incantesimo *evoca elementale.* La pietra non può più essere utilizzata in questo modo fino all'alba successiva. La pietra pesa 2,5 kg."),
			("Stone of Controlling Earth Elementals", "Wondrous item, rare",
			"If the stone is touching the ground, you can use an action to speak its command word and summon an earth elemental, as if you had cast the conjure elemental spell. The stone can't be used this way again until the next dawn. The stone weighs 5 pounds.", null));
	}
}
