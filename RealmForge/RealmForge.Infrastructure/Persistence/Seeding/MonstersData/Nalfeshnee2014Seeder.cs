using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Nalfeshnee (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Nalfeshnee2014Seeder
{
	public static Monster Build() => Create("nalfeshnee", null, ContentSource.Srd51, CreatureSize.Large, CreatureType.Fiend,
		18, 184, "16d10 + 96", 20, new[] { 21, 10, 22, 19, 12, 15 }, 13m, 10000, 5, 11,
		new Text(
			"Nalfeshnee",
			null,
			"Immondo Grande (demone), caotico malvagio",
			"18 (armatura naturale)",
			"6 m, volare 9 m",
			"Car +7, Cos +11, Int +9, Sag +6",
			"",
			"",
			"freddo, fulmine, fuoco; contundenti, perforanti e taglienti da attacchi non magici",
			"veleno",
			"avvelenato",
			"Percezione passiva 11, vista pura 36 m",
			"Abissale, telepatia 36 m",
			"***Resistenza alla magia.*** Il nalfeshnee dispone di vantaggio ai tiri salvezza contro incantesimi e altri effetti magici.",
			"***Multiattacco.*** Il nalfeshnee usa Nube di orrore, se ne è in grado. Poi effettua tre attacchi: uno con il morso e due con gli artigli.\n\n***Artiglio.*** *Attacco con arma da mischia:* +10 al tiro per colpire, portata 3 m, un bersaglio. *Colpito:* 15 (3d6 + 5) danni taglienti.\n\n***Morso.*** *Attacco con arma da mischia:* +10 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 32 (5d10 + 5) danni perforanti.\n\n***Nube di orrore (ricarica 5–6).*** Il nalfeshnee emette magicamente una luce multicolore scintillante. Ogni creatura entro 4,5 metri dal nalfeshnee che sia in grado di vedere la luce deve superare un tiro salvezza su Saggezza con CD 15, altrimenti è spaventata per 1 minuto. La creatura può ripetere il tiro salvezza alla fine di ogni suo turno e, se lo supera, l'effetto svanisce. Se il tiro salvezza di una creatura ha successo o l'effetto per lei termina, è immune alla Nube di orrore del nalfeshnee per le 24 ore successive.\n\n***Teletrasporto.*** Il nalfeshnee si teletrasporta magicamente, insieme a ogni oggetto che indossa o trasporta, fino a uno spazio libero visibile entro 36 metri.",
			"",
			"",
			"",
			""),
		new Text(
			"Nalfeshnee",
			null,
			"Large fiend (demon), chaotic evil",
			"18 (natural armor)",
			"20 ft., fly 30 ft.",
			"Con +11, Int +9, Wis +6, Cha +7",
			"",
			"",
			"cold, fire, lightning; bludgeoning, piercing, and slashing from nonmagical weapons",
			"poison",
			"poisoned",
			"truesight 120 ft., passive Perception 11",
			"Abyssal, telepathy 120 ft.",
			"***Magic Resistance.*** The nalfeshnee has advantage on saving throws against spells and other magical effects.",
			"***Multiattack.*** The nalfeshnee uses Horror Nimbus if it can. It then makes three attacks: one with its bite and two with its claws.\n\n***Bite.*** *Melee Weapon Attack:* +10 to hit, reach 5 ft., one target. *Hit:* 32 (5d10 + 5) piercing damage.\n\n***Claw.*** *Melee Weapon Attack:* +10 to hit, reach 10 ft., one target. *Hit:* 15 (3d6 + 5) slashing damage.\n\n***Horror Nimbus (Recharge 5–6).*** The nalfeshnee magically emits scintillating, multicolored light. Each creature within 15 feet of the nalfeshnee that can see the light must succeed on a DC 15 Wisdom saving throw or be frightened for 1 minute. A creature can repeat the saving throw at the end of each of its turns, ending the effect on itself on a success. If a creature's saving throw is successful or the effect ends for it, the creature is immune to the nalfeshnee's Horror Nimbus for the next 24 hours.\n\n***Teleport.*** The nalfeshnee magically teleports, along with any equipment it is wearing or carrying, up to 120 feet to an unoccupied space it can see.",
			"",
			"",
			"",
			""));
}
