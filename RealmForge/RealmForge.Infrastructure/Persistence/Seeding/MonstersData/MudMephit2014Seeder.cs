using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Mud Mephit (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class MudMephit2014Seeder
{
	public static Monster Build() => Create("mud-mephit", null, ContentSource.RealmForge, CreatureSize.Small, CreatureType.Elemental,
		11, 27, "6d6 + 6", 20, new[] { 8, 12, 12, 9, 11, 7 }, 0.25m, 50, 2, 10,
		new Text(
			"Mephit del fango",
			null,
			"Elementale Piccolo, neutrale malvagio",
			"11",
			"6 m, volare 6 m, nuotare 6 m",
			"",
			"Furtività +3",
			"",
			"",
			"veleno",
			"avvelenato",
			"Percezione passiva 10, scurovisione 18 m",
			"Acquan, Terran",
			"***Esplosione mortale.*** Quando muore, il mephit esplode in una massa di fango appiccicoso: ogni creatura di taglia Media o inferiore entro 1,5 metri da lui effettua un tiro salvezza su Destrezza con CD 11, altrimenti è trattenuta fino alla fine del suo turno successivo.\n\n***Falso aspetto.*** Finché resta immobile, il mephit ha esattamente l'aspetto di un normale mucchio di fango.",
			"***Pugni.*** *Attacco con arma da mischia:* +3 al tiro per colpire, portata 1,5 m, una creatura. *Colpito:* 4 (1d6 + 1) danni contundenti.\n\n***Soffio di fango (ricarica 6).*** Il mephit vomita fango vischioso su una creatura entro 1,5 metri da lui. Un bersaglio di taglia Media o inferiore effettua un tiro salvezza su Destrezza con CD 11, altrimenti è trattenuto per 1 minuto; ripete il tiro salvezza alla fine di ogni suo turno e l'effetto termina con un successo.",
			"",
			"",
			"",
			""),
		new Text(
			"Mud Mephit",
			null,
			"Small elemental, neutral evil",
			"11",
			"20 ft., fly 20 ft., swim 20 ft.",
			"",
			"Stealth +3",
			"",
			"",
			"poison",
			"poisoned",
			"darkvision 60 ft., passive Perception 10",
			"Aquan, Terran",
			"***Death Burst.*** When the mephit dies, it bursts into sticky mud: each Medium or smaller creature within 5 feet of it makes a DC 11 Dexterity saving throw or is restrained until the end of its next turn.\n\n***False Appearance.*** As long as it stays still, the mephit looks exactly like an ordinary heap of mud.",
			"***Fists.*** *Melee Weapon Attack:* +3 to hit, reach 5 ft., one creature. *Hit:* 4 (1d6 + 1) bludgeoning damage.\n\n***Mud Breath (Recharge 6).*** The mephit spews clinging mud on a creature within 5 feet of it. A Medium or smaller target makes a DC 11 Dexterity saving throw or is restrained for 1 minute, repeating the save at the end of each of its turns and ending the effect on a success.",
			"",
			"",
			"",
			""));
}
