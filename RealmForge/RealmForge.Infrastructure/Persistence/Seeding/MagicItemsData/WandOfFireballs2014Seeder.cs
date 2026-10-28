using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Wand of Fireballs (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class WandOfFireballs2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("wand-of-fireballs", null, 0, MagicItemType.Wand, ItemRarity.Rare, true, ContentSource.Srd51,
			Charges(7, ItemRecharge.LongRest, "1d6+1"),
			("Bacchetta delle palle di fuoco", "Bacchetta, rara (richiede sintonia con un incantatore)",
			"Questa bacchetta possiede 7 cariche. Mentre il personaggio la impugna, può usare un'azione per consumare 1 o più delle sue cariche e lanciare con essa l'incantesimo *palla di fuoco* (CD del tiro salvezza 15). Consumando 1 carica, il personaggio lancia la versione di 3° livello dell'incantesimo. Può aumentare il livello dello slot incantesimo di 1 per ogni carica aggiuntiva consumata.\n\nAll'alba di ogni giorno, la bacchetta recupera 1d6 + 1 cariche consumate. Se il personaggio consuma l'ultima carica, deve tirare un d20: se ottiene 1, la bacchetta diventa cenere e viene distrutta.", null),
			("Wand of Fireballs", "Wand, rare (requires attunement by a spellcaster)",
			"This wand has 7 charges. While holding it, you can use an action to expend 1 or more of its charges to cast the fireball spell (save DC 15) from it. For 1 charge, you cast the 3rd-level version of the spell. You can increase the spell slot level by one for each additional charge you expend.\n\nThe wand regains 1d6 + 1 expended charges daily at dawn. If you expend the wand's last charge, roll a d20. On a 1, the wand crumbles into ashes and is destroyed.", null));
	}
}
