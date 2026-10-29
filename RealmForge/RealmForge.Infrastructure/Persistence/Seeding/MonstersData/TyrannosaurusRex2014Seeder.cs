using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Tyrannosaurus Rex (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class TyrannosaurusRex2014Seeder
{
	public static Monster Build() => Create("tyrannosaurus-rex", null, CreatureSize.Huge, CreatureType.Beast,
		13, 136, "13d12 + 52", 50, new[] { 25, 10, 19, 2, 12, 9 }, 8m, 3900, 3, 14,
		new Text(
			"Tirannosauro",
			null,
			"Bestia Enorme, senza allineamento",
			"13 (armatura naturale)",
			"15 m",
			"",
			"Percezione +4",
			"",
			"",
			"",
			"",
			"Percezione passiva 14",
			"—",
			"",
			"***Multiattacco.*** Il tirannosauro effettua due attacchi: uno con il morso e uno con la coda. Non può effettuare entrambi gli attacchi contro lo stesso bersaglio.\n\n***Coda.*** *Attacco con arma da mischia:* +10 al tiro per colpire, portata 3 m, un bersaglio. *Colpito:* 20 (3d8 + 7) danni contundenti.\n\n***Morso.*** *Attacco con arma da mischia:* +10 al tiro per colpire, portata 3 m, un bersaglio. *Colpito:* 33 (4d12 + 7) danni perforanti. Se il bersaglio è una creatura di taglia Media o inferiore, viene afferrato (CD 17 per sfuggire). Finché la presa perdura, il bersaglio è trattenuto e il tirannosauro non può morderne un altro.",
			"",
			""),
		new Text(
			"Tyrannosaurus Rex",
			null,
			"Huge beast, unaligned",
			"13 (natural armor)",
			"50 ft.",
			"",
			"Perception +4",
			"",
			"",
			"",
			"",
			"passive Perception 14",
			"—",
			"",
			"***Multiattack.*** The tyrannosaurus makes two attacks: one with its bite and one with its tail. It can't make both attacks against the same target.\n\n***Bite.*** *Melee Weapon Attack:* +10 to hit, reach 10 ft., one target. *Hit:* 33 (4d12 + 7) piercing damage. If the target is a Medium or smaller creature, it is grappled (escape DC 17). Until this grapple ends, the target is restrained, and the tyrannosaurus can't bite another target.\n\n***Tail.*** *Melee Weapon Attack:* +10 to hit, reach 10 ft., one target. *Hit:* 20 (3d8 + 7) bludgeoning damage.",
			"",
			""));
}
