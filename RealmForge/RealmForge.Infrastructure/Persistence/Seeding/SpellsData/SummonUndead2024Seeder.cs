using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Summon Undead (2024 ruleset). Not part of SRD 5.2: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class SummonUndead2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "summon-undead");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			Level = 3,
			School = SpellSchool.Necromancy,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "summon-undead", "en"),
					Language = LanguageCode.En,
					Name = "Summon Undead",
					CastingTime = "Action",
					Range = "90 feet",
					Duration = "Concentration, up to 1 hour",
					MaterialComponent = "a skull covered in gold leaf, worth 300+ GP",
					Description = "You rouse an uneasy spirit of the dead, and it forms in an unoccupied space you can see within range. Its statistics are given in the **Undead Spirit** block below. Pick its form when you cast the spell (Spectral, Rotting, or Skeletal); the form shapes its look and decides which of the form-specific entries apply. The spirit is gone as soon as its Hit Points reach 0 or the spell ends.\n\nThe spirit fights on your side and is friendly to your companions. It doesn't roll its own Initiative: it acts immediately after you, on your turn. You can direct it with spoken orders at no cost in actions; left without orders, it takes the Dodge action and moves only to avoid harm.\n\n#### Undead Spirit\n\n*Medium Undead, Neutral*\n\n**AC** 11 + spell level · **HP** 30 (Spectral, Rotting) or 20 (Skeletal), plus 10 per spell level above 3 · **Speed** 30 ft.; Fly 40 ft. and can hover (Spectral only)\n\n| Ability | Score | Mod | Save |\n|---|---|---|---|\n| STR | 12 | +1 | +1 |\n| DEX | 16 | +3 | +3 |\n| CON | 15 | +2 | +2 |\n| INT | 4 | −3 | −3 |\n| WIS | 10 | +0 | +0 |\n| CHA | 9 | −1 | −1 |\n\n**Immune** to Necrotic and Poison damage, Exhaustion, and the Frightened, Paralyzed, and Poisoned conditions · **Senses** Darkvision 60 ft., Passive Perception 10 · **Languages** understands every language you know · **Challenge** none (XP 0); uses your Proficiency Bonus\n\n**Features**\n\n- **Grave Stench (Rotting).** Any creature other than you that starts its turn within 5 feet of the spirit makes a Constitution saving throw against your spell save DC; on a failure, it is Poisoned until its next turn starts.\n- **Drifting Shade (Spectral).** The spirit can pass through creatures and objects, treating them as Difficult Terrain. If its turn ends while it is inside an object, it is shunted to the nearest unoccupied space and suffers 1d10 Force damage for every 5 feet it is moved.\n\n**Actions**\n\n- **Multiattack.** The spirit attacks a number of times equal to half the spell level, rounded down.\n- **Grave Chill (Spectral).** Melee attack using your spell attack modifier, reach 5 ft. On a hit: Necrotic damage equal to 1d8 + 3 + spell level, and the target is Frightened until its next turn ends.\n- **Bone Shard (Skeletal).** Ranged attack using your spell attack modifier, range 150 ft. On a hit: Necrotic damage equal to 2d4 + 3 + spell level.\n- **Rotting Claw (Rotting).** Melee attack using your spell attack modifier, reach 5 ft. On a hit: Slashing damage equal to 1d6 + 3 + spell level; a target that is Poisoned is also Paralyzed until its next turn ends.",
					HigherLevels = "Wherever the stat block refers to the spell level, use the level of the slot you spent."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "summon-undead", "it"),
					Language = LanguageCode.It,
					Name = "Richiama Non Morto",
					CastingTime = "Azione",
					Range = "27 metri",
					Duration = "Concentrazione, fino a 1 ora",
					MaterialComponent = "un teschio rivestito di foglia d'oro, del valore di almeno 300 mo",
					Description = "L'incantatore ridesta uno spirito inquieto dei morti, che si forma in uno spazio libero entro gittata che questi è in grado di vedere. Le sue statistiche sono riportate nella scheda dello **Spirito Non Morto** qui sotto. Al momento del lancio l'incantatore sceglie la sua forma (Spettrale, Putrescente o Scheletrica); la forma ne determina l'aspetto e decide quali voci specifiche si applicano. Lo spirito scompare non appena i suoi punti ferita scendono a 0 o l'incantesimo termina.\n\nLo spirito combatte dalla parte dell'incantatore ed è amichevole verso i suoi compagni. Non tira la propria Iniziativa: agisce subito dopo l'incantatore, nel turno di quest'ultimo. L'incantatore può guidarlo con ordini verbali senza spendere azioni; se non riceve ordini, lo spirito effettua l'azione di Schivata e si muove soltanto per evitare danni.\n\n#### Spirito Non Morto\n\n*Non morto Medio, neutrale*\n\n**CA** 11 + livello dell'incantesimo · **PF** 30 (Spettrale, Putrescente) o 20 (Scheletrica), più 10 per ogni livello dell'incantesimo oltre il 3° · **Velocità** 9 m; volare 12 m e può fluttuare (solo Spettrale)\n\n| Caratteristica | Punteggio | Mod | TS |\n|---|---|---|---|\n| FOR | 12 | +1 | +1 |\n| DES | 16 | +3 | +3 |\n| COS | 15 | +2 | +2 |\n| INT | 4 | −3 | −3 |\n| SAG | 10 | +0 | +0 |\n| CAR | 9 | −1 | −1 |\n\n**Immune** ai danni necrotici e da veleno, all'indebolimento e alle condizioni avvelenato, paralizzato e spaventato · **Sensi** scurovisione 18 m, Percezione passiva 10 · **Linguaggi** comprende tutti i linguaggi conosciuti dall'incantatore · **Grado di sfida** nessuno (PE 0); usa il bonus di competenza dell'incantatore\n\n**Capacità**\n\n- **Fetore della Tomba (Putrescente).** Qualsiasi creatura diversa dall'incantatore che inizia il proprio turno entro 1,5 metri dallo spirito effettua un tiro salvezza su Costituzione contro la CD del tiro salvezza degli incantesimi dell'incantatore; se fallisce, è avvelenata finché non inizia il suo turno successivo.\n- **Ombra Fluttuante (Spettrale).** Lo spirito può attraversare creature e oggetti, trattandoli come terreno difficile. Se il suo turno termina mentre si trova dentro un oggetto, viene spostato nello spazio libero più vicino e subisce 1d10 danni da forza per ogni 1,5 metri di spostamento.\n\n**Azioni**\n\n- **Multiattacco.** Lo spirito attacca un numero di volte pari alla metà del livello dell'incantesimo, arrotondata per difetto.\n- **Gelo della Tomba (Spettrale).** Attacco in mischia con il modificatore di attacco con incantesimo dell'incantatore, portata 1,5 m. Se colpisce: danni necrotici pari a 1d8 + 3 + livello dell'incantesimo, e il bersaglio è spaventato fino al termine del suo turno successivo.\n- **Scheggia d'Osso (Scheletrica).** Attacco a distanza con il modificatore di attacco con incantesimo dell'incantatore, gittata 45 m. Se colpisce: danni necrotici pari a 2d4 + 3 + livello dell'incantesimo.\n- **Artiglio Marcescente (Putrescente).** Attacco in mischia con il modificatore di attacco con incantesimo dell'incantatore, portata 1,5 m. Se colpisce: danni taglienti pari a 1d6 + 3 + livello dell'incantesimo; un bersaglio avvelenato è anche paralizzato fino al termine del suo turno successivo.",
					HigherLevels = "Ovunque la scheda faccia riferimento al livello dell'incantesimo, si usa il livello dello slot speso."
				}
			}
		};
	}
}
