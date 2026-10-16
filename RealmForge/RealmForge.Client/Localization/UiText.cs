using RealmForge.Shared.Enums;

namespace RealmForge.Client.Localization
{
	public static class UiText
	{
		#region Navigation & Layout
		public static string NavDashboard(LanguageCode lang) =>
			lang == LanguageCode.It ? "Dashboard" : "Dashboard";

		public static string NavSpecies(LanguageCode lang) =>
			lang == LanguageCode.It ? "Compendio Specie" : "Species Compendium";

		public static string VersionNotice(LanguageCode lang) =>
			lang == LanguageCode.It ? "RealmForge TTRPG Suite v0.1" : "RealmForge TTRPG Suite v0.1";
		#endregion

		#region Dashboard
		public static string HomeTitle(LanguageCode lang) =>
			lang == LanguageCode.It ? "BENVENUTO NELLA FORGIA" : "WELCOME TO THE FORGE";

		public static string HomeSubtitle(LanguageCode lang) =>
			lang == LanguageCode.It
				? "Gestisci le tue campagne, compendi e regole per i tuoi giochi di ruolo da tavolo."
				: "Manage your campaigns, compendiums, and rulebooks for tabletop roleplaying games.";
		#endregion

		#region Common UI Elements & Actions
		public static string Actions(LanguageCode lang) => lang == LanguageCode.It ? "Azioni" : "Actions";
		public static string Edit(LanguageCode lang) => lang == LanguageCode.It ? "Modifica" : "Edit";
		public static string Delete(LanguageCode lang) => lang == LanguageCode.It ? "Elimina" : "Delete";
		public static string Cancel(LanguageCode lang) => lang == LanguageCode.It ? "Annulla" : "Cancel";
		public static string BtnClose(LanguageCode lang) => lang == LanguageCode.It ? "CHIUDI" : "CLOSE";
		public static string BtnCancel(LanguageCode lang) => lang == LanguageCode.It ? "ANNULLA" : "CANCEL";
		public static string BtnViewDetails(LanguageCode lang) => lang == LanguageCode.It ? "DETTAGLI" : "DETAILS";
		public static string BtnInspect(LanguageCode lang) => lang == LanguageCode.It ? "Esamina →" : "Inspect →";
		public static string ConfirmDeletion(LanguageCode lang) => lang == LanguageCode.It ? "Conferma Eliminazione" : "Confirm Deletion";

		public static string TabItalian(LanguageCode lang) => lang == LanguageCode.It ? "🇮🇹 Traduzione Italiana" : "🇮🇹 Italian Translation";
		public static string TabEnglish(LanguageCode lang) => lang == LanguageCode.It ? "🇬🇧 Traduzione Inglese" : "🇬🇧 English Translation";

		public static string LabelName(LanguageCode lang) => lang == LanguageCode.It ? "Nome" : "Name";
		public static string LabelDescription(LanguageCode lang) => lang == LanguageCode.It ? "Descrizione / Note" : "Description / Notes";
		public static string NoDescription(LanguageCode lang) => lang == LanguageCode.It ? "Nessuna annotazione disponibile." : "No notes available.";
		#endregion

