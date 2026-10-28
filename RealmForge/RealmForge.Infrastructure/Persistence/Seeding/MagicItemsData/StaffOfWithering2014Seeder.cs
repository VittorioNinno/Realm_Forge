using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Staff of Withering (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class StaffOfWithering2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("staff-of-withering", null, 0, MagicItemType.Staff, ItemRarity.Rare, true, ContentSource.Srd51,
			Charges(3, ItemRecharge.LongRest, "1d3"),
			("Bastone del deperimento", "Bastone, raro (richiede sintonia con un chierico, un druido o un warlock)",
			"Questo bastone possiede 3 cariche e recupera 1d3 cariche consumate all'alba di ogni giorno.\n\nIl bastone può anche essere brandito come un bastone ferrato magico. Se il colpo va a segno, infligge danni come un normale bastone ferrato e il personaggio può consumare 1 carica per infliggere al bersaglio 2d10 danni necrotici extra. Inoltre, il bersaglio deve superare un tiro salvezza su Costituzione con CD 15, altrimenti ha svantaggio per 1 ora a qualsiasi prova di caratteristica o tiro salvezza su Forza o Costituzione.", null),
			("Staff of Withering", "Staff, rare (requires attunement by a cleric, druid, or warlock)",
			"This staff has 3 charges and regains 1d3 expended charges daily at dawn.\n\nThe staff can be wielded as a magic quarterstaff. On a hit, it deals damage as a normal quarterstaff, and you can expend 1 charge to deal an extra 2d10 necrotic damage to the target. In addition, the target must succeed on a DC 15 Constitution saving throw or have disadvantage for 1 hour on any ability check or saving throw that uses Strength or Constitution.", null));
	}
}
