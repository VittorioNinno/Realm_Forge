using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Shadow Demon (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class ShadowDemon2014Seeder
{
	public static Monster Build() => Create("shadow-demon", null, ContentSource.RealmForge, CreatureSize.Medium, CreatureType.Fiend,
		13, 66, "12d8 + 12", 30, new[] { 1, 17, 12, 14, 13, 14 }, 4m, 1100, 2, 11,
		new Text(
			"Demone d'ombra",
			null,
			"Immondo Medio (demone), caotico malvagio",
			"13",
			"9 m, volare 9 m",
			"Car +4, Des +5",
			"Furtività +7",
			"radiosi",
			"acido, fuoco, necrotici, tuono; contundenti, perforanti e taglienti da attacchi non magici",
			"freddo, fulmine, veleno",
			"afferrato, avvelenato, indebolimento, paralizzato, pietrificato, prono, trattenuto",
			"Percezione passiva 11, scurovisione 36 m",
			"Abissale, telepatia 36 m",
			"***Movimento incorporeo.*** Il demone può attraversare creature e oggetti come se fossero terreno difficile. Se termina il turno all'interno di un oggetto, subisce 5 (1d10) danni da forza.\n\n***Sensibilità alla luce.*** In luce intensa, il demone subisce svantaggio ai tiri per colpire e alle prove di Saggezza (Percezione) basate sulla vista.\n\n***Furtività nell'ombra.*** In luce fioca o nell'oscurità, il demone può effettuare l'azione di Nascondersi come azione bonus.",
			"***Artigli.*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, una creatura. *Colpito:* 10 (2d6 + 3) danni psichici, o 17 (4d6 + 3) danni psichici se il demone disponeva di vantaggio al tiro per colpire.",
			"",
			"",
			"",
			""),
		new Text(
			"Shadow Demon",
			null,
			"Medium fiend (demon), chaotic evil",
			"13",
			"30 ft., fly 30 ft.",
			"Dex +5, Cha +4",
			"Stealth +7",
			"radiant",
			"acid, fire, necrotic, thunder; bludgeoning, piercing, and slashing from nonmagical attacks",
			"cold, lightning, poison",
			"exhaustion, grappled, paralyzed, petrified, poisoned, prone, restrained",
			"darkvision 120 ft., passive Perception 11",
			"Abyssal, telepathy 120 ft.",
			"***Incorporeal Movement.*** The demon can pass through creatures and objects as if they were difficult terrain. If it ends its turn inside an object, it takes 5 (1d10) force damage.\n\n***Light Sensitivity.*** In bright light, the demon has disadvantage on attack rolls and on Wisdom (Perception) checks that rely on sight.\n\n***Shadow Stealth.*** In dim light or darkness, the demon can take the Hide action as a bonus action.",
			"***Claws.*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one creature. *Hit:* 10 (2d6 + 3) psychic damage, or 17 (4d6 + 3) psychic damage if the demon had advantage on the attack roll.",
			"",
			"",
			"",
			""));
}