		#region Backgrounds
		public static string BackgroundsTitle(LanguageCode lang) => lang == LanguageCode.It ? "Background" : "Backgrounds";
		public static string BackgroundsSubtitle(LanguageCode lang) => lang == LanguageCode.It
			? "Origini, competenze e talenti di partenza dei personaggi"
			: "Character origins, proficiencies and starting feats";
		public static string LoadingBackgrounds(LanguageCode lang) => lang == LanguageCode.It ? "Consultazione degli archivi..." : "Consulting the archives...";
		public static string NoBackgroundsFound(LanguageCode lang) => lang == LanguageCode.It ? "Nessun background trovato." : "No backgrounds found.";
		public static string BtnAddBackground(LanguageCode lang) => lang == LanguageCode.It ? "+ NUOVO BACKGROUND" : "+ ADD BACKGROUND";
		public static string BtnSaveBackground(LanguageCode lang) => lang == LanguageCode.It ? "SALVA BACKGROUND" : "SAVE BACKGROUND";
		public static string ModalTitleAddBackground(LanguageCode lang) => lang == LanguageCode.It ? "FORGIA BACKGROUND" : "FORGE BACKGROUND";
		public static string LabelSearchBackground(LanguageCode lang) => lang == LanguageCode.It ? "Cerca background" : "Search background";
		public static string PlaceholderSearchBackgrounds(LanguageCode lang) => lang == LanguageCode.It ? "Es. Accolito, Soldato..." : "e.g. Acolyte, Soldier...";
		public static string LabelMechanics(LanguageCode lang) => lang == LanguageCode.It ? "Meccaniche" : "Mechanics";
		public static string LabelAbilityOptions(LanguageCode lang) => lang == LanguageCode.It ? "Caratteristiche (max 3)" : "Abilities (max 3)";
		public static string LabelAbilityOptionsShort(LanguageCode lang) => lang == LanguageCode.It ? "Caratteristiche:" : "Abilities:";
		public static string LabelSkillProficiencies(LanguageCode lang) => lang == LanguageCode.It ? "Competenze nelle abilità (max 4)" : "Skill proficiencies (max 4)";
		public static string LabelSkillsShort(LanguageCode lang) => lang == LanguageCode.It ? "Abilità:" : "Skills:";
		public static string LabelOriginFeat(LanguageCode lang) => lang == LanguageCode.It ? "Talento di origine" : "Origin feat";
		public static string LabelOriginFeatShort(LanguageCode lang) => lang == LanguageCode.It ? "Talento:" : "Feat:";
		public static string LabelOriginFeatNote(LanguageCode lang) => lang == LanguageCode.It ? "Variante del talento" : "Feat variant";
		public static string PlaceholderOriginFeatNoteIt(LanguageCode lang) => lang == LanguageCode.It ? "Es. lista degli incantesimi del Chierico" : "e.g. lista degli incantesimi del Chierico";
		public static string PlaceholderOriginFeatNoteEn(LanguageCode lang) => lang == LanguageCode.It ? "Es. Cleric spell list" : "e.g. Cleric spell list";
		public static string LabelToolProficiencies(LanguageCode lang) => lang == LanguageCode.It ? "Competenze negli attrezzi" : "Tool proficiencies";
		public static string LabelLanguages(LanguageCode lang) => lang == LanguageCode.It ? "Linguaggi" : "Languages";
		public static string LabelEquipment(LanguageCode lang) => lang == LanguageCode.It ? "Equipaggiamento" : "Equipment";
		public static string LabelFeatureName(LanguageCode lang) => lang == LanguageCode.It ? "Privilegio" : "Feature";
		public static string LabelFeatureDescription(LanguageCode lang) => lang == LanguageCode.It ? "Descrizione del privilegio" : "Feature description";
		public static string LabelSuggestedCharacteristics(LanguageCode lang) => lang == LanguageCode.It ? "Caratteristiche suggerite" : "Suggested characteristics";
		public static string LabelCharacteristicsIntro(LanguageCode lang) => lang == LanguageCode.It ? "Introduzione" : "Introduction";
		public static string LabelPersonalityTraits(LanguageCode lang) => lang == LanguageCode.It ? "Tratti caratteriali" : "Personality traits";
		public static string LabelIdeals(LanguageCode lang) => lang == LanguageCode.It ? "Ideali" : "Ideals";
		public static string LabelBonds(LanguageCode lang) => lang == LanguageCode.It ? "Legami" : "Bonds";
		public static string LabelFlaws(LanguageCode lang) => lang == LanguageCode.It ? "Difetti" : "Flaws";
		public static string HintOnePerLine(LanguageCode lang) => lang == LanguageCode.It ? "Una voce per riga, nell'ordine del tiro di dado" : "One entry per line, in die-roll order";
		public static string BtnShowCharacteristics(LanguageCode lang) => lang == LanguageCode.It ? "▸ Caratteristiche suggerite" : "▸ Suggested characteristics";
		public static string BtnHideCharacteristics(LanguageCode lang) => lang == LanguageCode.It ? "▾ Caratteristiche suggerite" : "▾ Suggested characteristics";
		public static string BtnOpenFeat(LanguageCode lang) => lang == LanguageCode.It ? "Apri talento →" : "Open feat →";
		public static string NoOriginFeat(LanguageCode lang) => lang == LanguageCode.It ? "Nessuno" : "None";
		public static string DeleteBackgroundWarning(LanguageCode lang, string name) => lang == LanguageCode.It
			? $"Eliminare definitivamente il background \"{name}\"? L'operazione non può essere annullata."
			: $"Permanently delete the background \"{name}\"? This cannot be undone.";
		public static string ErrDeleteBackground(LanguageCode lang) => lang == LanguageCode.It ? "Errore durante l'eliminazione del background." : "Failed to delete background.";
		#endregion

