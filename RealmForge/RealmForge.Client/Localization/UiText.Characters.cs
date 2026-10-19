using RealmForge.Shared.Enums;

namespace RealmForge.Client.Localization
{
	///	<summary>
	///	Texts of the characters: list, creation wizard and sheet.
	///	</summary>
	public static partial class UiText
	{
		private static string T(LanguageCode lang, string it, string en) => lang == LanguageCode.It ? it : en;

		public static string NavCharacters(LanguageCode lang) => T(lang, "Personaggi", "Characters");
		public static string CharactersTitle(LanguageCode lang) => T(lang, "I tuoi personaggi", "Your characters");
		public static string CharactersSubtitle(LanguageCode lang) => T(lang,
			"Gli eroi che hai forgiato. Sono privati: li vedi soltanto tu.",
			"The heroes you have forged. They are private: only you can see them.");
		public static string CharactersSignIn(LanguageCode lang) => T(lang,
			"Accedi per forgiare e conservare i tuoi personaggi.",
			"Sign in to forge and keep your characters.");
		public static string CharactersEmpty(LanguageCode lang) => T(lang,
			"Non hai ancora forgiato nessun personaggio.",
			"You have not forged any character yet.");
		public static string BtnNewCharacter(LanguageCode lang) => T(lang, "Forgia un personaggio", "Forge a character");
		public static string LoadingCharacters(LanguageCode lang) => T(lang, "Apertura degli archivi degli eroi...", "Opening the hall of heroes...");
		public static string CharacterLevel(int level, LanguageCode lang) => T(lang, $"Livello {level}", $"Level {level}");
		public static string DeleteCharacterWarning(string name, LanguageCode lang) => T(lang,
			$"Vuoi eliminare definitivamente il personaggio \"{name}\"? L'operazione non può essere annullata.",
			$"Do you want to permanently delete the character \"{name}\"? This cannot be undone.");
		public static string CharacterNotFound(LanguageCode lang) => T(lang,
			"Personaggio non trovato: forse è stato eliminato, oppure appartiene a un altro account.",
			"Character not found: it may have been deleted, or it belongs to another account.");
		public static string BtnBackToCharacters(LanguageCode lang) => T(lang, "← Tutti i personaggi", "← All characters");

		//	Wizard
		public static string WizardTitle(LanguageCode lang) => T(lang, "Creazione del personaggio", "Character creation");
		public static string WizardStep(int step, LanguageCode lang) => step switch
		{
			1 => T(lang, "Identità", "Identity"),
			2 => T(lang, "Origini", "Origins"),
			3 => T(lang, "Classe", "Class"),
			4 => T(lang, "Punteggi di caratteristica", "Ability scores"),
			5 => T(lang, "Incrementi e talento", "Increases and feat"),
			6 => T(lang, "Equipaggiamento", "Equipment"),
			7 => T(lang, "Incantesimi", "Spells"),
			_ => T(lang, "Riepilogo", "Summary")
		};
		public static string WizardStepOf(int step, int total, LanguageCode lang) => T(lang, $"Passo {step} di {total} · ", $"Step {step} of {total} · ") + WizardStep(step, lang);
		public static string BtnWizardNext(LanguageCode lang) => T(lang, "Avanti", "Next");
		public static string BtnWizardBack(LanguageCode lang) => T(lang, "Indietro", "Back");
		public static string BtnWizardForge(LanguageCode lang) => T(lang, "Forgia il personaggio", "Forge the character");
		public static string WizardSaving(LanguageCode lang) => T(lang, "Forgiatura in corso...", "Forging...");
		public static string WizardLoading(LanguageCode lang) => T(lang, "Preparazione della forgia...", "Preparing the forge...");

