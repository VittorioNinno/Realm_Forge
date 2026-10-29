using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Centaur (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Centaur2014Seeder
{
	public static Monster Build() => Create("centaur", null, ContentSource.Srd51, CreatureSize.Large, CreatureType.Monstrosity,
		12, 45, "6d10 + 12", 50, new[] { 18, 14, 14, 9, 13, 11 }, 2m, 450, 2, 13,
		new Text(
			"Centauro",
			null,
			"Mostruosità Grande, neutrale buono",
			"12",
			"15 m",
			"",
			"Atletica +6, Percezione +3, Sopravvivenza +3",
			"",
			"",
			"",
			"",
			"Percezione passiva 13",
			"Elfico, Silvano",
			"***Carica.*** Se il centauro si muove di almeno 9 metri in linea retta verso un bersaglio e poi lo colpisce con un attacco con la picca nello stesso turno, il bersaglio subisce 10 (3d6) danni perforanti extra.",
			"***Multiattacco.*** Il centauro effettua due attacchi: uno con la picca e uno con gli zoccoli oppure due con l'arco lungo.\n\n***Picca.*** *Attacco con arma da mischia:* +6 al tiro per colpire, portata 3 m, un bersaglio. *Colpito:* 9 (1d10 + 4) danni perforanti.\n\n***Zoccoli.*** *Attacco con arma da mischia:* +6 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 11 (2d6 + 4) danni contundenti.\n\n***Arco lungo.*** *Attacco con arma a distanza:* +4 al tiro per colpire, gittata 45/180 m, un bersaglio. *Colpito:* 6 (1d8 + 2) danni perforanti.",
			"",
			"",
			"",
			""),
		new Text(
			"Centaur",
			null,
			"Large monstrosity, neutral good",
			"12",
			"50 ft.",
			"",
			"Athletics +6, Perception +3, Survival +3",
			"",
			"",
			"",
			"",
			"passive Perception 13",
			"Elvish, Sylvan",
			"***Charge.*** If the centaur moves at least 30 ft. straight toward a target and then hits it with a pike attack on the same turn, the target takes an extra 10 (3d6) piercing damage.",
			"***Multiattack.*** The centaur makes two attacks: one with its pike and one with its hooves or two with its longbow.\n\n***Pike.*** *Melee Weapon Attack:* +6 to hit, reach 10 ft., one target. *Hit:* 9 (1d10 + 4) piercing damage.\n\n***Hooves.*** *Melee Weapon Attack:* +6 to hit, reach 5 ft., one target. *Hit:* 11 (2d6 + 4) bludgeoning damage.\n\n***Longbow.*** *Ranged Weapon Attack:* +4 to hit, range 150/600 ft., one target. *Hit:* 6 (1d8 + 2) piercing damage.",
			"",
			"",
			"",
			""));
}
