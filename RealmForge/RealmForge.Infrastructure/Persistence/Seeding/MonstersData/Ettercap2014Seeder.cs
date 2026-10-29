using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Ettercap (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Ettercap2014Seeder
{
	public static Monster Build() => Create("ettercap", null, CreatureSize.Medium, CreatureType.Monstrosity,
		13, 44, "8d8 + 8", 30, new[] { 14, 15, 13, 7, 12, 8 }, 2m, 450, 2, 13,
		new Text(
			"Ettercap",
			null,
			"Mostruosità Media, neutrale malvagio",
			"13 (armatura naturale)",
			"9 m, scalare 9 m",
			"",
			"Furtività +4, Percezione +3, Sopravvivenza +3",
			"",
			"",
			"",
			"",
			"Percezione passiva 13, scurovisione 18 m",
			"—",
			"***Arrampicatele.*** L'ettecap ignora le restrizioni di movimento causate dalle ragnatele.\n\n***Movimenti del ragno.*** L'ettercap può scalare le superfici difficili, inclusi i soffitti, lungo i quali si muove a testa in giù, senza effettuare una prova di caratteristica.\n\n***Percezione della Ragnatela.*** Finché è in contatto con una ragnatela, l'ettercap conosce l'ubicazione esatta di ogni altra creatura a contatto con la stessa ragnatela.",
			"***Multiattacco.*** L'ettercap effettua due attacchi: uno con il morso e uno con gli artigli.\n\n***Artigli.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 7 (2d4 + 2) danni taglienti.\n\n***Morso.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, una creatura. *Colpito:* 6 (1d8 + 2) danni perforanti più 4 (1d8) danni da veleno. Il bersaglio deve superare un tiro salvezza su Costituzione con CD 11, altrimenti viene avvelenato per 1 minuto. La creatura può ripetere il tiro salvezza alla fine di ogni suo turno e, se lo supera, l'effetto svanisce.\n\n***Ragnatela (ricarica 5–6).*** *Attacco con arma a distanza:* +4 al tiro per colpire, gittata 9/18 m, una creatura Grande o di taglia inferiore. *Colpito:* La creatura è trattenuta dalle ragnatele. Con un'azione, la creatura trattenuta può effettuare una prova di Forza con CD 11, sfuggendo alla ragnatela in caso di successo. L'effetto termina anche se la ragnatela viene distrutta. La ragnatela ha CA 10, 5 punti ferita, vulnerabilità ai danni da fuoco e immunità ai danni contundenti, psichici e da veleno.",
			"",
			""),
		new Text(
			"Ettercap",
			null,
			"Medium monstrosity, neutral evil",
			"13 (natural armor)",
			"30 ft., climb 30 ft.",
			"",
			"Perception +3, Stealth +4, Survival +3",
			"",
			"",
			"",
			"",
			"darkvision 60 ft., passive Perception 13",
			"—",
			"***Spider Climb.*** The ettercap can climb difficult surfaces, including upside down on ceilings, without needing to make an ability check.\n\n***Web Sense.*** While in contact with a web, the ettercap knows the exact location of any other creature in contact with the same web.\n\n***Web Walker.*** The ettercap ignores movement restrictions caused by webbing.",
			"***Multiattack.*** The ettercap makes two attacks: one with its bite and one with its claws.\n\n***Bite.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one creature. *Hit:* 6 (1d8 + 2) piercing damage plus 4 (1d8) poison damage. The target must succeed on a DC 11 Constitution saving throw or be poisoned for 1 minute. The creature can repeat the saving throw at the end of each of its turns, ending the effect on itself on a success.\n\n***Claws.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one target. *Hit:* 7 (2d4 + 2) slashing damage.\n\n***Web (Recharge 5–6).*** *Ranged Weapon Attack:* +4 to hit, range 30/60 ft., one Large or smaller creature. *Hit:* The creature is restrained by webbing. As an action, the restrained creature can make a DC 11 Strength check, escaping from the webbing on a success. The effect ends if the webbing is destroyed. The webbing has AC 10, 5 hit points, is vulnerable to fire damage and immune to bludgeoning damage.",
			"",
			""));
}
