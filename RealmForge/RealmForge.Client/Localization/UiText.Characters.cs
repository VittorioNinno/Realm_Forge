using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;

namespace RealmForge.Client.Localization
{
	public enum WizardStep
	{
		Identity = 1,
		Species = 2,
		Class = 3,
		Background = 4,
		Abilities = 5,
		Progression = 6,
		Languages = 7,
		Equipment = 8,
		Spells = 9,
		Details = 10,
		Summary = 11
	}

	///	<summary>
	///	Texts of the characters: list, creation wizard, sheet and PDF. The 2014 rules use the terms of the 2014
	///	Manuale del Giocatore (razza, linguaggi), the 2024 rules those of the 2024 one (specie, lingue).
	///	</summary>
	public static partial class UiText
	{
		private static string T(LanguageCode lang, string it, string en) => lang == LanguageCode.It ? it : en;

		private static bool Is2014(RulesetVersion ruleset) => ruleset == RulesetVersion.Dnd5e_2014;

		// ===== List =====
		public static string NavCharacters(LanguageCode lang) => T(lang, "Personaggi", "Characters");
		public static string CharactersTitle(LanguageCode lang) => T(lang, "I tuoi personaggi", "Your characters");
		public static string CharactersSubtitle(LanguageCode lang) => T(lang,
			"Gli eroi che hai forgiato. Sono privati: li vedi soltanto tu.",
			"The heroes you have forged. They are private: only you can see them.");
		public static string CharactersSignIn(LanguageCode lang) => T(lang,
			"Accedi per forgiare e conservare i tuoi personaggi.",
			"Sign in to forge and keep your characters.");
		public static string CharactersEmpty(LanguageCode lang) => T(lang, "Non hai ancora forgiato nessun personaggio.", "You have not forged any character yet.");
		public static string BtnNewCharacter(LanguageCode lang) => T(lang, "Forgia un personaggio", "Forge a character");
		public static string LoadingCharacters(LanguageCode lang) => T(lang, "Apertura degli archivi degli eroi...", "Opening the hall of heroes...");
		public static string CharacterLevel(int level, LanguageCode lang) => T(lang, $"Livello {level}", $"Level {level}");
		public static string DeleteCharacterWarning(string name, LanguageCode lang) => T(lang,
			$"Vuoi eliminare definitivamente il personaggio \"{name}\"? L'operazione non può essere annullata.",
			$"Do you want to permanently delete the character \"{name}\"? This cannot be undone.");
		public static string BtnBackToCharacters(LanguageCode lang) => T(lang, "← Tutti i personaggi", "← All characters");
		public static string BtnBackToSheet(LanguageCode lang) => T(lang, "← Torna alla scheda", "← Back to the sheet");
		public static string CharacterNotFound(LanguageCode lang) => T(lang,
			"Personaggio non trovato: forse è stato eliminato, oppure appartiene a un altro account.",
			"Character not found: it may have been deleted, or it belongs to another account.");
		public static string RulesUnavailable(LanguageCode lang) => T(lang,
			"Non è stato possibile caricare le regole dell'edizione. Riprova tra poco.",
			"The rules of the edition could not be loaded. Try again in a moment.");

		// ===== Wizard =====
		public static string WizardTitle(LanguageCode lang) => T(lang, "Creazione del personaggio", "Character creation");
		public static string WizardEditTitle(LanguageCode lang) => T(lang, "Modifica del personaggio", "Edit character");
		public static string WizardLevelUpTitle(LanguageCode lang) => T(lang, "Avanzamento di livello", "Level up");

		public static string WizardStepName(WizardStep step, RulesetVersion ruleset, LanguageCode lang) => step switch
		{
			WizardStep.Identity => T(lang, "Edizione e identità", "Edition and identity"),
			WizardStep.Species => Is2014(ruleset) ? T(lang, "Razza", "Race") : T(lang, "Specie", "Species"),
			WizardStep.Class => T(lang, "Classe", "Class"),
			WizardStep.Background => T(lang, "Background", "Background"),
			WizardStep.Abilities => T(lang, "Punteggi di caratteristica", "Ability scores"),
			WizardStep.Progression => T(lang, "Livelli e multiclasse", "Levels and multiclassing"),
			WizardStep.Languages => Is2014(ruleset) ? T(lang, "Linguaggi", "Languages") : T(lang, "Lingue", "Languages"),
			WizardStep.Equipment => T(lang, "Equipaggiamento", "Equipment"),
			WizardStep.Spells => T(lang, "Incantesimi", "Spells"),
			WizardStep.Details => T(lang, "Allineamento e dettagli", "Alignment and details"),
			_ => T(lang, "Riepilogo", "Summary")
		};
		public static string WizardStepOf(int step, int total, LanguageCode lang) => T(lang, $"Passo {step} di {total} · ", $"Step {step} of {total} · ");
		public static string BtnWizardNext(LanguageCode lang) => T(lang, "Avanti", "Next");
		public static string BtnWizardBack(LanguageCode lang) => T(lang, "Indietro", "Back");
		public static string BtnWizardForge(LanguageCode lang) => T(lang, "Forgia il personaggio", "Forge the character");
		public static string BtnWizardSave(LanguageCode lang) => T(lang, "Salva le modifiche", "Save the changes");
		public static string WizardSaving(LanguageCode lang) => T(lang, "Forgiatura in corso...", "Forging...");
		public static string WizardLoading(LanguageCode lang) => T(lang, "Preparazione della forgia...", "Preparing the forge...");
		public static string ErrSave(LanguageCode lang) => T(lang, "Non è stato possibile salvare il personaggio:", "The character could not be saved:");
		public static string WizardStepIncomplete(LanguageCode lang) => T(lang, "Completa questo passo per proseguire:", "Complete this step to go on:");

		public static string EditionIntro(RulesetVersion ruleset, LanguageCode lang) => Is2014(ruleset)
			? T(lang,
				"Regole del 2014: si sceglie la razza (che dà gli incrementi di caratteristica e i linguaggi), poi la classe, i punteggi e infine il background, con i suoi tratti di personalità.",
				"2014 rules: you choose the race (which gives the ability increases and the languages), then the class, the scores and finally the background with its personality traits.")
			: T(lang,
				"Regole del 2024: si sceglie la classe, poi l'origine (il background dà gli incrementi di caratteristica e un talento di origine; la specie dà i tratti), i punteggi e l'allineamento.",
				"2024 rules: you choose the class, then the origin (the background gives the ability increases and an Origin feat; the species gives its traits), the scores and the alignment.");

