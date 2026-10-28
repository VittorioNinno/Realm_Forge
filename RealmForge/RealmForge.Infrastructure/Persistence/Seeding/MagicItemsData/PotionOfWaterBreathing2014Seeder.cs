using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Potion of Water Breathing (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class PotionOfWaterBreathing2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("potion-of-water-breathing", null, 0, MagicItemType.Potion, ItemRarity.Uncommon, false, ContentSource.Srd51,
			null,
			("Pozione del respirare sott'acqua", "Pozione, non comune",
			"Il personaggio può respirare sott'acqua per 1 ora dopo aver bevuto questa pozione. Il suo liquido verde torbido ha un odore salmastro e al suo interno galleggia una bolla simile a una medusa."),
			("Potion of Water Breathing", "Potion, uncommon",
			"You can breathe underwater for 1 hour after drinking this potion. Its cloudy green fluid smells of the sea and has a jellyfish-like bubble floating in it.", null));
	}
}
