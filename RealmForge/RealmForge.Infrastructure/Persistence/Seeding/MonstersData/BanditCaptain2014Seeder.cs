using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Bandit Captain (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class BanditCaptain2014Seeder
{
	public static Monster Build() => Create("bandit-captain", null, ContentSource.Srd51, CreatureSize.Medium, CreatureType.Humanoid,
		15, 65, "10d8 + 20", 30, new[] { 15, 16, 14, 14, 11, 14 }, 2m, 450, 2, 10,
		new Text(
			"Capo dei banditi",
			null,
			"Umanoide Medio (qualsiasi razza), qualsiasi allineamento non legale",
			"15 (cuoio borchiato)",
			"9 m",
			"Des +4, For +5, Sag +2",
			"Atletica +4, Inganno +4",
			"",
			"",
			"",
			"",
			"Percezione passiva 10",
			"due qualsiasi",
			"",
			"***Multiattacco.*** Il capo dei banditi effettua tre attacchi in mischia: due con la scimitarra e uno con il pugnale. In alternativa, effettua due attacchi a distanza con i suoi pugnali.\n\n***Scimitarra.*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 6 (1d6 + 3) danni taglienti.\n\n***Pugnale.*** *Attacco con arma da mischia o con arma a distanza:* +5 al tiro per colpire, portata 1,5 m o gittata 6/18 m, un bersaglio. *Colpito:* 5 (1d4 + 3) danni perforanti.",
			"",
			"***Parata.*** Il capo aggiunge 2 alla sua CA contro un attacco in mischia che lo colpirebbe. Per farlo, deve vedere l'attaccante e deve impugnare un'arma da mischia.",
			"",
			""),
		new Text(
			"Bandit Captain",
			null,
			"Medium humanoid (any race), any non-lawful alignment",
			"15 (studded leather armor)",
			"30 ft.",
			"Str +4, Dex +5, Wis +2",
			"Athletics +4, Deception +4",
			"",
			"",
			"",
			"",
			"passive Perception 10",
			"any two languages",
			"",
			"***Multiattack.*** The captain makes three melee attacks: two with its scimitar and one with its dagger. Or the captain makes two ranged attacks with its daggers.\n\n***Scimitar.*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one target. *Hit:* 6 (1d6 + 3) slashing damage.\n\n***Dagger.*** *Melee or Ranged Weapon Attack:* +5 to hit, reach 5 ft. or range 20/60 ft., one target. *Hit:* 5 (1d4 + 3) piercing damage.",
			"",
			"***Parry.*** The captain adds 2 to its AC against one melee attack that would hit it. To do so, the captain must see the attacker and be wielding a melee weapon.",
			"",
			""));
}