		public static string LabelEdition(LanguageCode lang) => T(lang, "Edizione", "Edition");
		public static string LabelCharacterName(LanguageCode lang) => T(lang, "Nome", "Name");
		public static string PlaceholderCharacterName(LanguageCode lang) => T(lang, "Il nome del tuo eroe", "Your hero's name");
		public static string LabelAlignment(LanguageCode lang) => T(lang, "Allineamento", "Alignment");
		public static string LabelSuggestedTraits(LanguageCode lang) => T(lang, "Tratti caratteriali suggeriti", "Suggested personality traits");
		public static string LabelSpecies(LanguageCode lang) => T(lang, "Specie", "Species");
		public static string LabelSubspecies(LanguageCode lang) => T(lang, "Sottospecie", "Lineage");
		public static string LabelSize(LanguageCode lang) => T(lang, "Taglia", "Size");
		public static string LabelBackground(LanguageCode lang) => T(lang, "Background", "Background");
		public static string LabelLanguage(int index, LanguageCode lang) => T(lang, $"Linguaggio {index}", $"Language {index}");
		public static string LabelClass(LanguageCode lang) => T(lang, "Classe", "Class");
		public static string LabelSubclassChoice(LanguageCode lang) => T(lang, "Sottoclasse", "Subclass");
		public static string NoSubclassYet(int level, LanguageCode lang) => T(lang, $"Si sceglie al {level}° livello", $"Chosen at level {level}");
		public static string LabelClassSkills(int count, LanguageCode lang) => T(lang, $"Abilità di classe (scegline {count})", $"Class skills (choose {count})");
		public static string HintBackgroundSkills(LanguageCode lang) => T(lang, "Le abilità tratteggiate vengono già dal background.", "Dashed skills already come from the background.");
		public static string LabelFeaturesUpToLevel(int level, LanguageCode lang) => T(lang, $"Privilegi fino al {level}° livello", $"Features up to level {level}");
		public static string LabelSpeciesTraits(LanguageCode lang) => T(lang, "Tratti della specie", "Species traits");

		public static string LabelMethod(LanguageCode lang) => T(lang, "Metodo", "Method");
		public static string AbilityMethodName(AbilityMethod method, LanguageCode lang) => method switch
		{
			AbilityMethod.StandardArray => T(lang, "Serie standard", "Standard array"),
			AbilityMethod.PointBuy => T(lang, "Acquisto a punti", "Point buy"),
			_ => T(lang, "Tiro dei dadi (4d6)", "Dice roll (4d6)")
		};
		public static string AbilityMethodHint(AbilityMethod method, LanguageCode lang) => method switch
		{
			AbilityMethod.StandardArray => T(lang,
				"Assegna i valori 15, 14, 13, 12, 10 e 8: scegli un valore e poi la caratteristica. Puoi partire dalla disposizione consigliata per la classe.",
				"Assign 15, 14, 13, 12, 10 and 8: pick a value, then the ability. You can start from the arrangement suggested for the class."),
			AbilityMethod.PointBuy => T(lang,
				"Ogni caratteristica parte da 8 e arriva al massimo a 15: hai 27 punti da spendere (14 costa 7, 15 costa 9).",
				"Every score starts at 8 and goes up to 15: you have 27 points to spend (14 costs 7, 15 costs 9)."),
			_ => T(lang,
				"Tira 4d6 sei volte e scarta il dado più basso di ogni tiro; poi assegna i risultati. Hai tre tentativi.",
				"Roll 4d6 six times and drop the lowest die of each roll, then assign the results. You have three attempts.")
		};
		public static string BtnSuggestedArray(LanguageCode lang) => T(lang, "Disposizione consigliata", "Suggested arrangement");
		public static string BtnAssign(LanguageCode lang) => T(lang, "Assegna", "Assign");
		public static string PointsLeft(int points, LanguageCode lang) => T(lang, $"Punti rimanenti: {points}", $"Points left: {points}");
		public static string BtnRollDice(int left, LanguageCode lang) => T(lang, $"Tira i dadi [{left}/3]", $"Roll the dice [{left}/3]");
		public static string NoRollsLeft(LanguageCode lang) => T(lang, "Tentativi esauriti", "No rolls left");
		public static string RerollTitle(LanguageCode lang) => T(lang, "Ritirare i dadi?", "Reroll the dice?");
		public static string RerollText(int left, LanguageCode lang) => T(lang,
			$"I punteggi ottenuti andranno persi e non potrai tornare indietro. Tentativi rimasti: {left}.",
			$"The current scores will be lost for good. Rolls left: {left}.");
		public static string BtnReroll(LanguageCode lang) => T(lang, "Ritira", "Reroll");