		#region Account
		public static string AccountTitle(LanguageCode lang) => lang == LanguageCode.It ? "Account" : "Account";
		public static string AccountLoginTitle(LanguageCode lang) => lang == LanguageCode.It ? "ACCEDI ALLA FORGIA" : "SIGN IN TO THE FORGE";
		public static string AccountRegisterTitle(LanguageCode lang) => lang == LanguageCode.It ? "CREA UN ACCOUNT" : "CREATE AN ACCOUNT";
		public static string AccountSignedInAs(LanguageCode lang) => lang == LanguageCode.It ? "Accesso effettuato come" : "Signed in as";
		public static string AccountSwitchToRegister(LanguageCode lang) => lang == LanguageCode.It ? "Non hai un account? Registrati" : "No account? Register";
		public static string AccountSwitchToLogin(LanguageCode lang) => lang == LanguageCode.It ? "Hai già un account? Accedi" : "Already registered? Sign in";
		public static string LabelPassword(LanguageCode lang) => lang == LanguageCode.It ? "Password" : "Password";
		public static string PasswordHint(LanguageCode lang) => lang == LanguageCode.It
			? "Almeno 6 caratteri, con una maiuscola, una minuscola, un numero e un simbolo."
			: "At least 6 characters, with an uppercase, a lowercase letter, a digit and a symbol.";
		public static string BtnLogin(LanguageCode lang) => lang == LanguageCode.It ? "Accedi" : "Sign in";
		public static string BtnRegister(LanguageCode lang) => lang == LanguageCode.It ? "Registrati" : "Register";
		public static string BtnLoginToForge(LanguageCode lang) => lang == LanguageCode.It ? "Accedi per forgiare" : "Sign in to forge";
		public static string BtnLogout(LanguageCode lang) => lang == LanguageCode.It ? "Esci" : "Sign out";

		public static string AuthError(string code, LanguageCode lang) => (code, lang == LanguageCode.It) switch
		{
			("InvalidCredentials", true) => "Email o password non corrette.",
			("InvalidCredentials", false) => "Wrong email or password.",
			("MissingFields", true) => "Inserisci email e password.",
			("MissingFields", false) => "Enter email and password.",
			("Unreachable", true) => "Impossibile contattare il server.",
			("Unreachable", false) => "Cannot reach the server.",
			("DuplicateUserName" or "DuplicateEmail", true) => "Esiste già un account con questa email.",
			("DuplicateUserName" or "DuplicateEmail", false) => "An account with this email already exists.",
			("InvalidEmail" or "InvalidUserName", true) => "Email non valida.",
			("InvalidEmail" or "InvalidUserName", false) => "Invalid email.",
			("PasswordTooShort", true) => "La password deve avere almeno 6 caratteri.",
			("PasswordTooShort", false) => "The password must be at least 6 characters long.",
			("PasswordRequiresDigit", true) => "La password deve contenere un numero.",
			("PasswordRequiresDigit", false) => "The password must contain a digit.",
			("PasswordRequiresUpper", true) => "La password deve contenere una lettera maiuscola.",
			("PasswordRequiresUpper", false) => "The password must contain an uppercase letter.",
			("PasswordRequiresLower", true) => "La password deve contenere una lettera minuscola.",
			("PasswordRequiresLower", false) => "The password must contain a lowercase letter.",
			("PasswordRequiresNonAlphanumeric", true) => "La password deve contenere un simbolo (es. ! ? #).",
			("PasswordRequiresNonAlphanumeric", false) => "The password must contain a symbol (e.g. ! ? #).",
			(_, true) => "Operazione non riuscita. Riprova.",
			(_, false) => "Something went wrong. Please try again."
		};
		#endregion

