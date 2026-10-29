using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Young Silver Dragon (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class YoungSilverDragon2014Seeder
{
	public static Monster Build() => Create("young-silver-dragon", null, ContentSource.Srd51, CreatureSize.Large, CreatureType.Dragon,
		18, 168, "16d10 + 80", 40, new[] { 23, 10, 21, 14, 11, 19 }, 9m, 5000, 4, 18,
		new Text(
			"Drago d'argento giovane",
			null,
			"Drago Grande, legale buono",
			"18 (armatura naturale)",
			"12 m, volare 24 m",
			"Car +8, Cos +9, Des +4, Sag +4",
			"Arcano +6, Furtività +4, Percezione +8, Storia +6",
			"",
			"",
			"freddo",
			"",
			"Percezione passiva 18, scurovisione 36 m, vista cieca 9 m",
			"Comune, Draconico",
			"",
			"***Multiattacco.*** Il drago effettua tre attacchi: uno con il morso e due con gli artigli.\n\n***Artiglio.*** *Attacco con arma da mischia:* +10 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 13 (2d6 + 6) danni taglienti.\n\n***Morso.*** *Attacco con arma da mischia:* +10 al tiro per colpire, portata 3 m, un bersaglio. *Colpito:* 17 (2d10 + 6) danni perforanti.\n\n***Soffi (ricarica 5–6).*** Il drago usa uno dei seguenti soffi.\n\n***Soffio di freddo.*** Il drago esala una folata gelida in un cono di 9 metri. Ogni creatura in quell'area deve effettuare un tiro salvezza su Costituzione con CD 17, subendo 54 (12d8) danni da freddo in caso di fallimento, o la metà dei danni in caso di successo.\n\n***Soffio paralizzante.*** Il drago esala gas paralizzante in un cono di 9 metri. Ogni creatura in quell'area deve superare un tiro salvezza su Costituzione con CD 17, altrimenti è paralizzata per 1 minuto. La creatura può ripetere il tiro salvezza alla fine di ogni suo turno e, se lo supera, l'effetto svanisce.",
			"",
			"",
			"",
			""),
		new Text(
			"Young Silver Dragon",
			null,
			"Large dragon, lawful good",
			"18 (natural armor)",
			"40 ft., fly 80 ft.",
			"Dex +4, Con +9, Wis +4, Cha +8",
			"Arcana +6, History +6, Perception +8, Stealth +4",
			"",
			"",
			"cold",
			"",
			"blindsight 30 ft., darkvision 120 ft., passive Perception 18",
			"Common, Draconic",
			"",
			"***Multiattack.*** The dragon makes three attacks: one with its bite and two with its claws.\n\n***Bite.*** *Melee Weapon Attack:* +10 to hit, reach 10 ft., one target. *Hit:* 17 (2d10 + 6) piercing damage.\n\n***Claw.*** *Melee Weapon Attack:* +10 to hit, reach 5 ft., one target. *Hit:* 13 (2d6 + 6) slashing damage.\n\n***Breath Weapons (Recharge 5–6).*** The dragon uses one of the following breath weapons.\n\nCold Breath. The dragon exhales an icy blast in a 30-foot cone. Each creature in that area must make a DC 17 Constitution saving throw, taking 54 (12d8) cold damage on a failed save, or half as much damage on a successful one.\nParalyzing Breath. The dragon exhales paralyzing gas in a 30-foot cone. Each creature in that area must succeed on a DC 17 Constitution saving throw or be paralyzed for 1 minute. A creature can repeat the saving throw at the end of each of its turns, ending the effect on itself on a success.",
			"",
			"",
			"",
			""));
}
