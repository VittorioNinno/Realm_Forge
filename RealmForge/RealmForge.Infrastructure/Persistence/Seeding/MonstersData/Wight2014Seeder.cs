using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Wight (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Wight2014Seeder
{
	public static Monster Build() => Create("wight", null, ContentSource.Srd51, CreatureSize.Medium, CreatureType.Undead,
		14, 45, "6d8 + 18", 30, new[] { 15, 14, 16, 10, 13, 15 }, 3m, 700, 2, 13,
		new Text(
			"Wight",
			null,
			"Non morto Medio, neutrale malvagio",
			"14 (cuoio borchiato)",
			"9 m",
			"",
			"Furtività +4, Percezione +3",
			"",
			"necrotici; contundenti, perforanti e taglienti da attacchi non magici non argentati",
			"veleno",
			"avvelenato, indebolimento",
			"Percezione passiva 13, scurovisione 18 m",
			"quelli conosciuti in vita",
			"***Sensibilità al sole.*** Finché è esposto alla luce del sole, il wight subisce svantaggio ai tiri per colpire, oltre che alle prove di Saggezza (Percezione) basate sulla vista.",
			"***Multiattacco.*** Il wight effettua due attacchi con la spada lunga o con l'arco lungo. Può usare il Risucchio di vita al posto di un attacco con la spada lunga.\n\n***Risucchio di vita.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, una creatura. *Colpito:* 5 (1d6 + 2) danni necrotici. Il bersaglio deve superare un tiro salvezza su Costituzione con CD 13, o i suoi punti ferita massimi vengono ridotti di un importo pari al danno subito. Questa riduzione dura finché il bersaglio non completa un riposo lungo. Il bersaglio muore se questo effetto riduce a 0 i suoi punti ferita massimi. Un umanoide ucciso da questo attacco si anima 24 ore dopo come zombi sotto il controllo del wight, a meno che l'umanoide non sia riportato in vita o il suo corpo non venga distrutto. Il wight non può controllare più di dodici zombi simultaneamente.\n\n***Spada lunga.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 6 (1d8 + 2) danni taglienti o 7 (1d10 + 2) danni taglienti se impugnata con due mani.\n\n***Arco lungo.*** *Attacco con arma a distanza:* +4 al tiro per colpire, gittata 45/180 m, un bersaglio. *Colpito:* 6 (1d8 + 2) danni perforanti.",
			"",
			"",
			"",
			""),
		new Text(
			"Wight",
			null,
			"Medium undead, neutral evil",
			"14 (studded leather armor)",
			"30 ft.",
			"",
			"Perception +3, Stealth +4",
			"",
			"necrotic; bludgeoning, piercing, and slashing from nonmagical weapons that aren't silvered",
			"poison",
			"exhaustion, poisoned",
			"darkvision 60 ft., passive Perception 13",
			"the languages it knew in life",
			"***Sunlight Sensitivity.*** While in sunlight, the wight has disadvantage on attack rolls, as well as on Wisdom (Perception) checks that rely on sight.",
			"***Multiattack.*** The wight makes two longsword attacks or two longbow attacks. It can use its Life Drain in place of one longsword attack.\n\n***Life Drain.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one creature. *Hit:* 5 (1d6 + 2) necrotic damage. The target must succeed on a DC 13 Constitution saving throw or its hit point maximum is reduced by an amount equal to the damage taken. This reduction lasts until the target finishes a long rest. The target dies if this effect reduces its hit point maximum to 0.\n\nA humanoid slain by this attack rises 24 hours later as a zombie under the wight's control, unless the humanoid is restored to life or its body is destroyed. The wight can have no more than twelve zombies under its control at one time.\n\n***Longsword.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one target. *Hit:* 6 (1d8 + 2) slashing damage, or 7 (1d10 + 2) slashing damage if used with two hands.\n\n***Longbow.*** *Ranged Weapon Attack:* +4 to hit, range 150/600 ft., one target. *Hit:* 6 (1d8 + 2) piercing damage.",
			"",
			"",
			"",
			""));
}
