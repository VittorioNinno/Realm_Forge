using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Potion of Climbing (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class PotionOfClimbing2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("potion-of-climbing", null, 0, MagicItemType.Potion, ItemRarity.Common, false, ContentSource.Srd51,
			null,
			("Pozione di scalare", "Pozione, comune",
			"Quando il personaggio beve questa pozione, ottiene una velocità di scalare pari alla sua velocità base sul terreno per 1 ora. Per la stessa durata, dispone anche di vantaggio alle prove di Forza (Atletica) effettuate per scalare. La pozione è composta da strati separati di colore marrone, argento e grigio, simili a strati geologici sovrapposti. Agitando la pozione, gli strati non si mescolano."),
			("Potion of Climbing", "Potion, common",
			"When you drink this potion, you gain a climbing speed equal to your walking speed for 1 hour. During this time, you have advantage on Strength (Athletics) checks you make to climb. The potion is separated into brown, silver, and gray layers resembling bands of stone. Shaking the bottle fails to mix the colors.", null));
	}
}
