using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Slaad Tadpole (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class SlaadTadpole2014Seeder
{
	public static Monster Build() => Create("slaad-tadpole", null, ContentSource.RealmForge, CreatureSize.Tiny, CreatureType.Aberration,
		12, 10, "4d4", 30, new[] { 7, 15, 10, 3, 5, 3 }, 0.125m, 25, 2, 7,
		new Text(
			"Slaad girino",
			null,
			"Aberrazione Minuscola, caotico neutrale",
			"12",
			"9 m",
			"",
			"Furtività +4",
			"",
			"acido, freddo, fuoco, fulmine, tuono",
			"",
			"",
			"Percezione passiva 7, scurovisione 18 m",
			"capisce lo Slaad ma non lo parla",
			"***Resistenza alla magia.*** Lo slaad dispone di vantaggio ai tiri salvezza contro incantesimi e altri effetti magici.",
			"***Morso.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 4 (1d4 + 2) danni perforanti.",
			"",
			"",
			"",
			""),
		new Text(
			"Slaad Tadpole",
			null,
			"Tiny aberration, chaotic neutral",
			"12",
			"30 ft.",
			"",
			"Stealth +4",
			"",
			"acid, cold, fire, lightning, thunder",
			"",
			"",
			"darkvision 60 ft., passive Perception 7",
			"understands Slaad but can't speak",
			"***Magic Resistance.*** The slaad has advantage on saving throws against spells and other magical effects.",
			"***Bite.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one target. *Hit:* 4 (1d4 + 2) piercing damage.",
			"",
			"",
			"",
			""));
}
