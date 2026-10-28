using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Arrow of Slaying (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class ArrowOfSlaying2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("arrow-of-slaying", null, 0, MagicItemType.Weapon, ItemRarity.VeryRare, false, ContentSource.Srd51,
			null,
			("Freccia assassina", "Arma (freccia), molto rara",
			"Una *freccia assassina* è un'arma magica creata per uccidere un particolare tipo di creatura. Alcune frecce sono più specializzate di altre; esistono, per esempio, sia *frecce assassine dei draghi* che *frecce assassine dei draghi blu.* Se una creatura appartenente al tipo, razza o gruppo associato alla freccia assassina subisce danni da essa, deve effettuare un tiro salvezza su Costituzione con CD 17; se lo fallisce, subisce 6d10 danni perforanti extra, mentre se lo supera, subisce la metà di quei danni.\n\nUna volta che la *freccia assassina* ha inflitto i suoi danni extra a una creatura, diventa una freccia non magica.\n\nEsistono anche altri tipi di munizioni magiche con le stesse caratteristiche, come i *quadrelli assassini,* utilizzabili dalle balestre, ma le frecce sono le più comuni.", null),
			("Arrow of Slaying", "Weapon (arrow), very rare",
			"An arrow of slaying is a magic weapon meant to slay a particular kind of creature. Some are more focused than others; for example, there are both arrows of dragon slaying and arrows of blue dragon slaying. If a creature belonging to the type, race, or group associated with an arrow of slaying takes damage from the arrow, the creature must make a DC 17 Constitution saving throw, taking an extra 6d10 piercing damage on a failed save, or half as much extra damage on a successful one.\n\nOnce an arrow of slaying deals its extra damage to a creature, it becomes a nonmagical arrow.\n\nOther types of magic ammunition of this kind exist, such as bolts of slaying meant for a crossbow, though arrows are most common.", null));
	}
}
