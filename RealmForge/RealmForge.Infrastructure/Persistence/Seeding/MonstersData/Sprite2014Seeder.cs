using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Sprite (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Sprite2014Seeder
{
	public static Monster Build() => Create("sprite", null, CreatureSize.Tiny, CreatureType.Fey,
		15, 2, "1d4", 10, new[] { 3, 18, 10, 14, 13, 11 }, 0.25m, 50, 2, 13,
		new Text(
			"Spiritello",
			null,
			"Folletto Minuscolo, neutrale buono",
			"15 (armatura di cuoio)",
			"3 m, volare 12 m",
			"",
			"Furtività +8, Percezione +3",
			"",
			"",
			"",
			"",
			"Percezione passiva 13",
			"Comune, Elfico, Silvano",
			"",
			"***Spada lunga.*** *Attacco con arma da mischia:* +2 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 1 danno tagliente.\n\n***Arco corto.*** *Attacco con arma a distanza:* +6 al tiro per colpire, gittata 12/48 m, un bersaglio. *Colpito:* 1 danno perforante e il bersaglio deve superare un tiro salvezza su Costituzione con CD 10, altrimenti è avvelenato per 1 minuto. Se il risultato del tiro salvezza è pari o inferiore a 5, il bersaglio avvelenato perde conoscenza ed è privo di sensi per la stessa durata, finché non subisce danni o finché un'altra creatura non usa un'azione per risvegliarlo scuotendolo.\n\n***Invisibilità.*** Lo spiritello diventa magicamente invisibile finché non attacca, non lancia un incantesimo o finché non perde la concentrazione (come se si concentrasse su un incantesimo). Ogni oggetto che lo spiritello indossa o trasporta diventa invisibile insieme a lui.\n\n***Vista del cuore.*** Lo spiritello tocca una creatura e capisce magicamente il suo stato emotivo attuale. Se il bersaglio fallisce un tiro salvezza su Carisma con CD 10, lo spiritello apprende anche l'allineamento della creatura. I celestiali, gli immondi e i non morti falliscono automaticamente il tiro salvezza.",
			"",
			""),
		new Text(
			"Sprite",
			null,
			"Tiny fey, neutral good",
			"15 (leather armor)",
			"10 ft., fly 40 ft.",
			"",
			"Perception +3, Stealth +8",
			"",
			"",
			"",
			"",
			"passive Perception 13",
			"Common, Elvish, Sylvan",
			"",
			"***Longsword.*** *Melee Weapon Attack:* +2 to hit, reach 5 ft., one target. *Hit:* 1 slashing damage.\n\n***Shortbow.*** *Ranged Weapon Attack:* +6 to hit, range 40/160 ft., one target. *Hit:* 1 piercing damage, and the target must succeed on a DC 10 Constitution saving throw or become poisoned for 1 minute. If its saving throw result is 5 or lower, the poisoned target falls unconscious for the same duration, or until it takes damage or another creature takes an action to shake it awake.\n\n***Heart Sight.*** The sprite touches a creature and magically knows the creature's current emotional state. If the target fails a DC 10 Charisma saving throw, the sprite also knows the creature's alignment. Celestials, fiends, and undead automatically fail the saving throw.\n\n***Invisibility.*** The sprite magically turns invisible until it attacks or casts a spell, or until its concentration ends (as if concentrating on a spell). Any equipment the sprite wears or carries is invisible with it.",
			"",
			""));
}
