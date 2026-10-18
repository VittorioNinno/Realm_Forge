using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Summon Fiend (2024 ruleset). Not part of SRD 5.2: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class SummonFiend2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "summon-fiend");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			Level = 6,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "summon-fiend", "en"),
					Language = LanguageCode.En,
					Name = "Summon Fiend",
					CastingTime = "Action",
					Range = "90 feet",
					Duration = "Concentration, up to 1 hour",
					MaterialComponent = "a vial stained with blood, worth 600+ GP",
					Description = "You call a spirit up from the Lower Planes, and it forms in an unoccupied space you can see within range. Its statistics are given in the **Fiendish Spirit** block below. Pick its kind when you cast the spell (Demon, Devil, or Mercenary, a fiend of the neutral evil planes); the kind shapes its look and decides which of the kind-specific entries apply. The spirit is gone as soon as its Hit Points reach 0 or the spell ends.\n\nThe spirit fights on your side and is friendly to your companions. It doesn't roll its own Initiative: it acts immediately after you, on your turn. You can direct it with spoken orders at no cost in actions; left without orders, it takes the Dodge action and moves only to avoid harm.\n\n#### Fiendish Spirit\n\n*Large Fiend, Neutral*\n\n**AC** 12 + spell level · **HP** 50 (Demon), 40 (Devil), or 60 (Mercenary), plus 15 per spell level above 6 · **Speed** 40 ft.; Climb 40 ft. (Demon only); Fly 60 ft. (Devil only)\n\n| Ability | Score | Mod | Save |\n|---|---|---|---|\n| STR | 13 | +1 | +1 |\n| DEX | 16 | +3 | +3 |\n| CON | 15 | +2 | +2 |\n| INT | 10 | +0 | +0 |\n| WIS | 10 | +0 | +0 |\n| CHA | 16 | +3 | +3 |\n\n**Resistant** to Fire damage · **Immune** to Poison damage and the Poisoned condition · **Senses** Darkvision 60 ft., Passive Perception 10 · **Languages** Abyssal, Infernal; telepathy 60 ft. · **Challenge** none (XP 0); uses your Proficiency Bonus\n\n**Features**\n\n- **Death Burst (Demon).** When the spirit drops to 0 Hit Points or the spell ends, it bursts in flame. Each creature in a 10-foot Emanation around it makes a Dexterity saving throw against your spell save DC, suffering Fire damage equal to 2d10 + spell level on a failure, or half as much on a success.\n- **Pitch-Dark Vision (Devil).** The spirit's Darkvision works normally in magical Darkness.\n- **Magic Resistance.** Saving throws the spirit makes against spells and other magical effects have Advantage.\n\n**Actions**\n\n- **Multiattack.** The spirit attacks a number of times equal to half the spell level, rounded down.\n- **Gnashing Jaws (Demon).** Melee attack using your spell attack modifier, reach 5 ft. On a hit: Necrotic damage equal to 1d12 + 3 + spell level.\n- **Raking Talons (Mercenary).** Melee attack using your spell attack modifier, reach 5 ft. On a hit: Slashing damage equal to 1d8 + 3 + spell level. Whether the attack hits or not, the spirit can then teleport to an unoccupied space it can see up to 30 feet away.\n- **Infernal Flame (Devil).** Melee or ranged attack using your spell attack modifier, reach 5 ft. or range 150 ft. On a hit: Fire damage equal to 2d6 + 3 + spell level.",
					HigherLevels = "Wherever the stat block refers to the spell level, use the level of the slot you spent."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "summon-fiend", "it"),
					Language = LanguageCode.It,
					Name = "Richiama Immondo",
					CastingTime = "Azione",
					Range = "27 metri",
					Duration = "Concentrazione, fino a 1 ora",
					MaterialComponent = "una fiala macchiata di sangue, del valore di almeno 600 mo",
					Description = "L'incantatore richiama uno spirito dai Piani Inferiori, che si forma in uno spazio libero entro gittata che questi è in grado di vedere. Le sue statistiche sono riportate nella scheda dello **Spirito Immondo** qui sotto. Al momento del lancio l'incantatore sceglie la sua specie (Demone, Diavolo o Mercenario, un immondo dei piani neutrali malvagi); la specie ne determina l'aspetto e decide quali voci specifiche si applicano. Lo spirito scompare non appena i suoi punti ferita scendono a 0 o l'incantesimo termina.\n\nLo spirito combatte dalla parte dell'incantatore ed è amichevole verso i suoi compagni. Non tira la propria Iniziativa: agisce subito dopo l'incantatore, nel turno di quest'ultimo. L'incantatore può guidarlo con ordini verbali senza spendere azioni; se non riceve ordini, lo spirito effettua l'azione di Schivata e si muove soltanto per evitare danni.\n\n#### Spirito Immondo\n\n*Immondo Grande, neutrale*\n\n**CA** 12 + livello dell'incantesimo · **PF** 50 (Demone), 40 (Diavolo) o 60 (Mercenario), più 15 per ogni livello dell'incantesimo oltre il 6° · **Velocità** 12 m; scalare 12 m (solo Demone); volare 18 m (solo Diavolo)\n\n| Caratteristica | Punteggio | Mod | TS |\n|---|---|---|---|\n| FOR | 13 | +1 | +1 |\n| DES | 16 | +3 | +3 |\n| COS | 15 | +2 | +2 |\n| INT | 10 | +0 | +0 |\n| SAG | 10 | +0 | +0 |\n| CAR | 16 | +3 | +3 |\n\n**Resistente** ai danni da fuoco · **Immune** ai danni da veleno e alla condizione avvelenato · **Sensi** scurovisione 18 m, Percezione passiva 10 · **Linguaggi** Abissale, Infernale; telepatia 18 m · **Grado di sfida** nessuno (PE 0); usa il bonus di competenza dell'incantatore\n\n**Capacità**\n\n- **Esplosione Mortale (Demone).** Quando lo spirito scende a 0 punti ferita o l'incantesimo termina, erompe in una vampata di fiamme. Ogni creatura in un'emanazione di 3 metri attorno a lui effettua un tiro salvezza su Destrezza contro la CD del tiro salvezza degli incantesimi dell'incantatore e subisce danni da fuoco pari a 2d10 + livello dell'incantesimo se fallisce, o la metà se riesce.\n- **Vista nella Tenebra (Diavolo).** La scurovisione dello spirito funziona normalmente nell'oscurità magica.\n- **Resistenza alla Magia.** I tiri salvezza dello spirito contro incantesimi e altri effetti magici hanno vantaggio.\n\n**Azioni**\n\n- **Multiattacco.** Lo spirito attacca un numero di volte pari alla metà del livello dell'incantesimo, arrotondata per difetto.\n- **Fauci Digrignanti (Demone).** Attacco in mischia con il modificatore di attacco con incantesimo dell'incantatore, portata 1,5 m. Se colpisce: danni necrotici pari a 1d12 + 3 + livello dell'incantesimo.\n- **Artigli Rapaci (Mercenario).** Attacco in mischia con il modificatore di attacco con incantesimo dell'incantatore, portata 1,5 m. Se colpisce: danni taglienti pari a 1d8 + 3 + livello dell'incantesimo. Che l'attacco vada a segno o meno, lo spirito può poi teletrasportarsi in uno spazio libero che è in grado di vedere entro 9 metri.\n- **Fiamma Infernale (Diavolo).** Attacco in mischia o a distanza con il modificatore di attacco con incantesimo dell'incantatore, portata 1,5 m o gittata 45 m. Se colpisce: danni da fuoco pari a 2d6 + 3 + livello dell'incantesimo.",
					HigherLevels = "Ovunque la scheda faccia riferimento al livello dell'incantesimo, si usa il livello dello slot speso."
				}
			}
		};
	}
}
