using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Quasit (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Quasit2014Seeder
{
	public static Monster Build() => Create("quasit", null, CreatureSize.Tiny, CreatureType.Fiend,
		13, 7, "3d4", 40, new[] { 5, 17, 10, 7, 10, 10 }, 1m, 200, 2, 10,
		new Text(
			"Quasit",
			null,
			"Immondo Minuscolo (demone, mutaforma), caotico malvagio",
			"13",
			"12 m",
			"",
			"Furtività +5",
			"",
			"freddo, fulmine, fuoco; contundenti, perforanti e taglienti da attacchi non magici",
			"veleno",
			"avvelenato",
			"Percezione passiva 10, scurovisione 36 m",
			"Abissale, Comune",
			"***Mutaforma.*** Il quasit può usare la sua azione per assumere la forma bestiale di un pipistrello (velocità 3 m, volare 12 m), di un millepiedi (12 m, scalare 12 m) o di un rospo (12 m, nuotare 12 m) oppure riassumere la sua vera forma. Le sue statistiche restano le stesse in ogni forma, a eccezione dei cambiamenti di velocità menzionati. Ogni oggetto che indossa o trasporta non viene trasformato. Se muore, torna alla sua forma naturale.\n\n***Resistenza alla magia.*** Il quasit dispone di vantaggio ai tiri salvezza contro incantesimi e altri effetti magici.",
			"***Artigli (morso in forma bestiale).*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 5 (1d4 + 3) danni perforanti e il bersaglio deve superare un tiro salvezza su Costituzione con CD 10, altrimenti subisce 5 (2d4) danni da veleno e diventa avvelenato per 1 minuto. Il bersaglio può ripetere il tiro salvezza alla fine di ogni suo turno e, se lo supera, l'effetto svanisce.\n\n***Invisibilità.*** Il quasit diventa magicamente invisibile finché non attacca, non usa Spaventare o finché non perde la concentrazione (come se si concentrasse su un incantesimo). Gli oggetti che il quasit indossa o trasporta diventano invisibili insieme a lui.\n\n***Spaventare (1/giorno).*** Una creatura a scelta del quasit e situata entro 6 metri da lui deve superare un tiro salvezza su Saggezza con CD 10, altrimenti è spaventata per 1 minuto. Il bersaglio può ripetere il tiro salvezza alla fine di ogni suo turno, subendo svantaggio se il quasit si trova entro il suo campo visivo: se il bersaglio lo supera, l'effetto svanisce.",
			"",
			""),
		new Text(
			"Quasit",
			null,
			"Tiny fiend (demon), chaotic evil",
			"13",
			"40 ft.",
			"",
			"Stealth +5",
			"",
			"cold, fire, lightning; bludgeoning, piercing, and slashing from nonmagical weapons",
			"poison",
			"poisoned",
			"darkvision 120 ft., passive Perception 10",
			"Abyssal, Common",
			"***Shapechanger.*** The quasit can use its action to polymorph into a beast form that resembles a bat (speed 10 ft. fly 40 ft.), a centipede (40 ft., climb 40 ft.), or a toad (40 ft., swim 40 ft.), or back into its true form . Its statistics are the same in each form, except for the speed changes noted. Any equipment it is wearing or carrying isn't transformed . It reverts to its true form if it dies.\n\n***Magic Resistance.*** The quasit has advantage on saving throws against spells and other magical effects.",
			"***Claw (Bite in Beast Form).*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one target. *Hit:* 5 (1d4 + 3) piercing damage, and the target must succeed on a DC 10 Constitution saving throw or take 5 (2d4) poison damage and become poisoned for 1 minute. The target can repeat the saving throw at the end of each of its turns, ending the effect on itself on a success.\n\n***Scare (1/Day).*** One creature of the quasit's choice within 20 ft. of it must succeed on a DC 10 Wisdom saving throw or be frightened for 1 minute. The target can repeat the saving throw at the end of each of its turns, with disadvantage if the quasit is within line of sight, ending the effect on itself on a success.\n\n***Invisibility.*** The quasit magically turns invisible until it attacks or uses Scare, or until its concentration ends (as if concentrating on a spell). Any equipment the quasit wears or carries is invisible with it.",
			"",
			""));
}
