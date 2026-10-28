using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Flame Tongue (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class FlameTongue2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("flame-tongue", null, 0, MagicItemType.Weapon, ItemRarity.Rare, true, ContentSource.Srd51,
			null,
			("Lingua di fiamme", "Arma (qualsiasi spada), rara (richiede sintonia)",
			"Il personaggio può usare un'azione bonus per pronunciare la parola d'ordine di questa spada magica sprigionando fiamme dalla sua lama. Le fiamme proiettano luce intensa in un raggio di 12 metri e luce fioca per altri 12 metri. Quando la lama è in fiamme, infligge 2d6 danni da fuoco extra a ogni bersaglio che colpisce. Le fiamme durano finché il personaggio non usa un'azione bonus per pronunciare di nuovo la parola d'ordine o finché non lascia cadere la spada o non la rinfodera."),
			("Flame Tongue", "Weapon (any sword), rare (requires attunement)",
			"You can use a bonus action to speak this magic sword's command word, causing flames to erupt from the blade. These flames shed bright light in a 40-foot radius and dim light for an additional 40 feet. While the sword is ablaze, it deals an extra 2d6 fire damage to any target it hits. The flames last until you use a bonus action to speak the command word again or until you drop or sheathe the sword.", null));
	}
}
