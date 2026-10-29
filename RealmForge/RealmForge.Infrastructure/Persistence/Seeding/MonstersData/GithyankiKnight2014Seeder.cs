using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Githyanki Knight (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class GithyankiKnight2014Seeder
{
	public static Monster Build() => Create("githyanki-knight", null, ContentSource.RealmForge, CreatureSize.Medium, CreatureType.Humanoid,
		18, 91, "14d8 + 28", 30, new[] { 16, 14, 15, 14, 14, 15 }, 8m, 3900, 3, 12,
		new Text(
			"Githyanki cavaliere",
			null,
			"Umanoide Medio (gith), legale malvagio",
			"18 (armatura completa)",
			"9 m",
			"Cos +5, Int +5, Sag +5",
			"",
			"",
			"",
			"",
			"",
			"Percezione passiva 12",
			"Gith",
			"***Incantesimi innati (psionici).*** Il githyanki lancia per natura gli incantesimi seguenti usando l'Intelligenza (CD del tiro salvezza sull'incantesimo 13, +5 al tiro per colpire con attacco con incantesimo), senza bisogno di componenti:\n\n- A volontà: *mano magica* (la mano è invisibile)\n- 3/giorno ciascuno: *saltare*, *passo velato*, *anti-individuazione* (solo su se stesso), *linguaggi*\n- 1/giorno ciascuno: *spostamento planare*, *telecinesi*",
			"***Multiattacco.*** Il githyanki effettua due attacchi con lo spadone d'argento.\n\n***Spadone d'argento.*** *Attacco con arma da mischia:* +9 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 13 (2d6 + 6) danni taglienti più 10 (3d6) danni psichici. L'attacco è magico. Con un colpo critico contro un bersaglio che si trova in forma di corpo astrale (come con l'incantesimo *proiezione astrale*), il githyanki può recidere il cordone d'argento che lega il bersaglio al suo corpo fisico invece di infliggere danni.",
			"",
			"",
			"",
			""),
		new Text(
			"Githyanki Knight",
			null,
			"Medium humanoid (gith), lawful evil",
			"18 (plate)",
			"30 ft.",
			"Con +5, Int +5, Wis +5",
			"",
			"",
			"",
			"",
			"",
			"passive Perception 12",
			"Gith",
			"***Innate Spellcasting (Psionics).*** The githyanki casts the following spells innately, using Intelligence (spell save DC 13, +5 to hit with spell attacks) and needing no components:\n\n- At will: *mage hand* (the hand is invisible)\n- 3/day each: *jump*, *misty step*, *nondetection* (self only), *tongues*\n- 1/day each: *plane shift*, *telekinesis*",
			"***Multiattack.*** The githyanki makes two silver greatsword attacks.\n\n***Silver Greatsword.*** *Melee Weapon Attack:* +9 to hit, reach 5 ft., one target. *Hit:* 13 (2d6 + 6) slashing damage plus 10 (3d6) psychic damage. The attack is magical. On a critical hit against a target that is an astral body (as with the astral projection spell), the githyanki can sever the silvery cord binding the target to its physical body instead of dealing damage.",
			"",
			"",
			"",
			""));
}
