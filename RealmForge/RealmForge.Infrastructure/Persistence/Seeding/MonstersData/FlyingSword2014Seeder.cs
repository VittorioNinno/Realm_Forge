using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Flying Sword (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class FlyingSword2014Seeder
{
	public static Monster Build() => Create("flying-sword", null, CreatureSize.Small, CreatureType.Construct,
		17, 17, "5d6", 0, new[] { 12, 15, 11, 1, 5, 1 }, 0.25m, 50, 2, 7,
		new Text(
			"Spada volante",
			null,
			"Costrutto Piccolo, senza allineamento",
			"17 (armatura naturale)",
			"0 m, volare 15 m (fluttuare)",
			"Des +4",
			"",
			"",
			"",
			"psichici, veleno",
			"accecato, affascinato, assordato, avvelenato, paralizzato, pietrificato, spaventato",
			"Percezione passiva 7, vista cieca 18 m (cecità oltre questo raggio)",
			"—",
			"***Falso aspetto.*** Finché la spada non vola e rimane immobile, non è distinguibile da una spada normale.\n\n***Suscettibilità all'anti-magia.*** La spada è incapacitata finché si trova nell'area di un *campo anti-magia.* Se bersagliata da un incantesimo *dissolvi magie,* la spada deve superare un tiro salvezza su Costituzione contro la CD del tiro salvezza sull'incantesimo, altrimenti è priva di sensi per 1 minuto.",
			"***Spada lunga.*** *Attacco con arma da mischia:* +3 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 5 (1d8 + 1) danni taglienti.",
			"",
			""),
		new Text(
			"Flying Sword",
			null,
			"Small construct, unaligned",
			"17 (natural armor)",
			"0 ft., fly 50 ft. (hover)",
			"Dex +4",
			"",
			"",
			"",
			"poison, psychic",
			"blinded, charmed, blinded, frightened, paralyzed, petrified, poisoned",
			"blindsight 60 ft. (blind beyond this radius), passive Perception 7",
			"—",
			"***Antimagic Susceptibility.*** The sword is incapacitated while in the area of an antimagic field. If targeted by dispel magic, the sword must succeed on a Constitution saving throw against the caster's spell save DC or fall unconscious for 1 minute.\n\n***False Appearance.*** While the sword remains motionless and isn't flying, it is indistinguishable from a normal sword.",
			"***Longsword.*** *Melee Weapon Attack:* +3 to hit, reach 5 ft., one target. *Hit:* 5 (1d8 + 1) slashing damage.",
			"",
			""));
}
