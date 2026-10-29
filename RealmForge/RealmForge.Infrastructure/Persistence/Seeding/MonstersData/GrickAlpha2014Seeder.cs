using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Grick Alpha (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class GrickAlpha2014Seeder
{
	public static Monster Build() => Create("grick-alpha", null, ContentSource.RealmForge, CreatureSize.Large, CreatureType.Monstrosity,
		18, 75, "10d10 + 20", 30, new[] { 18, 16, 15, 4, 14, 9 }, 7m, 2900, 3, 12,
		new Text(
			"Grick alfa",
			null,
			"Mostruosità Grande, neutrale",
			"18 (armatura naturale)",
			"9 m, scalare 9 m",
			"",
			"",
			"",
			"contundenti, perforanti e taglienti da attacchi non magici",
			"",
			"",
			"Percezione passiva 12, scurovisione 18 m",
			"—",
			"***Mimetismo nella roccia.*** Il grick dispone di vantaggio alle prove di Destrezza (Furtività) per nascondersi in un terreno roccioso.",
			"***Multiattacco.*** Il grick effettua due attacchi: uno con la coda e uno con i tentacoli. Se i tentacoli colpiscono, può anche effettuare un attacco con il becco contro lo stesso bersaglio.\n\n***Coda.*** *Attacco con arma da mischia:* +7 al tiro per colpire, portata 3 m, un bersaglio. *Colpito:* 11 (2d6 + 4) danni contundenti.\n\n***Tentacoli.*** *Attacco con arma da mischia:* +7 al tiro per colpire, portata 3 m, un bersaglio. *Colpito:* 22 (4d8 + 4) danni taglienti.\n\n***Becco.*** *Attacco con arma da mischia:* +7 al tiro per colpire, portata 3 m, un bersaglio. *Colpito:* 13 (2d8 + 4) danni perforanti.",
			"",
			"",
			"",
			""),
		new Text(
			"Grick Alpha",
			null,
			"Large monstrosity, neutral",
			"18 (natural armor)",
			"30 ft., climb 30 ft.",
			"",
			"",
			"",
			"bludgeoning, piercing, and slashing from nonmagical attacks",
			"",
			"",
			"darkvision 60 ft., passive Perception 12",
			"—",
			"***Stone Camouflage.*** The grick has advantage on Dexterity (Stealth) checks to hide in rocky terrain.",
			"***Multiattack.*** The grick makes two attacks: one with its tail and one with its tentacles. If the tentacles hit, it can also make a beak attack against the same target.\n\n***Tail.*** *Melee Weapon Attack:* +7 to hit, reach 10 ft., one target. *Hit:* 11 (2d6 + 4) bludgeoning damage.\n\n***Tentacles.*** *Melee Weapon Attack:* +7 to hit, reach 10 ft., one target. *Hit:* 22 (4d8 + 4) slashing damage.\n\n***Beak.*** *Melee Weapon Attack:* +7 to hit, reach 10 ft., one target. *Hit:* 13 (2d8 + 4) piercing damage.",
			"",
			"",
			"",
			""));
}