		public static string LabelEdition(LanguageCode lang) => T(lang, "Edizione", "Edition");
		public static string LabelCharacterName(LanguageCode lang) => T(lang, "Nome", "Name");
		public static string PlaceholderCharacterName(LanguageCode lang) => T(lang, "Il nome del tuo eroe", "Your hero's name");
		public static string LabelStartingLevel(LanguageCode lang) => T(lang, "Livello di partenza", "Starting level");
		public static string LabelAlignment(LanguageCode lang) => T(lang, "Allineamento", "Alignment");
		public static string LabelSuggestedTraits(LanguageCode lang) => T(lang, "Tratti caratteriali suggeriti", "Suggested personality traits");

		// Species / race
		public static string LabelSpecies(RulesetVersion ruleset, LanguageCode lang) => Is2014(ruleset) ? T(lang, "Razza", "Race") : T(lang, "Specie", "Species");
		public static string LabelSubspecies(RulesetVersion ruleset, LanguageCode lang) => Is2014(ruleset) ? T(lang, "Sottorazza", "Subrace") : T(lang, "Discendenza", "Lineage");
		public static string LabelSize(LanguageCode lang) => T(lang, "Taglia", "Size");
		public static string LabelSpeciesTraits(RulesetVersion ruleset, LanguageCode lang) => Is2014(ruleset) ? T(lang, "Tratti razziali", "Racial traits") : T(lang, "Tratti della specie", "Species traits");
		public static string LabelRacialIncreases(LanguageCode lang) => T(lang, "Incrementi razziali", "Racial increases");
		public static string LabelChooseIncreases(int count, LanguageCode lang) => T(lang, $"Scegli {count} caratteristiche da aumentare di 1", $"Choose {count} abilities to increase by 1");
		public static string LabelSpeciesSkills(int count, LanguageCode lang) => T(lang, $"Abilità dei tratti (scegline {count})", $"Trait skills (choose {count})");
		public static string LabelFixedSkills(LanguageCode lang) => T(lang, "Competenze dei tratti", "Trait proficiencies");
		public static string LabelSpeciesFeat(RulesetVersion ruleset, LanguageCode lang) => Is2014(ruleset)
			? T(lang, "Talento (umano variante)", "Feat (variant human)")
			: T(lang, "Talento di origine (Versatile)", "Origin feat (Versatile)");
		public static string LabelSpeciesCantrip(LanguageCode lang) => T(lang, "Trucchetto del mago (alto elfo)", "Wizard cantrip (high elf)");

		// Class
		public static string LabelClass(LanguageCode lang) => T(lang, "Classe", "Class");
		public static string LabelStartingClass(LanguageCode lang) => T(lang, "Classe iniziale", "Starting class");
		public static string LabelSubclassChoice(LanguageCode lang) => T(lang, "Sottoclasse", "Subclass");
		public static string NoSubclassYet(int level, LanguageCode lang) => T(lang, $"Si sceglie al {level}° livello", $"Chosen at level {level}");
		public static string LabelClassSkills(int count, LanguageCode lang) => T(lang, $"Abilità di classe (scegline {count})", $"Class skills (choose {count})");
		public static string HintBackgroundSkills(LanguageCode lang) => T(lang, "Le abilità tratteggiate sono già competenze del personaggio.", "Dashed skills are already proficiencies of the character.");
		public static string LabelFeaturesUpToLevel(int level, LanguageCode lang) => T(lang, $"Privilegi fino al {level}° livello", $"Features up to level {level}");

		// Background and origin increases
		public static string LabelBackground(LanguageCode lang) => T(lang, "Background", "Background");
		public static string LabelBonusMode(LanguageCode lang) => T(lang, "Distribuzione", "Distribution");
		public static string BonusModeName(AbilityBonusMode mode, LanguageCode lang) => mode switch
		{
			AbilityBonusMode.TwoAndOne => T(lang, "+2 e +1", "+2 and +1"),
			AbilityBonusMode.ThreeOnes => T(lang, "+1 a tre caratteristiche", "+1 to three scores"),
			_ => T(lang, "+1 a tutte le caratteristiche", "+1 to every score")
		};
		public static string LabelPlusTwo(LanguageCode lang) => T(lang, "+2 a", "+2 to");
		public static string LabelPlusOne(LanguageCode lang) => T(lang, "+1 a", "+1 to");
		public static string LabelAbilityIncreases(LanguageCode lang) => T(lang, "Incrementi dei punteggi di caratteristica", "Ability score increases");
		public static string HintIncreases2024(LanguageCode lang) => T(lang,
			"Il background indica tre caratteristiche: aumentane una di 2 e un'altra di 1, oppure tutte e tre di 1. Nessun punteggio può superare 20.",
			"The background lists three abilities: increase one by 2 and another by 1, or all three by 1. No score can exceed 20.");
		public static string HintIncreasesHomebrew2014(LanguageCode lang) => T(lang,
			"Razza Homebrew: applica gli incrementi indicati nei suoi tratti.",
			"Homebrew race: apply the increases listed in its traits.");
		public static string LabelOriginFeatTitle(LanguageCode lang) => T(lang, "Talento di origine", "Origin feat");
		public static string LabelBackgroundFeature(LanguageCode lang) => T(lang, "Privilegio del background", "Background feature");
		public static string LabelLanguageChoices(int count, LanguageCode lang) => T(lang, $"{count} a scelta", $"{count} of your choice");

		// Ability scores
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
		public static string LabelFinalScores(LanguageCode lang) => T(lang, "Punteggi finali", "Final scores");
		public static string LabelBaseScore(LanguageCode lang) => T(lang, "Base", "Base");
		public static string LabelOriginBonus(LanguageCode lang) => T(lang, "Origine", "Origin");
		public static string LabelLevelBonus(LanguageCode lang) => T(lang, "Livelli e talenti", "Levels and feats");

