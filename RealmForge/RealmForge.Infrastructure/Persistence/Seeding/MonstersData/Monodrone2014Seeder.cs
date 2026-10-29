using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Monodrone (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class Monodrone2014Seeder
{
	public static Monster Build() => Create("monodrone", null, ContentSource.RealmForge, CreatureSize.Medium, CreatureType.Construct,
		15, 5, "1d8 + 1", 30, new[] { 10, 13, 12, 4, 10, 5 }, 0.125m, 25, 2, 10,
		new Text(
			"Monodrone",
			null,
			"Costrutto Medio, legale neutrale",
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
			"***Mente assiomatica.*** Niente può costringere il monodrone ad agire contro la sua natura o le sue istruzioni.\n\n***Disintegrazione.*** Quando muore, il corpo del monodrone si sbriciola in polvere, lasciando le sue armi e qualsiasi altra cosa trasportasse.",
			"***Pugnale.*** *Attacco con arma da mischia:* +3 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 3 (1d4 + 1) danni perforanti.\n\n***Giavellotto.*** *Attacco con arma da mischia o a distanza:* +3 al tiro per colpire, portata 1,5 m o gittata 9/36 m, un bersaglio. *Colpito:* 4 (1d6 + 1) danni perforanti.",
			"",
			"",
			"",
			""),
		new Text(
			"Monodrone",
			null,
			"Medium construct, lawful neutral",
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
			"***Axiomatic Mind.*** Nothing can force the monodrone to act against its nature or its instructions.\n\n***Disintegration.*** When the monodrone dies, its body crumbles to dust, leaving its weapons and whatever else it carried.",
			"***Dagger.*** *Melee Weapon Attack:* +3 to hit, reach 5 ft., one target. *Hit:* 3 (1d4 + 1) piercing damage.\n\n***Javelin.*** *Melee or Ranged Weapon Attack:* +3 to hit, reach 5 ft. or range 30/120 ft., one target. *Hit:* 4 (1d6 + 1) piercing damage.",
			"",
			"",
			"",
			""));
}
