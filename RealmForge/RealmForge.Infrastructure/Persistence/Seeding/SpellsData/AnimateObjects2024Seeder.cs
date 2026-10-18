using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Animate Objects (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class AnimateObjects2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "animate-objects");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 5,
			School = SpellSchool.Transmutation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "animate-objects", "en"),
					Language = LanguageCode.En,
					Name = "Animate Objects",
					CastingTime = "Action",
					Range = "120 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = null,
					Description = "Objects animate at your command. Choose a number of nonmagical objects within range that aren't being worn or carried, aren't fixed to a surface, and aren't Gargantuan. The maximum number of objects is equal to your spellcasting ability modifier; for this number, a Medium or smaller target counts as one object, a Large target counts as two, and a Huge target counts as three.\n\nEach target animates, sprouts legs, and becomes a Construct that uses the **Animated Object** stat block; this creature is under your control until the spell ends or until it is reduced to 0 Hit Points. Each creature you make with this spell is an ally to you and your allies. In combat, it shares your Initiative count and takes its turn immediately after yours.\n\nUntil the spell ends, you can take a Bonus Action to mentally command any creature you made with this spell if the creature is within 500 feet of you (if you control multiple creatures, you can command any of them at the same time, issuing the same command to each one). If you issue no commands, the creature takes the Dodge action and moves only to avoid harm. When the creature drops to 0 Hit Points, it reverts to its object form, and any remaining damage carries over to that form.\n\n#### Animated Object\n\n*Huge or Smaller Construct, Unaligned*\n\n**AC** 15\n\n**HP** 10 (Medium or smaller), 20 (Large), 40 (Huge)\n\n**Speed** 30 ft.\n\n| Ability | Score | Mod | Save |\n|---|---|---|---|\n| STR | 16 | +3 | +3 |\n| DEX | 10 | +0 | +0 |\n| CON | 10 | +0 | +0 |\n| INT | 3 | −4 | −4 |\n| WIS | 3 | −4 | −4 |\n| CHA | 1 | −5 | −5 |\n\n**Immunities** Poison, Psychic; Charmed, Exhaustion, Frightened, Paralyzed, Poisoned\n\n**Senses** Blindsight 30 ft.; Passive Perception 6\n\n**Languages** Understands the languages you know\n\n**CR** None (XP 0; PB equals your Proficiency Bonus)\n\n***Actions***\n\n***Slam.*** *Melee Attack Roll:* Bonus equals your spell attack modifier, reach 5 ft. *Hit:* Force damage equal to 1d4 + 3 (Medium or smaller), 2d6 + 3 + your spellcasting ability modifier (Large), or 2d12 + 3 + your spellcasting ability modifier (Huge).",
					HigherLevels = "The creature's Slam damage increases by 1d4 (Medium or smaller), 1d6 (Large), or 1d12 (Huge) for each spell slot level above 5."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "animate-objects", "it"),
					Language = LanguageCode.It,
					Name = "Animare Oggetti",
					CastingTime = "Azione",
					Range = "36 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = null,
					Description = "Gli oggetti si animano al comando dell'incantatore. L'incantatore sceglie entro gittata un certo numero di oggetti non magici che non siano indossati o trasportati, che non siano fissati a una superficie e che non siano Mastodontici. Il numero massimo di oggetti è pari al suo modificatore di caratteristica da incantatore; per questo numero, un bersaglio di taglia Media o inferiore conta come un oggetto, un bersaglio Grande conta come due e un bersaglio Enorme conta come tre.\n\nOgni bersaglio si anima, gli spuntano delle zampe e diventa un costrutto che usa la scheda delle statistiche dell'**oggetto animato**; questa creatura è sotto il controllo dell'incantatore finché l'incantesimo non termina o finché non scende a 0 punti ferita. Ogni creatura creata con questo incantesimo è un'alleata dell'incantatore e dei suoi alleati. In combattimento condivide il conteggio di Iniziativa dell'incantatore e svolge il proprio turno subito dopo il suo.\n\nFinché l'incantesimo non termina, l'incantatore può effettuare un'azione bonus per impartire mentalmente un comando a qualsiasi creatura creata con questo incantesimo, se la creatura si trova entro 150 metri da lui (se controlla più creature, può impartire un comando a qualsiasi di esse contemporaneamente, dando lo stesso comando a ciascuna). Se l'incantatore non impartisce alcun comando, la creatura effettua l'azione di Schivata e si muove soltanto per evitare pericoli. Quando la creatura scende a 0 punti ferita, torna alla sua forma di oggetto e gli eventuali danni in eccesso si applicano a quella forma.\n\n#### Oggetto Animato\n\n*Costrutto di taglia Enorme o inferiore, senza allineamento*\n\n**CA** 15\n\n**PF** 10 (Medio o inferiore), 20 (Grande), 40 (Enorme)\n\n**Velocità** 9 m\n\n| Caratteristica | Punteggio | Mod | TS |\n|---|---|---|---|\n| FOR | 16 | +3 | +3 |\n| DES | 10 | +0 | +0 |\n| COS | 10 | +0 | +0 |\n| INT | 3 | −4 | −4 |\n| SAG | 3 | −4 | −4 |\n| CAR | 1 | −5 | −5 |\n\n**Immunità** psichici, veleno; affascinato, avvelenato, indebolimento, paralizzato, spaventato\n\n**Sensi** vista cieca 9 m; Percezione passiva 6\n\n**Linguaggi** comprende i linguaggi conosciuti dall'incantatore\n\n**GS** nessuno (PE 0; BC pari al bonus di competenza dell'incantatore)\n\n***Azioni***\n\n***Schianto.*** *Tiro per colpire in mischia:* bonus pari al modificatore di attacco con incantesimo dell'incantatore, portata 1,5 m. *Colpito:* danni da forza pari a 1d4 + 3 (Medio o inferiore), 2d6 + 3 + il modificatore di caratteristica da incantatore dell'incantatore (Grande) o 2d12 + 3 + il modificatore di caratteristica da incantatore dell'incantatore (Enorme).",
					HigherLevels = "I danni dello Schianto della creatura aumentano di 1d4 (Medio o inferiore), 1d6 (Grande) o 1d12 (Enorme) per ogni livello dello slot incantesimo superiore al 5°."
				}
			}
		};
	}
}
