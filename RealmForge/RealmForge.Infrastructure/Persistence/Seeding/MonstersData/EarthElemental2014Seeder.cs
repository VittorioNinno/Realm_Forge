using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Earth Elemental (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class EarthElemental2014Seeder
{
	public static Monster Build() => Create("earth-elemental", null, ContentSource.Srd51, CreatureSize.Large, CreatureType.Elemental,
		17, 126, "12d10 + 60", 30, new[] { 20, 8, 20, 5, 10, 5 }, 5m, 1800, 3, 10,
		new Text(
			"Elementale della terra",
			null,
			"Elementale Grande, neutrale",
			"17 (armatura naturale)",
			"9 m, scavare 9 m",
			"",
			"",
			"tuono",
			"contundenti, perforanti e taglienti da attacchi non magici",
			"veleno",
			"avvelenato, indebolimento, paralizzato, pietrificato, privo di sensi",
			"Percezione passiva 10, percezione tellurica 18 m, scurovisione 18 m",
			"Terran",
			"***Mostro da assedio.*** L'elementale infligge danni doppi agli oggetti e alle strutture.\n\n***Scivolare nella terra.*** L'elementale può scavare attraverso la terra e la pietra non magiche e non lavorate. Quando lo fa, l'elementale non disturba il materiale attraverso cui si muove.",
			"***Multiattacco.*** L'elementale effettua due attacchi con schianto.\n\n***Schianto.*** *Attacco con arma da mischia:* +8 al tiro per colpire, portata 3 m, un bersaglio. *Colpito:* 14 (2d8 + 5) danni contundenti.",
			"",
			"",
			"",
			""),
		new Text(
			"Earth Elemental",
			null,
			"Large elemental, neutral",
			"17 (natural armor)",
			"30 ft., burrow 30 ft.",
			"",
			"",
			"thunder",
			"bludgeoning, piercing, and slashing from nonmagical weapons",
			"poison",
			"exhaustion, paralyzed, petrified, poisoned, unconscious",
			"darkvision 60 ft., tremorsense 60 ft., passive Perception 10",
			"Terran",
			"***Earth Glide.*** The elemental can burrow through nonmagical, unworked earth and stone. While doing so, the elemental doesn't disturb the material it moves through.\n\n***Siege Monster.*** The elemental deals double damage to objects and structures.",
			"***Multiattack.*** The elemental makes two slam attacks.\n\n***Slam.*** *Melee Weapon Attack:* +8 to hit, reach 10 ft., one target. *Hit:* 14 (2d8 + 5) bludgeoning damage.",
			"",
			"",
			"",
			""));
}
