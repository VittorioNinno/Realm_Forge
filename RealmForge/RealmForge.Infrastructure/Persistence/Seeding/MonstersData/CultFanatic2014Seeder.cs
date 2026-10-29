using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Cult Fanatic (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class CultFanatic2014Seeder
{
	public static Monster Build() => Create("cult-fanatic", null, CreatureSize.Medium, CreatureType.Humanoid,
		13, 33, "6d8 + 6", 30, new[] { 11, 14, 12, 10, 13, 14 }, 2m, 450, 2, 11,
		new Text(
			"Cultista fanatico",
			null,
			"Umanoide Medio (qualsiasi razza), qualsiasi allineamento non buono",
			"13 (armatura di cuoio)",
			"9 m",
			"",
			"Inganno +4, Persuasione +4, Religione +2",
			"",
			"",
			"",
			"",
			"Percezione passiva 11",
			"uno qualsiasi (di solito Comune)",
			"***Devozione oscura.*** Il fanatico dispone di vantaggio ai tiri salvezza contro le condizioni affascinato e spaventato.\n\n***Incantesimi.*** Il fanatico è un incantatore di 4° livello: la sua caratteristica da incantatore è Saggezza (CD del tiro salvezza sull'incantesimo 11, +3 al tiro per colpire con attacco con incantesimo). Il fanatico ha a disposizione i seguenti incantesimi da chierico:\n\n- Trucchetti (a volontà): *fiamma sacra, luce, taumaturgia*\n- 1° livello (4 slot): *comando, infliggi ferite, scudo della fede*\n- 2° livello (3 slot): *arma spirituale, blocca persone*",
			"***Multiattacco.*** Il fanatico effettua due attacchi in mischia.\n\n***Pugnale.*** *Attacco con arma da mischia o a distanza:* +4 al tiro per colpire, portata 1,5 m o gittata 6/18 m, una creatura. *Colpito:* 4 (1d4 + 2) danni perforanti.",
			"",
			""),
		new Text(
			"Cult Fanatic",
			null,
			"Medium humanoid (any race), any non-good alignment",
			"13 (leather armor)",
			"30 ft.",
			"",
			"Deception +4, Persuasion +4, Religion +2",
			"",
			"",
			"",
			"",
			"passive Perception 11",
			"any one language (usually Common)",
			"***Dark Devotion.*** The fanatic has advantage on saving throws against being charmed or frightened.\n\n***Spellcasting.*** The fanatic is a 4th-level spellcaster. Its spell casting ability is Wisdom (spell save DC 11, +3 to hit with spell attacks). The fanatic has the following cleric spells prepared:\n\n\nCantrips (at will): light, sacred flame, thaumaturgy\n- 1st level (4 slots): *command, inflict wounds, shield of faith*\n- 2nd level (3 slots): *hold person, spiritual weapon*",
			"***Multiattack.*** The fanatic makes two melee attacks.\n\n***Dagger.*** *Melee or Ranged Weapon Attack:* +4 to hit, reach 5 ft. or range 20/60 ft., one creature. *Hit:* 4 (1d4 + 2) piercing damage.",
			"",
			""));
}
