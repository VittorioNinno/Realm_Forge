using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Carrion Crawler (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class CarrionCrawler2014Seeder
{
	public static Monster Build() => Create("carrion-crawler", null, ContentSource.RealmForge, CreatureSize.Large, CreatureType.Monstrosity,
		13, 51, "6d10 + 18", 30, new[] { 14, 13, 16, 1, 12, 5 }, 2m, 450, 2, 13,
		new Text(
			"Vermeiena",
			null,
			"Mostruosità Grande, senza allineamento",
			"13 (armatura naturale)",
			"9 m, scalare 9 m",
			"",
			"Percezione +3",
			"",
			"",
			"",
			"",
			"Percezione passiva 13, scurovisione 18 m",
			"—",
			"***Olfatto acuto.*** La vermeiena dispone di vantaggio alle prove di Saggezza (Percezione) basate sull'olfatto.\n\n***Movimenti del ragno.*** La vermeiena può scalare superfici difficili, soffitti compresi (a testa in giù), senza effettuare prove di caratteristica.",
			"***Multiattacco.*** La vermeiena effettua due attacchi: uno con i tentacoli e uno con il morso.\n\n***Tentacoli.*** *Attacco con arma da mischia:* +8 al tiro per colpire, portata 3 m, una creatura. *Colpito:* 4 (1d4 + 2) danni da veleno. Il bersaglio effettua un tiro salvezza su Costituzione con CD 13, altrimenti è avvelenato per 1 minuto e resta paralizzato finché dura il veleno. Ripete il tiro salvezza alla fine di ogni suo turno e il veleno termina con un successo.\n\n***Morso.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 7 (2d4 + 2) danni perforanti.",
			"",
			"",
			"",
			""),
		new Text(
			"Carrion Crawler",
			null,
			"Large monstrosity, unaligned",
			"13 (natural armor)",
			"30 ft., climb 30 ft.",
			"",
			"Perception +3",
			"",
			"",
			"",
			"",
			"darkvision 60 ft., passive Perception 13",
			"—",
			"***Keen Smell.*** The carrion crawler has advantage on Wisdom (Perception) checks that rely on smell.\n\n***Spider Climb.*** The carrion crawler can climb difficult surfaces, ceilings included (upside down), without making an ability check.",
			"***Multiattack.*** The carrion crawler makes two attacks: one with its tentacles and one with its bite.\n\n***Tentacles.*** *Melee Weapon Attack:* +8 to hit, reach 10 ft., one creature. *Hit:* 4 (1d4 + 2) poison damage. The target makes a DC 13 Constitution saving throw or is poisoned for 1 minute, and paralyzed for as long as the poison lasts. It repeats the save at the end of each of its turns, ending the poison on a success.\n\n***Bite.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one target. *Hit:* 7 (2d4 + 2) piercing damage.",
			"",
			"",
			"",
			""));
}
