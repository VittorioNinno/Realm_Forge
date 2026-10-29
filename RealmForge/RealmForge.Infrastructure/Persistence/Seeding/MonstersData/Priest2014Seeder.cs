using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Priest (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Priest2014Seeder
{
	public static Monster Build() => Create("priest", null, CreatureSize.Medium, CreatureType.Humanoid,
		13, 27, "5d8 + 5", 25, new[] { 10, 10, 12, 13, 16, 13 }, 2m, 450, 2, 13,
		new Text(
			"Sacerdote",
			null,
			"Umanoide Medio (qualsiasi razza), qualsiasi allineamento",
			"13 (giaco di maglia)",
			"7,5 m",
			"",
			"Medicina +7, Persuasione +3, Religione +4",
			"",
			"",
			"",
			"",
			"Percezione passiva 13",
			"due qualsiasi",
			"***Eminenza divina.*** Come azione bonus, il sacerdote può spendere uno slot incantesimo per fare in modo che i suoi attacchi con arma da mischia infliggano magicamente 10 (3d6) danni radiosi extra a un bersaglio se vanno a segno. Questo beneficio permane fino alla fine del turno. Se il sacerdote spende uno slot incantesimo di livello pari o superiore al 2°, i danni extra aumentano di 1d6 per ogni livello oltre il 1°.\n\n***Incantesimi.*** Il sacerdote è un incantatore di 5° livello: la sua caratteristica da incantatore è Saggezza (CD del tiro salvezza sull'incantesimo 13, +5 al tiro per colpire con attacco con incantesimo). Ha a disposizione i seguenti incantesimi da chierico:\n\n- Trucchetti (a volontà): *fiamma sacra, luce, taumaturgia*\n- 1° livello (4 slot): *cura ferite, dardo tracciante, santuario*\n- 2° livello (3 slot): *arma spirituale, ristorare inferiore*\n- 3° livello (2 slot): *dissolvi magie, guardiani spirituali*",
			"***Mazza.*** *Attacco con arma da mischia:* +2 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 3 (1d6) danni contundenti.",
			"",
			""),
		new Text(
			"Priest",
			null,
			"Medium humanoid (any race), any alignment",
			"13 (chain shirt)",
			"25 ft.",
			"",
			"Medicine +7, Persuasion +3, Religion +4",
			"",
			"",
			"",
			"",
			"passive Perception 13",
			"any two languages",
			"***Divine Eminence.*** As a bonus action, the priest can expend a spell slot to cause its melee weapon attacks to magically deal an extra 10 (3d6) radiant damage to a target on a hit. This benefit lasts until the end of the turn. If the priest expends a spell slot of 2nd level or higher, the extra damage increases by 1d6 for each level above 1st.\n\n***Spellcasting.*** The priest is a 5th-level spellcaster. Its spellcasting ability is Wisdom (spell save DC 13, +5 to hit with spell attacks). The priest has the following cleric spells prepared:\n\n- Cantrips (at will): *light, sacred flame, thaumaturgy*\n- 1st level (4 slots): *cure wounds, guiding bolt, sanctuary*\n- 2nd level (3 slots): *lesser restoration, spiritual weapon*\n- 3rd level (2 slots): *dispel magic, spirit guardians*",
			"***Mace.*** *Melee Weapon Attack:* +2 to hit, reach 5 ft., one target. *Hit:* 3 (1d6) bludgeoning damage.",
			"",
			""));
}
