using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Blue Slaad (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class BlueSlaad2014Seeder
{
	public static Monster Build() => Create("blue-slaad", null, ContentSource.RealmForge, CreatureSize.Large, CreatureType.Aberration,
		15, 123, "13d10 + 52", 30, new[] { 20, 15, 18, 7, 7, 9 }, 7m, 2900, 3, 11,
		new Text(
			"Slaad blu",
			null,
			"Aberrazione Grande, caotico neutrale",
			"15 (armatura naturale)",
			"9 m",
			"",
			"Percezione +1",
			"",
			"acido, freddo, fuoco, fulmine, tuono",
			"",
			"",
			"Percezione passiva 11, scurovisione 18 m",
			"Slaad, telepatia 18 m",
			"***Resistenza alla magia.*** Lo slaad dispone di vantaggio ai tiri salvezza contro incantesimi e altri effetti magici.\n\n***Rigenerazione.*** All'inizio del suo turno lo slaad recupera 10 punti ferita, purché abbia almeno 1 punto ferita.",
			"***Multiattacco.*** Lo slaad effettua tre attacchi: uno con il morso e due con gli artigli.\n\n***Morso.*** *Attacco con arma da mischia:* +8 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 12 (2d6 + 5) danni perforanti.\n\n***Artiglio.*** *Attacco con arma da mischia:* +8 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 12 (2d6 + 5) danni taglienti. Un umanoide colpito effettua un tiro salvezza su Costituzione con CD 15, altrimenti contrae il morbo del caos. Finché è infetto non può recuperare punti ferita e i suoi punti ferita massimi si riducono di 10 (3d6) ogni 24 ore; se scendono a 0, si trasforma all'istante in uno slaad rosso, o in uno slaad verde se sa lanciare incantesimi di 3° livello o superiore. Solo un incantesimo *desiderio* può annullare la trasformazione.",
			"",
			"",
			"",
			""),
		new Text(
			"Blue Slaad",
			null,
			"Large aberration, chaotic neutral",
			"15 (natural armor)",
			"30 ft.",
			"",
			"Perception +1",
			"",
			"acid, cold, fire, lightning, thunder",
			"",
			"",
			"darkvision 60 ft., passive Perception 11",
			"Slaad, telepathy 60 ft.",
			"***Magic Resistance.*** The slaad has advantage on saving throws against spells and other magical effects.\n\n***Regeneration.*** At the start of its turn, the slaad regains 10 hit points, provided it has at least 1 hit point.",
			"***Multiattack.*** The slaad makes three attacks: one bite and two claw attacks.\n\n***Bite.*** *Melee Weapon Attack:* +8 to hit, reach 5 ft., one target. *Hit:* 12 (2d6 + 5) piercing damage.\n\n***Claw.*** *Melee Weapon Attack:* +8 to hit, reach 5 ft., one target. *Hit:* 12 (2d6 + 5) slashing damage. A humanoid hit makes a DC 15 Constitution saving throw or catches the chaos phage. While infected, it can't regain hit points and its hit point maximum drops by 10 (3d6) every 24 hours; if the maximum reaches 0, it instantly becomes a red slaad, or a green slaad if it can cast spells of 3rd level or higher. Only a wish spell reverses the transformation.",
			"",
			"",
			"",
			""));
}
