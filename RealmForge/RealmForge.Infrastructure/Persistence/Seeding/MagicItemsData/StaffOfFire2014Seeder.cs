using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Staff of Fire (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class StaffOfFire2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("staff-of-fire", null, 0, MagicItemType.Staff, ItemRarity.VeryRare, true, ContentSource.Srd51,
			Charges(10, ItemRecharge.LongRest, "1d6+4"),
			("Bastone del fuoco", "Bastone, molto raro (richiede sintonia con un druido, un mago, uno stregone o un warlock)",
			"Mentre il personaggio impugna questo bastone, ottiene resistenza ai danni da fuoco.\n\nIl bastone possiede 10 cariche. Mentre il personaggio lo impugna, può usare un'azione per consumare 1 o più delle sue cariche e lanciare uno dei seguenti incantesimi usando la CD del tiro salvezza sull'incantesimo: *mani brucianti* (1 carica), *muro di fuoco* (4 cariche) o *palla di fuoco* (3 cariche).\n\nAll'alba di ogni giorno, il bastone recupera 1d6 + 4 cariche consumate. Se il personaggio consuma l'ultima carica, deve tirare un d20; se ottiene 1, il bastone si annerisce, viene ridotto in cenere ed è distrutto."),
			("Staff of Fire", "Staff, very rare (requires attunement by a druid, sorcerer, warlock, or wizard)",
			"You have resistance to fire damage while you hold this staff.\n\nThe staff has 10 charges. While holding it, you can use an action to expend 1 or more of its charges to cast one of the following spells from it, using your spell save DC: burning hands (1 charge), fireball (3 charges), or wall of fire (4 charges).\n\nThe staff regains 1d6 + 4 expended charges daily at dawn. If you expend the last charge, roll a d20. On a 1, the staff blackens, crumbles into cinders, and is destroyed.", null));
	}
}
