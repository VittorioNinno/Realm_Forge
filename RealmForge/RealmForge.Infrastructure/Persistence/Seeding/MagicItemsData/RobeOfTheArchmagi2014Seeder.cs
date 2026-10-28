using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Robe of the Archmagi (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class RobeOfTheArchmagi2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("robe-of-the-archmagi", null, 0, MagicItemType.WondrousItem, ItemRarity.Legendary, true, ContentSource.Srd51,
			Magic(Effect(MagicEffectKind.SpellSaveDc, 2), Effect(MagicEffectKind.SpellAttack, 2)),
			("Tunica dell'arcimago", "Oggetto meraviglioso, leggendario (richiede sintonia con un mago, uno stregone o un warlock)",
			"Questa elegante tunica è fatta di un esclusivo tessuto di colore bianco, grigio o nero decorato con rune argentate. Il colore della tunica corrisponde all'allineamento per il quale la tunica è stata creata: bianco per un allineamento buono, grigio per un allineamento neutrale e nero per un allineamento malvagio. Un personaggio può entrare in sintonia solo con una *tunica dell'arcimago* che corrisponde al suo allineamento.\n\nFinché il personaggio indossa questa tunica ottiene i benefici seguenti:\n\n- Se il personaggio non indossa alcuna armatura, la sua Classe Armatura base è pari a 15 + il suo modificatore di Destrezza.\n\n- Il personaggio dispone di vantaggio ai tiri salvezza contro gli incantesimi e gli altri effetti magici.\n\n- La CD del tiro salvezza sull'incantesimo e il bonus di attacco dell'incantesimo del personaggio aumentano entrambi di 2."),
			("Robe of the Archmagi", "Wondrous item, legendary (requires attunement by a sorcerer, warlock, or wizard)",
			"This elegant garment is made from exquisite cloth of white, gray, or black and adorned with silvery runes. The robe's color corresponds to the alignment for which the item was created. A white robe was made for good, gray for neutral, and black for evil. You can't attune to a robe of the archmagi that doesn't correspond to your alignment.\n\nYou gain these benefits while wearing the robe:\n\nIf you aren't wearing armor, your base Armor Class is 15 + your Dexterity modifier.\n\nYou have advantage on saving throws against spells and other magical effects.\n\nYour spell save DC and spell attack bonus each increase by 2.", null));
	}
}