		public static string LabelBonusMode(LanguageCode lang) => T(lang, "Distribuzione", "Distribution");
		public static string BonusModeName(AbilityBonusMode mode, LanguageCode lang) => mode switch
		{
			AbilityBonusMode.TwoAndOne => T(lang, "+2 e +1", "+2 and +1"),
			AbilityBonusMode.ThreeOnes => T(lang, "+1 a tre caratteristiche", "+1 to three scores"),
			_ => T(lang, "+1 a tutte le caratteristiche", "+1 to every score")
		};
		public static string LabelPlusTwo(LanguageCode lang) => T(lang, "+2 a", "+2 to");
		public static string LabelPlusOne(LanguageCode lang) => T(lang, "+1 a", "+1 to");
		public static string LabelThreeOnes(LanguageCode lang) => T(lang, "+1 a", "+1 to");
		public static string LabelAbilityIncreases(LanguageCode lang) => T(lang, "Incrementi dei punteggi di caratteristica", "Ability score increases");
		public static string HintIncreases2024(LanguageCode lang) => T(lang,
			"Il background indica tre caratteristiche: aumentane una di 2 e un'altra di 1, oppure tutte e tre di 1. Nessun punteggio può superare 20.",
			"The background lists three abilities: increase one by 2 and another by 1, or all three by 1. No score can exceed 20.");
		public static string HintIncreases2014(LanguageCode lang) => T(lang,
			"Nelle regole 2014 gli incrementi vengono dalla specie: applica quelli indicati nel tratto \"Aumento dei punteggi di caratteristica\" qui sotto.",
			"In the 2014 rules the increases come from the species: apply those listed in its \"Ability Score Increase\" trait below.");
		public static string LabelFinalScores(LanguageCode lang) => T(lang, "Punteggi finali", "Final scores");
		public static string LabelOriginFeatTitle(LanguageCode lang) => T(lang, "Talento di origine", "Origin feat");

		public static string LabelBackgroundEquipment(LanguageCode lang) => T(lang, "Equip. del background", "Background equipment");
		public static string LabelClassEquipment(LanguageCode lang) => T(lang, "Equip. della classe", "Class equipment");
		public static string LabelEquipmentLine(int index, LanguageCode lang) => T(lang, $"Scelta {index}", $"Choice {index}");
		public static string LabelYourEquipment(LanguageCode lang) => T(lang, "Il tuo equipaggiamento", "Your equipment");
		public static string OptionLetter(string letter, LanguageCode lang) => T(lang, $"Opzione {letter}", $"Option {letter}");

		public static string LabelCantrips(LanguageCode lang) => T(lang, "Trucchetti", "Cantrips");
		public static string LabelLeveledSpells(int maxLevel, LanguageCode lang) => T(lang, $"Incantesimi (fino al {maxLevel}° livello)", $"Spells (up to level {maxLevel})");
		public static string SpellsSelected(int count, int max, LanguageCode lang) => T(lang, $"Selezionati: {count} / {max}", $"Selected: {count} / {max}");
		public static string NoSpellsForClass(LanguageCode lang) => T(lang,
			"Nessun trucchetto o incantesimo da scegliere per questa classe a questo livello.",
			"No cantrips or spells to choose for this class at this level.");
		public static string PlaceholderSearchSpell(LanguageCode lang) => T(lang, "Cerca un incantesimo", "Search a spell");

		public static string ErrName(LanguageCode lang) => T(lang, "Dai un nome al tuo personaggio.", "Give your character a name.");
		public static string ErrSkills(int count, LanguageCode lang) => T(lang, $"Scegli {count} abilità di classe.", $"Choose {count} class skills.");
		public static string ErrScores(LanguageCode lang) => T(lang, "Assegna tutti e sei i punteggi.", "Assign all six scores.");
		public static string ErrPoints(LanguageCode lang) => T(lang, "Spendi tutti i punti.", "Spend all the points.");
		public static string ErrSpells(LanguageCode lang) => T(lang, "Completa la scelta di trucchetti e incantesimi.", "Complete the choice of cantrips and spells.");
		public static string ErrSave(LanguageCode lang) => T(lang, "Non è stato possibile forgiare il personaggio:", "The character could not be forged:");