		// Progression
		public static string HintProgression(RulesetVersion ruleset, LanguageCode lang) => Is2014(ruleset)
			? T(lang,
				"Ogni livello si prende in una classe: per una nuova classe servono 13 nelle caratteristiche primarie di tutte le classi. Ai livelli di classe 4, 8, 12, 16 e 19 (anche 6 e 14 per il guerriero, 10 per il ladro) aumenti i punteggi (+2 a uno o +1 a due) oppure scegli un talento.",
				"Each level is taken in a class: a new class needs 13 in the primary abilities of every class. At class levels 4, 8, 12, 16 and 19 (also 6 and 14 for the fighter, 10 for the rogue) you raise your scores (+2 to one or +1 to two) or take a feat.")
			: T(lang,
				"Ogni livello si prende in una classe: per una nuova classe servono 13 nelle caratteristiche primarie di tutte le classi. Ai livelli di classe 4, 8, 12 e 16 (anche 6 e 14 per il guerriero, 10 per il ladro) scegli il talento Aumento dei Punteggi di Caratteristica o un altro talento; al 19° un Dono Epico.",
				"Each level is taken in a class: a new class needs 13 in the primary abilities of every class. At class levels 4, 8, 12 and 16 (also 6 and 14 for the fighter, 10 for the rogue) you take the Ability Score Improvement feat or another feat; at 19 an Epic Boon.");
		public static string LabelLevelRow(int level, LanguageCode lang) => T(lang, $"{level}° livello", $"Level {level}");
		public static string LabelClassLevel(string className, int level, LanguageCode lang) => $"{className} {level}";
		public static string LabelHitPointsGain(LanguageCode lang) => T(lang, "Punti ferita", "Hit points");
		public static string HitPointsMaximum(int die, LanguageCode lang) => T(lang, $"Massimo del d{die}", $"Maximum of the d{die}");
		public static string HitPointsFixed(int value, LanguageCode lang) => T(lang, $"Fisso ({value})", $"Fixed ({value})");
		public static string HitPointsRolled(int value, LanguageCode lang) => T(lang, $"Tirato: {value}", $"Rolled: {value}");
		public static string BtnRollHitDie(int die, LanguageCode lang) => T(lang, $"Tira d{die}", $"Roll d{die}");
		public static string LabelImprovement(RulesetVersion ruleset, LanguageCode lang) => Is2014(ruleset)
			? T(lang, "Aumento dei punteggi di caratteristica o talento", "Ability Score Improvement or feat")
			: T(lang, "Talento", "Feat");
		public static string LabelEpicBoon(LanguageCode lang) => T(lang, "Dono Epico (o un altro talento)", "Epic Boon (or another feat)");
		public static string OptionPlainImprovement(LanguageCode lang) => T(lang, "Aumento dei punteggi", "Ability score increase");
		public static string OptionTakeFeat(LanguageCode lang) => T(lang, "Talento", "Feat");
		public static string LabelFeat(LanguageCode lang) => T(lang, "Talento", "Feat");
		public static string NoFeatChosen(LanguageCode lang) => T(lang, "— scegli un talento —", "— choose a feat —");
		public static string BtnAddLevel(LanguageCode lang) => T(lang, "+ Aggiungi un livello", "+ Add a level");
		public static string BtnRemoveLevel(LanguageCode lang) => T(lang, "Rimuovi l'ultimo livello", "Remove the last level");
		public static string LabelClassChoices(string className, int level, LanguageCode lang) => T(lang, $"Scelte di {className} ({level}° livello)", $"{className} choices (level {level})");
		public static string LabelMulticlassSkill(LanguageCode lang) => T(lang, "Abilità della multiclasse", "Multiclass skill");
		public static string LabelExpertise(int count, LanguageCode lang) => T(lang, $"Maestria (scegli {count} abilità con competenza)", $"Expertise (choose {count} proficient skills)");
		public static string LabelFightingStyle(LanguageCode lang) => T(lang, "Stile di combattimento", "Fighting Style");
		public static string LabelOrder(string? classKey, LanguageCode lang) => classKey == "druid" ? T(lang, "Ordine primordiale", "Primal Order") : T(lang, "Ordine divino", "Divine Order");
		public static string LabelWeaponMastery(int count, LanguageCode lang) => T(lang, $"Maestria nelle armi (scegline {count})", $"Weapon Mastery (choose {count})");
		public static string LabelStyleCantrips(LanguageCode lang) => T(lang, "Trucchetti dello stile", "Style cantrips");
		public static string MulticlassNeeds(string abilities, LanguageCode lang) => T(lang, $"Richiede 13 in {abilities}", $"Requires 13 in {abilities}");
		public static string MulticlassProficiencies(LanguageCode lang) => T(lang,
			"Con una nuova classe ottieni solo una parte delle sue competenze iniziali (vedi la descrizione della classe); tiri salvezza e abilità di classe restano quelli della classe iniziale.",
			"A new class grants only some of its starting proficiencies (see the class description); saving throws and class skills stay those of the starting class.");

		// Feat choices
		public static string LabelFeatIncrease(LanguageCode lang) => T(lang, "Incremento", "Increase");
		public static string LabelAsiIncrease(LanguageCode lang) => T(lang, "+2 a una caratteristica oppure +1 a due", "+2 to one score or +1 to two");
		public static string LabelFeatSkills(int count, LanguageCode lang) => T(lang, $"Abilità del talento (scegline {count})", $"Feat skills (choose {count})");
		public static string LabelFeatExpertise(LanguageCode lang) => T(lang, "Maestria del talento", "Feat Expertise");
		public static string LabelSpellList(LanguageCode lang) => T(lang, "Lista degli incantesimi", "Spell list");
		public static string HintFeatSpells(LanguageCode lang) => T(lang, "Gli incantesimi del talento si scelgono nel passo Incantesimi.", "The spells of the feat are chosen in the Spells step.");

		// Languages
		public static string LabelLanguages(RulesetVersion ruleset, LanguageCode lang) => Is2014(ruleset) ? T(lang, "Linguaggi", "Languages") : T(lang, "Lingue", "Languages");
		public static string LabelKnownLanguages(RulesetVersion ruleset, LanguageCode lang) => Is2014(ruleset) ? T(lang, "Linguaggi conosciuti", "Known languages") : T(lang, "Lingue conosciute", "Known languages");
		public static string LabelChooseLanguages(int count, RulesetVersion ruleset, LanguageCode lang) => Is2014(ruleset)
			? T(lang, $"Scegli {count} linguaggi", $"Choose {count} languages")
			: T(lang, $"Scegli {count} lingue", $"Choose {count} languages");
		public static string LanguageGroupName(LanguageGroup group, RulesetVersion ruleset, LanguageCode lang) => (group, Is2014(ruleset)) switch
		{
			(LanguageGroup.Standard, true) => T(lang, "Linguaggi standard", "Standard languages"),
			(LanguageGroup.Standard, false) => T(lang, "Lingue standard", "Standard languages"),
			(LanguageGroup.Exotic, true) => T(lang, "Linguaggi esotici", "Exotic languages"),
			(LanguageGroup.Exotic, false) => T(lang, "Lingue rare", "Rare languages"),
			_ => T(lang, "Linguaggi segreti", "Secret languages")
		};
		public static string HintLanguages(RulesetVersion ruleset, LanguageCode lang) => Is2014(ruleset)
			? T(lang,
				"La razza dà il Comune e il proprio linguaggio; altri linguaggi vengono da razza, background, classe e talenti. Gli esotici richiedono di solito il permesso del DM.",
				"The race gives Common and its own language; more languages come from race, background, class and feats. Exotic ones usually need the DM's permission.")
			: T(lang,
				"Ogni personaggio conosce il Comune e due lingue della tabella Lingue standard; privilegi come Esploratore Abile del ranger aggiungono altre lingue, anche rare.",
				"Every character knows Common and two languages of the Standard Languages table; features such as the ranger's Deft Explorer add more, rare ones included.");
		public static string NoLanguagesToChoose(LanguageCode lang) => T(lang, "Nessuna lingua da scegliere.", "No languages to choose.");

