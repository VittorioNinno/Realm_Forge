using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Drow Priestess of Lolth (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class DrowPriestessOfLolth2014Seeder
{
	public static Monster Build() => Create("drow-priestess-of-lolth", null, ContentSource.RealmForge, CreatureSize.Medium, CreatureType.Humanoid,
		16, 71, "13d8 + 13", 30, new[] { 10, 14, 12, 13, 17, 18 }, 8m, 3900, 3, 16,
		new Text(
			"Drow sacerdotessa di Lolth",
			null,
			"Umanoide Medio (elfo), neutrale malvagia",
			"16 (corazza di scaglie)",
			"9 m",
			"Car +7, Cos +4, Sag +6",
			"Furtività +5, Intuizione +6, Percezione +6, Religione +4",
			"",
			"",
			"",
			"",
			"Percezione passiva 16, scurovisione 36 m",
			"Elfico, Sottocomune",
			"***Retaggio fatato.*** La drow dispone di vantaggio ai tiri salvezza per non essere affascinata, e la magia non può farla addormentare.\n\n***Incantesimi innati.*** La drow lancia per natura gli incantesimi seguenti usando il Carisma (CD del tiro salvezza sull'incantesimo 15), senza bisogno di componenti materiali:\n\n- A volontà: *luci danzanti*\n- 1/giorno ciascuno: *oscurità*, *luminescenza*, *levitazione* (solo su se stesso)\n\n***Incantesimi.*** La drow lancia incantesimi come un'incantatrice di 10° livello, usando la Saggezza (CD del tiro salvezza sull'incantesimo 14, +6 al tiro per colpire con attacco con incantesimo). Ha preparati i seguenti incantesimi da chierico:\n\n- Trucchetti (a volontà): *guida*, *spruzzo velenoso*, *resistenza*, *salvare i morenti*, *taumaturgia*\n- 1° livello (4 slot): *amicizia con gli animali*, *cura ferite*, *individuazione delle malattie e dei veleni*, *raggio di infermità*\n- 2° livello (3 slot): *ristorare inferiore*, *protezione dai veleni*, *ragnatela*\n- 3° livello (3 slot): *evoca animali* (2 ragni giganti), *dissolvi magie*\n- 4° livello (3 slot): *divinazione*, *libertà di movimento*\n- 5° livello (2 slot): *piaga degli insetti*, *cura ferite di massa*\n\n***Sensibilità alla luce del sole.*** Finché si trova alla luce del sole, la drow subisce svantaggio ai tiri per colpire e alle prove di Saggezza (Percezione) basate sulla vista.",
			"***Multiattacco.*** La drow effettua due attacchi con il flagello.\n\n***Flagello.*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 5 (1d6 + 2) danni perforanti più 17 (5d6) danni da veleno.\n\n***Evocare demoni (1/giorno).*** La drow tenta di richiamare magicamente uno yochlol con il 30 per cento di probabilità di successo; se fallisce, subisce 5 (1d10) danni psichici. Il demone compare in uno spazio libero entro 18 metri da chi lo evoca, combatte al suo fianco e non può evocare altri demoni. Rimane per 10 minuti, finché esso o chi lo ha evocato non muore, o finché chi lo ha evocato non lo congeda con un'azione.",
			"",
			"",
			"",
			""),
		new Text(
			"Drow Priestess of Lolth",
			null,
			"Medium humanoid (elf), neutral evil",
			"16 (scale mail)",
			"30 ft.",
			"Con +4, Wis +6, Cha +7",
			"Insight +6, Perception +6, Religion +4, Stealth +5",
			"",
			"",
			"",
			"",
			"darkvision 120 ft., passive Perception 16",
			"Elvish, Undercommon",
			"***Fey Ancestry.*** The drow has advantage on saving throws against being charmed, and magic can't put her to sleep.\n\n***Innate Spellcasting.*** The drow casts the following spells innately, using Charisma (spell save DC 15) and needing no material components:\n\n- At will: *dancing lights*\n- 1/day each: *darkness*, *faerie fire*, *levitate* (self only)\n\n***Spellcasting.*** The drow casts spells as a 10th-level spellcaster, using Wisdom (spell save DC 14, +6 to hit with spell attacks). She has these cleric spells prepared:\n\n- Cantrips (at will): *guidance*, *poison spray*, *resistance*, *spare the dying*, *thaumaturgy*\n- 1st level (4 slots): *animal friendship*, *cure wounds*, *detect poison and disease*, *ray of sickness*\n- 2nd level (3 slots): *lesser restoration*, *protection from poison*, *web*\n- 3rd level (3 slots): *conjure animals* (2 giant spiders), *dispel magic*\n- 4th level (3 slots): *divination*, *freedom of movement*\n- 5th level (2 slots): *insect plague*, *mass cure wounds*\n\n***Sunlight Sensitivity.*** While in sunlight, the drow has disadvantage on attack rolls, as well as on Wisdom (Perception) checks that rely on sight.",
			"***Multiattack.*** The drow makes two scourge attacks.\n\n***Scourge.*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one target. *Hit:* 5 (1d6 + 2) piercing damage plus 17 (5d6) poison damage.\n\n***Summon Demon (1/Day).*** The drow tries to magically call a yochlol, with a 30 percent chance of success; if she fails, she takes 5 (1d10) psychic damage. The demon appears in a free space within 60 feet of the summoner, fights at its side and can't summon other demons. It stays for 10 minutes, until it or the summoner dies, or until the summoner dismisses it as an action.",
			"",
			"",
			"",
			""));
}
