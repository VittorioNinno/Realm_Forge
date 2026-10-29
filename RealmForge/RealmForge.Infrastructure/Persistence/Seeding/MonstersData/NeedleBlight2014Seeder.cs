using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Needle Blight (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class NeedleBlight2014Seeder
{
	public static Monster Build() => Create("needle-blight", null, ContentSource.RealmForge, CreatureSize.Medium, CreatureType.Plant,
		12, 11, "2d8 + 2", 30, new[] { 12, 12, 13, 4, 8, 3 }, 0.25m, 50, 2, 9,
		new Text(
			"Ago maligno",
			null,
			"Vegetale Medio, neutrale malvagio",
			"12 (armatura naturale)",
			"9 m",
			"",
			"",
			"",
			"",
			"",
			"accecato, assordato",
			"Percezione passiva 9, vista cieca 18 m (cieco oltre questo raggio)",
			"capisce il Comune ma non lo parla",
			"",
			"***Artigli.*** *Attacco con arma da mischia:* +3 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 6 (2d4 + 1) danni perforanti.\n\n***Aghi.*** *Attacco con arma a distanza:* +3 al tiro per colpire, gittata 9/18 m, un bersaglio. *Colpito:* 8 (2d6 + 1) danni perforanti.",
			"",
			"",
			"",
			""),
		new Text(
			"Needle Blight",
			null,
			"Medium plant, neutral evil",
			"12 (natural armor)",
			"30 ft.",
			"",
			"",
			"",
			"",
			"",
			"blinded, deafened",
			"blindsight 60 ft. (blind beyond this radius), passive Perception 9",
			"understands Common but can't speak",
			"",
			"***Claws.*** *Melee Weapon Attack:* +3 to hit, reach 5 ft., one target. *Hit:* 6 (2d4 + 1) piercing damage.\n\n***Needles.*** *Ranged Weapon Attack:* +3 to hit, range 30/60 ft., one target. *Hit:* 8 (2d6 + 1) piercing damage.",
			"",
			"",
			"",
			""));
}
