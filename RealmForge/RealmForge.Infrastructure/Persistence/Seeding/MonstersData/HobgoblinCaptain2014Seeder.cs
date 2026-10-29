using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Hobgoblin Captain (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class HobgoblinCaptain2014Seeder
{
	public static Monster Build() => Create("hobgoblin-captain", null, ContentSource.RealmForge, CreatureSize.Medium, CreatureType.Humanoid,
		17, 39, "6d8 + 12", 30, new[] { 15, 14, 14, 12, 10, 13 }, 3m, 700, 2, 10,
		new Text(
			"Hobgoblin capitano",
			null,
			"Umanoide Medio (goblinoide), legale malvagio",
			"17 (mezza armatura)",
			"9 m",
			"",
			"",
			"",
			"",
			"",
			"",
			"Percezione passiva 10, scurovisione 18 m",
			"Comune, Goblin",
			"***Vantaggio marziale.*** Una volta per turno, l'hobgoblin può infliggere 10 (3d6) danni extra a una creatura che colpisce con un attacco con arma, se quella creatura si trova entro 1,5 metri da un alleato dell'hobgoblin che non sia incapacitato.",
			"***Multiattacco.*** L'hobgoblin effettua due attacchi con lo spadone.\n\n***Spadone.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 9 (2d6 + 2) danni taglienti.\n\n***Giavellotto.*** *Attacco con arma da mischia o a distanza:* +4 al tiro per colpire, portata 1,5 m o gittata 9/36 m, un bersaglio. *Colpito:* 5 (1d6 + 2) danni perforanti.\n\n***Comando (ricarica dopo un riposo breve o lungo).*** Per 1 minuto, ogni volta che una creatura non ostile che l'hobgoblin è in grado di vedere entro 9 metri da lui effettua un tiro per colpire o un tiro salvezza, l'hobgoblin può gridare un ordine o un avvertimento: se la creatura lo sente e lo capisce, aggiunge un d4 al tiro. Una creatura beneficia di un solo dado di Comando alla volta, e l'effetto termina se l'hobgoblin è incapacitato.",
			"",
			"",
			"",
			""),
		new Text(
			"Hobgoblin Captain",
			null,
			"Medium humanoid (goblinoid), lawful evil",
			"17 (half plate)",
			"30 ft.",
			"",
			"",
			"",
			"",
			"",
			"",
			"darkvision 60 ft., passive Perception 10",
			"Common, Goblin",
			"***Martial Advantage.*** Once per turn, the hobgoblin can deal an extra 10 (3d6) damage to a creature it hits with a weapon attack, if that creature is within 5 feet of one of the hobgoblin's allies that isn't incapacitated.",
			"***Multiattack.*** The hobgoblin makes two greatsword attacks.\n\n***Greatsword.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one target. *Hit:* 9 (2d6 + 2) slashing damage.\n\n***Javelin.*** *Melee or Ranged Weapon Attack:* +4 to hit, reach 5 ft. or range 30/120 ft., one target. *Hit:* 5 (1d6 + 2) piercing damage.\n\n***Leadership (Recharges after a Short or Long Rest).*** For 1 minute, whenever a creature the hobgoblin can see within 30 feet of it, not hostile to it, makes an attack roll or a saving throw, the hobgoblin can shout an order or a warning: if the creature hears and understands it, it adds a d4 to the roll. A creature benefits from only one Leadership die at a time, and the effect ends if the hobgoblin is incapacitated.",
			"",
			"",
			"",
			""));
}
