using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Potion of Heroism (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class PotionOfHeroism2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("potion-of-heroism", null, 0, MagicItemType.Potion, ItemRarity.Rare, false, ContentSource.Srd51,
			null,
			("Pozione di eroismo", "Pozione, rara",
			"Quando il personaggio beve questa pozione, ottiene 10 punti ferita temporanei che durano 1 ora. Per la stessa durata, il personaggio è sotto l'effetto dell'incantesimo *benedizione* (non è richiesta la concentrazione). Il liquido blu di questa pozione gorgoglia e fuma come se stesse bollendo.", null),
			("Potion of Heroism", "Potion, rare",
			"For 1 hour after drinking it, you gain 10 temporary hit points that last for 1 hour. For the same duration, you are under the effect of the bless spell (no concentration required). This blue potion bubbles and steams as if boiling.", null));
	}
}
