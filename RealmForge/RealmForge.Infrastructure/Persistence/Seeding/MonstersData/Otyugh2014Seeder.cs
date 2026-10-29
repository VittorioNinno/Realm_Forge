using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Otyugh (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Otyugh2014Seeder
{
	public static Monster Build() => Create("otyugh", null, ContentSource.Srd51, CreatureSize.Large, CreatureType.Aberration,
		14, 114, "12d10 + 48", 30, new[] { 16, 11, 19, 6, 13, 6 }, 5m, 1800, 3, 11,
		new Text(
			"Otyugh",
			null,
			"Aberrazione Grande, neutrale",
			"14 (armatura naturale)",
			"9 m",
			"Cos +7",
			"",
			"",
			"",
			"",
			"",
			"Percezione passiva 11, scurovisione 36 m",
			"Otyugh",
			"***Telepatia limitata.*** L'otyugh può trasmettere magicamente messaggi e immagini semplici a qualsiasi creatura situata entro 36 metri da lui e che sia in grado di comprendere un linguaggio. Questa forma di telepatia non consente alla creatura che riceve il messaggio di rispondere telepaticamente.",
			"***Multiattacco.*** L'otyugh effettua tre attacchi: uno con il morso e due con i tentacoli.\n\n***Morso.*** *Attacco con arma da mischia:* +6 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 12 (2d8 + 3) danni perforanti. Se il bersaglio è una creatura, deve superare un tiro salvezza su Costituzione con CD 15 contro le malattie, altrimenti è avvelenato finché la malattia non viene curata. Dopo ogni 24 ore, il bersaglio deve ripetere il tiro salvezza; riduce i suoi punti ferita massimi di 5 (1d10) in caso di fallimento, e viene curato dalla malattia in caso di successo. Se la malattia porta i suoi punti ferita massimi a 0, il bersaglio muore. Questa riduzione dei punti ferita massimi del bersaglio dura finché la malattia non viene curata.\n\n***Tentacolo.*** *Attacco con arma da mischia:* +6 al tiro per colpire, portata 3 m, un bersaglio. *Colpito:* 7 (1d8 + 3) danni contundenti più 4 (1d8) danni perforanti. Se il bersaglio è di taglia Media o inferiore, viene afferrato (CD 13 per sfuggire) e, finché l'otyugh non molla la presa, è trattenuto. Il mostro possiede due tentacoli, ognuno dei quali può afferrare un bersaglio.\n\n***Schianto con tentacolo.*** L'otyugh scaglia le creature afferrate l'una contro l'altra o contro una superficie solida. Ogni creatura deve superare un tiro salvezza su Costituzione con CD 14, altrimenti subisce 10 (2d6 + 3) danni contundenti ed è stordita fino alla fine del turno successivo dell'otyugh. Se supera il tiro salvezza, il bersaglio subisce la metà dei danni contundenti e non è stordito.",
			"",
			"",
			"",
			""),
		new Text(
			"Otyugh",
			null,
			"Large aberration, neutral",
			"14 (natural armor)",
			"30 ft.",
			"Con +7",
			"",
			"",
			"",
			"",
			"",
			"darkvision 120 ft., passive Perception 11",
			"Otyugh",
			"***Limited Telepathy.*** The otyugh can magically transmit simple messages and images to any creature within 120 ft. of it that can understand a language. This form of telepathy doesn't allow the receiving creature to telepathically respond.",
			"***Multiattack.*** The otyugh makes three attacks: one with its bite and two with its tentacles.\n\n***Bite.*** *Melee Weapon Attack:* +6 to hit, reach 5 ft., one target. *Hit:* 12 (2d8 + 3) piercing damage. If the target is a creature, it must succeed on a DC 15 Constitution saving throw against disease or become poisoned until the disease is cured. Every 24 hours that elapse, the target must repeat the saving throw, reducing its hit point maximum by 5 (1d10) on a failure. The disease is cured on a success. The target dies if the disease reduces its hit point maximum to 0. This reduction to the target's hit point maximum lasts until the disease is cured.\n\n***Tentacle.*** *Melee Weapon Attack:* +6 to hit, reach 10 ft., one target. *Hit:* 7 (1d8 + 3) bludgeoning damage plus 4 (1d8) piercing damage. If the target is Medium or smaller, it is grappled (escape DC 13) and restrained until the grapple ends. The otyugh has two tentacles, each of which can grapple one target.\n\n***Tentacle Slam.*** The otyugh slams creatures grappled by it into each other or a solid surface. Each creature must succeed on a DC 14 Constitution saving throw or take 10 (2d6 + 3) bludgeoning damage and be stunned until the end of the otyugh's next turn. On a successful save, the target takes half the bludgeoning damage and isn't stunned.",
			"",
			"",
			"",
			""));
}
