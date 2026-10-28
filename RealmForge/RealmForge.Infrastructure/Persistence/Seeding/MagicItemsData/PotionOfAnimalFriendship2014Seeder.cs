using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Potion of Animal Friendship (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class PotionOfAnimalFriendship2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("potion-of-animal-friendship", null, 0, MagicItemType.Potion, ItemRarity.Uncommon, false, ContentSource.Srd51,
			null,
			("Pozione di amicizia con gli animali", "Pozione, non comune",
			"Quando il personaggio beve questa pozione, può lanciare l'incantesimo *amicizia con gli animali* (CD del tiro salvezza 13) a volontà per 1 ora. Agitando questo liquido melmoso si notano alcuni piccoli oggetti al suo interno: una squama di pesce, la lingua di un colibrì, l'artiglio di un gatto o un pelo di scoiattolo.", null),
			("Potion of Animal Friendship", "Potion, uncommon",
			"When you drink this potion, you can cast the animal friendship spell (save DC 13) for 1 hour at will. Agitating this muddy liquid brings little bits into view: a fish scale, a hummingbird tongue, a cat claw, or a squirrel hair.", null));
	}
}
