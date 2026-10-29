using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Goblin (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Goblin2014Seeder
{
	public static Monster Build() => Create("goblin", null, ContentSource.Srd51, CreatureSize.Small, CreatureType.Humanoid,
		15, 7, "2d6", 30, new[] { 8, 14, 10, 10, 8, 8 }, 0.25m, 50, 2, 9,
		new Text(
			"Goblin",
			null,
			"Umanoide Piccolo (goblinoide), neutrale malvagio",
			"15 (armatura di cuoio, scudo)",
			"9 m",
			"",
			"Furtività +6",
			"",
			"",
			"",
			"",
			"Percezione passiva 9, scurovisione 18 m",
			"Comune, Goblin",
			"***Fuga agile.*** Il goblin può utilizzare l'azione disimpegno o nascondersi come azione bonus a ogni suo turno.",
			"***Scimitarra.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 5 (1d6 + 2) danni taglienti.\n\n***Arco corto.*** *Attacco con arma a distanza:* +4 al tiro per colpire, gittata 24/96 m, un bersaglio. *Colpito:* 5 (1d6 + 2) danni perforanti.",
			"",
			"",
			"",
			""),
		new Text(
			"Goblin",
			null,
			"Small humanoid (goblinoid), neutral evil",
			"15 (leather armor, shield)",
			"30 ft.",
			"",
			"Stealth +6",
			"",
			"",
			"",
			"",
			"darkvision 60 ft., passive Perception 9",
			"Common, Goblin",
			"***Nimble Escape.*** The goblin can take the Disengage or Hide action as a bonus action on each of its turns.",
			"***Scimitar.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one target. *Hit:* 5 (1d6 + 2) slashing damage.\n\n***Shortbow.*** *Ranged Weapon Attack:* +4 to hit, range 80/320 ft., one target. *Hit:* 5 (1d6 + 2) piercing damage.",
			"",
			"",
			"",
			""));
}
