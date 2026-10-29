using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Fire Elemental (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class FireElemental2014Seeder
{
	public static Monster Build() => Create("fire-elemental", null, ContentSource.Srd51, CreatureSize.Large, CreatureType.Elemental,
		13, 102, "12d10 + 36", 50, new[] { 10, 17, 16, 6, 10, 7 }, 5m, 1800, 3, 10,
		new Text(
			"Elementale del fuoco",
			null,
			"Elementale Grande, neutrale",
			"13",
			"15 m",
			"",
			"",
			"",
			"contundenti, perforanti e taglienti da attacchi non magici",
			"fuoco, veleno",
			"afferrato, avvelenato, indebolimento, paralizzato, pietrificato, privo di sensi, prono, trattenuto",
			"Percezione passiva 10, scurovisione 18 m",
			"Ignan",
			"***Forma di fuoco.*** L'elementale può muoversi attraverso uno spazio stretto fino a 2,5 centimetri senza doversi stringere. Una creatura che tocchi l'elementale o lo colpisca con un attacco in mischia mentre si trova entro 1,5 metri da esso subisce 5 (1d10) danni da fuoco. Inoltre, l'elementale può entrare nello spazio di una creatura ostile e soffermarvisi. La prima volta che entra nello spazio di una creatura in un turno, quella creatura subisce 5 (1d10) danni da fuoco e prende fuoco; finché qualcuno non usa un'azione per estinguere le fiamme, la creatura subisce 5 (1d10) danni da fuoco all'inizio di ogni suo turno.\n\n***Illuminazione.*** L'elementale proietta luce intensa in un raggio di 9 metri e luce fioca per altri 9 metri.\n\n***Suscettibilità all'acqua.*** Per ogni 1,5 metri di cui l'elementale si muove nell'acqua o per ogni 4 litri d'acqua versatigli addosso, subisce 1 danno da freddo.",
			"***Multiattacco.*** L'elementale effettua due attacchi con il tocco.\n\n***Tocco.*** *Attacco con arma da mischia:* +6 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 10 (2d6 + 3) danni da fuoco. Se il bersaglio è una creatura o un oggetto infiammabile, prende fuoco. Finché qualcuno non usa un'azione per estinguere le fiamme, il bersaglio subisce 5 (1d10) danni da fuoco all'inizio di ogni suo turno.",
			"",
			"",
			"",
			""),
		new Text(
			"Fire Elemental",
			null,
			"Large elemental, neutral",
			"13",
			"50 ft.",
			"",
			"",
			"",
			"bludgeoning, piercing, and slashing from nonmagical weapons",
			"fire, poison",
			"exhaustion, grappled, paralyzed, petrified, poisoned, prone, restrained, unconscious",
			"darkvision 60 ft., passive Perception 10",
			"Ignan",
			"***Fire Form.*** The elemental can move through a space as narrow as 1 inch wide without squeezing. A creature that touches the elemental or hits it with a melee attack while within 5 ft. of it takes 5 (1d10) fire damage. In addition, the elemental can enter a hostile creature's space and stop there. The first time it enters a creature's space on a turn, that creature takes 5 (1d10) fire damage and catches fire; until someone takes an action to douse the fire, the creature takes 5 (1d10) fire damage at the start of each of its turns.\n\n***Illumination.*** The elemental sheds bright light in a 30-foot radius and dim light in an additional 30 ft..\n\n***Water Susceptibility.*** For every 5 ft. the elemental moves in water, or for every gallon of water splashed on it, it takes 1 cold damage.",
			"***Multiattack.*** The elemental makes two touch attacks.\n\n***Touch.*** *Melee Weapon Attack:* +6 to hit, reach 5 ft., one target. *Hit:* 10 (2d6 + 3) fire damage. If the target is a creature or a flammable object, it ignites. Until a creature takes an action to douse the fire, the target takes 5 (1d10) fire damage at the start of each of its turns.",
			"",
			"",
			"",
			""));
}
