using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Kenku (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class Kenku2014Seeder
{
	public static Monster Build() => Create("kenku", null, ContentSource.RealmForge, CreatureSize.Medium, CreatureType.Humanoid,
		13, 13, "3d8", 30, new[] { 10, 16, 10, 11, 10, 10 }, 0.25m, 50, 2, 12,
		new Text(
			"Kenku",
			null,
			"Umanoide Medio (kenku), caotico neutrale",
			"13",
			"9 m",
			"",
			"Furtività +5, Inganno +4, Percezione +2",
			"",
			"",
			"",
			"",
			"Percezione passiva 12",
			"capisce l'Auran e il Comune ma parla solo tramite il tratto Imitazione",
			"***Agguato.*** Il kenku dispone di vantaggio ai tiri per colpire contro qualsiasi creatura che abbia sorpreso.\n\n***Imitazione.*** Il kenku può riprodurre qualsiasi suono abbia sentito, voci comprese. Una creatura che sente i suoni capisce che sono imitazioni superando una prova di Saggezza (Intuizione) con CD 14.",
			"***Spada corta.*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 6 (1d6 + 3) danni perforanti.\n\n***Arco corto.*** *Attacco con arma a distanza:* +5 al tiro per colpire, gittata 24/96 m, un bersaglio. *Colpito:* 6 (1d6 + 3) danni perforanti.",
			"",
			"",
			"",
			""),
		new Text(
			"Kenku",
			null,
			"Medium humanoid (kenku), chaotic neutral",
			"13",
			"30 ft.",
			"",
			"Deception +4, Perception +2, Stealth +5",
			"",
			"",
			"",
			"",
			"passive Perception 12",
			"understands Auran and Common but speaks only through its Mimicry trait",
			"***Ambusher.*** The kenku has advantage on attack rolls against any creature it has surprised.\n\n***Mimicry.*** The kenku can reproduce any sound it has heard, voices included. A creature that hears the sounds realizes they are imitations with a DC 14 Wisdom (Insight) check.",
			"***Shortsword.*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one target. *Hit:* 6 (1d6 + 3) piercing damage.\n\n***Shortbow.*** *Ranged Weapon Attack:* +5 to hit, range 80/320 ft., one target. *Hit:* 6 (1d6 + 3) piercing damage.",
			"",
			"",
			"",
			""));
}
