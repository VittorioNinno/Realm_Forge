using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Clay Golem (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class ClayGolem2014Seeder
{
	public static Monster Build() => Create("clay-golem", null, CreatureSize.Large, CreatureType.Construct,
		14, 133, "14d10 + 56", 20, new[] { 20, 9, 18, 3, 8, 1 }, 9m, 5000, 4, 9,
		new Text(
			"Golem di argilla",
			null,
			"Costrutto Grande, senza allineamento",
			"14 (armatura naturale)",
			"6 m",
			"",
			"",
			"",
			"",
			"acido, psichici, veleno; contundenti, perforanti e taglienti da attacchi non magici non adamantini",
			"affascinato, avvelenato, indebolimento, paralizzato, pietrificato, spaventato",
			"Percezione passiva 9, scurovisione 18 m",
			"comprende i linguaggi del suo creatore ma non li sa parlare",
			"***Armi magiche.*** Gli attacchi con arma del golem sono magici.\n\n***Assorbimento dell'acido.*** Ogni volta che il golem riceve danni da acido, non subisce danni e anzi recupera un numero di punti ferita pari ai danni da acido inflitti.\n\n***Berserk.*** Ogni volta che il golem inizia il suo turno con 60 punti ferita o meno, si tira un d6. Con un risultato di 6, il golem entra in uno stato di berserk. A ogni suo turno, finché è in stato di berserk, il golem attacca la creatura visibile più vicina. Se nessuna creatura è abbastanza vicina per un attacco, il golem prende di mira un oggetto, prediligendone uno più piccolo di lui. Una volta che il golem è in stato di berserk, non si arresta finché non viene distrutto o non recupera tutti i suoi punti ferita.\n\n***Forma immutabile.*** Il golem è immune a qualsiasi incantesimo o effetto che ne altererebbe la forma.\n\n***Resistenza alla magia.*** Il golem dispone di vantaggio ai tiri salvezza contro incantesimi e altri effetti magici.",
			"***Multiattacco.*** Il golem effettua due attacchi con schianto.\n\n***Schianto.*** *Attacco con arma da mischia:* +8 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 16 (2d10 + 5) danni contundenti. Se il bersaglio è una creatura, deve superare un tiro salvezza su Costituzione con CD 15, altrimenti i suoi punti ferita massimi vengono ridotti di un importo pari ai danni inflitti. Il bersaglio muore se questo attacco riduce a 0 i suoi punti ferita massimi. La riduzione permane finché non viene rimossa da un incantesimo *ristorare superiore* o altre magie analoghe.\n\n***Velocità (ricarica 5–6).*** Fino alla fine del suo turno successivo, il golem ottiene magicamente un bonus di +2 alla CA, dispone di vantaggio ai tiri salvezza su Destrezza e può usare il suo attacco con schianto come azione bonus.",
			"",
			""),
		new Text(
			"Clay Golem",
			null,
			"Large construct, unaligned",
			"14 (natural armor)",
			"20 ft.",
			"",
			"",
			"",
			"",
			"acid, poison, psychic; bludgeoning, piercing, and slashing from nonmagical weapons that aren't adamantine",
			"charmed, exhaustion, frightened, paralyzed, petrified, poisoned",
			"darkvision 60 ft., passive Perception 9",
			"understands the languages of its creator but can't speak",
			"***Acid Absorption.*** Whenever the golem is subjected to acid damage, it takes no damage and instead regains a number of hit points equal to the acid damage dealt.\n\n***Berserk.*** Whenever the golem starts its turn with 60 hit points or fewer, roll a d6. On a 6, the golem goes berserk. On each of its turns while berserk, the golem attacks the nearest creature it can see. If no creature is near enough to move to and attack, the golem attacks an object, with preference for an object smaller than itself. Once the golem goes berserk, it continues to do so until it is destroyed or regains all its hit points.\n\n***Immutable Form.*** The golem is immune to any spell or effect that would alter its form.\n\n***Magic Resistance.*** The golem has advantage on saving throws against spells and other magical effects.\n\n***Magic Weapons.*** The golem's weapon attacks are magical.",
			"***Multiattack.*** The golem makes two slam attacks.\n\n***Slam.*** *Melee Weapon Attack:* +8 to hit, reach 5 ft., one target. *Hit:* 16 (2d10 + 5) bludgeoning damage. If the target is a creature, it must succeed on a DC 15 Constitution saving throw or have its hit point maximum reduced by an amount equal to the damage taken. The target dies if this attack reduces its hit point maximum to 0. The reduction lasts until removed by the greater restoration spell or other magic.\n\n***Haste (Recharge 5–6).*** Until the end of its next turn, the golem magically gains a +2 bonus to its AC, has advantage on Dexterity saving throws, and can use its slam attack as a bonus action.",
			"",
			""));
}
