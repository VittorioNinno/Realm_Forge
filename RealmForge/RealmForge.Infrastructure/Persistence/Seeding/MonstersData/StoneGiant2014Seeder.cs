using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Stone Giant (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class StoneGiant2014Seeder
{
	public static Monster Build() => Create("stone-giant", null, ContentSource.Srd51, CreatureSize.Huge, CreatureType.Giant,
		17, 126, "11d12 + 55", 40, new[] { 23, 15, 20, 10, 12, 9 }, 7m, 2900, 3, 14,
		new Text(
			"Gigante delle pietre",
			null,
			"Gigante Enorme, neutrale",
			"17 (armatura naturale)",
			"12 m",
			"Cos +8, Des +5, Sag +4",
			"Atletica +12, Percezione +4",
			"",
			"",
			"",
			"",
			"Percezione passiva 14, scurovisione 18 m",
			"Gigante",
			"***Mimetizzazione rocciosa.*** Il gigante dispone di vantaggio alle prove di Destrezza (Furtività) effettuate per nascondersi nei terreni rocciosi.",
			"***Multiattacco.*** Il gigante effettua due attacchi con il randello pesante.\n\n***Randello pesante.*** *Attacco con arma da mischia:* +9 al tiro per colpire, portata 4,5 m, un bersaglio. *Colpito:* 19 (3d8 + 6) danni contundenti.\n\n***Roccia.*** *Attacco con arma a distanza:* +9 al tiro per colpire, gittata 18/72 m, un bersaglio. *Colpito:* 28 (4d10 + 6) danni contundenti. Se il bersaglio è una creatura, deve superare un tiro salvezza su Forza con CD 17, altrimenti viene buttato a terra prono.",
			"",
			"***Afferrare roccia.*** Se una roccia o un oggetto simile viene scagliato contro il gigante, quest'ultimo può afferrarlo superando un tiro salvezza su Destrezza con CD 10, nel qual caso non subisce danni contundenti da esso.",
			"",
			""),
		new Text(
			"Stone Giant",
			null,
			"Huge giant, neutral",
			"17 (natural armor)",
			"40 ft.",
			"Dex +5, Con +8, Wis +4",
			"Athletics +12, Perception +4",
			"",
			"",
			"",
			"",
			"darkvision 60 ft., passive Perception 14",
			"Giant",
			"***Stone Camouflage.*** The giant has advantage on Dexterity (Stealth) checks made to hide in rocky terrain.",
			"***Multiattack.*** The giant makes two greatclub attacks.\n\n***Greatclub.*** *Melee Weapon Attack:* +9 to hit, reach 15 ft., one target. *Hit:* 19 (3d8 + 6) bludgeoning damage.\n\n***Rock.*** *Ranged Weapon Attack:* +9 to hit, range 60/240 ft., one target. *Hit:* 28 (4d10 + 6) bludgeoning damage. If the target is a creature, it must succeed on a DC 17 Strength saving throw or be knocked prone.",
			"",
			"***Rock Catching.*** If a rock or similar object is hurled at the giant, the giant can, with a successful DC 10 Dexterity saving throw, catch the missile and take no bludgeoning damage from it.",
			"",
			""));
}