		//	Sheet
		public static string SheetArmorClass(LanguageCode lang) => T(lang, "CA", "AC");
		public static string SheetHitPoints(LanguageCode lang) => T(lang, "Punti ferita", "Hit points");
		public static string SheetInitiative(LanguageCode lang) => T(lang, "Iniziativa", "Initiative");
		public static string SheetSpeed(LanguageCode lang) => T(lang, "Velocità", "Speed");
		public static string SheetProficiency(LanguageCode lang) => T(lang, "Competenza", "Proficiency");
		public static string SheetPassivePerception(LanguageCode lang) => T(lang, "Percezione passiva", "Passive Perception");
		public static string SheetSaves(LanguageCode lang) => T(lang, "Tiri salvezza", "Saving throws");
		public static string SheetSkills(LanguageCode lang) => T(lang, "Abilità", "Skills");
		public static string SheetLanguages(LanguageCode lang) => T(lang, "Linguaggi", "Languages");
		public static string SheetEquipment(LanguageCode lang) => T(lang, "Equipaggiamento", "Equipment");
		public static string SheetSpells(LanguageCode lang) => T(lang, "Incantesimi", "Spells");
		public static string SheetOrigin(LanguageCode lang) => T(lang, "Origine", "Origin");
		public static string SheetSpellcasting(AbilityScore ability, int dc, int attack, LanguageCode lang) => T(lang,
			$"Caratteristica: {Shared.Localization.FeatPrerequisiteFormatter.AbilityName(ability, lang)} · CD {dc} · attacco {Shared.Rules.CharacterMath.FormatModifier(attack)}",
			$"Ability: {Shared.Localization.FeatPrerequisiteFormatter.AbilityName(ability, lang)} · DC {dc} · attack {Shared.Rules.CharacterMath.FormatModifier(attack)}");

		public static string AbilityShort(AbilityScore ability, LanguageCode lang) => (ability, lang == LanguageCode.It) switch
		{
			(AbilityScore.Strength, true) => "FOR",
			(AbilityScore.Dexterity, true) => "DES",
			(AbilityScore.Constitution, true) => "COS",
			(AbilityScore.Intelligence, true) => "INT",
			(AbilityScore.Wisdom, true) => "SAG",
			(AbilityScore.Charisma, true) => "CAR",
			(AbilityScore.Strength, false) => "STR",
			(AbilityScore.Dexterity, false) => "DEX",
			(AbilityScore.Constitution, false) => "CON",
			(AbilityScore.Intelligence, false) => "INT",
			(AbilityScore.Wisdom, false) => "WIS",
			_ => "CHA"
		};

		public static string AlignmentName(Alignment alignment, LanguageCode lang) => (alignment, lang == LanguageCode.It) switch
		{
			(Alignment.LawfulGood, true) => "Legale buono",
			(Alignment.NeutralGood, true) => "Neutrale buono",
			(Alignment.ChaoticGood, true) => "Caotico buono",
			(Alignment.LawfulNeutral, true) => "Legale neutrale",
			(Alignment.Neutral, true) => "Neutrale",
			(Alignment.ChaoticNeutral, true) => "Caotico neutrale",
			(Alignment.LawfulEvil, true) => "Legale malvagio",
			(Alignment.NeutralEvil, true) => "Neutrale malvagio",
			(Alignment.ChaoticEvil, true) => "Caotico malvagio",
			(Alignment.LawfulGood, false) => "Lawful Good",
			(Alignment.NeutralGood, false) => "Neutral Good",
			(Alignment.ChaoticGood, false) => "Chaotic Good",
			(Alignment.LawfulNeutral, false) => "Lawful Neutral",
			(Alignment.Neutral, false) => "Neutral",
			(Alignment.ChaoticNeutral, false) => "Chaotic Neutral",
			(Alignment.LawfulEvil, false) => "Lawful Evil",
			(Alignment.NeutralEvil, false) => "Neutral Evil",
			_ => "Chaotic Evil"
		};

