using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Drider (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Drider2014Seeder
{
	public static Monster Build() => Create("drider", null, CreatureSize.Large, CreatureType.Monstrosity,
		19, 123, "13d10 + 52", 30, new[] { 16, 16, 18, 13, 14, 12 }, 6m, 2300, 3, 15,
		new Text(
			"Drider",
			null,
			"Mostruosità Grande, caotico malvagio",
			"19 (armatura naturale)",
			"9 m, scalare 9 m",
			"",
			"Furtività +9, Percezione +5",
			"",
			"",
			"",
			"",
			"Percezione passiva 15, scurovisione 36 m",
			"Elfico, Sottocomune",
			"***Arrampicatele.*** Il drider ignora le restrizioni di movimento causate dalle ragnatele.\n\n***Incantesimi innati.*** La caratteristica innata da incantatore del drider è Saggezza (CD del tiro salvezza sull'incantesimo 13). Per sua natura, il drider è in grado di lanciare gli incantesimi indicati di seguito senza aver bisogno di componenti materiali:\n\n- A volontà: *luci danzanti*\n- 1/giorno ciascuno: *luminescenza, oscurità*\n\n***Movimenti del ragno.*** Il drider può scalare le superfici difficili, inclusi i soffitti, lungo i quali si muove a testa in giù, senza effettuare una prova di caratteristica.\n\n***Retaggio fatato.*** Il drider dispone di vantaggio ai tiri salvezza contro la condizione di affascinato e non può essere addormentato tramite la magia.\n\n***Sensibilità al sole.*** Finché è esposto alla luce del sole, il drider subisce svantaggio ai tiri per colpire, oltre che alle prove di Saggezza (Percezione) basate sulla vista.",
			"***Multiattacco.*** Il drider effettua tre attacchi a scelta con la spada lunga o con l'arco lungo. Può sostituire una di queste mosse con un morso.\n\n***Morso.*** *Attacco con arma da mischia:* +6 al tiro per colpire, portata 1,5 m, una creatura. *Colpito:* 2 (1d4) danni perforanti più 9 (2d8) danni da veleno.\n\n***Spada lunga.*** *Attacco con arma da mischia:* +6 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 7 (1d8 + 3) danni taglienti o 8 (1d10 + 3) danni taglienti se impugnata con due mani.\n\n***Arco lungo.*** *Attacco con arma a distanza:* +6 al tiro per colpire, gittata 45/180 m, un bersaglio. *Colpito:* 7 (1d8 + 3) danni perforanti più 4 (1d8) danni da veleno.",
			"",
			""),
		new Text(
			"Drider",
			null,
			"Large monstrosity, chaotic evil",
			"19 (natural armor)",
			"30 ft., climb 30 ft.",
			"",
			"Perception +5, Stealth +9",
			"",
			"",
			"",
			"",
			"darkvision 120 ft., passive Perception 15",
			"Elvish, Undercommon",
			"***Fey Ancestry.*** The drider has advantage on saving throws against being charmed, and magic can't put the drider to sleep.\n\n***Innate Spellcasting.*** The drider's innate spellcasting ability is Wisdom (spell save DC 13). The drider can innately cast the following spells, requiring no material components:\n\n- At will: *dancing lights*\n- 1/day each: *darkness, faerie fire*\n\n***Spider Climb.*** The drider can climb difficult surfaces, including upside down on ceilings, without needing to make an ability check.\n\n***Sunlight Sensitivity.*** While in sunlight, the drider has disadvantage on attack rolls, as well as on Wisdom (Perception) checks that rely on sight.\n\n***Web Walker.*** The drider ignores movement restrictions caused by webbing.",
			"***Multiattack.*** The drider makes three attacks, either with its longsword or its longbow. It can replace one of those attacks with a bite attack.\n\n***Bite.*** *Melee Weapon Attack:* +6 to hit, reach 5 ft., one creature. *Hit:* 2 (1d4) piercing damage plus 9 (2d8) poison damage.\n\n***Longsword.*** *Melee Weapon Attack:* +6 to hit, reach 5 ft., one target. *Hit:* 7 (1d8 + 3) slashing damage, or 8 (1d10 + 3) slashing damage if used with two hands.\n\n***Longbow.*** *Ranged Weapon Attack:* +6 to hit, range 150/600 ft., one target. *Hit:* 7 (1d8 + 3) piercing damage plus 4 (1d8) poison damage.",
			"",
			""));
}
