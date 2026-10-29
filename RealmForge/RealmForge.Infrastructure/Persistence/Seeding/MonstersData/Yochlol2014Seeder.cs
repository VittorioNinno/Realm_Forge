using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Yochlol (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class Yochlol2014Seeder
{
	public static Monster Build() => Create("yochlol", null, ContentSource.RealmForge, CreatureSize.Medium, CreatureType.Fiend,
		15, 136, "16d8 + 64", 30, new[] { 15, 14, 18, 13, 15, 15 }, 10m, 5900, 4, 12,
		new Text(
			"Yochlol",
			null,
			"Immondo Medio (demone, mutaforma), caotico malvagio",
			"15 (armatura naturale)",
			"9 m, scalare 9 m",
			"Car +6, Des +6, Int +5, Sag +6",
			"Inganno +10, Intuizione +6",
			"",
			"freddo, fuoco, fulmine; contundenti, perforanti e taglienti da attacchi non magici",
			"veleno",
			"avvelenato",
			"Percezione passiva 12, scurovisione 36 m",
			"Abissale, Elfico, Sottocomune",
			"***Mutaforma.*** Con un'azione, lo yochlol può assumere l'aspetto di una femmina drow o di un ragno gigante, o tornare alla sua vera forma. Le sue statistiche non cambiano e ciò che indossa o trasporta non si trasforma. Quando muore torna alla sua vera forma.\n\n***Resistenza alla magia.*** Lo yochlol dispone di vantaggio ai tiri salvezza contro incantesimi e altri effetti magici.\n\n***Movimenti del ragno.*** Lo yochlol può scalare superfici difficili, soffitti compresi (a testa in giù), senza effettuare prove di caratteristica.\n\n***Incantesimi innati.*** Lo yochlol lancia per natura gli incantesimi seguenti usando il Carisma (CD del tiro salvezza sull'incantesimo 14), senza bisogno di componenti materiali:\n\n- A volontà: *individuazione dei pensieri*, *ragnatela*\n- 1/giorno: *dominare persone*\n\n***Camminare sulle ragnatele.*** Le ragnatele non ostacolano il movimento dello yochlol.",
			"***Multiattacco.*** Lo yochlol effettua due attacchi in mischia.\n\n***Schianto (morso in forma di ragno).*** *Attacco con arma da mischia:* +6 al tiro per colpire, portata 1,5 m (3 m in forma demoniaca), un bersaglio. *Colpito:* 5 (1d6 + 2) danni contundenti (perforanti in forma di ragno) più 21 (6d6) danni da veleno.\n\n***Forma di nebbia.*** Lo yochlol si trasforma in una nebbia velenosa, o torna alla sua vera forma; ciò che indossa o trasporta si trasforma con lui, e quando muore torna alla sua vera forma.\n\nIn forma di nebbia lo yochlol è incapacitato e non può parlare; ha velocità di volare 9 metri, può fluttuare, passa attraverso qualsiasi spazio non ermetico, dispone di vantaggio ai tiri salvezza su Forza, Destrezza e Costituzione ed è immune ai danni non magici. Può anche entrare nello spazio di una creatura e fermarvisi: ogni volta che quella creatura inizia il turno nello stesso spazio dello yochlol, effettua un tiro salvezza su Costituzione con CD 14, altrimenti è avvelenata, e incapacitata, fino all'inizio del suo turno successivo.",
			"",
			"",
			"",
			""),
		new Text(
			"Yochlol",
			null,
			"Medium fiend (demon, shapechanger), chaotic evil",
			"15 (natural armor)",
			"30 ft., climb 30 ft.",
			"Dex +6, Int +5, Wis +6, Cha +6",
			"Deception +10, Insight +6",
			"",
			"cold, fire, lightning; bludgeoning, piercing, and slashing from nonmagical attacks",
			"poison",
			"poisoned",
			"darkvision 120 ft., passive Perception 12",
			"Abyssal, Elvish, Undercommon",
			"***Shapechanger.*** As an action, the yochlol can take the shape of a female drow or of a giant spider, or return to its true form. Its statistics don't change, and what it wears or carries isn't transformed. It returns to its true form when it dies.\n\n***Magic Resistance.*** The yochlol has advantage on saving throws against spells and other magical effects.\n\n***Spider Climb.*** The yochlol can climb difficult surfaces, ceilings included (upside down), without making an ability check.\n\n***Innate Spellcasting.*** The yochlol casts the following spells innately, using Charisma (spell save DC 14) and needing no material components:\n\n- At will: *detect thoughts*, *web*\n- 1/day: *dominate person*\n\n***Web Walker.*** Webbing doesn't hinder the yochlol's movement.",
			"***Multiattack.*** The yochlol makes two melee attacks.\n\n***Slam (Bite in Spider Form).*** *Melee Weapon Attack:* +6 to hit, reach 5 ft. (10 ft. in demon form), one target. *Hit:* 5 (1d6 + 2) bludgeoning damage (piercing in spider form) plus 21 (6d6) poison damage.\n\n***Mist Form.*** The yochlol becomes a poisonous mist, or returns to its true form; what it wears or carries changes with it, and it returns to its true form when it dies.\n\nAs mist, the yochlol is incapacitated and can't speak; it has a flying speed of 30 feet, can hover, slips through any space that isn't airtight, has advantage on Strength, Dexterity and Constitution saving throws, and is immune to nonmagical damage. It can also move into a creature's space and stay there: each time that creature starts its turn sharing its space with the yochlol, it makes a DC 14 Constitution saving throw or is poisoned, and incapacitated, until the start of its next turn.",
			"",
			"",
			"",
			""));
}
