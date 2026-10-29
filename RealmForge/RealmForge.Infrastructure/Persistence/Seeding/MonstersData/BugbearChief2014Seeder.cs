using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Bugbear Chief (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class BugbearChief2014Seeder
{
	public static Monster Build() => Create("bugbear-chief", null, ContentSource.RealmForge, CreatureSize.Medium, CreatureType.Humanoid,
		17, 65, "10d8 + 20", 30, new[] { 17, 14, 14, 11, 12, 11 }, 3m, 700, 2, 11,
		new Text(
			"Bugbear capotribù",
			null,
			"Umanoide Medio (goblinoide), caotico malvagio",
			"17 (giaco di maglia, scudo)",
			"9 m",
			"",
			"Furtività +6, Intimidire +2, Sopravvivenza +3",
			"",
			"",
			"",
			"",
			"Percezione passiva 11, scurovisione 18 m",
			"Comune, Goblin",
			"***Bruto.*** Quando il bugbear colpisce con un'arma da mischia, l'arma infligge un dado di danno in più (già incluso nei suoi attacchi).\n\n***Cuore di Hruggek.*** Il bugbear dispone di vantaggio ai tiri salvezza per non essere affascinato, avvelenato, paralizzato, spaventato, stordito o addormentato.\n\n***Attacco a sorpresa.*** Se il bugbear sorprende una creatura e la colpisce con un attacco nel primo round di combattimento, l'attacco infligge 7 (2d6) danni extra.",
			"***Multiattacco.*** Il bugbear effettua due attacchi in mischia.\n\n***Morning star.*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 12 (2d8 + 3) danni perforanti.\n\n***Giavellotto.*** *Attacco con arma da mischia o a distanza:* +5 al tiro per colpire, portata 1,5 m o gittata 9/36 m, un bersaglio. *Colpito:* 10 (2d6 + 3) danni perforanti in mischia, o 6 (1d6 + 3) danni perforanti a distanza.",
			"",
			"",
			"",
			""),
		new Text(
			"Bugbear Chief",
			null,
			"Medium humanoid (goblinoid), chaotic evil",
			"17 (chain shirt, shield)",
			"30 ft.",
			"",
			"Intimidation +2, Stealth +6, Survival +3",
			"",
			"",
			"",
			"",
			"darkvision 60 ft., passive Perception 11",
			"Common, Goblin",
			"***Brute.*** When the bugbear hits with a melee weapon, the weapon deals one extra die of its damage (already counted in its attacks).\n\n***Heart of Hruggek.*** The bugbear has advantage on saving throws against being charmed, frightened, paralyzed, poisoned, stunned or put to sleep.\n\n***Surprise Attack.*** If the bugbear surprises a creature and hits it with an attack in the first round of combat, the attack deals an extra 7 (2d6) damage.",
			"***Multiattack.*** The bugbear makes two melee attacks.\n\n***Morningstar.*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one target. *Hit:* 12 (2d8 + 3) piercing damage.\n\n***Javelin.*** *Melee or Ranged Weapon Attack:* +5 to hit, reach 5 ft. or range 30/120 ft., one target. *Hit:* 10 (2d6 + 3) piercing damage in melee, or 6 (1d6 + 3) piercing damage at range.",
			"",
			"",
			"",
			""));
}
