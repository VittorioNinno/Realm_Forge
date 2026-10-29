using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Drow Elite Warrior (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class DrowEliteWarrior2014Seeder
{
	public static Monster Build() => Create("drow-elite-warrior", null, ContentSource.RealmForge, CreatureSize.Medium, CreatureType.Humanoid,
		18, 71, "11d8 + 22", 30, new[] { 13, 18, 14, 11, 13, 12 }, 5m, 1800, 3, 14,
		new Text(
			"Drow combattente scelto",
			null,
			"Umanoide Medio (elfo), neutrale malvagio",
			"18 (cuoio borchiato, scudo)",
			"9 m",
			"Cos +5, Des +7, Sag +4",
			"Furtività +10, Percezione +4",
			"",
			"",
			"",
			"",
			"Percezione passiva 14, scurovisione 36 m",
			"Elfico, Sottocomune",
			"***Retaggio fatato.*** Il drow dispone di vantaggio ai tiri salvezza per non essere affascinato, e la magia non può farlo addormentare.\n\n***Incantesimi innati.*** Il drow lancia per natura gli incantesimi seguenti usando il Carisma (CD del tiro salvezza sull'incantesimo 12), senza bisogno di componenti materiali:\n\n- A volontà: *luci danzanti*\n- 1/giorno ciascuno: *oscurità*, *luminescenza*, *levitazione* (solo su se stesso)\n\n***Sensibilità alla luce del sole.*** Finché si trova alla luce del sole, il drow subisce svantaggio ai tiri per colpire e alle prove di Saggezza (Percezione) basate sulla vista.",
			"***Multiattacco.*** Il drow effettua due attacchi con la spada corta.\n\n***Spada corta.*** *Attacco con arma da mischia:* +7 al tiro per colpire, portata 3 m, un bersaglio. *Colpito:* 7 (1d6 + 4) danni perforanti più 10 (3d6) danni da veleno.\n\n***Balestra a mano.*** *Attacco con arma a distanza:* +7 al tiro per colpire, gittata 9/36 m, un bersaglio. *Colpito:* 7 (1d6 + 4) danni perforanti. Il bersaglio effettua un tiro salvezza su Costituzione con CD 13, altrimenti è avvelenato per 1 ora; se lo fallisce di 5 o più, resta anche privo di sensi finché è avvelenato in questo modo, e si sveglia se subisce danni o se un'altra creatura usa un'azione per scuoterlo.",
			"",
			"***Parata.*** Quando un attacco in mischia sta per colpirlo, il drow può aggiungere 3 alla sua CA contro quell'attacco, purché veda l'attaccante e impugni un'arma da mischia.",
			"",
			""),
		new Text(
			"Drow Elite Warrior",
			null,
			"Medium humanoid (elf), neutral evil",
			"18 (studded leather, shield)",
			"30 ft.",
			"Dex +7, Con +5, Wis +4",
			"Perception +4, Stealth +10",
			"",
			"",
			"",
			"",
			"darkvision 120 ft., passive Perception 14",
			"Elvish, Undercommon",
			"***Fey Ancestry.*** The drow has advantage on saving throws against being charmed, and magic can't put it to sleep.\n\n***Innate Spellcasting.*** The drow casts the following spells innately, using Charisma (spell save DC 12) and needing no material components:\n\n- At will: *dancing lights*\n- 1/day each: *darkness*, *faerie fire*, *levitate* (self only)\n\n***Sunlight Sensitivity.*** While in sunlight, the drow has disadvantage on attack rolls, as well as on Wisdom (Perception) checks that rely on sight.",
			"***Multiattack.*** The drow makes two shortsword attacks.\n\n***Shortsword.*** *Melee Weapon Attack:* +7 to hit, reach 10 ft., one target. *Hit:* 7 (1d6 + 4) piercing damage plus 10 (3d6) poison damage.\n\n***Hand Crossbow.*** *Ranged Weapon Attack:* +7 to hit, range 30/120 ft., one target. *Hit:* 7 (1d6 + 4) piercing damage. The target makes a DC 13 Constitution saving throw or is poisoned for 1 hour; if it fails by 5 or more, it is also unconscious for as long as it stays poisoned this way, waking up if it takes damage or another creature uses an action to shake it awake.",
			"",
			"***Parry.*** When a melee attack would hit it, the drow can add 3 to its AC against that attack, provided it can see the attacker and holds a melee weapon.",
			"",
			""));
}
