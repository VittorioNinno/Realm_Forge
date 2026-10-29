using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Specter (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Specter2014Seeder
{
	public static Monster Build() => Create("specter", null, ContentSource.Srd51, CreatureSize.Medium, CreatureType.Undead,
		12, 22, "5d8", 0, new[] { 1, 14, 11, 10, 10, 11 }, 1m, 200, 2, 10,
		new Text(
			"Spettro",
			null,
			"Non morto Medio, caotico malvagio",
			"12",
			"0 m, volare 15 m (fluttuare)",
			"",
			"",
			"",
			"acido, freddo, fuoco, fulmine, tuono; contundenti, perforanti e taglienti da attacchi non magici",
			"necrotici, veleno",
			"affascinato, afferrato, avvelenato, indebolimento, paralizzato, pietrificato, privo di sensi, prono, trattenuto",
			"Percezione passiva 10, scurovisione 18 m",
			"capisce quelli che conosceva in vita, ma non è in grado di parlarli",
			"***Movimento incorporeo.*** Lo spettro può muoversi attraverso altre creature e oggetti come se fossero terreno difficile. Subisce 5 (1d10) danni da forza se termina il proprio turno all'interno di un oggetto.\n\n***Sensibilità al sole.*** Finché è esposto alla luce del sole, lo spettro subisce svantaggio ai tiri per colpire, oltre che alle prove di Saggezza (Percezione) basate sulla vista.",
			"***Risucchio di vita.*** *Attacco in mischia con incantesimo:* +4 al tiro per colpire, portata 1,5 m, una creatura. *Colpito:* 10 (3d6) danni necrotici. Il bersaglio deve superare un tiro salvezza su Costituzione con CD 10, o i suoi punti ferita massimi vengono ridotti di un importo pari al danno subito. Tale riduzione perdura finché la creatura non termina un riposo lungo. Il bersaglio muore se questo effetto riduce a 0 i suoi punti ferita massimi.",
			"",
			"",
			"",
			""),
		new Text(
			"Specter",
			null,
			"Medium undead, chaotic evil",
			"12",
			"0 ft., fly 50 ft. (hover)",
			"",
			"",
			"",
			"acid, cold, fire, lightning, thunder; bludgeoning, piercing, and slashing from nonmagical weapons",
			"necrotic, poison",
			"charmed, exhaustion, grappled, paralyzed, petrified, poisoned, prone, restrained, unconscious",
			"darkvision 60 ft., passive Perception 10",
			"understands all languages it knew in life but can't speak",
			"***Incorporeal Movement.*** The specter can move through other creatures and objects as if they were difficult terrain. It takes 5 (1d10) force damage if it ends its turn inside an object.\n\n***Sunlight Sensitivity.*** While in sunlight, the specter has disadvantage on attack rolls, as well as on Wisdom (Perception) checks that rely on sight.",
			"***Life Drain.*** *Melee Spell Attack:* +4 to hit, reach 5 ft., one creature. *Hit:* 10 (3d6) necrotic damage. The target must succeed on a DC 10 Constitution saving throw or its hit point maximum is reduced by an amount equal to the damage taken. This reduction lasts until the creature finishes a long rest. The target dies if this effect reduces its hit point maximum to 0.",
			"",
			"",
			"",
			""));
}
