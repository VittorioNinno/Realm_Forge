using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Mummy (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Mummy2014Seeder
{
	public static Monster Build() => Create("mummy", null, ContentSource.Srd51, CreatureSize.Medium, CreatureType.Undead,
		11, 58, "9d8 + 18", 20, new[] { 16, 8, 15, 6, 10, 12 }, 3m, 700, 2, 10,
		new Text(
			"Mummia",
			null,
			"Non morto Medio, legale malvagia",
			"11 (armatura naturale)",
			"6 m",
			"Sag +2",
			"",
			"fuoco",
			"contundenti, perforanti e taglienti da attacchi non magici",
			"necrotici, veleno",
			"affascinato, avvelenato, indebolimento, paralizzato, spaventato",
			"Percezione passiva 10, scurovisione 18 m",
			"quelli conosciuti in vita",
			"",
			"***Multiattacco.*** La mummia può usare lo sguardo funesto ed effettuare un attacco con il pugno di putrefazione.\n\n***Pugno di putrefazione.*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 10 (2d6 + 3) danni contundenti più 10 (3d6) danni necrotici. Se il bersaglio è una creatura, deve superare un tiro salvezza su Costituzione con CD 12, altrimenti è maledetto dalla putrefazione della mummia. In tal caso, non può riguadagnare punti ferita e i suoi punti ferita massimi diminuiscono di 10 (3d6) ogni 24 ore trascorse. Se la maledizione riduce i punti ferita massimi del bersaglio a 0, quest'ultimo muore e il suo corpo si trasforma in polvere. La maledizione permane finché non viene rimossa da un incantesimo *rimuovi maledizione* o da una magia analoga.\n\n***Sguardo funesto.*** La mummia prende di mira una creatura nel suo campo visivo in un raggio di 18 metri. Se il bersaglio può vedere la mummia, deve superare un tiro salvezza su Saggezza con CD 11 contro questa magia, altrimenti è spaventato fino alla fine del turno successivo della mummia. Se il bersaglio fallisce il tiro salvezza di 5 o più, è anche paralizzato per la stessa durata. Un bersaglio che supera il tiro salvezza è immune allo sguardo funesto di tutte le mummie (ma non a quello dei signori delle mummie) per le 24 ore successive.",
			"",
			"",
			"",
			""),
		new Text(
			"Mummy",
			null,
			"Medium undead, lawful evil",
			"11 (natural armor)",
			"20 ft.",
			"Wis +2",
			"",
			"fire",
			"bludgeoning, piercing, and slashing from nonmagical weapons",
			"necrotic, poison",
			"charmed, exhaustion, frightened, paralyzed, poisoned",
			"darkvision 60 ft., passive Perception 10",
			"the languages it knew in life",
			"",
			"***Multiattack.*** The mummy can use its Dreadful Glare and makes one attack with its rotting fist.\n\n***Rotting Fist.*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one target. *Hit:* 10 (2d6 + 3) bludgeoning damage plus 10 (3d6) necrotic damage. If the target is a creature, it must succeed on a DC 12 Constitution saving throw or be cursed with mummy rot. The cursed target can't regain hit points, and its hit point maximum decreases by 10 (3d6) for every 24 hours that elapse. If the curse reduces the target's hit point maximum to 0, the target dies, and its body turns to dust. The curse lasts until removed by the remove curse spell or other magic.\n\n***Dreadful Glare.*** The mummy targets one creature it can see within 60 ft. of it. If the target can see the mummy, it must succeed on a DC 11 Wisdom saving throw against this magic or become frightened until the end of the mummy's next turn. If the target fails the saving throw by 5 or more, it is also paralyzed for the same duration. A target that succeeds on the saving throw is immune to the Dreadful Glare of all mummies (but not mummy lords) for the next 24 hours.",
			"",
			"",
			"",
			""));
}
