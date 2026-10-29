using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Wraith (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Wraith2014Seeder
{
	public static Monster Build() => Create("wraith", null, CreatureSize.Medium, CreatureType.Undead,
		13, 67, "9d8 + 27", 0, new[] { 6, 16, 16, 12, 14, 15 }, 5m, 1800, 3, 12,
		new Text(
			"Wraith",
			null,
			"Non morto Medio, neutrale malvagio",
			"13",
			"0 m, volare 18 m (fluttuare)",
			"",
			"",
			"",
			"acido, freddo, fulmine, fuoco, tuono; contundenti, perforanti e taglienti da attacchi non magici con armi non argentate",
			"necrotici, veleno",
			"affascinato, afferrato, avvelenato, indebolimento, paralizzato, pietrificato, prono, trattenuto",
			"Percezione passiva 12, scurovisione 18 m",
			"quelli conosciuti in vita",
			"***Movimento incorporeo.*** Il wraith può muoversi attraverso altre creature e oggetti come se fossero terreno difficile. Subisce 5 (1d10) danni da forza se termina il proprio turno all'interno di un oggetto.\n\n***Sensibilità al sole.*** Finché è esposto alla luce del sole, il wraith subisce svantaggio ai tiri per colpire, oltre che alle prove di Saggezza (Percezione) basate sulla vista.",
			"***Risucchio di vita.*** *Attacco con arma da mischia:* +6 al tiro per colpire, portata 1,5 m, una creatura. *Colpito:* 21 (4d8 + 3) danni necrotici. Il bersaglio deve superare un tiro salvezza su Costituzione con CD 14, o i suoi punti ferita massimi vengono ridotti di un importo pari al danno subito. Questa riduzione dura finché il bersaglio non completa un riposo lungo. Il bersaglio muore se questo effetto riduce a 0 i suoi punti ferita massimi.\n\n***Creare spettro.*** Il wraith bersaglia un umanoide situato entro 3 metri da lui, che non abbia perso la vita da più di 1 minuto e che sia morto di morte violenta. Lo spirito del bersaglio si anima come spettro nello spazio del suo cadavere o nello spazio libero più vicino. Lo spettro è sotto il controllo del wraith. Il wraith non può controllare più di sette spettri simultaneamente.",
			"",
			""),
		new Text(
			"Wraith",
			null,
			"Medium undead, neutral evil",
			"13",
			"0 ft., fly 60 ft. (hover)",
			"",
			"",
			"",
			"acid, cold, fire, lightning, thunder; bludgeoning, piercing, and slashing from nonmagical weapons that aren't silvered",
			"necrotic, poison",
			"charmed, exhaustion, grappled, paralyzed, petrified, poisoned, prone, restrained",
			"darkvision 60 ft., passive Perception 12",
			"the languages it knew in life",
			"***Incorporeal Movement.*** The wraith can move through other creatures and objects as if they were difficult terrain. It takes 5 (1d10) force damage if it ends its turn inside an object.\n\n***Sunlight Sensitivity.*** While in sunlight, the wraith has disadvantage on attack rolls, as well as on Wisdom (Perception) checks that rely on sight.",
			"***Life Drain.*** *Melee Weapon Attack:* +6 to hit, reach 5 ft., one creature. *Hit:* 21 (4d8 + 3) necrotic damage. The target must succeed on a DC 14 Constitution saving throw or its hit point maximum is reduced by an amount equal to the damage taken. This reduction lasts until the target finishes a long rest. The target dies if this effect reduces its hit point maximum to 0.\n\n***Create Specter.*** The wraith targets a humanoid within 10 feet of it that has been dead for no longer than 1 minute and died violently. The target's spirit rises as a specter in the space of its corpse or in the nearest unoccupied space. The specter is under the wraith's control. The wraith can have no more than seven specters under its control at one time.",
			"",
			""));
}
