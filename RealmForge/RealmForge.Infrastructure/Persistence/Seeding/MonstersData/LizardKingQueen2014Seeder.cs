using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Lizard King/Queen (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class LizardKingQueen2014Seeder
{
	public static Monster Build() => Create("lizard-king-queen", null, ContentSource.RealmForge, CreatureSize.Medium, CreatureType.Humanoid,
		15, 78, "12d8 + 24", 30, new[] { 17, 12, 15, 11, 11, 15 }, 4m, 1100, 2, 14,
		new Text(
			"Re/regina lucertola",
			null,
			"Umanoide Medio (lucertoloide), caotico malvagio",
			"15 (armatura naturale)",
			"9 m, nuotare 9 m",
			"Cos +4, Sag +2",
			"Furtività +5, Percezione +4, Sopravvivenza +4",
			"",
			"",
			"",
			"spaventato",
			"Percezione passiva 14, scurovisione 18 m",
			"Abissale, Draconico",
			"***Trattenere il respiro.*** Il lucertoloide può trattenere il respiro per 15 minuti.\n\n***Infilzare.*** Una volta per turno, quando il lucertoloide colpisce con un attacco in mischia con il tridente, il bersaglio subisce 10 (3d6) danni extra e il lucertoloide ottiene punti ferita temporanei pari a quei danni extra.",
			"***Multiattacco.*** Il lucertoloide effettua due attacchi: uno con il morso e uno con gli artigli o con il tridente, oppure due attacchi in mischia con il tridente.\n\n***Morso.*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 6 (1d6 + 3) danni perforanti.\n\n***Artigli.*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 5 (1d4 + 3) danni taglienti.\n\n***Tridente.*** *Attacco con arma da mischia o a distanza:* +5 al tiro per colpire, portata 1,5 m o gittata 6/18 m, un bersaglio. *Colpito:* 6 (1d6 + 3) danni perforanti, o 7 (1d8 + 3) danni perforanti se impugnata a due mani.",
			"",
			"",
			"",
			""),
		new Text(
			"Lizard King/Queen",
			null,
			"Medium humanoid (lizardfolk), chaotic evil",
			"15 (natural armor)",
			"30 ft., swim 30 ft.",
			"Con +4, Wis +2",
			"Perception +4, Stealth +5, Survival +4",
			"",
			"",
			"",
			"frightened",
			"darkvision 60 ft., passive Perception 14",
			"Abyssal, Draconic",
			"***Hold Breath.*** The lizardfolk can hold its breath for 15 minutes.\n\n***Skewer.*** Once per turn, when the lizardfolk hits with a melee trident attack, the target takes an extra 10 (3d6) damage and the lizardfolk gains temporary hit points equal to that extra damage.",
			"***Multiattack.*** The lizardfolk makes two attacks: a bite and a claws or trident attack, or two melee trident attacks.\n\n***Bite.*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one target. *Hit:* 6 (1d6 + 3) piercing damage.\n\n***Claws.*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one target. *Hit:* 5 (1d4 + 3) slashing damage.\n\n***Trident.*** *Melee or Ranged Weapon Attack:* +5 to hit, reach 5 ft. or range 20/60 ft., one target. *Hit:* 6 (1d6 + 3) piercing damage, or 7 (1d8 + 3) piercing damage if used with two hands.",
			"",
			"",
			"",
			""));
}
