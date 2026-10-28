using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Staff of Healing (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class StaffOfHealing2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("staff-of-healing", null, 0, MagicItemType.Staff, ItemRarity.Rare, true, ContentSource.Srd51,
			Charges(10, ItemRecharge.LongRest, "1d6+4"),
			("Bastone della guarigione", "Bastone, raro (richiede sintonia con un bardo, un chierico o un druido)",
			"Questo bastone possiede 10 cariche. Mentre il personaggio lo impugna, può usare un'azione per consumare 1 o più delle sue cariche e lanciare uno dei seguenti incantesimi usando la CD del tiro salvezza sull'incantesimo e il modificatore di caratteristica da incantatore: *cura ferite* (1 carica per livello di incantesimo, fino al 4°), *cura ferite di massa* (5 cariche) o *ristorare inferiore* (2 cariche).\n\nAll'alba di ogni giorno, il bastone recupera 1d6 + 4 cariche consumate. Se il personaggio consuma l'ultima carica, deve tirare un d20; se ottiene 1, il bastone svanisce in un lampo di luce ed è perduto per sempre.", null),
			("Staff of Healing", "Staff, rare (requires attunement by a bard, cleric, or druid)",
			"This staff has 10 charges. While holding it, you can use an action to expend 1 or more of its charges to cast one of the following spells from it, using your spell save DC and spellcasting ability modifier: cure wounds (1 charge per spell level, up to 4th), lesser restoration (2 charges), or mass cure wounds (5 charges).\n\nThe staff regains 1d6 + 4 expended charges daily at dawn. If you expend the last charge, roll a d20. On a 1, the staff vanishes in a flash of light, lost forever.", null));
	}
}
