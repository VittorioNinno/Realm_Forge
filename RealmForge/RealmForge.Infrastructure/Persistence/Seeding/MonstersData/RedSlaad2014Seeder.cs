using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Red Slaad (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class RedSlaad2014Seeder
{
	public static Monster Build() => Create("red-slaad", null, ContentSource.RealmForge, CreatureSize.Large, CreatureType.Aberration,
		14, 93, "11d10 + 33", 30, new[] { 16, 12, 16, 6, 6, 7 }, 5m, 1800, 3, 11,
		new Text(
			"Slaad rosso",
			null,
			"Aberrazione Grande, caotico neutrale",
			"14 (armatura naturale)",
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
			"***Multiattacco.*** Lo slaad effettua tre attacchi: uno con il morso e due con gli artigli.\n\n***Morso.*** *Attacco con arma da mischia:* +6 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 8 (2d4 + 3) danni perforanti.\n\n***Artiglio.*** *Attacco con arma da mischia:* +6 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 7 (1d8 + 3) danni perforanti. Un umanoide colpito effettua un tiro salvezza su Costituzione con CD 14, altrimenti contrae una malattia: un minuscolo uovo di slaad. Un ospite porta un solo uovo alla volta; nell'arco di tre mesi l'uovo si sposta nel torace e diventa uno slaad girino. Nelle ultime 24 ore l'ospite si sente male, la sua velocità è dimezzata e subisce svantaggio ai tiri per colpire, alle prove di caratteristica e ai tiri salvezza; poi il girino si apre la strada a morsi fuori dal torace in 1 round, uccidendo l'ospite. Curare la malattia prima di allora distrugge lo slaad non ancora nato.",
			"",
			"",
			"",
			""),
		new Text(
			"Red Slaad",
			null,
			"Large aberration, chaotic neutral",
			"14 (natural armor)",
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
			"***Multiattack.*** The slaad makes three attacks: one bite and two claw attacks.\n\n***Bite.*** *Melee Weapon Attack:* +6 to hit, reach 5 ft., one target. *Hit:* 8 (2d4 + 3) piercing damage.\n\n***Claw.*** *Melee Weapon Attack:* +6 to hit, reach 5 ft., one target. *Hit:* 7 (1d8 + 3) piercing damage. A humanoid hit makes a DC 14 Constitution saving throw or is infected with a disease: a tiny slaad egg. A host carries one egg at a time; over three months it moves into the chest and grows into a slaad tadpole. In the last 24 hours the host feels ill, its speed is halved and it has disadvantage on attack rolls, ability checks and saving throws; then the tadpole bites its way out of the chest in 1 round, killing the host. Curing the disease before then destroys the unborn slaad.",
			"",
			"",
			"",
			""));
}
