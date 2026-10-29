using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Drow (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Drow2014Seeder
{
	public static Monster Build() => Create("drow", null, ContentSource.Srd51, CreatureSize.Medium, CreatureType.Humanoid,
		15, 13, "3d8", 30, new[] { 10, 14, 10, 11, 11, 12 }, 0.25m, 50, 2, 12,
		new Text(
			"Elfo drow",
			"Drow",
			"Umanoide Medio (elfo), neutrale malvagio",
			"15 (giaco di maglia)",
			"9 m",
			"",
			"Furtività +4, Percezione +2",
			"",
			"",
			"",
			"",
			"Percezione passiva 12, scurovisione 36 m",
			"Elfico, Sottocomune",
			"***Incantesimi innati.*** La caratteristica da incantatore del drow è Carisma (CD del tiro salvezza sull'incantesimo 11). Per sua natura, è in grado di lanciare gli incantesimi indicati di seguito senza aver bisogno di componenti materiali:\n\n- A volontà: *luci danzanti*\n- 1/giorno ciascuno: *luminescenza, oscurità*\n\n***Retaggio fatato.*** Il drow dispone di vantaggio ai tiri salvezza contro la condizione di affascinato e non può essere addormentato tramite la magia.\n\n***Sensibilità al sole.*** Mentre è alla luce del sole, il drow ha uno svantaggio nei tiri per colpire, così come nelle prove di Saggezza (Percezione) che si basano sulla vista.",
			"***Spada corta.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 5 (1d6 + 2) danni perforanti.\n\n***Balestra a mano.*** *Attacco con arma a distanza:* +4 al tiro per colpire, gittata 9/36 m, un bersaglio. *Colpito:* 5 (1d6 + 2) danni perforanti e il bersaglio deve superare un tiro salvezza su Costituzione con CD 13, altrimenti viene avvelenato per 1 ora. Se il tiro salvezza fallisce di 5 o più, il bersaglio avvelenato rimane anche privo di sensi. Il bersaglio si risveglia se subisce danni o se un'altra creatura usa un'azione per svegliarlo scuotendolo.",
			"",
			"",
			"",
			""),
		new Text(
			"Drow",
			null,
			"Medium humanoid (elf), neutral evil",
			"15 (chain shirt)",
			"30 ft.",
			"",
			"Perception +2, Stealth +4",
			"",
			"",
			"",
			"",
			"darkvision 120 ft., passive Perception 12",
			"Elvish, Undercommon",
			"***Fey Ancestry.*** The drow has advantage on saving throws against being charmed, and magic can't put the drow to sleep.\n\n***Innate Spellcasting.*** The drow's spellcasting ability is Charisma (spell save DC 11). It can innately cast the following spells, requiring no material components:\n\n- At will: *dancing lights*\n- 1/day each: *darkness, faerie fire*\n\n***Sunlight Sensitivity.*** While in sunlight, the drow has disadvantage on attack rolls, as well as on Wisdom (Perception) checks that rely on sight.",
			"***Shortsword.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one target. *Hit:* 5 (1d6 + 2) piercing damage.\n\n***Hand Crossbow.*** *Ranged Weapon Attack:* +4 to hit, range 30/120 ft., one target. *Hit:* 5 (1d6 + 2) piercing damage, and the target must succeed on a DC 13 Constitution saving throw or be poisoned for 1 hour. If the saving throw fails by 5 or more, the target is also unconscious while poisoned in this way. The target wakes up if it takes damage or if another creature takes an action to shake it awake.",
			"",
			"",
			"",
			""));
}
