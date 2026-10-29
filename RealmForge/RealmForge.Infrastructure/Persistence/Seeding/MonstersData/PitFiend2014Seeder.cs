using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Pit Fiend (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class PitFiend2014Seeder
{
	public static Monster Build() => Create("pit-fiend", null, CreatureSize.Large, CreatureType.Fiend,
		19, 300, "24d10 + 168", 30, new[] { 26, 14, 24, 22, 18, 24 }, 20m, 25000, 6, 14,
		new Text(
			"Diavolo della fossa",
			null,
			"Immondo Grande (diavolo), legale malvagio",
			"19 (armatura naturale)",
			"9 m, volare 18 m",
			"Cos +13, Des +8, Sag +10",
			"",
			"",
			"freddo; contundenti, perforanti e taglienti da attacchi non magici non argentati",
			"fuoco, veleno",
			"avvelenato",
			"Percezione passiva 14, vista pura 36 m",
			"Infernale, telepatia 36 m",
			"***Armi magiche.*** Gli attacchi con arma del diavolo della fossa sono magici.\n\n***Aura di paura.*** Ogni creatura ostile al diavolo della fossa che inizi il proprio turno entro 6 metri da esso deve effettuare un tiro salvezza su Saggezza con CD 21, a meno che il diavolo della fossa non sia incapacitato. Se fallisce, la creatura è spaventata fino all'inizio del proprio turno successivo. Se lo supera, invece, è immune all'Aura di paura del diavolo della fossa per le 24 ore successive.\n\n***Incantesimi innati.*** La caratteristica da incantatore del diavolo della fossa è Carisma (CD del tiro salvezza sull'incantesimo 21). Per sua natura, il diavolo della fossa è in grado di lanciare gli incantesimi indicati di seguito senza aver bisogno di componenti materiali:\n\n- A volontà: *individuazione del magico, palla di fuoco*\n- 3/giorno ciascuno: *blocca mostri, muro di fuoco*\n\n***Resistenza alla magia.*** Il diavolo della fossa dispone di vantaggio ai tiri salvezza contro incantesimi e altri effetti magici.",
			"***Multiattacco.*** Il diavolo della fossa effettua quattro attacchi: uno con il morso, uno con gli artigli, uno con la mazza e uno con la coda.\n\n***Artiglio.*** *Attacco con arma da mischia:* +14 al tiro per colpire, portata 3 m, un bersaglio. *Colpito:* 17 (2d8 + 8) danni taglienti.\n\n***Coda.*** *Attacco con arma da mischia:* +14 al tiro per colpire, portata 3 m, un bersaglio. *Colpito:* 24 (3d10 + 8) danni contundenti.\n\n***Mazza.*** *Attacco con arma da mischia:* +14 al tiro per colpire, portata 3 m, un bersaglio. *Colpito:* 15 (2d6 + 8) danni contundenti più 21 (6d6) danni da fuoco.\n\n***Morso.*** *Attacco con arma da mischia:* +14 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 22 (4d6 + 8) danni perforanti. Il bersaglio deve superare un tiro salvezza su Costituzione con CD 21, altrimenti viene avvelenato. Finché è avvelenato in questo modo, il bersaglio non può recuperare punti ferita e subisce 21 (6d6) danni da veleno all'inizio di ogni suo turno. La creatura avvelenata può ripetere il tiro salvezza alla fine di ogni suo turno e, se lo supera, l'effetto svanisce.",
			"",
			""),
		new Text(
			"Pit Fiend",
			null,
			"Large fiend (devil), lawful evil",
			"19 (natural armor)",
			"30 ft., fly 60 ft.",
			"Dex +8, Con +13, Wis +10",
			"",
			"",
			"cold; bludgeoning, piercing, and slashing from nonmagical weapons that aren't silvered",
			"fire, poison",
			"poisoned",
			"truesight 120 ft., passive Perception 14",
			"Infernal, telepathy 120 ft.",
			"***Fear Aura.*** Any creature hostile to the pit fiend that starts its turn within 20 feet of the pit fiend must make a DC 21 Wisdom saving throw, unless the pit fiend is incapacitated. On a failed save, the creature is frightened until the start of its next turn. If a creature's saving throw is successful, the creature is immune to the pit fiend's Fear Aura for the next 24 hours.\n\n***Magic Resistance.*** The pit fiend has advantage on saving throws against spells and other magical effects.\n\n***Magic Weapons.*** The pit fiend's weapon attacks are magical.\n\n***Innate Spellcasting.*** The pit fiend's spellcasting ability is Charisma (spell save DC 21). The pit fiend can innately cast the following spells, requiring no material components:\n\n- At will: *detect magic, fireball*\n- 3/day each: *hold monster, wall of fire*",
			"***Multiattack.*** The pit fiend makes four attacks: one with its bite, one with its claw, one with its mace, and one with its tail.\n\n***Bite.*** *Melee Weapon Attack:* +14 to hit, reach 5 ft., one target. *Hit:* 22 (4d6 + 8) piercing damage. The target must succeed on a DC 21 Constitution saving throw or become poisoned. While poisoned in this way, the target can't regain hit points, and it takes 21 (6d6) poison damage at the start of each of its turns. The poisoned target can repeat the saving throw at the end of each of its turns, ending the effect on itself on a success.\n\n***Claw.*** *Melee Weapon Attack:* +14 to hit, reach 10 ft., one target. *Hit:* 17 (2d8 + 8) slashing damage.\n\n***Mace.*** *Melee Weapon Attack:* +14 to hit, reach 10 ft., one target. *Hit:* 15 (2d6 + 8) bludgeoning damage plus 21 (6d6) fire damage.\n\n***Tail.*** *Melee Weapon Attack:* +14 to hit, reach 10 ft., one target. *Hit:* 24 (3d10 + 8) bludgeoning damage.",
			"",
			""));
}
