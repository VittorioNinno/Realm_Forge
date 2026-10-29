using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Githyanki Warrior (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class GithyankiWarrior2014Seeder
{
	public static Monster Build() => Create("githyanki-warrior", null, ContentSource.RealmForge, CreatureSize.Medium, CreatureType.Humanoid,
		17, 49, "9d8 + 9", 30, new[] { 15, 14, 12, 13, 13, 10 }, 3m, 700, 2, 11,
		new Text(
			"Githyanki combattente",
			null,
			"Umanoide Medio (gith), legale malvagio",
			"17 (mezza armatura)",
			"9 m",
			"Cos +3, Int +3, Sag +3",
			"",
			"",
			"",
			"",
			"",
			"Percezione passiva 11",
			"Gith",
			"***Incantesimi innati (psionici).*** Il githyanki lancia per natura gli incantesimi seguenti usando l'Intelligenza, senza bisogno di componenti:\n\n- A volontà: *mano magica* (la mano è invisibile)\n- 3/giorno ciascuno: *saltare*, *passo velato*, *anti-individuazione* (solo su se stesso)",
			"***Multiattacco.*** Il githyanki effettua due attacchi con lo spadone.\n\n***Spadone.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 9 (2d6 + 2) danni taglienti più 7 (2d6) danni psichici.",
			"",
			"",
			"",
			""),
		new Text(
			"Githyanki Warrior",
			null,
			"Medium humanoid (gith), lawful evil",
			"17 (half plate)",
			"30 ft.",
			"Con +3, Int +3, Wis +3",
			"",
			"",
			"",
			"",
			"",
			"passive Perception 11",
			"Gith",
			"***Innate Spellcasting (Psionics).*** The githyanki casts the following spells innately, using Intelligence and needing no components:\n\n- At will: *mage hand* (the hand is invisible)\n- 3/day each: *jump*, *misty step*, *nondetection* (self only)",
			"***Multiattack.*** The githyanki makes two greatsword attacks.\n\n***Greatsword.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one target. *Hit:* 9 (2d6 + 2) slashing damage plus 7 (2d6) psychic damage.",
			"",
			"",
			"",
			""));
}
