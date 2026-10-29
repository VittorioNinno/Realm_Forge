using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Duergar (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Duergar2014Seeder
{
	public static Monster Build() => Create("duergar", null, CreatureSize.Medium, CreatureType.Humanoid,
		16, 26, "4d8 + 8", 25, new[] { 14, 11, 14, 11, 10, 9 }, 1m, 200, 2, 10,
		new Text(
			"Duergar",
			null,
			"Umanoide Medio (nano), legale malvagio",
			"16 (corazza a scaglie, scudo)",
			"7,5 m",
			"",
			"",
			"",
			"veleno",
			"",
			"",
			"Percezione passiva 10, scurovisione 36 m",
			"Nanico, Sottocomune",
			"***Resilienza del duergar.*** Il duergar dispone di vantaggio ai tiri salvezza contro veleno, incantesimi e illusioni, nonché per resistere alle condizioni di affascinato o paralizzato.\n\n***Sensibilità al sole.*** Finché è esposto alla luce del sole, il duergar subisce svantaggio ai tiri per colpire, oltre che alle prove di Saggezza (Percezione) basate sulla vista.",
			"***Ingrandire (ricarica dopo un riposo breve o lungo).*** Per 1 minuto, la taglia del duergar aumenta magicamente, insieme a ogni oggetto che indossa o trasporta. Mentre è ingrandito, il duergar è Grande, raddoppia i suoi dadi di danno per gli attacchi con armi basati sulla Forza (inclusi negli attacchi) ed effettua prove di Forza e tiri salvezza su Forza con un vantaggio. Se il duergar non ha lo spazio per diventare Grande, raggiunge la dimensione massima possibile nello spazio disponibile.\n\n***Piccone da guerra.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 6 (1d8 + 2) danni perforanti o 11 (2d8 + 2) danni perforanti quando è ingrandito.\n\n***Giavellotto.*** *Attacco con arma da mischia o a distanza:* +4 al tiro per colpire, portata 1,5 m o gittata 9/36 m, un bersaglio. *Colpito:* 5 (1d6 + 2) danni perforanti o 9 (2d6 + 2) danni perforanti quando è ingrandito.\n\n***Invisibilità (ricarica dopo un riposo breve o lungo).*** Il duergar diventa magicamente invisibile finché non attacca, non lancia un incantesimo o non usa Ingrandire, oppure finché non perde la concentrazione, fino a un massimo di 1 ora (come se si concentrasse su un incantesimo). Qualsiasi equipaggiamento che il duergar indossa o trasporta diventa invisibile.",
			"",
			""),
		new Text(
			"Duergar",
			null,
			"Medium humanoid (dwarf), lawful evil",
			"16 (scale mail, shield)",
			"25 ft.",
			"",
			"",
			"",
			"poison",
			"",
			"",
			"darkvision 120 ft., passive Perception 10",
			"Dwarvish, Undercommon",
			"***Duergar Resilience.*** The duergar has advantage on saving throws against poison, spells, and illusions, as well as to resist being charmed or paralyzed.\n\n***Sunlight Sensitivity.*** While in sunlight, the duergar has disadvantage on attack rolls, as well as on Wisdom (Perception) checks that rely on sight.",
			"***Enlarge (Recharges after a Short or Long Rest).*** For 1 minute, the duergar magically increases in size, along with anything it is wearing or carrying. While enlarged, the duergar is Large, doubles its damage dice on Strength-based weapon attacks (included in the attacks), and makes Strength checks and Strength saving throws with advantage. If the duergar lacks the room to become Large, it attains the maximum size possible in the space available.\n\n***War Pick.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one target. *Hit:* 6 (1d8 + 2) piercing damage, or 11 (2d8 + 2) piercing damage while enlarged.\n\n***Javelin.*** *Melee or Ranged Weapon Attack:* +4 to hit, reach 5 ft. or range 30/120 ft., one target. *Hit:* 5 (1d6 + 2) piercing damage, or 9 (2d6 + 2) piercing damage while enlarged.\n\n***Invisibility (Recharges after a Short or Long Rest).*** The duergar magically turns invisible until it attacks, casts a spell, or uses its Enlarge, or until its concentration is broken, up to 1 hour (as if concentrating on a spell). Any equipment the duergar wears or carries is invisible with it.",
			"",
			""));
}
