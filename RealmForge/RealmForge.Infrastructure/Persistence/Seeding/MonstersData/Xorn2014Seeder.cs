using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Xorn (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Xorn2014Seeder
{
	public static Monster Build() => Create("xorn", null, ContentSource.Srd51, CreatureSize.Medium, CreatureType.Elemental,
		19, 73, "7d8 + 42", 20, new[] { 17, 10, 22, 11, 10, 11 }, 5m, 1800, 3, 16,
		new Text(
			"Xorn",
			null,
			"Elementale Medio, neutrale",
			"19 (armatura naturale)",
			"6 m, scavare 6 m",
			"",
			"Furtività +3, Percezione +6",
			"",
			"perforanti e taglienti da attacchi non magici non adamantini",
			"",
			"",
			"Percezione passiva 16, percezione tellurica 18 m, scurovisione 18 m",
			"Terran",
			"***Mimetizzazione rocciosa.*** Lo xorn dispone di vantaggio alle prove di Destrezza (Furtività) effettuate per nascondersi nei terreni rocciosi.\n\n***Percezione dei tesori.*** Lo xorn può individuare, tramite l'olfatto, l'ubicazione precisa di metalli e pietre preziose, come monete o gemme, entro 18 metri da lui.\n\n***Scivolare nella terra.*** Lo xorn può scavare attraverso la terra e la pietra non magiche e non lavorate senza disturbare il materiale attraverso cui si muove.",
			"***Multiattacco.*** Lo xorn effettua tre attacchi con gli artigli e uno con il morso.\n\n***Artiglio.*** *Attacco con arma da mischia:* +6 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 6 (1d6 + 3) danni taglienti.\n\n***Morso.*** *Attacco con arma da mischia:* +6 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 13 (3d6 + 3) danni perforanti.",
			"",
			"",
			"",
			""),
		new Text(
			"Xorn",
			null,
			"Medium elemental, neutral",
			"19 (natural armor)",
			"20 ft., burrow 20 ft.",
			"",
			"Perception +6, Stealth +3",
			"",
			"piercing and slashing from nonmagical weapons that aren't adamantine",
			"",
			"",
			"darkvision 60 ft., tremorsense 60 ft., passive Perception 16",
			"Terran",
			"***Earth Glide.*** The xorn can burrow through nonmagical, unworked earth and stone. While doing so, the xorn doesn't disturb the material it moves through.\n\n***Stone Camouflage.*** The xorn has advantage on Dexterity (Stealth) checks made to hide in rocky terrain.\n\n***Treasure Sense.*** The xorn can pinpoint, by scent, the location of precious metals and stones, such as coins and gems, within 60 ft. of it.",
			"***Multiattack.*** The xorn makes three claw attacks and one bite attack.\n\n***Bite.*** *Melee Weapon Attack:* +6 to hit, reach 5 ft., one target. *Hit:* 13 (3d6 + 3) piercing damage.\n\n***Claw.*** *Melee Weapon Attack:* +6 to hit, reach 5 ft., one target. *Hit:* 6 (1d6 + 3) slashing damage.",
			"",
			"",
			"",
			""));
}
