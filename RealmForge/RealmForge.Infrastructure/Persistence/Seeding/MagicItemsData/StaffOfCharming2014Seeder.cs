using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Staff of Charming (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class StaffOfCharming2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("staff-of-charming", null, 0, MagicItemType.Staff, ItemRarity.Rare, true, ContentSource.Srd51,
			Charges(10, ItemRecharge.LongRest, "1d8+2"),
			("Bastone dello charme", "Bastone, raro (richiede sintonia con un bardo, un chierico, un druido, un mago, uno stregone o un warlock)",
			"Mentre il personaggio impugna questo bastone, può usare un'azione e consumare 1 delle sue 10 cariche per lanciare con esso *charme su persone, comando* o *comprensione dei linguaggi* usando la sua CD del tiro salvezza sull'incantesimo. Il bastone può anche essere usato come un bastone ferrato magico.\n\nSe il personaggio impugna il bastone e fallisce un tiro salvezza contro un incantesimo di ammaliamento che ha solo lui come bersaglio, può trasformare il tiro salvezza fallito in un successo. Una volta usata, quest'azione non può essere riutilizzata fino all'alba successiva. Se il personaggio supera il tiro salvezza contro un incantesimo di ammaliamento che ha solo lui come bersaglio, con o senza l'intervento del bastone, può usare la sua reazione e consumare 1 carica del bastone per riflettere l'incantesimo contro il suo incantatore, come se fosse stato il personaggio a lanciarlo.\n\nIl bastone recupera 1d8 + 2 cariche consumate all'alba di ogni giorno. Se il personaggio consuma l'ultima carica, deve tirare un d20; con un 1, il bastone diventa un bastone ferrato non magico.", null),
			("Staff of Charming", "Staff, rare (requires attunement by a bard, cleric, druid, sorcerer, warlock, or wizard)",
			"While holding this staff, you can use an action to expend 1 of its 10 charges to cast charm person, command, or comprehend languages from it using your spell save DC. The staff can also be used as a magic quarterstaff.\n\nIf you are holding the staff and fail a saving throw against an enchantment spell that targets only you, you can turn your failed save into a successful one. You can't use this property of the staff again until the next dawn. If you succeed on a save against an enchantment spell that targets only you, with or without the staff's intervention, you can use your reaction to expend 1 charge from the staff and turn the spell back on its caster as if you had cast the spell.\n\nThe staff regains 1d8 + 2 expended charges daily at dawn. If you expend the last charge, roll a d20. On a 1, the staff becomes a nonmagical quarterstaff.", null));
	}
}
