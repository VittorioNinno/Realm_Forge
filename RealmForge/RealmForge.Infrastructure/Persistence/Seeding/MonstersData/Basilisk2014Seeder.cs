using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Basilisk (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Basilisk2014Seeder
{
	public static Monster Build() => Create("basilisk", null, ContentSource.Srd51, CreatureSize.Medium, CreatureType.Monstrosity,
		15, 52, "8d8 + 16", 20, new[] { 16, 8, 15, 2, 8, 7 }, 3m, 700, 2, 9,
		new Text(
			"Basilisco",
			null,
			"Mostruosità Media, senza allineamento",
			"15 (armatura naturale)",
			"6 m",
			"",
			"",
			"",
			"",
			"",
			"",
			"Percezione passiva 9, scurovisione 18 m",
			"—",
			"***Sguardo pietrificante.*** Se una creatura inizia il proprio turno entro 9 metri dal basilisco e i due sono in grado di vedersi a vicenda, il basilisco può obbligare la creatura a effettuare un tiro salvezza su Costituzione con CD 12 (se non è incapacitato). Se la creatura fallisce, inizia a trasformarsi magicamente in pietra ed è trattenuta. Deve ripetere il tiro salvezza alla fine del suo turno successivo. Se lo supera, l'effetto svanisce. In caso di fallimento, la creatura rimane pietrificata finché non viene liberata dall'incantesimo *ristorare superiore* o da altre magie. A meno che non venga colta di sorpresa, una creatura può distogliere lo sguardo per evitare il tiro salvezza all'inizio del suo turno. Se lo fa, non può vedere il basilisco fino all'inizio del proprio turno successivo, quando potrà distogliere lo sguardo di nuovo. Se nel frattempo guarda il basilisco, deve immediatamente effettuare il tiro salvezza. Se il basilisco vede il suo riflesso entro 9 metri da sé in condizioni di luce intensa, crede erroneamente che il suo riflesso sia un rivale e bersaglia se stesso col suo sguardo.",
			"***Morso.*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 10 (2d6 + 3) danni perforanti più 7 (2d6) danni da veleno.",
			"",
			"",
			"",
			""),
		new Text(
			"Basilisk",
			null,
			"Medium monstrosity, unaligned",
			"15 (natural armor)",
			"20 ft.",
			"",
			"",
			"",
			"",
			"",
			"",
			"darkvision 60 ft., passive Perception 9",
			"—",
			"***Petrifying Gaze.*** If a creature starts its turn within 30 ft. of the basilisk and the two of them can see each other, the basilisk can force the creature to make a DC 12 Constitution saving throw if the basilisk isn't incapacitated. On a failed save, the creature magically begins to turn to stone and is restrained. It must repeat the saving throw at the end of its next turn. On a success, the effect ends. On a failure, the creature is petrified until freed by the greater restoration spell or other magic.\n\nA creature that isn't surprised can avert its eyes to avoid the saving throw at the start of its turn. If it does so, it can't see the basilisk until the start of its next turn, when it can avert its eyes again. If it looks at the basilisk in the meantime, it must immediately make the save.\nIf the basilisk sees its reflection within 30 ft. of it in bright light, it mistakes itself for a rival and targets itself with its gaze.",
			"***Bite.*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one target. *Hit:* 10 (2d6 + 3) piercing damage plus 7 (2d6) poison damage.",
			"",
			"",
			"",
			""));
}
