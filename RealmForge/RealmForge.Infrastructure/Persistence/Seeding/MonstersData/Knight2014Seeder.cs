using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Knight (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Knight2014Seeder
{
	public static Monster Build() => Create("knight", null, CreatureSize.Medium, CreatureType.Humanoid,
		18, 52, "8d8 + 16", 30, new[] { 16, 11, 14, 11, 11, 15 }, 3m, 700, 2, 10,
		new Text(
			"Cavaliere",
			null,
			"Umanoide Medio (qualsiasi razza), qualsiasi allineamento",
			"18 (piastre)",
			"9 m",
			"Cos +4, Sag +2",
			"",
			"",
			"",
			"",
			"",
			"Percezione passiva 10",
			"uno qualsiasi (di solito Comune)",
			"***Impavido.*** Il cavaliere dispone di vantaggio ai tiri salvezza contro la condizione spaventato.",
			"***Multiattacco.*** Il cavaliere effettua due attacchi in mischia.\n\n***Spadone.*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 10 (2d6 + 3) danni taglienti.\n\n***Balestra pesante.*** *Attacco con arma a distanza:* +2 al tiro per colpire, gittata 30/120 m, un bersaglio. *Colpito:* 5 (1d10) danni perforanti.\n\n***Autorità (ricarica dopo un riposo breve o lungo).*** Per 1 minuto, il cavaliere può pronunciare un comando speciale o un monito ogni volta che una creatura non ostile visibile entro 9 metri da lui effettua un tiro per colpire o un tiro salvezza. La creatura può aggiungere un d4 al suo tiro a patto che possa udire e comprendere il cavaliere. Una creatura può beneficiare di un solo dado Autorità alla volta. Questo effetto termina se il cavaliere è incapacitato.",
			"***Parata.*** Il cavaliere aggiunge 2 alla sua CA contro un attacco in mischia che lo colpirebbe. Per farlo, deve vedere l'attaccante e deve impugnare un'arma da mischia.",
			""),
		new Text(
			"Knight",
			null,
			"Medium humanoid (any race), any alignment",
			"18 (plate armor)",
			"30 ft.",
			"Con +4, Wis +2",
			"",
			"",
			"",
			"",
			"",
			"passive Perception 10",
			"any one language (usually Common)",
			"***Brave.*** The knight has advantage on saving throws against being frightened.",
			"***Multiattack.*** The knight makes two melee attacks.\n\n***Greatsword.*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one target. *Hit:* 10 (2d6 + 3) slashing damage.\n\n***Heavy Crossbow.*** *Ranged Weapon Attack:* +2 to hit, range 100/400 ft., one target. *Hit:* 5 (1d10) piercing damage.\n\n***Leadership (Recharges after a Short or Long Rest).*** For 1 minute, the knight can utter a special command or warning whenever a nonhostile creature that it can see within 30 ft. of it makes an attack roll or a saving throw. The creature can add a d4 to its roll provided it can hear and understand the knight. A creature can benefit from only one Leadership die at a time. This effect ends if the knight is incapacitated.",
			"***Parry.*** The knight adds 2 to its AC against one melee attack that would hit it. To do so, the knight must see the attacker and be wielding a melee weapon.",
			""));
}
