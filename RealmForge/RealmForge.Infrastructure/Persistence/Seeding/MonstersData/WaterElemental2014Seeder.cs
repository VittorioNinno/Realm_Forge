using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Water Elemental (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class WaterElemental2014Seeder
{
	public static Monster Build() => Create("water-elemental", null, ContentSource.Srd51, CreatureSize.Large, CreatureType.Elemental,
		14, 114, "12d10 + 48", 30, new[] { 18, 14, 18, 5, 10, 8 }, 5m, 1800, 3, 10,
		new Text(
			"Elementale dell'acqua",
			null,
			"Elementale Grande, neutrale",
			"14 (armatura naturale)",
			"9 m, nuotare 27 m",
			"",
			"",
			"",
			"acido; contundenti, perforanti e taglienti da attacchi non magici",
			"veleno",
			"afferrato, avvelenato, indebolimento, paralizzato, pietrificato, privo di sensi, prono, trattenuto",
			"Percezione passiva 10, scurovisione 18 m",
			"Aquan",
			"***Congelamento.*** Se l'elementale subisce danni da freddo, si congela parzialmente; la sua velocità è ridotta di 6 metri fino alla fine del suo turno successivo.\n\n***Forma d'acqua.*** L'elementale può entrare nello spazio di una creatura ostile e soffermarvisi. Può muoversi attraverso uno spazio stretto fino a 2,5 centimetri senza doversi stringere.",
			"***Multiattacco.*** L'elementale effettua due attacchi con schianto.\n\n***Schianto.*** *Attacco con arma da mischia:* +7 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 13 (2d8 + 4) danni contundenti.\n\n***Sommergere (ricarica 4–6).*** Ogni creatura nello spazio dell'elementale deve effettuare un tiro salvezza su Forza con CD 15; se lo fallisce, subisce 13 (2d8 + 4) danni contundenti. Se la creatura è di taglia Grande o inferiore, viene anche afferrata (CD 14 per sfuggire). Finché la presa perdura, il bersaglio è trattenuto e non può respirare a meno che non riesca a respirare in acqua. Se il bersaglio supera il tiro salvezza, viene spinto fuori dallo spazio dell'elementale. L'elementale può afferrare una creatura Grande o un massimo di due creature Medie o di taglia inferiore contemporaneamente tramite questa capacità. All'inizio di ogni turno dell'elementale, ogni bersaglio afferrato subisce 13 (2d8 + 4) danni contundenti. Con un'azione, una creatura entro 1,5 metri dall'elementale può tirare fuori da esso una creatura o un oggetto effettuando con successo una prova di Forza con CD 14.",
			"",
			"",
			"",
			""),
		new Text(
			"Water Elemental",
			null,
			"Large elemental, neutral",
			"14 (natural armor)",
			"30 ft., swim 90 ft.",
			"",
			"",
			"",
			"acid; bludgeoning, piercing, and slashing from nonmagical weapons",
			"poison",
			"exhaustion, grappled, paralyzed, petrified, poisoned, prone, restrained, unconscious",
			"darkvision 60 ft., passive Perception 10",
			"Aquan",
			"***Water Form.*** The elemental can enter a hostile creature's space and stop there. It can move through a space as narrow as 1 inch wide without squeezing.\n\n***Freeze.*** If the elemental takes cold damage, it partially freezes; its speed is reduced by 20 ft. until the end of its next turn.",
			"***Multiattack.*** The elemental makes two slam attacks.\n\n***Slam.*** *Melee Weapon Attack:* +7 to hit, reach 5 ft., one target. *Hit:* 13 (2d8 + 4) bludgeoning damage.\n\n***Whelm (Recharge 4–6).*** Each creature in the elemental's space must make a DC 15 Strength saving throw. On a failure, a target takes 13 (2d8 + 4) bludgeoning damage. If it is Large or smaller, it is also grappled (escape DC 14). Until this grapple ends, the target is restrained and unable to breathe unless it can breathe water. If the saving throw is successful, the target is pushed out of the elemental's space.\n\nThe elemental can grapple one Large creature or up to two Medium or smaller creatures at one time. At the start of each of the elemental's turns, each target grappled by it takes 13 (2d8 + 4) bludgeoning damage. A creature within 5 feet of the elemental can pull a creature or object out of it by taking an action to make a DC 14 Strength and succeeding.",
			"",
			"",
			"",
			""));
}
