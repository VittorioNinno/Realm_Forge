using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Bulette (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Bulette2014Seeder
{
	public static Monster Build() => Create("bulette", null, ContentSource.Srd51, CreatureSize.Large, CreatureType.Monstrosity,
		17, 94, "9d10 + 45", 40, new[] { 19, 11, 21, 2, 10, 5 }, 5m, 1800, 3, 16,
		new Text(
			"Bulette",
			null,
			"Mostruosità Grande, senza allineamento",
			"17 (armatura naturale)",
			"12 m, scavare 12 m",
			"",
			"Percezione +6",
			"",
			"",
			"",
			"",
			"Percezione passiva 16, percezione tellurica 18 m, scurovisione 18 m",
			"—",
			"***Balzo da fermo.*** Il bulette può compiere un salto in lungo di un massimo di 9 metri e un salto in alto di un massimo di 4,5 metri, con o senza rincorsa.",
			"***Morso.*** *Attacco con arma da mischia:* +7 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 30 (4d12 + 4) danni perforanti.\n\n***Balzo letale.Se*** il bulette salta di almeno 4,5 metri come parte del suo movimento, poi può usare questa azione per atterrare in piedi in uno spazio che contenga una o più creature oltre a lui. Ognuna di queste creature deve effettuare un tiro salvezza su Forza o Destrezza con CD 16 (a scelta del bersaglio); se lo fallisce, viene buttata a terra prona e subisce 14 (3d6 + 4) danni contundenti più 14 (3d6 + 4) danni taglienti. Se invece lo supera, subisce la metà di quei danni, non è buttata a terra prona e viene spinta di 1,5 metri fuori dallo spazio del bulette fino a uno spazio libero a scelta della creatura. Se non c'è alcuno spazio libero entro gittata, la creatura cade invece a terra prona nello spazio del bulette.",
			"",
			"",
			"",
			""),
		new Text(
			"Bulette",
			null,
			"Large monstrosity, unaligned",
			"17 (natural armor)",
			"40 ft., burrow 40 ft.",
			"",
			"Perception +6",
			"",
			"",
			"",
			"",
			"darkvision 60 ft., tremorsense 60 ft., passive Perception 16",
			"—",
			"***Standing Leap.*** The bulette's long jump is up to 30 ft. and its high jump is up to 15 ft., with or without a running start.",
			"***Bite.*** *Melee Weapon Attack:* +7 to hit, reach 5 ft., one target. *Hit:* 30 (4d12 + 4) piercing damage.\n\n***Deadly Leap.*** If the bulette jumps at least 15 ft. as part of its movement, it can then use this action to land on its feet in a space that contains one or more other creatures. Each of those creatures must succeed on a DC 16 Strength or Dexterity saving throw (target's choice) or be knocked prone and take 14 (3d6 + 4) bludgeoning damage plus 14 (3d6 + 4) slashing damage. On a successful save, the creature takes only half the damage, isn't knocked prone, and is pushed 5 ft. out of the bulette's space into an unoccupied space of the creature's choice. If no unoccupied space is within range, the creature instead falls prone in the bulette's space.",
			"",
			"",
			"",
			""));
}
