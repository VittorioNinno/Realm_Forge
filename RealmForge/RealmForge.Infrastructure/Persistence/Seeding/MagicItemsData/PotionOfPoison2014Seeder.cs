using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Potion of Poison (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class PotionOfPoison2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("potion-of-poison", null, 0, MagicItemType.Potion, ItemRarity.Uncommon, false, ContentSource.Srd51,
			null,
			("Pozione velenosa", "Pozione, non comune",
			"Questa mistura ha l'aspetto, l'odore e il sapore di una pozione di guarigione o di altre pozioni benefiche. In realtà, si tratta di un veleno mascherato da un'illusione magica. L'incantesimo *identificare* rivela la sua vera natura.\n\nSe il personaggio la beve, subisce 3d6 danni da veleno e deve superare un tiro salvezza su Costituzione con CD 13, altrimenti diventa avvelenato. All'inizio di ogni suo turno, finché è avvelenato in questo modo, subisce 3d6 danni da veleno. Alla fine di ogni suo turno, può ripetere il tiro salvezza: se lo supera, i danni da veleno che subisce nei turni successivi si riducono di 1d6. L'effetto della pozione termina quando questi danni scendono a 0.", null),
			("Potion of Poison", "Potion, uncommon",
			"This concoction looks, smells, and tastes like a potion of healing or other beneficial potion. However, it is actually poison masked by illusion magic. An identify spell reveals its true nature.\n\nIf you drink it, you take 3d6 poison damage, and you must succeed on a DC 13 Constitution saving throw or be poisoned. At the start of each of your turns while you are poisoned in this way, you take 3d6 poison damage. At the end of each of your turns, you can repeat the saving throw. On a successful save, the poison damage you take on your subsequent turns decreases by 1d6. The poison ends when the damage decreases to 0.", null));
	}
}
