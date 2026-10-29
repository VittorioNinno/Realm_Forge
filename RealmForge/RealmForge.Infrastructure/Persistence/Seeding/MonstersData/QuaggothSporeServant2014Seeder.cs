using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Quaggoth Spore Servant (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class QuaggothSporeServant2014Seeder
{
	public static Monster Build() => Create("quaggoth-spore-servant", null, ContentSource.RealmForge, CreatureSize.Medium, CreatureType.Plant,
		13, 45, "6d8 + 18", 20, new[] { 17, 12, 16, 2, 6, 1 }, 1m, 200, 2, 8,
		new Text(
			"Quaggoth servitore delle spore",
			null,
			"Vegetale Medio, senza allineamento",
			"13 (armatura naturale)",
			"6 m, scalare 6 m",
			"",
			"",
			"",
			"",
			"veleno",
			"accecato, affascinato, avvelenato, paralizzato, spaventato",
			"Percezione passiva 8, vista cieca 9 m (cieco oltre questo raggio)",
			"—",
			"",
			"***Multiattacco.*** Il servitore delle spore effettua due attacchi con gli artigli.\n\n***Artiglio.*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 6 (1d6 + 3) danni taglienti.",
			"",
			"",
			"",
			"Un servitore delle spore è una creatura morta, di taglia Grande o inferiore, rianimata dalle spore di un miconide sovrano (costrutti, elementali, melme, vegetali e non morti non possono diventarlo). Mantiene CA, punti ferita, Dadi Vita, Forza, Destrezza, Costituzione, vulnerabilità, resistenze e immunità; diventa un vegetale senza allineamento, perde le competenze nei tiri salvezza e nelle abilità, i sensi speciali, i tratti, i linguaggi e tutte le azioni tranne Multiattacco e gli attacchi con arma da mischia che infliggono danni contundenti, perforanti o taglienti; le sue velocità si riducono di 3 metri (minimo 1,5 metri); ha Int 2, Sag 6, Car 1, vista cieca 9 metri e immunità alle condizioni accecato, affascinato, paralizzato e spaventato, e obbedisce agli ordini dei miconidi. Questo quaggoth è un esempio."),
		new Text(
			"Quaggoth Spore Servant",
			null,
			"Medium plant, unaligned",
			"13 (natural armor)",
			"20 ft., climb 20 ft.",
			"",
			"",
			"",
			"",
			"poison",
			"blinded, charmed, frightened, paralyzed, poisoned",
			"blindsight 30 ft. (blind beyond this radius), passive Perception 8",
			"—",
			"",
			"***Multiattack.*** The spore servant makes two claw attacks.\n\n***Claw.*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one target. *Hit:* 6 (1d6 + 3) slashing damage.",
			"",
			"",
			"",
			"A spore servant is a dead creature, Large or smaller, raised by a myconid sovereign's spores (constructs, elementals, oozes, plants and undead can't become one). It keeps AC, hit points, Hit Dice, Strength, Dexterity, Constitution, vulnerabilities, resistances and immunities; it becomes an unaligned plant, loses saving throw and skill proficiencies, special senses, traits, languages and every action except Multiattack and melee weapon attacks dealing bludgeoning, piercing or slashing damage; its speeds drop by 10 feet (minimum 5 feet); it has Int 2, Wis 6, Cha 1, blindsight 30 feet and immunity to blinded, charmed, frightened and paralyzed, and obeys the myconids' orders. This quaggoth is an example."));
}
