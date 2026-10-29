using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Marid (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class Marid2014Seeder
{
	public static Monster Build() => Create("marid", null, ContentSource.RealmForge, CreatureSize.Large, CreatureType.Elemental,
		17, 229, "17d10 + 136", 30, new[] { 22, 12, 26, 18, 17, 18 }, 11m, 7200, 4, 13,
		new Text(
			"Marid",
			null,
			"Elementale Grande, caotico neutrale",
			"17 (armatura naturale)",
			"9 m, volare 18 m, nuotare 27 m",
			"Car +8, Des +5, Sag +7",
			"",
			"",
			"acido, freddo, fulmine",
			"",
			"",
			"Percezione passiva 13, scurovisione 36 m, vista cieca 9 m",
			"Acquan",
			"***Anfibio.*** Il marid può respirare in aria e in acqua.\n\n***Fine elementale.*** Quando il marid muore, il suo corpo si dissolve in uno spruzzo di acqua e schiuma, lasciando solo ciò che indossava o trasportava.\n\n***Incantesimi innati.*** Il marid lancia per natura gli incantesimi seguenti usando il Carisma (CD del tiro salvezza sull'incantesimo 16, +8 al tiro per colpire con attacco con incantesimo), senza bisogno di componenti materiali:\n\n- A volontà: *creare o distruggere acqua*, *individuazione del bene e del male*, *individuazione del magico*, *nube di nebbia*, *purificare cibo e bevande*\n- 3/giorno ciascuno: *linguaggi*, *respirare sott'acqua*, *camminare sull'acqua*\n- 1/giorno ciascuno: *evoca elementale* (solo elementale dell'acqua), *controllare acqua*, *forma gassosa*, *invisibilità*, *spostamento planare*",
			"***Multiattacco.*** Il marid effettua due attacchi con il tridente.\n\n***Tridente.*** *Attacco con arma da mischia o a distanza:* +10 al tiro per colpire, portata 1,5 m o gittata 6/18 m, un bersaglio. *Colpito:* 13 (2d6 + 6) danni perforanti, o 15 (2d8 + 6) danni perforanti se impugnata a due mani.\n\n***Getto d'acqua.*** Il marid spara magicamente un getto d'acqua in una linea lunga 18 metri e larga 1,5 metri. Ogni creatura sulla linea effettua un tiro salvezza su Destrezza con CD 16. Se lo fallisce subisce 21 (6d6) danni contundenti e, se è di taglia Enorme o inferiore, viene spinta fino a 6 metri lontano dal marid e cade prona; se lo supera subisce la metà dei danni e resta dov'è, in piedi.",
			"",
			"",
			"",
			""),
		new Text(
			"Marid",
			null,
			"Large elemental, chaotic neutral",
			"17 (natural armor)",
			"30 ft., fly 60 ft., swim 90 ft.",
			"Dex +5, Wis +7, Cha +8",
			"",
			"",
			"acid, cold, lightning",
			"",
			"",
			"blindsight 30 ft., darkvision 120 ft., passive Perception 13",
			"Aquan",
			"***Amphibious.*** The marid can breathe air and water.\n\n***Elemental Demise.*** When the marid dies, its body dissolves into a splash of water and foam, leaving only what it wore or carried.\n\n***Innate Spellcasting.*** The marid casts the following spells innately, using Charisma (spell save DC 16, +8 to hit with spell attacks) and needing no material components:\n\n- At will: *create or destroy water*, *detect evil and good*, *detect magic*, *fog cloud*, *purify food and drink*\n- 3/day each: *tongues*, *water breathing*, *water walk*\n- 1/day each: *conjure elemental* (water elemental only), *control water*, *gaseous form*, *invisibility*, *plane shift*",
			"***Multiattack.*** The marid makes two trident attacks.\n\n***Trident.*** *Melee or Ranged Weapon Attack:* +10 to hit, reach 5 ft. or range 20/60 ft., one target. *Hit:* 13 (2d6 + 6) piercing damage, or 15 (2d8 + 6) piercing damage if used with two hands.\n\n***Water Jet.*** The marid magically blasts water in a 60-foot line, 5 feet wide. Each creature in the line makes a DC 16 Dexterity saving throw. On a failure it takes 21 (6d6) bludgeoning damage and, if Huge or smaller, is pushed up to 20 feet away from the marid and knocked prone; on a success it takes half the damage and stays where it is, on its feet.",
			"",
			"",
			"",
			""));
}