		#region Common Validation & Errors
		public static string ApiError(RealmForge.Client.Services.ApiErrorKind kind, LanguageCode lang) => (kind, lang == LanguageCode.It) switch
		{
			(RealmForge.Client.Services.ApiErrorKind.Unreachable, true) => "Impossibile contattare il server. Verifica che l'API sia avviata.",
			(RealmForge.Client.Services.ApiErrorKind.Unreachable, false) => "Cannot reach the server. Check that the API is running.",
			(RealmForge.Client.Services.ApiErrorKind.Forbidden, true) => "Operazione non consentita: puoi modificare solo i tuoi contenuti Homebrew (gli SRD sono in sola lettura).",
			(RealmForge.Client.Services.ApiErrorKind.Forbidden, false) => "Operation not allowed: you can only modify your own Homebrew content (SRD is read-only).",
			(RealmForge.Client.Services.ApiErrorKind.Unauthorized, true) => "Accesso richiesto: effettua il login per creare o modificare contenuti.",
			(RealmForge.Client.Services.ApiErrorKind.Unauthorized, false) => "Sign-in required: log in to create or edit content.",
			(RealmForge.Client.Services.ApiErrorKind.Validation, true) => "Dati non validi: controlla i campi del modulo.",
			(RealmForge.Client.Services.ApiErrorKind.Validation, false) => "Invalid data: please check the form fields.",
			(_, true) => "Errore del server. Riprova tra poco.",
			(_, false) => "Server error. Please try again shortly."
		};

		public static string ErrFillNames(LanguageCode lang) =>
			lang == LanguageCode.It ? "Inserire sia il nome italiano che quello inglese prima di salvare!" : "Please provide both Italian and English names before saving!";

		public static string ErrApiSave(LanguageCode lang) =>
			lang == LanguageCode.It ? "Errore durante il salvataggio nell'archivio." : "Error while saving to the archive.";
		#endregion

		#region Game System & Metadata (Shared)
		public static string LabelRuleset(LanguageCode lang) =>
			lang == LanguageCode.It ? "Regolamento / Edizione" : "Ruleset / Edition";

		public static string FormatRuleset(RulesetVersion ruleset, LanguageCode lang) => (ruleset, lang) switch
		{
			(RulesetVersion.Dnd5e_2014, LanguageCode.It) => "5e (2014)",
			(RulesetVersion.Dnd5e_2014, LanguageCode.En) => "5e (2014)",
			(RulesetVersion.Dnd5e_2024, LanguageCode.It) => "5.5e (2024)",
			(RulesetVersion.Dnd5e_2024, LanguageCode.En) => "5.5e (2024)",
			_ => ruleset.ToString()
		};

		//	Platform content (seeded, read-only for everyone); the text origin is shown by FormatSource
		public static string BadgeBase(LanguageCode lang) => lang == LanguageCode.It ? "Base" : "Base";

