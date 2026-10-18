using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Summon Aberration (2024 ruleset). Not part of SRD 5.2: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class SummonAberration2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "summon-aberration");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			Level = 4,
			School = SpellSchool.Conjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "summon-aberration", "en"),
					Language = LanguageCode.En,
					Name = "Summon Aberration",
					CastingTime = "Action",
					Range = "90 feet",
					Duration = "Concentration, up to 1 hour",
					MaterialComponent = "a brined tentacle and an eye kept together in a vial inlaid with platinum, worth 400+ GP",
					Description = "You reach past the stars and drag back an alien spirit, which forms in an unoccupied space you can see within range. Its statistics are given in the **Aberrant Spirit** block below. Pick its form when you cast the spell (Ocular, Psionic, or Amphibian); the form shapes its alien appearance and decides which of the form-specific entries apply. The spirit is gone as soon as its Hit Points reach 0 or the spell ends.\n\nThe spirit fights on your side and is friendly to your companions. It doesn't roll its own Initiative: it acts immediately after you, on your turn. You can direct it with spoken orders at no cost in actions; left without orders, it takes the Dodge action and moves only to avoid harm.\n\n#### Aberrant Spirit\n\n*Medium Aberration, Neutral*\n\n**AC** 11 + spell level · **HP** 40, plus 10 per spell level above 4 · **Speed** 30 ft.; Fly 30 ft. and can hover (Ocular only)\n\n| Ability | Score | Mod | Save |\n|---|---|---|---|\n| STR | 16 | +3 | +3 |\n| DEX | 10 | +0 | +0 |\n| CON | 15 | +2 | +2 |\n| INT | 16 | +3 | +3 |\n| WIS | 10 | +0 | +0 |\n| CHA | 6 | −2 | −2 |\n\n**Immune** Psychic damage · **Senses** Darkvision 60 ft., Passive Perception 10 · **Languages** Deep Speech; understands every language you know · **Challenge** none (XP 0); uses your Proficiency Bonus\n\n**Features**\n\n- **Knitting Flesh (Amphibian).** As long as it has 1 or more Hit Points, the spirit heals 5 Hit Points when its turn starts.\n- **Psychic Murmur (Psionic).** When its turn starts, unless it is Incapacitated, the spirit gives off a wave of mental static. Every creature other than you within 5 feet of it makes a Wisdom saving throw against your spell save DC, suffering 2d6 Psychic damage on a failure.\n\n**Actions**\n\n- **Multiattack.** The spirit attacks a number of times equal to half the spell level, rounded down.\n- **Rending Claw (Amphibian).** Melee attack using your spell attack modifier, reach 5 ft. On a hit: Slashing damage equal to 1d10 + 3 + spell level, and the target can't regain Hit Points until the spirit's next turn begins.\n- **Gaze Beam (Ocular).** Ranged attack using your spell attack modifier, range 150 ft. On a hit: Psychic damage equal to 1d8 + 3 + spell level.\n- **Mind Crush (Psionic).** Melee attack using your spell attack modifier, reach 5 ft. On a hit: Psychic damage equal to 1d8 + 3 + spell level.",
					HigherLevels = "Wherever the stat block refers to the spell level, use the level of the slot you spent."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "summon-aberration", "it"),
					Language = LanguageCode.It,
					Name = "Richiama Aberrazione",
					CastingTime = "Azione",
					Range = "27 metri",
					Duration = "Concentrazione, fino a 1 ora",
					MaterialComponent = "un tentacolo in salamoia e un occhio conservati insieme in una fiala intarsiata di platino, del valore di almeno 400 mo",
					Description = "L'incantatore si spinge oltre le stelle e ne riporta uno spirito alieno, che si forma in uno spazio libero entro gittata che è in grado di vedere. Le sue statistiche sono riportate nella scheda dello **Spirito Aberrante** qui sotto. Al momento del lancio l'incantatore sceglie la sua forma (Oculare, Psionica o Anfibia); la forma ne determina l'aspetto alieno e decide quali voci specifiche si applicano. Lo spirito scompare non appena i suoi punti ferita scendono a 0 o l'incantesimo termina.\n\nLo spirito combatte dalla parte dell'incantatore ed è amichevole verso i suoi compagni. Non tira la propria Iniziativa: agisce subito dopo l'incantatore, nel turno di quest'ultimo. L'incantatore può guidarlo con ordini verbali senza spendere azioni; se non riceve ordini, lo spirito effettua l'azione di Schivata e si muove soltanto per evitare danni.\n\n#### Spirito Aberrante\n\n*Aberrazione Media, neutrale*\n\n**CA** 11 + livello dell'incantesimo · **PF** 40, più 10 per ogni livello dell'incantesimo oltre il 4° · **Velocità** 9 m; volare 9 m e può fluttuare (solo Oculare)\n\n| Caratteristica | Punteggio | Mod | TS |\n|---|---|---|---|\n| FOR | 16 | +3 | +3 |\n| DES | 10 | +0 | +0 |\n| COS | 15 | +2 | +2 |\n| INT | 16 | +3 | +3 |\n| SAG | 10 | +0 | +0 |\n| CAR | 6 | −2 | −2 |\n\n**Immune** ai danni psichici · **Sensi** scurovisione 18 m, Percezione passiva 10 · **Linguaggi** Gergo delle Profondità; comprende tutti i linguaggi conosciuti dall'incantatore · **Grado di sfida** nessuno (PE 0); usa il bonus di competenza dell'incantatore\n\n**Capacità**\n\n- **Carne Rigenerante (Anfibia).** Finché ha almeno 1 punto ferita, lo spirito recupera 5 punti ferita quando inizia il suo turno.\n- **Mormorio Psichico (Psionica).** Quando inizia il suo turno, a meno che non sia incapacitato, lo spirito emette un'ondata di disturbo mentale. Ogni creatura diversa dall'incantatore entro 1,5 metri da lui effettua un tiro salvezza su Saggezza contro la CD del tiro salvezza degli incantesimi dell'incantatore e, se fallisce, subisce 2d6 danni psichici.\n\n**Azioni**\n\n- **Multiattacco.** Lo spirito attacca un numero di volte pari alla metà del livello dell'incantesimo, arrotondata per difetto.\n- **Artiglio Lacerante (Anfibia).** Attacco in mischia con il modificatore di attacco con incantesimo dell'incantatore, portata 1,5 m. Se colpisce: danni taglienti pari a 1d10 + 3 + livello dell'incantesimo, e il bersaglio non può recuperare punti ferita finché non inizia il turno successivo dello spirito.\n- **Raggio dello Sguardo (Oculare).** Attacco a distanza con il modificatore di attacco con incantesimo dell'incantatore, gittata 45 m. Se colpisce: danni psichici pari a 1d8 + 3 + livello dell'incantesimo.\n- **Schiacciamento Mentale (Psionica).** Attacco in mischia con il modificatore di attacco con incantesimo dell'incantatore, portata 1,5 m. Se colpisce: danni psichici pari a 1d8 + 3 + livello dell'incantesimo.",
					HigherLevels = "Ovunque la scheda faccia riferimento al livello dell'incantesimo, si usa il livello dello slot speso."
				}
			}
		};
	}
}
