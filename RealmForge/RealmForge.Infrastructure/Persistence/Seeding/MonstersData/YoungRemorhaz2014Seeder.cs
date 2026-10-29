using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Young Remorhaz (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class YoungRemorhaz2014Seeder
{
	public static Monster Build() => Create("young-remorhaz", null, ContentSource.RealmForge, CreatureSize.Large, CreatureType.Monstrosity,
		14, 93, "11d10 + 33", 30, new[] { 18, 13, 17, 3, 10, 4 }, 5m, 1800, 3, 10,
		new Text(
			"Remorhaz giovane",
			null,
			"Mostruosità Grande, senza allineamento",
			"14 (armatura naturale)",
			"9 m, scavare 6 m",
			"",
			"",
			"",
			"",
			"freddo, fuoco",
			"",
			"Percezione passiva 10, percezione tellurica 18 m, scurovisione 18 m",
			"—",
			"***Corpo rovente.*** Una creatura che tocca il remorhaz, o che lo colpisce con un attacco in mischia trovandosi entro 1,5 metri da lui, subisce 7 (2d6) danni da fuoco.",
			"***Morso.*** *Attacco con arma da mischia:* +6 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 20 (3d10 + 4) danni perforanti più 7 (2d6) danni da fuoco.",
			"",
			"",
			"",
			""),
		new Text(
			"Young Remorhaz",
			null,
			"Large monstrosity, unaligned",
			"14 (natural armor)",
			"30 ft., burrow 20 ft.",
			"",
			"",
			"",
			"",
			"cold, fire",
			"",
			"darkvision 60 ft., tremorsense 60 ft., passive Perception 10",
			"—",
			"***Heated Body.*** A creature that touches the remorhaz, or hits it with a melee attack while within 5 feet of it, takes 7 (2d6) fire damage.",
			"***Bite.*** *Melee Weapon Attack:* +6 to hit, reach 5 ft., one target. *Hit:* 20 (3d10 + 4) piercing damage plus 7 (2d6) fire damage.",
			"",
			"",
			"",
			""));
}
