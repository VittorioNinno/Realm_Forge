using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Homunculus (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Homunculus2014Seeder
{
	public static Monster Build() => Create("homunculus", null, CreatureSize.Tiny, CreatureType.Construct,
		13, 5, "2d4", 20, new[] { 4, 15, 11, 10, 10, 7 }, 0m, 10, 2, 10,
		new Text(
			"Omuncolo",
			null,
			"Costrutto Minuscolo, neutrale",
			"13 (armatura naturale)",
			"6 m, volare 12 m",
			"",
			"",
			"",
			"",
			"veleno",
			"affascinato, avvelenato",
			"Percezione passiva 10, scurovisione 18 m",
			"comprende i linguaggi del suo creatore ma non li sa parlare",
			"***Legame telepatico.*** Finché l'omuncolo si trova sullo stesso piano di esistenza del suo padrone, può trasmettergli magicamente ciò che percepisce e i due possono comunicare telepaticamente.",
			"***Morso.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, una creatura. *Colpito:* 1 danno perforante e il bersaglio deve superare un tiro salvezza su Costituzione con CD 10, altrimenti è avvelenato per 1 minuto. Se fallisce il tiro salvezza di 5 o più, il bersaglio è invece avvelenato per 5 (1d10) minuti ed è privo di sensi finché è in questo stato.",
			"",
			""),
		new Text(
			"Homunculus",
			null,
			"Tiny construct, neutral",
			"13 (natural armor)",
			"20 ft., fly 40 ft.",
			"",
			"",
			"",
			"",
			"poison",
			"charmed, poisoned",
			"darkvision 60 ft., passive Perception 10",
			"understands the languages of its creator but can't speak",
			"***Telepathic Bond.*** While the homunculus is on the same plane of existence as its master, it can magically convey what it senses to its master, and the two can communicate telepathically.",
			"***Bite.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one creature. *Hit:* 1 piercing damage, and the target must succeed on a DC 10 Constitution saving throw or be poisoned for 1 minute. If the saving throw fails by 5 or more, the target is instead poisoned for 5 (1d10) minutes and unconscious while poisoned in this way.",
			"",
			""));
}
