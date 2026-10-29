using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Magma Mephit (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class MagmaMephit2014Seeder
{
	public static Monster Build() => Create("magma-mephit", null, CreatureSize.Small, CreatureType.Elemental,
		11, 22, "5d6 + 5", 30, new[] { 8, 12, 12, 7, 10, 10 }, 0.5m, 100, 2, 10,
		new Text(
			"Mephit del magma",
			null,
			"Elementale Piccolo, neutrale malvagio",
			"11",
			"9 m, volare 9 m",
			"",
			"Furtività +3",
			"freddo",
			"",
			"fuoco, veleno",
			"avvelenato",
			"Percezione passiva 10, scurovisione 18 m",
			"Ignan, Terran",
			"***Esplosione della morte.*** Quando il mephit muore, esplode in un fiume di lava. Ogni creatura situata entro 1,5 metri dal mephit deve effettuare un tiro salvezza su Destrezza con CD 11, subendo 7 (2d6) danni da fuoco in caso di fallimento, o la metà in caso di successo.\n\n***Falso aspetto.*** Finché il mephit rimane immobile, non è possibile distinguerlo da un normale cumulo di magma.\n\n***Incantesimi innati (1/giorno).*** Il mephit può lanciare *riscaldare il metallo* (CD del tiro salvezza sull'incantesimo 10) come incantesimo innato senza aver bisogno di componenti materiali. La sua caratteristica innata da incantatore è Carisma.",
			"***Artigli.*** *Attacco con arma da mischia:* +3 al tiro per colpire, portata 1,5 m, una creatura. *Colpito:* 3 (1d4 + 1) danni taglienti più 2 (1d4) danni da fuoco.\n\n***Soffio di fuoco (ricarica 6).*** Il mephit esala aria fredda in un cono di 4,5 metri. Ogni creatura in quell'area deve effettuare un tiro salvezza su Destrezza con CD 11, subendo 7 (2d6) danni da fuoco in caso di fallimento, o la metà in caso di successo.",
			"",
			""),
		new Text(
			"Magma Mephit",
			null,
			"Small elemental, neutral evil",
			"11",
			"30 ft., fly 30 ft.",
			"",
			"Stealth +3",
			"cold",
			"",
			"fire, poison",
			"poisoned",
			"darkvision 60 ft., passive Perception 10",
			"Ignan, Terran",
			"***Death Burst.*** When the mephit dies, it explodes in a burst of lava. Each creature within 5 ft. of it must make a DC 11 Dexterity saving throw, taking 7 (2d6) fire damage on a failed save, or half as much damage on a successful one.\n\n***False Appearance.*** While the mephit remains motionless, it is indistinguishable from an ordinary mound of magma.\n\n***Innate Spellcasting.*** The mephit can innately cast heat metal (spell save DC 10), requiring no material components. Its innate spellcasting ability is Charisma.",
			"***Claws.*** *Melee Weapon Attack:* +3 to hit, reach 5 ft., one creature. *Hit:* 3 (1d4 + 1) slashing damage plus 2 (1d4) fire damage.\n\n***Fire Breath (Recharge 6).*** The mephit exhales a 15-foot cone of fire. Each creature in that area must make a DC 11 Dexterity saving throw, taking 7 (2d6) fire damage on a failed save, or half as much damage on a successful one.",
			"",
			""));
}
