using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Quadrone (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class Quadrone2014Seeder
{
	public static Monster Build() => Create("quadrone", null, ContentSource.RealmForge, CreatureSize.Medium, CreatureType.Construct,
		16, 22, "4d8 + 4", 30, new[] { 12, 14, 12, 10, 10, 11 }, 1m, 200, 2, 12,
		new Text(
			"Quadrone",
			null,
			"Costrutto Medio, legale neutrale",
			"16 (armatura naturale)",
			"9 m, volare 9 m",
			"",
			"Percezione +2",
			"",
			"",
			"",
			"",
			"Percezione passiva 12, vista pura 36 m",
			"Modron",
			"***Mente assiomatica.*** Niente può costringere il quadrone ad agire contro la sua natura o le sue istruzioni.\n\n***Disintegrazione.*** Quando muore, il corpo del quadrone si sbriciola in polvere, lasciando le sue armi e qualsiasi altra cosa trasportasse.",
			"***Multiattacco.*** Il quadrone effettua due attacchi con i pugni o quattro con l'arco corto.\n\n***Pugno.*** *Attacco con arma da mischia:* +3 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 3 (1d4 + 1) danni contundenti.\n\n***Arco corto.*** *Attacco con arma a distanza:* +4 al tiro per colpire, gittata 24/96 m, un bersaglio. *Colpito:* 5 (1d6 + 2) danni perforanti.",
			"",
			"",
			"",
			""),
		new Text(
			"Quadrone",
			null,
			"Medium construct, lawful neutral",
			"16 (natural armor)",
			"30 ft., fly 30 ft.",
			"",
			"Perception +2",
			"",
			"",
			"",
			"",
			"truesight 120 ft., passive Perception 12",
			"Modron",
			"***Axiomatic Mind.*** Nothing can force the quadrone to act against its nature or its instructions.\n\n***Disintegration.*** When the quadrone dies, its body crumbles to dust, leaving its weapons and whatever else it carried.",
			"***Multiattack.*** The quadrone makes two fist attacks or four shortbow attacks.\n\n***Fist.*** *Melee Weapon Attack:* +3 to hit, reach 5 ft., one target. *Hit:* 3 (1d4 + 1) bludgeoning damage.\n\n***Shortbow.*** *Ranged Weapon Attack:* +4 to hit, range 80/320 ft., one target. *Hit:* 5 (1d6 + 2) piercing damage.",
			"",
			"",
			"",
			""));
}