		public static string FormatSource(ContentSource? source, LanguageCode lang) => (source, lang == LanguageCode.It) switch
		{
			(ContentSource.Srd51, true) => "Fonte: SRD 5.1 (CC BY 4.0)",
			(ContentSource.Srd51, false) => "Source: SRD 5.1 (CC BY 4.0)",
			(ContentSource.Srd52, true) => "Fonte: SRD 5.2 (CC BY 4.0)",
			(ContentSource.Srd52, false) => "Source: SRD 5.2 (CC BY 4.0)",
			(_, true) => "Fonte: testo RealmForge",
			(_, false) => "Source: RealmForge text"
		};
		public static string BadgeHomebrew(LanguageCode lang) => lang == LanguageCode.It ? "Homebrew" : "Homebrew";
		public static string LabelRequiredLevel(int level, LanguageCode lang) => lang == LanguageCode.It ? $"Livello {level}" : $"Level {level}";
		#endregion

		#region Global Filters
		public static string LabelOrigin(LanguageCode lang) => lang == LanguageCode.It ? "Origine Contenuto" : "Content Origin";
		public static string FilterAll(LanguageCode lang) => lang == LanguageCode.It ? "Tutti" : "All";
		public static string FilterRulesetAll(LanguageCode lang) => lang == LanguageCode.It ? "Tutte le Edizioni" : "All Editions";
		public static string FilterOriginAll(LanguageCode lang) => lang == LanguageCode.It ? "Tutte le Origini" : "All Origins";
		public static string FilterOnlySRD(LanguageCode lang) => lang == LanguageCode.It ? "Solo Ufficiale (SRD)" : "Official SRD Only";
		public static string FilterOnlyHomebrew(LanguageCode lang) => lang == LanguageCode.It ? "Solo Homebrew" : "Homebrew Only";
		#endregion

		#region Feats Compendium
		public static string FeatsTitle(LanguageCode lang) => lang == LanguageCode.It ? "Talenti" : "Feats";

		public static string FeatsSubtitle(LanguageCode lang) =>
			lang == LanguageCode.It
				? "Consulta i talenti di origine, le doti eroiche e le tecniche di combattimento del multiverso."
				: "Browse origin feats, heroic capabilities, and combat styles across the multiverse.";

		public static string LoadingFeats(LanguageCode lang) =>
			lang == LanguageCode.It ? "Caricamento talenti in corso..." : "Loading feats archive...";

		public static string NoFeatsFound(LanguageCode lang) =>
			lang == LanguageCode.It ? "Nessun talento trovato per i criteri selezionati." : "No feats found matching the criteria.";

		public static string BtnAddFeat(LanguageCode lang) => lang == LanguageCode.It ? "+ NUOVO TALENTO" : "+ ADD FEAT";
		public static string BtnSaveFeat(LanguageCode lang) => lang == LanguageCode.It ? "SALVA TALENTO" : "SAVE FEAT";
		public static string ModalTitleAddFeat(LanguageCode lang) => lang == LanguageCode.It ? "AGGIUNGI NUOVO TALENTO" : "ADD NEW FEAT";

		public static string LabelSearchFeat(LanguageCode lang) => lang == LanguageCode.It ? "Cerca Talento" : "Search Feat";
		public static string PlaceholderSearchFeats(LanguageCode lang) =>
			lang == LanguageCode.It ? "Cerca talento per nome o descrizione..." : "Search feat by name or description...";

		public static string LabelFeatCategory(LanguageCode lang) => lang == LanguageCode.It ? "Categoria Talento" : "Feat Category";
		public static string LabelCategory(LanguageCode lang) => lang == LanguageCode.It ? "Categoria:" : "Category:";
		public static string FilterCategoryAll(LanguageCode lang) => lang == LanguageCode.It ? "Tutti" : "All";

