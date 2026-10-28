using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Potion of Speed (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class PotionOfSpeed2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("potion-of-speed", null, 0, MagicItemType.Potion, ItemRarity.VeryRare, false, ContentSource.Srd51,
			null,
			("Pozione di velocità", "Pozione, molto rara",
			"Quando il personaggio beve questa pozione, ottiene l'effetto dell'incantesimo *velocità* per 1 minuto (non è richiesta la concentrazione). Il fluido giallo della pozione è striato di nero e vortica costantemente.", null),
			("Potion of Speed", "Potion, very rare",
			"When you drink this potion, you gain the effect of the haste spell for 1 minute (no concentration required). The potion's yellow fluid is streaked with black and swirls on its own.", null));
	}
}
