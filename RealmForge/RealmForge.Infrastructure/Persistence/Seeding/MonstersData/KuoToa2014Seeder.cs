using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Kuo-toa (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class KuoToa2014Seeder
{
	public static Monster Build() => Create("kuo-toa", null, ContentSource.RealmForge, CreatureSize.Medium, CreatureType.Humanoid,
		13, 18, "4d8", 30, new[] { 13, 10, 11, 11, 10, 8 }, 0.25m, 50, 2, 14,
		new Text(
			"Kuo-toa",
			null,
			"Umanoide Medio (kuo-toa), neutrale malvagio",
			"13 (armatura naturale, scudo)",
			"9 m, nuotare 9 m",
			"",
			"Percezione +4",
			"",
			"",
			"",
			"",
			"Percezione passiva 14, scurovisione 36 m",
			"Sottocomune",
			"***Anfibio.*** Il kuo-toa può respirare in aria e in acqua.\n\n***Percezione ultraterrena.*** Il kuo-toa avverte la presenza di ogni creatura invisibile, o che si trova sul Piano Etereo, entro 9 metri da lui, e se si muove ne conosce la posizione esatta.\n\n***Viscido.*** Il kuo-toa dispone di vantaggio alle prove di caratteristica e ai tiri salvezza per sfuggire a una presa.\n\n***Sensibilità alla luce del sole.*** Finché si trova alla luce del sole, il kuo-toa subisce svantaggio ai tiri per colpire e alle prove di Saggezza (Percezione) basate sulla vista.",
			"***Morso.*** *Attacco con arma da mischia:* +3 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 3 (1d4 + 1) danni perforanti.\n\n***Lancia.*** *Attacco con arma da mischia o a distanza:* +3 al tiro per colpire, portata 1,5 m o gittata 6/18 m, un bersaglio. *Colpito:* 4 (1d6 + 1) danni perforanti, o 5 (1d8 + 1) danni perforanti se impugnata a due mani.\n\n***Rete.*** *Attacco con arma a distanza:* +3 al tiro per colpire, gittata 1,5/4,5 m, una creatura di taglia Grande o inferiore. *Colpito:* il bersaglio è trattenuto. Con un'azione, una creatura può effettuare una prova di Forza con CD 10 per liberare se stessa o un'altra creatura dalla rete; infliggere 5 danni taglienti alla rete (CA 10) libera il bersaglio, illeso, e distrugge la rete.",
			"",
			"***Scudo appiccicoso.*** Quando una creatura manca il kuo-toa con un attacco con arma da mischia, il kuo-toa cerca di bloccare l'arma con il suo scudo colloso: l'attaccante effettua un tiro salvezza su Forza con CD 11, altrimenti l'arma resta incollata allo scudo. Finché è incollata l'arma non può essere usata, e chi la impugna e non può o non vuole lasciarla è afferrato. Con un'azione, una creatura può staccare l'arma superando una prova di Forza con CD 11.",
			"",
			""),
		new Text(
			"Kuo-toa",
			null,
			"Medium humanoid (kuo-toa), neutral evil",
			"13 (natural armor, shield)",
			"30 ft., swim 30 ft.",
			"",
			"Perception +4",
			"",
			"",
			"",
			"",
			"darkvision 120 ft., passive Perception 14",
			"Undercommon",
			"***Amphibious.*** The kuo-toa can breathe air and water.\n\n***Otherworldly Perception.*** The kuo-toa senses the presence of every invisible creature, or creature on the Ethereal Plane, within 30 feet of it, and knows exactly where it is if it moves.\n\n***Slippery.*** The kuo-toa has advantage on ability checks and saving throws to escape a grapple.\n\n***Sunlight Sensitivity.*** While in sunlight, the kuo-toa has disadvantage on attack rolls, as well as on Wisdom (Perception) checks that rely on sight.",
			"***Bite.*** *Melee Weapon Attack:* +3 to hit, reach 5 ft., one target. *Hit:* 3 (1d4 + 1) piercing damage.\n\n***Spear.*** *Melee or Ranged Weapon Attack:* +3 to hit, reach 5 ft. or range 20/60 ft., one target. *Hit:* 4 (1d6 + 1) piercing damage, or 5 (1d8 + 1) piercing damage if used with two hands.\n\n***Net.*** *Ranged Weapon Attack:* +3 to hit, range 5/15 ft., one Large or smaller creature. *Hit:* the target is restrained. As an action, a creature can make a DC 10 Strength check to free itself or another creature from the net; dealing 5 slashing damage to the net (AC 10) also frees the target, unharmed, and destroys the net.",
			"",
			"***Sticky Shield.*** When a creature misses the kuo-toa with a melee weapon attack, the kuo-toa tries to catch the weapon with its gluey shield: the attacker makes a DC 11 Strength saving throw or the weapon sticks to the shield. While stuck, the weapon can't be used, and a wielder who can't or won't let go of it is grappled. As an action, a creature can pull the weapon free with a DC 11 Strength check.",
			"",
			""));
}