		public static string LabelPrerequisite(LanguageCode lang) => lang == LanguageCode.It ? "Prerequisito:" : "Prerequisite:";
		public static string PlaceholderPrerequisite(LanguageCode lang) => lang == LanguageCode.It ? "Es. Livello 4+, Forza 13+" : "e.g. Level 4+, Strength 13+";
		public static string LabelMinimumLevel(LanguageCode lang) => lang == LanguageCode.It ? "Livello minimo" : "Minimum level";
		public static string LabelMinimumScore(LanguageCode lang) => lang == LanguageCode.It ? "Punteggio minimo" : "Minimum score";
		public static string LabelRequiredFeature(LanguageCode lang) => lang == LanguageCode.It ? "Privilegio / Addestramento" : "Feature / Training";
		public static string LabelAnyOfAbilities(LanguageCode lang) => lang == LanguageCode.It ? "Caratteristiche (almeno una)" : "Abilities (any one of)";
		public static string LabelPreview(LanguageCode lang) => lang == LanguageCode.It ? "Anteprima:" : "Preview:";
		public static string LabelPrerequisiteNote(LanguageCode lang) => lang == LanguageCode.It ? "Altro prerequisito (testo libero)" : "Other prerequisite (free text)";
		public static string PlaceholderPrerequisiteNoteIt(LanguageCode lang) => lang == LanguageCode.It ? "Es. Elfo o Mezzelfo" : "e.g. Elfo o Mezzelfo (Italian)";
		public static string PlaceholderPrerequisiteNoteEn(LanguageCode lang) => lang == LanguageCode.It ? "Es. Elf or Half-Elf (inglese)" : "e.g. Elf or Half-Elf";

		public static string PlaceholderFeatNameIt(LanguageCode lang) => lang == LanguageCode.It ? "Es. Abile, Allerta, Fortunato..." : "e.g. Skilled, Alert, Lucky...";
		public static string PlaceholderFeatNameEn(LanguageCode lang) => lang == LanguageCode.It ? "Es. Skilled, Alert, Lucky..." : "e.g. Skilled, Alert, Lucky...";

		public static string DeleteFeatWarning(LanguageCode lang, string featName) =>
			lang == LanguageCode.It
				? $"Sei sicuro di voler eliminare il talento '{featName}'? L'azione è irreversibile."
				: $"Are you sure you want to delete the feat '{featName}'? This action cannot be undone.";

		public static string ErrDeleteFeat(LanguageCode lang) => lang == LanguageCode.It ? "Errore durante l'eliminazione del talento." : "Failed to delete feat.";

		public static string FormatFeatCategory(FeatCategory cat, LanguageCode lang) => (cat, lang) switch
		{
			(FeatCategory.Origin, LanguageCode.It) => "Origine",
			(FeatCategory.Origin, _) => "Origin",
			(FeatCategory.General, LanguageCode.It) => "Generale",
			(FeatCategory.General, _) => "General",
			(FeatCategory.FightingStyle, LanguageCode.It) => "Stile di Combattimento",
			(FeatCategory.FightingStyle, _) => "Fighting Style",
			(FeatCategory.EpicBoon, LanguageCode.It) => "Dono Epico",
			(FeatCategory.EpicBoon, _) => "Epic Boon",
			_ => cat.ToString()
		};
		#endregion

		#region Species Compendium
		public static string SpeciesTitle(LanguageCode lang) => lang == LanguageCode.It ? "COMPENDIO SPECIE" : "SPECIES COMPENDIUM";

		public static string SpeciesSubtitle(LanguageCode lang) =>
			lang == LanguageCode.It
				? "Archivio delle specie registrate per le tue sessioni"
				: "Archive of registered species for your tabletop sessions";

		public static string LoadingArchives(LanguageCode lang) =>
			lang == LanguageCode.It ? "Consultazione degli archivi..." : "Consulting the archives...";

		public static string NoSpeciesFound(LanguageCode lang) =>
			lang == LanguageCode.It
				? "Nessuna specie registrata nel compendio per la lingua selezionata."
				: "No species registered in the compendium for the selected language.";

		public static string BtnAddSpecies(LanguageCode lang) => lang == LanguageCode.It ? "+ NUOVA SPECIE" : "+ NEW SPECIES";
		public static string BtnSave(LanguageCode lang) => lang == LanguageCode.It ? "FORGIA SPECIE" : "FORGE SPECIES";
		public static string ModalTitleAddSpecies(LanguageCode lang) => lang == LanguageCode.It ? "FORGIA NUOVA SPECIE" : "FORGE NEW SPECIES";

