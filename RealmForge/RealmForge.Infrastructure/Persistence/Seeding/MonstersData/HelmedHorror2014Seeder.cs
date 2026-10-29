using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Helmed Horror (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class HelmedHorror2014Seeder
{
	public static Monster Build() => Create("helmed-horror", null, ContentSource.RealmForge, CreatureSize.Medium, CreatureType.Construct,
		20, 60, "8d8 + 24", 30, new[] { 18, 13, 16, 10, 10, 10 }, 4m, 1100, 2, 14,
		new Text(
			"Orrore corazzato",
			null,
			"Costrutto Medio, neutrale",
			"20 (armatura completa, scudo)",
			"9 m, volare 9 m",
			"",
			"Percezione +4",
			"",
			"contundenti, perforanti e taglienti da attacchi non magici con armi non adamantine",
			"forza, necrotici, veleno",
			"accecato, affascinato, assordato, avvelenato, paralizzato, pietrificato, spaventato, stordito",
			"Percezione passiva 14, vista cieca 18 m (cieco oltre questo raggio)",
			"capisce i linguaggi del suo creatore ma non li parla",
			"***Resistenza alla magia.*** L'orrore corazzato dispone di vantaggio ai tiri salvezza contro incantesimi e altri effetti magici.\n\n***Immunità agli incantesimi.*** L'orrore corazzato è immune a tre incantesimi scelti da chi lo ha costruito; scelte comuni sono *palla di fuoco*, *riscaldare il metallo* e *fulmine*.",
			"***Multiattacco.*** L'orrore corazzato effettua due attacchi con la spada lunga.\n\n***Spada lunga.*** *Attacco con arma da mischia:* +6 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 8 (1d8 + 4) danni taglienti, o 9 (1d10 + 4) danni taglienti se impugnata a due mani.",
			"",
			"",
			"",
			""),
		new Text(
			"Helmed Horror",
			null,
			"Medium construct, neutral",
			"20 (plate, shield)",
			"30 ft., fly 30 ft.",
			"",
			"Perception +4",
			"",
			"bludgeoning, piercing, and slashing from nonmagical attacks that aren't adamantine",
			"force, necrotic, poison",
			"blinded, charmed, deafened, frightened, paralyzed, petrified, poisoned, stunned",
			"blindsight 60 ft. (blind beyond this radius), passive Perception 14",
			"understands the languages of its creator but can't speak",
			"***Magic Resistance.*** The helmed horror has advantage on saving throws against spells and other magical effects.\n\n***Spell Immunity.*** The helmed horror is immune to three spells chosen by whoever made it; fireball, heat metal and lightning bolt are common choices.",
			"***Multiattack.*** The helmed horror makes two longsword attacks.\n\n***Longsword.*** *Melee Weapon Attack:* +6 to hit, reach 5 ft., one target. *Hit:* 8 (1d8 + 4) slashing damage, or 9 (1d10 + 4) slashing damage if used with two hands.",
			"",
			"",
			"",
			""));
}
