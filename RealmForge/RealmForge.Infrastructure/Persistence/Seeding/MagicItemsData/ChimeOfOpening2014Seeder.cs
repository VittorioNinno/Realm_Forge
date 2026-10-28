using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Chime of Opening (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class ChimeOfOpening2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("chime-of-opening", null, 0, MagicItemType.WondrousItem, ItemRarity.Rare, false, ContentSource.Srd51,
			null,
			("Campana dell'apertura", "Oggetto meraviglioso, raro",
			"Questo tubo cavo di metallo è lungo circa 30 cm e pesa 0,5 kg. Il personaggio può usare un'azione per colpire la campana, orientandola verso un oggetto apribile situato entro 36 metri da lui: una porta, un coperchio o una serratura. La campana emette una nota squillante e apre una serratura o un chiavistello posizionato sull'oggetto, purché il suono non sia impossibilitato a raggiungerlo. Se non resta nessun'altra serratura o chiavistello, l'oggetto si apre.\n\nLa campana può essere usata dieci volte. Dopo il decimo uso, si crepa e diventa inutilizzabile."),
			("Chime of Opening", "Wondrous item, rare",
			"This hollow metal tube measures about 1 foot long and weighs 1 pound. You can strike it as an action, pointing it at an object within 120 feet of you that can be opened, such as a door, lid, or lock. The chime issues a clear tone, and one lock or latch on the object opens unless the sound can't reach the object. If no locks or latches remain, the object itself opens.\n\nThe chime can be used ten times. After the tenth time, it cracks and becomes useless.", null));
	}
}