		// Equipment
		public static string LabelBackgroundEquipment(LanguageCode lang) => T(lang, "Equip. del background", "Background equipment");
		public static string LabelClassEquipment(LanguageCode lang) => T(lang, "Equip. della classe", "Class equipment");
		public static string LabelEquipmentLine(int index, LanguageCode lang) => T(lang, $"Scelta {index}", $"Choice {index}");
		public static string LabelYourEquipment(LanguageCode lang) => T(lang, "Il tuo equipaggiamento", "Your equipment");
		public static string OptionLetter(string letter, LanguageCode lang) => T(lang, $"Opzione {letter}", $"Option {letter}");
		public static string PickLabel(LoadoutPickKind kind, bool melee, LanguageCode lang) => (kind, melee) switch
		{
			(LoadoutPickKind.SimpleWeapon, true) => T(lang, "Arma semplice da mischia", "Simple melee weapon"),
			(LoadoutPickKind.SimpleWeapon, false) => T(lang, "Arma semplice", "Simple weapon"),
			(LoadoutPickKind.MartialWeapon, true) => T(lang, "Arma da guerra da mischia", "Martial melee weapon"),
			(LoadoutPickKind.MartialWeapon, false) => T(lang, "Arma da guerra", "Martial weapon"),
			_ => T(lang, "Strumento musicale", "Musical instrument")
		};
		public static string LabelCoins(LanguageCode lang) => T(lang, "Monete", "Coins");
		public static string HintEquipmentLater(LanguageCode lang) => T(lang,
			"L'equipaggiamento iniziale è diventato l'inventario: gestiscilo dalla scheda.",
			"The starting equipment became the inventory: manage it from the sheet.");

		// Spells
		public static string LabelCantrips(LanguageCode lang) => T(lang, "Trucchetti", "Cantrips");
		public static string LabelLeveledSpells(int maxLevel, LanguageCode lang) => T(lang, $"Incantesimi (fino al {maxLevel}° livello)", $"Spells (up to level {maxLevel})");
		public static string SpellsSelected(int count, int max, LanguageCode lang) => T(lang, $"Selezionati: {count} / {max}", $"Selected: {count} / {max}");
		public static string NoSpellsForClass(LanguageCode lang) => T(lang, "Nessun trucchetto o incantesimo da scegliere a questo livello.", "No cantrips or spells to choose at this level.");
		public static string PlaceholderSearchSpell(LanguageCode lang) => T(lang, "Cerca un incantesimo", "Search a spell");
		public static string SpellSourceSpecies(RulesetVersion ruleset, LanguageCode lang) => Is2014(ruleset) ? T(lang, "Razza", "Race") : T(lang, "Specie", "Species");

		// Details
		public static string LabelAppearance(LanguageCode lang) => T(lang, "Aspetto", "Appearance");
		public static string LabelBackstory(LanguageCode lang) => T(lang, "Storia", "Backstory");
		public static string LabelAllies(LanguageCode lang) => T(lang, "Alleati e organizzazioni", "Allies and organizations");
		public static string LabelNotes(LanguageCode lang) => T(lang, "Note", "Notes");
		public static string BtnRollTable(LanguageCode lang) => T(lang, "Tira", "Roll");
		public static string HintPersonality2014(LanguageCode lang) => T(lang,
			"Tira o scegli dalle tabelle del background, oppure scrivi i tuoi.",
			"Roll or pick from the background's tables, or write your own.");

		// Summary and issues
		public static string LabelToComplete(LanguageCode lang) => T(lang, "Scelte da completare", "Choices to complete");
		public static string AllChoicesDone(LanguageCode lang) => T(lang, "Tutte le scelte sono complete.", "Every choice is complete.");

