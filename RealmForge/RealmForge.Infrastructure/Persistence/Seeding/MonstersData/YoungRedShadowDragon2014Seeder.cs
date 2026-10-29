using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Young Red Shadow Dragon (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class YoungRedShadowDragon2014Seeder
{
	public static Monster Build() => Create("young-red-shadow-dragon", null, ContentSource.RealmForge, CreatureSize.Large, CreatureType.Dragon,
		18, 178, "17d10 + 85", 40, new[] { 23, 10, 21, 14, 11, 19 }, 13m, 10000, 5, 18,
		new Text(
			"Drago d'ombra rosso giovane",
			null,
			"Drago Grande, caotico malvagio",
			"18 (armatura naturale)",
			"12 m, scalare 12 m, volare 24 m",
			"Car +8, Cos +9, Des +4, Sag +4",
			"Furtività +8, Percezione +8",
			"",
			"necrotici",
			"fuoco",
			"",
			"Percezione passiva 18, scurovisione 36 m, vista cieca 9 m",
			"Comune, Draconico",
			"***Ombra vivente.*** In luce fioca o nell'oscurità, il drago ha resistenza a tutti i danni tranne quelli da forza, psichici e radiosi.\n\n***Furtività nell'ombra.*** In luce fioca o nell'oscurità, il drago può effettuare l'azione di Nascondersi come azione bonus.\n\n***Sensibilità alla luce del sole.*** Finché si trova alla luce del sole, il drago subisce svantaggio ai tiri per colpire e alle prove di Saggezza (Percezione) basate sulla vista.",
			"***Multiattacco.*** Il drago effettua tre attacchi: uno con il morso e due con gli artigli.\n\n***Morso.*** *Attacco con arma da mischia:* +10 al tiro per colpire, portata 3 m, un bersaglio. *Colpito:* 17 (2d10 + 6) danni perforanti più 3 (1d6) danni necrotici.\n\n***Artiglio.*** *Attacco con arma da mischia:* +10 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 13 (2d6 + 6) danni taglienti.\n\n***Soffio d'ombra (ricarica 5–6).*** Il drago esala fuoco d'ombra in un cono di 9 metri. Ogni creatura nel cono effettua un tiro salvezza su Destrezza con CD 18 e subisce 56 (16d6) danni necrotici se lo fallisce, o la metà se lo supera. Un umanoide ucciso da questi danni si rialza subito come un'ombra non morta al servizio del drago, che agisce subito dopo il drago nell'ordine di iniziativa.",
			"",
			"",
			"",
			""),
		new Text(
			"Young Red Shadow Dragon",
			null,
			"Large dragon, chaotic evil",
			"18 (natural armor)",
			"40 ft., climb 40 ft., fly 80 ft.",
			"Dex +4, Con +9, Wis +4, Cha +8",
			"Perception +8, Stealth +8",
			"",
			"necrotic",
			"fire",
			"",
			"blindsight 30 ft., darkvision 120 ft., passive Perception 18",
			"Common, Draconic",
			"***Living Shadow.*** In dim light or darkness, the dragon has resistance to all damage except force, psychic and radiant.\n\n***Shadow Stealth.*** In dim light or darkness, the dragon can take the Hide action as a bonus action.\n\n***Sunlight Sensitivity.*** While in sunlight, the dragon has disadvantage on attack rolls, as well as on Wisdom (Perception) checks that rely on sight.",
			"***Multiattack.*** The dragon makes three attacks: one bite and two claw attacks.\n\n***Bite.*** *Melee Weapon Attack:* +10 to hit, reach 10 ft., one target. *Hit:* 17 (2d10 + 6) piercing damage plus 3 (1d6) necrotic damage.\n\n***Claw.*** *Melee Weapon Attack:* +10 to hit, reach 5 ft., one target. *Hit:* 13 (2d6 + 6) slashing damage.\n\n***Shadow Breath (Recharge 5–6).*** The dragon breathes shadowy fire in a 30-foot cone. Each creature in the cone makes a DC 18 Dexterity saving throw, taking 56 (16d6) necrotic damage on a failure, or half as much on a success. A humanoid killed by this damage rises at once as an undead shadow under the dragon's control, acting right after the dragon in the initiative order.",
			"",
			"",
			"",
			""));
}
