using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Young White Dragon (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class YoungWhiteDragon2014Seeder
{
	public static Monster Build() => Create("young-white-dragon", null, CreatureSize.Large, CreatureType.Dragon,
		17, 133, "14d10 + 56", 40, new[] { 18, 10, 18, 6, 11, 12 }, 6m, 2300, 3, 16,
		new Text(
			"Drago bianco giovane",
			null,
			"Drago Grande, caotico malvagio",
			"17 (armatura naturale)",
			"12 m, nuotare 12 m, scavare 6 m, volare 24 m",
			"Car +4, Cos +7, Des +3, Sag +3",
			"Furtività +3, Percezione +6",
			"",
			"",
			"freddo",
			"",
			"Percezione passiva 16, scurovisione 36 m, vista cieca 9 m",
			"Comune, Draconico",
			"***Camminare sul ghiaccio.*** Il drago può muoversi sulle superfici di ghiaccio e scalarle senza bisogno di effettuare una prova di caratteristica. Inoltre, un terreno difficile costituito da ghiaccio o neve non gli costa alcun movimento aggiuntivo.",
			"***Multiattacco.*** Il drago effettua tre attacchi: uno con il morso e due con gli artigli.\n\n***Artiglio.*** *Attacco con arma da mischia:* +7 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 11 (2d6 + 4) danni taglienti.\n\n***Morso.*** *Attacco con arma da mischia:* +7 al tiro per colpire, portata 3 m, un bersaglio. *Colpito:* 15 (2d10 + 4) danni perforanti più 4 (1d8) danni da freddo.\n\n***Soffio di freddo (ricarica 5–6).*** Il drago esala una folata gelida in un cono di 9 metri. Ogni creatura in quell'area deve effettuare un tiro salvezza su Costituzione con CD 15, subendo 45 (10d8) danni da freddo in caso di fallimento, o la metà dei danni in caso di successo.",
			"",
			""),
		new Text(
			"Young White Dragon",
			null,
			"Large dragon, chaotic evil",
			"17 (natural armor)",
			"40 ft., burrow 20 ft., fly 80 ft., swim 40 ft.",
			"Dex +3, Con +7, Wis +3, Cha +4",
			"Perception +6, Stealth +3",
			"",
			"",
			"cold",
			"",
			"blindsight 30 ft., darkvision 120 ft., passive Perception 16",
			"Common, Draconic",
			"***Ice Walk.*** The dragon can move across and climb icy surfaces without needing to make an ability check. Additionally, difficult terrain composed of ice or snow doesn't cost it extra movement.",
			"***Multiattack.*** The dragon makes three attacks: one with its bite and two with its claws.\n\n***Bite.*** *Melee Weapon Attack:* +7 to hit, reach 10 ft., one target. *Hit:* 15 (2d10 + 4) piercing damage plus 4 (1d8) cold damage.\n\n***Claw.*** *Melee Weapon Attack:* +7 to hit, reach 5 ft., one target. *Hit:* 11 (2d6 + 4) slashing damage.\n\n***Cold Breath (Recharge 5–6).*** The dragon exhales an icy blast in a 30-foot cone. Each creature in that area must make a DC 15 Constitution saving throw, taking 45 (10d8) cold damage on a failed save, or half as much damage on a successful one.",
			"",
			""));
}
