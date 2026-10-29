using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Mage (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Mage2014Seeder
{
	public static Monster Build() => Create("mage", null, ContentSource.Srd51, CreatureSize.Medium, CreatureType.Humanoid,
		12, 40, "9d8", 30, new[] { 9, 14, 11, 17, 12, 11 }, 6m, 2300, 3, 11,
		new Text(
			"Mago",
			null,
			"Umanoide Medio (qualsiasi razza), qualsiasi allineamento",
			"12 (15 con armatura magica)",
			"9 m",
			"Int +6, Sag +4",
			"Arcano +6, Storia +6",
			"",
			"",
			"",
			"",
			"Percezione passiva 11",
			"quattro qualsiasi",
			"***Incantesimi.*** Il mago è un incantatore di 9° livello: la sua caratteristica da incantatore è Intelligenza (CD del tiro salvezza sull'incantesimo 14, +6 al tiro per colpire con attacco con incantesimo). Ha a disposizione i seguenti incantesimi da mago:\n\n- Trucchetti (a volontà): *dardo di fuoco, luce, mano magica, prestidigitazione*\n- 1° livello (4 slot): *dardo di fuoco, luce, mano magica, prestidigitazione*\n- 2° livello (3 slot): *passo velato, suggestione*\n- 3° livello (3 slot): *controincantesimo, palla di fuoco, volare*\n- 4° livello (3 slot): *invisibilità superiore, tempesta di ghiaccio*\n- 5° livello (1 slot): *cono di freddo*",
			"***Pugnale.*** *Attacco con arma da mischia o con arma a distanza:* +5 al tiro per colpire, portata 1,5 m o gittata 6/18 m, un bersaglio. *Colpito:* 4 (1d4 + 2) danni perforanti.",
			"",
			"",
			"",
			""),
		new Text(
			"Mage",
			null,
			"Medium humanoid (any race), any alignment",
			"12 (15 with mage armor)",
			"30 ft.",
			"Int +6, Wis +4",
			"Arcana +6, History +6",
			"",
			"",
			"",
			"",
			"passive Perception 11",
			"any four languages",
			"***Spellcasting.*** The mage is a 9th-level spellcaster. Its spellcasting ability is Intelligence (spell save DC 14, +6 to hit with spell attacks). The mage has the following wizard spells prepared:\n\n- Cantrips (at will): *fire bolt, light, mage hand, prestidigitation*\n- 1st level (4 slots): *detect magic, mage armor, magic missile, shield*\n- 2nd level (3 slots): *misty step, suggestion*\n- 3rd level (3 slots): *counterspell, fireball, fly*\n- 4th level (3 slots): *greater invisibility, ice storm*\n- 5th level (1 slot): *cone of cold*",
			"***Dagger.*** *Melee or Ranged Weapon Attack:* +5 to hit, reach 5 ft. or range 20/60 ft., one target. *Hit:* 4 (1d4 + 2) piercing damage.",
			"",
			"",
			"",
			""));
}
