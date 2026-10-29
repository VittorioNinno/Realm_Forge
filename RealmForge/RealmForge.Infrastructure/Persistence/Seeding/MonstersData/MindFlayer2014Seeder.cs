using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Mind Flayer (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class MindFlayer2014Seeder
{
	public static Monster Build() => Create("mind-flayer", null, ContentSource.RealmForge, CreatureSize.Medium, CreatureType.Aberration,
		15, 71, "13d8 + 13", 30, new[] { 11, 12, 12, 19, 17, 17 }, 7m, 2900, 3, 16,
		new Text(
			"Mind flayer",
			null,
			"Aberrazione Media, legale malvagio",
			"15 (corazza di piastre)",
			"9 m",
			"Car +6, Int +7, Sag +6",
			"Arcano +7, Furtività +4, Inganno +6, Intuizione +6, Percezione +6, Persuasione +6",
			"",
			"",
			"",
			"",
			"Percezione passiva 16, scurovisione 36 m",
			"Gergo delle profondità, Sottocomune, telepatia 36 m",
			"***Resistenza alla magia.*** Il mind flayer dispone di vantaggio ai tiri salvezza contro incantesimi e altri effetti magici.\n\n***Incantesimi innati (psionici).*** Il mind flayer lancia per natura gli incantesimi seguenti usando l'Intelligenza (CD del tiro salvezza sull'incantesimo 15), senza bisogno di componenti:\n\n- A volontà: *individuazione dei pensieri*, *levitazione*\n- 1/giorno ciascuno: *dominare mostri*, *spostamento planare* (solo su se stesso)",
			"***Tentacoli.*** *Attacco con arma da mischia:* +7 al tiro per colpire, portata 1,5 m, una creatura. *Colpito:* 15 (2d10 + 4) danni psichici. Un bersaglio di taglia Media o inferiore è afferrato (CD 15 per sfuggire) ed effettua un tiro salvezza su Intelligenza con CD 15, altrimenti è stordito finché dura la presa.\n\n***Estrarre cervello.*** *Attacco con arma da mischia:* +7 al tiro per colpire, portata 1,5 m, un umanoide incapacitato afferrato dal mind flayer. *Colpito:* 55 (10d10) danni perforanti. Se questi danni portano il bersaglio a 0 punti ferita, il mind flayer lo uccide estraendone e divorandone il cervello.\n\n***Esplosione mentale (ricarica 5–6).*** Il mind flayer sprigiona magicamente energia psichica in un cono di 18 metri. Ogni creatura nel cono effettua un tiro salvezza su Intelligenza con CD 15, altrimenti subisce 22 (4d8 + 4) danni psichici ed è stordita per 1 minuto; ripete il tiro salvezza alla fine di ogni suo turno e l'effetto termina con un successo.",
			"",
			"",
			"",
			""),
		new Text(
			"Mind Flayer",
			null,
			"Medium aberration, lawful evil",
			"15 (breastplate)",
			"30 ft.",
			"Int +7, Wis +6, Cha +6",
			"Arcana +7, Deception +6, Insight +6, Perception +6, Persuasion +6, Stealth +4",
			"",
			"",
			"",
			"",
			"darkvision 120 ft., passive Perception 16",
			"Deep Speech, Undercommon, telepathy 120 ft.",
			"***Magic Resistance.*** The mind flayer has advantage on saving throws against spells and other magical effects.\n\n***Innate Spellcasting (Psionics).*** The mind flayer casts the following spells innately, using Intelligence (spell save DC 15) and needing no components:\n\n- At will: *detect thoughts*, *levitate*\n- 1/day each: *dominate monster*, *plane shift* (self only)",
			"***Tentacles.*** *Melee Weapon Attack:* +7 to hit, reach 5 ft., one creature. *Hit:* 15 (2d10 + 4) psychic damage. A Medium or smaller target is grappled (escape DC 15) and makes a DC 15 Intelligence saving throw or is stunned until the grapple ends.\n\n***Extract Brain.*** *Melee Weapon Attack:* +7 to hit, reach 5 ft., one incapacitated humanoid grappled by the mind flayer. *Hit:* 55 (10d10) piercing damage. If this drops the target to 0 hit points, the mind flayer kills it by pulling out and eating its brain.\n\n***Mind Blast (Recharge 5–6).*** The mind flayer magically releases psychic energy in a 60-foot cone. Each creature in the cone makes a DC 15 Intelligence saving throw or takes 22 (4d8 + 4) psychic damage and is stunned for 1 minute, repeating the save at the end of each of its turns and ending the effect on a success.",
			"",
			"",
			"",
			""));
}