		public static string Issue(CharacterIssue issue, RulesetVersion ruleset, LanguageCode lang)
		{
			string A(int i) => i < issue.Args.Count ? issue.Args[i] : string.Empty;
			return issue.Code switch
			{
				IssueCodes.Name => T(lang, "Dai un nome al personaggio (al massimo 100 caratteri).", "Give the character a name (at most 100 characters)."),
				IssueCodes.Level => T(lang, "Il livello deve essere tra 1 e 20.", "The level must be between 1 and 20."),
				IssueCodes.Species => Is2014(ruleset) ? T(lang, "Scegli una razza.", "Choose a race.") : T(lang, "Scegli una specie.", "Choose a species."),
				IssueCodes.Subspecies or IssueCodes.SubspeciesMissing => Is2014(ruleset) ? T(lang, "Scegli una sottorazza.", "Choose a subrace.") : T(lang, "Scegli una discendenza.", "Choose a lineage."),
				IssueCodes.Size => T(lang, "Taglia non ammessa.", "Size not allowed."),
				IssueCodes.Background => T(lang, "Scegli un background.", "Choose a background."),
				IssueCodes.Class => T(lang, "Scegli la classe.", "Choose the class."),
				IssueCodes.Multiclass => T(lang, $"Multiclasse non permessa: servono 13 nelle caratteristiche primarie di {A(0)}.", $"Multiclassing not allowed: {A(0)} needs 13 in its primary abilities."),
				IssueCodes.Subclass => T(lang, $"Sottoclasse non valida per {A(0)}.", $"Invalid subclass for {A(0)}."),
				IssueCodes.SubclassMissing => T(lang, $"Scegli la sottoclasse di {A(0)}.", $"Choose the {A(0)} subclass."),
				IssueCodes.BaseScores => T(lang, "Assegna tutti e sei i punteggi secondo il metodo scelto.", "Assign all six scores following the chosen method."),
				IssueCodes.Bonuses => T(lang, "Incrementi di caratteristica non validi.", "Invalid ability increases."),
				IssueCodes.BonusesMissing => T(lang, "Scegli le caratteristiche da aumentare.", "Choose the abilities to increase."),
				IssueCodes.Improvement => T(lang, $"Scelta non valida al {A(0)}° livello.", $"Invalid choice at level {A(0)}."),
				IssueCodes.ImprovementMissing => Is2014(ruleset)
					? T(lang, $"Al {A(0)}° livello aumenta i punteggi o scegli un talento.", $"At level {A(0)} raise your scores or choose a feat.")
					: T(lang, $"Al {A(0)}° livello scegli un talento.", $"At level {A(0)} choose a feat."),
				IssueCodes.Feat => T(lang, "Talento sconosciuto.", "Unknown feat."),
				IssueCodes.FeatPrerequisite => T(lang, $"Non soddisfi i prerequisiti di {A(0)}.", $"You do not meet the prerequisites of {A(0)}."),
				IssueCodes.FeatDuplicate => T(lang, $"Il talento {A(0)} si può prendere una volta sola.", $"The {A(0)} feat can be taken only once."),
				IssueCodes.FeatChoice => T(lang, $"Scelte non valide per {A(0)}.", $"Invalid choices for {A(0)}."),
				IssueCodes.FeatChoiceMissing => T(lang, $"Completa le scelte di {A(0)}.", $"Complete the choices of {A(0)}."),
				IssueCodes.SpeciesFeatMissing => T(lang, "Scegli il talento dei tratti.", "Choose the feat of the traits."),
				IssueCodes.ScoreCap => T(lang, "Un punteggio supererebbe il massimo.", "A score would go over the maximum."),
				IssueCodes.Skills => T(lang, "Abilità non valide o ripetute.", "Invalid or repeated skills."),
				IssueCodes.SkillsMissing => T(lang, $"Scegli ancora {A(1)} abilità.", $"Choose {A(1)} more skills."),
				IssueCodes.Expertise => T(lang, $"Maestria non valida ({A(0)}).", $"Invalid Expertise ({A(0)})."),
				IssueCodes.ExpertiseMissing => T(lang, $"Scegli ancora {A(1)} abilità per la Maestria di {A(0)}.", $"Choose {A(1)} more skills for the {A(0)} Expertise."),
				IssueCodes.Languages => Is2014(ruleset) ? T(lang, "Linguaggi non validi o troppi.", "Invalid or too many languages.") : T(lang, "Lingue non valide o troppe.", "Invalid or too many languages."),
				IssueCodes.LanguagesMissing => Is2014(ruleset) ? T(lang, $"Scegli ancora {A(0)} linguaggi.", $"Choose {A(0)} more languages.") : T(lang, $"Scegli ancora {A(0)} lingue.", $"Choose {A(0)} more languages."),
				IssueCodes.Spells => T(lang, $"Incantesimi non validi ({A(0)}).", $"Invalid spells ({A(0)})."),
				IssueCodes.CantripsMissing => T(lang, $"Scegli ancora {A(1)} trucchetti ({A(0)}).", $"Choose {A(1)} more cantrips ({A(0)})."),
				IssueCodes.SpellsMissing => T(lang, $"Scegli ancora {A(1)} incantesimi ({A(0)}).", $"Choose {A(1)} more spells ({A(0)})."),
				IssueCodes.HitPointRoll => T(lang, $"Tiro dei punti ferita non valido al {A(0)}° livello.", $"Invalid hit point roll at level {A(0)}."),
				IssueCodes.FightingStyle => T(lang, $"Stile di combattimento non valido ({A(0)}).", $"Invalid Fighting Style ({A(0)})."),
				IssueCodes.FightingStyleMissing => T(lang, $"Scegli lo stile di combattimento di {A(0)}.", $"Choose the {A(0)} Fighting Style."),
				IssueCodes.Order => T(lang, $"Ordine non valido ({A(0)}).", $"Invalid order ({A(0)})."),
				IssueCodes.OrderMissing => T(lang, $"Scegli l'ordine di {A(0)}.", $"Choose the {A(0)} order."),
				IssueCodes.WeaponMastery => T(lang, $"Maestria nelle armi non valida ({A(0)}).", $"Invalid Weapon Mastery ({A(0)})."),
				IssueCodes.WeaponMasteryMissing => T(lang, $"Scegli ancora {A(1)} armi per la Maestria di {A(0)}.", $"Choose {A(1)} more weapons for the {A(0)} Weapon Mastery."),
				IssueCodes.Equipment => T(lang, "Completa le scelte dell'equipaggiamento.", "Complete the equipment choices."),
				_ => issue.ToString()
			};
		}

		// ===== Sheet =====
		public static string SheetArmorClass(LanguageCode lang) => T(lang, "CA", "AC");
		public static string SheetArmorClassLong(LanguageCode lang) => T(lang, "Classe Armatura", "Armor Class");
		public static string SheetHitPoints(LanguageCode lang) => T(lang, "Punti ferita", "Hit points");
		public static string SheetTempHitPoints(LanguageCode lang) => T(lang, "PF temporanei", "Temporary HP");
		public static string SheetInitiative(LanguageCode lang) => T(lang, "Iniziativa", "Initiative");
		public static string SheetSpeed(LanguageCode lang) => T(lang, "Velocità", "Speed");
		public static string SheetProficiency(LanguageCode lang) => T(lang, "Competenza", "Proficiency");
		public static string SheetPassivePerception(LanguageCode lang) => T(lang, "Percezione passiva", "Passive Perception");
		public static string SheetHitDice(LanguageCode lang) => T(lang, "Dadi vita", "Hit dice");
		public static string SheetSaves(LanguageCode lang) => T(lang, "Tiri salvezza", "Saving throws");
		public static string SheetSkills(LanguageCode lang) => T(lang, "Abilità", "Skills");
		public static string SheetEquipment(LanguageCode lang) => T(lang, "Equipaggiamento", "Equipment");
		public static string SheetSpells(LanguageCode lang) => T(lang, "Incantesimi", "Spells");
		public static string SheetOrigin(LanguageCode lang) => T(lang, "Origine", "Origin");
		public static string SheetFeats(LanguageCode lang) => T(lang, "Talenti", "Feats");
		public static string SheetProficiencies(LanguageCode lang) => T(lang, "Competenze", "Proficiencies");
		public static string SheetArmorTraining(LanguageCode lang) => T(lang, "Armature", "Armor");
		public static string SheetAttacks(LanguageCode lang) => T(lang, "Attacchi", "Attacks");
		public static string SheetSpellSlots(LanguageCode lang) => T(lang, "Slot incantesimo", "Spell slots");
		public static string SheetPactSlots(int level, LanguageCode lang) => T(lang, $"Slot del patto ({level}° livello)", $"Pact slots (level {level})");
		public static string SheetSpellcasting(AbilityScore ability, int dc, int attack, LanguageCode lang) => T(lang,
			$"{Shared.Localization.FeatPrerequisiteFormatter.AbilityName(ability, lang)} · CD {dc} · attacco {Shared.Rules.CharacterMath.FormatModifier(attack)}",
			$"{Shared.Localization.FeatPrerequisiteFormatter.AbilityName(ability, lang)} · DC {dc} · attack {Shared.Rules.CharacterMath.FormatModifier(attack)}");
		public static string SheetExpertiseMark(LanguageCode lang) => T(lang, "Maestria", "Expertise");

