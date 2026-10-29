using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Planetar (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Planetar2014Seeder
{
	public static Monster Build() => Create("planetar", null, ContentSource.Srd51, CreatureSize.Large, CreatureType.Celestial,
		19, 200, "16d10 + 112", 40, new[] { 24, 20, 24, 19, 22, 25 }, 16m, 15000, 5, 21,
		new Text(
			"Planetar",
			null,
			"Celestiale Grande, legale buono",
			"19 (armatura naturale)",
			"12 m, volare 36 m",
			"Car +12, Cos +12, Sag +11",
			"Percezione +11",
			"",
			"radiosi, contundenti, perforanti e taglienti da attacchi non magici",
			"",
			"affascinato, indebolimento, spaventato",
			"Percezione passiva 21, vista pura 36 m",
			"tutti, telepatia 36 m",
			"***Armi angeliche.*** Gli attacchi con arma del planetar sono magici. Quando il planetar colpisce con qualsiasi arma, la sua arma infligge 5d8 danni radiosi extra (già inclusi nell'attacco).\n\n***Consapevolezza divina.*** Il planetar sa riconoscere le menzogne.\n\n***Incantesimi innati.*** La caratteristica da incantatore del planetar è Carisma (CD del tiro salvezza sull'incantesimo 20). Per sua natura, il planetar è in grado di lanciare gli incantesimi indicati di seguito senza aver bisogno di componenti materiali:\n\n- A volontà: *individuazione del bene e del male, invisibilità* (solo se stesso)\n- 3/giorno ciascuno: *barriera di lame, colpo infuocato, dissolvi il bene e il male, rianimare morti*\n- 1/giorno ciascuno: *comunione, controllare tempo atmosferico, piaga degli insetti*\n\n***Resistenza alla magia.*** Il planetar dispone di vantaggio ai tiri salvezza contro incantesimi e altri effetti magici.",
			"***Multiattacco.*** Il planetar effettua due attacchi in mischia.\n\n***Spadone.*** *Attacco con arma da mischia:* +12 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 21 (4d6 + 7) danni taglienti più 22 (5d8) danni radiosi.\n\n***Tocco Guaritore (4/giorno).*** Il planetar tocca un'altra creatura. Il bersaglio recupera magicamente 30 (6d8 + 3) punti ferita ed è liberato da qualsiasi maledizione, malattia, veleno, cecità o sordità.",
			"",
			"",
			"",
			""),
		new Text(
			"Planetar",
			null,
			"Large celestial, lawful good",
			"19 (natural armor)",
			"40 ft., fly 120 ft.",
			"Con +12, Wis +11, Cha +12",
			"Perception +11",
			"",
			"radiant; bludgeoning, piercing, and slashing from nonmagical weapons",
			"",
			"charmed, exhaustion, frightened",
			"truesight 120 ft., passive Perception 21",
			"all, telepathy 120 ft.",
			"***Angelic Weapons.*** The planetar's weapon attacks are magical. When the planetar hits with any weapon, the weapon deals an extra 5d8 radiant damage (included in the attack).\n\n***Divine Awareness.*** The planetar knows if it hears a lie.\n\n***Innate Spellcasting.*** The planetar's spellcasting ability is Charisma (spell save DC 20). The planetar can innately cast the following spells, requiring no material components:\n\n- At will: *detect evil and good, invisibility (self only)*\n- 3/day each: *blade barrier, dispel evil and good, flame strike, raise dead*\n- 1/day each: *commune, control weather, insect plague*\n\n***Magic Resistance.*** The planetar has advantage on saving throws against spells and other magical effects.",
			"***Multiattack.*** The planetar makes two melee attacks.\n\n***Greatsword.*** *Melee Weapon Attack:* +12 to hit, reach 5 ft., one target. *Hit:* 21 (4d6 + 7) slashing damage plus 22 (5d8) radiant damage.\n\n***Healing Touch (4/Day).*** The planetar touches another creature. The target magically regains 30 (6d8 + 3) hit points and is freed from any curse, disease, poison, blindness, or deafness.",
			"",
			"",
			"",
			""));
}
