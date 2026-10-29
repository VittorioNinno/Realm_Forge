using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Drow Mage (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class DrowMage2014Seeder
{
	public static Monster Build() => Create("drow-mage", null, ContentSource.RealmForge, CreatureSize.Medium, CreatureType.Humanoid,
		12, 45, "10d8", 30, new[] { 9, 14, 10, 17, 13, 12 }, 7m, 2900, 3, 14,
		new Text(
			"Drow mago",
			null,
			"Umanoide Medio (elfo), neutrale malvagio",
			"12 (15 con armatura magica)",
			"9 m",
			"",
			"Arcano +6, Furtività +5, Inganno +5, Percezione +4",
			"",
			"",
			"",
			"",
			"Percezione passiva 14, scurovisione 36 m",
			"Elfico, Sottocomune",
			"***Retaggio fatato.*** Il drow dispone di vantaggio ai tiri salvezza per non essere affascinato, e la magia non può farlo addormentare.\n\n***Incantesimi innati.*** Il drow lancia per natura gli incantesimi seguenti usando il Carisma (CD del tiro salvezza sull'incantesimo 12), senza bisogno di componenti materiali:\n\n- A volontà: *luci danzanti*\n- 1/giorno ciascuno: *oscurità*, *luminescenza*, *levitazione* (solo su se stesso)\n\n***Incantesimi.*** Il drow lancia incantesimi come un incantatore di 10° livello, usando l'Intelligenza (CD del tiro salvezza sull'incantesimo 14, +6 al tiro per colpire con attacco con incantesimo). Ha preparati i seguenti incantesimi da mago:\n\n- Trucchetti (a volontà): *mano magica*, *illusione minore*, *spruzzo velenoso*, *raggio di gelo*\n- 1° livello (4 slot): *armatura magica*, *dardo incantato*, *scudo*, *dardo stregato*\n- 2° livello (3 slot): *alterare se stesso*, *passo velato*, *ragnatela*\n- 3° livello (3 slot): *volare*, *fulmine*\n- 4° livello (3 slot): *tentacoli neri di Evard*, *invisibilità superiore*\n- 5° livello (2 slot): *nube mortale*\n\n***Sensibilità alla luce del sole.*** Finché si trova alla luce del sole, il drow subisce svantaggio ai tiri per colpire e alle prove di Saggezza (Percezione) basate sulla vista.",
			"***Bastone.*** *Attacco con arma da mischia:* +2 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 2 (1d6 - 1) danni contundenti, o 3 (1d8 - 1) danni contundenti se impugnata a due mani. In entrambi i casi il colpo infligge anche 3 (1d6) danni da veleno.\n\n***Evocare demoni (1/giorno).*** Il drow richiama magicamente un quasit, o tenta di richiamare un demone d'ombra con il 50 per cento di probabilità di successo. Il demone compare in uno spazio libero entro 18 metri da chi lo evoca, combatte al suo fianco e non può evocare altri demoni. Rimane per 10 minuti, finché esso o chi lo ha evocato non muore, o finché chi lo ha evocato non lo congeda con un'azione.",
			"",
			"",
			"",
			""),
		new Text(
			"Drow Mage",
			null,
			"Medium humanoid (elf), neutral evil",
			"12 (15 with mage armor)",
			"30 ft.",
			"",
			"Arcana +6, Deception +5, Perception +4, Stealth +5",
			"",
			"",
			"",
			"",
			"darkvision 120 ft., passive Perception 14",
			"Elvish, Undercommon",
			"***Fey Ancestry.*** The drow has advantage on saving throws against being charmed, and magic can't put it to sleep.\n\n***Innate Spellcasting.*** The drow casts the following spells innately, using Charisma (spell save DC 12) and needing no material components:\n\n- At will: *dancing lights*\n- 1/day each: *darkness*, *faerie fire*, *levitate* (self only)\n\n***Spellcasting.*** The drow casts spells as a 10th-level spellcaster, using Intelligence (spell save DC 14, +6 to hit with spell attacks). It has these wizard spells prepared:\n\n- Cantrips (at will): *mage hand*, *minor illusion*, *poison spray*, *ray of frost*\n- 1st level (4 slots): *mage armor*, *magic missile*, *shield*, *witch bolt*\n- 2nd level (3 slots): *alter self*, *misty step*, *web*\n- 3rd level (3 slots): *fly*, *lightning bolt*\n- 4th level (3 slots): *Evard's black tentacles*, *greater invisibility*\n- 5th level (2 slots): *cloudkill*\n\n***Sunlight Sensitivity.*** While in sunlight, the drow has disadvantage on attack rolls, as well as on Wisdom (Perception) checks that rely on sight.",
			"***Staff.*** *Melee Weapon Attack:* +2 to hit, reach 5 ft., one target. *Hit:* 2 (1d6 - 1) bludgeoning damage, or 3 (1d8 - 1) bludgeoning damage if used with two hands. Either way, the hit also deals 3 (1d6) poison damage.\n\n***Summon Demon (1/Day).*** The drow magically calls a quasit, or tries to call a shadow demon, with a 50 percent chance of success. The demon appears in a free space within 60 feet of the summoner, fights at its side and can't summon other demons. It stays for 10 minutes, until it or the summoner dies, or until the summoner dismisses it as an action.",
			"",
			"",
			"",
			""));
}
