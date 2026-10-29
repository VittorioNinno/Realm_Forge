using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Acolyte (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Acolyte2014Seeder
{
	public static Monster Build() => Create("acolyte", null, ContentSource.Srd51, CreatureSize.Medium, CreatureType.Humanoid,
		10, 9, "2d8", 30, new[] { 10, 10, 10, 10, 14, 11 }, 0.25m, 50, 2, 12,
		new Text(
			"Accolito",
			null,
			"Umanoide Medio (qualsiasi razza), qualsiasi allineamento",
			"10",
			"9 m",
			"",
			"Medicina +4, Religione +2",
			"",
			"",
			"",
			"",
			"Percezione passiva 12",
			"uno qualsiasi (di solito Comune)",
			"***Incantesimi.*** L'accolito è un incantatore di 1° livello: la sua caratteristica da incantatore è Saggezza (CD del tiro salvezza sull'incantesimo 12, +4 al tiro per colpire con attacco con incantesimo). L'accolito ha a disposizione i seguenti incantesimi da chierico:\n\n- Trucchetti (a volontà): *fiamma sacra, luce, taumaturgia*\n- 1° livello (3 slot): *benedizione, cura ferite, santuario*",
			"***Randello.*** *Attacco con arma da mischia:* +2 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 2 (1d4) danni contundenti.",
			"",
			"",
			"",
			""),
		new Text(
			"Acolyte",
			null,
			"Medium humanoid (any race), any alignment",
			"10",
			"30 ft.",
			"",
			"Medicine +4, Religion +2",
			"",
			"",
			"",
			"",
			"passive Perception 12",
			"any one language (usually Common)",
			"***Spellcasting.*** The acolyte is a 1st-level spellcaster. Its spellcasting ability is Wisdom (spell save DC 12, +4 to hit with spell attacks). The acolyte has following cleric spells prepared:\n\n- Cantrips (at will): *light, sacred flame, thaumaturgy*\n- 1st level (3 slots): *bless, cure wounds, sanctuary*",
			"***Club.*** *Melee Weapon Attack:* +2 to hit, reach 5 ft., one target. *Hit:* 2 (1d4) bludgeoning damage.",
			"",
			"",
			"",
			""));
}