		//	Short descriptions written for RealmForge
		public static string AlignmentDescription(Alignment alignment, LanguageCode lang) => alignment switch
		{
			Alignment.LawfulGood => T(lang,
				"Agisce come ci si aspetta da una persona giusta: rispetta la parola data, protegge i deboli e crede che leggi eque rendano il mondo migliore.",
				"Acts as a just person is expected to: keeps their word, protects the weak and believes fair laws make the world better."),
			Alignment.NeutralGood => T(lang,
				"Fa del suo meglio per aiutare gli altri secondo i propri mezzi, senza sentirsi legato né alle regole né alla loro assenza.",
				"Does their best to help others as they can, bound neither to rules nor to their absence."),
			Alignment.ChaoticGood => T(lang,
				"Segue la propria coscienza e il proprio cuore, poco curandosi di ciò che gli altri si aspettano: libertà e gentilezza prima di tutto.",
				"Follows conscience and heart with little regard for what others expect: freedom and kindness come first."),
			Alignment.LawfulNeutral => T(lang,
				"Si affida alla legge, alla tradizione o a un codice personale: l'ordine e la disciplina guidano ogni sua scelta.",
				"Relies on law, tradition or a personal code: order and discipline guide every choice."),
			Alignment.Neutral => T(lang,
				"Preferisce non schierarsi e agisce secondo ciò che appare più sensato nel momento, evitando gli estremi morali.",
				"Prefers not to take sides and does what seems most sensible at the moment, avoiding moral extremes."),
			Alignment.ChaoticNeutral => T(lang,
				"Segue i propri capricci e tiene alla propria libertà più di ogni altra cosa, diffidando di qualsiasi vincolo.",
				"Follows their whims and values personal freedom above everything, wary of any constraint."),
			Alignment.LawfulEvil => T(lang,
				"Prende ciò che vuole in modo metodico, dentro i limiti di un codice, di una gerarchia o di una tradizione.",
				"Methodically takes what they want, within the limits of a code, a hierarchy or a tradition."),
			Alignment.NeutralEvil => T(lang,
				"Fa tutto ciò che gli conviene senza compassione né scrupoli, purché non ne paghi il prezzo.",
				"Does whatever serves them, without compassion or scruples, as long as they do not pay for it."),
			_ => T(lang,
				"Agisce con violenza arbitraria, spinto da avidità, odio o sete di sangue.",
				"Acts with arbitrary violence, driven by greed, hatred or bloodlust.")
		};

		public static IReadOnlyList<string> AlignmentTraits(Alignment alignment, LanguageCode lang)
		{
			var traits = new List<string>();
			var name = alignment.ToString();
			if (name.StartsWith("Lawful")) traits.AddRange(lang == LanguageCode.It ? new[] { "Onorevole", "Disciplinato", "Affidabile" } : new[] { "Honorable", "Disciplined", "Reliable" });
			if (name.StartsWith("Chaotic")) traits.AddRange(lang == LanguageCode.It ? new[] { "Indipendente", "Imprevedibile", "Spontaneo" } : new[] { "Independent", "Unpredictable", "Spontaneous" });
			if (name.EndsWith("Good")) traits.AddRange(lang == LanguageCode.It ? new[] { "Altruista", "Compassionevole", "Leale" } : new[] { "Selfless", "Compassionate", "Loyal" });
			if (name.EndsWith("Evil")) traits.AddRange(lang == LanguageCode.It ? new[] { "Spietato", "Egoista", "Ambizioso" } : new[] { "Ruthless", "Selfish", "Ambitious" });
			if (alignment is Alignment.Neutral or Alignment.LawfulNeutral or Alignment.ChaoticNeutral or Alignment.NeutralGood or Alignment.NeutralEvil)
			{
				traits.AddRange(lang == LanguageCode.It ? new[] { "Pragmatico", "Equilibrato" } : new[] { "Pragmatic", "Balanced" });
			}

			return traits;
		}

		//	Standard languages of the Player's Handbook (2024 list; 2014 has the same minus the sign language)
		public static IReadOnlyList<string> StandardLanguages(RulesetVersion ruleset, LanguageCode lang)
		{
			var it = new[] { "Draconico", "Elfico", "Gigante", "Gnomesco", "Goblin", "Halfling", "Nanico", "Orchesco", "Lingua dei segni comune" };
			var en = new[] { "Draconic", "Elvish", "Giant", "Gnomish", "Goblin", "Halfling", "Dwarvish", "Orc", "Common Sign Language" };
			var list = lang == LanguageCode.It ? it : en;
			return ruleset == RulesetVersion.Dnd5e_2024 ? list : list.Take(8).ToArray();
		}

		public static string CommonLanguage(LanguageCode lang) => T(lang, "Comune", "Common");
	}
}
