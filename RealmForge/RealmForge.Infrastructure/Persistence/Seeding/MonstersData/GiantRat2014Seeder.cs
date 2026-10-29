using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Giant Rat (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class GiantRat2014Seeder
{
	public static Monster Build() => Create("giant-rat", null, CreatureSize.Small, CreatureType.Beast,
		12, 7, "2d6", 30, new[] { 7, 15, 11, 2, 10, 4 }, 0.125m, 25, 2, 10,
		new Text(
			"Topo gigante",
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
			"***Olfatto acuto.*** Il topo dispone di vantaggio alle prove di Saggezza (Percezione) basate sull'olfatto.\n\n***Tattiche del branco.*** Il topo dispone di vantaggio nel tiro per colpire contro una creatura se almeno uno degli alleati del topo si trova entro 1,5 metri da essa e non è incapacitato.\n\n**Variante: topi giganti contagiosi.** Alcuni topi giganti sono portatori di orrende malattie che trasmettono con il morso. Un topo gigante contagioso ha un grado di sfida pari a 1/8 (25 PE) e possiede l'azione seguente al posto del normale attacco con il morso.",
			"***Morso.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 4 (1d4 + 2) danni perforanti.",
			"",
			""),
		new Text(
			"Giant Rat",
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
			"***Keen Smell.*** The rat has advantage on Wisdom (Perception) checks that rely on smell.\n\n***Pack Tactics.*** The rat has advantage on an attack roll against a creature if at least one of the rat's allies is within 5 ft. of the creature and the ally isn't incapacitated.\n\n**Variant: Diseased Giant Rats.** Some giant rats carry vile diseases that they spread with their bites. A diseased giant rat has a challenge rating of 1/8 (25 XP) and has the following action instead of its normal Bite attack.",
			"***Bite.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one target. *Hit:* 4 (1d4 + 2) piercing damage.",
			"",
			""));
}
