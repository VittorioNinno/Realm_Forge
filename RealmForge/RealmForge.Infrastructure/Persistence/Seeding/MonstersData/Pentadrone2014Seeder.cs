using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Pentadrone (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class Pentadrone2014Seeder
{
	public static Monster Build() => Create("pentadrone", null, ContentSource.RealmForge, CreatureSize.Large, CreatureType.Construct,
		16, 32, "5d10 + 5", 40, new[] { 15, 14, 12, 10, 10, 13 }, 2m, 450, 2, 14,
		new Text(
			"Pentadrone",
			null,
			"Costrutto Grande, legale neutrale",
			"16 (armatura naturale)",
			"12 m",
			"",
			"Percezione +4",
			"",
			"",
			"",
			"",
			"Percezione passiva 14, vista pura 36 m",
			"Modron",
			"***Mente assiomatica.*** Niente può costringere il pentadrone ad agire contro la sua natura o le sue istruzioni.\n\n***Disintegrazione.*** Quando muore, il corpo del pentadrone si sbriciola in polvere, lasciando le sue armi e qualsiasi altra cosa trasportasse.",
			"***Multiattacco.*** Il pentadrone effettua cinque attacchi con le braccia.\n\n***Braccio.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 5 (1d6 + 2) danni contundenti.\n\n***Gas paralizzante (ricarica 5–6).*** Il pentadrone esala gas in un cono di 9 metri. Ogni creatura nel cono effettua un tiro salvezza su Costituzione con CD 11, altrimenti è paralizzata per 1 minuto; ripete il tiro salvezza alla fine di ogni suo turno e l'effetto termina con un successo.",
			"",
			"",
			"",
			""),
		new Text(
			"Pentadrone",
			null,
			"Large construct, lawful neutral",
			"16 (natural armor)",
			"40 ft.",
			"",
			"Perception +4",
			"",
			"",
			"",
			"",
			"truesight 120 ft., passive Perception 14",
			"Modron",
			"***Axiomatic Mind.*** Nothing can force the pentadrone to act against its nature or its instructions.\n\n***Disintegration.*** When the pentadrone dies, its body crumbles to dust, leaving its weapons and whatever else it carried.",
			"***Multiattack.*** The pentadrone makes five arm attacks.\n\n***Arm.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one target. *Hit:* 5 (1d6 + 2) bludgeoning damage.\n\n***Paralysis Gas (Recharge 5–6).*** The pentadrone breathes out gas in a 30-foot cone. Each creature in the cone makes a DC 11 Constitution saving throw or is paralyzed for 1 minute, repeating the save at the end of each of its turns and ending the effect on a success.",
			"",
			"",
			"",
			""));
}
