using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Lizardfolk (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Lizardfolk2014Seeder
{
	public static Monster Build() => Create("lizardfolk", null, ContentSource.Srd51, CreatureSize.Medium, CreatureType.Humanoid,
		15, 22, "4d8 + 4", 30, new[] { 15, 10, 13, 7, 12, 7 }, 0.5m, 100, 2, 13,
		new Text(
			"Lucertoloide",
			null,
			"Umanoide Medio (lucertoloide), neutrale",
			"15 (armatura naturale, scudo)",
			"9 m, nuotare 9 m",
			"",
			"Furtività +4, Percezione +3, Sopravvivenza +5",
			"",
			"",
			"",
			"",
			"Percezione passiva 13",
			"Draconico",
			"***Apnea.*** Il lucertoloide può trattenere il respiro per 15 minuti.",
			"***Multiattacco.*** Il lucertoloide effettua due attacchi in mischia, ognuno con un'arma diversa.\n\n***Mazza pesante.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 5 (1d6 + 2) danni contundenti.\n\n***Morso.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 5 (1d6 + 2) danni perforanti.\n\n***Scudo chiodato.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 5 (1d6 + 2) danni perforanti.\n\n***Giavellotto.*** *Attacco con arma da mischia o a distanza:* +4 al tiro per colpire, portata 1,5 m o gittata 9/36 m, un bersaglio. *Colpito:* 5 (1d6 + 2) danni perforanti.",
			"",
			"",
			"",
			""),
		new Text(
			"Lizardfolk",
			null,
			"Medium humanoid (lizardfolk), neutral",
			"15 (natural armor, shield)",
			"30 ft., swim 30 ft.",
			"",
			"Perception +3, Stealth +4, Survival +5",
			"",
			"",
			"",
			"",
			"passive Perception 13",
			"Draconic",
			"***Hold Breath.*** The lizardfolk can hold its breath for 15 minutes.",
			"***Multiattack.*** The lizardfolk makes two melee attacks, each one with a different weapon.\n\n***Bite.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one target. *Hit:* 5 (1d6 + 2) piercing damage.\n\n***Heavy Club.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one target. *Hit:* 5 (1d6 + 2) bludgeoning damage.\n\n***Javelin.*** *Melee or Ranged Weapon Attack:* +4 to hit, reach 5 ft. or range 30/120 ft., one target. *Hit:* 5 (1d6 + 2) piercing damage.\n\n***Spiked Shield.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one target. *Hit:* 5 (1d6 + 2) piercing damage.",
			"",
			"",
			"",
			""));
}
