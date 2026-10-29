using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Spectator (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class Spectator2014Seeder
{
	public static Monster Build() => Create("spectator", null, ContentSource.RealmForge, CreatureSize.Medium, CreatureType.Aberration,
		14, 39, "6d8 + 12", 0, new[] { 8, 14, 14, 13, 14, 11 }, 3m, 700, 2, 16,
		new Text(
			"Spectator",
			null,
			"Aberrazione Media, legale neutrale",
			"14 (armatura naturale)",
			"0 m, volare 9 m (fluttuare)",
			"",
			"Percezione +6",
			"",
			"",
			"",
			"prono",
			"Percezione passiva 16, scurovisione 36 m",
			"Gergo delle profondità, Sottocomune, telepatia 36 m",
			"",
			"***Morso.*** *Attacco con arma da mischia:* +1 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 2 (1d6 - 1) danni perforanti.\n\n***Raggi oculari.*** Lo spectator spara fino a due dei seguenti raggi oculari magici contro una o due creature che è in grado di vedere entro 27 metri da lui, usando ogni raggio al massimo una volta per turno:\n\n1. *Raggio confondente.* Il bersaglio effettua un tiro salvezza su Saggezza con CD 13. Se lo fallisce non può effettuare reazioni fino alla fine del suo turno successivo, e in quel turno non si muove e usa la sua azione per attaccare una creatura casuale entro la sua portata o gittata (se non può attaccare, non fa nulla).\n2. *Raggio paralizzante.* Il bersaglio effettua un tiro salvezza su Costituzione con CD 13, altrimenti è paralizzato per 1 minuto; ripete il tiro salvezza alla fine di ogni suo turno e l'effetto termina con un successo.\n3. *Raggio della paura.* Il bersaglio effettua un tiro salvezza su Saggezza con CD 13, altrimenti è spaventato per 1 minuto. Ripete il tiro salvezza alla fine di ogni suo turno, con svantaggio se può vedere lo spectator, e l'effetto termina con un successo.\n4. *Raggio ferente.* Il bersaglio effettua un tiro salvezza su Costituzione con CD 13 e subisce 16 (3d10) danni necrotici se lo fallisce, o la metà se lo supera.\n\n***Creare cibo e acqua.*** Lo spectator crea magicamente cibo e acqua sufficienti a sostentarsi per 24 ore.",
			"",
			"***Riflettere incantesimi.*** Quando lo spectator supera un tiro salvezza contro un incantesimo, o un attacco con incantesimo lo manca, può deviare l'incantesimo su un'altra creatura che è in grado di vedere entro 9 metri da lui (incantatore compreso). Se l'incantesimo richiedeva un tiro salvezza, il nuovo bersaglio effettua il proprio; se era un attacco, il tiro per colpire viene ripetuto contro il nuovo bersaglio.",
			"",
			""),
		new Text(
			"Spectator",
			null,
			"Medium aberration, lawful neutral",
			"14 (natural armor)",
			"0 ft., fly 30 ft. (hover)",
			"",
			"Perception +6",
			"",
			"",
			"",
			"prone",
			"darkvision 120 ft., passive Perception 16",
			"Deep Speech, Undercommon, telepathy 120 ft.",
			"",
			"***Bite.*** *Melee Weapon Attack:* +1 to hit, reach 5 ft., one target. *Hit:* 2 (1d6 - 1) piercing damage.\n\n***Eye Rays.*** The spectator fires up to two of the following magical eye rays at one or two creatures it can see within 90 feet of it, using each ray at most once per turn:\n\n1. *Confusion Ray.* The target makes a DC 13 Wisdom saving throw. On a failure it can't take reactions until the end of its next turn, and on that turn it doesn't move and uses its action to attack a random creature within its reach or range (if it can't attack, it does nothing).\n2. *Paralyzing Ray.* The target makes a DC 13 Constitution saving throw or is paralyzed for 1 minute, repeating the save at the end of each of its turns and ending the effect on a success.\n3. *Fear Ray.* The target makes a DC 13 Wisdom saving throw or is frightened for 1 minute. It repeats the save at the end of each of its turns, with disadvantage if it can see the spectator, ending the effect on a success.\n4. *Wounding Ray.* The target makes a DC 13 Constitution saving throw, taking 16 (3d10) necrotic damage on a failure, or half as much on a success.\n\n***Create Food and Water.*** The spectator magically conjures enough food and water to keep itself going for 24 hours.",
			"",
			"***Spell Reflection.*** When the spectator succeeds on a saving throw against a spell, or a spell attack misses it, it can redirect the spell to another creature it can see within 30 feet of it (the caster included). A spell that called for a save asks the new target to make its own; a spell attack is rolled again against the new target.",
			"",
			""));
}
