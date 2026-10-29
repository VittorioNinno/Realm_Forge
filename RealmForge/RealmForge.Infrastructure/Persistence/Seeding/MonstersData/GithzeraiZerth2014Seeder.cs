using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Githzerai Zerth (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class GithzeraiZerth2014Seeder
{
	public static Monster Build() => Create("githzerai-zerth", null, ContentSource.RealmForge, CreatureSize.Medium, CreatureType.Humanoid,
		17, 84, "13d8 + 26", 30, new[] { 13, 18, 15, 16, 17, 12 }, 6m, 2300, 3, 16,
		new Text(
			"Githzerai zerth",
			null,
			"Umanoide Medio (gith), legale neutrale",
			"17",
			"9 m",
			"Des +7, For +4, Int +6, Sag +6",
			"Arcano +6, Intuizione +6, Percezione +6",
			"",
			"",
			"",
			"",
			"Percezione passiva 16",
			"Gith",
			"***Incantesimi innati (psionici).*** Il githzerai lancia per natura gli incantesimi seguenti usando la Saggezza (CD del tiro salvezza sull'incantesimo 14, +6 al tiro per colpire con attacco con incantesimo), senza bisogno di componenti:\n\n- A volontà: *mano magica* (la mano è invisibile)\n- 3/giorno ciascuno: *caduta morbida*, *saltare*, *vedere invisibilità*, *scudo*\n- 1/giorno ciascuno: *allucinazione mortale*, *spostamento planare*\n\n***Difesa psichica.*** Finché non indossa armature e non impugna scudi, il githzerai somma il suo modificatore di Saggezza alla CA (già incluso).",
			"***Multiattacco.*** Il githzerai effettua due colpi senz'armi.\n\n***Colpo senz'armi.*** *Attacco con arma da mischia:* +7 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 11 (2d6 + 4) danni contundenti più 13 (3d8) danni psichici. L'attacco è magico.",
			"",
			"",
			"",
			""),
		new Text(
			"Githzerai Zerth",
			null,
			"Medium humanoid (gith), lawful neutral",
			"17",
			"30 ft.",
			"Str +4, Dex +7, Int +6, Wis +6",
			"Arcana +6, Insight +6, Perception +6",
			"",
			"",
			"",
			"",
			"passive Perception 16",
			"Gith",
			"***Innate Spellcasting (Psionics).*** The githzerai casts the following spells innately, using Wisdom (spell save DC 14, +6 to hit with spell attacks) and needing no components:\n\n- At will: *mage hand* (the hand is invisible)\n- 3/day each: *feather fall*, *jump*, *see invisibility*, *shield*\n- 1/day each: *phantasmal killer*, *plane shift*\n\n***Psychic Defense.*** While it wears no armor and holds no shield, the githzerai adds its Wisdom modifier to its AC (already included).",
			"***Multiattack.*** The githzerai makes two unarmed strikes.\n\n***Unarmed Strike.*** *Melee Weapon Attack:* +7 to hit, reach 5 ft., one target. *Hit:* 11 (2d6 + 4) bludgeoning damage plus 13 (3d8) psychic damage. The attack is magical.",
			"",
			"",
			"",
			""));
}
