using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Carpet of Flying (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class CarpetOfFlying2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("carpet-of-flying", null, 0, MagicItemType.WondrousItem, ItemRarity.VeryRare, false, ContentSource.Srd51,
			null,
			("Tappeto volante", "Oggetto meraviglioso, molto raro",
			"Con un'azione, il personaggio può pronunciare la parola d'ordine del tappeto per fare in modo che fluttui in volo. Il tappeto si muove in base ai comandi verbali impartiti dal personaggio, che deve trovarsi entro 9 metri da esso.\n\nEsistono *tappeti volanti* di quattro misure diverse. Il GM può scegliere le dimensioni di un determinato tappeto o determinarle casualmente.\n\n| d100 | Dimensioni | Capacità di trasporto | Velocità di volare |\n|---|---|---|---|\n| 01–20 | 90 cm × 150 cm | 100 kg | 24 metri |\n| 21–55 | 120 cm × 80 cm | 200 kg | 18 metri |\n| 56–80 | 150 cm × 210 cm | 300 kg | 12 metri |\n| 81–100 | 180 cm × 270 cm | 400 kg | 9 metri |\n\nUn tappeto può trasportare fino al doppio del peso indicato in tabella, ma se trasporta più di quanto indicato vola a velocità dimezzata."),
			("Carpet of Flying", "Wondrous item, very rare",
			"You can speak the carpet's command word as an  action to make the carpet hover and fly. It moves according to your spoken directions, provided that you are within 30 feet of it.\n\nFour sizes of carpet of flying exist. The GM chooses the size of a given carpet or determines it randomly.\n\n| d100 | Size | Capacity | Flying Speed |\n|---|---|---|---|\n| 01-20 | 3 ft. × 5 ft. | 200 lb. | 80 feet |\n| 21-55 | 4 ft. × 6 ft. | 400 lb. | 60 feet |\n| 56-80 | 5 ft. × 7 ft. | 600 lb. | 40 feet |\n| 81-100 | 6 ft. × 9 ft. | 800 lb. | 30 feet |\n\nA carpet can carry up to twice the weight shown on the table, but it flies at half speed if it carries more than its normal capacity.", null));
		yield return Item("carpet-of-flying-3x5", "carpet-of-flying", 1, MagicItemType.WondrousItem, ItemRarity.VeryRare, false, ContentSource.Srd51,
			null,
			("Tappeto volante (90 cm × 150 cm)", "Oggetto meraviglioso, molto raro",
			""),
			("Carpet of Flying (3 ft. × 5 ft.)", "Wondrous item, very rare",
			"", null));
		yield return Item("carpet-of-flying-4x6", "carpet-of-flying", 2, MagicItemType.WondrousItem, ItemRarity.VeryRare, false, ContentSource.Srd51,
			null,
			("Tappeto volante (120 cm × 180 cm)", "Oggetto meraviglioso, molto raro",
			""),
			("Carpet of Flying (4 ft. × 6 ft.)", "Wondrous item, very rare",
			"", null));
		yield return Item("carpet-of-flying-5x7", "carpet-of-flying", 3, MagicItemType.WondrousItem, ItemRarity.VeryRare, false, ContentSource.Srd51,
			null,
			("Tappeto volante (150 cm × 210 cm)", "Oggetto meraviglioso, molto raro",
			""),
			("Carpet of Flying (5 ft. × 7 ft.)", "Wondrous item, very rare",
			"", null));
		yield return Item("carpet-of-flying-6x9", "carpet-of-flying", 4, MagicItemType.WondrousItem, ItemRarity.VeryRare, false, ContentSource.Srd51,
			null,
			("Tappeto volante (180 cm × 270 cm)", "Oggetto meraviglioso, molto raro",
			""),
			("Carpet of Flying (6 ft. × 9 ft.)", "Wondrous item, very rare",
			"", null));
	}
}
