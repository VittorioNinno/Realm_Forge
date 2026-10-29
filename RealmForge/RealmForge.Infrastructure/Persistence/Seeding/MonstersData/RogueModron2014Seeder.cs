using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Rogue Modron (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class RogueModron2014Seeder
{
	public static Monster Build() => Create("rogue-modron", "monodrone", ContentSource.RealmForge, CreatureSize.Medium, CreatureType.Construct,
		15, 5, "1d8 + 1", 30, new[] { 10, 13, 12, 4, 10, 5 }, 0.125m, 25, 2, 10,
		new Text(
			"Modron fuori controllo",
			null,
			"Costrutto Medio, qualsiasi allineamento tranne legale neutrale",
			"15 (armatura naturale)",
			"9 m, volare 9 m",
			"",
			"",
			"",
			"",
			"",
			"",
			"Percezione passiva 10, vista pura 36 m",
			"Modron",
			"***Disintegrazione.*** Quando muore, il corpo del modron si sbriciola in polvere, lasciando le sue armi e qualsiasi altra cosa trasportasse.",
			"***Pugnale.*** *Attacco con arma da mischia:* +3 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 3 (1d4 + 1) danni perforanti.\n\n***Giavellotto.*** *Attacco con arma da mischia o a distanza:* +3 al tiro per colpire, portata 1,5 m o gittata 9/36 m, un bersaglio. *Colpito:* 4 (1d6 + 1) danni perforanti.",
			"",
			"",
			"",
			"Un modron guastato dal deterioramento o dal contatto con il caos smette di obbedire a Primus e infrange le leggi di Mechanus. Perde Mente assiomatica e mantiene le statistiche del suo rango; questa voce usa quelle di un monodrone."),
		new Text(
			"Rogue Modron",
			null,
			"Medium construct, any alignment except lawful neutral",
			"15 (natural armor)",
			"30 ft., fly 30 ft.",
			"",
			"",
			"",
			"",
			"",
			"",
			"truesight 120 ft., passive Perception 10",
			"Modron",
			"***Disintegration.*** When the modron dies, its body crumbles to dust, leaving its weapons and whatever else it carried.",
			"***Dagger.*** *Melee Weapon Attack:* +3 to hit, reach 5 ft., one target. *Hit:* 3 (1d4 + 1) piercing damage.\n\n***Javelin.*** *Melee or Ranged Weapon Attack:* +3 to hit, reach 5 ft. or range 30/120 ft., one target. *Hit:* 4 (1d6 + 1) piercing damage.",
			"",
			"",
			"",
			"A modron broken by decay or by contact with chaos stops obeying Primus and breaks the laws of Mechanus. It loses Axiomatic Mind and keeps the statistics of its rank; this entry uses a monodrone's."));
}
