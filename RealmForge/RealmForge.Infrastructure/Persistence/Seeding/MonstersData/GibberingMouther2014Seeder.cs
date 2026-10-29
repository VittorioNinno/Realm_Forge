using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Gibbering Mouther (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class GibberingMouther2014Seeder
{
	public static Monster Build() => Create("gibbering-mouther", null, ContentSource.Srd51, CreatureSize.Medium, CreatureType.Aberration,
		9, 67, "9d8 + 27", 10, new[] { 10, 8, 16, 3, 10, 6 }, 2m, 450, 2, 10,
		new Text(
			"Fauce gorgogliante",
			null,
			"Aberrazione Media, neutrale",
			"9",
			"3 m, nuotare 3 m",
			"",
			"",
			"",
			"",
			"",
			"prono",
			"Percezione passiva 10, scurovisione 18 m",
			"—",
			"***Gorgogliare.*** La fauce gorgoglia in modo incoerente finché vede una qualsiasi creatura e non è incapacitata. Ogni creatura che inizia il proprio turno entro 6 metri dalla fauce e può sentirla gorgogliare deve superare un tiro salvezza su Saggezza con CD 10. Se lo fallisce, la creatura non può effettuare reazioni fino all'inizio del proprio turno successivo e tira un d8 per determinare cosa fa durante il proprio turno. Con un risultato da 1 a 4, la creatura non fa nulla. Con un risultato di 5 o 6, la creatura non effettua alcuna azione, né azione bonus, e usa tutto il suo movimento per muoversi in una data direzione a caso. Con un 7 o un 8, la creatura effettua un attacco in mischia contro una creatura determinata casualmente entro portata oppure non fa nulla se non riesce a eseguire un attacco simile.\n\n***Terreno aberrante.*** Il terreno in un raggio di 3 metri dalla fauce gorgogliante diventa molle ed è considerato terreno difficile. Ogni creatura che inizia il proprio turno in quell'area deve superare un tiro salvezza su Forza con CD 10, altrimenti la sua velocità si riduce a 0 fino all'inizio del suo turno successivo.",
			"***Multiattacco.*** La fauce gorgogliante effettua un attacco con il morso e, se possibile, usa lo Sputo accecante.\n\n***Morsi.*** *Attacco con arma da mischia:* +2 al tiro per colpire, portata 1,5 m, una creatura. *Colpito:* 17 (5d6) danni perforanti. Se il bersaglio è di taglia Media o inferiore, deve superare un tiro salvezza su Forza con CD 10, altrimenti cade a terra prono. Se il bersaglio viene ucciso da questi danni, viene assorbito dalla fauce gorgogliante.\n\n***Sputo accecante (ricarica 5–6).*** La fauce gorgogliante sputa una goccia chimica in un punto visibile entro 4,5 metri. La goccia esplode in un lampo di luce accecante all'impatto. Ogni creatura entro 1,5 metri dal lampo deve superare un tiro salvezza su Destrezza con CD 13, altrimenti è accecata fino alla fine del turno successivo della fauce gorgogliante.",
			"",
			"",
			"",
			""),
		new Text(
			"Gibbering Mouther",
			null,
			"Medium aberration, neutral",
			"9",
			"10 ft., swim 10 ft.",
			"",
			"",
			"",
			"",
			"",
			"prone",
			"darkvision 60 ft., passive Perception 10",
			"—",
			"***Aberrant Ground.*** The ground in a 10-foot radius around the mouther is doughlike difficult terrain. Each creature that starts its turn in that area must succeed on a DC 10 Strength saving throw or have its speed reduced to 0 until the start of its next turn.\n\n***Gibbering.*** The mouther babbles incoherently while it can see any creature and isn't incapacitated. Each creature that starts its turn within 20 feet of the mouther and can hear the gibbering must succeed on a DC 10 Wisdom saving throw. On a failure, the creature can't take reactions until the start of its next turn and rolls a d8 to determine what it does during its turn. On a 1 to 4, the creature does nothing. On a 5 or 6, the creature takes no action or bonus action and uses all its movement to move in a randomly determined direction. On a 7 or 8, the creature makes a melee attack against a randomly determined creature within its reach or does nothing if it can't make such an attack.",
			"***Multiattack.*** The gibbering mouther makes one bite attack and, if it can, uses its Blinding Spittle.\n\n***Bites.*** *Melee Weapon Attack:* +2 to hit, reach 5 ft., one creature. *Hit:* 17 (5d6) piercing damage. If the target is Medium or smaller, it must succeed on a DC 10 Strength saving throw or be knocked prone. If the target is killed by this damage, it is absorbed into the mouther.\n\n***Blinding Spittle (Recharge 5–6).*** The mouther spits a chemical glob at a point it can see within 15 feet of it. The glob explodes in a blinding flash of light on impact. Each creature within 5 feet of the flash must succeed on a DC 13 Dexterity saving throw or be blinded until the end of the mouther's next turn.",
			"",
			"",
			"",
			""));
}
