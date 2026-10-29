using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Giant Crocodile (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class GiantCrocodile2014Seeder
{
	public static Monster Build() => Create("giant-crocodile", null, CreatureSize.Huge, CreatureType.Beast,
		14, 85, "9d12 + 27", 30, new[] { 21, 9, 17, 2, 10, 7 }, 5m, 1800, 3, 10,
		new Text(
			"Coccodrillo gigante",
			null,
			"Bestia Enorme, senza allineamento",
			"14 (armatura naturale)",
			"9 m, nuotare 15 m",
			"",
			"Furtività +5",
			"",
			"",
			"",
			"",
			"Percezione passiva 10",
			"—",
			"***Apnea.*** Il coccodrillo può trattenere il respiro per 30 minuti.",
			"***Multiattacco.*** Il coccodrillo effettua due attacchi: uno con il morso e uno con la coda.\n\n***Coda.*** *Attacco con arma da mischia:* +8 al tiro per colpire, portata 3 m, un bersaglio non afferrato dal coccodrillo. *Colpito:* 14 (2d8 + 5) danni contundenti. Se il bersaglio è una creatura, deve superare un tiro salvezza su Forza con CD 16, altrimenti cade a terra prono.\n\n***Morso.*** *Attacco con arma da mischia:* +8 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 21 (3d10 + 5) danni perforanti e il bersaglio è afferrato (CD 16 per sfuggire). Finché la presa perdura, il bersaglio viene trattenuto e il coccodrillo non può morderne un altro.",
			"",
			""),
		new Text(
			"Giant Crocodile",
			null,
			"Huge beast, unaligned",
			"14 (natural armor)",
			"30 ft., swim 50 ft.",
			"",
			"Stealth +5",
			"",
			"",
			"",
			"",
			"passive Perception 10",
			"—",
			"***Hold Breath.*** The crocodile can hold its breath for 30 minutes.",
			"***Multiattack.*** The crocodile makes two attacks: one with its bite and one with its tail.\n\n***Bite.*** *Melee Weapon Attack:* +8 to hit, reach 5 ft., one target. *Hit:* 21 (3d10 + 5) piercing damage, and the target is grappled (escape DC 16). Until this grapple ends, the target is restrained, and the crocodile can't bite another target.\n\n***Tail.*** *Melee Weapon Attack:* +8 to hit, reach 10 ft., one target not grappled by the crocodile. *Hit:* 14 (2d8 + 5) bludgeoning damage. If the target is a creature, it must succeed on a DC 16 Strength saving throw or be knocked prone.",
			"",
			""));
}
