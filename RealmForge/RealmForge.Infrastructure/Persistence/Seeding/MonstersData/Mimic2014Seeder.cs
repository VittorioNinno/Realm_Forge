using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Mimic (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Mimic2014Seeder
{
	public static Monster Build() => Create("mimic", null, CreatureSize.Medium, CreatureType.Monstrosity,
		12, 58, "9d8 + 18", 15, new[] { 17, 12, 15, 5, 13, 8 }, 2m, 450, 2, 11,
		new Text(
			"Mimic",
			null,
			"Mostruosità Media (mutaforma), neutrale",
			"12 (armatura naturale)",
			"4,5 m",
			"",
			"Furtività +5",
			"",
			"",
			"acido",
			"prono",
			"Percezione passiva 11, scurovisione 18 m",
			"—",
			"***Mutaforma.*** Il mimic può usare la sua azione per trasformarsi in un oggetto o per tornare alla sua forma naturale, che è amorfa. Le sue statistiche restano le stesse in ogni forma. Ogni oggetto che indossa o trasporta non viene trasformato. Se muore, torna alla sua forma naturale.\n\n***Adesivo (solo forma di oggetto).*** Il mimic aderisce a qualsiasi cosa lo tocchi. Una creatura di taglia Enorme o inferiore a cui il mimic si sia attaccato è anche afferrata da esso (CD 13 per sfuggire). Le prove di caratteristica effettuate per sfuggire a questa presa subiscono svantaggio.\n\n***Falso aspetto (solo forma di oggetto).*** Finché il mimic rimane immobile, non è possibile distinguerlo da un oggetto comune.\n\n***Lottatore.*** Il mimic dispone di vantaggio ai tiri per colpire contro qualsiasi creatura afferrata.",
			"***Morso.*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 7 (1d8 + 3) danni perforanti più 4 (1d8) danni da acido.\n\n***Pseudopode.*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 7 (1d8 + 3) danni contundenti. Se il mimic è in forma di oggetto, il bersaglio è soggetto al suo tratto Adesivo.",
			"",
			""),
		new Text(
			"Mimic",
			null,
			"Medium monstrosity (shapechanger), neutral",
			"12 (natural armor)",
			"15 ft.",
			"",
			"Stealth +5",
			"",
			"",
			"acid",
			"prone",
			"darkvision 60 ft., passive Perception 11",
			"—",
			"***Shapechanger.*** The mimic can use its action to polymorph into an object or back into its true, amorphous form. Its statistics are the same in each form. Any equipment it is wearing or carrying isn 't transformed. It reverts to its true form if it dies.\n\n***Adhesive (Object Form Only).*** The mimic adheres to anything that touches it. A Huge or smaller creature adhered to the mimic is also grappled by it (escape DC 13). Ability checks made to escape this grapple have disadvantage.\n\n***False Appearance (Object Form Only).*** While the mimic remains motionless, it is indistinguishable from an ordinary object.\n\n***Grappler.*** The mimic has advantage on attack rolls against any creature grappled by it.",
			"***Pseudopod.*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one target. *Hit:* 7 (1d8 + 3) bludgeoning damage. If the mimic is in object form, the target is subjected to its Adhesive trait.\n\n***Bite.*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one target. *Hit:* 7 (1d8 + 3) piercing damage plus 4 (1d8) acid damage.",
			"",
			""));
}
