using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Potion of Healing (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class PotionOfHealing2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("potion-of-healing", null, 0, MagicItemType.Potion, null, false, ContentSource.Srd51,
			null,
			("Pozione di guarigione", "Pozione, rarità variabile",
			"Quando il personaggio beve questa pozione, recupera punti ferita. L'ammontare di punti ferita dipende dalla rarità della pozione, come indicato nella tabella \"Pozioni di guarigione\". A prescindere dalla sua potenza, il liquido rosso della pozione brilla quando viene agitato.\n\n**Pozioni di Guarigione**\n\n| Pozione di... | Rarità | PF recuperati |\n|---|---|---|\n| Guarigione | Comune | 2d4 + 2 |\n| Guarigione maggiore | Non comune | 4d4 + 4 |\n| Guarigione superiore | Rara | 8d4 + 8 |\n| Guarigione suprema | Molto rara | 10d4 + 20 |"),
			("Potion of Healing", "Potion, varies",
			"You regain hit points when you drink this potion. The number of hit points depends on the potion's rarity, as shown in the Potions of Healing table. Whatever its potency, the potion's red liquid glimmers when agitated.\n\n**Potions of Healing**\n\n| Potion of ... | Rarity | HP Regained |\n|---|---|---|\n| Healing | Common | 2d4 + 2 |\n| Greater healing | Uncommon | 4d4 + 4 |\n| Superior healing | Rare | 8d4 + 8 |\n| Supreme healing | Very rare | 10d4 + 20 |", null));
		yield return Item("potion-of-healing-common", "potion-of-healing", 1, MagicItemType.Potion, ItemRarity.Common, false, ContentSource.Srd51,
			Heal("2d4+2"),
			("Pozione di guarigione", "Pozione, comune",
			""),
			("Potion of Healing", "Potion, common",
			"", null));
		yield return Item("potion-of-healing-greater", "potion-of-healing", 2, MagicItemType.Potion, ItemRarity.Uncommon, false, ContentSource.Srd51,
			Heal("4d4+4"),
			("Pozione di guarigione maggiore", "Pozione, non comune",
			""),
			("Potion of Greater Healing", "Potion, uncommon",
			"", null));
		yield return Item("potion-of-healing-superior", "potion-of-healing", 3, MagicItemType.Potion, ItemRarity.Rare, false, ContentSource.Srd51,
			Heal("8d4+8"),
			("Pozione di guarigione superiore", "Pozione, rara",
			""),
			("Potion of Superior Healing", "Potion, rare",
			"", null));
		yield return Item("potion-of-healing-supreme", "potion-of-healing", 4, MagicItemType.Potion, ItemRarity.VeryRare, false, ContentSource.Srd51,
			Heal("10d4+20"),
			("Pozione di guarigione suprema", "Pozione, molto rara",
			""),
			("Potion of Supreme Healing", "Potion, very rare",
			"", null));
	}
}
