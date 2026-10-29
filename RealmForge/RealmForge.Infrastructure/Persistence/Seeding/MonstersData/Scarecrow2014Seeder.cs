using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Scarecrow (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class Scarecrow2014Seeder
{
	public static Monster Build() => Create("scarecrow", null, ContentSource.RealmForge, CreatureSize.Medium, CreatureType.Construct,
		11, 36, "8d8", 30, new[] { 11, 13, 11, 10, 10, 13 }, 1m, 200, 2, 10,
		new Text(
			"Spaventapasseri",
			null,
			"Costrutto Medio, caotico malvagio",
			"11",
			"9 m",
			"",
			"",
			"fuoco",
			"contundenti, perforanti e taglienti da attacchi non magici",
			"veleno",
			"affascinato, avvelenato, indebolimento, paralizzato, privo di sensi, spaventato",
			"Percezione passiva 10, scurovisione 18 m",
			"capisce i linguaggi del suo creatore ma non li parla",
			"***Falso aspetto.*** Finché resta immobile, lo spaventapasseri ha esattamente l'aspetto di un normale spaventapasseri inanimato.",
			"***Multiattacco.*** Lo spaventapasseri effettua due attacchi con gli artigli.\n\n***Artiglio.*** *Attacco con arma da mischia:* +3 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 6 (2d4 + 1) danni taglienti. Una creatura colpita effettua un tiro salvezza su Saggezza con CD 11, altrimenti è spaventata fino alla fine del turno successivo dello spaventapasseri.\n\n***Sguardo terrificante.*** Una creatura che lo spaventapasseri è in grado di vedere entro 9 metri da lui, e che può vederlo, effettua un tiro salvezza su Saggezza con CD 11, altrimenti è magicamente spaventata, e paralizzata, fino alla fine del turno successivo dello spaventapasseri.",
			"",
			"",
			"",
			""),
		new Text(
			"Scarecrow",
			null,
			"Medium construct, chaotic evil",
			"11",
			"30 ft.",
			"",
			"",
			"fire",
			"bludgeoning, piercing, and slashing from nonmagical attacks",
			"poison",
			"charmed, exhaustion, frightened, paralyzed, poisoned, unconscious",
			"darkvision 60 ft., passive Perception 10",
			"understands the languages of its creator but can't speak",
			"***False Appearance.*** As long as it stays still, the scarecrow looks exactly like an ordinary, lifeless scarecrow.",
			"***Multiattack.*** The scarecrow makes two claw attacks.\n\n***Claw.*** *Melee Weapon Attack:* +3 to hit, reach 5 ft., one target. *Hit:* 6 (2d4 + 1) slashing damage. A creature hit makes a DC 11 Wisdom saving throw or is frightened until the end of the scarecrow's next turn.\n\n***Terrifying Glare.*** One creature the scarecrow can see within 30 feet of it, and that can see the scarecrow, makes a DC 11 Wisdom saving throw or is magically frightened, and paralyzed, until the end of the scarecrow's next turn.",
			"",
			"",
			"",
			""));
}
