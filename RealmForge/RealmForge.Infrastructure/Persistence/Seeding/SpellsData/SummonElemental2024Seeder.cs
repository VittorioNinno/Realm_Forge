using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Summon Elemental (2024 ruleset). Not part of SRD 5.2: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class SummonElemental2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "summon-elemental");

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
			Classes = new List<SpellcastingClass> { SpellcastingClass.Druid, SpellcastingClass.Ranger, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "summon-elemental", "en"),
					Language = LanguageCode.En,
					Name = "Summon Elemental",
					CastingTime = "Action",
					Range = "90 feet",
					Duration = "Concentration, up to 1 hour",
					MaterialComponent = "air, a small stone, ash, and water, held in a gold-inlaid vial worth 400+ GP",
					Description = "A spirit of raw elemental matter answers you and forms in an unoccupied space you can see within range as a two-legged figure cloaked in its element. Its statistics are given in the **Elemental Spirit** block below. Pick its element when you cast the spell (Air, Earth, Fire, or Water); the element decides which of the element-specific entries apply. The spirit is gone as soon as its Hit Points reach 0 or the spell ends.\n\nThe spirit fights on your side and is friendly to your companions. It doesn't roll its own Initiative: it acts immediately after you, on your turn. You can direct it with spoken orders at no cost in actions; left without orders, it takes the Dodge action and moves only to avoid harm.\n\n#### Elemental Spirit\n\n*Medium Elemental, Neutral*\n\n**AC** 11 + spell level · **HP** 50, plus 10 per spell level above 4 · **Speed** 40 ft.; Burrow 40 ft. (Earth only); Fly 40 ft. and can hover (Air only); Swim 40 ft. (Water only)\n\n| Ability | Score | Mod | Save |\n|---|---|---|---|\n| STR | 18 | +4 | +4 |\n| DEX | 15 | +2 | +2 |\n| CON | 17 | +3 | +3 |\n| INT | 4 | −3 | −3 |\n| WIS | 10 | +0 | +0 |\n| CHA | 16 | +3 | +3 |\n\n**Resistant** to Acid damage (Water); Lightning and Thunder damage (Air); Piercing and Slashing damage (Earth) · **Immune** to Poison damage, Fire damage (Fire only), Exhaustion, and the Paralyzed, Petrified, and Poisoned conditions · **Senses** Darkvision 60 ft., Passive Perception 10 · **Languages** Primordial; understands every language you know · **Challenge** none (XP 0); uses your Proficiency Bonus\n\n**Features**\n\n- **Fluid Form (Air, Fire, Water).** The spirit can slip through any gap at least 1 inch wide, and such a gap isn't Difficult Terrain for it.\n\n**Actions**\n\n- **Multiattack.** The spirit makes Elemental Strike attacks equal in number to half the spell level, rounded down.\n- **Elemental Strike.** Melee attack using your spell attack modifier, reach 5 ft. On a hit: damage equal to 1d10 + 4 + spell level, of the spirit's element: Bludgeoning (Earth), Cold (Water), Lightning (Air), or Fire (Fire).",
					HigherLevels = "Wherever the stat block refers to the spell level, use the level of the slot you spent."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "summon-elemental", "it"),
					Language = LanguageCode.It,
					Name = "Richiama Elementale",
					CastingTime = "Azione",
					Range = "27 metri",
					Duration = "Concentrazione, fino a 1 ora",
					MaterialComponent = "aria, una pietruzza, cenere e acqua, contenute in una fiala intarsiata d'oro del valore di almeno 400 mo",
					Description = "Uno spirito di pura materia elementale risponde all'incantatore e si forma in uno spazio libero entro gittata che questi è in grado di vedere, come una figura bipede avvolta nel proprio elemento. Le sue statistiche sono riportate nella scheda dello **Spirito Elementale** qui sotto. Al momento del lancio l'incantatore sceglie il suo elemento (Aria, Terra, Fuoco o Acqua); l'elemento decide quali voci specifiche si applicano. Lo spirito scompare non appena i suoi punti ferita scendono a 0 o l'incantesimo termina.\n\nLo spirito combatte dalla parte dell'incantatore ed è amichevole verso i suoi compagni. Non tira la propria Iniziativa: agisce subito dopo l'incantatore, nel turno di quest'ultimo. L'incantatore può guidarlo con ordini verbali senza spendere azioni; se non riceve ordini, lo spirito effettua l'azione di Schivata e si muove soltanto per evitare danni.\n\n#### Spirito Elementale\n\n*Elementale Medio, neutrale*\n\n**CA** 11 + livello dell'incantesimo · **PF** 50, più 10 per ogni livello dell'incantesimo oltre il 4° · **Velocità** 12 m; scavare 12 m (solo Terra); volare 12 m e può fluttuare (solo Aria); nuotare 12 m (solo Acqua)\n\n| Caratteristica | Punteggio | Mod | TS |\n|---|---|---|---|\n| FOR | 18 | +4 | +4 |\n| DES | 15 | +2 | +2 |\n| COS | 17 | +3 | +3 |\n| INT | 4 | −3 | −3 |\n| SAG | 10 | +0 | +0 |\n| CAR | 16 | +3 | +3 |\n\n**Resistente** ai danni da acido (Acqua); ai danni da fulmine e da tuono (Aria); ai danni perforanti e taglienti (Terra) · **Immune** ai danni da veleno, ai danni da fuoco (solo Fuoco), all'indebolimento e alle condizioni avvelenato, paralizzato e pietrificato · **Sensi** scurovisione 18 m, Percezione passiva 10 · **Linguaggi** Primordiale; comprende tutti i linguaggi conosciuti dall'incantatore · **Grado di sfida** nessuno (PE 0); usa il bonus di competenza dell'incantatore\n\n**Capacità**\n\n- **Forma Fluida (Aria, Fuoco, Acqua).** Lo spirito può scivolare attraverso qualsiasi fessura larga almeno 2,5 centimetri, e per lui quella fessura non è terreno difficile.\n\n**Azioni**\n\n- **Multiattacco.** Lo spirito effettua un numero di attacchi di Colpo Elementale pari alla metà del livello dell'incantesimo, arrotondata per difetto.\n- **Colpo Elementale.** Attacco in mischia con il modificatore di attacco con incantesimo dell'incantatore, portata 1,5 m. Se colpisce: danni pari a 1d10 + 4 + livello dell'incantesimo, dell'elemento dello spirito: contundenti (Terra), da freddo (Acqua), da fulmine (Aria) o da fuoco (Fuoco).",
					HigherLevels = "Ovunque la scheda faccia riferimento al livello dell'incantesimo, si usa il livello dello slot speso."
				}
			}
		};
	}
}
