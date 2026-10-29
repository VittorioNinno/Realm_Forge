using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Yuan-ti Malison (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class YuanTiMalison2014Seeder
{
	public static Monster Build() => Create("yuan-ti-malison", null, ContentSource.RealmForge, CreatureSize.Medium, CreatureType.Monstrosity,
		12, 66, "12d8 + 12", 30, new[] { 16, 14, 13, 14, 12, 16 }, 3m, 700, 2, 11,
		new Text(
			"Yuan-ti nefasto",
			null,
			"Mostruosità Media (mutaforma, yuan-ti), neutrale malvagio",
			"12",
			"9 m",
			"",
			"Furtività +4, Inganno +5",
			"",
			"",
			"veleno",
			"avvelenato",
			"Percezione passiva 11, scurovisione 18 m",
			"Abissale, Comune, Draconico",
			"***Mutaforma.*** Con un'azione, lo yuan-ti può trasformarsi in un serpente Medio o tornare alla sua forma reale. Le sue statistiche restano invariate in entrambe le forme; ciò che indossa o trasporta non si trasforma, e non torna alla forma originale se muore.\n\n***Incantesimi innati (solo in forma di yuan-ti).*** Lo yuan-ti lancia per natura gli incantesimi seguenti usando il Carisma (CD del tiro salvezza sull'incantesimo 13), senza bisogno di componenti materiali:\n\n- A volontà: *amicizia con gli animali* (solo serpenti)\n- 3/giorno: *suggestione*\n\n***Resistenza alla magia.*** Lo yuan-ti dispone di vantaggio ai tiri salvezza contro incantesimi e altri effetti magici.\n\n***Tipo di nefasto.*** Lo yuan-ti appartiene a uno di tre tipi: il tipo 1 ha corpo umano e testa di serpente; il tipo 2 ha testa e corpo umani con serpenti al posto delle braccia; il tipo 3 ha testa e torso umani su una parte inferiore serpentina. Le azioni seguenti sono quelle del tipo 1.",
			"***Multiattacco.*** In forma di yuan-ti, lo yuan-ti effettua due attacchi a distanza o due in mischia, mordendo non più di una volta.\n\n***Morso.*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, una creatura. *Colpito:* 5 (1d4 + 3) danni perforanti più 7 (2d6) danni da veleno.\n\n***Scimitarra (solo in forma di yuan-ti).*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 6 (1d6 + 3) danni taglienti.\n\n***Arco lungo (solo in forma di yuan-ti).*** *Attacco con arma a distanza:* +4 al tiro per colpire, gittata 45/180 m, un bersaglio. *Colpito:* 6 (1d8 + 2) danni perforanti più 7 (2d6) danni da veleno.",
			"",
			"",
			"",
			"Tipo 2: come Multiattacco morde due volte con le braccia di serpente (+5 al tiro per colpire, portata 1,5 m, una creatura, 5 (1d4 + 3) danni perforanti più 7 (2d6) danni da veleno) e non ha gli attacchi con scimitarra e arco lungo.\n\nTipo 3: come Multiattacco effettua due attacchi a distanza o due in mischia, stritolando non più di una volta. Il suo morso funziona solo in forma di serpente; Stritolare: +5 al tiro per colpire, portata 1,5 m, un bersaglio, 10 (2d6 + 3) danni contundenti e il bersaglio è afferrato (CD 13 per sfuggire) e trattenuto finché dura la presa. Il suo arco lungo infligge 6 (1d8 + 2) danni perforanti senza veleno."),
		new Text(
			"Yuan-ti Malison",
			null,
			"Medium monstrosity (shapechanger, yuan-ti), neutral evil",
			"12",
			"30 ft.",
			"",
			"Deception +5, Stealth +4",
			"",
			"",
			"poison",
			"poisoned",
			"darkvision 60 ft., passive Perception 11",
			"Abyssal, Common, Draconic",
			"***Shapechanger.*** As an action, the yuan-ti can polymorph into a Medium snake or back into its true form. Its statistics stay the same in either form; what it wears or carries doesn't change, and it doesn't revert if it dies.\n\n***Innate Spellcasting (Yuan-ti Form Only).*** The yuan-ti casts the following spells innately, using Charisma (spell save DC 13) and needing no material components:\n\n- At will: *animal friendship* (snakes only)\n- 3/day: *suggestion*\n\n***Magic Resistance.*** The yuan-ti has advantage on saving throws against spells and other magical effects.\n\n***Malison Type.*** The yuan-ti is one of three types: type 1 has a human body and a snake head; type 2 has a human head and body with snakes in place of arms; type 3 has a human head and torso on a serpentine lower body. The actions below are those of type 1.",
			"***Multiattack.*** In yuan-ti form, the yuan-ti makes two ranged or two melee attacks, biting no more than once.\n\n***Bite.*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one creature. *Hit:* 5 (1d4 + 3) piercing damage plus 7 (2d6) poison damage.\n\n***Scimitar (Yuan-ti Form Only).*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one target. *Hit:* 6 (1d6 + 3) slashing damage.\n\n***Longbow (Yuan-ti Form Only).*** *Ranged Weapon Attack:* +4 to hit, range 150/600 ft., one target. *Hit:* 6 (1d8 + 2) piercing damage plus 7 (2d6) poison damage.",
			"",
			"",
			"",
			"Type 2: as its Multiattack, it bites twice with its snake arms (+5 to hit, reach 5 ft., one creature, 5 (1d4 + 3) piercing plus 7 (2d6) poison damage), and has no scimitar or longbow attacks.\n\nType 3: as its Multiattack, it makes two ranged or two melee attacks, constricting no more than once. Its bite works only in snake form; Constrict: +5 to hit, reach 5 ft., one target, 10 (2d6 + 3) bludgeoning damage and the target is grappled (escape DC 13) and restrained until the grapple ends. Its longbow deals 6 (1d8 + 2) piercing damage with no poison."));
}
