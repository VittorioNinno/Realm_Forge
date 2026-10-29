using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Troll (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Troll2014Seeder
{
	public static Monster Build() => Create("troll", null, ContentSource.Srd51, CreatureSize.Large, CreatureType.Giant,
		15, 84, "8d10 + 40", 30, new[] { 18, 13, 20, 7, 9, 7 }, 5m, 1800, 3, 12,
		new Text(
			"Troll",
			null,
			"Gigante Grande, caotico malvagio",
			"15 (armatura naturale)",
			"9 m",
			"",
			"Percezione +2",
			"",
			"",
			"",
			"",
			"Percezione passiva 12, scurovisione 18 m",
			"Gigante",
			"***Olfatto acuto.*** Il troll dispone di vantaggio alle prove di Saggezza (Percezione) basate sull'olfatto.\n\n***Rigenerazione.*** Il troll recupera 10 punti ferita all'inizio del suo turno. Se il troll subisce danni da acido o fuoco, questo tratto non funziona all'inizio del suo turno successivo. Il troll muore solo se inizia il turno con 0 punti ferita e non si rigenera.",
			"***Multiattacco.*** Il troll effettua tre attacchi: uno con il morso e due con gli artigli.\n\n***Artiglio.*** *Attacco con arma da mischia:* +7 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 11 (2d6 + 4) danni taglienti.\n\n***Morso.*** *Attacco con arma da mischia:* +7 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 7 (1d6 + 4) danni perforanti.",
			"",
			"",
			"",
			""),
		new Text(
			"Troll",
			null,
			"Large giant, chaotic evil",
			"15 (natural armor)",
			"30 ft.",
			"",
			"Perception +2",
			"",
			"",
			"",
			"",
			"darkvision 60 ft., passive Perception 12",
			"Giant",
			"***Keen Smell.*** The troll has advantage on Wisdom (Perception) checks that rely on smell.\n\n***Regeneration.*** The troll regains 10 hit points at the start of its turn. If the troll takes acid or fire damage, this trait doesn't function at the start of the troll's next turn. The troll dies only if it starts its turn with 0 hit points and doesn't regenerate.",
			"***Multiattack.*** The troll makes three attacks: one with its bite and two with its claws.\n\n***Bite.*** *Melee Weapon Attack:* +7 to hit, reach 5 ft., one target. *Hit:* 7 (1d6 + 4) piercing damage.\n\n***Claw.*** *Melee Weapon Attack:* +7 to hit, reach 5 ft., one target. *Hit:* 11 (2d6 + 4) slashing damage.",
			"",
			"",
			"",
			""));
}
