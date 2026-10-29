using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Hobgoblin (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Hobgoblin2014Seeder
{
	public static Monster Build() => Create("hobgoblin", null, ContentSource.Srd51, CreatureSize.Medium, CreatureType.Humanoid,
		18, 11, "2d8 + 2", 30, new[] { 13, 12, 12, 10, 10, 9 }, 0.5m, 100, 2, 10,
		new Text(
			"Hobgoblin",
			null,
			"Umanoide Medio (goblinoide), legale malvagio",
			"18 (cotta di maglia, scudo)",
			"9 m",
			"",
			"",
			"",
			"",
			"",
			"",
			"Percezione passiva 10, scurovisione 18 m",
			"Comune, Goblin",
			"***Vantaggio marziale.*** Una volta per turno, l'hobgoblin può infliggere 7 (2d6) danni extra a una creatura che colpisce con un attacco con arma, se quella creatura si trova entro 1,5 metri da un alleato dell'hobgoblin che non sia incapacitato.",
			"***Spada lunga.*** *Attacco con arma da mischia:* +3 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 5 (1d8 + 1) danni taglienti o 6 (1d10 + 1) danni taglienti se impugnata con due mani.\n\n***Arco lungo.*** *Attacco con arma a distanza:* +3 al tiro per colpire, gittata 45/180 m, un bersaglio. *Colpito:* 5 (1d8 + 1) danni perforanti.",
			"",
			"",
			"",
			""),
		new Text(
			"Hobgoblin",
			null,
			"Medium humanoid (goblinoid), lawful evil",
			"18 (chain mail, shield)",
			"30 ft.",
			"",
			"",
			"",
			"",
			"",
			"",
			"darkvision 60 ft., passive Perception 10",
			"Common, Goblin",
			"***Martial Advantage.*** Once per turn, the hobgoblin can deal an extra 7 (2d6) damage to a creature it hits with a weapon attack if that creature is within 5 ft. of an ally of the hobgoblin that isn't incapacitated.",
			"***Longsword.*** *Melee Weapon Attack:* +3 to hit, reach 5 ft., one target. *Hit:* 5 (1d8 + 1) slashing damage, or 6 (1d10 + 1) slashing damage if used with two hands.\n\n***Longbow.*** *Ranged Weapon Attack:* +3 to hit, range 150/600 ft., one target. *Hit:* 5 (1d8 + 1) piercing damage.",
			"",
			"",
			"",
			""));
}
