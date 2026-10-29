using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Balor (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Balor2014Seeder
{
	public static Monster Build() => Create("balor", null, CreatureSize.Huge, CreatureType.Fiend,
		19, 262, "21d12 + 126", 40, new[] { 26, 15, 22, 20, 16, 22 }, 19m, 22000, 6, 13,
		new Text(
			"Balor",
			null,
			"Immondo Enorme (demone), caotico malvagio",
			"19 (armatura naturale)",
			"12 m, volare 24 m",
			"Car +12, Cos +12, For +14, Sag +9",
			"",
			"",
			"freddo, fulmine; contundenti, perforanti e taglienti da attacchi non magici",
			"fuoco, veleno",
			"avvelenato",
			"Percezione passiva 13, vista pura 36 m",
			"Abissale, telepatia 36 m",
			"***Armi magiche.*** Gli attacchi con arma del balor sono magici.\n\n***Aura di fuoco.*** All'inizio di ognuno dei turni del balor, ogni creatura situata entro 1,5 metri da lui subisce 10 (3d6) danni da fuoco e gli oggetti infiammabili nell'aura che non sono indossati o trasportati si incendiano. Una creatura che tocchi il balor o lo colpisca con un attacco in mischia mentre si trova entro 1,5 metri da lui subisce 10 (3d6) danni da fuoco.\n\n***Resistenza alla magia.*** Il balor dispone di vantaggio ai tiri salvezza contro incantesimi e altri effetti magici.\n\n***Spasmi di morte.*** Quando il balor muore, esplode e ogni creatura situata entro 9 metri da lui deve effettuare un tiro salvezza su Destrezza con CD 20, subendo 70 (20d6) danni da fuoco in caso di fallimento, o la metà dei danni in caso di successo. L'esplosione incendia gli oggetti infiammabili in quell'area che non sono indossati o trasportati e distrugge le armi del balor.",
			"***Multiattacco.*** Il balor effettua due attacchi: uno con la spada lunga e uno con la frusta.\n\n***Frusta.*** *Attacco con arma da mischia:* +14 al tiro per colpire, portata 9 m, un bersaglio. *Colpito:* 15 (2d6 + 8) danni taglienti più 10 (3d6) danni da fuoco e il bersaglio deve superare un tiro salvezza su Forza con CD 20, altrimenti verrà tirato fino a 7,5 metri più vicino al balor.\n\n***Spada lunga.*** *Attacco con arma da mischia:* +14 al tiro per colpire, portata 3 m, un bersaglio. *Colpito:* 21 (3d8 + 8) danni taglienti più 13 (3d8) danni da fulmine. Se il balor mette a segno un colpo critico, tira i dadi per i danni tre volte invece che due.\n\n***Teletrasporto.*** Il balor si teletrasporta magicamente, insieme a ogni oggetto che indossa o trasporta, fino a uno spazio libero visibile entro 36 metri.",
			"",
			""),
		new Text(
			"Balor",
			null,
			"Huge fiend (demon), chaotic evil",
			"19 (natural armor)",
			"40 ft., fly 80 ft.",
			"Str +14, Con +12, Wis +9, Cha +12",
			"",
			"",
			"cold, lightning; bludgeoning, piercing, and slashing from nonmagical weapons",
			"fire, poison",
			"poisoned",
			"truesight 120 ft., passive Perception 13",
			"Abyssal, telepathy 120 ft.",
			"***Death Throes.*** When the balor dies, it explodes, and each creature within 30 feet of it must make a DC 20 Dexterity saving throw, taking 70 (20d6) fire damage on a failed save, or half as much damage on a successful one. The explosion ignites flammable objects in that area that aren't being worn or carried, and it destroys the balor's weapons.\n\n***Fire Aura.*** At the start of each of the balor's turns, each creature within 5 feet of it takes 10 (3d6) fire damage, and flammable objects in the aura that aren't being worn or carried ignite. A creature that touches the balor or hits it with a melee attack while within 5 feet of it takes 10 (3d6) fire damage.\n\n***Magic Resistance.*** The balor has advantage on saving throws against spells and other magical effects.\n\n***Magic Weapons.*** The balor's weapon attacks are magical.",
			"***Multiattack.*** The balor makes two attacks: one with its longsword and one with its whip.\n\n***Longsword.*** *Melee Weapon Attack:* +14 to hit, reach 10 ft., one target. *Hit:* 21 (3d8 + 8) slashing damage plus 13 (3d8) lightning damage. If the balor scores a critical hit, it rolls damage dice three times, instead of twice.\n\n***Whip.*** *Melee Weapon Attack:* +14 to hit, reach 30 ft., one target. *Hit:* 15 (2d6 + 8) slashing damage plus 10 (3d6) fire damage, and the target must succeed on a DC 20 Strength saving throw or be pulled up to 25 feet toward the balor.\n\n***Teleport.*** The balor magically teleports, along with any equipment it is wearing or carrying, up to 120 feet to an unoccupied space it can see.",
			"",
			""));
}
