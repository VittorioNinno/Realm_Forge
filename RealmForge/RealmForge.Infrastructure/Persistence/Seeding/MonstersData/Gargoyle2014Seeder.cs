using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Gargoyle (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Gargoyle2014Seeder
{
	public static Monster Build() => Create("gargoyle", null, ContentSource.Srd51, CreatureSize.Medium, CreatureType.Elemental,
		15, 52, "7d8 + 21", 30, new[] { 15, 11, 16, 6, 11, 7 }, 2m, 450, 2, 10,
		new Text(
			"Gargoyle",
			null,
			"Elementale Medio, caotico malvagio",
			"15 (armatura naturale)",
			"9 m, volare 18 m",
			"",
			"",
			"",
			"contundenti, perforanti e taglienti da attacchi non magici non adamantini",
			"veleno",
			"avvelenato, indebolimento, pietrificato",
			"Percezione passiva 10, scurovisione 18 m",
			"Terran",
			"***Falso aspetto.*** Finché il gargoyle rimane immobile, non è possibile distinguerlo da una statua inanimata.",
			"***Multiattacco.*** Il gargoyle effettua due attacchi: uno con il morso e uno con gli artigli.\n\n***Artigli.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 5 (1d6 + 2) danni taglienti.\n\n***Morso.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 5 (1d6 + 2) danni perforanti.",
			"",
			"",
			"",
			""),
		new Text(
			"Gargoyle",
			null,
			"Medium elemental, chaotic evil",
			"15 (natural armor)",
			"30 ft., fly 60 ft.",
			"",
			"",
			"",
			"bludgeoning, piercing, and slashing from nonmagical weapons that aren't adamantine",
			"poison",
			"exhaustion, petrified, poisoned",
			"darkvision 60 ft., passive Perception 10",
			"Terran",
			"***False Appearance.*** While the gargoyle remains motion less, it is indistinguishable from an inanimate statue.",
			"***Multiattack.*** The gargoyle makes two attacks: one with its bite and one with its claws.\n\n***Bite.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one target. *Hit:* 5 (1d6 + 2) piercing damage.\n\n***Claws.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one target. *Hit:* 5 (1d6 + 2) slashing damage.",
			"",
			"",
			"",
			""));
}
