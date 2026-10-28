using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Sword of Sharpness (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class SwordOfSharpness2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("sword-of-sharpness", null, 0, MagicItemType.Weapon, ItemRarity.VeryRare, true, ContentSource.Srd51,
			null,
			("Spada affilata", "Arma (qualsiasi spada che infligga danni taglienti), molto rara (richiede sintonia)",
			"Quando il personaggio attacca un oggetto con questa spada magica e l'attacco va a segno, massimizza i dadi dei danni della sua arma contro il bersaglio.\n\nQuando il personaggio attacca una creatura con quest'arma e ottiene 20 al tiro per colpire, il bersaglio subisce 4d6 danni taglienti extra. Dopodiché deve tirare un altro d20. Se ottiene 20, recide un arto al bersaglio (sarà il GM a determinare gli effetti di questa menomazione). Se la creatura è priva di arti, il personaggio recide invece una parte del corpo.\n\nInoltre, il personaggio può pronunciare la parola d'ordine della spada per fare in modo che la lama proietti luce intensa in un raggio di 3 metri e luce fioca per altri 3 metri. Pronunciando di nuovo la parola d'ordine, o rinfoderando la spada, la luce si spegne."),
			("Sword of Sharpness", "Weapon (any sword that deals slashing damage), very rare (requires attunement)",
			"When you attack an object with this magic sword and hit, maximize your weapon damage dice against the target.\n\nWhen you attack a creature with this weapon and roll a 20 on the attack roll, that target takes an extra 4d6 slashing damage. Then roll another d20. If you roll a 20, you lop off one of the target's limbs, with the effect of such loss determined by the GM. If the creature has no limb to sever, you lop off a portion of its body instead.\n\nIn addition, you can speak the sword's command word to cause the blade to shed bright light in a 10 foot radius and dim light for an additional 10 feet. Speaking the command word again or sheathing the sword puts out the light.", null));
	}
}
