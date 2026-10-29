using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Ghast (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Ghast2014Seeder
{
	public static Monster Build() => Create("ghast", null, CreatureSize.Medium, CreatureType.Undead,
		13, 36, "8d8", 30, new[] { 16, 17, 10, 11, 10, 8 }, 2m, 450, 2, 10,
		new Text(
			"Ghast",
			null,
			"Non morto Medio, caotico malvagio",
			"13",
			"9 m",
			"",
			"",
			"",
			"necrotici",
			"veleno",
			"affascinato, avvelenato, indebolimento",
			"Percezione passiva 10, scurovisione 18 m",
			"Comune",
			"***Fetore.*** Ogni creatura che inizi il suo turno entro 1,5 metri dal ghast deve superare un tiro salvezza su Costituzione con CD 10, altrimenti è avvelenata fino all'inizio del proprio turno successivo. Se supera il tiro salvezza, la creatura è immune al fetore del ghast per 24 ore.\n\n***Scacciare contrastato.*** Il ghast e ogni ghoul entro 9 metri da esso dispongono di vantaggio ai tiri salvezza contro gli effetti che scacciano i non morti.",
			"***Artigli.*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 10 (2d6 + 3) danni taglienti. Se il bersaglio è una creatura diversa da un non morto, deve superare un tiro salvezza su Costituzione con CD 10, altrimenti viene paralizzato per 1 minuto. Il bersaglio può ripetere il tiro salvezza alla fine di ogni suo turno e, se lo supera, l'effetto svanisce.\n\n***Morso.*** *Attacco con arma da mischia:* +3 al tiro per colpire, portata 1,5 m, una creatura. *Colpito:* 12 (2d8 + 3) danni perforanti.",
			"",
			""),
		new Text(
			"Ghast",
			null,
			"Medium undead, chaotic evil",
			"13",
			"30 ft.",
			"",
			"",
			"",
			"necrotic",
			"poison",
			"poisoned, charmed, exhaustion",
			"darkvision 60 ft., passive Perception 10",
			"Common",
			"***Stench.*** Any creature that starts its turn within 5 ft. of the ghast must succeed on a DC 10 Constitution saving throw or be poisoned until the start of its next turn. On a successful saving throw, the creature is immune to the ghast's Stench for 24 hours.\n\n***Turn Defiance.*** The ghast and any ghouls within 30 ft. of it have advantage on saving throws against effects that turn undead.",
			"***Bite.*** *Melee Weapon Attack:* +3 to hit, reach 5 ft., one creature. *Hit:* 12 (2d8 + 3) piercing damage.\n\n***Claws.*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one target. *Hit:* 10 (2d6 + 3) slashing damage. If the target is a creature other than an undead, it must succeed on a DC 10 Constitution saving throw or be paralyzed for 1 minute. The target can repeat the saving throw at the end of each of its turns, ending the effect on itself on a success.",
			"",
			""));
}
