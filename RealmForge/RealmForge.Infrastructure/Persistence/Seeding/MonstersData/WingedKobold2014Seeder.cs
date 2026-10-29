using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Winged Kobold (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class WingedKobold2014Seeder
{
	public static Monster Build() => Create("winged-kobold", null, ContentSource.RealmForge, CreatureSize.Small, CreatureType.Humanoid,
		13, 7, "3d6 - 3", 30, new[] { 7, 16, 9, 8, 7, 8 }, 0.25m, 50, 2, 8,
		new Text(
			"Coboldo alato",
			"Urd",
			"Umanoide Piccolo (coboldo), legale malvagio",
			"13",
			"9 m, volare 9 m",
			"",
			"",
			"",
			"",
			"",
			"",
			"Percezione passiva 8, scurovisione 18 m",
			"Comune, Draconico",
			"***Sensibilità alla luce del sole.*** Finché si trova alla luce del sole, il coboldo subisce svantaggio ai tiri per colpire e alle prove di Saggezza (Percezione) basate sulla vista.\n\n***Tattiche del branco.*** Il coboldo dispone di vantaggio al tiro per colpire contro una creatura se almeno uno dei suoi alleati si trova entro 1,5 metri da essa e non è incapacitato.",
			"***Pugnale.*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 5 (1d4 + 3) danni perforanti.\n\n***Sasso lasciato cadere.*** *Attacco con arma a distanza:* +5 al tiro per colpire, un bersaglio direttamente sotto il coboldo. *Colpito:* 6 (1d6 + 3) danni contundenti.",
			"",
			"",
			"",
			""),
		new Text(
			"Winged Kobold",
			null,
			"Small humanoid (kobold), lawful evil",
			"13",
			"30 ft., fly 30 ft.",
			"",
			"",
			"",
			"",
			"",
			"",
			"darkvision 60 ft., passive Perception 8",
			"Common, Draconic",
			"***Sunlight Sensitivity.*** While in sunlight, the kobold has disadvantage on attack rolls, as well as on Wisdom (Perception) checks that rely on sight.\n\n***Pack Tactics.*** The kobold has advantage on an attack roll against a creature if at least one of the kobold's allies is within 5 feet of the creature and the ally isn't incapacitated.",
			"***Dagger.*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one target. *Hit:* 5 (1d4 + 3) piercing damage.\n\n***Dropped Rock.*** *Ranged Weapon Attack:* +5 to hit, one target directly below the kobold. *Hit:* 6 (1d6 + 3) bludgeoning damage.",
			"",
			"",
			"",
			""));
}
