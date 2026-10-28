using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Oathbow (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class Oathbow2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("oathbow", null, 0, MagicItemType.Weapon, ItemRarity.VeryRare, true, ContentSource.Srd51,
			null,
			("Arco del giuramento", "Arma (arco lungo), molto rara (richiede sintonia)",
			"Quando il personaggio incocca una freccia, quest'arco sussurra in Elfico: \"Rapida sconfitta ai miei nemici\". Quando il personaggio usa quest'arma per effettuare un attacco a distanza, può pronunciare la seguente frase come parola d'ordine: \"Morte rapida a chi mi ha fatto un torto\". Il bersaglio dell'attacco diventa nemico giurato del personaggio fino alla sua morte o all'alba del settimo giorno dopo l'attacco. Il personaggio può avere un solo nemico giurato alla volta. Quando il suo nemico giurato muore, può sceglierne un altro a partire dall'alba successiva.\n\nQuando il personaggio effettua un tiro per colpire a distanza con quest'arma contro il suo nemico giurato, dispone di vantaggio al tiro. Inoltre, il bersaglio non ottiene alcun beneficio da una copertura che non sia totale e il personaggio non subisce svantaggio a causa della lunga gittata. Se l'attacco va a segno, il nemico giurato del personaggio subisce 3d6 danni perforanti extra.\n\nFinché il nemico giurato è in vita, il personaggio subisce svantaggio ai tiri per colpire effettuati con tutte le altre armi."),
			("Oathbow", "Weapon (longbow), very rare (requires attunement)",
			"When you nock an arrow on this bow, it whispers in Elvish, \"Swift defeat to my enemies.\" When you use this weapon to make a ranged attack, you can, as a command phrase, say, \"Swift death to you who have wronged me.\" The target of your attack becomes your sworn enemy until it dies or until dawn seven days later. You can have only one such sworn enemy at a time. When your sworn enemy dies, you can choose a new one after the next dawn.\n\nWhen you make a ranged attack roll with this weapon against your sworn enemy, you have advantage on the roll. In addition, your target gains no benefit from cover, other than total cover, and you suffer no disadvantage due to long range. If the attack hits, your sworn enemy takes an extra 3d6 piercing damage.\n\nWhile your sworn enemy lives, you have disadvantage on attack rolls with all other weapons.", null));
	}
}
