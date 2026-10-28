using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Boots of the Winterlands (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class BootsOfTheWinterlands2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("boots-of-the-winterlands", null, 0, MagicItemType.WondrousItem, ItemRarity.Uncommon, true, ContentSource.Srd51,
			null,
			("Stivali dell'inverno", "Oggetto meraviglioso, non comune (richiede sintonia)",
			"Questi stivali foderati di pelliccia sono comodi e caldi. Quando un personaggio li indossa, riceve i seguenti benefici:\n\n- Possiede resistenza ai danni da freddo.\n\n- Ignora il terreno difficile dovuto al ghiaccio o alla neve.\n\n- Tollera il freddo fino a –45 gradi senza bisogno di ulteriori protezioni. Se indossa abiti pesanti, può arrivare a tollerare basse temperature fino a –73 gradi.", null),
			("Boots of the Winterlands", "Wondrous item, uncommon (requires attunement)",
			"These furred boots are snug and feel quite warm. While you wear them, you gain the following benefits:\n\n* You have resistance to cold damage.\n\n* You ignore difficult terrain created by ice or snow.\n\n* You can tolerate temperatures as low as -50 degrees Fahrenheit without any additional protection. If you wear heavy clothes, you can tolerate temperatures as low as -100 degrees Fahrenheit.", null));
	}
}
