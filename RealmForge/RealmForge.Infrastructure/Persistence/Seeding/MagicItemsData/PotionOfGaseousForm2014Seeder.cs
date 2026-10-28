using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Potion of Gaseous Form (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class PotionOfGaseousForm2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("potion-of-gaseous-form", null, 0, MagicItemType.Potion, ItemRarity.Rare, false, ContentSource.Srd51,
			null,
			("Pozione della forma gassosa", "Pozione, rara",
			"Quando il personaggio beve questa pozione, ottiene l'effetto dell'incantesimo *forma gassosa* per 1 ora (non è richiesta la concentrazione) o finché non vi pone fine con un'azione bonus. Il contenitore di questa pozione sembra pieno di nebbia che ondeggia e si riversa all'esterno come se fosse acqua."),
			("Potion of Gaseous Form", "Potion, rare",
			"When you drink this potion, you gain the effect of the gaseous form spell for 1 hour (no concentration required) or until you end the effect as a bonus action. This potion's container seems to hold fog that moves and pours like water.", null));
	}
}
