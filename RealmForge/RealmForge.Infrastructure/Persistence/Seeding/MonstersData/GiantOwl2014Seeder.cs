using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Giant Owl (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class GiantOwl2014Seeder
{
	public static Monster Build() => Create("giant-owl", null, ContentSource.Srd51, CreatureSize.Large, CreatureType.Beast,
		12, 19, "3d10 + 3", 5, new[] { 13, 15, 12, 8, 13, 10 }, 0.25m, 50, 2, 15,
		new Text(
			"Gufo gigante",
			null,
			"Bestia Grande, neutrale",
			"12",
			"1,5 m, volare 18 m",
			"",
			"Furtività +4, Percezione +5",
			"",
			"",
			"",
			"",
			"Percezione passiva 15, scurovisione 36 m",
			"Gufo gigante, capisce il Comune, l'Elfico e il Silvano ma non li parla",
			"***Sfuggente.*** Il gufo non provoca attacchi d'opportunità quando vola oltre la portata di un nemico.\n\n***Udito e vista acuti.*** Il gufo dispone di vantaggio alle prove di Saggezza (Percezione) basate sulla vista o sull'udito.",
			"***Artigli.*** *Attacco con arma da mischia:* +3 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 8 (2d6 + 1) danni taglienti.",
			"",
			"",
			"",
			""),
		new Text(
			"Giant Owl",
			null,
			"Large beast, neutral",
			"12",
			"5 ft., fly 60 ft.",
			"",
			"Perception +5, Stealth +4",
			"",
			"",
			"",
			"",
			"darkvision 120 ft., passive Perception 15",
			"Giant Owl, understands Common, Elvish, and Sylvan but can't speak",
			"***Flyby.*** The owl doesn't provoke opportunity attacks when it flies out of an enemy's reach.\n\n***Keen Hearing and Sight.*** The owl has advantage on Wisdom (Perception) checks that rely on hearing or sight.",
			"***Talons.*** *Melee Weapon Attack:* +3 to hit, reach 5 ft., one target. *Hit:* 8 (2d6 + 1) slashing damage.",
			"",
			"",
			"",
			""));
}
