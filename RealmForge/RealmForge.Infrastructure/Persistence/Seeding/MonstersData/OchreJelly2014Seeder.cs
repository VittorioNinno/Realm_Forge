using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Ochre Jelly (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class OchreJelly2014Seeder
{
	public static Monster Build() => Create("ochre-jelly", null, ContentSource.Srd51, CreatureSize.Large, CreatureType.Ooze,
		8, 45, "6d10 + 12", 10, new[] { 15, 6, 14, 2, 6, 1 }, 2m, 450, 2, 8,
		new Text(
			"Ameba paglierina",
			null,
			"Melma Grande, senza allineamento",
			"8",
			"3 m, scalare 3 m",
			"",
			"",
			"",
			"acido",
			"fulmine, tagliente",
			"accecato, affascinato, assordato, indebolimento, prono, spaventato",
			"Percezione passiva 8, vista cieca 18 m (cecità oltre questo raggio)",
			"—",
			"***Amorfo.*** L'ameba può muoversi attraverso uno spazio stretto fino a 2,5 centimetri senza doversi stringere.\n\n***Movimenti del ragno.*** L'ameba può scalare le superfici difficili, inclusi i soffitti (lungo i quali si muove a testa in giù), senza effettuare una prova di caratteristica.",
			"***Pseudopode.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 9 (2d6 + 2) danni contundenti più 3 (1d6) danni da acido.",
			"",
			"***Scindersi.*** Quando un'ameba di taglia Media o superiore è soggetta a danni da fulmine o a danni taglienti, si scinde in due nuove amebe se possiede almeno 10 punti ferita. Ogni nuova ameba ha un numero di punti ferita pari alla metà dell'ameba originale, arrotondando per difetto. Le nuove amebe sono inferiori di una taglia rispetto a quella originale.",
			"",
			""),
		new Text(
			"Ochre Jelly",
			null,
			"Large ooze, unaligned",
			"8",
			"10 ft., climb 10 ft.",
			"",
			"",
			"",
			"acid",
			"lightning, slashing",
			"blinded, charmed, blinded, exhaustion, frightened, prone",
			"blindsight 60 ft. (blind beyond this radius), passive Perception 8",
			"—",
			"***Amorphous.*** The jelly can move through a space as narrow as 1 inch wide without squeezing.\n\n***Spider Climb.*** The jelly can climb difficult surfaces, including upside down on ceilings, without needing to make an ability check.",
			"***Pseudopod.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one target. *Hit:* 9 (2d6 + 2) bludgeoning damage plus 3 (1d6) acid damage.",
			"",
			"***Split.*** When a jelly that is Medium or larger is subjected to lightning or slashing damage, it splits into two new jellies if it has at least 10 hit points. Each new jelly has hit points equal to half the original jelly's, rounded down. New jellies are one size smaller than the original jelly.",
			"",
			""));
}
