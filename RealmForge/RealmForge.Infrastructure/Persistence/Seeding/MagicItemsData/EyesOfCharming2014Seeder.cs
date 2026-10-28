using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Eyes of Charming (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class EyesOfCharming2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("eyes-of-charming", null, 0, MagicItemType.WondrousItem, ItemRarity.Uncommon, true, ContentSource.Srd51,
			Charges(3, ItemRecharge.LongRest, null),
			("Lenti dello charme", "Oggetto meraviglioso, non comune (richiede sintonia)",
			"Queste lenti di cristallo si adattano agli occhi di chi le indossa. Possiedono 3 cariche. Quando il personaggio le indossa, può usare un'azione per consumare 1 carica e lanciare l'incantesimo *charme su persone* (CD del tiro salvezza 13) su un umanoide situato entro 9 metri da lui, purché siano in grado di vedersi a vicenda. Le lenti recuperano tutte le cariche consumate all'alba di ogni giorno."),
			("Eyes of Charming", "Wondrous item, uncommon (requires attunement)",
			"These crystal lenses fit over the eyes. They have 3 charges. While wearing them, you can expend 1 charge as an action to cast the charm person spell (save DC 13) on a humanoid within 30 feet of you, provided that you and the target can see each other. The lenses regain all expended charges daily at dawn.", null));
	}
}