		public static string TabOverview(LanguageCode lang) => T(lang, "Panoramica", "Overview");
		public static string TabAbilities(LanguageCode lang) => T(lang, "Caratteristiche", "Abilities");
		public static string TabSpells(LanguageCode lang) => T(lang, "Incantesimi", "Spells");
		public static string TabInventory(LanguageCode lang) => T(lang, "Inventario", "Inventory");
		public static string TabFeatures(LanguageCode lang) => T(lang, "Privilegi", "Features");
		public static string TabNotes(LanguageCode lang) => T(lang, "Note", "Notes");

		public static string BtnDamage(LanguageCode lang) => T(lang, "Danno", "Damage");
		public static string BtnHeal(LanguageCode lang) => T(lang, "Cura", "Heal");
		public static string BtnTempHp(LanguageCode lang) => T(lang, "PF temp.", "Temp HP");
		public static string PlaceholderAmount(LanguageCode lang) => T(lang, "Quantità", "Amount");
		public static string SheetDeathSaves(LanguageCode lang) => T(lang, "Tiri salvezza contro morte", "Death saving throws");
		public static string SheetSuccesses(LanguageCode lang) => T(lang, "Successi", "Successes");
		public static string SheetFailures(LanguageCode lang) => T(lang, "Fallimenti", "Failures");
		public static string SheetConditions(LanguageCode lang) => T(lang, "Condizioni", "Conditions");
		public static string SheetExhaustion(LanguageCode lang) => T(lang, "Indebolimento", "Exhaustion");
		public static string SheetInspiration(RulesetVersion ruleset, LanguageCode lang) => Is2014(ruleset) ? T(lang, "Ispirazione", "Inspiration") : T(lang, "Ispirazione eroica", "Heroic Inspiration");
		public static string BtnShortRest(LanguageCode lang) => T(lang, "Riposo breve", "Short rest");
		public static string BtnLongRest(LanguageCode lang) => T(lang, "Riposo lungo", "Long rest");
		public static string LongRestText(RulesetVersion ruleset, LanguageCode lang) => Is2014(ruleset)
			? T(lang, "Recuperi tutti i punti ferita, gli slot e metà dei dadi vita spesi (almeno uno); l'indebolimento scende di 1.",
				"You regain all hit points, the spell slots and half the spent hit dice (at least one); exhaustion drops by 1.")
			: T(lang, "Recuperi tutti i punti ferita, gli slot e tutti i dadi vita spesi; l'indebolimento scende di 1.",
				"You regain all hit points, the spell slots and every spent hit die; exhaustion drops by 1.");
		public static string ShortRestText(LanguageCode lang) => T(lang,
			"Spendi dadi vita per recuperare punti ferita (tiro del dado + modificatore di Costituzione); si ripristinano gli slot del patto e i contatori a riposo breve.",
			"Spend hit dice to regain hit points (die roll + Constitution modifier); Pact slots and short-rest counters come back.");
		public static string BtnSpendHitDie(int die, LanguageCode lang) => T(lang, $"Spendi un d{die}", $"Spend a d{die}");
		public static string BtnConfirm(LanguageCode lang) => T(lang, "Conferma", "Confirm");
		public static string SheetResources(LanguageCode lang) => T(lang, "Risorse", "Resources");
		public static string PlaceholderResource(LanguageCode lang) => T(lang, "Ira, Punti Ki, Incanalare Divinità...", "Rage, Ki points, Channel Divinity...");
		public static string LabelShortRestReset(LanguageCode lang) => T(lang, "Si ripristina con il riposo breve", "Resets on a short rest");
		public static string BtnAdd(LanguageCode lang) => T(lang, "Aggiungi", "Add");
		public static string BtnRemove(LanguageCode lang) => T(lang, "Rimuovi", "Remove");
		public static string SheetEquipped(LanguageCode lang) => T(lang, "Indossato", "Equipped");
		public static string SheetAttuned(LanguageCode lang) => T(lang, "Sintonia", "Attuned");
		public static string SheetQuantity(LanguageCode lang) => T(lang, "Qtà", "Qty");
		public static string SheetWeight(LanguageCode lang) => T(lang, "Peso", "Weight");
		public static string SheetCarrying(string total, string capacity, LanguageCode lang) => T(lang, $"Peso trasportato: {total} su {capacity}", $"Carried weight: {total} of {capacity}");
		public static string PlaceholderSearchItem(LanguageCode lang) => T(lang, "Cerca nel compendio o scrivi un oggetto", "Search the compendium or type an item");
		public static string BtnAddFreeItem(string name, LanguageCode lang) => T(lang, $"Aggiungi \"{name}\"", $"Add \"{name}\"");
		public static string SheetAttackBonus(LanguageCode lang) => T(lang, "Tiro per colpire", "Attack");
		public static string SheetDamage(LanguageCode lang) => T(lang, "Danni", "Damage");
		public static string SheetNotProficient(LanguageCode lang) => T(lang, "senza competenza", "not proficient");
		public static string NoAttacks(LanguageCode lang) => T(lang, "Indossa un'arma dall'inventario per vederne l'attacco.", "Equip a weapon in the inventory to see its attack.");
		public static string SheetSaved(LanguageCode lang) => T(lang, "Salvato", "Saved");
		public static string SheetSaving(LanguageCode lang) => T(lang, "Salvataggio...", "Saving...");
		public static string SheetSaveFailed(LanguageCode lang) => T(lang, "Salvataggio non riuscito", "Save failed");
		public static string BtnLevelUp(LanguageCode lang) => T(lang, "Sali di livello", "Level up");
		public static string BtnEditCharacter(LanguageCode lang) => T(lang, "Modifica", "Edit");
		public static string BtnDownloadPdf(LanguageCode lang) => T(lang, "Scarica PDF", "Download PDF");
		public static string SheetTodoBanner(LanguageCode lang) => T(lang, "Ci sono scelte da completare:", "Some choices are still to make:");
		public static string RollNormal(LanguageCode lang) => T(lang, "Normale", "Normal");
		public static string RollAdvantage(LanguageCode lang) => T(lang, "Vantaggio", "Advantage");
		public static string RollDisadvantage(LanguageCode lang) => T(lang, "Svantaggio", "Disadvantage");
		public static string HintClickToRoll(LanguageCode lang) => T(lang, "Tocca un valore per tirare il d20.", "Tap a value to roll the d20.");
		public static string SheetExperience(LanguageCode lang) => T(lang, "Punti esperienza", "Experience points");
		public static string SheetAdjustments(LanguageCode lang) => T(lang, "Modificatori manuali", "Manual adjustments");
		public static string HintAdjustments(LanguageCode lang) => T(lang,
			"Per oggetti magici e privilegi che la scheda non calcola da sola.",
			"For magic items and features the sheet does not compute by itself.");
		public static string LabelMaxHpAdjustment(LanguageCode lang) => T(lang, "PF massimi", "Max HP");
		public static string LabelExtraSkills(LanguageCode lang) => T(lang, "Altre competenze nelle abilità", "Other skill proficiencies");
		public static string LabelExtraExpertise(LanguageCode lang) => T(lang, "Altre maestrie", "Other Expertise");
		public static string LabelExtraSaves(LanguageCode lang) => T(lang, "Altri tiri salvezza", "Other saving throws");
		public static string LabelOtherProficiencies(LanguageCode lang) => T(lang, "Strumenti e altre competenze", "Tools and other proficiencies");
		public static string LabelFeatureNotes(LanguageCode lang) => T(lang, "Opzioni dei privilegi (suppliche, metamagia, manovre...)", "Feature options (invocations, metamagic, maneuvers...)");
		public static string SheetFeaturesOf(string name, int level, LanguageCode lang) => T(lang, $"{name} · {level}° livello", $"{name} · level {level}");
		public static string PdfFooter(LanguageCode lang) => T(lang, "Scheda generata da RealmForge", "Sheet generated by RealmForge");

