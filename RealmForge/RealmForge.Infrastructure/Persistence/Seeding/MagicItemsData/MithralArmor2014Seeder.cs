using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Mithral Armor (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class MithralArmor2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("mithral-armor", null, 0, MagicItemType.Armor, ItemRarity.Uncommon, false, ContentSource.Srd51,
			null,
			("Armatura in Mithral", "Armatura (media o pesante, ma non di pelle), non comune",
			"Il mithral è un metallo flessibile e leggero. Un giaco di maglia o una corazza di piastre in mithral possono essere indossate sotto gli abiti normali. Se un'armatura normalmente impone svantaggio alle prove di Destrezza (Furtività) o prevede un requisito di Forza, la sua versione di mithral non fa né l'una né l'altra cosa."),
			("Mithral Armor", "Armor (medium or heavy), uncommon",
			"Mithral is a light, flexible metal. A mithral chain shirt or breastplate can be worn under normal clothes. If the armor normally imposes disadvantage on Dexterity (Stealth) checks or has a Strength requirement, the mithral version of the armor doesn't.", null));
	}
}
