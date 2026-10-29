using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Violet Fungus (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class VioletFungus2014Seeder
{
	public static Monster Build() => Create("violet-fungus", null, ContentSource.Srd51, CreatureSize.Medium, CreatureType.Plant,
		5, 18, "4d8", 5, new[] { 3, 1, 10, 1, 3, 1 }, 0.25m, 50, 2, 6,
		new Text(
			"Fungo viola",
			null,
			"Vegetale Medio, senza allineamento",
			"5",
			"1,5 m",
			"",
			"",
			"",
			"",
			"",
			"accecato, assordato, spaventato",
			"Percezione passiva 6, vista cieca 9 metri (cecità oltre questo raggio)",
			"—",
			"***Falso aspetto.*** Finché il fungo viola rimane immobile, non è possibile distinguerlo da un normale fungo.",
			"***Multiattacco.*** Il fungo effettua 1d4 attacchi Tocco marcescente.\n\n***Tocco marcescente.*** *Attacco con arma da mischia:* +2 al tiro per colpire, portata 3 m, una creatura. *Colpito:* 4 (1d8) danni necrotici.",
			"",
			"",
			"",
			""),
		new Text(
			"Violet Fungus",
			null,
			"Medium plant, unaligned",
			"5",
			"5 ft.",
			"",
			"",
			"",
			"",
			"",
			"blinded, blinded, frightened",
			"blindsight 30 ft. (blind beyond this radius), passive Perception 6",
			"—",
			"***False Appearance.*** While the violet fungus remains motionless, it is indistinguishable from an ordinary fungus.",
			"***Multiattack.*** The fungus makes 1d4 Rotting Touch attacks.\n\n***Rotting Touch.*** *Melee Weapon Attack:* +2 to hit, reach 10 ft., one creature. *Hit:* 4 (1d8) necrotic damage.",
			"",
			"",
			"",
			""));
}
