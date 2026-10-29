using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Half-Red Dragon Veteran (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class HalfRedDragonVeteran2014Seeder
{
	public static Monster Build() => Create("half-red-dragon-veteran", null, ContentSource.Srd51, CreatureSize.Medium, CreatureType.Humanoid,
		18, 65, "10d8 + 20", 30, new[] { 16, 13, 14, 10, 11, 10 }, 5m, 1800, 3, 12,
		new Text(
			"Mezzodrago rosso veterano",
			null,
			"Umanoide Medio (umano), qualsiasi allineamento",
			"18 (piastre)",
			"9 m",
			"",
			"Atletica +5, Percezione +2",
			"",
			"fuoco",
			"",
			"",
			"Percezione passiva 12, scurovisione 18 m, vista cieca 3 m",
			"Comune, Draconico",
			"",
			"***Multiattacco.*** Il veterano sferra due attacchi con la spada lunga. Se ha sfoderato una spada corta, può effettuare anche un attacco con quest'ultima.\n\n***Spada corta.*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 6 (1d6 + 3) danni perforanti.\n\n***Spada lunga.*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 7 (1d8 + 3) danni taglienti o 8 (1d10 + 3) danni taglienti se impugnata con due mani.\n\n***Balestra pesante.*** *Attacco con arma a distanza:* +3 al tiro per colpire, gittata 30/120 m, un bersaglio. *Colpito:* 6 (1d10 + 1) danni perforanti.\n\n***Soffio di fuoco (ricarica 5–6).*** Il veterano esala fuoco in un cono di 4,5 metri. Ogni creatura in quell'area deve effettuare un tiro salvezza su Destrezza con CD 15, subendo 24 (7d6) danni da fuoco in caso di fallimento, o la metà dei danni in caso di successo.",
			"",
			"",
			"",
			""),
		new Text(
			"Half-Red Dragon Veteran",
			null,
			"Medium humanoid (human), any alignment",
			"18 (plate armor)",
			"30 ft.",
			"",
			"Athletics +5, Perception +2",
			"",
			"fire",
			"",
			"",
			"blindsight 10 ft., darkvision 60 ft., passive Perception 12",
			"Common, Draconic",
			"",
			"***Multiattack.*** The veteran makes two longsword attacks. If it has a shortsword drawn, it can also make a shortsword attack.\n\n***Longsword.*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one target. *Hit:* 7 (1d8 + 3) slashing damage, or 8 (1d10 + 3) slashing damage if used with two hands.\n\n***Shortsword.*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one target. *Hit:* 6 (1d6 + 3) piercing damage.\n\n***Heavy Crossbow.*** *Ranged Weapon Attack:* +3 to hit, range 100/400 ft., one target. *Hit:* 6 (1d10 + 1) piercing damage.\n\n***Fire Breath (Recharge 5–6).*** The veteran exhales fire in a 15-foot cone. Each creature in that area must make a DC 15 Dexterity saving throw, taking 24 (7d6) fire damage on a failed save, or half as much damage on a successful one.",
			"",
			"",
			"",
			""));
}
