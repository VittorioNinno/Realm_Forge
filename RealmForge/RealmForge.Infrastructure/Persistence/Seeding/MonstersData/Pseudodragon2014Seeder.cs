using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Pseudodragon (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Pseudodragon2014Seeder
{
	public static Monster Build() => Create("pseudodragon", null, ContentSource.Srd51, CreatureSize.Tiny, CreatureType.Dragon,
		13, 7, "2d4 + 2", 15, new[] { 6, 15, 13, 10, 12, 10 }, 0.25m, 50, 2, 13,
		new Text(
			"Pseudodrago",
			null,
			"Drago Minuscolo, neutrale buono",
			"13 (armatura naturale)",
			"4,5 m, volare 18 m",
			"",
			"Furtività +4, Percezione +3",
			"",
			"",
			"",
			"",
			"Percezione passiva 13, scurovisione 18 m, vista cieca 3 m",
			"capisce Comune e Draconico, ma non è in grado di parlarli",
			"***Resistenza alla magia.*** Lo pseudodrago dispone di vantaggio ai tiri salvezza contro incantesimi e altri effetti magici.\n\n***Sensi acuti.*** Lo pseudodrago dispone di vantaggio alle prove di Saggezza (Percezione) basate sulla vista, sull'udito o sull'olfatto.\n\n***Telepatia limitata.*** Lo pseudodrago può trasmettere magicamente idee, emozioni e immagini semplici a qualsiasi creatura situata entro 30 metri da lui e che sia in grado di comprendere un linguaggio.",
			"***Morso.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 4 (1d4 + 2) danni perforanti.\n\n***Pungiglione.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, una creatura. *Colpito:* 4 (1d4 + 2) danni perforanti e il bersaglio deve superare un tiro salvezza su Costituzione con CD 11, altrimenti è avvelenato per 1 ora. Se fallisce il tiro salvezza di 5 o più, il bersaglio perde conoscenza per la stessa durata, o finché non subisce danni o un'altra creatura non usa un'azione per risvegliarlo scuotendolo.",
			"",
			"",
			"",
			""),
		new Text(
			"Pseudodragon",
			null,
			"Tiny dragon, neutral good",
			"13 (natural armor)",
			"15 ft., fly 60 ft.",
			"",
			"Perception +3, Stealth +4",
			"",
			"",
			"",
			"",
			"blindsight 10 ft., darkvision 60 ft., passive Perception 13",
			"understands Common and Draconic but can't speak",
			"***Keen Senses.*** The pseudodragon has advantage on Wisdom (Perception) checks that rely on sight, hearing, or smell.\n\n***Magic Resistance.*** The pseudodragon has advantage on saving throws against spells and other magical effects.\n\n***Limited Telepathy.*** The pseudodragon can magically communicate simple ideas, emotions, and images telepathically with any creature within 100 ft. of it that can understand a language.",
			"***Bite.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one target. *Hit:* 4 (1d4 + 2) piercing damage.\n\n***Sting.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one creature. *Hit:* 4 (1d4 + 2) piercing damage, and the target must succeed on a DC 11 Constitution saving throw or become poisoned for 1 hour. If the saving throw fails by 5 or more, the target falls unconscious for the same duration, or until it takes damage or another creature uses an action to shake it awake.",
			"",
			"",
			"",
			""));
}
