using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Hobgoblin Warlord (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class HobgoblinWarlord2014Seeder
{
	public static Monster Build() => Create("hobgoblin-warlord", null, ContentSource.RealmForge, CreatureSize.Medium, CreatureType.Humanoid,
		20, 97, "13d8 + 39", 30, new[] { 16, 14, 16, 14, 11, 15 }, 6m, 2300, 3, 10,
		new Text(
			"Hobgoblin signore della guerra",
			null,
			"Umanoide Medio (goblinoide), legale malvagio",
			"20 (armatura completa, scudo)",
			"9 m",
			"Car +5, Int +5, Sag +3",
			"",
			"",
			"",
			"",
			"",
			"Percezione passiva 10, scurovisione 18 m",
			"Comune, Goblin",
			"***Vantaggio marziale.*** Una volta per turno, l'hobgoblin può infliggere 14 (4d6) danni extra a una creatura che colpisce con un attacco con arma, se quella creatura si trova entro 1,5 metri da un alleato dell'hobgoblin che non sia incapacitato.",
			"***Multiattacco.*** L'hobgoblin effettua tre attacchi in mischia, oppure due attacchi a distanza con i giavellotti.\n\n***Spada lunga.*** *Attacco con arma da mischia:* +9 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 7 (1d8 + 3) danni taglienti, o 8 (1d10 + 3) danni taglienti se impugnata a due mani.\n\n***Colpo di scudo.*** *Attacco con arma da mischia:* +9 al tiro per colpire, portata 1,5 m, una creatura. *Colpito:* 5 (1d4 + 3) danni contundenti. Un bersaglio di taglia Grande o inferiore deve superare un tiro salvezza su Forza con CD 14, altrimenti cade prono.\n\n***Giavellotto.*** *Attacco con arma da mischia o a distanza:* +9 al tiro per colpire, portata 1,5 m o gittata 9/36 m, un bersaglio. *Colpito:* 6 (1d6 + 3) danni perforanti.\n\n***Comando (ricarica dopo un riposo breve o lungo).*** Per 1 minuto, ogni volta che una creatura non ostile che l'hobgoblin è in grado di vedere entro 9 metri da lui effettua un tiro per colpire o un tiro salvezza, l'hobgoblin può gridare un ordine o un avvertimento: se la creatura lo sente e lo capisce, aggiunge un d4 al tiro. Una creatura beneficia di un solo dado di Comando alla volta, e l'effetto termina se l'hobgoblin è incapacitato.",
			"",
			"***Parata.*** Quando un attacco in mischia sta per colpirlo, l'hobgoblin può aggiungere 3 alla sua CA contro quell'attacco, purché veda l'attaccante e impugni un'arma da mischia.",
			"",
			""),
		new Text(
			"Hobgoblin Warlord",
			null,
			"Medium humanoid (goblinoid), lawful evil",
			"20 (plate, shield)",
			"30 ft.",
			"Int +5, Wis +3, Cha +5",
			"",
			"",
			"",
			"",
			"",
			"darkvision 60 ft., passive Perception 10",
			"Common, Goblin",
			"***Martial Advantage.*** Once per turn, the hobgoblin can deal an extra 14 (4d6) damage to a creature it hits with a weapon attack, if that creature is within 5 feet of one of the hobgoblin's allies that isn't incapacitated.",
			"***Multiattack.*** The hobgoblin makes three melee attacks, or two ranged attacks with its javelins.\n\n***Longsword.*** *Melee Weapon Attack:* +9 to hit, reach 5 ft., one target. *Hit:* 7 (1d8 + 3) slashing damage, or 8 (1d10 + 3) slashing damage if used with two hands.\n\n***Shield Bash.*** *Melee Weapon Attack:* +9 to hit, reach 5 ft., one creature. *Hit:* 5 (1d4 + 3) bludgeoning damage. A Large or smaller target must succeed on a DC 14 Strength saving throw or be knocked prone.\n\n***Javelin.*** *Melee or Ranged Weapon Attack:* +9 to hit, reach 5 ft. or range 30/120 ft., one target. *Hit:* 6 (1d6 + 3) piercing damage.\n\n***Leadership (Recharges after a Short or Long Rest).*** For 1 minute, whenever a creature the hobgoblin can see within 30 feet of it, not hostile to it, makes an attack roll or a saving throw, the hobgoblin can shout an order or a warning: if the creature hears and understands it, it adds a d4 to the roll. A creature benefits from only one Leadership die at a time, and the effect ends if the hobgoblin is incapacitated.",
			"",
			"***Parry.*** When a melee attack would hit it, the hobgoblin can add 3 to its AC against that attack, provided it can see the attacker and holds a melee weapon.",
			"",
			""));
}
