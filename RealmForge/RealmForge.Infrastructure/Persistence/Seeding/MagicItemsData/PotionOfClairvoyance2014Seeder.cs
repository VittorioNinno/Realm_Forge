using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Potion of Clairvoyance (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class PotionOfClairvoyance2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("potion-of-clairvoyance", null, 0, MagicItemType.Potion, ItemRarity.Rare, false, ContentSource.Srd51,
			null,
			("Pozione di chiaroveggenza", "Pozione, rara",
			"Quando il personaggio beve questa pozione, ottiene l'effetto dell'incantesimo *chiaroveggenza.* Nel liquido giallastro galleggia un globo oculare, che scompare quando la pozione viene aperta.", null),
			("Potion of Clairvoyance", "Potion, rare",
			"When you drink this potion, you gain the effect of the clairvoyance spell. An eyeball bobs in this yellowish liquid but vanishes when the potion is opened.", null));
	}
}
