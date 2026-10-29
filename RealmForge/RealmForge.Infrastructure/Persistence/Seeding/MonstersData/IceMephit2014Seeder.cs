using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Ice Mephit (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class IceMephit2014Seeder
{
	public static Monster Build() => Create("ice-mephit", null, CreatureSize.Small, CreatureType.Elemental,
		11, 21, "6d6", 30, new[] { 7, 13, 10, 9, 11, 12 }, 0.5m, 100, 2, 12,
		new Text(
			"Mephit del ghiaccio",
			null,
			"Elementale Piccolo, neutrale malvagio",
			"11",
			"9 m, volare 9 m",
			"",
			"Furtività +3, Percezione +2",
			"contundenti, fuoco",
			"",
			"freddo, veleno",
			"avvelenato",
			"Percezione passiva 12, scurovisione 18 m",
			"Aquan, Auran",
			"***Esplosione della morte.*** Quando il mephit muore, esplode in una pioggia di frammenti di ghiaccio acuminati. Ogni creatura entro 1,5 metri dal mephit deve effettuare un tiro salvezza su Destrezza con CD 10, subendo 4 (1d8) danni taglienti in caso di fallimento, o la metà in caso di successo.\n\n***Falso aspetto.*** Finché il mephit rimane immobile, non è possibile distinguerlo da un normale pezzo di ghiaccio.\n\n***Incantesimi innati (1/giorno).*** Il mephit può lanciare *nube di nebbia* come incantesimo innato senza aver bisogno di componenti materiali. La sua caratteristica innata da incantatore è Carisma.",
			"***Artigli.*** *Attacco con arma da mischia:* +3 al tiro per colpire, portata 1,5 m, una creatura. *Colpito:* 3 (1d4 + 1) danni taglienti più 2 (1d4) danni da freddo.\n\n***Soffio di gelo (ricarica 6).*** Il mephit esala aria fredda in un cono di 4,5 metri. Ogni creatura in quell'area deve effettuare un tiro salvezza su Destrezza con CD 10, subendo 5 (2d4) danni da freddo in caso di fallimento, o la metà dei danni in caso di successo.",
			"",
			""),
		new Text(
			"Ice Mephit",
			null,
			"Small elemental, neutral evil",
			"11",
			"30 ft., fly 30 ft.",
			"",
			"Perception +2, Stealth +3",
			"bludgeoning, fire",
			"",
			"cold, poison",
			"poisoned",
			"darkvision 60 ft., passive Perception 12",
			"Aquan, Auran",
			"***Death Burst.*** When the mephit dies, it explodes in a burst of jagged ice. Each creature within 5 ft. of it must make a DC 10 Dexterity saving throw, taking 4 (1d8) slashing damage on a failed save, or half as much damage on a successful one.\n\n***False Appearance.*** While the mephit remains motionless, it is indistinguishable from an ordinary shard of ice.\n\n***Innate Spellcasting.*** The mephit can innately cast fog cloud, requiring no material components. Its innate spellcasting ability is Charisma.",
			"***Claws.*** *Melee Weapon Attack:* +3 to hit, reach 5 ft., one creature. *Hit:* 3 (1d4 + 1) slashing damage plus 2 (1d4) cold damage.\n\n***Frost Breath (Recharge 6).*** The mephit exhales a 15-foot cone of cold air. Each creature in that area must succeed on a DC 10 Dexterity saving throw, taking 5 (2d4) cold damage on a failed save, or half as much damage on a successful one.",
			"",
			""));
}
