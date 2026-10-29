using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Gladiator (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Gladiator2014Seeder
{
	public static Monster Build() => Create("gladiator", null, ContentSource.Srd51, CreatureSize.Medium, CreatureType.Humanoid,
		16, 112, "15d8 + 45", 30, new[] { 18, 15, 16, 10, 12, 15 }, 5m, 1800, 3, 11,
		new Text(
			"Gladiatore",
			null,
			"Umanoide Medio (qualsiasi razza), qualsiasi allineamento",
			"16 (cuoio borchiato, scudo)",
			"9 m",
			"Cos +6, Des +5, For +7",
			"Atletica +10, Intimidire +5",
			"",
			"",
			"",
			"",
			"Percezione passiva 11",
			"uno qualsiasi (di solito Comune)",
			"***Bruto.*** Quando il gladiatore colpisce con un'arma da mischia, l'attacco infligge un dado extra del tipo di danno dell'arma (già incluso nell'attacco).\n\n***Impavido.*** Il gladiatore dispone di vantaggio ai tiri salvezza contro la condizione spaventato.",
			"***Multiattacco.*** Il gladiatore sferra tre attacchi in mischia o due attacchi a distanza.\n\n***Lancia.*** *Attacco con arma da mischia o con arma a distanza:* +7 al tiro per colpire, portata 1,5 m o gittata 6/18 m, un bersaglio. *Colpito:* 11 (2d6 + 4) danni perforanti o 13 (2d8 + 4) danni perforanti se usata a due mani per effettuare un attacco in mischia.\n\n***Scudo da sfondamento.*** *Attacco con arma da mischia:* +7 al tiro per colpire, portata 1,5 m, una creatura. *Colpito:* 9 (2d4 + 4) danni contundenti. Se il bersaglio è una creatura di taglia Media o inferiore, deve superare un tiro salvezza su Forza con CD 15, altrimenti viene buttato a terra prono.",
			"",
			"***Parata.*** Il gladiatore aggiunge 3 alla sua CA contro un attacco in mischia che lo colpirebbe. Per farlo, deve vedere l'attaccante e deve impugnare un'arma da mischia.",
			"",
			""),
		new Text(
			"Gladiator",
			null,
			"Medium humanoid (any race), any alignment",
			"16 (studded leather armor, shield)",
			"30 ft.",
			"Str +7, Dex +5, Con +6",
			"Athletics +10, Intimidation +5",
			"",
			"",
			"",
			"",
			"passive Perception 11",
			"any one language (usually Common)",
			"***Brave.*** The gladiator has advantage on saving throws against being frightened.\n\n***Brute.*** A melee weapon deals one extra die of its damage when the gladiator hits with it (included in the attack).",
			"***Multiattack.*** The gladiator makes three melee attacks or two ranged attacks.\n\n***Spear.*** *Melee or Ranged Weapon Attack:* +7 to hit, reach 5 ft. or range 20/60 ft., one target. *Hit:* 11 (2d6 + 4) piercing damage, or 13 (2d8 + 4) piercing damage if used with two hands to make a melee attack.\n\n***Shield Bash.*** *Melee Weapon Attack:* +7 to hit, reach 5 ft., one creature. *Hit:* 9 (2d4 + 4) bludgeoning damage. If the target is a Medium or smaller creature, it must succeed on a DC 15 Strength saving throw or be knocked prone.",
			"",
			"***Parry.*** The gladiator adds 3 to its AC against one melee attack that would hit it. To do so, the gladiator must see the attacker and be wielding a melee weapon.",
			"",
			""));
}
