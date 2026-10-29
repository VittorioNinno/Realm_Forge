using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Dretch (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Dretch2014Seeder
{
	public static Monster Build() => Create("dretch", null, CreatureSize.Small, CreatureType.Fiend,
		11, 18, "4d6 + 4", 20, new[] { 11, 11, 12, 5, 8, 3 }, 0.25m, 50, 2, 9,
		new Text(
			"Dretch",
			null,
			"Immondo Piccolo (demone), caotico malvagio",
			"11 (armatura naturale)",
			"6 m",
			"",
			"",
			"",
			"freddo, fulmine, fuoco",
			"veleno",
			"avvelenato",
			"Percezione passiva 9, scurovisione 18 m",
			"Abissale, telepatia 18 m (funziona con le creature che capiscono l'Abissale)",
			"",
			"***Multiattacco.*** Il dretch effettua due attacchi: uno con il morso e uno con gli artigli.\n\n***Artigli.*** *Attacco con arma da mischia:* +2 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 5 (2d4) danni taglienti.\n\n***Morso.*** *Attacco con arma da mischia:* +2 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 3 (1d6) danni perforanti.\n\n***Nube fetida (1/giorno)*** Una nube di disgustoso gas verdastro si diffonde dal dretch entro un raggio di 3 metri. Il gas si diffonde nell'ambiente e la sua area è leggermente oscurata. Permane per 1 minuto o finché un forte vento non lo disperde. Ogni creatura che inizia il proprio turno in quell'area deve superare un tiro salvezza su Costituzione con CD 11, altrimenti è avvelenata fino all'inizio del proprio turno successivo. Finché è avvelenato in questo modo, il bersaglio può effettuare nel suo turno un'azione o un'azione bonus, ma non entrambe, e non può avere reazioni.",
			"",
			""),
		new Text(
			"Dretch",
			null,
			"Small fiend (demon), chaotic evil",
			"11 (natural armor)",
			"20 ft.",
			"",
			"",
			"",
			"cold, fire, lightning",
			"poison",
			"poisoned",
			"darkvision 60 ft., passive Perception 9",
			"Abyssal, telepathy 60 ft. (works only with creatures that understand Abyssal)",
			"",
			"***Multiattack.*** The dretch makes two attacks: one with its bite and one with its claws.\n\n***Bite.*** *Melee Weapon Attack:* +2 to hit, reach 5 ft., one target. *Hit:* 3 (1d6) piercing damage.\n\n***Claws.*** *Melee Weapon Attack:* +2 to hit, reach 5 ft., one target. *Hit:* 5 (2d4) slashing damage.\n\n***Fetid Cloud (1/Day).*** A 10-foot radius of disgusting green gas extends out from the dretch. The gas spreads around corners, and its area is lightly obscured. It lasts for 1 minute or until a strong wind disperses it. Any creature that starts its turn in that area must succeed on a DC 11 Constitution saving throw or be poisoned until the start of its next turn. While poisoned in this way, the target can take either an action or a bonus action on its turn, not both, and can't take reactions.",
			"",
			""));
}