		public static string HintStartingLevel(LanguageCode lang) => T(lang,
			"I livelli oltre il primo si possono distribuire fra più classi nel passo Livelli e multiclasse.",
			"Levels after the first can be spread over several classes in the Levels and multiclassing step.");
		public static string FeatNoChoices(LanguageCode lang) => T(lang, "Questo talento non richiede scelte.", "This feat needs no choices.");
		public static string HintScoreBreakdown(RulesetVersion ruleset, LanguageCode lang) => Is2014(ruleset)
			? T(lang, "Punteggio base + incrementi razziali e dei livelli = punteggio finale.", "Base score + racial and level increases = final score.")
			: T(lang, "Punteggio base + incrementi del background e dei talenti = punteggio finale.", "Base score + background and feat increases = final score.");
		public static string WordOr(LanguageCode lang) => T(lang, " o ", " or ");
		public static string WordAnd(LanguageCode lang) => T(lang, " e ", " and ");
		public static string LabelOption(LanguageCode lang) => T(lang, "Opzione", "Option");
		public static string HintStyleCantrips(LanguageCode lang) => T(lang, "I due trucchetti si scelgono nel passo Incantesimi.", "The two cantrips are chosen in the Spells step.");
		public static string SlotLevel(int level, LanguageCode lang) => T(lang, $"{level}° livello", $"Level {level}");
		public static string ConcentrationShort(LanguageCode lang) => T(lang, "concentrazione", "concentration");
		public static string SheetSaveShort(LanguageCode lang) => T(lang, "TS", "Save");
		public static string HintSaveIncomplete(LanguageCode lang) => T(lang,
			"Puoi forgiare il personaggio anche ora e completare queste scelte in seguito dalla scheda.",
			"You can forge the character now and complete these choices later from the sheet.");
		public static string SheetHitPointsShort(LanguageCode lang) => T(lang, "PF", "HP");
		public static string SheetSpellAttack(LanguageCode lang) => T(lang, "Attacco con incantesimo", "Spell attack");

		public static string ArmorTrainingText(ArmorTraining training, LanguageCode lang)
		{
			var parts = new List<string>();
			if (training.HasFlag(ArmorTraining.Light)) parts.Add(T(lang, "leggere", "light"));
			if (training.HasFlag(ArmorTraining.Medium)) parts.Add(T(lang, "medie", "medium"));
			if (training.HasFlag(ArmorTraining.Heavy)) parts.Add(T(lang, "pesanti", "heavy"));
			if (training.HasFlag(ArmorTraining.Shield)) parts.Add(T(lang, "scudi", "shields"));
			return parts.Count == 0 ? T(lang, "nessuna", "none") : string.Join(", ", parts);
		}

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

		public static string OptionName(RuleOption option, LanguageCode lang) => lang == LanguageCode.It ? option.NameIt : option.NameEn;

		public static string CoinName(CoinType coin, LanguageCode lang) => (coin, lang == LanguageCode.It) switch
		{
			(CoinType.Cp, true) => "mr",
			(CoinType.Sp, true) => "ma",
			(CoinType.Ep, true) => "me",
			(CoinType.Gp, true) => "mo",
			(CoinType.Pp, true) => "mp",
			(CoinType.Cp, false) => "CP",
			(CoinType.Sp, false) => "SP",
			(CoinType.Ep, false) => "EP",
			(CoinType.Gp, false) => "GP",
			_ => "PP"
		};

		public static string FormatWeight(decimal pounds, LanguageCode lang) => lang == LanguageCode.It
			? $"{pounds / 2m:0.#} kg"
			: $"{pounds:0.#} lb.";
			// ===== Wizard: clearer choices =====

		public static string SelectorPlaceholder(LanguageCode lang) => T(lang, "Scegli…", "Choose…");
		public static string SkillAlreadyKnown(string source, LanguageCode lang) => T(lang, $"Già nota grazie a: {source}", $"Already known from: {source}");
		public static string SourceSheet(LanguageCode lang) => T(lang, "scheda", "sheet");
		public static string AlreadyExpertise(LanguageCode lang) => T(lang, "già con maestria", "already expertise");
		public static string NotProficient(LanguageCode lang) => T(lang, "serve la competenza", "needs proficiency");
		public static string HintKnownSkills(LanguageCode lang) => T(lang,
			"Le abilità con ✓ sono già note (dal background, dalla specie o da un'altra classe): non si possono scegliere due volte, quindi non contano tra quelle da scegliere.",
			"Skills marked ✓ are already known (from the background, species or another class): they cannot be picked twice, so they do not count toward your picks.");
		public static string HitPointsSummary(int die, LanguageCode lang) => T(lang,
			$"PF al 1° livello: {die} + mod. Cos · poi {die / 2 + 1} + mod. Cos per livello",
			$"HP at level 1: {die} + Con mod · then {die / 2 + 1} + Con mod per level");
		public static string SpellListOf(string className, LanguageCode lang) => T(lang, $"lista del {className}", $"{className} list");
		public static string LabelClassDescription(LanguageCode lang) => T(lang, "Descrizione", "Description");
		public static string LabelFinalShort(LanguageCode lang) => T(lang, "Finale", "Final");
		public static string LabelModifierShort(LanguageCode lang) => T(lang, "mod.", "mod");
		public static string LabelNotAssigned(LanguageCode lang) => T(lang, "Da assegnare", "Not assigned");
		public static string DraftRestored(LanguageCode lang) => T(lang, "Abbiamo ripreso la creazione da dove l'avevi lasciata.", "We picked up the creation where you left it.");
		public static string BtnStartOver(LanguageCode lang) => T(lang, "Ricomincia da capo", "Start over");
		public static string BtnSpellDetails(LanguageCode lang) => T(lang, "Dettagli dell'incantesimo", "Spell details");
		public static string OpenInCompendium(LanguageCode lang) => T(lang, "Apri nel compendio ↗", "Open in the compendium ↗");
		public static string LoadingTraits(LanguageCode lang) => T(lang, "Caricamento dei tratti…", "Loading traits…");
		public static string HintSuggest(LanguageCode lang) => T(lang,
			"Serve un'idea? I suggerimenti partono da classe, origine e allineamento: modificali come preferisci.",
			"Need an idea? Suggestions start from class, origin and alignment: change them as you like.");
		public static string BtnSuggestAll(LanguageCode lang) => T(lang, "Suggerisci i campi vuoti", "Suggest empty fields");
		public static string BtnSuggest(LanguageCode lang) => T(lang, "Suggerisci", "Suggest");

