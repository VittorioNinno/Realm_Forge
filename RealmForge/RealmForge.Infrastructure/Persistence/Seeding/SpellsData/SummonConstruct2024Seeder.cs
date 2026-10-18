using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Summon Construct (2024 ruleset). Not part of SRD 5.2: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class SummonConstruct2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "summon-construct");

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
			Classes = new List<SpellcastingClass> { SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "summon-construct", "en"),
					Language = LanguageCode.En,
					Name = "Summon Construct",
					CastingTime = "Action",
					Range = "90 feet",
					Duration = "Concentration, up to 1 hour",
					MaterialComponent = "a locked strongbox worth 400+ GP",
					Description = "You give life to a spirit bound in crafted matter, and it forms in an unoccupied space you can see within range as an animated statue whose look you decide. Its statistics are given in the **Construct Spirit** block below. Pick its material when you cast the spell (Clay, Metal, or Stone); the material decides which of the material-specific entries apply. The spirit is gone as soon as its Hit Points reach 0 or the spell ends.\n\nThe spirit fights on your side and is friendly to your companions. It doesn't roll its own Initiative: it acts immediately after you, on your turn. You can direct it with spoken orders at no cost in actions; left without orders, it takes the Dodge action and moves only to avoid harm.\n\n#### Construct Spirit\n\n*Medium Construct, Neutral*\n\n**AC** 13 + spell level · **HP** 40, plus 15 per spell level above 4 · **Speed** 30 ft.\n\n| Ability | Score | Mod | Save |\n|---|---|---|---|\n| STR | 18 | +4 | +4 |\n| DEX | 10 | +0 | +0 |\n| CON | 18 | +4 | +4 |\n| INT | 14 | +2 | +2 |\n| WIS | 11 | +0 | +0 |\n| CHA | 5 | −3 | −3 |\n\n**Resistant** to Poison damage · **Immune** to Exhaustion and to the Charmed, Frightened, Paralyzed, and Poisoned conditions · **Senses** Darkvision 60 ft., Passive Perception 10 · **Languages** understands every language you know · **Challenge** none (XP 0); uses your Proficiency Bonus\n\n**Features**\n\n- **Searing Frame (Metal).** Any creature that hits the spirit with a melee attack suffers 1d10 Fire damage, and so does a creature that starts its turn grappling the spirit or being grappled by it.\n- **Leaden Aura (Stone).** When a creature the spirit can see starts its turn within 10 feet of it, the spirit can weigh that creature down. The creature makes a Wisdom saving throw against your spell save DC; on a failure, until its next turn starts, its Speed is halved and it can't make Opportunity Attacks.\n\n**Actions**\n\n- **Multiattack.** The spirit makes Pound attacks equal in number to half the spell level, rounded down.\n- **Pound.** Melee attack using your spell attack modifier, reach 5 ft. On a hit: Bludgeoning damage equal to 1d8 + 4 + spell level.\n\n**Reactions**\n\n- **Retaliation (Clay).** When a creature damages the spirit, the spirit makes a Pound attack against it if it can; if it can't, it moves up to half its Speed toward that creature, and this movement doesn't provoke Opportunity Attacks.",
					HigherLevels = "Wherever the stat block refers to the spell level, use the level of the slot you spent."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "summon-construct", "it"),
					Language = LanguageCode.It,
					Name = "Richiama Costrutto",
					CastingTime = "Azione",
					Range = "27 metri",
					Duration = "Concentrazione, fino a 1 ora",
					MaterialComponent = "un forziere chiuso a chiave del valore di almeno 400 mo",
					Description = "L'incantatore dà vita a uno spirito racchiuso in materia lavorata, che si forma in uno spazio libero entro gittata che questi è in grado di vedere, come una statua animata dall'aspetto deciso dall'incantatore. Le sue statistiche sono riportate nella scheda dello **Spirito Costrutto** qui sotto. Al momento del lancio l'incantatore sceglie il suo materiale (Argilla, Metallo o Pietra); il materiale decide quali voci specifiche si applicano. Lo spirito scompare non appena i suoi punti ferita scendono a 0 o l'incantesimo termina.\n\nLo spirito combatte dalla parte dell'incantatore ed è amichevole verso i suoi compagni. Non tira la propria Iniziativa: agisce subito dopo l'incantatore, nel turno di quest'ultimo. L'incantatore può guidarlo con ordini verbali senza spendere azioni; se non riceve ordini, lo spirito effettua l'azione di Schivata e si muove soltanto per evitare danni.\n\n#### Spirito Costrutto\n\n*Costrutto Medio, neutrale*\n\n**CA** 13 + livello dell'incantesimo · **PF** 40, più 15 per ogni livello dell'incantesimo oltre il 4° · **Velocità** 9 m\n\n| Caratteristica | Punteggio | Mod | TS |\n|---|---|---|---|\n| FOR | 18 | +4 | +4 |\n| DES | 10 | +0 | +0 |\n| COS | 18 | +4 | +4 |\n| INT | 14 | +2 | +2 |\n| SAG | 11 | +0 | +0 |\n| CAR | 5 | −3 | −3 |\n\n**Resistente** ai danni da veleno · **Immune** all'indebolimento e alle condizioni affascinato, avvelenato, paralizzato e spaventato · **Sensi** scurovisione 18 m, Percezione passiva 10 · **Linguaggi** comprende tutti i linguaggi conosciuti dall'incantatore · **Grado di sfida** nessuno (PE 0); usa il bonus di competenza dell'incantatore\n\n**Capacità**\n\n- **Struttura Ardente (Metallo).** Qualsiasi creatura che colpisce lo spirito con un attacco in mischia subisce 1d10 danni da fuoco, così come una creatura che inizia il proprio turno mentre afferra lo spirito o ne è afferrata.\n- **Aura Plumbea (Pietra).** Quando una creatura che lo spirito è in grado di vedere inizia il proprio turno entro 3 metri da lui, lo spirito può appesantirla. La creatura effettua un tiro salvezza su Saggezza contro la CD del tiro salvezza degli incantesimi dell'incantatore; se fallisce, finché non inizia il suo turno successivo la sua velocità è dimezzata e non può effettuare attacchi di opportunità.\n\n**Azioni**\n\n- **Multiattacco.** Lo spirito effettua un numero di attacchi di Martello pari alla metà del livello dell'incantesimo, arrotondata per difetto.\n- **Martello.** Attacco in mischia con il modificatore di attacco con incantesimo dell'incantatore, portata 1,5 m. Se colpisce: danni contundenti pari a 1d8 + 4 + livello dell'incantesimo.\n\n**Reazioni**\n\n- **Ritorsione (Argilla).** Quando una creatura infligge danni allo spirito, lo spirito effettua contro di lei un attacco di Martello, se può; se non può, si muove fino a metà della sua velocità verso quella creatura, e questo movimento non provoca attacchi di opportunità.",
					HigherLevels = "Ovunque la scheda faccia riferimento al livello dell'incantesimo, si usa il livello dello slot speso."
				}
			}
		};
	}
}
