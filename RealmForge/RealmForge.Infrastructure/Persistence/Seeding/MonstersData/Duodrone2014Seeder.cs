using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Duodrone (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class Duodrone2014Seeder
{
	public static Monster Build() => Create("duodrone", null, ContentSource.RealmForge, CreatureSize.Medium, CreatureType.Construct,
		15, 11, "2d8 + 2", 30, new[] { 11, 13, 12, 6, 10, 7 }, 0.25m, 50, 2, 10,
		new Text(
			"Duodrone",
			null,
			"Costrutto Medio, legale neutrale",
			"15 (armatura naturale)",
			"9 m",
			"",
			"",
			"",
			"",
			"",
			"",
			"Percezione passiva 10, vista pura 36 m",
			"Modron",
			"***Mente assiomatica.*** Niente può costringere il duodrone ad agire contro la sua natura o le sue istruzioni.\n\n***Disintegrazione.*** Quando muore, il corpo del duodrone si sbriciola in polvere, lasciando le sue armi e qualsiasi altra cosa trasportasse.",
			"***Multiattacco.*** Il duodrone effettua due attacchi con i pugni o due con i giavellotti.\n\n***Pugno.*** *Attacco con arma da mischia:* +2 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 2 (1d4) danni contundenti.\n\n***Giavellotto.*** *Attacco con arma da mischia o a distanza:* +3 al tiro per colpire, portata 1,5 m o gittata 9/36 m, un bersaglio. *Colpito:* 4 (1d6 + 1) danni perforanti.",
			"",
			"",
			"",
			""),
		new Text(
			"Duodrone",
			null,
			"Medium construct, lawful neutral",
			"15 (natural armor)",
			"30 ft.",
			"",
			"",
			"",
			"",
			"",
			"",
			"truesight 120 ft., passive Perception 10",
			"Modron",
			"***Axiomatic Mind.*** Nothing can force the duodrone to act against its nature or its instructions.\n\n***Disintegration.*** When the duodrone dies, its body crumbles to dust, leaving its weapons and whatever else it carried.",
			"***Multiattack.*** The duodrone makes two fist or two javelin attacks.\n\n***Fist.*** *Melee Weapon Attack:* +2 to hit, reach 5 ft., one target. *Hit:* 2 (1d4) bludgeoning damage.\n\n***Javelin.*** *Melee or Ranged Weapon Attack:* +3 to hit, reach 5 ft. or range 30/120 ft., one target. *Hit:* 4 (1d6 + 1) piercing damage.",
			"",
			"",
			"",
			""));
}
