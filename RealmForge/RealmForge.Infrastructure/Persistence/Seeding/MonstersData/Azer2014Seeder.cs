using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Azer (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Azer2014Seeder
{
	public static Monster Build() => Create("azer", null, CreatureSize.Medium, CreatureType.Elemental,
		17, 39, "6d8 + 12", 30, new[] { 17, 12, 15, 12, 13, 10 }, 2m, 450, 2, 11,
		new Text(
			"Azer",
			null,
			"Elementale Medio, legale neutrale",
			"17 (armatura naturale, scudo)",
			"9 m",
			"Cos +4",
			"",
			"",
			"",
			"fuoco, veleno",
			"avvelenato",
			"Percezione passiva 11",
			"Ignan",
			"***Armi surriscaldate.*** Quando l'azer colpisce con un'arma da mischia in metallo, infligge 3 (1d6) danni da fuoco extra (già inclusi nell'attacco).\n\n***Corpo surriscaldato.*** Una creatura che tocchi l'azer o lo colpisca con un attacco in mischia mentre si trova a 1,5 metri da esso subisce 5 (1d10) danni da fuoco.\n\n***Illuminazione.*** L'azer emana luce intensa in un raggio di 3 metri e luce fioca per ulteriori 3 metri.",
			"***Martello da guerra.*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 7 (1d8 + 3) danni contundenti, o 8 (1d10 + 3) danni contundenti se usato a due mani per effettuare un attacco in mischia, più 3 (1d6) danni da fuoco.",
			"",
			""),
		new Text(
			"Azer",
			null,
			"Medium elemental, lawful neutral",
			"17 (natural armor, shield)",
			"30 ft.",
			"Con +4",
			"",
			"",
			"",
			"fire, poison",
			"poisoned",
			"passive Perception 11",
			"Ignan",
			"***Heated Body.*** A creature that touches the azer or hits it with a melee attack while within 5 ft. of it takes 5 (1d10) fire damage.\n\n***Heated Weapons.*** When the azer hits with a metal melee weapon, it deals an extra 3 (1d6) fire damage (included in the attack).\n\n***Illumination.*** The azer sheds bright light in a 10-foot radius and dim light for an additional 10 ft..",
			"***Warhammer.*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one target. *Hit:* 7 (1d8 + 3) bludgeoning damage, or 8 (1d10 + 3) bludgeoning damage if used with two hands to make a melee attack, plus 3 (1d6) fire damage.",
			"",
			""));
}
