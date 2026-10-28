using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Alchemy Jug (2014 ruleset). Item of the 2014 Dungeon Master's Guide outside the SRD: name and texts written by RealmForge (Italian and English).
///	</summary>
public static class AlchemyJug2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("alchemy-jug", null, 0, MagicItemType.WondrousItem, ItemRarity.Uncommon, false, ContentSource.RealmForge,
			null,
			("Brocca alchemica", "Oggetto meraviglioso, non comune",
			"Una brocca di ceramica che sembra contenere circa quattro litri e pesa 6 kg, piena o vuota che sia; se viene scossa si sente sciabordare del liquido anche quando è vuota.\n\nIl personaggio può usare un'azione per nominare uno dei liquidi della tabella: la brocca inizia a produrlo. In seguito può stapparla con un'azione e versarne fino a 8 litri al minuto, fino alla quantità massima prevista per quel liquido.\n\nUna volta che la brocca ha iniziato a produrre un liquido, non può produrne un altro, né altro dello stesso liquido arrivato al massimo, fino all'alba successiva.\n\n| Liquido | Quantità massima |\n|---|---|\n| Acido | 250 ml |\n| Veleno base | 15 ml |\n| Birra | 16 litri |\n| Miele | 4 litri |\n| Maionese | 8 litri |\n| Olio | 1 litro |\n| Aceto | 8 litri |\n| Acqua dolce | 32 litri |\n| Acqua salata | 48 litri |\n| Vino | 4 litri |"),
			("Alchemy Jug", "Wondrous item, uncommon",
			"A ceramic jug that looks like it holds about a gallon and weighs 12 pounds whether full or empty; shaking it produces a sloshing sound even when it is empty.\n\nAs an action, you can name one liquid from the table and the jug starts producing it. Afterwards you can uncork it as an action and pour out up to 2 gallons per minute, until the maximum amount for that liquid is reached.\n\nOnce the jug has started producing a liquid, it can't produce a different one, or more of one that has reached its maximum, until the next dawn.\n\n| Liquid | Maximum amount |\n|---|---|\n| Acid | 8 ounces |\n| Basic poison | 1/2 ounce |\n| Beer | 4 gallons |\n| Honey | 1 gallon |\n| Mayonnaise | 2 gallons |\n| Oil | 1 quart |\n| Vinegar | 2 gallons |\n| Water, fresh | 8 gallons |\n| Water, salt | 12 gallons |\n| Wine | 1 gallon |", null));
	}
}
