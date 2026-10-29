using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Kobold (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Kobold2014Seeder
{
	public static Monster Build() => Create("kobold", null, CreatureSize.Small, CreatureType.Humanoid,
		12, 5, "2d6 - 2", 30, new[] { 7, 15, 9, 8, 7, 8 }, 0.125m, 25, 2, 8,
		new Text(
			"Coboldo",
			null,
			"Umanoide Piccolo (coboldo), legale malvagio",
			"12",
			"9 m",
			"",
			"",
			"",
			"",
			"",
			"",
			"Percezione passiva 8, scurovisione 18 m",
			"Comune, Draconico",
			"***Sensibilità al sole.*** Mentre è alla luce del sole, il coboldo ha uno svantaggio ai tiri per colpire, così come nelle prove di Saggezza (Percezione) che si basano sulla vista.\n\n***Tattiche del branco.*** Il coboldo dispone di vantaggio nel tiro per colpire contro una creatura se almeno uno degli alleati del mostro si trova entro 1,5 metri dalla creatura e non è incapacitato.",
			"***Pugnale.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 4 (1d4 + 2) danni perforanti.\n\n***Fionda.*** *Attacco con arma a distanza:* +4 al tiro per colpire, gittata 9/36 m, un bersaglio. *Colpito:* 4 (1d4 + 2) danni contundenti.",
			"",
			""),
		new Text(
			"Kobold",
			null,
			"Small humanoid (kobold), lawful evil",
			"12",
			"30 ft.",
			"",
			"",
			"",
			"",
			"",
			"",
			"darkvision 60 ft., passive Perception 8",
			"Common, Draconic",
			"***Sunlight Sensitivity.*** While in sunlight, the kobold has disadvantage on attack rolls, as well as on Wisdom (Perception) checks that rely on sight.\n\n***Pack Tactics.*** The kobold has advantage on an attack roll against a creature if at least one of the kobold's allies is within 5 ft. of the creature and the ally isn't incapacitated.",
			"***Dagger.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one target. *Hit:* 4 (1d4 + 2) piercing damage.\n\n***Sling.*** *Ranged Weapon Attack:* +4 to hit, range 30/120 ft., one target. *Hit:* 4 (1d4 + 2) bludgeoning damage.",
			"",
			""));
}
