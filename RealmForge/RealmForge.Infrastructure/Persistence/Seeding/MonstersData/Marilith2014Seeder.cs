using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Marilith (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Marilith2014Seeder
{
	public static Monster Build() => Create("marilith", null, CreatureSize.Large, CreatureType.Fiend,
		18, 189, "18d10 + 90", 40, new[] { 18, 20, 20, 18, 16, 20 }, 16m, 15000, 5, 13,
		new Text(
			"Marilith",
			null,
			"Immondo Grande (demone), caotica malvagia",
			"18 (armatura naturale)",
			"12 m",
			"Car +10, Cos +10, For +9, Sag +8",
			"",
			"",
			"freddo, fulmine, fuoco; contundenti, perforanti e taglienti da attacchi non magici",
			"veleno",
			"avvelenato",
			"Percezione passiva 13, vista pura 36 m",
			"Abissale, telepatia 36 m",
			"***Armi magiche.*** Gli attacchi con arma della marilith sono magici.\n\n***Reattiva.*** La marilith può eseguire una reazione a ogni turno in combattimento.\n\n***Resistenza alla magia.*** La marilith dispone di vantaggio ai tiri salvezza contro incantesimi e altri effetti magici.",
			"***Multiattacco.*** La marilith effettua sette attacchi: sei con le spade lunghe e uno con la coda.\n\n***Coda.*** *Attacco con arma da mischia:* +9 al tiro per colpire, portata 3 m, una creatura. *Colpito:* 15 (2d10 + 4) danni contundenti. Se il bersaglio è di taglia Media o inferiore, viene afferrato (CD 19 per sfuggire). Finché la presa perdura, il bersaglio è trattenuto e la marilith può colpirlo automaticamente con la coda ma non può effettuare attacchi di questo tipo contro altri.\n\n***Spada lunga.*** *Attacco con arma da mischia:* +9 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 13 (2d8 + 4) danni taglienti.\n\n***Teletrasporto.*** La marilith si teletrasporta magicamente, insieme a ogni oggetto che indossa o trasporta, fino a uno spazio libero visibile entro 36 metri.",
			"***Parata.*** La marilith aggiunge 5 alla sua CA contro un attacco in mischia che la colpirebbe. Per farlo, deve vedere l'attaccante e deve impugnare un'arma da mischia.",
			""),
		new Text(
			"Marilith",
			null,
			"Large fiend (demon), chaotic evil",
			"18 (natural armor)",
			"40 ft.",
			"Str +9, Con +10, Wis +8, Cha +10",
			"",
			"",
			"cold, fire, lightning; bludgeoning, piercing, and slashing from nonmagical weapons",
			"poison",
			"poisoned",
			"truesight 120 ft., passive Perception 13",
			"Abyssal, telepathy 120 ft.",
			"***Magic Resistance.*** The marilith has advantage on saving throws against spells and other magical effects.\n\n***Magic Weapons.*** The marilith's weapon attacks are magical.\n\n***Reactive.*** The marilith can take one reaction on every turn in combat.",
			"***Multiattack.*** The marilith can make seven attacks: six with its longswords and one with its tail.\n\n***Longsword.*** *Melee Weapon Attack:* +9 to hit, reach 5 ft., one target. *Hit:* 13 (2d8 + 4) slashing damage.\n\n***Tail.*** *Melee Weapon Attack:* +9 to hit, reach 10 ft., one creature. *Hit:* 15 (2d10 + 4) bludgeoning damage. If the target is Medium or smaller, it is grappled (escape DC 19). Until this grapple ends, the target is restrained, the marilith can automatically hit the target with its tail, and the marilith can't make tail attacks against other targets.\n\n***Teleport.*** The marilith magically teleports, along with any equipment it is wearing or carrying, up to 120 feet to an unoccupied space it can see.",
			"***Parry.*** The marilith adds 5 to its AC against one melee attack that would hit it. To do so, the marilith must see the attacker and be wielding a melee weapon.",
			""));
}
