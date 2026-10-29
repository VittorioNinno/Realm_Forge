using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Hydra (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Hydra2014Seeder
{
	public static Monster Build() => Create("hydra", null, ContentSource.Srd51, CreatureSize.Huge, CreatureType.Monstrosity,
		15, 172, "15d12 + 75", 30, new[] { 20, 12, 20, 2, 10, 7 }, 8m, 3900, 3, 16,
		new Text(
			"Idra",
			null,
			"Mostruosità Enorme, senza allineamento",
			"15 (armatura naturale)",
			"9 m, nuotare 9 m",
			"",
			"Percezione +6",
			"",
			"",
			"",
			"",
			"Percezione passiva 16, scurovisione 18 m",
			"—",
			"***Apnea.*** L'idra può trattenere il respiro per 1 ora.\n\n***Policefalia.*** L'idra possiede cinque teste. Finché ha più di una testa, dispone di vantaggio ai tiri salvezza contro le condizioni accecato, affascinato, assordato, privo di sensi, spaventato e stordito. Ogni volta che l'idra subisce 25 o più danni in un singolo turno, una delle teste muore. Se tutte le teste muoiono, l'idra muore. Alla fine del suo turno, due teste ricrescono per ogni testa morta dal suo ultimo turno, a meno che nel corso di tale periodo non abbia subito danni da fuoco. L'idra recupera 10 punti ferita per ogni testa ricresciuta in questo modo.\n\n***Sempre all'erta.*** Mentre l'idra dorme, almeno una delle sue teste rimane vigile.\n\n***Teste reattive.*** Per ogni testa che l'idra possiede oltre la prima, riceve una reazione extra che può essere usata soltanto per gli attacchi di opportunità.",
			"***Multiattacco.*** L'idra effettua un numero di attacchi con il morso pari al numero di teste che possiede.\n\n***Morso.*** *Attacco con arma da mischia:* +8 al tiro per colpire, portata 3 m, un bersaglio. *Colpito:* 10 (1d10 + 5) danni perforanti.",
			"",
			"",
			"",
			""),
		new Text(
			"Hydra",
			null,
			"Huge monstrosity, unaligned",
			"15 (natural armor)",
			"30 ft., swim 30 ft.",
			"",
			"Perception +6",
			"",
			"",
			"",
			"",
			"darkvision 60 ft., passive Perception 16",
			"—",
			"***Hold Breath.*** The hydra can hold its breath for 1 hour.\n\n***Multiple Heads.*** The hydra has five heads. While it has more than one head, the hydra has advantage on saving throws against being blinded, charmed, deafened, frightened, stunned, and knocked unconscious.\n\nWhenever the hydra takes 25 or more damage in a single turn, one of its heads dies. If all its heads die, the hydra dies.\nAt the end of its turn, it grows two heads for each of its heads that died since its last turn, unless it has taken fire damage since its last turn. The hydra regains 10 hit points for each head regrown in this way.\n\n***Reactive Heads.*** For each head the hydra has beyond one, it gets an extra reaction that can be used only for opportunity attacks.\n\n***Wakeful.*** While the hydra sleeps, at least one of its heads is awake.",
			"***Multiattack.*** The hydra makes as many bite attacks as it has heads.\n\n***Bite.*** *Melee Weapon Attack:* +8 to hit, reach 10 ft., one target. *Hit:* 10 (1d10 + 5) piercing damage.",
			"",
			"",
			"",
			""));
}
