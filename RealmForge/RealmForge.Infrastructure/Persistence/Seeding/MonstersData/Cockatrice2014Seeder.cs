using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Cockatrice (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Cockatrice2014Seeder
{
	public static Monster Build() => Create("cockatrice", null, ContentSource.Srd51, CreatureSize.Small, CreatureType.Monstrosity,
		11, 27, "6d6 + 6", 20, new[] { 6, 12, 12, 2, 13, 5 }, 0.5m, 100, 2, 11,
		new Text(
			"Cockatrice",
			null,
			"Mostruosità Piccola, senza allineamento",
			"11",
			"6 m, volare 12 m",
			"",
			"",
			"",
			"",
			"",
			"",
			"Percezione passiva 11, scurovisione 18 m",
			"—",
			"",
			"***Morso.*** *Attacco con arma da mischia:* +3 al tiro per colpire, portata 1,5 m, una creatura. *Colpito:* 3 (1d4 + 1) danni perforanti e il bersaglio deve superare un tiro salvezza su Costituzione con CD 11 per non essere pietrificato magicamente. Se la creatura fallisce il tiro salvezza, inizia a trasformarsi in pietra ed è trattenuta. Deve ripetere il tiro salvezza alla fine del suo turno successivo. Se lo supera, l'effetto svanisce. Se lo fallisce, è pietrificata per 24 ore.",
			"",
			"",
			"",
			""),
		new Text(
			"Cockatrice",
			null,
			"Small monstrosity, unaligned",
			"11",
			"20 ft., fly 40 ft.",
			"",
			"",
			"",
			"",
			"",
			"",
			"darkvision 60 ft., passive Perception 11",
			"—",
			"",
			"***Bite.*** *Melee Weapon Attack:* +3 to hit, reach 5 ft., one creature. *Hit:* 3 (1d4 + 1) piercing damage, and the target must succeed on a DC 11 Constitution saving throw against being magically petrified. On a failed save, the creature begins to turn to stone and is restrained. It must repeat the saving throw at the end of its next turn. On a success, the effect ends. On a failure, the creature is petrified for 24 hours.",
			"",
			"",
			"",
			""));
}
