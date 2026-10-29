using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Goristro (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class Goristro2014Seeder
{
	public static Monster Build() => Create("goristro", null, ContentSource.RealmForge, CreatureSize.Huge, CreatureType.Fiend,
		19, 310, "23d12 + 161", 40, new[] { 25, 11, 25, 6, 13, 14 }, 17m, 18000, 6, 17,
		new Text(
			"Goristro",
			null,
			"Immondo Enorme (demone), caotico malvagio",
			"19 (armatura naturale)",
			"12 m",
			"Cos +13, Des +6, For +13, Sag +7",
			"Percezione +7",
			"",
			"freddo, fuoco, fulmine; contundenti, perforanti e taglienti da attacchi non magici",
			"veleno",
			"avvelenato",
			"Percezione passiva 17, scurovisione 36 m",
			"Abissale",
			"***Carica.*** Se il goristro si muove di almeno 4,5 metri in linea retta verso un bersaglio e poi lo colpisce con un attacco di incornata nello stesso turno, il bersaglio subisce 38 (7d10) danni perforanti extra; se è una creatura deve anche superare un tiro salvezza su Forza con CD 21, altrimenti viene spinto fino a 6 metri di distanza e cade prono.\n\n***Memoria labirintica.*** Il goristro ricorda alla perfezione ogni percorso che abbia mai seguito.\n\n***Resistenza alla magia.*** Il goristro dispone di vantaggio ai tiri salvezza contro incantesimi e altri effetti magici.\n\n***Mostro da assedio.*** Il goristro infligge danni doppi a oggetti e strutture.",
			"***Multiattacco.*** Il goristro effettua tre attacchi: due con i pugni e uno con lo zoccolo.\n\n***Pugno.*** *Attacco con arma da mischia:* +13 al tiro per colpire, portata 3 m, un bersaglio. *Colpito:* 20 (3d8 + 7) danni contundenti.\n\n***Zoccolo.*** *Attacco con arma da mischia:* +13 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 23 (3d10 + 7) danni contundenti. Una creatura colpita deve superare un tiro salvezza su Forza con CD 21, altrimenti cade prona.\n\n***Incornata.*** *Attacco con arma da mischia:* +13 al tiro per colpire, portata 3 m, un bersaglio. *Colpito:* 45 (7d10 + 7) danni perforanti.",
			"",
			"",
			"",
			""),
		new Text(
			"Goristro",
			null,
			"Huge fiend (demon), chaotic evil",
			"19 (natural armor)",
			"40 ft.",
			"Str +13, Dex +6, Con +13, Wis +7",
			"Perception +7",
			"",
			"cold, fire, lightning; bludgeoning, piercing, and slashing from nonmagical attacks",
			"poison",
			"poisoned",
			"darkvision 120 ft., passive Perception 17",
			"Abyssal",
			"***Charge.*** If the goristro moves at least 15 feet straight toward a target and then hits it with a gore attack on the same turn, the target takes an extra 38 (7d10) piercing damage; a creature must also succeed on a DC 21 Strength saving throw or be pushed up to 20 feet away and knocked prone.\n\n***Labyrinthine Recall.*** The goristro remembers flawlessly every route it has ever traveled.\n\n***Magic Resistance.*** The goristro has advantage on saving throws against spells and other magical effects.\n\n***Siege Monster.*** The goristro deals double damage to objects and structures.",
			"***Multiattack.*** The goristro makes three attacks: two fist attacks and one hoof attack.\n\n***Fist.*** *Melee Weapon Attack:* +13 to hit, reach 10 ft., one target. *Hit:* 20 (3d8 + 7) bludgeoning damage.\n\n***Hoof.*** *Melee Weapon Attack:* +13 to hit, reach 5 ft., one target. *Hit:* 23 (3d10 + 7) bludgeoning damage. A creature hit must succeed on a DC 21 Strength saving throw or be knocked prone.\n\n***Gore.*** *Melee Weapon Attack:* +13 to hit, reach 10 ft., one target. *Hit:* 45 (7d10 + 7) piercing damage.",
			"",
			"",
			"",
			""));
}
