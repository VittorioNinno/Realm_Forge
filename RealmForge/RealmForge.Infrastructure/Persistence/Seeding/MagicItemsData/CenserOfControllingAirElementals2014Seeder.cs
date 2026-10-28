using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Censer of Controlling Air Elementals (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class CenserOfControllingAirElementals2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("censer-of-controlling-air-elementals", null, 0, MagicItemType.WondrousItem, ItemRarity.Rare, false, ContentSource.Srd51,
			null,
			("Incensiere del controllo degli elementali dell'aria", "Oggetto meraviglioso, raro",
			"Quando il personaggio brucia dell'incenso in questo incensiere, può usare un'azione per pronunciare la sua parola d'ordine ed evocare un elementale dell'aria, come se avesse lanciato l'incantesimo *evoca elementale.* L'incensiere non può essere riutilizzato in questo modo fino all'alba successiva.\n\nIl recipiente, largo 15 cm e alto 30 cm, somiglia a un calice chiuso da un coperchio decorato e pesa 0,5 kg.", null),
			("Censer of Controlling Air Elementals", "Wondrous item, rare",
			"While incense is burning in this censer, you can use an action to speak the censer's command word and summon an air elemental, as if you had cast the conjure elemental spell. The censer can't be used this way again until the next dawn.\n\nThis 6-inch-wide, 1-foot-high vessel resembles a chalice with a decorated lid. It weighs 1 pound.", null));
	}
}
