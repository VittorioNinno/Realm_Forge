using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Bag of Tricks (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class BagOfTricks2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("bag-of-tricks", null, 0, MagicItemType.WondrousItem, ItemRarity.Uncommon, false, ContentSource.Srd51,
			null,
			("Borsa dei trucchi", "Oggetto meraviglioso, non comune",
			"Questa borsa dall'aspetto ordinario, fatta di stoffa di colore grigio, ruggine o marrone, sembra vuota. Frugando al suo interno, si trova invece un piccolo oggetto lanuginoso. La borsa pesa 250 grammi.\n\nUn personaggio può usare un'azione per estrarre l'oggetto lanuginoso dalla borsa e lanciarlo fino a 6 metri di distanza. Quando atterra, l'oggetto si trasforma in una creatura determinata tirando un d8 e consultando la tabella corrispondente al colore della borsa posseduta. La creatura scompare all'alba successiva o quando viene ridotta a 0 punti ferita.\n\nLa creatura è amichevole nei confronti del possessore della borsa e dei suoi compagni e agisce nel turno di chi la possiede. Quest'ultimo può usare un'azione bonus per ordinare alla creatura come muoversi e agire nel turno successivo, o per impartirle comandi generici come attaccare i nemici. In assenza di tali ordini, la creatura agisce in modo appropriato alla sua natura.\n\nDopo che dalla borsa sono stati estratti tre oggetti lanuginosi, non può essere riutilizzata fino all'alba successiva.\n\n**Borsa dei trucchi grigia**\n\n| d8 | Creatura |\n|---|---|\n| 1 | Faina |\n| 2 | Topo gigante |\n| 3 | Tasso |\n| 4 | Cinghiale |\n| 5 | Pantera |\n| 6 | Tasso gigante |\n| 7 | Lupo feroce |\n| 8 | Alce gigante |\n\n**Borsa dei trucchi ruggine**\n\n| d8 | Creatura |\n|---|---|\n| 1 | Topo |\n| 2 | Gufo |\n| 3 | Mastino |\n| 4 | Capra |\n| 5 | Capra gigante |\n| 6 | Cinghiale gigante |\n| 7 | Leone |\n| 8 | Orso bruno |\n\n**Borsa dei trucchi marrone**\n\n| d8 | Creatura |\n|---|---|\n| 1 | Sciacallo |\n| 2 | Gorilla |\n| 3 | Babbuino |\n| 4 | Beccoaguzzo |\n| 5 | Orso nero |\n| 6 | Faina gigante |\n| 7 | Iena gigante |\n| 8 | Tigre |", null),
			("Bag of Tricks", "Wondrous item, uncommon",
			"This ordinary bag, made from gray, rust, or tan cloth, appears empty. Reaching inside the bag, however, reveals the presence of a small, fuzzy object. The bag weighs 1/2 pound.\n\nYou can use an action to pull the fuzzy object from the bag and throw it up to 20 feet. When the object lands, it transforms into a creature you determine by rolling a d8 and consulting the table that corresponds to the bag's color. The creature vanishes at the next dawn or when it is reduced to 0 hit points.\n\nThe creature is friendly to you and your companions, and it acts on your turn. You can use a bonus action to command how the creature moves and what action it takes on its next turn, or to give it general orders, such as to attack your enemies. In the absence of such orders, the creature acts in a fashion appropriate to its nature.\n\nOnce three fuzzy objects have been pulled from the bag, the bag can't be used again until the next dawn.\n\n**Gray Bag**\n\n| d8 | Creature |\n|---|---|\n| 01 | Weasel |\n| 02 | Giant Rat |\n| 03 | Badger |\n| 04 | Boar |\n| 05 | Panther |\n| 06 | Giant Badger |\n| 07 | Dire Wolf |\n| 08 | Giant Elk |\n\n**Rust Bag**\n\n| d8 | Creature |\n|---|---|\n| 01 | Rat |\n| 02 | Owl |\n| 03 | Mastiff |\n| 04 | Goat |\n| 05 | Giant Goat |\n| 06 | Giant Boar |\n| 07 | Lion |\n| 08 | Brown Bear |\n\n**Tan Bag**\n\n| d8 | Creature |\n|---|---|\n| 01 | Jackal |\n| 02 | Ape |\n| 03 | Baboon |\n| 04 | Axe Beak |\n| 05 | Black Bear |\n| 06 | Giant Weasel |\n| 07 | Giant Hyena |\n| 08 | Tiger |", null));
		yield return Item("bag-of-tricks-gray", "bag-of-tricks", 1, MagicItemType.WondrousItem, ItemRarity.Uncommon, false, ContentSource.Srd51,
			null,
			("Borsa dei trucchi grigia", "Oggetto meraviglioso, non comune",
			"", null),
			("Gray Bag of Tricks", "Wondrous item, uncommon",
			"", null));
		yield return Item("bag-of-tricks-rust", "bag-of-tricks", 2, MagicItemType.WondrousItem, ItemRarity.Uncommon, false, ContentSource.Srd51,
			null,
			("Borsa dei trucchi ruggine", "Oggetto meraviglioso, non comune",
			"", null),
			("Rust Bag of Tricks", "Wondrous item, uncommon",
			"", null));
		yield return Item("bag-of-tricks-tan", "bag-of-tricks", 3, MagicItemType.WondrousItem, ItemRarity.Uncommon, false, ContentSource.Srd51,
			null,
			("Borsa dei trucchi marrone", "Oggetto meraviglioso, non comune",
			"", null),
			("Tan Bag of Tricks", "Wondrous item, uncommon",
			"", null));
	}
}
