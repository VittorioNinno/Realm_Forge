using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Shield Guardian (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class ShieldGuardian2014Seeder
{
	public static Monster Build() => Create("shield-guardian", null, CreatureSize.Large, CreatureType.Construct,
		17, 142, "15d10 + 60", 30, new[] { 18, 8, 18, 7, 10, 3 }, 7m, 2900, 3, 10,
		new Text(
			"Guardiano protettore",
			null,
			"Costrutto Grande, senza allineamento",
			"17 (armatura naturale)",
			"9 m",
			"",
			"",
			"",
			"",
			"veleno",
			"affascinato, avvelenato, indebolimento, paralizzato, spaventato",
			"Percezione passiva 10, scurovisione 18 m, vista cieca 3 m",
			"capisce i comandi impartiti in qualsiasi linguaggio, ma non è in grado di parlare",
			"***Accumula incantesimi.*** Un incantatore che indossa l'amuleto del guardiano protettore può fare in modo che il guardiano custodisca un incantesimo di 4° livello o inferiore. Per farlo, il portatore deve lanciare l'incantesimo sul guardiano. L'incantesimo non ha effetto, ma è custodito all'interno del guardiano. Quando il portatore gli ordina di farlo o quando si verifica una condizione predefinita dall'incantatore, il guardiano lancia l'incantesimo custodito usando gli eventuali parametri stabiliti dall'incantatore originale e senza bisogno di componenti. Quando l'incantesimo viene lanciato o se un nuovo incantesimo viene custodito nel guardiano, ogni eventuale incantesimo custodito in precedenza va perduto.\n\n***Rigenerazione.*** Il guardiano protettore recupera 10 punti ferita all'inizio del suo turno, se ha almeno 1 punto ferita.\n\n***Vincolato.*** Il guardiano protettore è vincolato magicamente a un amuleto. Finché il guardiano e il suo amuleto si trovano sullo stesso piano di esistenza, il portatore dell'amuleto può chiamare telepaticamente il guardiano affinché viaggi fino a lui. Il guardiano conosce la distanza e la direzione dell'oggetto. Se il guardiano si trova entro 18 metri dal portatore dell'amuleto, la metà dei danni (arrotondati per eccesso) che il portatore subisce viene trasferita al guardiano.",
			"***Multiattacco.*** Il guardiano effettua due attacchi con i pugni.\n\n***Pugno.*** *Attacco con arma da mischia:* +7 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 11 (2d6 + 4) danni contundenti.",
			"***Protettore.*** Quando una creatura effettua un attacco contro chi indossa l'amuleto, il guardiano concede un bonus di +2 alla CA del portatore se il guardiano si trova entro 1,5 metri da lui.",
			""),
		new Text(
			"Shield Guardian",
			null,
			"Large construct, unaligned",
			"17 (natural armor)",
			"30 ft.",
			"",
			"",
			"",
			"",
			"poison",
			"charmed, exhaustion, frightened, paralyzed, poisoned",
			"blindsight 10 ft., darkvision 60 ft., passive Perception 10",
			"understands commands given in any language but can't speak",
			"***Bound.*** The shield guardian is magically bound to an amulet. As long as the guardian and its amulet are on the same plane of existence, the amulet's wearer can telepathically call the guardian to travel to it, and the guardian knows the distance and direction to the amulet. If the guardian is within 60 feet of the amulet's wearer, half of any damage the wearer takes (rounded up) is transferred to the guardian.\n\n***Regeneration.*** The shield guardian regains 10 hit points at the start of its turn if it has at least 1 hit. point.\n\n***Spell Storing.*** A spellcaster who wears the shield guardian's amulet can cause the guardian to store one spell of 4th level or lower. To do so, the wearer must cast the spell on the guardian. The spell has no effect but is stored within the guardian. When commanded to do so by the wearer or when a situation arises that was predefined by the spellcaster, the guardian casts the stored spell with any parameters set by the original caster, requiring no components. When the spell is cast or a new spell is stored, any previously stored spell is lost.",
			"***Multiattack.*** The guardian makes two fist attacks.\n\n***Fist.*** *Melee Weapon Attack:* +7 to hit, reach 5 ft., one target. *Hit:* 11 (2d6 + 4) bludgeoning damage.",
			"***Shield.*** When a creature makes an attack against the wearer of the guardian's amulet, the guardian grants a +2 bonus to the wearer's AC if the guardian is within 5 feet of the wearer.",
			""));
}
