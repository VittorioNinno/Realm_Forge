using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Cloud Giant (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class CloudGiant2014Seeder
{
	public static Monster Build() => Create("cloud-giant", null, ContentSource.Srd51, CreatureSize.Huge, CreatureType.Giant,
		14, 200, "16d12 + 96", 40, new[] { 27, 10, 22, 12, 16, 16 }, 9m, 5000, 4, 17,
		new Text(
			"Gigante delle nuvole",
			null,
			"Gigante Enorme, neutrale buono (50%) o neutrale malvagio (50%)",
			"14 (armatura naturale)",
			"12 m",
			"Car +7, Cos +10, Sag +7",
			"Intuizione +7, Percezione +7",
			"",
			"",
			"",
			"",
			"Percezione passiva 17",
			"Comune, Gigante",
			"***Incantesimi innati.*** La caratteristica innata da incantatore del gigante è Carisma. Per sua natura, è in grado di lanciare gli incantesimi indicati di seguito senza aver bisogno di componenti materiali:\n\n- A volontà: *individuazione del magico, luce, nube di nebbia*\n- 3/giorno ciascuno: *caduta morbida, passo velato, telecinesi, volare*\n- 1/giorno ciascuno: *controllare tempo atmosferico, forma gassosa*\n\n***Olfatto acuto.*** Il gigante dispone di vantaggio alle prove di Saggezza (Percezione) basate sull'olfatto.",
			"***Multiattacco.*** Il gigante effettua due attacchi con la mazza chiodata.\n\n***Mazza chiodata.*** *Attacco con arma da mischia:* +12 al tiro per colpire, portata 3 m, un bersaglio. *Colpito:* 21 (3d8 + 8) danni perforanti.\n\n***Roccia.*** *Attacco con arma a distanza:* +12 al tiro per colpire, gittata 18/72 m, un bersaglio. *Colpito:* 30 (4d10 + 8) danni contundenti.",
			"",
			"",
			"",
			""),
		new Text(
			"Cloud Giant",
			null,
			"Huge giant, neutral good (50%) or neutral evil (50%)",
			"14 (natural armor)",
			"40 ft.",
			"Con +10, Wis +7, Cha +7",
			"Insight +7, Perception +7",
			"",
			"",
			"",
			"",
			"passive Perception 17",
			"Common, Giant",
			"***Keen Smell.*** The giant has advantage on Wisdom (Perception) checks that rely on smell.\n\n***Innate Spellcasting.*** The giant's innate spellcasting ability is Charisma. It can innately cast the following spells, requiring no material components:\n\n\n- At will: *detect magic, fog cloud, light*\n- 3/day each: *feather fall, fly, misty step, telekinesis*\n- 1/day each: *control weather, gaseous form*",
			"***Multiattack.*** The giant makes two morningstar attacks.\n\n***Morningstar.*** *Melee Weapon Attack:* +12 to hit, reach 10 ft., one target. *Hit:* 21 (3d8 + 8) piercing damage.\n\n***Rock.*** *Ranged Weapon Attack:* +12 to hit, range 60/240 ft., one target. *Hit:* 30 (4d10 + 8) bludgeoning damage.",
			"",
			"",
			"",
			""));
}
