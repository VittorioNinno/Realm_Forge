using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Dao (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class Dao2014Seeder
{
	public static Monster Build() => Create("dao", null, ContentSource.RealmForge, CreatureSize.Large, CreatureType.Elemental,
		18, 187, "15d10 + 105", 30, new[] { 23, 12, 24, 12, 13, 14 }, 11m, 7200, 4, 11,
		new Text(
			"Dao",
			null,
			"Elementale Grande, neutrale malvagio",
			"18 (armatura naturale)",
			"9 m, scavare 9 m, volare 9 m",
			"Car +6, Int +5, Sag +5",
			"",
			"",
			"",
			"",
			"pietrificato",
			"Percezione passiva 11, scurovisione 36 m",
			"Terran",
			"***Scivolare nella terra.*** Il dao può scavare attraverso terra e pietra non magiche e non lavorate senza smuovere ciò che attraversa.\n\n***Fine elementale.*** Quando il dao muore, il suo corpo si sgretola in polvere cristallina, lasciando solo ciò che indossava o trasportava.\n\n***Incantesimi innati.*** Il dao lancia per natura gli incantesimi seguenti usando il Carisma (CD del tiro salvezza sull'incantesimo 14, +6 al tiro per colpire con attacco con incantesimo), senza bisogno di componenti materiali:\n\n- A volontà: *individuazione del bene e del male*, *individuazione del magico*, *scolpire pietra*\n- 3/giorno ciascuno: *passapareti*, *muovere il terreno*, *linguaggi*\n- 1/giorno ciascuno: *evoca elementale* (solo elementale della terra), *forma gassosa*, *invisibilità*, *allucinazione mortale*, *spostamento planare*, *muro di pietra*\n\n***Piede fermo.*** Il dao dispone di vantaggio ai tiri salvezza su Forza e su Destrezza contro gli effetti che lo farebbero cadere prono.",
			"***Multiattacco.*** Il dao effettua due attacchi con i pugni o due con il maglio.\n\n***Pugno.*** *Attacco con arma da mischia:* +10 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 15 (2d8 + 6) danni contundenti.\n\n***Maglio.*** *Attacco con arma da mischia:* +10 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 20 (4d6 + 6) danni contundenti. Una creatura di taglia Enorme o inferiore colpita deve superare un tiro salvezza su Forza con CD 18, altrimenti cade prona.",
			"",
			"",
			"",
			""),
		new Text(
			"Dao",
			null,
			"Large elemental, neutral evil",
			"18 (natural armor)",
			"30 ft., burrow 30 ft., fly 30 ft.",
			"Int +5, Wis +5, Cha +6",
			"",
			"",
			"",
			"",
			"petrified",
			"darkvision 120 ft., passive Perception 11",
			"Terran",
			"***Earth Glide.*** The dao can burrow through nonmagical, unworked earth and stone without disturbing what it passes through.\n\n***Elemental Demise.*** When the dao dies, its body crumbles into crystal powder, leaving only what it wore or carried.\n\n***Innate Spellcasting.*** The dao casts the following spells innately, using Charisma (spell save DC 14, +6 to hit with spell attacks) and needing no material components:\n\n- At will: *detect evil and good*, *detect magic*, *stone shape*\n- 3/day each: *passwall*, *move earth*, *tongues*\n- 1/day each: *conjure elemental* (earth elemental only), *gaseous form*, *invisibility*, *phantasmal killer*, *plane shift*, *wall of stone*\n\n***Sure-Footed.*** The dao has advantage on Strength and Dexterity saving throws against effects that would knock it prone.",
			"***Multiattack.*** The dao makes two fist attacks or two maul attacks.\n\n***Fist.*** *Melee Weapon Attack:* +10 to hit, reach 5 ft., one target. *Hit:* 15 (2d8 + 6) bludgeoning damage.\n\n***Maul.*** *Melee Weapon Attack:* +10 to hit, reach 5 ft., one target. *Hit:* 20 (4d6 + 6) bludgeoning damage. A Huge or smaller creature hit must succeed on a DC 18 Strength saving throw or be knocked prone.",
			"",
			"",
			"",
			""));
}
