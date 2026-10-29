using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Giant Vulture (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class GiantVulture2014Seeder
{
	public static Monster Build() => Create("giant-vulture", null, ContentSource.Srd51, CreatureSize.Large, CreatureType.Beast,
		10, 22, "3d10 + 6", 10, new[] { 15, 10, 15, 6, 12, 7 }, 1m, 200, 2, 13,
		new Text(
			"Avvoltoio gigante",
			null,
			"Bestia Grande, neutrale malvagio",
			"10",
			"3 m, volare 18 m",
			"",
			"Percezione +3",
			"",
			"",
			"",
			"",
			"Percezione passiva 13",
			"capisce il Comune ma non lo parla",
			"***Tattiche del branco.*** L'avvoltoio dispone di vantaggio nel tiro per colpire contro una creatura se almeno uno degli alleati dell'animale si trova entro 1,5 metri dalla creatura e non è incapacitato.\n\n***Vista e olfatto acuti.*** L'avvoltoio dispone di vantaggio alle prove di Saggezza (Percezione) basate sulla vista o sull'olfatto.",
			"***Multiattacco.*** L'avvoltoio effettua due attacchi: uno con il becco e uno con gli artigli.\n\n***Artigli.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 9 (2d6 + 2) danni taglienti.\n\n***Becco.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 7 (2d4 + 2) danni perforanti.",
			"",
			"",
			"",
			""),
		new Text(
			"Giant Vulture",
			null,
			"Large beast, neutral evil",
			"10",
			"10 ft., fly 60 ft.",
			"",
			"Perception +3",
			"",
			"",
			"",
			"",
			"passive Perception 13",
			"understands Common but can't speak",
			"***Keen Sight and Smell.*** The vulture has advantage on Wisdom (Perception) checks that rely on sight or smell.\n\n***Pack Tactics.*** The vulture has advantage on an attack roll against a creature if at least one of the vulture's allies is within 5 ft. of the creature and the ally isn't incapacitated.",
			"***Multiattack.*** The vulture makes two attacks: one with its beak and one with its talons.\n\n***Beak.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one target. *Hit:* 7 (2d4 + 2) piercing damage.\n\n***Talons.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one target. *Hit:* 9 (2d6 + 2) slashing damage.",
			"",
			"",
			"",
			""));
}
