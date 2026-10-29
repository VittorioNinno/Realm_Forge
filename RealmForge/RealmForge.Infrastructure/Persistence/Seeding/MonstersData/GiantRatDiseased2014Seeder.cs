using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Giant Rat (Diseased) (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class GiantRatDiseased2014Seeder
{
	public static Monster Build() => Create("giant-rat-diseased", "giant-rat", CreatureSize.Small, CreatureType.Beast,
		12, 7, "2d6", 30, new[] { 7, 15, 11, 2, 10, 4 }, 0.125m, 25, 2, 10,
		new Text(
			"Topo gigante contagioso",
			null,
			"Bestia Piccola, senza allineamento",
			"12",
			"9 m",
			"",
			"",
			"",
			"",
			"",
			"",
			"Percezione passiva 10, scurovisione 18 m",
			"—",
			"***Olfatto acuto.*** Il topo dispone di vantaggio alle prove di Saggezza (Percezione) basate sull'olfatto.\n\n***Tattiche del branco.*** Il topo dispone di vantaggio nel tiro per colpire contro una creatura se almeno uno degli alleati del topo si trova entro 1,5 metri da essa e non è incapacitato.",
			"***Morso.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 4 (1d4 + 2) danni perforanti. Se il bersaglio è una creatura, deve superare un tiro salvezza su Costituzione con CD 10, altrimenti contrae una malattia. Finché la malattia non viene curata, il bersaglio non può recuperare punti ferita se non tramite mezzi magici e i suoi punti ferita massimi si riducono di 3 (1d6) ogni 24 ore. Se la malattia fa scendere i suoi punti ferita massimi a 0, il bersaglio muore.",
			"",
			""),
		new Text(
			"Giant Rat (Diseased)",
			null,
			"Small beast, unaligned",
			"12",
			"30 ft.",
			"",
			"",
			"",
			"",
			"",
			"",
			"darkvision 60 ft., passive Perception 10",
			"—",
			"***Keen Smell.*** The rat has advantage on Wisdom (Perception) checks that rely on smell.\n\n***Pack Tactics.*** The rat has advantage on an attack roll against a creature if at least one of the rat's allies is within 5 ft. of the creature and the ally isn't incapacitated.",
			"***Bite.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one target. *Hit:* 4 (1d4 + 2) piercing damage. If the target is a creature, it must succeed on a DC 10 Constitution saving throw or contract a disease. Until the disease is cured, the target can't regain hit points except by magical means, and the target's hit point maximum decreases by 3 (1d6) every 24 hours. If the target's hit point maximum drops to 0 as a result of this disease, the target dies.",
			"",
			""));
}
