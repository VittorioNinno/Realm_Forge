using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Kuo-toa Whip (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class KuoToaWhip2014Seeder
{
	public static Monster Build() => Create("kuo-toa-whip", null, ContentSource.RealmForge, CreatureSize.Medium, CreatureType.Humanoid,
		11, 65, "10d8 + 20", 30, new[] { 14, 10, 14, 12, 14, 11 }, 1m, 200, 2, 16,
		new Text(
			"Kuo-toa esecutore",
			null,
			"Umanoide Medio (kuo-toa), neutrale malvagio",
			"11 (armatura naturale)",
			"9 m, nuotare 9 m",
			"",
			"Percezione +6, Religione +4",
			"",
			"",
			"",
			"",
			"Percezione passiva 16, scurovisione 36 m",
			"Sottocomune",
			"***Anfibio.*** Il kuo-toa può respirare in aria e in acqua.\n\n***Percezione ultraterrena.*** Il kuo-toa avverte la presenza di ogni creatura invisibile, o che si trova sul Piano Etereo, entro 9 metri da lui, e se si muove ne conosce la posizione esatta.\n\n***Viscido.*** Il kuo-toa dispone di vantaggio alle prove di caratteristica e ai tiri salvezza per sfuggire a una presa.\n\n***Sensibilità alla luce del sole.*** Finché si trova alla luce del sole, il kuo-toa subisce svantaggio ai tiri per colpire e alle prove di Saggezza (Percezione) basate sulla vista.\n\n***Incantesimi.*** Il kuo-toa lancia incantesimi come un incantatore di 2° livello, usando la Saggezza (CD del tiro salvezza sull'incantesimo 12, +4 al tiro per colpire con attacco con incantesimo). Ha preparati i seguenti incantesimi da chierico:\n\n- Trucchetti (a volontà): *fiamma sacra*, *taumaturgia*\n- 1° livello (3 slot): *anatema*, *scudo della fede*",
			"***Multiattacco.*** Il kuo-toa effettua due attacchi: uno con il morso e uno con il bastone a tenaglia.\n\n***Morso.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 4 (1d4 + 2) danni perforanti.\n\n***Bastone a tenaglia.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 3 m, un bersaglio. *Colpito:* 5 (1d6 + 2) danni perforanti. Una creatura di taglia Media o inferiore colpita è afferrata (CD 14 per sfuggire); finché dura la presa, il kuo-toa non può usare il bastone a tenaglia contro nessun altro.",
			"",
			"",
			"",
			""),
		new Text(
			"Kuo-toa Whip",
			null,
			"Medium humanoid (kuo-toa), neutral evil",
			"11 (natural armor)",
			"30 ft., swim 30 ft.",
			"",
			"Perception +6, Religion +4",
			"",
			"",
			"",
			"",
			"darkvision 120 ft., passive Perception 16",
			"Undercommon",
			"***Amphibious.*** The kuo-toa can breathe air and water.\n\n***Otherworldly Perception.*** The kuo-toa senses the presence of every invisible creature, or creature on the Ethereal Plane, within 30 feet of it, and knows exactly where it is if it moves.\n\n***Slippery.*** The kuo-toa has advantage on ability checks and saving throws to escape a grapple.\n\n***Sunlight Sensitivity.*** While in sunlight, the kuo-toa has disadvantage on attack rolls, as well as on Wisdom (Perception) checks that rely on sight.\n\n***Spellcasting.*** The kuo-toa casts spells as a 2nd-level spellcaster, using Wisdom (spell save DC 12, +4 to hit with spell attacks). It has these cleric spells prepared:\n\n- Cantrips (at will): *sacred flame*, *thaumaturgy*\n- 1st level (3 slots): *bane*, *shield of faith*",
			"***Multiattack.*** The kuo-toa makes two attacks: one with its bite and one with its pincer staff.\n\n***Bite.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one target. *Hit:* 4 (1d4 + 2) piercing damage.\n\n***Pincer Staff.*** *Melee Weapon Attack:* +4 to hit, reach 10 ft., one target. *Hit:* 5 (1d6 + 2) piercing damage. A Medium or smaller creature hit is grappled (escape DC 14); while the grapple lasts, the kuo-toa can't use its pincer staff on anyone else.",
			"",
			"",
			"",
			""));
}
