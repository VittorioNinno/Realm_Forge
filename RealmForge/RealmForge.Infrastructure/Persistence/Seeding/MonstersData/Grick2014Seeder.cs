using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Grick (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Grick2014Seeder
{
	public static Monster Build() => Create("grick", null, ContentSource.Srd51, CreatureSize.Medium, CreatureType.Monstrosity,
		14, 27, "6d8", 30, new[] { 14, 14, 11, 3, 14, 5 }, 2m, 450, 2, 12,
		new Text(
			"Grick",
			null,
			"Mostruosità Media, neutrale",
			"14 (armatura naturale)",
			"9 m, scalare 9 m",
			"",
			"",
			"",
			"contundenti, perforanti e taglienti da attacchi non magici",
			"",
			"",
			"Percezione passiva 12, scurovisione 18 m",
			"—",
			"***Mimetizzazione rocciosa.*** Il grick dispone di vantaggio alle prove di Destrezza (Furtività) effettuate per nascondersi nei terreni rocciosi.",
			"***Multiattacco.*** Il grick effettua un attacco con i tentacoli. Se va a segno, può effettuarne uno con il becco contro lo stesso bersaglio.\n\n***Becco.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 5 (1d6 + 2) danni perforanti.\n\n***Tentacoli.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 9 (2d6 + 2) danni taglienti.",
			"",
			"",
			"",
			""),
		new Text(
			"Grick",
			null,
			"Medium monstrosity, neutral",
			"14 (natural armor)",
			"30 ft., climb 30 ft.",
			"",
			"",
			"",
			"bludgeoning, piercing, and slashing from nonmagical weapons",
			"",
			"",
			"darkvision 60 ft., passive Perception 12",
			"—",
			"***Stone Camouflage.*** The grick has advantage on Dexterity (Stealth) checks made to hide in rocky terrain.",
			"***Multiattack.*** The grick makes one attack with its tentacles. If that attack hits, the grick can make one beak attack against the same target.\n\n***Tentacles.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one target. *Hit:* 9 (2d6 + 2) slashing damage.\n\n***Beak.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one target. *Hit:* 5 (1d6 + 2) piercing damage.",
			"",
			"",
			"",
			""));
}
