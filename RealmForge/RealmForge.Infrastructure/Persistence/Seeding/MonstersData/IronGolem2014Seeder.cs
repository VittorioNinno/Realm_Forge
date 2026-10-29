using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Iron Golem (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class IronGolem2014Seeder
{
	public static Monster Build() => Create("iron-golem", null, CreatureSize.Large, CreatureType.Construct,
		20, 210, "20d10 + 100", 30, new[] { 24, 9, 20, 3, 11, 1 }, 16m, 15000, 5, 10,
		new Text(
			"Golem di ferro",
			null,
			"Costrutto Grande, senza allineamento",
			"20 (armatura naturale)",
			"9 m",
			"",
			"",
			"",
			"",
			"fuoco, psichici, veleno; contundenti, perforanti e taglienti da attacchi non magici non adamantini",
			"affascinato, avvelenato, indebolimento, paralizzato, pietrificato, spaventato",
			"Percezione passiva 10, scurovisione 36 m",
			"comprende i linguaggi del suo creatore ma non li sa parlare",
			"***Armi magiche.*** Gli attacchi con arma del golem sono magici.\n\n***Assorbimento del fuoco.*** Ogni volta che il golem riceve danni da fuoco, non subisce danni e anzi recupera invece un numero di punti ferita pari ai danni da fuoco inflitti.\n\n***Forma immutabile.*** Il golem è immune a qualsiasi incantesimo o effetto che ne altererebbe la forma.\n\n***Resistenza alla magia.*** Il golem dispone di vantaggio ai tiri salvezza contro incantesimi e altri effetti magici.",
			"***Multiattacco.*** Il golem effettua due attacchi in mischia.\n\n***Schianto.*** *Attacco con arma da mischia:* +13 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 20 (3d8 + 7) danni contundenti.\n\n***Spada.*** *Attacco con arma da mischia:* +13 al tiro per colpire, portata 3 m, un bersaglio. *Colpito:* 23 (3d10 + 7) danni taglienti.\n\n***Soffio di veleno (ricarica 6).*** Il golem esala gas velenoso in un cono di 4,5 metri. Ogni creatura in quell'area deve effettuare un tiro salvezza su Costituzione con CD 19, subendo 45 (10d8) danni da veleno in caso di fallimento, o la metà dei danni in caso di successo.",
			"",
			""),
		new Text(
			"Iron Golem",
			null,
			"Large construct, unaligned",
			"20 (natural armor)",
			"30 ft.",
			"",
			"",
			"",
			"",
			"fire, poison, psychic; bludgeoning, piercing, and slashing from nonmagical weapons that aren't adamantine",
			"charmed, exhaustion, frightened, paralyzed, petrified, poisoned",
			"darkvision 120 ft., passive Perception 10",
			"understands the languages of its creator but can't speak",
			"***Fire Absorption.*** Whenever the golem is subjected to fire damage, it takes no damage and instead regains a number of hit points equal to the fire damage dealt.\n\n***Immutable Form.*** The golem is immune to any spell or effect that would alter its form.\n\n***Magic Resistance.*** The golem has advantage on saving throws against spells and other magical effects.\n\n***Magic Weapons.*** The golem's weapon attacks are magical.",
			"***Multiattack.*** The golem makes two melee attacks.\n\n***Slam.*** *Melee Weapon Attack:* +13 to hit, reach 5 ft., one target. *Hit:* 20 (3d8 + 7) bludgeoning damage.\n\n***Sword.*** *Melee Weapon Attack:* +13 to hit, reach 10 ft., one target. *Hit:* 23 (3d10 + 7) slashing damage.\n\n***Poison Breath (Recharge 5–6).*** The golem exhales poisonous gas in a 15-foot cone. Each creature in that area must make a DC 19 Constitution saving throw, taking 45 (10d8) poison damage on a failed save, or half as much damage on a successful one.",
			"",
			""));
}
