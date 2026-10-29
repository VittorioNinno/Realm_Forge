using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Salamander (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Salamander2014Seeder
{
	public static Monster Build() => Create("salamander", null, CreatureSize.Large, CreatureType.Elemental,
		15, 90, "12d10 + 24", 30, new[] { 18, 14, 15, 11, 10, 12 }, 5m, 1800, 3, 10,
		new Text(
			"Salamandra",
			null,
			"Elementale Grande, neutrale malvagia",
			"15 (armatura naturale)",
			"9 m",
			"",
			"",
			"freddo",
			"contundenti, perforanti e taglienti da attacchi non magici",
			"fuoco",
			"",
			"Percezione passiva 10, scurovisione 18 m",
			"Ignan",
			"***Armi surriscaldate.*** Ogni arma da mischia di metallo impugnata dalla salamandra infligge 3 (1d6) danni da fuoco extra se il colpo va a segno (già inclusi nell'attacco).\n\n***Corpo surriscaldato.*** Una creatura che tocchi la salamandra o la colpisca con un attacco in mischia trovandosi entro 1,5 metri da essa subisce 7 (2d6) danni da fuoco.",
			"***Multiattacco.*** La salamandra effettua due attacchi: uno con la lancia e uno con la coda.\n\n***Coda.*** *Attacco con arma da mischia:* +7 al tiro per colpire, portata 3 m, un bersaglio. *Colpito:* 11 (2d6 + 4) danni contundenti più 7 (2d6) danni da fuoco e il bersaglio è afferrato (CD 14 per sfuggire). Finché la presa perdura, il bersaglio è trattenuto e la salamandra può colpirlo automaticamente con la coda e non può effettuare attacchi di questo tipo contro altri.\n\n***Lancia.*** *Attacco con arma da mischia o a distanza:* +7 al tiro per colpire, portata 1,5 m o gittata 6/18 m, un bersaglio. *Colpito:* 11 (2d6 + 4) danni perforanti, o 13 (2d8 + 4) danni perforanti se usata a due mani per effettuare un attacco in mischia, più 3 (1d6) danni da fuoco.",
			"",
			""),
		new Text(
			"Salamander",
			null,
			"Large elemental, neutral evil",
			"15 (natural armor)",
			"30 ft.",
			"",
			"",
			"cold",
			"bludgeoning, piercing, and slashing from nonmagical weapons",
			"fire",
			"",
			"darkvision 60 ft., passive Perception 10",
			"Ignan",
			"***Heated Body.*** A creature that touches the salamander or hits it with a melee attack while within 5 ft. of it takes 7 (2d6) fire damage.\n\n***Heated Weapons.*** Any metal melee weapon the salamander wields deals an extra 3 (1d6) fire damage on a hit (included in the attack).",
			"***Multiattack.*** The salamander makes two attacks: one with its spear and one with its tail.\n\n***Spear.*** *Melee or Ranged Weapon Attack:* +7 to hit, reach 5 ft. or range 20/60 ft., one target. *Hit:* 11 (2d6 + 4) piercing damage, or 13 (2d8 + 4) piercing damage if used with two hands to make a melee attack, plus 3 (1d6) fire damage.\n\n***Tail.*** *Melee Weapon Attack:* +7 to hit, reach 10 ft., one target. *Hit:* 11 (2d6 + 4) bludgeoning damage plus 7 (2d6) fire damage, and the target is grappled (escape DC 14). Until this grapple ends, the target is restrained, the salamander can automatically hit the target with its tail, and the salamander can't make tail attacks against other targets.",
			"",
			""));
}
