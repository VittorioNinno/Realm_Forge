using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Ettin (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Ettin2014Seeder
{
	public static Monster Build() => Create("ettin", null, CreatureSize.Large, CreatureType.Giant,
		12, 85, "10d10 + 30", 40, new[] { 21, 8, 17, 6, 10, 8 }, 4m, 1100, 2, 14,
		new Text(
			"Ettin",
			null,
			"Gigante Grande, caotico malvagio",
			"12 (armatura naturale)",
			"12 m",
			"",
			"Percezione +4",
			"",
			"",
			"",
			"",
			"Percezione passiva 14, scurovisione 18 m",
			"Gigante, Orchesco",
			"***Bicefalo.*** L'ettin dispone di vantaggio alle prove di Saggezza (Percezione) e ai tiri salvezza contro le condizioni accecato, affascinato, assordato, privo di sensi, spaventato e stordito.\n\n***Sempre all'erta.*** Quando una delle due teste dell'ettin dorme, l'altra testa è sveglia.",
			"***Multiattacco.*** L'ettin effettua due attacchi: uno con l'ascia da battaglia e uno con la mazza chiodata.\n\n***Ascia da battaglia.*** *Attacco con arma da mischia:* +7 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 14 (2d8 + 5) danni taglienti.\n\n***Mazza chiodata.*** *Attacco con arma da mischia:* +7 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 14 (2d8 + 5) danni perforanti.",
			"",
			""),
		new Text(
			"Ettin",
			null,
			"Large giant, chaotic evil",
			"12 (natural armor)",
			"40 ft.",
			"",
			"Perception +4",
			"",
			"",
			"",
			"",
			"darkvision 60 ft., passive Perception 14",
			"Giant, Orc",
			"***Two Heads.*** The ettin has advantage on Wisdom (Perception) checks and on saving throws against being blinded, charmed, deafened, frightened, stunned, and knocked unconscious.\n\n***Wakeful.*** When one of the ettin's heads is asleep, its other head is awake.",
			"***Multiattack.*** The ettin makes two attacks: one with its battleaxe and one with its morningstar.\n\n***Battleaxe.*** *Melee Weapon Attack:* +7 to hit, reach 5 ft., one target. *Hit:* 14 (2d8 + 5) slashing damage.\n\n***Morningstar.*** *Melee Weapon Attack:* +7 to hit, reach 5 ft., one target. *Hit:* 14 (2d8 + 5) piercing damage.",
			"",
			""));
}
