using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Blink Dog (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class BlinkDog2014Seeder
{
	public static Monster Build() => Create("blink-dog", null, ContentSource.Srd51, CreatureSize.Medium, CreatureType.Fey,
		13, 22, "4d8 + 4", 40, new[] { 12, 17, 12, 10, 13, 11 }, 0.25m, 50, 2, 13,
		new Text(
			"Cane intermittente",
			null,
			"Folletto Medio, legale buono",
			"13",
			"12 m",
			"",
			"Furtività +5, Percezione +3",
			"",
			"",
			"",
			"",
			"Percezione passiva 13",
			"Cane Intermittente, capisce il Silvano ma non lo parla",
			"***Udito e olfatto acuti.*** Il cane dispone di vantaggio alle prove di Saggezza (Percezione) basate sull'olfatto o sull'udito.",
			"***Morso.*** *Attacco con arma da mischia:* +3 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 4 (1d6 + 1) danni perforanti.\n\n***Teletrasporto (ricarica 4–6).*** Il cane si teletrasporta magicamente, insieme a ogni oggetto che indossa o trasporta, fino a uno spazio libero visibile situato entro 12 metri. Prima o dopo essersi teletrasportato, il cane può effettuare un attacco con il morso.",
			"",
			"",
			"",
			""),
		new Text(
			"Blink Dog",
			null,
			"Medium fey, lawful good",
			"13",
			"40 ft.",
			"",
			"Perception +3, Stealth +5",
			"",
			"",
			"",
			"",
			"passive Perception 13",
			"Blink Dog, understands Sylvan but can't speak it",
			"***Keen Hearing and Smell.*** The dog has advantage on Wisdom (Perception) checks that rely on hearing or smell.",
			"***Bite.*** *Melee Weapon Attack:* +3 to hit, reach 5 ft., one target. *Hit:* 4 (1d6 + 1) piercing damage.\n\n***Teleport (Recharge 4–6).*** The dog magically teleports, along with any equipment it is wearing or carrying, up to 40 ft. to an unoccupied space it can see. Before or after teleporting, the dog can make one bite attack.",
			"",
			"",
			"",
			""));
}
