using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Yuan-ti Abomination (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class YuanTiAbomination2014Seeder
{
	public static Monster Build() => Create("yuan-ti-abomination", null, ContentSource.RealmForge, CreatureSize.Large, CreatureType.Monstrosity,
		15, 127, "15d10 + 45", 40, new[] { 19, 16, 17, 17, 15, 18 }, 7m, 2900, 3, 15,
		new Text(
			"Yuan-ti abominio",
			null,
			"Mostruosità Grande (mutaforma, yuan-ti), neutrale malvagio",
			"15 (armatura naturale)",
			"12 m",
			"",
			"Furtività +6, Percezione +5",
			"",
			"",
			"veleno",
			"avvelenato",
			"Percezione passiva 15, scurovisione 18 m",
			"Abissale, Comune, Draconico",
			"***Mutaforma.*** Con un'azione, lo yuan-ti può trasformarsi in un serpente Grande o tornare alla sua forma reale. Le sue statistiche restano invariate in entrambe le forme; ciò che indossa o trasporta non si trasforma, e non torna alla forma originale se muore.\n\n***Incantesimi innati (solo in forma di abominio).*** Lo yuan-ti lancia per natura gli incantesimi seguenti usando il Carisma (CD del tiro salvezza sull'incantesimo 15), senza bisogno di componenti materiali:\n\n- A volontà: *amicizia con gli animali* (solo serpenti)\n- 3/giorno: *suggestione*\n- 1/giorno: *paura*\n\n***Resistenza alla magia.*** Lo yuan-ti dispone di vantaggio ai tiri salvezza contro incantesimi e altri effetti magici.",
			"***Multiattacco.*** In forma di abominio, lo yuan-ti effettua due attacchi a distanza o tre in mischia, usando il morso e la stretta non più di una volta ciascuno.\n\n***Morso.*** *Attacco con arma da mischia:* +7 al tiro per colpire, portata 1,5 m, una creatura. *Colpito:* 7 (1d6 + 4) danni perforanti più 10 (3d6) danni da veleno.\n\n***Stritolare.*** *Attacco con arma da mischia:* +7 al tiro per colpire, portata 3 m, un bersaglio. *Colpito:* 11 (2d6 + 4) danni contundenti. Il bersaglio è afferrato (CD 14 per sfuggire); finché dura la presa è trattenuto e lo yuan-ti non può stritolare nessun altro.\n\n***Scimitarra (solo in forma di abominio).*** *Attacco con arma da mischia:* +7 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 11 (2d6 + 4) danni taglienti.\n\n***Arco lungo (solo in forma di abominio).*** *Attacco con arma a distanza:* +6 al tiro per colpire, gittata 45/180 m, un bersaglio. *Colpito:* 12 (2d8 + 3) danni perforanti più 10 (3d6) danni da veleno.",
			"",
			"",
			"",
			"Gli abomini sono la casta più alta degli yuan-ti: enormi serpenti con torso e braccia umani possenti, i più vicini alla forma voluta dalle loro divinità serpentine."),
		new Text(
			"Yuan-ti Abomination",
			null,
			"Large monstrosity (shapechanger, yuan-ti), neutral evil",
			"15 (natural armor)",
			"40 ft.",
			"",
			"Perception +5, Stealth +6",
			"",
			"",
			"poison",
			"poisoned",
			"darkvision 60 ft., passive Perception 15",
			"Abyssal, Common, Draconic",
			"***Shapechanger.*** As an action, the yuan-ti can polymorph into a Large snake or back into its true form. Its statistics stay the same in either form; what it wears or carries doesn't change, and it doesn't revert if it dies.\n\n***Innate Spellcasting (Abomination Form Only).*** The yuan-ti casts the following spells innately, using Charisma (spell save DC 15) and needing no material components:\n\n- At will: *animal friendship* (snakes only)\n- 3/day: *suggestion*\n- 1/day: *fear*\n\n***Magic Resistance.*** The yuan-ti has advantage on saving throws against spells and other magical effects.",
			"***Multiattack.*** In abomination form, the yuan-ti makes two ranged attacks or three melee attacks, using bite and constrict no more than once each.\n\n***Bite.*** *Melee Weapon Attack:* +7 to hit, reach 5 ft., one creature. *Hit:* 7 (1d6 + 4) piercing damage plus 10 (3d6) poison damage.\n\n***Constrict.*** *Melee Weapon Attack:* +7 to hit, reach 10 ft., one target. *Hit:* 11 (2d6 + 4) bludgeoning damage. The target is grappled (escape DC 14); while the grapple lasts, it is restrained and the yuan-ti can't constrict anyone else.\n\n***Scimitar (Abomination Form Only).*** *Melee Weapon Attack:* +7 to hit, reach 5 ft., one target. *Hit:* 11 (2d6 + 4) slashing damage.\n\n***Longbow (Abomination Form Only).*** *Ranged Weapon Attack:* +6 to hit, range 150/600 ft., one target. *Hit:* 12 (2d8 + 3) piercing damage plus 10 (3d6) poison damage.",
			"",
			"",
			"",
			"Abominations are the highest caste of the yuan-ti: huge serpents with powerful human torsos and arms, closest to the form their serpent gods intended."));
}