		public static string LabelCreatureType(LanguageCode lang) => lang == LanguageCode.It ? "Tipo di Creatura" : "Creature Type";
		public static string LabelSizes(LanguageCode lang) => lang == LanguageCode.It ? "Taglie Disponibili" : "Available Sizes";
		public static string LabelSpeed(LanguageCode lang) => lang == LanguageCode.It ? "Velocità Base" : "Base Speed";

		public static string MetaSize(LanguageCode lang) => lang == LanguageCode.It ? "Taglia" : "Size";
		public static string MetaSpeed(LanguageCode lang) => lang == LanguageCode.It ? "Velocità" : "Speed";

		public static string PlaceholderNameIt(LanguageCode lang) => lang == LanguageCode.It ? "Es. Nano delle Colline..." : "E.g., Nano delle Colline...";
		public static string PlaceholderNameEn(LanguageCode lang) => lang == LanguageCode.It ? "Es. Hill Dwarf..." : "E.g., Hill Dwarf...";

		public static string DeleteSpeciesWarning(LanguageCode lang, string speciesName) =>
			lang == LanguageCode.It
				? $"Sei sicuro di voler eliminare la specie '{speciesName}'? L'azione è irreversibile."
				: $"Are you sure you want to delete the species '{speciesName}'? This action cannot be undone.";

		public static string LabelSelectSubspecies(LanguageCode lang) => lang == LanguageCode.It ? "Sottospecie / Lignaggio:" : "Subspecies / Lineage:";
		public static string OptionBaseSpeciesOnly(LanguageCode lang) => lang == LanguageCode.It ? "Specie Base" : "Base Species";
		public static string BadgeSourceBase(LanguageCode lang) => lang == LanguageCode.It ? "Specie" : "Species";
		public static string BadgeSourceSubspecies(LanguageCode lang) => lang == LanguageCode.It ? "Sottospecie" : "Subspecies";
		public static string SectionBaseTraits(LanguageCode lang) => lang == LanguageCode.It ? "Tratti della Specie" : "Species Traits";
		public static string SectionSubspecies(LanguageCode lang) => lang == LanguageCode.It ? "Sottospecie e Lignaggi" : "Subspecies & Lineages";
		public static string BadgeTraitsCount(int count, LanguageCode lang) => lang == LanguageCode.It ? $"{count} Tratti" : $"{count} Traits";
		public static string BadgeSubspeciesCount(int count, LanguageCode lang) => lang == LanguageCode.It ? $"{count} Sottospecie" : $"{count} Subspecies";

		public static string FormatCreatureType(CreatureType type, LanguageCode lang) => (type, lang) switch
		{
			(CreatureType.Humanoid, LanguageCode.It) => "Umanoide",
			(CreatureType.Beast, LanguageCode.It) => "Bestia",
			(CreatureType.Fey, LanguageCode.It) => "Folletto",
			(CreatureType.Fiend, LanguageCode.It) => "Immondo",
			(CreatureType.Celestial, LanguageCode.It) => "Celestiale",
			(CreatureType.Undead, LanguageCode.It) => "Non Morto",
			(CreatureType.Construct, LanguageCode.It) => "Costrutto",
			(CreatureType.Dragon, LanguageCode.It) => "Drago",
			(CreatureType.Elemental, LanguageCode.It) => "Elementale",
			(CreatureType.Monstrosity, LanguageCode.It) => "Mostruosità",
			(CreatureType.Aberration, LanguageCode.It) => "Aberrazione",
			(CreatureType.Giant, LanguageCode.It) => "Gigante",
			(CreatureType.Ooze, LanguageCode.It) => "Melma",
			(CreatureType.Plant, LanguageCode.It) => "Vegetale",
			_ => type.ToString()
		};

		public static string FormatSizeSingle(CreatureSize size, LanguageCode lang) => (size, lang) switch
		{
			(CreatureSize.Tiny, LanguageCode.It) => "Minuscola",
			(CreatureSize.Small, LanguageCode.It) => "Piccola",
			(CreatureSize.Medium, LanguageCode.It) => "Media",
			(CreatureSize.Large, LanguageCode.It) => "Grande",
			(CreatureSize.Huge, LanguageCode.It) => "Enorme",
			(CreatureSize.Gargantuan, LanguageCode.It) => "Mastodontica",
			_ => size.ToString()
		};

