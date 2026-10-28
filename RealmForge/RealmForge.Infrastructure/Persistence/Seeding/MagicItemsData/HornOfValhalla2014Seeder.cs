using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Horn of Valhalla (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class HornOfValhalla2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("horn-of-valhalla", null, 0, MagicItemType.WondrousItem, null, false, ContentSource.Srd51,
			null,
			("Corno del Valhalla", "Oggetto meraviglioso, raro (ottone o argento), molto raro (bronzo) o leggendario (ferro)",
			"Il personaggio può usare un'azione per suonare questo corno. In risposta al suono, entro 18 metri da lui compare una schiera di spiriti guerrieri provenienti dal Valhalla, che utilizzano le statistiche del berserker. Tornano nel Valhalla dopo 1 ora o quando scendono a 0 punti ferita. Una volta usato, il corno non può essere riutilizzato finché non sono trascorsi 7 giorni.\n\nSono noti quattro tipi di *corno del Valhalla,* ognuno fatto di un metallo diverso. Il tipo di corno determina il numero di berserker che rispondono all'evocazione e i requisiti per il suo uso. Il GM sceglie il tipo di corno o lo determina casualmente.\n\n| d100 | Tipo di corno | Berserker evocati | Requisiti |\n|---|---|---|---|\n| 01–40 | Argento | 2d4 + 2 | Nessuno |\n| 41–75 | Ottone | 3d4 + 3 | Competenza in tutte le armi semplici |\n| 76–90 | Bronzo | 4d4 + 4 | Competenza in tutte le armature medie |\n| 91–00 | Ferro | 5d4 + 5 | Competenza in tutte le armi da guerra |\n\nSe il personaggio suona il corno senza soddisfare i requisiti, i berserker evocati lo attaccano. In caso contrario, i berserker sono amichevoli nei suoi confronti e in quelli dei suoi compagni e obbediscono ai suoi ordini.", null),
			("Horn of Valhalla", "Wondrous item, rare (silver or brass), very rare (bronze) or legendary (iron)",
			"You can use an action to blow this horn. In response, warrior spirits from the Valhalla appear within 60 feet of you. They use the statistics of a berserker. They return to Valhalla after 1 hour or when they drop to 0 hit points. Once you use the horn, it can't be used again until 7 days have passed.\n\nFour types of horn of Valhalla are known to exist, each made of a different metal. The horn's type determines how many berserkers answer its summons, as well as the requirement for its use. The GM chooses the horn's type or determines it randomly.\n\n| d100 | Horn Type | Berserkers Summoned | Requirement |\n|---|---|---|---|\n| 01-40 | Silver | 2d4 + 2 | None |\n| 41-75 | Brass | 3d4 + 3 | Proficiency with all simple weapons |\n| 76-90 | Bronze | 4d4 + 4 | Proficiency with all medium armor |\n| 91-00 | Iron | 5d4 + 5 | Proficiency with all martial weapons |\n\nIf you blow the horn without meeting its requirement, the summoned berserkers attack you. If you meet the requirement, they are friendly to you and your companions and follow your commands.", null));
		yield return Item("horn-of-valhalla-silver", "horn-of-valhalla", 1, MagicItemType.WondrousItem, ItemRarity.Rare, false, ContentSource.Srd51,
			null,
			("Corno del Valhalla d'argento", "Oggetto meraviglioso, raro",
			"", null),
			("Silver Horn of Valhalla", "Wondrous item, rare",
			"", null));
		yield return Item("horn-of-valhalla-brass", "horn-of-valhalla", 2, MagicItemType.WondrousItem, ItemRarity.Rare, false, ContentSource.Srd51,
			null,
			("Corno del Valhalla d'ottone", "Oggetto meraviglioso, raro",
			"", null),
			("Brass Horn of Valhalla", "Wondrous item, rare",
			"", null));
		yield return Item("horn-of-valhalla-bronze", "horn-of-valhalla", 3, MagicItemType.WondrousItem, ItemRarity.VeryRare, false, ContentSource.Srd51,
			null,
			("Corno del Valhalla di bronzo", "Oggetto meraviglioso, molto raro",
			"", null),
			("Bronze Horn of Valhalla", "Wondrous item, very rare",
			"", null));
		yield return Item("horn-of-valhalla-iron", "horn-of-valhalla", 4, MagicItemType.WondrousItem, ItemRarity.Legendary, false, ContentSource.Srd51,
			null,
			("Corno del Valhalla di ferro", "Oggetto meraviglioso, leggendario",
			"", null),
			("Iron Horn of Valhalla", "Wondrous item, legendary",
			"", null));
	}
}
