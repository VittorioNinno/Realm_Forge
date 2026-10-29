using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Merrow (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Merrow2014Seeder
{
	public static Monster Build() => Create("merrow", null, CreatureSize.Large, CreatureType.Monstrosity,
		13, 45, "6d10 + 12", 10, new[] { 18, 10, 15, 8, 10, 9 }, 2m, 450, 2, 10,
		new Text(
			"Merrow",
			null,
			"Mostruosità Grande, caotico malvagio",
			"13 (armatura naturale)",
			"3 m, nuotare 12 m",
			"",
			"",
			"",
			"",
			"",
			"",
			"Percezione passiva 10, scurovisione 18 m",
			"Abissale, Aquan",
			"***Anfibio.*** Il merrow può respirare in aria e in acqua.",
			"***Multiattacco.*** Il merrow effettua due attacchi: uno con il morso e uno con gli artigli o l'arpione.\n\n***Artigli.*** *Attacco con arma da mischia:* +6 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 9 (2d4 + 4) danni taglienti.\n\n***Morso.*** *Attacco con arma da mischia:* +6 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 8 (1d8 + 4) danni perforanti.\n\n***Arpione.*** *Attacco con arma da mischia o a distanza:* +6 al tiro per colpire, portata 1,5 m o gittata 6/18 m, un bersaglio. *Colpito:* 11 (2d6 + 4) danni perforanti. Se il bersaglio è una creatura di taglia Enorme o inferiore, deve vincere una prova di Forza contro il merrow, altrimenti verrà scagliato 6 metri verso il mostro.",
			"",
			""),
		new Text(
			"Merrow",
			null,
			"Large monstrosity, chaotic evil",
			"13 (natural armor)",
			"10 ft., swim 40 ft.",
			"",
			"",
			"",
			"",
			"",
			"",
			"darkvision 60 ft., passive Perception 10",
			"Abyssal, Aquan",
			"***Amphibious.*** The merrow can breathe air and water.",
			"***Multiattack.*** The merrow makes two attacks: one with its bite and one with its claws or harpoon.\n\n***Bite.*** *Melee Weapon Attack:* +6 to hit, reach 5 ft., one target. *Hit:* 8 (1d8 + 4) piercing damage.\n\n***Claws.*** *Melee Weapon Attack:* +6 to hit, reach 5 ft., one target. *Hit:* 9 (2d4 + 4) slashing damage.\n\n***Harpoon.*** *Melee or Ranged Weapon Attack:* +6 to hit, reach 5 ft. or range 20/60 ft., one target. *Hit:* 11 (2d6 + 4) piercing damage. If the target is a Huge or smaller creature, it must succeed on a Strength contest against the merrow or be pulled up to 20 feet toward the merrow.",
			"",
			""));
}
