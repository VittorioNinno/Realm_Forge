using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Death Dog (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class DeathDog2014Seeder
{
	public static Monster Build() => Create("death-dog", null, CreatureSize.Medium, CreatureType.Monstrosity,
		12, 39, "6d8 + 12", 40, new[] { 15, 14, 14, 3, 13, 6 }, 1m, 200, 2, 15,
		new Text(
			"Cane della morte",
			null,
			"Mostruosità Media, neutrale malvagio",
			"12",
			"12 m",
			"",
			"Furtività +4, Percezione +5",
			"",
			"",
			"",
			"",
			"Percezione passiva 15, scurovisione 36 m",
			"—",
			"***Bicefalo.*** Il cane dispone di vantaggio alle prove di Saggezza (Percezione) e ai tiri salvezza contro le condizioni accecato, affascinato, assordato, spaventato, stordito o privo di sensi.",
			"***Multiattacco.*** Il cane effettua due attacchi con il morso.\n\n***Morso.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 5 (1d6 + 2) danni perforanti. Se il bersaglio è una creatura, deve superare un tiro salvezza su Costituzione con CD 12 contro le malattie, altrimenti è avvelenato finché la malattia non viene curata. Dopo ogni 24 ore, la creatura deve ripetere il tiro salvezza; riducendo i suoi punti ferita massimi di 5 (1d10) in caso di fallimento. Questa riduzione dura finché la malattia non viene curata. Se la creatura porta i suoi punti ferita massimi a 0, il bersaglio muore.",
			"",
			""),
		new Text(
			"Death Dog",
			null,
			"Medium monstrosity, neutral evil",
			"12",
			"40 ft.",
			"",
			"Perception +5, Stealth +4",
			"",
			"",
			"",
			"",
			"darkvision 120 ft., passive Perception 15",
			"—",
			"***Two-Headed.*** The dog has advantage on Wisdom (Perception) checks and on saving throws against being blinded, charmed, deafened, frightened, stunned, or knocked unconscious.",
			"***Multiattack.*** The dog makes two bite attacks.\n\n***Bite.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one target. *Hit:* 5 (1d6 + 2) piercing damage. If the target is a creature, it must succeed on a DC 12 Constitution saving throw against disease or become poisoned until the disease is cured. Every 24 hours that elapse, the creature must repeat the saving throw, reducing its hit point maximum by 5 (1d10) on a failure. This reduction lasts until the disease is cured. The creature dies if the disease reduces its hit point maximum to 0.",
			"",
			""));
}
