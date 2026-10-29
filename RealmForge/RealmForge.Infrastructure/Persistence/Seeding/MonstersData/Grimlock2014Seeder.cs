using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Grimlock (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Grimlock2014Seeder
{
	public static Monster Build() => Create("grimlock", null, ContentSource.Srd51, CreatureSize.Medium, CreatureType.Humanoid,
		11, 11, "2d8 + 2", 30, new[] { 16, 12, 12, 9, 8, 6 }, 0.25m, 50, 2, 13,
		new Text(
			"Grimlock",
			null,
			"Umanoide Medio (grimlock), neutrale malvagio",
			"11",
			"9 m",
			"",
			"Atletica +5, Furtività +3, Percezione +3",
			"",
			"",
			"",
			"accecato",
			"Percezione passiva 13, vista cieca 9 m o 3 m finché assordato (cieco oltre questo raggio)",
			"Sottocomune",
			"***Mimetizzazione rocciosa.*** Il grimlock dispone di vantaggio alle prove di Destrezza (Furtività) effettuate per nascondersi nei terreni rocciosi.\n\n***Percezione cieca.*** Il grimlock non può usare la sua vista cieca finché è assordato e non ha olfatto.\n\n***Udito e olfatto acuti.*** Il grimlock dispone di vantaggio alle prove di Saggezza (Percezione) basate sull'olfatto o sull'udito.",
			"***Clava di osso chiodata.*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 5 (1d4 + 3) danni contundenti più 2 (1d4) danni perforanti.",
			"",
			"",
			"",
			""),
		new Text(
			"Grimlock",
			null,
			"Medium humanoid (grimlock), neutral evil",
			"11",
			"30 ft.",
			"",
			"Athletics +5, Perception +3, Stealth +3",
			"",
			"",
			"",
			"blinded",
			"blindsight 30 ft. or 10 ft. while deafened (blind beyond this radius), passive Perception 13",
			"Undercommon",
			"***Blind Senses.*** The grimlock can't use its blindsight while deafened and unable to smell.\n\n***Keen Hearing and Smell.*** The grimlock has advantage on Wisdom (Perception) checks that rely on hearing or smell.\n\n***Stone Camouflage.*** The grimlock has advantage on Dexterity (Stealth) checks made to hide in rocky terrain.",
			"***Spiked Bone Club.*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one target. *Hit:* 5 (1d4 + 3) bludgeoning damage plus 2 (1d4) piercing damage.",
			"",
			"",
			"",
			""));
}
