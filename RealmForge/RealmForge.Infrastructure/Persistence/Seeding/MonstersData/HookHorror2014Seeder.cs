using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Hook Horror (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class HookHorror2014Seeder
{
	public static Monster Build() => Create("hook-horror", null, ContentSource.RealmForge, CreatureSize.Large, CreatureType.Monstrosity,
		15, 75, "10d10 + 20", 30, new[] { 18, 10, 15, 6, 12, 7 }, 3m, 700, 2, 13,
		new Text(
			"Orrore uncinato",
			null,
			"Mostruosità Grande, neutrale",
			"15 (armatura naturale)",
			"9 m, scalare 9 m",
			"",
			"Percezione +3",
			"",
			"",
			"",
			"",
			"Percezione passiva 13, scurovisione 3 m, vista cieca 18 m",
			"Orrore uncinato",
			"***Ecolocazione.*** L'orrore uncinato non può usare la vista cieca mentre è assordato.\n\n***Udito acuto.*** L'orrore uncinato dispone di vantaggio alle prove di Saggezza (Percezione) basate sull'udito.",
			"***Multiattacco.*** L'orrore uncinato effettua due attacchi con gli uncini.\n\n***Uncino.*** *Attacco con arma da mischia:* +6 al tiro per colpire, portata 3 m, un bersaglio. *Colpito:* 11 (2d6 + 4) danni perforanti.",
			"",
			"",
			"",
			""),
		new Text(
			"Hook Horror",
			null,
			"Large monstrosity, neutral",
			"15 (natural armor)",
			"30 ft., climb 30 ft.",
			"",
			"Perception +3",
			"",
			"",
			"",
			"",
			"blindsight 60 ft., darkvision 10 ft., passive Perception 13",
			"Hook Horror",
			"***Echolocation.*** The hook horror can't use its blindsight while deafened.\n\n***Keen Hearing.*** The hook horror has advantage on Wisdom (Perception) checks that rely on hearing.",
			"***Multiattack.*** The hook horror makes two hook attacks.\n\n***Hook.*** *Melee Weapon Attack:* +6 to hit, reach 10 ft., one target. *Hit:* 11 (2d6 + 4) piercing damage.",
			"",
			"",
			"",
			""));
}