		// ===== Sheet: play helpers =====

		public static string TabCombat(LanguageCode lang) => T(lang, "Combattimento", "Combat");
		public static string PortraitTooLarge(LanguageCode lang) => T(lang, "Immagine non valida o troppo grande.", "The image is not valid or too large.");
		public static string BtnPortrait(LanguageCode lang) => T(lang, "Ritratto", "Portrait");
		public static string LabelAge(LanguageCode lang) => T(lang, "Età", "Age");
		public static string LabelGender(LanguageCode lang) => T(lang, "Genere", "Gender");
		public static string LabelFaith(LanguageCode lang) => T(lang, "Fede", "Faith");
		public static string LabelHeight(LanguageCode lang) => T(lang, "Altezza", "Height");
		public static string SheetSensesAndTraits(LanguageCode lang) => T(lang, "Sensi e tratti", "Senses and traits");
		public static string PassiveShort(string skill, LanguageCode lang) => T(lang, $"{skill} pass.", $"Passive {skill}");
		public static string SheetTempShort(LanguageCode lang) => T(lang, "temp.", "temp");
		public static string BtnAddExperience(LanguageCode lang) => T(lang, "Aggiungi PE", "Add XP");
		public static string ReadyToLevelUp(LanguageCode lang) => T(lang, "Hai abbastanza esperienza per salire di livello!", "You have enough experience to level up!");
		public static string SheetConditionsTitle(LanguageCode lang) => T(lang, "Condizioni ed effetti", "Conditions and effects");
		public static string LevelShort(LanguageCode lang) => T(lang, "liv.", "lvl");
		public static string BtnReset(LanguageCode lang) => T(lang, "Azzera", "Reset");
		public static string ConditionEffect(LanguageCode lang) => T(lang, "(effetto)", "(effect)");
		public static string ConditionCause(LanguageCode lang) => T(lang, "(causa)", "(cause)");

		//	Exhaustion summary in our own words: 2024 is a flat penalty per level, 2014 a cumulative table
		public static string ExhaustionEffect(RulesetVersion ruleset, int level, LanguageCode lang)
		{
			if (level >= 6)
			{
				return T(lang, "il personaggio muore.", "the character dies.");
			}
			if (!Is2014(ruleset))
			{
				return T(lang,
					$"−{level * 2} alle prove con il d20 e velocità ridotta di {UiText.FormatSpeed(level * 5, lang)}. Un riposo lungo toglie un livello.",
					$"−{level * 2} to d20 tests and speed reduced by {UiText.FormatSpeed(level * 5, lang)}. A long rest removes one level.");
			}
			var effects = new List<string>();
			if (level >= 1) effects.Add(T(lang, "svantaggio alle prove di caratteristica", "disadvantage on ability checks"));
			if (level >= 2) effects.Add(T(lang, "velocità dimezzata", "speed halved"));
			if (level >= 3) effects.Add(T(lang, "svantaggio a tiri per colpire e tiri salvezza", "disadvantage on attack rolls and saving throws"));
			if (level >= 4) effects.Add(T(lang, "punti ferita massimi dimezzati", "hit point maximum halved"));
			if (level >= 5) effects.Add(T(lang, "velocità 0", "speed 0"));
			return string.Join("; ", effects) + ".";
		}

		public static string BtnUse(LanguageCode lang) => T(lang, "Usa", "Use");
		public static string SheetSpellsPrepared(LanguageCode lang) => T(lang, "Incantesimi", "Spells");
		public static string RitualShort(LanguageCode lang) => T(lang, "rituale", "ritual");
		public static string CoinLongName(CoinType type, LanguageCode lang) => (type, lang == LanguageCode.It) switch
		{
			(CoinType.Cp, true) => "Rame",
			(CoinType.Sp, true) => "Argento",
			(CoinType.Ep, true) => "Electrum",
			(CoinType.Gp, true) => "Oro",
			(CoinType.Pp, true) => "Platino",
			(CoinType.Cp, false) => "Copper",
			(CoinType.Sp, false) => "Silver",
			(CoinType.Ep, false) => "Electrum",
			(CoinType.Gp, false) => "Gold",
			_ => "Platinum"
		};
		public static string SheetEquippedGroup(LanguageCode lang) => T(lang, "Equipaggiato", "Equipped");
		public static string SheetBackpack(LanguageCode lang) => T(lang, "Zaino", "Backpack");
		public static string BtnEquip(LanguageCode lang) => T(lang, "Equipaggia", "Equip");
		public static string BtnUnequip(LanguageCode lang) => T(lang, "Togli", "Unequip");
			// ===== Advancement type =====

		public static string LabelAdvancement(LanguageCode lang) => T(lang, "Tipo di avanzamento", "Advancement type");
		public static string AdvancementName(AdvancementType type, LanguageCode lang) => type == AdvancementType.Milestone
			? T(lang, "Progressione narrativa", "Story-based progression")
			: T(lang, "Progressione a punti esperienza", "XP-based progression");
		public static string AdvancementHint(AdvancementType type, LanguageCode lang) => type == AdvancementType.Milestone
			? T(lang, "Si sale di livello quando il master lo decide, al raggiungimento di tappe della storia: la scheda non tiene il conto dei PE.",
				"You level up when the game master decides, at milestones of the story: the sheet does not track XP.")
			: T(lang, "Si sale di livello accumulando punti esperienza: la scheda mostra i PE e avvisa quando bastano per il livello successivo.",
				"You level up by earning experience points: the sheet tracks XP and tells you when you have enough for the next level.");
		public static string MilestoneSheetText(LanguageCode lang) => T(lang,
			"Progressione narrativa: sali di livello quando il master annuncia una tappa della storia.",
			"Story-based progression: level up when the game master announces a story milestone.");
	}
}
