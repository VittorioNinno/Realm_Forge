using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Ghoul (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Ghoul2014Seeder
{
	public static Monster Build() => Create("ghoul", null, ContentSource.Srd51, CreatureSize.Medium, CreatureType.Undead,
		12, 22, "5d8", 30, new[] { 13, 15, 10, 7, 10, 6 }, 1m, 200, 2, 10,
		new Text(
			"Ghoul",
			null,
			"Non morto Medio, caotico malvagio",
			"12",
			"9 m",
			"",
			"",
			"",
			"",
			"veleno",
			"affascinato, avvelenato, indebolimento",
			"Percezione passiva 10, scurovisione 18 m",
			"Comune",
			"",
			"***Artigli.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 7 (2d4 + 2) danni taglienti. Se il bersaglio è una creatura diversa da un elfo o un non morto, deve superare un tiro salvezza su Costituzione con CD 10, altrimenti viene paralizzato per 1 minuto. Il bersaglio può ripetere il tiro salvezza alla fine di ogni suo turno e, se lo supera, l'effetto svanisce.\n\n***Morso.*** *Attacco con arma da mischia:* +2 al tiro per colpire, portata 1,5 m, una creatura. *Colpito:* 9 (2d6 + 2) danni perforanti.",
			"",
			"",
			"",
			""),
		new Text(
			"Ghoul",
			null,
			"Medium undead, chaotic evil",
			"12",
			"30 ft.",
			"",
			"",
			"",
			"",
			"poison",
			"poisoned, charmed, exhaustion",
			"darkvision 60 ft., passive Perception 10",
			"Common",
			"",
			"***Bite.*** *Melee Weapon Attack:* +2 to hit, reach 5 ft., one creature. *Hit:* 9 (2d6 + 2) piercing damage.\n\n***Claws.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one target. *Hit:* 7 (2d4 + 2) slashing damage. If the target is a creature other than an elf or undead, it must succeed on a DC 10 Constitution saving throw or be paralyzed for 1 minute. The target can repeat the saving throw at the end of each of its turns, ending the effect on itself on a success.",
			"",
			"",
			"",
			""));
}
