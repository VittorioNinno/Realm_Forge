using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Lion (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Lion2014Seeder
{
	public static Monster Build() => Create("lion", null, ContentSource.Srd51, CreatureSize.Large, CreatureType.Beast,
		12, 26, "4d10 + 4", 50, new[] { 17, 15, 13, 3, 12, 8 }, 1m, 200, 2, 13,
		new Text(
			"Leone",
			null,
			"Bestia Grande, senza allineamento",
			"12",
			"15 m",
			"",
			"Furtività +6, Percezione +3",
			"",
			"",
			"",
			"",
			"Percezione passiva 13",
			"—",
			"***Balzo.*** Se il leone si muove di almeno 6 metri in linea retta verso una creatura e poi la colpisce con un attacco con gli artigli nello stesso turno, quel bersaglio deve superare un tiro salvezza su Forza con CD 13, altrimenti cade a terra prono. Se il bersaglio è prono, il leone può effettuare un attacco con il morso contro di esso come azione bonus.\n\n***Balzo in corsa.*** Dopo una rincorsa di 3 metri, il leone può effettuare un salto in lungo di un massimo di 7,5 metri.\n\n***Olfatto acuto.*** Il leone dispone di vantaggio alle prove di Saggezza (Percezione) basate sull'olfatto.\n\n***Tattiche del branco.*** Il leone dispone di vantaggio a un tiro per colpire contro una creatura se almeno uno degli alleati dell'animale si trova entro 1,5 metri dalla creatura e non è incapacitato.",
			"***Artiglio.*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 6 (1d6 + 3) danni taglienti.\n\n***Morso.*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 7 (1d8 + 3) danni perforanti.",
			"",
			"",
			"",
			""),
		new Text(
			"Lion",
			null,
			"Large beast, unaligned",
			"12",
			"50 ft.",
			"",
			"Perception +3, Stealth +6",
			"",
			"",
			"",
			"",
			"passive Perception 13",
			"—",
			"***Keen Smell.*** The lion has advantage on Wisdom (Perception) checks that rely on smell.\n\n***Pack Tactics.*** The lion has advantage on an attack roll against a creature if at least one of the lion's allies is within 5 ft. of the creature and the ally isn't incapacitated.\n\n***Pounce.*** If the lion moves at least 20 ft. straight toward a creature and then hits it with a claw attack on the same turn, that target must succeed on a DC 13 Strength saving throw or be knocked prone. If the target is prone, the lion can make one bite attack against it as a bonus action.\n\n***Running Leap.*** With a 10-foot running start, the lion can long jump up to 25 ft..",
			"***Bite.*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one target. *Hit:* 7 (1d8 + 3) piercing damage.\n\n***Claw.*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one target. *Hit:* 6 (1d6 + 3) slashing damage.",
			"",
			"",
			"",
			""));
}
