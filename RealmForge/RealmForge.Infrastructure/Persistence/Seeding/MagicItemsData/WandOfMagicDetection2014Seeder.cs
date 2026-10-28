using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Wand of Magic Detection (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class WandOfMagicDetection2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("wand-of-magic-detection", null, 0, MagicItemType.Wand, ItemRarity.Uncommon, false, ContentSource.Srd51,
			Charges(3, ItemRecharge.LongRest, "1d3"),
			("Bacchetta di individuazione del magico", "Bacchetta, non comune",
			"Questa bacchetta possiede 3 cariche. Mentre il personaggio la impugna, può usare un'azione per consumare 1 carica e lanciare con essa l'incantesimo *individuazione del magico.* La bacchetta recupera 1d3 cariche consumate all'alba di ogni giorno."),
			("Wand of Magic Detection", "Wand, uncommon",
			"This wand has 3 charges. While holding it, you can expend 1 charge as an action to cast the detect magic spell from it. The wand regains 1d3 expended charges daily at dawn.", null));
	}
}
