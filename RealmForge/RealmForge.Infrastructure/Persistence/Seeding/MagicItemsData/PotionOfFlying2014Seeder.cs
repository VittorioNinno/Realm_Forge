using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Potion of Flying (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class PotionOfFlying2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("potion-of-flying", null, 0, MagicItemType.Potion, ItemRarity.VeryRare, false, ContentSource.Srd51,
			null,
			("Pozione di volare", "Pozione, molto rara",
			"Quando il personaggio beve questa pozione, ottiene una velocità di volare pari alla sua velocità base sul terreno per 1 ora e può fluttuare. Se il personaggio si trova in aria quando l'effetto della pozione termina, cade a meno che non possieda altri mezzi per mantenersi in aria. Il liquido trasparente di questa pozione rimane sospeso nella parte superiore del contenitore e al suo interno sono visibili alcune impurità biancastre simili a nuvole.", null),
			("Potion of Flying", "Potion, very rare",
			"When you drink this potion, you gain a flying speed equal to your walking speed for 1 hour and can hover. If you're in the air when the potion wears off, you fall unless you have some other means of staying aloft. This potion's clear liquid floats at the top of its container and has cloudy white impurities drifting in it.", null));
	}
}
