using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Flesh Golem (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class FleshGolem2014Seeder
{
	public static Monster Build() => Create("flesh-golem", null, CreatureSize.Medium, CreatureType.Construct,
		9, 93, "11d8 + 44", 30, new[] { 19, 9, 18, 6, 10, 5 }, 5m, 1800, 3, 10,
		new Text(
			"Golem di carne",
			null,
			"Costrutto Medio, neutrale",
			"9",
			"9 m",
			"",
			"",
			"",
			"",
			"fulmine, veleno; contundenti, perforanti e taglienti da attacchi non magici non adamantini",
			"affascinato, avvelenato, indebolimento, paralizzato, pietrificato, spaventato",
			"Percezione passiva 10, scurovisione 18 m",
			"comprende i linguaggi del suo creatore ma non li sa parlare",
			"***Armi magiche.*** Gli attacchi con arma del golem sono magici.\n\n***Assorbimento del fulmine.*** Ogni volta che il golem è soggetto a danni da fulmine, non subisce danni e anzi recupera un numero di punti ferita pari ai danni da fulmine inflitti.\n\n***Avversione al fuoco.*** Se il golem subisce danni da fuoco, ha svantaggio ai tiri per colpire e alle prove di caratteristica fino alla fine del suo turno successivo.\n\n***Berserk.*** Ogni volta che il golem inizia il suo turno con 40 punti ferita o meno, si tira un d6. Con un risultato di 6, il golem entra in uno stato di berserk. A ogni suo turno, finché è in stato di berserk, il golem attacca la creatura visibile più vicina. Se nessuna creatura è abbastanza vicina per un attacco, il golem prende di mira un oggetto, prediligendone uno più piccolo di lui. Una volta che il golem è in stato di berserk, non si arresta finché non viene distrutto o non recupera tutti i suoi punti ferita. Il creatore del golem, se si trova entro 18 metri dal golem berserk, può cercare di calmarlo parlandogli con fermezza e persuasione. Il golem deve essere in grado di udire il suo creatore, che userà un'azione per effettuare una prova di Carisma (Persuasione) con CD 15. Se la supera, il golem esce dallo stato di berserk. Se subisce danni mentre ha ancora 40 punti ferita o meno, il golem potrebbe entrare di nuovo in quello stato.\n\n***Forma immutabile.*** Il golem è immune a qualsiasi incantesimo o effetto che ne altererebbe la forma.\n\n***Resistenza alla magia.*** Il golem dispone di vantaggio ai tiri salvezza contro incantesimi e altri effetti magici.",
			"***Multiattacco.*** Il golem effettua due attacchi con schianto.\n\n***Schianto.*** *Attacco con arma da mischia:* +7 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 13 (2d8 + 4) danni contundenti.",
			"",
			""),
		new Text(
			"Flesh Golem",
			null,
			"Medium construct, neutral",
			"9",
			"30 ft.",
			"",
			"",
			"",
			"",
			"lightning, poison; bludgeoning, piercing, and slashing from nonmagical weapons that aren't adamantine",
			"charmed, exhaustion, frightened, paralyzed, petrified, poisoned",
			"darkvision 60 ft., passive Perception 10",
			"understands the languages of its creator but can't speak",
			"***Berserk.*** Whenever the golem starts its turn with 40 hit points or fewer, roll a d6. On a 6, the golem goes berserk. On each of its turns while berserk, the golem attacks the nearest creature it can see. If no creature is near enough to move to and attack, the golem attacks an object, with preference for an object smaller than itself. Once the golem goes berserk, it continues to do so until it is destroyed or regains all its hit points.\n\nThe golem's creator, if within 60 feet of the berserk golem, can try to calm it by speaking firmly and persuasively. The golem must be able to hear its creator, who must take an action to make a DC 15 Charisma (Persuasion) check. If the check succeeds, the golem ceases being berserk. If it takes damage while still at 40 hit points or fewer, the golem might go berserk again.\n\n***Aversion of Fire.*** If the golem takes fire damage, it has disadvantage on attack rolls and ability checks until the end of its next turn.\n\n***Immutable Form.*** The golem is immune to any spell or effect that would alter its form.\n\n***Lightning Absorption.*** Whenever the golem is subjected to lightning damage, it takes no damage and instead regains a number of hit points equal to the lightning damage dealt.\n\n***Magic Resistance.*** The golem has advantage on saving throws against spells and other magical effects.\n\n***Magic Weapons.*** The golem's weapon attacks are magical.",
			"***Multiattack.*** The golem makes two slam attacks.\n\n***Slam.*** *Melee Weapon Attack:* +7 to hit, reach 5 ft., one target. *Hit:* 13 (2d8 + 4) bludgeoning damage.",
			"",
			""));
}
