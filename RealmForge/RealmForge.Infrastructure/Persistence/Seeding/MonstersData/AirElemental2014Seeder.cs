using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Air Elemental (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class AirElemental2014Seeder
{
	public static Monster Build() => Create("air-elemental", null, ContentSource.Srd51, CreatureSize.Large, CreatureType.Elemental,
		15, 90, "12d10 + 24", 0, new[] { 14, 20, 14, 6, 10, 6 }, 5m, 1800, 3, 10,
		new Text(
			"Elementale dell'aria",
			null,
			"Elementale Grande, neutrale",
			"15",
			"0 m, volare 27 m (fluttuare)",
			"",
			"",
			"",
			"fulmine, tuono; contundenti, perforanti e taglienti da attacchi non magici",
			"veleno",
			"afferrato, avvelenato, indebolimento, paralizzato, pietrificato, privo di sensi, prono, trattenuto",
			"Percezione passiva 10, scurovisione 18 m",
			"Auran",
			"***Forma d'aria.*** L'elementale può entrare nello spazio di una creatura ostile e soffermarvisi. Può muoversi attraverso uno spazio stretto fino a 2,5 centimetri senza doversi stringere.",
			"***Multiattacco.*** L'elementale effettua due attacchi con schianto.\n\n***Schianto.*** *Attacco con arma da mischia:* +8 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 14 (2d8 + 5) danni contundenti.\n\n***Vortice (ricarica 4–6).*** Ogni creatura nello spazio dell'elementale deve effettuare un tiro salvezza su Forza con CD 13; se lo fallisce, subisce 15 (3d8 + 2) danni contundenti, viene scagliata a 6 metri di distanza dall'elementale in una direzione casuale e cade a terra prona. Se un bersaglio scagliato colpisce un oggetto, come per esempio un muro o una porta, quel bersaglio subisce 3 (1d6) danni contundenti per ogni 3 metri di cui è stato scagliato. Se il bersaglio viene lanciato contro un'altra creatura, quest'ultima deve superare un tiro salvezza su Destrezza con CD 13, altrimenti subirà gli stessi danni e cadrà a terra prona. Se supera il tiro salvezza, il bersaglio subisce la metà dei danni contundenti, non viene scagliato via e non cade a terra prono.",
			"",
			"",
			"",
			""),
		new Text(
			"Air Elemental",
			null,
			"Large elemental, neutral",
			"15",
			"0 ft., fly 90 ft. (hover)",
			"",
			"",
			"",
			"lightning, thunder; bludgeoning, piercing, and slashing from nonmagical weapons",
			"poison",
			"exhaustion, grappled, paralyzed, petrified, poisoned, prone, restrained, unconscious",
			"darkvision 60 ft., passive Perception 10",
			"Auran",
			"***Air Form.*** The elemental can enter a hostile creature's space and stop there. It can move through a space as narrow as 1 inch wide without squeezing.",
			"***Multiattack.*** The elemental makes two slam attacks.\n\n***Slam.*** *Melee Weapon Attack:* +8 to hit, reach 5 ft., one target. *Hit:* 14 (2d8 + 5) bludgeoning damage.\n\n***Whirlwind (Recharge 4–6).*** Each creature in the elemental's space must make a DC 13 Strength saving throw. On a failure, a target takes 15 (3d8 + 2) bludgeoning damage and is flung up 20 feet away from the elemental in a random direction and knocked prone. If a thrown target strikes an object, such as a wall or floor, the target takes 3 (1d6) bludgeoning damage for every 10 feet it was thrown. If the target is thrown at another creature, that creature must succeed on a DC 13 Dexterity saving throw or take the same damage and be knocked prone.\n\nIf the saving throw is successful, the target takes half the bludgeoning damage and isn't flung away or knocked prone.",
			"",
			"",
			"",
			""));
}
