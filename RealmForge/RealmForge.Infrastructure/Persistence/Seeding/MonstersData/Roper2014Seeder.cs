using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Roper (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Roper2014Seeder
{
	public static Monster Build() => Create("roper", null, ContentSource.Srd51, CreatureSize.Large, CreatureType.Monstrosity,
		20, 93, "11d10 + 33", 10, new[] { 18, 8, 17, 7, 16, 6 }, 5m, 1800, 3, 16,
		new Text(
			"Fustigatore",
			null,
			"Mostruosità Grande, neutrale malvagio",
			"20 (armatura naturale)",
			"3 m, scalare 3 m",
			"",
			"Furtività +5, Percezione +6",
			"",
			"",
			"",
			"",
			"Percezione passiva 16, scurovisione 18 m",
			"—",
			"***Falso aspetto.*** Finché il fustigatore rimane immobile, non è possibile distinguerlo da una normale formazione rocciosa, come una stalagmite.\n\n***Movimenti del ragno.*** Il fustigatore può arrampicarsi su superfici difficili, compresi i soffitti (lungo i quali si muove a testa in giù), senza effettuare una prova di caratteristica.\n\n***Tentacoli afferranti.*** Il fustigatore può avere al massimo sei tentacoli contemporaneamente. Ogni tentacolo può essere attaccato (CA 20; 10 punti ferita; immunità ai danni psichici e da veleno). La distruzione di un tentacolo non infligge danni al fustigatore, che può impiegare un tentacolo sostitutivo nel suo turno successivo. Un tentacolo può anche essere spezzato se una creatura effettua un'azione e supera una prova di Forza con CD 15 contro di esso.",
			"***Multiattacco.*** Il fustigatore effettua quattro attacchi con i tentacoli, usa riavvolgere ed esegue un attacco con il morso.\n\n***Morso.*** *Attacco con arma da mischia:* +7 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 22 (4d8 + 4) danni perforanti.\n\n***Tentacolo.*** *Attacco con arma da mischia:* +7 al tiro per colpire, portata 15 m, una creatura. *Colpito:* il bersaglio è afferrato (CD 15 per sfuggire). Finché il fustigatore afferra il bersaglio, quest'ultimo è trattenuto e subisce svantaggio alle prove di Forza e ai tiri salvezza su Forza. Inoltre, il fustigatore non può usare lo stesso tentacolo su un altro bersaglio.\n\n***Riavvolgere.*** Il fustigatore tira verso di sé ogni creatura che ha afferrato per un massimo di 7,5 metri.",
			"",
			"",
			"",
			""),
		new Text(
			"Roper",
			null,
			"Large monstrosity, neutral evil",
			"20 (natural armor)",
			"10 ft., climb 10 ft.",
			"",
			"Perception +6, Stealth +5",
			"",
			"",
			"",
			"",
			"darkvision 60 ft., passive Perception 16",
			"—",
			"***False Appearance.*** While the roper remains motionless, it is indistinguishable from a normal cave formation, such as a stalagmite.\n\n***Grasping Tendrils.*** The roper can have up to six tendrils at a time. Each tendril can be attacked (AC 20; 10 hit points; immunity to poison and psychic damage). Destroying a tendril deals no damage to the roper, which can extrude a replacement tendril on its next turn. A tendril can also be broken if a creature takes an action and succeeds on a DC 15 Strength check against it.\n\n***Spider Climb.*** The roper can climb difficult surfaces, including upside down on ceilings, without needing to make an ability check.",
			"***Multiattack.*** The roper makes four attacks with its tendrils, uses Reel, and makes one attack with its bite.\n\n***Bite.*** *Melee Weapon Attack:* +7 to hit, reach 5 ft., one target. *Hit:* 22 (4d8 + 4) piercing damage.\n\n***Tendril.*** *Melee Weapon Attack:* +7 to hit, reach 50 ft., one creature. *Hit:* The target is grappled (escape DC 15). Until the grapple ends, the target is restrained and has disadvantage on Strength checks and Strength saving throws, and the roper can't use the same tendril on another target.\n\n***Reel.*** The roper pulls each creature grappled by it up to 25 ft. straight toward it.",
			"",
			"",
			"",
			""));
}
