using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Raven (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Raven2014Seeder
{
	public static Monster Build() => Create("raven", null, ContentSource.Srd51, CreatureSize.Tiny, CreatureType.Beast,
		12, 1, "1d4 - 1", 10, new[] { 2, 14, 8, 2, 12, 6 }, 0m, 10, 2, 13,
		new Text(
			"Corvo",
			null,
			"Bestia Minuscola, senza allineamento",
			"12",
			"3 m, volare 15 m",
			"",
			"Percezione +3",
			"",
			"",
			"",
			"",
			"Percezione passiva 13",
			"—",
			"***Imitare.*** Il corvo può imitare i suoni semplici che sente, come il sussurro di una persona, il pianto di un bambino o il verso di un animale. Una creatura che oda tali suoni riesce a capire che si tratta di imitazioni superando una prova di Saggezza (Intuizione) con CD 10.",
			"***Becco.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 1 danno perforante.",
			"",
			"",
			"",
			""),
		new Text(
			"Raven",
			null,
			"Tiny beast, unaligned",
			"12",
			"10 ft., fly 50 ft.",
			"",
			"Perception +3",
			"",
			"",
			"",
			"",
			"passive Perception 13",
			"—",
			"***Mimicry.*** The raven can mimic simple sounds it has heard, such as a person whispering, a baby crying, or an animal chittering. A creature that hears the sounds can tell they are imitations with a successful DC 10 Wisdom (Insight) check.",
			"***Beak.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one target. *Hit:* 1 piercing damage.",
			"",
			"",
			"",
			""));
}
