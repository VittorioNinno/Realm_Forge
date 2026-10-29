using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Dust Mephit (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class DustMephit2014Seeder
{
	public static Monster Build() => Create("dust-mephit", null, ContentSource.Srd51, CreatureSize.Small, CreatureType.Elemental,
		12, 17, "5d6", 30, new[] { 5, 14, 10, 9, 11, 10 }, 0.5m, 100, 2, 12,
		new Text(
			"Mephit della polvere",
			null,
			"Elementale Piccolo, neutrale malvagio",
			"12",
			"9 m, volare 9 m",
			"",
			"Furtività +4, Percezione +2",
			"fuoco",
			"",
			"veleno",
			"avvelenato",
			"Percezione passiva 12, scurovisione 18 m",
			"Auran, Terran",
			"***Esplosione della morte.*** Quando il mephit muore, esplode in una nube di polvere. Ogni creatura entro 1,5 metri dal mephit deve superare un tiro salvezza su Costituzione con CD 10, altrimenti è accecata per 1 minuto. Una creatura accecata può ripetere il tiro salvezza a ogni suo turno e, se lo supera, l'effetto svanisce.\n\n***Incantesimi innati (1/giorno).*** Il mephit può lanciare *sonno* come incantesimo innato senza aver bisogno di componenti materiali. La sua caratteristica innata da incantatore è Carisma.",
			"***Artigli.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, una creatura. *Colpito:* 4 (1d4 + 2) danni taglienti.\n\n***Soffio accecante (ricarica 6).*** Il mephit esala polvere accecante in un cono di 4,5 metri. Ogni creatura in quell'area deve superare un tiro salvezza su Destrezza con CD 10, altrimenti è accecata per 1 minuto. La creatura può ripetere il tiro salvezza alla fine di ogni suo turno e, se lo supera, l'effetto svanisce.",
			"",
			"",
			"",
			""),
		new Text(
			"Dust Mephit",
			null,
			"Small elemental, neutral evil",
			"12",
			"30 ft., fly 30 ft.",
			"",
			"Perception +2, Stealth +4",
			"fire",
			"",
			"poison",
			"poisoned",
			"darkvision 60 ft., passive Perception 12",
			"Auran, Terran",
			"***Death Burst.*** When the mephit dies, it explodes in a burst of dust. Each creature within 5 ft. of it must then succeed on a DC 10 Constitution saving throw or be blinded for 1 minute. A blinded creature can repeat the saving throw on each of its turns, ending the effect on itself on a success.\n\n***Innate Spellcasting.*** The mephit can innately cast sleep, requiring no material components. Its innate spellcasting ability is Charisma.",
			"***Claws.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one creature. *Hit:* 4 (1d4 + 2) slashing damage.\n\n***Blinding Breath (Recharge 6).*** The mephit exhales a 15-foot cone of blinding dust. Each creature in that area must succeed on a DC 10 Dexterity saving throw or be blinded for 1 minute. A creature can repeat the saving throw at the end of each of its turns, ending the effect on itself on a success.",
			"",
			"",
			"",
			""));
}
