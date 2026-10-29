using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Goblin Boss (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class GoblinBoss2014Seeder
{
	public static Monster Build() => Create("goblin-boss", null, ContentSource.RealmForge, CreatureSize.Small, CreatureType.Humanoid,
		17, 21, "6d6", 30, new[] { 10, 14, 10, 10, 8, 10 }, 1m, 200, 2, 9,
		new Text(
			"Goblin capo",
			null,
			"Umanoide Piccolo (goblinoide), neutrale malvagio",
			"17 (giaco di maglia, scudo)",
			"9 m",
			"",
			"Furtività +6",
			"",
			"",
			"",
			"",
			"Percezione passiva 9, scurovisione 18 m",
			"Comune, Goblin",
			"***Fuga agile.*** A ogni suo turno, il goblin può effettuare l'azione di Disimpegno o di Nascondersi come azione bonus.",
			"***Multiattacco.*** Il goblin effettua due attacchi con la scimitarra; il secondo subisce svantaggio.\n\n***Scimitarra.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 5 (1d6 + 2) danni taglienti.\n\n***Giavellotto.*** *Attacco con arma da mischia o a distanza:* +4 al tiro per colpire, portata 1,5 m o gittata 9/36 m, un bersaglio. *Colpito:* 5 (1d6 + 2) danni perforanti.",
			"",
			"***Deviare attacco.*** Quando una creatura che il goblin è in grado di vedere lo bersaglia con un attacco, il goblin sceglie un altro goblin entro 1,5 metri da lui: i due si scambiano di posto e l'altro goblin diventa il bersaglio.",
			"",
			""),
		new Text(
			"Goblin Boss",
			null,
			"Small humanoid (goblinoid), neutral evil",
			"17 (chain shirt, shield)",
			"30 ft.",
			"",
			"Stealth +6",
			"",
			"",
			"",
			"",
			"darkvision 60 ft., passive Perception 9",
			"Common, Goblin",
			"***Nimble Escape.*** On each of its turns, the goblin can take the Disengage or Hide action as a bonus action.",
			"***Multiattack.*** The goblin makes two scimitar attacks; the second one has disadvantage.\n\n***Scimitar.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one target. *Hit:* 5 (1d6 + 2) slashing damage.\n\n***Javelin.*** *Melee or Ranged Weapon Attack:* +4 to hit, reach 5 ft. or range 30/120 ft., one target. *Hit:* 5 (1d6 + 2) piercing damage.",
			"",
			"***Redirect Attack.*** When a creature the goblin can see targets it with an attack, the goblin picks another goblin within 5 feet of it: they swap places, and the other goblin becomes the target.",
			"",
			""));
}
