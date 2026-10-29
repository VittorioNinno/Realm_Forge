using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Roc (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Roc2014Seeder
{
	public static Monster Build() => Create("roc", null, ContentSource.Srd51, CreatureSize.Gargantuan, CreatureType.Monstrosity,
		15, 248, "16d20 + 80", 20, new[] { 28, 10, 20, 3, 10, 9 }, 11m, 7200, 4, 14,
		new Text(
			"Roc",
			null,
			"Mostruosità Mastodontica, senza allineamento",
			"15 (armatura naturale)",
			"6 m, volare 36 m",
			"Car +3, Cos +9, Des +4, Sag +4",
			"Percezione +4",
			"",
			"",
			"",
			"",
			"Percezione passiva 14",
			"—",
			"***Vista acuta.*** Il roc dispone di vantaggio alle prove di Saggezza (Percezione) basate sulla vista.",
			"***Multiattacco.*** Il roc effettua due attacchi: uno con il becco e uno con gli artigli.\n\n***Artigli.*** *Attacco con arma da mischia:* +13 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 23 (4d6 + 9) danni taglienti e il bersaglio è afferrato (CD 19 per sfuggire). Finché la presa perdura, il bersaglio è trattenuto e il roc non può usare i suoi artigli su altri.\n\n***Becco.*** *Attacco con arma da mischia:* +13 al tiro per colpire, portata 3 m, un bersaglio. *Colpito:* 27 (4d8 + 9) danni perforanti.",
			"",
			"",
			"",
			""),
		new Text(
			"Roc",
			null,
			"Gargantuan monstrosity, unaligned",
			"15 (natural armor)",
			"20 ft., fly 120 ft.",
			"Dex +4, Con +9, Wis +4, Cha +3",
			"Perception +4",
			"",
			"",
			"",
			"",
			"passive Perception 14",
			"—",
			"***Keen Sight.*** The roc has advantage on Wisdom (Perception) checks that rely on sight.",
			"***Multiattack.*** The roc makes two attacks: one with its beak and one with its talons.\n\n***Beak.*** *Melee Weapon Attack:* +13 to hit, reach 10 ft., one target. *Hit:* 27 (4d8 + 9) piercing damage.\n\n***Talons.*** *Melee Weapon Attack:* +13 to hit, reach 5 ft., one target. *Hit:* 23 (4d6 + 9) slashing damage, and the target is grappled (escape DC 19). Until this grapple ends, the target is restrained, and the roc can't use its talons on another target.",
			"",
			"",
			"",
			""));
}
