using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Druid (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Druid2014Seeder
{
	public static Monster Build() => Create("druid", null, ContentSource.Srd51, CreatureSize.Medium, CreatureType.Humanoid,
		11, 27, "5d8 + 5", 30, new[] { 10, 12, 13, 12, 15, 11 }, 2m, 450, 2, 14,
		new Text(
			"Druido",
			null,
			"Umanoide Medio (qualsiasi razza), qualsiasi allineamento",
			"11 (16 con pelle coriacea)",
			"9 m",
			"",
			"Medicina +4, Natura +3, Percezione +4",
			"",
			"",
			"",
			"",
			"Percezione passiva 14",
			"Druidico più altri due qualsiasi",
			"***Incantesimi.*** Il druido è un incantatore di 4° livello: la sua caratteristica da incantatore è Saggezza (CD del tiro salvezza sull'incantesimo 12, +4 al tiro per colpire con attacco con incantesimo). Ha a disposizione i seguenti incantesimi da druido:\n\n- Trucchetti (a volontà): *artificio druidico, produrre fiamma, randello incantato*\n- 1° livello (4 slot): *intralciare, onda tonante, parlare con gli animali, passo veloce*\n- 2° livello (3 slot): *animale messaggero, pelle coriacea*",
			"***Bastone ferrato.*** *Attacco con arma da mischia:* +2 al tiro per colpire (+4 con *randello incantato),* portata 1,5 m, un bersaglio. *Colpito:* 3 (1d6) danni contundenti, 4 (1d8) danni contundenti se usato a due mani o 6 (1d8 + 2) danni contundenti con *randello incantato.*",
			"",
			"",
			"",
			""),
		new Text(
			"Druid",
			null,
			"Medium humanoid (any race), any alignment",
			"11 (16 with barkskin)",
			"30 ft.",
			"",
			"Medicine +4, Nature +3, Perception +4",
			"",
			"",
			"",
			"",
			"passive Perception 14",
			"Druidic plus any two languages",
			"***Spellcasting.*** The druid is a 4th-level spellcaster. Its spellcasting ability is Wisdom (spell save DC 12, +4 to hit with spell attacks). It has the following druid spells prepared:\n\n- Cantrips (at will): *druidcraft, produce flame, shillelagh*\n- 1st level (4 slots): *entangle, longstrider, speak with animals, thunderwave*\n- 2nd level (3 slots): *animal messenger, barkskin*",
			"***Quarterstaff.*** *Melee Weapon Attack:* +2 to hit (+4 to hit with shillelagh), reach 5 ft., one target. *Hit:* 3 (1d6) bludgeoning damage, 4 (1d8) bludgeoning damage if wielded with two hands, or 6 (1d8 + 2) bludgeoning damage with shillelagh.",
			"",
			"",
			"",
			""));
}
