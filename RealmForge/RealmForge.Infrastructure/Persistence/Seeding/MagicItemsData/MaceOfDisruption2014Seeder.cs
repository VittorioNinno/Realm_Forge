using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Mace of Disruption (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class MaceOfDisruption2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("mace-of-disruption", null, 0, MagicItemType.Weapon, ItemRarity.Rare, true, ContentSource.Srd51,
			null,
			("Mazza della distruzione", "Arma (mazza), rara (richiede sintonia)",
			"Quando il personaggio colpisce con quest'arma magica un immondo o un non morto, quella creatura subisce 2d6 danni radiosi extra. Se il colpo porta il bersaglio a 25 punti ferita o meno, tale bersaglio deve superare un tiro salvezza su Saggezza con CD 15, altrimenti viene distrutto. In caso di successo, la creatura diventa spaventata dal personaggio fino alla fine del turno successivo di quest'ultimo.\n\nFinché il personaggio impugna quest'arma, essa proietta luce intensa in un raggio di 6 metri e luce fioca per altri 6 metri."),
			("Mace of Disruption", "Weapon (mace), rare (requires attunement)",
			"When you hit a fiend or an undead with this magic weapon, that creature takes an extra 2d6 radiant damage. If the target has 25 hit points or fewer after taking this damage, it must succeed on a DC 15 Wisdom saving throw or be destroyed. On a successful save, the creature becomes frightened of you until the end of your next turn.\n\nWhile you hold this weapon, it sheds bright light in a 20-foot radius and dim light for an additional 20 feet.", null));
	}
}
