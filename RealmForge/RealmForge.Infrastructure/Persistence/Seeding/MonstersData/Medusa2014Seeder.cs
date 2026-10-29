using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Medusa (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Medusa2014Seeder
{
	public static Monster Build() => Create("medusa", null, ContentSource.Srd51, CreatureSize.Medium, CreatureType.Monstrosity,
		15, 127, "17d8 + 51", 30, new[] { 10, 15, 16, 12, 13, 15 }, 6m, 2300, 3, 14,
		new Text(
			"Medusa",
			null,
			"Mostruosità Media, legale malvagia",
			"15 (armatura naturale)",
			"9 m",
			"",
			"Furtività +5, Inganno +5, Intuizione +4, Percezione +4",
			"",
			"",
			"",
			"",
			"Percezione passiva 14, scurovisione 18 m",
			"Comune",
			"***Sguardo pietrificante.*** Se una creatura in grado di vedere gli occhi della medusa inizia il proprio turno entro 9 metri da essa, la medusa può obbligarla a effettuare un tiro salvezza su Costituzione con CD 14 (se non è incapacitata ed è in grado di vedere la creatura). Se la creatura fallisce il tiro salvezza di 5 o più, viene pietrificata all'istante. Altrimenti inizia a trasformarsi magicamente in pietra e viene trattenuta. Deve ripetere il tiro salvezza alla fine del suo turno successivo. Se lo supera, l'effetto termina. Se lo fallisce, è pietrificata finché non viene liberata tramite un incantesimo *ristorare superiore* o un'altra magia analoga. A meno che non venga colta di sorpresa, una creatura può distogliere lo sguardo per evitare il tiro salvezza all'inizio del suo turno. Se la creatura si avvale di questa facoltà, non vede la medusa fino all'inizio del proprio turno successivo, quando potrà distogliere nuovamente lo sguardo. Tuttavia, se nel frattempo la creatura guarda la medusa, deve effettuare immediatamente il tiro salvezza. Se la medusa vede il suo riflesso entro 9 metri da sé in condizioni di luce intensa, è influenzata dal suo stesso sguardo a causa della sua maledizione.",
			"***Multiattacco.*** La medusa effettua tre attacchi in mischia (uno con la chioma di serpenti e due con la spada corta) o due attacchi a distanza con l'arco lungo.\n\n***Chioma di serpenti.*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, una creatura. *Colpito:* 4 (1d4 + 2) danni perforanti più 14 (4d6) danni da veleno.\n\n***Spada corta.*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 5 (1d6 + 2) danni perforanti.\n\n***Arco lungo.*** *Attacco con arma a distanza:* +5 al tiro per colpire, gittata 45/180 m, un bersaglio. *Colpito:* 6 (1d8 + 2) danni perforanti più 7 (2d6) danni da veleno.",
			"",
			"",
			"",
			""),
		new Text(
			"Medusa",
			null,
			"Medium monstrosity, lawful evil",
			"15 (natural armor)",
			"30 ft.",
			"",
			"Deception +5, Insight +4, Perception +4, Stealth +5",
			"",
			"",
			"",
			"",
			"darkvision 60 ft., passive Perception 14",
			"Common",
			"***Petrifying Gaze.*** When a creature that can see the medusa's eyes starts its turn within 30 ft. of the medusa, the medusa can force it to make a DC 14 Constitution saving throw if the medusa isn't incapacitated and can see the creature. If the saving throw fails by 5 or more, the creature is instantly petrified. Otherwise, a creature that fails the save begins to turn to stone and is restrained. The restrained creature must repeat the saving throw at the end of its next turn, becoming petrified on a failure or ending the effect on a success. The petrification lasts until the creature is freed by the greater restoration spell or other magic.\n\nUnless surprised, a creature can avert its eyes to avoid the saving throw at the start of its turn. If the creature does so, it can't see the medusa until the start of its next turn, when it can avert its eyes again. If the creature looks at the medusa in the meantime, it must immediately make the save.\nIf the medusa sees itself reflected on a polished surface within 30 ft. of it and in an area of bright light, the medusa is, due to its curse, affected by its own gaze.",
			"***Multiattack.*** The medusa makes either three melee attacks--one with its snake hair and two with its shortsword--or two ranged attacks with its longbow.\n\n***Snake Hair.*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one creature. *Hit:* 4 (1d4 + 2) piercing damage plus 14 (4d6) poison damage.\n\n***Shortsword.*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one target. *Hit:* 5 (1d6 + 2) piercing damage.\n\n***Longbow.*** *Ranged Weapon Attack:* +5 to hit, range 150/600 ft., one target. *Hit:* 6 (1d8 + 2) piercing damage plus 7 (2d6) poison damage.",
			"",
			"",
			"",
			""));
}
