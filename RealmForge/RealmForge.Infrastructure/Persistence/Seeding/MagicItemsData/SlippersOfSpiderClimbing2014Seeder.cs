using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Slippers of Spider Climbing (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class SlippersOfSpiderClimbing2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("slippers-of-spider-climbing", null, 0, MagicItemType.WondrousItem, ItemRarity.Uncommon, true, ContentSource.Srd51,
			null,
			("Pantofole del ragno", "Oggetto meraviglioso, non comune (richiede sintonia)",
			"Mentre indossa queste scarpe leggere, il personaggio può muoversi in alto, in basso e lateralmente sulle superfici verticali e a testa in giù sui soffitti mantenendo le mani libere. Inoltre, possiede velocità di scalare pari alla propria velocità base sul terreno. Tuttavia, le pantofole non gli permettono di muoversi in questo modo su una superficie scivolosa, come per esempio una superficie ricoperta di ghiaccio o d'olio."),
			("Slippers of Spider Climbing", "Wondrous item, uncommon (requires attunement)",
			"While you wear these light shoes, you can move up, down, and across vertical surfaces and upside down along ceilings, while leaving your hands free. You have a climbing speed equal to your walking speed. However, the slippers don't allow you to move this way on a slippery surface, such as one covered by ice or oil.", null));
	}
}
