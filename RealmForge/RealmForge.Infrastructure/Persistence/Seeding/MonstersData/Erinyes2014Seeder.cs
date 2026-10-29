using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Erinyes (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Erinyes2014Seeder
{
	public static Monster Build() => Create("erinyes", null, ContentSource.Srd51, CreatureSize.Medium, CreatureType.Fiend,
		18, 153, "18d8 + 72", 30, new[] { 18, 16, 18, 14, 14, 18 }, 12m, 8400, 4, 12,
		new Text(
			"Erinni",
			null,
			"Immondo Medio (diavolo), legale malvagia",
			"18 (piastre)",
			"9 m, volare 18 m",
			"Car +8, Cos +8, Des +7, Sag +6",
			"",
			"",
			"freddo; contundenti, perforanti e taglienti da attacchi non magici non argentati",
			"fuoco, veleno",
			"avvelenato",
			"Percezione passiva 12, vista pura 36 m",
			"Infernale, telepatia 36 m",
			"***Armi infernali.*** Gli attacchi con arma dell'erinni sono magici e infliggono 13 (3d8) danni da veleno extra se vanno a segno (già inclusi negli attacchi).\n\n***Resistenza alla magia.*** L'erinni dispone di vantaggio ai tiri salvezza contro incantesimi e altri effetti magici.",
			"***Multiattacco.*** L'erinni effettua tre attacchi.\n\n***Spada lunga.*** *Attacco con arma da mischia:* +8 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 8 (1d8 + 4) danni taglienti, o 9 (1d10 + 4) danni taglienti se usata a due mani, più 13 (3d8) danni da veleno.\n\n***Arco lungo.*** *Attacco con arma a distanza:* +7 al tiro per colpire, gittata 45/180 m, un bersaglio. *Colpito:* 7 (1d8 + 3) danni perforanti più 13 (3d8) danni da veleno e il bersaglio deve superare un tiro salvezza su Costituzione con CD 14, altrimenti è avvelenato. Il veleno permane finché non viene rimosso dall'incantesimo *ristorare inferiore* o da una magia analoga.",
			"",
			"***Parata.*** L'erinni aggiunge 4 alla sua CA contro un attacco in mischia che la colpirebbe. Per farlo, l'erinni deve vedere l'attaccante e deve impugnare un'arma da mischia.",
			"",
			""),
		new Text(
			"Erinyes",
			null,
			"Medium fiend (devil), lawful evil",
			"18 (plate armor)",
			"30 ft., fly 60 ft.",
			"Dex +7, Con +8, Wis +6, Cha +8",
			"",
			"",
			"cold; bludgeoning, piercing, and slashing from nonmagical weapons that aren't silvered",
			"fire, poison",
			"poisoned",
			"truesight 120 ft., passive Perception 12",
			"Infernal, telepathy 120 ft.",
			"***Hellish Weapons.*** The erinyes's weapon attacks are magical and deal an extra 13 (3d8) poison damage on a hit (included in the attacks).\n\n***Magic Resistance.*** The erinyes has advantage on saving throws against spells and other magical effects.",
			"***Multiattack.*** The erinyes makes three attacks\n\n***Longsword.*** *Melee Weapon Attack:* +8 to hit, reach 5 ft., one target. *Hit:* 8 (1d8 + 4) slashing damage, or 9 (1d10 + 4) slashing damage if used with two hands, plus 13 (3d8) poison damage.\n\n***Longbow.*** *Ranged Weapon Attack:* +7 to hit, range 150/600 ft., one target. *Hit:* 7 (1d8 + 3) piercing damage plus 13 (3d8) poison damage, and the target must succeed on a DC 14 Constitution saving throw or be poisoned. The poison lasts until it is removed by the lesser restoration spell or similar magic.",
			"",
			"***Parry.*** The erinyes adds 4 to its AC against one melee attack that would hit it. To do so, the erinyes must see the attacker and be wielding a melee weapon.",
			"",
			""));
}
