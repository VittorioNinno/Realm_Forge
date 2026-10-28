using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Manual of Golems (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class ManualOfGolems2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("manual-of-golems", null, 0, MagicItemType.WondrousItem, ItemRarity.VeryRare, false, ContentSource.Srd51,
			null,
			("Manuale dei golem", "Oggetto meraviglioso, molto raro",
			"Questo tomo contiene le informazioni e i rituali necessari alla creazione di un particolare tipo di golem. Il GM sceglie il tipo di golem o lo determina casualmente. Per decifrare e usare il manuale, il personaggio deve essere un incantatore e possedere almeno due slot incantesimo di 5° livello. Una creatura che non è in grado di usare il *manuale dei golem* e tenta di leggerlo comunque subisce 6d6 danni psichici.\n\n| d20 | Golem | Tempo | Costo |\n|---|---|---|---|\n| 1–5 | Argilla | 30 giorni | 65.000 mo |\n| 6–17 | Carne | 60 giorni | 50.000 mo |\n| 18 | Ferro | 120 giorni | 100.000 mo |\n| 19–20 | Pietra | 90 giorni | 80.000 mo |\n\nPer creare un golem, il personaggio deve trascorrere il tempo indicato dalla tabella a lavorare ininterrottamente con il manuale a portata di mano e riposando al massimo per 8 ore al giorno. Deve inoltre pagare la somma specificata per procurarsi i materiali necessari.\n\nUna volta terminato il processo di creazione del golem, il libro viene consumato da una fiammata soprannaturale. Il golem si anima quando su di esso vengono sparse le ceneri del manuale. Il golem è sotto il controllo del personaggio e comprende ed esegue i suoi comandi verbali.", null),
			("Manual of Golems", "Wondrous item, very rare",
			"This tome contains information and incantations necessary to make a particular type of golem. The GM chooses the type or determines it randomly. To decipher and use the manual, you must be a spellcaster with at least two 5th-level spell slots. A creature that can't use a manual of golems and attempts to read it takes 6d6 psychic damage.\n\n| d20 | Golem | Time | Cost |\n|---|---|---|---|\n| 1-5 | Clay | 30 days | 65,000 gp |\n| 6-17 | Flesh | 60 days | 50,000 gp |\n| 18 | Iron | 120 days | 100,000 gp |\n| 19-20 | Stone | 90 days | 80,000 gp |\n\nTo create a golem, you must spend the time shown on the table, working without interruption with the manual at hand and resting no more than 8 hours per day. You must also pay the specified cost to purchase supplies.\n\nOnce you finish creating the golem, the book is consumed in eldritch flames. The golem becomes animate when the ashes of the manual are sprinkled on it. It is under your control, and it understands and obeys your spoken commands.", null));
		yield return Item("manual-of-golems-clay", "manual-of-golems", 1, MagicItemType.WondrousItem, ItemRarity.VeryRare, false, ContentSource.Srd51,
			null,
			("Manuale dei golem (argilla)", "Oggetto meraviglioso, molto raro",
			"", null),
			("Manual of Clay Golems", "Wondrous item, very rare",
			"", null));
		yield return Item("manual-of-golems-flesh", "manual-of-golems", 2, MagicItemType.WondrousItem, ItemRarity.VeryRare, false, ContentSource.Srd51,
			null,
			("Manuale dei golem (carne)", "Oggetto meraviglioso, molto raro",
			"", null),
			("Manual of Flesh Golems", "Wondrous item, very rare",
			"", null));
		yield return Item("manual-of-golems-iron", "manual-of-golems", 3, MagicItemType.WondrousItem, ItemRarity.VeryRare, false, ContentSource.Srd51,
			null,
			("Manuale dei golem (ferro)", "Oggetto meraviglioso, molto raro",
			"", null),
			("Manual of Iron Golems", "Wondrous item, very rare",
			"", null));
		yield return Item("manual-of-golems-stone", "manual-of-golems", 4, MagicItemType.WondrousItem, ItemRarity.VeryRare, false, ContentSource.Srd51,
			null,
			("Manuale dei golem (pietra)", "Oggetto meraviglioso, molto raro",
			"", null),
			("Manual of Stone Golems", "Wondrous item, very rare",
			"", null));
	}
}
