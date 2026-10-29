using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Githzerai Monk (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class GithzeraiMonk2014Seeder
{
	public static Monster Build() => Create("githzerai-monk", null, ContentSource.RealmForge, CreatureSize.Medium, CreatureType.Humanoid,
		14, 38, "7d8 + 7", 30, new[] { 12, 15, 12, 13, 14, 10 }, 2m, 450, 2, 14,
		new Text(
			"Githzerai monaco",
			null,
			"Umanoide Medio (gith), legale neutrale",
			"14",
			"9 m",
			"Des +4, For +3, Int +3, Sag +4",
			"Intuizione +4, Percezione +4",
			"",
			"",
			"",
			"",
			"Percezione passiva 14",
			"Gith",
			"***Incantesimi innati (psionici).*** Il githzerai lancia per natura gli incantesimi seguenti usando la Saggezza, senza bisogno di componenti:\n\n- A volontà: *mano magica* (la mano è invisibile)\n- 3/giorno ciascuno: *caduta morbida*, *saltare*, *vedere invisibilità*, *scudo*\n\n***Difesa psichica.*** Finché non indossa armature e non impugna scudi, il githzerai somma il suo modificatore di Saggezza alla CA (già incluso).",
			"***Multiattacco.*** Il githzerai effettua due colpi senz'armi.\n\n***Colpo senz'armi.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 6 (1d8 + 2) danni contundenti più 9 (2d8) danni psichici. L'attacco è magico.",
			"",
			"",
			"",
			""),
		new Text(
			"Githzerai Monk",
			null,
			"Medium humanoid (gith), lawful neutral",
			"14",
			"30 ft.",
			"Str +3, Dex +4, Int +3, Wis +4",
			"Insight +4, Perception +4",
			"",
			"",
			"",
			"",
			"passive Perception 14",
			"Gith",
			"***Innate Spellcasting (Psionics).*** The githzerai casts the following spells innately, using Wisdom and needing no components:\n\n- At will: *mage hand* (the hand is invisible)\n- 3/day each: *feather fall*, *jump*, *see invisibility*, *shield*\n\n***Psychic Defense.*** While it wears no armor and holds no shield, the githzerai adds its Wisdom modifier to its AC (already included).",
			"***Multiattack.*** The githzerai makes two unarmed strikes.\n\n***Unarmed Strike.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one target. *Hit:* 6 (1d8 + 2) bludgeoning damage plus 9 (2d8) psychic damage. The attack is magical.",
			"",
			"",
			"",
			""));
}
