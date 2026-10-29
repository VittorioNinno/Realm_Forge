using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Bone Naga (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class BoneNaga2014Seeder
{
	public static Monster Build() => Create("bone-naga", null, ContentSource.RealmForge, CreatureSize.Large, CreatureType.Undead,
		15, 58, "9d10 + 9", 30, new[] { 15, 16, 12, 15, 15, 16 }, 4m, 1100, 2, 12,
		new Text(
			"Naga d'ossa",
			null,
			"Non morto Grande, legale malvagio",
			"15 (armatura naturale)",
			"9 m",
			"",
			"",
			"",
			"",
			"veleno",
			"affascinato, avvelenato, indebolimento, paralizzato",
			"Percezione passiva 12, scurovisione 18 m",
			"Comune più un altro linguaggio",
			"***Incantesimi.*** Il naga lancia incantesimi come un incantatore di 5° livello (CD del tiro salvezza sull'incantesimo 12, +4 al tiro per colpire con attacco con incantesimo), con le sole componenti verbali. I suoi incantesimi dipendono da ciò che era in vita.\n\nUn ex naga guardiano usa la Saggezza e ha preparati i seguenti incantesimi da chierico:\n- Trucchetti (a volontà): *riparare, fiamma sacra, taumaturgia*\n- 1° livello (4 slot): *comando, scudo della fede*\n- 2° livello (3 slot): *calmare emozioni, blocca persone*\n- 3° livello (2 slot): *scagliare maledizione*\n\nUn ex naga spirituale usa l'Intelligenza e ha preparati i seguenti incantesimi da mago:\n- Trucchetti (a volontà): *mano magica, illusione minore, raggio di gelo*\n- 1° livello (4 slot): *charme su persone, sonno*\n- 2° livello (3 slot): *individuazione dei pensieri, blocca persone*\n- 3° livello (2 slot): *fulmine*",
			"***Morso.*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 3 m, una creatura. *Colpito:* 10 (2d6 + 3) danni perforanti più 10 (3d6) danni da veleno.",
			"",
			"",
			"",
			""),
		new Text(
			"Bone Naga",
			null,
			"Large undead, lawful evil",
			"15 (natural armor)",
			"30 ft.",
			"",
			"",
			"",
			"",
			"poison",
			"charmed, exhaustion, paralyzed, poisoned",
			"darkvision 60 ft., passive Perception 12",
			"Common plus one other language",
			"***Spellcasting.*** The naga casts spells as a 5th-level spellcaster (spell save DC 12, +4 to hit with spell attacks), needing only verbal components. Its spells depend on what it was in life.\n\nA former guardian naga uses Wisdom and has these cleric spells prepared:\n- Cantrips (at will): *mending, sacred flame, thaumaturgy*\n- 1st level (4 slots): *command, shield of faith*\n- 2nd level (3 slots): *calm emotions, hold person*\n- 3rd level (2 slots): *bestow curse*\n\nA former spirit naga uses Intelligence and has these wizard spells prepared:\n- Cantrips (at will): *mage hand, minor illusion, ray of frost*\n- 1st level (4 slots): *charm person, sleep*\n- 2nd level (3 slots): *detect thoughts, hold person*\n- 3rd level (2 slots): *lightning bolt*",
			"***Bite.*** *Melee Weapon Attack:* +5 to hit, reach 10 ft., one creature. *Hit:* 10 (2d6 + 3) piercing damage plus 10 (3d6) poison damage.",
			"",
			"",
			"",
			""));
}
