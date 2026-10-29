using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Imp (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Imp2014Seeder
{
	public static Monster Build() => Create("imp", null, CreatureSize.Tiny, CreatureType.Fiend,
		13, 10, "3d4 + 3", 20, new[] { 6, 17, 13, 11, 12, 14 }, 1m, 200, 2, 11,
		new Text(
			"Imp",
			null,
			"Immondo Minuscolo (diavolo, mutaforma), legale malvagio",
			"13",
			"6 m, volare 12 m",
			"",
			"Furtività +5, Inganno +4, Intuizione +3, Persuasione +4",
			"",
			"freddo; contundenti, perforanti e taglienti da attacchi non magici non argentati",
			"fuoco, veleno",
			"avvelenato",
			"Percezione passiva 11, scurovisione 36 m",
			"Comune, Infernale",
			"***Mutaforma.*** L'imp può usare la sua azione per assumere la forma bestiale di un topo (velocità 6 m), un corvo (6 m, volare 18 m), un ragno (6 m, scalare 6 m) o riassumere la sua vera forma. Le sue statistiche restano le stesse in ogni forma, a eccezione dei cambiamenti di velocità menzionati. Ogni oggetto che indossa o trasporta non viene trasformato. Se muore, torna alla sua forma naturale.\n\n***Resistenza alla magia.*** L'imp dispone di vantaggio ai tiri salvezza contro incantesimi e altri effetti magici.\n\n***Vista del diavolo.*** L'oscurità magica non ostacola la scurovisione dell'imp.",
			"***Pungiglione (morso in forma bestiale).*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 5 (1d4 + 3) danni perforanti e il bersaglio deve effettuare un tiro salvezza su Costituzione con CD 11. Subisce 10 (3d6) danni da veleno in caso di fallimento, o la metà dei danni in caso di successo.\n\n***Invisibilità.*** L'imp diventa magicamente invisibile finché non attacca o finché non perde la concentrazione (come se si concentrasse su un incantesimo). Ogni oggetto che l'imp indossa o trasporta diventa invisibile insieme a lui.",
			"",
			""),
		new Text(
			"Imp",
			null,
			"Tiny fiend (devil), lawful evil",
			"13",
			"20 ft., fly 40 ft.",
			"",
			"Deception +4, Insight +3, Persuasion +4, Stealth +5",
			"",
			"cold; bludgeoning, piercing, and slashing from nonmagical weapons that aren't silvered",
			"fire, poison",
			"poisoned",
			"darkvision 120 ft., passive Perception 11",
			"Infernal, Common",
			"***Shapechanger.*** The imp can use its action to polymorph into a beast form that resembles a rat (speed 20 ft.), a raven (20 ft., fly 60 ft.), or a spider (20 ft., climb 20 ft.), or back into its true form. Its statistics are the same in each form, except for the speed changes noted. Any equipment it is wearing or carrying isn't transformed. It reverts to its true form if it dies.\n\n***Devil's Sight.*** Magical darkness doesn't impede the imp's darkvision.\n\n***Magic Resistance.*** The imp has advantage on saving throws against spells and other magical effects.",
			"***Sting (Bite in Beast Form).*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one target. *Hit:* 5 (1d4 + 3) piercing damage, and the target must make on a DC 11 Constitution saving throw, taking 10 (3d6) poison damage on a failed save, or half as much damage on a successful one.\n\n***Invisibility.*** The imp magically turns invisible until it attacks, or until its concentration ends (as if concentrating on a spell). Any equipment the imp wears or carries is invisible with it.",
			"",
			""));
}
