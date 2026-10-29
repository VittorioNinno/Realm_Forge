using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Hezrou (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Hezrou2014Seeder
{
	public static Monster Build() => Create("hezrou", null, ContentSource.Srd51, CreatureSize.Large, CreatureType.Fiend,
		16, 136, "13d10 + 65", 30, new[] { 19, 17, 20, 5, 12, 13 }, 8m, 3900, 3, 11,
		new Text(
			"Hezrou",
			null,
			"Immondo Grande (demone), caotico malvagio",
			"16 (armatura naturale)",
			"9 m",
			"Cos +8, For +7, Sag +4",
			"",
			"",
			"freddo, fulmine, fuoco; contundenti, perforanti e taglienti da attacchi non magici",
			"veleno",
			"avvelenato",
			"Percezione passiva 11, scurovisione 36 m",
			"Abissale, telepatia 36 m",
			"***Fetore.*** Ogni creatura che inizia il proprio turno entro 3 metri dall'hezrou deve superare un tiro salvezza su Costituzione con CD 14, altrimenti è avvelenata fino all'inizio del proprio turno successivo. Se supera il tiro salvezza, la creatura è immune al fetore dell'hezrou per 24 ore.\n\n***Resistenza alla magia.*** L'hezrou dispone di vantaggio ai tiri salvezza contro incantesimi e altri effetti magici.",
			"***Multiattacco.*** L'hezrou effettua tre attacchi: uno con il morso e due con gli artigli.\n\n***Artiglio.*** *Attacco con arma da mischia:* +7 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 11 (2d6 + 4) danni taglienti.\n\n***Morso.*** *Attacco con arma da mischia:* +7 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 15 (2d10 + 4) danni perforanti.",
			"",
			"",
			"",
			""),
		new Text(
			"Hezrou",
			null,
			"Large fiend (demon), chaotic evil",
			"16 (natural armor)",
			"30 ft.",
			"Str +7, Con +8, Wis +4",
			"",
			"",
			"cold, fire, lightning; bludgeoning, piercing, and slashing from nonmagical weapons",
			"poison",
			"poisoned",
			"darkvision 120 ft., passive Perception 11",
			"Abyssal, telepathy 120 ft.",
			"***Magic Resistance.*** The hezrou has advantage on saving throws against spells and other magical effects.\n\n***Stench.*** Any creature that starts its turn within 10 feet of the hezrou must succeed on a DC 14 Constitution saving throw or be poisoned until the start of its next turn. On a successful saving throw, the creature is immune to the hezrou's stench for 24 hours.",
			"***Multiattack.*** The hezrou makes three attacks: one with its bite and two with its claws.\n\n***Bite.*** *Melee Weapon Attack:* +7 to hit, reach 5 ft., one target. *Hit:* 15 (2d10 + 4) piercing damage.\n\n***Claws.*** *Melee Weapon Attack:* +7 to hit, reach 5 ft., one target. *Hit:* 11 (2d6 + 4) slashing damage.",
			"",
			"",
			"",
			""));
}
