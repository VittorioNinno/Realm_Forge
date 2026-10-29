using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Chimera (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Chimera2014Seeder
{
	public static Monster Build() => Create("chimera", null, ContentSource.Srd51, CreatureSize.Large, CreatureType.Monstrosity,
		14, 114, "12d10 + 48", 30, new[] { 19, 11, 19, 3, 14, 10 }, 6m, 2300, 3, 18,
		new Text(
			"Chimera",
			null,
			"Mostruosità Grande, caotica malvagia",
			"14 (armatura naturale)",
			"9 m, volare 18 m",
			"",
			"Percezione +8",
			"",
			"",
			"",
			"",
			"Percezione passiva 18, scurovisione 18 m",
			"capisce il Draconico ma non lo parla",
			"",
			"***Multiattacco.*** La chimera effettua tre attacchi: uno con il morso, uno con le corna e uno con gli artigli. Quando il soffio di fuoco è disponibile, può usarlo al posto del morso o delle corna.\n\n***Artigli.*** *Attacco con arma da mischia:* +7 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 11 (2d6 + 4) danni taglienti.\n\n***Corna.*** *Attacco con arma da mischia:* +7 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 10 (1d12 + 4) danni contundenti.\n\n***Morso.*** *Attacco con arma da mischia:* +7 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 11 (2d6 + 4) danni perforanti.\n\n***Soffio di fuoco (ricarica 5–6).*** La testa di drago esala un cono di fuoco di 4,5 metri. Ogni creatura in quell'area deve effettuare un tiro salvezza su Destrezza con CD 15, subendo 31 (7d8) danni da fuoco in caso di fallimento, o la metà dei danni in caso di successo.",
			"",
			"",
			"",
			""),
		new Text(
			"Chimera",
			null,
			"Large monstrosity, chaotic evil",
			"14 (natural armor)",
			"30 ft., fly 60 ft.",
			"",
			"Perception +8",
			"",
			"",
			"",
			"",
			"darkvision 60 ft., passive Perception 18",
			"understands Draconic but can't speak",
			"",
			"***Multiattack.*** The chimera makes three attacks: one with its bite, one with its horns, and one with its claws. When its fire breath is available, it can use the breath in place of its bite or horns.\n\n***Bite.*** *Melee Weapon Attack:* +7 to hit, reach 5 ft., one target. *Hit:* 11 (2d6 + 4) piercing damage.\n\n***Horns.*** *Melee Weapon Attack:* +7 to hit, reach 5 ft., one target. *Hit:* 10 (1d12 + 4) bludgeoning damage.\n\n***Claws.*** *Melee Weapon Attack:* +7 to hit, reach 5 ft., one target. *Hit:* 11 (2d6 + 4) slashing damage.\n\n***Fire Breath (Recharge 5–6).*** The dragon head exhales fire in a 15-foot cone. Each creature in that area must make a DC 15 Dexterity saving throw, taking 31 (7d8) fire damage on a failed save, or half as much damage on a successful one.",
			"",
			"",
			"",
			""));
}
