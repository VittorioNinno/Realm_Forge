using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Twig Blight (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class TwigBlight2014Seeder
{
	public static Monster Build() => Create("twig-blight", null, ContentSource.RealmForge, CreatureSize.Small, CreatureType.Plant,
		13, 4, "1d6 + 1", 20, new[] { 6, 13, 12, 4, 8, 3 }, 0.125m, 25, 2, 9,
		new Text(
			"Arbusto maligno",
			null,
			"Vegetale Piccolo, neutrale malvagio",
			"13 (armatura naturale)",
			"6 m",
			"",
			"Furtività +3",
			"fuoco",
			"",
			"",
			"accecato, assordato",
			"Percezione passiva 9, vista cieca 18 m (cieco oltre questo raggio)",
			"capisce il Comune ma non lo parla",
			"***Falso aspetto.*** Finché resta immobile, il maligno ha esattamente l'aspetto di un arbusto secco.",
			"***Artigli.*** *Attacco con arma da mischia:* +3 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 3 (1d4 + 1) danni perforanti.",
			"",
			"",
			"",
			""),
		new Text(
			"Twig Blight",
			null,
			"Small plant, neutral evil",
			"13 (natural armor)",
			"20 ft.",
			"",
			"Stealth +3",
			"fire",
			"",
			"",
			"blinded, deafened",
			"blindsight 60 ft. (blind beyond this radius), passive Perception 9",
			"understands Common but can't speak",
			"***False Appearance.*** As long as it stays still, the blight looks exactly like a dead shrub.",
			"***Claws.*** *Melee Weapon Attack:* +3 to hit, reach 5 ft., one target. *Hit:* 3 (1d4 + 1) piercing damage.",
			"",
			"",
			"",
			""));
}
