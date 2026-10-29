using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Beholder Zombie (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class BeholderZombie2014Seeder
{
	public static Monster Build() => Create("beholder-zombie", null, ContentSource.RealmForge, CreatureSize.Large, CreatureType.Undead,
		15, 93, "11d10 + 33", 0, new[] { 10, 8, 16, 3, 8, 5 }, 5m, 1800, 3, 9,
		new Text(
			"Zombi beholder",
			null,
			"Non morto Grande, neutrale malvagio",
			"15 (armatura naturale)",
			"0 m, volare 6 m (fluttuare)",
			"Sag +2",
			"",
			"",
			"",
			"veleno",
			"avvelenato",
			"Percezione passiva 9, scurovisione 18 m",
			"capisce il Gergo delle profondità e il Sottocomune ma non li parla",
			"***Tempra non morta.*** Se i danni riducono lo zombi a 0 punti ferita, effettua un tiro salvezza su Costituzione con CD pari a 5 + i danni subiti, a meno che i danni non siano radiosi o inflitti da un colpo critico. Se lo supera, lo zombi scende invece a 1 punto ferita.",
			"***Morso.*** *Attacco con arma da mischia:* +3 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 14 (4d6) danni perforanti.\n\n***Raggio oculare.*** Lo zombi spara un raggio oculare magico casuale (tirare un d4) contro un bersaglio che è in grado di vedere entro 18 metri da lui.\n\n1. *Raggio paralizzante.* La creatura effettua un tiro salvezza su Costituzione con CD 14, altrimenti è paralizzata per 1 minuto; ripete il tiro salvezza alla fine di ogni suo turno e l'effetto termina con un successo.\n2. *Raggio della paura.* La creatura effettua un tiro salvezza su Saggezza con CD 14, altrimenti è spaventata per 1 minuto; ripete il tiro salvezza alla fine di ogni suo turno e l'effetto termina con un successo.\n3. *Raggio di snervamento.* La creatura effettua un tiro salvezza su Costituzione con CD 14 e subisce 36 (8d8) danni necrotici se lo fallisce, o la metà di quei danni se lo supera.\n4. *Raggio disintegrante.* Una creatura effettua un tiro salvezza su Destrezza con CD 14, altrimenti subisce 45 (10d8) danni da forza e, se questi la portano a 0 punti ferita, si riduce a un mucchietto di polvere grigia. Un oggetto non magico o una creazione di forza magica di taglia Grande o inferiore viene disintegrato senza tiro salvezza; se è più grande, il raggio ne disintegra un cubo di 3 metri di lato.",
			"",
			"",
			"",
			"Uno zombi beholder è il guscio rianimato di un beholder morto; conserva solo alcuni dei suoi raggi oculari e nulla dell'astuzia che lo rendeva pericoloso in vita."),
		new Text(
			"Beholder Zombie",
			null,
			"Large undead, neutral evil",
			"15 (natural armor)",
			"0 ft., fly 20 ft. (hover)",
			"Wis +2",
			"",
			"",
			"",
			"poison",
			"poisoned",
			"darkvision 60 ft., passive Perception 9",
			"understands Deep Speech and Undercommon but can't speak",
			"***Undead Fortitude.*** If damage reduces the zombie to 0 hit points, it makes a Constitution saving throw with a DC of 5 + the damage taken, unless the damage is radiant or from a critical hit. On a success, the zombie drops to 1 hit point instead.",
			"***Bite.*** *Melee Weapon Attack:* +3 to hit, reach 5 ft., one target. *Hit:* 14 (4d6) piercing damage.\n\n***Eye Ray.*** The zombie fires a random magical eye ray (roll a d4) at a target it can see within 60 feet of it.\n\n1. *Paralyzing Ray.* The creature makes a DC 14 Constitution saving throw or is paralyzed for 1 minute, repeating the save at the end of each of its turns and ending the effect on a success.\n2. *Fear Ray.* The creature makes a DC 14 Wisdom saving throw or is frightened for 1 minute, repeating the save at the end of each of its turns and ending the effect on a success.\n3. *Enervation Ray.* The creature makes a DC 14 Constitution saving throw, taking 36 (8d8) necrotic damage on a failure or half as much on a success.\n4. *Disintegration Ray.* A creature makes a DC 14 Dexterity saving throw or takes 45 (10d8) force damage, and is reduced to fine gray dust if this drops it to 0 hit points. A Large or smaller nonmagical object or creation of magical force is disintegrated with no save; against a larger one, the ray disintegrates a 10-foot cube of it.",
			"",
			"",
			"",
			"A beholder zombie is the animated husk of a dead beholder; it keeps only a few of its eye rays and none of the cunning that made it dangerous in life."));
}
