using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Staff of Frost (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class StaffOfFrost2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("staff-of-frost", null, 0, MagicItemType.Staff, ItemRarity.VeryRare, true, ContentSource.Srd51,
			Charges(10, ItemRecharge.LongRest, "1d6+4"),
			("Bastone del gelo", "Bastone, molto raro (richiede sintonia con un druido, un mago, uno stregone o un warlock)",
			"Mentre il personaggio impugna questo bastone, ottiene resistenza ai danni da freddo.\n\nIl bastone possiede 10 cariche. Mentre il personaggio lo impugna, può usare un'azione per consumare 1 o più delle sue cariche e lanciare uno dei seguenti incantesimi usando la CD del tiro salvezza sull'incantesimo: *cono di freddo* (5 cariche), *muro di ghiaccio* (4 cariche), *nube di nebbia* (1 carica) o *tempesta di ghiaccio* (4 cariche).\n\nAll'alba di ogni giorno, il bastone recupera 1d6 + 4 cariche consumate. Se il personaggio consuma l'ultima carica, deve tirare un d20; se ottiene 1, il bastone si trasforma in acqua e viene distrutto."),
			("Staff of Frost", "Staff, very rare (requires attunement by a druid, sorcerer, warlock, or wizard)",
			"You have resistance to cold damage while you hold this staff.\n\nThe staff has 10 charges. While holding it, you can use an action to expend 1 or more of its charges to cast one of the following spells from it, using your spell save DC: cone of cold (5 charges), fog cloud (1 charge), ice storm (4 charges), or wall of ice (4 charges).\n\nThe staff regains 1d6 + 4 expended charges daily at dawn. If you expend the last charge, roll a d20. On a 1, the staff turns to water and is destroyed.", null));
	}
}
