using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Kuo-toa Archpriest (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class KuoToaArchpriest2014Seeder
{
	public static Monster Build() => Create("kuo-toa-archpriest", null, ContentSource.RealmForge, CreatureSize.Medium, CreatureType.Humanoid,
		13, 97, "13d8 + 39", 30, new[] { 16, 14, 16, 13, 16, 14 }, 6m, 2300, 3, 19,
		new Text(
			"Kuo-toa gran sacerdote",
			null,
			"Umanoide Medio (kuo-toa), neutrale malvagio",
			"13 (armatura naturale)",
			"9 m, nuotare 9 m",
			"",
			"Percezione +9, Religione +6",
			"",
			"",
			"",
			"",
			"Percezione passiva 19, scurovisione 36 m",
			"Sottocomune",
			"***Anfibio.*** Il kuo-toa può respirare in aria e in acqua.\n\n***Percezione ultraterrena.*** Il kuo-toa avverte la presenza di ogni creatura invisibile, o che si trova sul Piano Etereo, entro 9 metri da lui, e se si muove ne conosce la posizione esatta.\n\n***Viscido.*** Il kuo-toa dispone di vantaggio alle prove di caratteristica e ai tiri salvezza per sfuggire a una presa.\n\n***Sensibilità alla luce del sole.*** Finché si trova alla luce del sole, il kuo-toa subisce svantaggio ai tiri per colpire e alle prove di Saggezza (Percezione) basate sulla vista.\n\n***Incantesimi.*** Il kuo-toa lancia incantesimi come un incantatore di 10° livello, usando la Saggezza (CD del tiro salvezza sull'incantesimo 14, +6 al tiro per colpire con attacco con incantesimo). Ha preparati i seguenti incantesimi da chierico:\n\n- Trucchetti (a volontà): *guida*, *fiamma sacra*, *taumaturgia*\n- 1° livello (4 slot): *individuazione del magico*, *santuario*, *scudo della fede*\n- 2° livello (3 slot): *blocca persone*, *arma spirituale*\n- 3° livello (3 slot): *guardiani spirituali*, *linguaggi*\n- 4° livello (3 slot): *controllare acqua*, *divinazione*\n- 5° livello (2 slot): *cura ferite di massa*, *scrutare*",
			"***Multiattacco.*** Il kuo-toa effettua due attacchi in mischia.\n\n***Scettro.*** *Attacco con arma da mischia:* +6 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 6 (1d6 + 3) danni contundenti più 14 (4d6) danni da fulmine.\n\n***Colpo senz'armi.*** *Attacco con arma da mischia:* +6 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 4 (1d4 + 2) danni contundenti.",
			"",
			"",
			"",
			""),
		new Text(
			"Kuo-toa Archpriest",
			null,
			"Medium humanoid (kuo-toa), neutral evil",
			"13 (natural armor)",
			"30 ft., swim 30 ft.",
			"",
			"Perception +9, Religion +6",
			"",
			"",
			"",
			"",
			"darkvision 120 ft., passive Perception 19",
			"Undercommon",
			"***Amphibious.*** The kuo-toa can breathe air and water.\n\n***Otherworldly Perception.*** The kuo-toa senses the presence of every invisible creature, or creature on the Ethereal Plane, within 30 feet of it, and knows exactly where it is if it moves.\n\n***Slippery.*** The kuo-toa has advantage on ability checks and saving throws to escape a grapple.\n\n***Sunlight Sensitivity.*** While in sunlight, the kuo-toa has disadvantage on attack rolls, as well as on Wisdom (Perception) checks that rely on sight.\n\n***Spellcasting.*** The kuo-toa casts spells as a 10th-level spellcaster, using Wisdom (spell save DC 14, +6 to hit with spell attacks). It has these cleric spells prepared:\n\n- Cantrips (at will): *guidance*, *sacred flame*, *thaumaturgy*\n- 1st level (4 slots): *detect magic*, *sanctuary*, *shield of faith*\n- 2nd level (3 slots): *hold person*, *spiritual weapon*\n- 3rd level (3 slots): *spirit guardians*, *tongues*\n- 4th level (3 slots): *control water*, *divination*\n- 5th level (2 slots): *mass cure wounds*, *scrying*",
			"***Multiattack.*** The kuo-toa makes two melee attacks.\n\n***Scepter.*** *Melee Weapon Attack:* +6 to hit, reach 5 ft., one target. *Hit:* 6 (1d6 + 3) bludgeoning damage plus 14 (4d6) lightning damage.\n\n***Unarmed Strike.*** *Melee Weapon Attack:* +6 to hit, reach 5 ft., one target. *Hit:* 4 (1d4 + 2) bludgeoning damage.",
			"",
			"",
			"",
			""));
}
