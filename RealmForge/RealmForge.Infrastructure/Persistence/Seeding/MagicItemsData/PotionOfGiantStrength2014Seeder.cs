using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Potion of Giant Strength (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class PotionOfGiantStrength2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("potion-of-giant-strength", null, 0, MagicItemType.Potion, null, false, ContentSource.Srd51,
			null,
			("Pozione della forza dei giganti", "Pozione, rarità variabile",
			"Quando il personaggio beve questa pozione, il suo punteggio di Forza cambia per 1 ora, come determinato dal tipo di gigante (vedi la tabella sottostante). Se il punteggio di Forza del personaggio è pari o superiore a quello conferito dalla pozione, non ha alcun effetto.\n\nNel liquido trasparente di questa pozione galleggia un frammento d'unghia di un gigante del tipo appropriato. La *pozione della forza dei giganti del gelo* e la *pozione della forza dei giganti delle pietre* hanno lo stesso effetto.\n\n| Tipo di gigante | Forza | Rarità |\n|---|---|---|\n| Giganti delle colline | 21 | Non comune |\n| Giganti del gelo/delle pietre | 23 | Rara |\n| Giganti del fuoco | 25 | Rara |\n| Giganti delle nuvole | 27 | Molto rara |\n| Giganti delle tempeste | 29 | Leggendaria |"),
			("Potion of Giant Strength", "Potion, varies",
			"When you drink this potion, your Strength score changes for 1 hour. The type of giant determines the score (see the table below). The potion has no effect on you if your Strength is equal to or greater than that score.\n\nThis potion's transparent liquid has floating in it a sliver of fingernail from a giant of the appropriate type. The potion of frost giant strength and the potion of stone giant strength have the same effect.\n\n| Type of Giant | Strength | Rarity |\n|---|---|---|\n| Hill giant | 21 | Uncommon |\n| Frost/stone giant | 23 | Rare |\n| Fire giant | 25 | Rare |\n| Cloud giant | 27 | Very rare |\n| Storm giant | 29 | Legendary |", null));
		yield return Item("potion-of-giant-strength-hill", "potion-of-giant-strength", 1, MagicItemType.Potion, ItemRarity.Uncommon, false, ContentSource.Srd51,
			null,
			("Pozione della forza dei giganti delle colline", "Pozione, non comune",
			""),
			("Potion of Hill Giant Strength", "Potion, uncommon",
			"", null));
		yield return Item("potion-of-giant-strength-frost", "potion-of-giant-strength", 2, MagicItemType.Potion, ItemRarity.Rare, false, ContentSource.Srd51,
			null,
			("Pozione della forza dei giganti del gelo", "Pozione, rara",
			""),
			("Potion of Frost Giant Strength", "Potion, rare",
			"", null));
		yield return Item("potion-of-giant-strength-stone", "potion-of-giant-strength", 3, MagicItemType.Potion, ItemRarity.Rare, false, ContentSource.Srd51,
			null,
			("Pozione della forza dei giganti delle pietre", "Pozione, rara",
			""),
			("Potion of Stone Giant Strength", "Potion, rare",
			"", null));
		yield return Item("potion-of-giant-strength-fire", "potion-of-giant-strength", 4, MagicItemType.Potion, ItemRarity.Rare, false, ContentSource.Srd51,
			null,
			("Pozione della forza dei giganti del fuoco", "Pozione, rara",
			""),
			("Potion of Fire Giant Strength", "Potion, rare",
			"", null));
		yield return Item("potion-of-giant-strength-cloud", "potion-of-giant-strength", 5, MagicItemType.Potion, ItemRarity.VeryRare, false, ContentSource.Srd51,
			null,
			("Pozione della forza dei giganti delle nuvole", "Pozione, molto rara",
			""),
			("Potion of Cloud Giant Strength", "Potion, very rare",
			"", null));
		yield return Item("potion-of-giant-strength-storm", "potion-of-giant-strength", 6, MagicItemType.Potion, ItemRarity.Legendary, false, ContentSource.Srd51,
			null,
			("Pozione della forza dei giganti delle tempeste", "Pozione, leggendaria",
			""),
			("Potion of Storm Giant Strength", "Potion, legendary",
			"", null));
	}
}
