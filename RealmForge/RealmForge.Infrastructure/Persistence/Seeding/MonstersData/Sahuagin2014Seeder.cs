using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Sahuagin (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Sahuagin2014Seeder
{
	public static Monster Build() => Create("sahuagin", null, CreatureSize.Medium, CreatureType.Humanoid,
		12, 22, "4d8 + 4", 30, new[] { 13, 11, 12, 12, 13, 9 }, 0.5m, 100, 2, 15,
		new Text(
			"Sahuagin",
			null,
			"Umanoide Medio (sahuagin), legale malvagio",
			"12 (armatura naturale)",
			"9 m, nuotare 12 m",
			"",
			"Percezione +5",
			"",
			"",
			"",
			"",
			"Percezione passiva 15, scurovisione 36 m",
			"Sahuagin",
			"***Anfibio limitato.*** Il sahuagin può respirare in aria e in acqua, ma deve immergersi in acqua almeno una volta ogni 4 ore per evitare di soffocare.\n\n***Frenesia di sangue.*** Il sahuagin dispone di vantaggio ai tiri per colpire in mischia contro ogni creatura che non possieda tutti i propri punti ferita.\n\n***Telepatia con gli squali.*** Il sahuagin può comandare magicamente ogni squalo entro 36 metri da lui, usando una forma limitata di telepatia.",
			"***Multiattacco.*** Il sahuagin effettua due attacchi in mischia: uno con il morso e uno con gli artigli o con la lancia.\n\n***Artigli.*** *Attacco con arma da mischia:* +3 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 3 (1d4 + 1) danni taglienti.\n\n***Morso.*** *Attacco con arma da mischia:* +3 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 3 (1d4 + 1) danni perforanti.\n\n***Lancia.*** *Attacco con arma da mischia o a distanza:* +3 al tiro per colpire, portata 1,5 m o gittata 6/18 m, un bersaglio. *Colpito:* 4 (1d6 + 1) danni perforanti o 5 (1d8 + 1) danni perforanti se impugnata con due mani per effettuare un attacco in mischia.",
			"",
			""),
		new Text(
			"Sahuagin",
			null,
			"Medium humanoid (sahuagin), lawful evil",
			"12 (natural armor)",
			"30 ft., swim 40 ft.",
			"",
			"Perception +5",
			"",
			"",
			"",
			"",
			"darkvision 120 ft., passive Perception 15",
			"Sahuagin",
			"***Blood Frenzy.*** The sahuagin has advantage on melee attack rolls against any creature that doesn't have all its hit points.\n\n***Limited Amphibiousness.*** The sahuagin can breathe air and water, but it needs to be submerged at least once every 4 hours to avoid suffocating.\n\n***Shark Telepathy.*** The sahuagin can magically command any shark within 120 feet of it, using a limited telepathy.",
			"***Multiattack.*** The sahuagin makes two melee attacks: one with its bite and one with its claws or spear.\n\n***Bite.*** *Melee Weapon Attack:* +3 to hit, reach 5 ft., one target. *Hit:* 3 (1d4 + 1) piercing damage.\n\n***Claws.*** *Melee Weapon Attack:* +3 to hit, reach 5 ft., one target. *Hit:* 3 (1d4 + 1) slashing damage.\n\n***Spear.*** *Melee or Ranged Weapon Attack:* +3 to hit, reach 5 ft. or range 20/60 ft., one target. *Hit:* 4 (1d6 + 1) piercing damage, or 5 (1d8 + 1) piercing damage if used with two hands to make a melee attack.",
			"",
			""));
}
