using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Plate Armor of Etherealness (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class PlateArmorOfEtherealness2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("plate-armor-of-etherealness", null, 0, MagicItemType.Armor, ItemRarity.Legendary, true, ContentSource.Srd51,
			null,
			("Armatura a piastre della forma eterea", "Armatura (armatura a piastre), leggendaria (richiede sintonia)",
			"Finché il personaggio indossa questa armatura, può usare un'azione per pronunciarne la parola d'ordine e ottenere gli effetti dell'incantesimo *forma eterea* che dura per 10 minuti, finché non toglie l'armatura o finché non usa un'azione per pronunciare di nuovo la sua parola d'ordine. Questa proprietà dell'armatura non può essere riutilizzata fino all'alba successiva."),
			("Plate Armor of Etherealness", "Armor (plate), legendary (requires attunement)",
			"While you're wearing this armor, you can speak its command word as an action to gain the effect of the etherealness spell, which last for 10 minutes or until you remove the armor or use an action to speak the command word again. This property of the armor can't be used again until the next dawn.", null));
	}
}
