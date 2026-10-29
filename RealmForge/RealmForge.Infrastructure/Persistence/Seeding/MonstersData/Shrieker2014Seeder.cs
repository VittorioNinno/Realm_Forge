using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Shrieker (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Shrieker2014Seeder
{
	public static Monster Build() => Create("shrieker", null, CreatureSize.Medium, CreatureType.Plant,
		5, 13, "3d8", 0, new[] { 1, 1, 10, 1, 3, 1 }, 0m, 10, 2, 6,
		new Text(
			"Boleto stridente",
			null,
			"Vegetale Medio, senza allineamento",
			"5",
			"0 m",
			"",
			"",
			"",
			"",
			"",
			"accecato, assordato, spaventato",
			"Percezione passiva 6, vista cieca 9 metri (cecità oltre questo raggio)",
			"—",
			"***Falso aspetto.*** Finché il boleto stridente rimane immobile, non è possibile distinguerlo da un normale fungo.",
			"",
			"***Stridio.*** Quando una luce intensa o una creatura si trova entro 9 metri dal boleto stridente, esso emette uno stridio udibile nel raggio di 90 metri. Il boleto stridente continua a stridere finché la fonte del disturbo non si sposta fuori portata e per 1d4 turni successivi del boleto stridente.",
			""),
		new Text(
			"Shrieker",
			null,
			"Medium plant, unaligned",
			"5",
			"0 ft.",
			"",
			"",
			"",
			"",
			"",
			"blinded, blinded, frightened",
			"blindsight 30 ft. (blind beyond this radius), passive Perception 6",
			"—",
			"***False Appearance.*** While the shrieker remains motionless, it is indistinguishable from an ordinary fungus.",
			"",
			"***Shriek.*** When bright light or a creature is within 30 feet of the shrieker, it emits a shriek audible within 300 feet of it. The shrieker continues to shriek until the disturbance moves out of range and for 1d4 of the shrieker's turns afterward",
			""));
}
