using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Wand of Web (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class WandOfWeb2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("wand-of-web", null, 0, MagicItemType.Wand, ItemRarity.Uncommon, true, ContentSource.Srd51,
			Charges(7, ItemRecharge.LongRest, "1d6+1"),
			("Bacchetta della ragnatela", "Bacchetta, non comune (richiede sintonia con un incantatore)",
			"Questa bacchetta possiede 7 cariche. Mentre il personaggio la impugna, può usare un'azione per consumare 1 carica e lanciare con essa l'incantesimo *ragnatela* (CD del tiro salvezza 15).\n\nAll'alba di ogni giorno, la bacchetta recupera 1d6 + 1 cariche consumate. Se il personaggio consuma l'ultima carica, deve tirare un d20: se ottiene 1, la bacchetta diventa cenere e viene distrutta.", null),
			("Wand of Web", "Wand, uncommon (requires attunement by a spellcaster)",
			"This wand has 7 charges. While holding it, you can use an action to expend 1 of its charges to cast the web spell (save DC 15) from it.\n\nThe wand regains 1d6 + 1 expended charges daily at dawn. If you expend the wand's last charge, roll a d20. On a 1, the wand crumbles into ashes and is destroyed.", null));
	}
}
