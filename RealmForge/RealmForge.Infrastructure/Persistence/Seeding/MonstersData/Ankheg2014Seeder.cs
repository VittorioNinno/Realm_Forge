using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Ankheg (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Ankheg2014Seeder
{
	public static Monster Build() => Create("ankheg", null, CreatureSize.Large, CreatureType.Monstrosity,
		14, 39, "6d10 + 6", 30, new[] { 17, 11, 13, 1, 13, 6 }, 2m, 450, 2, 11,
		new Text(
			"Ankheg",
			null,
			"Mostruosità Grande, senza allineamento",
			"14 (armatura naturale), 11 se prono",
			"9 m, scavare 3 m",
			"",
			"",
			"",
			"",
			"",
			"",
			"Percezione passiva 11, percezione tellurica 18 m, scurovisione 18 m",
			"—",
			"",
			"***Morso.*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 10 (2d6 + 3) danni taglienti più 3 (1d6) danni da acido. Se il bersaglio è una creatura di taglia Grande o inferiore, è afferrato (CD 13 per sfuggire). Finché la presa perdura, l'ankheg può mordere soltanto la creatura afferrata e dispone di vantaggio ai tiri per colpire per farlo.\n\n***Spruzzo acido (ricarica 6).*** L'ankheg sputa acido in una linea lunga 9 metri e larga 1,5 metri, purché non abbia afferrato alcuna creatura. Ogni creatura su quella linea deve effettuare un tiro salvezza su Destrezza con CD 13, subendo 10 (3d6) danni da acido in caso di fallimento, o la metà dei danni in caso di successo.",
			"",
			""),
		new Text(
			"Ankheg",
			null,
			"Large monstrosity, unaligned",
			"14 (natural armor), 11 while prone",
			"30 ft., burrow 10 ft.",
			"",
			"",
			"",
			"",
			"",
			"",
			"darkvision 60 ft., tremorsense 60 ft., passive Perception 11",
			"—",
			"",
			"***Bite.*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one target. *Hit:* 10 (2d6 + 3) slashing damage plus 3 (1d6) acid damage. If the target is a Large or smaller creature, it is grappled (escape DC 13). Until this grapple ends, the ankheg can bite only the grappled creature and has advantage on attack rolls to do so.\n\n***Acid Spray (Recharge 6).*** The ankheg spits acid in a line that is 30 ft. long and 5 ft. wide, provided that it has no creature grappled. Each creature in that line must make a DC 13 Dexterity saving throw, taking 10 (3d6) acid damage on a failed save, or half as much damage on a successful one.",
			"",
			""));
}
