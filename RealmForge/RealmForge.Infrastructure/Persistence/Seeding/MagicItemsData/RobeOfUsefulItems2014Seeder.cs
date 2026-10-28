using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Robe of Useful Items (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class RobeOfUsefulItems2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("robe-of-useful-items", null, 0, MagicItemType.WondrousItem, ItemRarity.Uncommon, false, ContentSource.Srd51,
			null,
			("Tunica degli oggetti utili", "Oggetto meraviglioso, non comune",
			"Su questa tunica sono visibili alcune toppe di varie forme e colori. Finché il personaggio indossa la tunica, può usare un'azione per staccare una delle toppe, trasformandola nell'oggetto o nella creatura che essa raffigura. Quando anche l'ultima toppa viene staccata, la tunica diventa un capo d'abbigliamento comune.\n\nLa tunica possiede due copie di ognuna delle seguenti toppe:\n\n- Pugnale\n\n- Lanterna a lente sporgente (piena e accesa)\n\n- Specchio di acciaio\n\n- Asta da 3 metri\n\n- Corda di canapa (15 metri, arrotolata)\n\n- Sacco La tunica possiede altre 4d4 toppe, scelte dal GM o determinate casualmente.\n\n| d100 | Toppa |\n|---|---|\n| 01–08 | Una borsa con 100 mo |\n| 09–15 | Un forziere d'argento (lungo 30 cm, largo e profondo 15 cm) del valore di 500 mo |\n| 16–22 | Una porta di ferro (larga fino a 3 metri e alta 3 metri, sbarrata sul lato scelto dal personaggio) che può essere collocata in un'apertura entro portata del personaggio; la porta si adatta all'apertura, posizionandosi e infilandosi sui cardini |\n| 23–30 | 10 gemme del valore di 100 mo ciascuna |\n| 31–44 | Una scala a pioli di legno (lunga 7,2 metri) |\n| 45–51 | Un cavallo da galoppo dotato di bisacce |\n| 52–59 | Una fossa (un cubo con spigolo di 3 metri) che il personaggio può collocare sul terreno entro 3 metri da lui |\n| 60–68 | 4 pozioni di guarigione |\n| 69–75 | Una barca a remi (lunga 3,6 metri) |\n| 76–83 | Una pergamena magica contenente un incantesimo di livello compreso tra il 1° e il 3° |\n| 84–90 | 2 mastini |\n| 91–96 | Una finestra (60 per 120 cm, profonda fino a 60 cm) che il personaggio può collocare su una superficie verticale entro la sua portata |\n| 97–00 | Un ariete portatile |", null),
			("Robe of Useful Items", "Wondrous item, uncommon",
			"This robe has cloth patches of various shapes and colors covering it. While wearing the robe, you can use an action to detach one of the patches, causing it to become the object or creature it represents. Once the last patch is removed, the robe becomes an ordinary garment.\n\nThe robe has two of each of the following patches:\n\nDagger\n\nBullseye lantern (filled and lit)\n\nSteel mirror\n\n10-foot pole\n\nHempen rope (50 feet, coiled)\n\nSack\n\nIn addition, the robe has 4d4 other patches. The GM chooses the patches or determines them randomly.\n\n| d100 | Patch |\n|---|---|\n| 01-08 | Bag of 100 gp |\n| 09-15 | Silver coffer (1 foot long, 6 inches wide and deep) worth 500 gp |\n| 16-22 | Iron door (up to 10 feet wide and 10 feet high, barred on one side of your choice), which you can place in an opening you can reach; it conforms to fit the opening, attaching and hinging itself |\n| 23-30 | 10 gems worth 100 gp each |\n| 31-44 | Wooden ladder (24 feet long) 45-51 A riding horse with saddle bags |\n| 52-59 | Pit (a cube 10 feet on a side), which you can place on the ground within 10 feet of you |\n| 60-68 | 4 potions of healing |\n| 69-75 | Rowboat (12 feet long) |\n| 76-83 | Spell scroll containing one spell of 1st to 3rd level |\n| 84-90 | 2 mastiffs |\n| 91-96 | Window (2 feet by 4 feet, up to 2 feet deep), which you can place on a vertical surface you can reach |\n| 97-100 | Portable ram |", null));
	}
}
