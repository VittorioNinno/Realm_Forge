using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Summon Celestial (2024 ruleset). Not part of SRD 5.2: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class SummonCelestial2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "summon-celestial");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			Level = 5,
			School = SpellSchool.Conjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric, SpellcastingClass.Paladin },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "summon-celestial", "en"),
					Language = LanguageCode.En,
					Name = "Summon Celestial",
					CastingTime = "Action",
					Range = "90 feet",
					Duration = "Concentration, up to 1 hour",
					MaterialComponent = "a reliquary worth 500+ GP",
					Description = "A spirit of the Upper Planes descends at your call and takes a radiant, angelic form in an unoccupied space you can see within range. Its statistics are given in the **Celestial Spirit** block below. Pick its calling when you cast the spell (Avenger or Guardian); the calling decides which of the calling-specific entries apply. The spirit is gone as soon as its Hit Points reach 0 or the spell ends.\n\nThe spirit fights on your side and is friendly to your companions. It doesn't roll its own Initiative: it acts immediately after you, on your turn. You can direct it with spoken orders at no cost in actions; left without orders, it takes the Dodge action and moves only to avoid harm.\n\n#### Celestial Spirit\n\n*Large Celestial, Neutral*\n\n**AC** 11 + spell level (+2 more for a Guardian) · **HP** 40, plus 10 per spell level above 5 · **Speed** 30 ft.; Fly 40 ft.\n\n| Ability | Score | Mod | Save |\n|---|---|---|---|\n| STR | 16 | +3 | +3 |\n| DEX | 14 | +2 | +2 |\n| CON | 16 | +3 | +3 |\n| INT | 10 | +0 | +0 |\n| WIS | 14 | +2 | +2 |\n| CHA | 16 | +3 | +3 |\n\n**Resistant** to Radiant damage · **Immune** to the Charmed and Frightened conditions · **Senses** Darkvision 60 ft., Passive Perception 12 · **Languages** Celestial; understands every language you know · **Challenge** none (XP 0); uses your Proficiency Bonus\n\n**Actions**\n\n- **Multiattack.** The spirit attacks a number of times equal to half the spell level, rounded down.\n- **Dawnbow (Avenger).** Ranged attack using your spell attack modifier, range 600 ft. On a hit: Radiant damage equal to 2d6 + 2 + spell level.\n- **Dawnmace (Guardian).** Melee attack using your spell attack modifier, reach 5 ft. On a hit: Radiant damage equal to 1d10 + 3 + spell level, and the spirit grants 1d10 Temporary Hit Points either to itself or to another creature it can see within 10 feet of the target.\n- **Mending Light (once per day).** The spirit touches a creature other than itself, restoring Hit Points equal to 2d8 + spell level.",
					HigherLevels = "Wherever the stat block refers to the spell level, use the level of the slot you spent."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "summon-celestial", "it"),
					Language = LanguageCode.It,
					Name = "Richiama Celestiale",
					CastingTime = "Azione",
					Range = "27 metri",
					Duration = "Concentrazione, fino a 1 ora",
					MaterialComponent = "un reliquiario del valore di almeno 500 mo",
					Description = "Uno spirito dei Piani Superiori discende al richiamo dell'incantatore e assume una forma angelica e radiosa in uno spazio libero entro gittata che questi è in grado di vedere. Le sue statistiche sono riportate nella scheda dello **Spirito Celestiale** qui sotto. Al momento del lancio l'incantatore sceglie la sua vocazione (Vendicatore o Custode); la vocazione decide quali voci specifiche si applicano. Lo spirito scompare non appena i suoi punti ferita scendono a 0 o l'incantesimo termina.\n\nLo spirito combatte dalla parte dell'incantatore ed è amichevole verso i suoi compagni. Non tira la propria Iniziativa: agisce subito dopo l'incantatore, nel turno di quest'ultimo. L'incantatore può guidarlo con ordini verbali senza spendere azioni; se non riceve ordini, lo spirito effettua l'azione di Schivata e si muove soltanto per evitare danni.\n\n#### Spirito Celestiale\n\n*Celestiale Grande, neutrale*\n\n**CA** 11 + livello dell'incantesimo (+2 in più per un Custode) · **PF** 40, più 10 per ogni livello dell'incantesimo oltre il 5° · **Velocità** 9 m; volare 12 m\n\n| Caratteristica | Punteggio | Mod | TS |\n|---|---|---|---|\n| FOR | 16 | +3 | +3 |\n| DES | 14 | +2 | +2 |\n| COS | 16 | +3 | +3 |\n| INT | 10 | +0 | +0 |\n| SAG | 14 | +2 | +2 |\n| CAR | 16 | +3 | +3 |\n\n**Resistente** ai danni radiosi · **Immune** alle condizioni affascinato e spaventato · **Sensi** scurovisione 18 m, Percezione passiva 12 · **Linguaggi** Celestiale; comprende tutti i linguaggi conosciuti dall'incantatore · **Grado di sfida** nessuno (PE 0); usa il bonus di competenza dell'incantatore\n\n**Azioni**\n\n- **Multiattacco.** Lo spirito attacca un numero di volte pari alla metà del livello dell'incantesimo, arrotondata per difetto.\n- **Arco dell'Alba (Vendicatore).** Attacco a distanza con il modificatore di attacco con incantesimo dell'incantatore, gittata 180 m. Se colpisce: danni radiosi pari a 2d6 + 2 + livello dell'incantesimo.\n- **Mazza dell'Alba (Custode).** Attacco in mischia con il modificatore di attacco con incantesimo dell'incantatore, portata 1,5 m. Se colpisce: danni radiosi pari a 1d10 + 3 + livello dell'incantesimo, e lo spirito concede 1d10 punti ferita temporanei a se stesso o a un'altra creatura che è in grado di vedere entro 3 metri dal bersaglio.\n- **Luce Risanatrice (una volta al giorno).** Lo spirito tocca una creatura diversa da sé e le fa recuperare punti ferita pari a 2d8 + livello dell'incantesimo.",
					HigherLevels = "Ovunque la scheda faccia riferimento al livello dell'incantesimo, si usa il livello dello slot speso."
				}
			}
		};
	}
}