		public static string FormatSizes(IEnumerable<CreatureSize>? sizes, LanguageCode lang)
		{
			if (sizes == null || !sizes.Any())
			{
				return "-";
			}

			var localizedSizes = sizes.Select(s => FormatSizeSingle(s, lang));
			var separator = lang == LanguageCode.It ? " o " : " or ";
			return string.Join(separator, localizedSizes);
		}

		public static string FormatSpeed(int speedInFeet, LanguageCode lang)
		{
			if (lang == LanguageCode.It)
			{
				double meters = (speedInFeet / 5.0) * 1.5;
				return $"{meters:0.#} m";
			}

			return $"{speedInFeet} ft.";
		}
		#endregion

		#region Subspecies Compendium
		public static string SubspeciesTitle(LanguageCode lang) => lang == LanguageCode.It ? "Sottospecie e Lignaggi" : "Subspecies & Lineages";

		public static string SubspeciesSubtitle(LanguageCode lang) => lang == LanguageCode.It
			? "Gestisci le varianti regionali e i lignaggi derivati dalla specie madre."
			: "Manage regional variants and lineages derived from the parent species.";

		public static string BtnManageSubspecies(LanguageCode lang) => lang == LanguageCode.It ? "Gestisci Sottospecie" : "Manage Subspecies";

		public static string BtnBackToSpecies(LanguageCode lang) => lang == LanguageCode.It ? "← TORNA ALLA SPECIE" : "← BACK TO SPECIES";

		public static string NoSubspeciesFound(LanguageCode lang) => lang == LanguageCode.It
			? "Nessuna sottospecie trovata. Forgia la prima variante!"
			: "No subspecies found. Forge the first variant!";

		public static string BtnAddSubspecies(LanguageCode lang) => lang == LanguageCode.It ? "+ NUOVA SOTTOSPECIE" : "+ NEW SUBSPECIES";
		public static string ModalTitleAddSubspecies(LanguageCode lang) => lang == LanguageCode.It ? "FORGIA SOTTOSPECIE" : "FORGE SUBSPECIES";
		public static string ModalTitleEditSubspecies(LanguageCode lang) => lang == LanguageCode.It ? "MODIFICA SOTTOSPECIE" : "EDIT SUBSPECIES";
		public static string BtnSaveSubspecies(LanguageCode lang) => lang == LanguageCode.It ? "SALVA SOTTOSPECIE" : "SAVE SUBSPECIES";

		public static string LabelSpeedOverride(LanguageCode lang) => lang == LanguageCode.It ? "Override Velocità (Opzionale)" : "Speed Override (Optional)";

		public static string DeleteSubspeciesWarning(LanguageCode lang, string name) => lang == LanguageCode.It
			? $"Sei sicuro di voler eliminare la sottospecie '{name}'? L'azione è irreversibile."
			: $"Are you sure you want to delete the subspecies '{name}'? This action cannot be undone.";

		public static string InheritedFromParent(LanguageCode lang) => lang == LanguageCode.It ? "Ereditato dalla Specie" : "Inherited from Species";
		#endregion

		#region Error Pages (404)
		public static string NotFoundTitle(LanguageCode lang) =>
			lang == LanguageCode.It ? "ROTTA SMARRITA" : "ROUTE LOST";

		public static string NotFoundSubtitle(LanguageCode lang) =>
			lang == LanguageCode.It
				? "Il sentiero che stai cercando non conduce ad alcuna sala di questa forgia."
				: "The path you are seeking leads to no hall in this forge.";

		public static string NotFoundBackHome(LanguageCode lang) =>
			lang == LanguageCode.It ? "RITORNA ALLA DASHBOARD" : "RETURN TO DASHBOARD";
		#endregion
	}
}