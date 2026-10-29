using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Sahuagin Priestess (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class SahuaginPriestess2014Seeder
{
	public static Monster Build() => Create("sahuagin-priestess", null, ContentSource.RealmForge, CreatureSize.Medium, CreatureType.Humanoid,
		12, 33, "6d8 + 6", 30, new[] { 13, 11, 12, 12, 14, 13 }, 2m, 450, 2, 16,
		new Text(
			"Sahuagin sacerdotessa",
			null,
			"Umanoide Medio (sahuagin), legale malvagia",
			"12 (armatura naturale)",
			"9 m, nuotare 12 m",
			"",
			"Percezione +6, Religione +3",
			"",
			"",
			"",
			"",
			"Percezione passiva 16, scurovisione 36 m",
			"Sahuagin",
			"***Frenesia sanguinaria.*** La sahuagin dispone di vantaggio ai tiri per colpire in mischia contro qualsiasi creatura che non abbia tutti i suoi punti ferita.\n\n***Anfibio limitato.*** La sahuagin respira sia in aria che in acqua, ma deve immergersi completamente almeno una volta ogni 4 ore, altrimenti comincia a soffocare.\n\n***Telepatia con gli squali.*** Tramite una telepatia limitata, la sahuagin può comandare magicamente qualsiasi squalo entro 36 metri da lei.\n\n***Incantesimi.*** La sahuagin lancia incantesimi come un'incantatrice di 6° livello, usando la Saggezza (CD del tiro salvezza sull'incantesimo 12, +4 al tiro per colpire con attacco con incantesimo). Ha preparati i seguenti incantesimi da chierico:\n\n- Trucchetti (a volontà): *guida*, *taumaturgia*\n- 1° livello (4 slot): *benedizione*, *individuazione del magico*, *dardo tracciante*\n- 2° livello (3 slot): *blocca persone*, *arma spirituale* (tridente)\n- 3° livello (3 slot): *parola guaritrice di massa*, *linguaggi*",
			"***Multiattacco.*** La sahuagin effettua due attacchi: uno con il morso e uno con gli artigli.\n\n***Morso.*** *Attacco con arma da mischia:* +3 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 3 (1d4 + 1) danni perforanti.\n\n***Artigli.*** *Attacco con arma da mischia:* +3 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 3 (1d4 + 1) danni taglienti.",
			"",
			"",
			"",
			""),
		new Text(
			"Sahuagin Priestess",
			null,
			"Medium humanoid (sahuagin), lawful evil",
			"12 (natural armor)",
			"30 ft., swim 40 ft.",
			"",
			"Perception +6, Religion +3",
			"",
			"",
			"",
			"",
			"darkvision 120 ft., passive Perception 16",
			"Sahuagin",
			"***Blood Frenzy.*** The sahuagin has advantage on melee attack rolls against any creature that is missing some of its hit points.\n\n***Limited Amphibiousness.*** The sahuagin breathes both air and water, but must be fully underwater at least once every 4 hours or she starts to suffocate.\n\n***Shark Telepathy.*** Through a limited telepathy, the sahuagin can magically command any shark within 120 feet of her.\n\n***Spellcasting.*** The sahuagin casts spells as a 6th-level spellcaster, using Wisdom (spell save DC 12, +4 to hit with spell attacks). She has these cleric spells prepared:\n\n- Cantrips (at will): *guidance*, *thaumaturgy*\n- 1st level (4 slots): *bless*, *detect magic*, *guiding bolt*\n- 2nd level (3 slots): *hold person*, *spiritual weapon* (trident)\n- 3rd level (3 slots): *mass healing word*, *tongues*",
			"***Multiattack.*** The sahuagin makes two attacks: a bite and a claws attack.\n\n***Bite.*** *Melee Weapon Attack:* +3 to hit, reach 5 ft., one target. *Hit:* 3 (1d4 + 1) piercing damage.\n\n***Claws.*** *Melee Weapon Attack:* +3 to hit, reach 5 ft., one target. *Hit:* 3 (1d4 + 1) slashing damage.",
			"",
			"",
			"",
			""));
}
