using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Purple Worm (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class PurpleWorm2014Seeder
{
	public static Monster Build() => Create("purple-worm", null, CreatureSize.Gargantuan, CreatureType.Monstrosity,
		18, 247, "15d20 + 90", 50, new[] { 28, 7, 22, 1, 8, 4 }, 15m, 13000, 5, 9,
		new Text(
			"Verme purpureo",
			null,
			"Mostruosità Mastodontica, senza allineamento",
			"18 (armatura naturale)",
			"15 m, scavare 9 m",
			"Cos +11, Sag +4",
			"",
			"",
			"",
			"",
			"",
			"Percezione passiva 9, percezione tellurica 18 m, vista cieca 9 m",
			"—",
			"***Scavatore.*** Il verme può scavare attraverso la roccia solida a metà della sua velocità di scavare, formando un tunnel del diametro di 3 metri.",
			"***Multiattacco.*** Il verme effettua due attacchi: uno con il morso e uno con il pungiglione.\n\n***Morso.*** *Attacco con arma da mischia:* +9 al tiro per colpire, portata 3 m, un bersaglio. *Colpito:* 22 (3d8 + 9) danni perforanti. Se il bersaglio è una creatura di taglia Grande o inferiore, deve superare un tiro salvezza su Destrezza con CD 19, altrimenti viene inghiottito dal verme. Una creatura inghiottita è accecata e trattenuta, beneficia di copertura totale contro gli attacchi e altri effetti al di fuori del verme e subisce 21 (6d6) danni da acido all'inizio di ogni turno del verme. Se il verme subisce 30 o più danni in un singolo turno da una creatura al suo interno, deve superare un tiro salvezza su Costituzione con CD 21 alla fine di quel turno, altrimenti rigurgita tutte le creature inghiottite, che cadono a terra prone in uno spazio entro 3 metri da lui. Se il verme muore, la creatura inghiottita non è più trattenuta e può sfuggire usando 6 metri di movimento, uscendo così prona dal cadavere.\n\n***Pungiglione caudale.*** *Attacco con arma da mischia:* +9 al tiro per colpire, portata 3 m, una creatura. *Colpito:* 19 (3d6 + 9) danni perforanti e il bersaglio deve effettuare un tiro salvezza su Costituzione con CD 19, subendo 42 (12d6) danni da veleno in caso di fallimento, o la metà in caso di successo.",
			"",
			""),
		new Text(
			"Purple Worm",
			null,
			"Gargantuan monstrosity, unaligned",
			"18 (natural armor)",
			"50 ft., burrow 30 ft.",
			"Con +11, Wis +4",
			"",
			"",
			"",
			"",
			"",
			"blindsight 30 ft., tremorsense 60 ft., passive Perception 9",
			"—",
			"***Tunneler.*** The worm can burrow through solid rock at half its burrow speed and leaves a 10-foot-diameter tunnel in its wake.",
			"***Multiattack.*** The worm makes two attacks: one with its bite and one with its stinger.\n\n***Bite.*** *Melee Weapon Attack:* +9 to hit, reach 10 ft., one target. *Hit:* 22 (3d8 + 9) piercing damage. If the target is a Large or smaller creature, it must succeed on a DC 19 Dexterity saving throw or be swallowed by the worm. A swallowed creature is blinded and restrained, it has total cover against attacks and other effects outside the worm, and it takes 21 (6d6) acid damage at the start of each of the worm's turns.\n\nIf the worm takes 30 damage or more on a single turn from a creature inside it, the worm must succeed on a DC 21 Constitution saving throw at the end of that turn or regurgitate all swallowed creatures, which fall prone in a space within 10 feet of the worm. If the worm dies, a swallowed creature is no longer restrained by it and can escape from the corpse by using 20 feet of movement, exiting prone.\n\n***Tail Stinger.*** *Melee Weapon Attack:* +9 to hit, reach 10 ft., one creature. *Hit:* 19 (3d6 + 9) piercing damage, and the target must make a DC 19 Constitution saving throw, taking 42 (12d6) poison damage on a failed save, or half as much damage on a successful one.",
			"",
			""));
}
