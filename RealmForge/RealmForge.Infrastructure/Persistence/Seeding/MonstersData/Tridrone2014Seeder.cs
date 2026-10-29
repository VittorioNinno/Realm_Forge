using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Tridrone (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class Tridrone2014Seeder
{
	public static Monster Build() => Create("tridrone", null, ContentSource.RealmForge, CreatureSize.Medium, CreatureType.Construct,
		15, 16, "3d8 + 3", 30, new[] { 12, 13, 12, 9, 10, 9 }, 0.5m, 100, 2, 10,
		new Text(
			"Tridrone",
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
			"***Mente assiomatica.*** Niente può costringere il tridrone ad agire contro la sua natura o le sue istruzioni.\n\n***Disintegrazione.*** Quando muore, il corpo del tridrone si sbriciola in polvere, lasciando le sue armi e qualsiasi altra cosa trasportasse.",
			"***Multiattacco.*** Il tridrone effettua tre attacchi con i pugni o tre con i giavellotti.\n\n***Pugno.*** *Attacco con arma da mischia:* +3 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 3 (1d4 + 1) danni contundenti.\n\n***Giavellotto.*** *Attacco con arma da mischia o a distanza:* +3 al tiro per colpire, portata 1,5 m o gittata 9/36 m, un bersaglio. *Colpito:* 4 (1d6 + 1) danni perforanti.",
			"",
			"",
			"",
			""),
		new Text(
			"Tridrone",
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
			"***Axiomatic Mind.*** Nothing can force the tridrone to act against its nature or its instructions.\n\n***Disintegration.*** When the tridrone dies, its body crumbles to dust, leaving its weapons and whatever else it carried.",
			"***Multiattack.*** The tridrone makes three fist or three javelin attacks.\n\n***Fist.*** *Melee Weapon Attack:* +3 to hit, reach 5 ft., one target. *Hit:* 3 (1d4 + 1) bludgeoning damage.\n\n***Javelin.*** *Melee or Ranged Weapon Attack:* +3 to hit, reach 5 ft. or range 30/120 ft., one target. *Hit:* 4 (1d6 + 1) piercing damage.",
			"",
			"",
			"",
			""));
}
