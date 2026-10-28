using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Staff of Striking (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class StaffOfStriking2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("staff-of-striking", null, 0, MagicItemType.Staff, ItemRarity.VeryRare, true, ContentSource.Srd51,
			Charges(10, ItemRecharge.LongRest, "1d6+4", Effect(MagicEffectKind.AttackAndDamage, 3)),
			("Bastone del colpo possente", "Bastone, molto raro (richiede sintonia)",
			"Questo bastone può essere impugnato come un bastone ferrato magico che garantisce un bonus di +3 ai tiri per colpire e ai tiri per i danni effettuati con esso.\n\nIl bastone possiede 10 cariche. Quando il personaggio colpisce con un attacco in mischia usando il bastone, può consumare fino a 3 delle sue cariche. Per ogni carica consumata, il bersaglio subisce 1d6 danni da forza extra. All'alba di ogni giorno, il bastone recupera 1d6 + 4 cariche consumate. Se il personaggio consuma l'ultima carica, deve tirare un d20; con un 1, il bastone diventa un bastone ferrato non magico."),
			("Staff of Striking", "Staff, very rare (requires attunement)",
			"This staff can be wielded as a magic quarterstaff that grants a +3 bonus to attack and damage rolls made with it.\n\nThe staff has 10 charges. When you hit with a melee attack using it, you can expend up to 3 of its charges. For each charge you expend, the target takes an extra 1d6 force damage. The staff regains 1d6 + 4 expended charges daily at dawn. If you expend the last charge, roll a d20. On a 1, the staff becomes a nonmagical quarterstaff.", null));
	}
}
