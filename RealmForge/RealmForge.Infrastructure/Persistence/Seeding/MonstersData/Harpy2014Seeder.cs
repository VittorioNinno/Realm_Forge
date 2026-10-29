using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Harpy (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Harpy2014Seeder
{
	public static Monster Build() => Create("harpy", null, CreatureSize.Medium, CreatureType.Monstrosity,
		11, 38, "7d8 + 7", 20, new[] { 12, 13, 12, 7, 10, 13 }, 1m, 200, 2, 10,
		new Text(
			"Arpia",
			null,
			"Mostruosità Media, caotica malvagia",
			"11",
			"6 m, volare 12 m",
			"",
			"",
			"",
			"",
			"",
			"",
			"Percezione passiva 10",
			"Comune",
			"",
			"***Multiattacco.*** L'arpia effettua due attacchi: uno con gli artigli e uno con il randello.\n\n***Artigli.*** *Attacco con arma da mischia:* +3 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 6 (2d4 + 1) danni taglienti.\n\n***Randello.*** *Attacco con arma da mischia:* +3 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 3 (1d4 + 1) danni contundenti.\n\n***Canto seducente.*** L'arpia intona una melodia magica. Ogni umanoide e gigante situato entro 90 metri dall'arpia e che sia in grado di udire il canto deve superare un tiro salvezza su Saggezza con CD 11, altrimenti è affascinato finché il canto non termina. L'arpia deve effettuare un'azione bonus nei suoi turni successivi per continuare a cantare. Può smettere di cantare in qualsiasi momento. Se l'arpia è incapacitata, il canto termina. Finché è affascinato dall'arpia, il bersaglio è incapacitato e ignora i canti delle altre arpie. Se il bersaglio affascinato si trova a più di 1,5 metri di distanza dall'arpia, esso deve muoversi nel proprio turno verso l'arpia seguendo il percorso più diretto e cercando di giungere entro 1,5 metri. Il bersaglio non evita gli attacchi di opportunità, ma prima di muoversi su un terreno pericoloso (come per esempio un lago di lava o una fossa) e qualora subisca danni da una fonte diversa dall'arpia, può ripetere il tiro salvezza. Un bersaglio affascinato può ripetere il tiro salvezza alla fine di ogni suo turno. Se lo supera, l'effetto svanisce. Un bersaglio che supera il tiro salvezza è immune al canto di quest'arpia per le 24 ore successive.",
			"",
			""),
		new Text(
			"Harpy",
			null,
			"Medium monstrosity, chaotic evil",
			"11",
			"20 ft., fly 40 ft.",
			"",
			"",
			"",
			"",
			"",
			"",
			"passive Perception 10",
			"Common",
			"",
			"***Multiattack.*** The harpy makes two attacks: one with its claws and one with its club.\n\n***Claws.*** *Melee Weapon Attack:* +3 to hit, reach 5 ft., one target. *Hit:* 6 (2d4 + 1) slashing damage.\n\n***Club.*** *Melee Weapon Attack:* +3 to hit, reach 5 ft., one target. *Hit:* 3 (1d4 + 1) bludgeoning damage.\n\n***Luring Song.*** The harpy sings a magical melody. Every humanoid and giant within 300 ft. of the harpy that can hear the song must succeed on a DC 11 Wisdom saving throw or be charmed until the song ends. The harpy must take a bonus action on its subsequent turns to continue singing. It can stop singing at any time. The song ends if the harpy is incapacitated.\n\nWhile charmed by the harpy, a target is incapacitated and ignores the songs of other harpies. If the charmed target is more than 5 ft. away from the harpy, the must move on its turn toward the harpy by the most direct route. It doesn't avoid opportunity attacks, but before moving into damaging terrain, such as lava or a pit, and whenever it takes damage from a source other than the harpy, a target can repeat the saving throw. A creature can also repeat the saving throw at the end of each of its turns. If a creature's saving throw is successful, the effect ends on it.\nA target that successfully saves is immune to this harpy's song for the next 24 hours.",
			"",
			""));
}
