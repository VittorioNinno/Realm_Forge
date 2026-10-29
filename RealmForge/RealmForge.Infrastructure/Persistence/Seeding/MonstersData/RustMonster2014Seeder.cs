using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Rust Monster (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class RustMonster2014Seeder
{
	public static Monster Build() => Create("rust-monster", null, CreatureSize.Medium, CreatureType.Monstrosity,
		14, 27, "5d8 + 5", 40, new[] { 13, 12, 13, 2, 13, 6 }, 0.5m, 100, 2, 11,
		new Text(
			"Rugginofago",
			null,
			"Mostruosità Media, senza allineamento",
			"14 (armatura naturale)",
			"12 m",
			"",
			"",
			"",
			"",
			"",
			"",
			"Percezione passiva 11, scurovisione 18 m",
			"—",
			"***Arrugginire.*** Qualsiasi arma non magica fatta di metallo colpisca il rugginofago si corrode. Dopo avere inflitto danni, l'arma subisce una penalità cumulativa e permanente di -1 ai tiri per i danni. Se la sua penalità scende a -5, l'arma viene distrutta. Le munizioni non magiche fatte di metallo che colpiscono il rugginofago vengono distrutte dopo aver inflitto danni.\n\n***Fiutare il ferro.*** Il rugginofago può individuare, tramite l'olfatto, la precisa ubicazione di qualsiasi metallo ferroso situato entro 9 metri da lui.",
			"***Morso.*** *Attacco con arma da mischia:* +3 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 5 (1d8 + 1) danni perforanti.\n\n***Antenne.*** Il rugginofago corrode un oggetto di metallo ferroso non magico situato nel suo campo visivo in un raggio di 1,5 metri. Se l'oggetto non è indossato o trasportato, il tocco distrugge una porzione di quell'oggetto pari a 30 centimetri cubi. Se è indossato o trasportato da una creatura, quest'ultima può effettuare un tiro salvezza su Destrezza con CD 11 per evitare il tocco del rugginofago. Se l'oggetto toccato è un'armatura o uno scudo di metallo indossato o trasportato, esso subisce una penalità permanente e cumulativa di –1 alla CA che fornisce. Se un'armatura viene ridotta a una CA pari a 10 o uno scudo scende a un bonus di +0, vengono distrutti. Se l'oggetto toccato è un'arma di metallo impugnata, arrugginisce come descritto nel tratto Arrugginire.",
			"",
			""),
		new Text(
			"Rust Monster",
			null,
			"Medium monstrosity, unaligned",
			"14 (natural armor)",
			"40 ft.",
			"",
			"",
			"",
			"",
			"",
			"",
			"darkvision 60 ft., passive Perception 11",
			"—",
			"***Iron Scent.*** The rust monster can pinpoint, by scent, the location of ferrous metal within 30 feet of it.\n\n***Rust Metal.*** Any nonmagical weapon made of metal that hits the rust monster corrodes. After dealing damage, the weapon takes a permanent and cumulative -1 penalty to damage rolls. If its penalty drops to -5, the weapon is destroyed. Nonmagical ammunition made of metal that hits the rust monster is destroyed after dealing damage.",
			"***Bite.*** *Melee Weapon Attack:* +3 to hit, reach 5 ft., one target. *Hit:* 5 (1d8 + 1) piercing damage.\n\n***Antennae.*** The rust monster corrodes a nonmagical ferrous metal object it can see within 5 feet of it. If the object isn't being worn or carried, the touch destroys a 1-foot cube of it. If the object is being worn or carried by a creature, the creature can make a DC 11 Dexterity saving throw to avoid the rust monster's touch.\n\nIf the object touched is either metal armor or a metal shield being worn or carried, its takes a permanent and cumulative -1 penalty to the AC it offers. Armor reduced to an AC of 10 or a shield that drops to a +0 bonus is destroyed. If the object touched is a held metal weapon, it rusts as described in the Rust Metal trait.",
			"",
			""));
}
