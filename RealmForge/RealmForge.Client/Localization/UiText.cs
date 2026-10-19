using RealmForge.Shared.Enums;

namespace RealmForge.Client.Localization
{
	///	<summary>
	///	All the texts of the user interface, in Italian and English, grouped by page or component.
	///	Data texts (names, descriptions) come translated from the API instead.
	///	</summary>
	public static class UiText
	{
		#region Navigation & Layout
		public static string NavDashboard(LanguageCode lang) =>
			lang == LanguageCode.It ? "Dashboard" : "Dashboard";

		public static string NavSpecies(LanguageCode lang) =>
			lang == LanguageCode.It ? "Specie" : "Species";

		//	Reference data (species, backgrounds, feats) is grouped under a collapsible "Compendium" section
		public static string NavCompendium(LanguageCode lang) =>
			lang == LanguageCode.It ? "Compendio" : "Compendium";

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

		public static string DashboardUnavailable(LanguageCode lang) => lang == LanguageCode.It
			? "Impossibile leggere il compendio dal server. Se il sito è rimasto inattivo, il server si sta riavviando: riprova tra un minuto."
			: "Could not read the compendium from the server. If the site was idle, the server is starting up: try again in a minute.";
		public static string DashboardAnonymousHint(LanguageCode lang) => lang == LanguageCode.It
			? "Tutti possono consultare il compendio. Accedi per forgiare i tuoi contenuti Homebrew e condividerli."
			: "Anyone can browse the compendium. Sign in to forge your own Homebrew content and share it.";
		public static string DashboardSignedInHint(LanguageCode lang) => lang == LanguageCode.It
			? "I tuoi contenuti Homebrew, la verifica dell'email e la password sono nella pagina del tuo account."
			: "Your Homebrew content, e-mail verification and password are on your account page.";
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
		public static string LabelToolProficiencies(LanguageCode lang) => lang == LanguageCode.It ? "Competenze negli strumenti" : "Tool proficiencies";
		public static string LabelLanguages(LanguageCode lang) => lang == LanguageCode.It ? "Linguaggi" : "Languages";
		public static string LabelEquipment(LanguageCode lang) => lang == LanguageCode.It ? "Equipaggiamento" : "Equipment";
		public static string LabelEquipmentHint(LanguageCode lang) => lang == LanguageCode.It ? "un oggetto per riga" : "one item per line";
		public static string LabelEquipmentChoice(LanguageCode lang) => lang == LanguageCode.It ? "Scegli A o B" : "Choose A or B";
		public static string LabelEquipmentOptionA(LanguageCode lang) => lang == LanguageCode.It ? "Opzione A · Equipaggiamento" : "Option A · Equipment";
		public static string LabelEquipmentOptionB(LanguageCode lang) => lang == LanguageCode.It ? "Opzione B · Monete d'oro" : "Option B · Gold";
		public static string LabelGoldAlternative(LanguageCode lang) => lang == LanguageCode.It ? "Opzione B (mo)" : "Option B (gp)";
		public static string HintGoldAlternative(LanguageCode lang) => lang == LanguageCode.It ? "Monete d'oro al posto dell'equipaggiamento; vuoto se il background offre solo l'equipaggiamento" : "Gold pieces instead of the equipment; leave empty if the background offers only its equipment";
		public static string FormatGold(int gp, LanguageCode lang) => lang == LanguageCode.It ? $"{gp} mo" : $"{gp} gp";
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
		public static string ShowPassword(LanguageCode lang) => lang == LanguageCode.It ? "Mostra password" : "Show password";
		public static string HidePassword(LanguageCode lang) => lang == LanguageCode.It ? "Nascondi password" : "Hide password";
		public static string PasswordRepeatDiffers(LanguageCode lang) => lang == LanguageCode.It
			? "Attenzione: la password ripetuta è diversa dalla nuova."
			: "Careful: the repeated password differs from the new one.";
		public static string PasswordsMatch(LanguageCode lang) => lang == LanguageCode.It ? "Le password coincidono." : "The passwords match.";
		public static string BtnLogin(LanguageCode lang) => lang == LanguageCode.It ? "Accedi" : "Sign in";
		public static string BtnRegister(LanguageCode lang) => lang == LanguageCode.It ? "Registrati" : "Register";
		public static string BtnVerifyToForge(LanguageCode lang) => lang == LanguageCode.It ? "Verifica l'email per forgiare" : "Verify your e-mail to forge";
		public static string HintVerifyToForge(LanguageCode lang) => lang == LanguageCode.It
			? "Per creare o modificare contenuti Homebrew devi prima confermare il tuo indirizzo email."
			: "Confirm your e-mail address before creating or editing Homebrew content.";
		public static string BtnResendConfirmation(LanguageCode lang) => lang == LanguageCode.It ? "Invia di nuovo l'email di verifica" : "Send the verification e-mail again";
		public static string ConfirmationSent(string email, LanguageCode lang) => lang == LanguageCode.It
			? $"Email di verifica inviata a {email}. Controlla anche la cartella spam."
			: $"Verification e-mail sent to {email}. Check your spam folder too.";
		public static string ConfirmEmailTitle(LanguageCode lang) => lang == LanguageCode.It ? "Conferma email" : "Confirm e-mail";
		public static string ConfirmEmailWorking(LanguageCode lang) => lang == LanguageCode.It ? "Conferma in corso..." : "Confirming...";
		public static string ConfirmEmailDone(LanguageCode lang) => lang == LanguageCode.It
			? "Indirizzo email confermato: ora puoi creare e modificare i tuoi contenuti Homebrew."
			: "E-mail address confirmed: you can now create and edit your Homebrew content.";
		public static string ConfirmEmailOtherTab(LanguageCode lang) => lang == LanguageCode.It
			? "La scheda di RealmForge già aperta è stata aggiornata: questa scheda si chiuderà da sola."
			: "The RealmForge tab you already had open has been updated: this tab will close by itself.";
		//	Password recovery (/forgot-password and /reset-password)
		public static string LinkForgotPassword(LanguageCode lang) => lang == LanguageCode.It ? "Password dimenticata?" : "Forgot your password?";
		public static string ForgotPasswordTitle(LanguageCode lang) => lang == LanguageCode.It ? "PASSWORD DIMENTICATA" : "FORGOT PASSWORD";
		public static string ForgotPasswordIntro(LanguageCode lang) => lang == LanguageCode.It
			? "Inserisci l'email del tuo account: ti invieremo un link per scegliere una nuova password."
			: "Enter your account e-mail: we will send you a link to choose a new password.";
		public static string BtnSendResetLink(LanguageCode lang) => lang == LanguageCode.It ? "Invia il link" : "Send the link";
		public static string ForgotPasswordSent(string email, LanguageCode lang) => lang == LanguageCode.It
			? $"Se {email} corrisponde a un account con email confermata, riceverai a breve un link per reimpostare la password. Controlla anche la cartella spam."
			: $"If {email} belongs to an account with a confirmed e-mail, you will shortly receive a link to reset your password. Check your spam folder too.";
		public static string ForgotPasswordUnconfirmedHint(LanguageCode lang) => lang == LanguageCode.It
			? "Per sicurezza il link viene inviato solo agli indirizzi già confermati."
			: "For security, the link is only sent to addresses that have already been confirmed.";
		public static string ResetPasswordTitle(LanguageCode lang) => lang == LanguageCode.It ? "NUOVA PASSWORD" : "NEW PASSWORD";
		public static string ResetPasswordFor(string email, LanguageCode lang) => lang == LanguageCode.It ? $"Scegli una nuova password per {email}." : $"Choose a new password for {email}.";
		public static string BtnSetPassword(LanguageCode lang) => lang == LanguageCode.It ? "Salva la nuova password" : "Save the new password";
		public static string ResetPasswordDone(LanguageCode lang) => lang == LanguageCode.It
			? "Password aggiornata: ora puoi accedere con la nuova password."
			: "Password updated: you can now sign in with the new password.";
		public static string BtnBackToLogin(LanguageCode lang) => lang == LanguageCode.It ? "Torna all'accesso" : "Back to sign in";
		public static string BtnRequestNewLink(LanguageCode lang) => lang == LanguageCode.It ? "Richiedi un nuovo link" : "Ask for a new link";
		public static string BtnGoToAccount(LanguageCode lang) => lang == LanguageCode.It ? "Vai al tuo account" : "Go to your account";
		public static string BtnLoginToForge(LanguageCode lang) => lang == LanguageCode.It ? "Accedi per forgiare" : "Sign in to forge";
		public static string BtnLogout(LanguageCode lang) => lang == LanguageCode.It ? "Esci" : "Sign out";
		public static string NavAccount(LanguageCode lang) => lang == LanguageCode.It ? "Il mio account" : "My account";
		public static string LabelLanguage(LanguageCode lang) => lang == LanguageCode.It ? "Lingua" : "Language";

		//	Each language is shown in its own name, so it can be found whatever the current language is
		public static string LanguageName(LanguageCode lang) => lang switch
		{
			LanguageCode.It => "Italiano",
			LanguageCode.En => "English",
			_ => lang.ToString()
		};

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
			("MissingPasswords", true) => "Compila tutti i campi della password.",
			("MissingPasswords", false) => "Fill in all the password fields.",
			("InvalidConfirmationLink", true) => "Il link di conferma non è valido o è scaduto: richiedine uno nuovo dalla pagina account.",
			("InvalidConfirmationLink", false) => "The confirmation link is invalid or has expired: ask for a new one from the account page.",
			("PasswordMismatch", true) => "La password attuale non è corretta.",
			("PasswordMismatch", false) => "The current password is wrong.",
			("InvalidToken" or "InvalidResetLink", true) => "Il link per reimpostare la password non è valido o è scaduto: richiedine uno nuovo.",
			("InvalidToken" or "InvalidResetLink", false) => "The password reset link is invalid or has expired: ask for a new one.",
			("MissingEmail", true) => "Inserisci la tua email.",
			("MissingEmail", false) => "Enter your e-mail.",
			("PasswordsDiffer", true) => "Le due nuove password non coincidono.",
			("PasswordsDiffer", false) => "The two new passwords do not match.",
			(_, true) => "Operazione non riuscita. Riprova.",
			(_, false) => "Something went wrong. Please try again."
		};

		//	Account page (signed in)
		public static string LabelSubspeciesShort(LanguageCode lang) => lang == LanguageCode.It ? "Sottospecie" : "Subspecies";
		public static string AccountProfileTitle(LanguageCode lang) => lang == LanguageCode.It ? "Il tuo account" : "Your account";
		public static string AccountRole(bool isAdmin, LanguageCode lang) => (isAdmin, lang == LanguageCode.It) switch
		{
			(true, true) => "Amministratore",
			(true, false) => "Administrator",
			(false, true) => "Utente",
			(false, false) => "User"
		};
		public static string AccountRoleHint(bool isAdmin, LanguageCode lang) => (isAdmin, lang == LanguageCode.It) switch
		{
			(true, true) => "Puoi modificare tutti i contenuti Homebrew.",
			(true, false) => "You can edit every Homebrew entry.",
			(false, true) => "Puoi creare contenuti Homebrew e modificare i tuoi.",
			(false, false) => "You can create Homebrew content and edit your own."
		};
		//	Dates are formatted by hand: the WebAssembly runtime may not ship culture data for every language
		private static readonly string[] MonthsIt = ["gennaio", "febbraio", "marzo", "aprile", "maggio", "giugno", "luglio", "agosto", "settembre", "ottobre", "novembre", "dicembre"];
		private static readonly string[] MonthsEn = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];

		public static string FormatDate(DateTimeOffset date, LanguageCode lang) => lang == LanguageCode.It
			? $"{date.Day} {MonthsIt[date.Month - 1]} {date.Year}"
			: $"{date.Day} {MonthsEn[date.Month - 1]} {date.Year}";

		public static string LabelMemberSince(LanguageCode lang) => lang == LanguageCode.It ? "Registrato il" : "Member since";
		public static string LabelNotAvailable(LanguageCode lang) => lang == LanguageCode.It ? "non disponibile" : "not available";
		public static string LabelEmailStatus(LanguageCode lang) => lang == LanguageCode.It ? "Email" : "Email";
		public static string EmailStatus(bool confirmed, LanguageCode lang) => (confirmed, lang == LanguageCode.It) switch
		{
			(true, true) => "verificata",
			(true, false) => "verified",
			(false, true) => "non verificata",
			(false, false) => "not verified"
		};
		public static string LabelInterfaceLanguage(LanguageCode lang) => lang == LanguageCode.It ? "Lingua dell'interfaccia" : "Interface language";
		public static string AccountHomebrewTitle(LanguageCode lang) => lang == LanguageCode.It ? "I tuoi contenuti Homebrew" : "Your Homebrew content";
		public static string AccountHomebrewEmpty(LanguageCode lang) => lang == LanguageCode.It
			? "Non hai ancora creato contenuti: usa i pulsanti \"Forgia\" nelle pagine del Compendio."
			: "You have not created any content yet: use the \"Forge\" buttons in the Compendium pages.";
		public static string AccountSecurityTitle(LanguageCode lang) => lang == LanguageCode.It ? "Cambia password" : "Change password";
		public static string LabelCurrentPassword(LanguageCode lang) => lang == LanguageCode.It ? "Password attuale" : "Current password";
		public static string LabelNewPassword(LanguageCode lang) => lang == LanguageCode.It ? "Nuova password" : "New password";
		public static string LabelRepeatPassword(LanguageCode lang) => lang == LanguageCode.It ? "Ripeti la nuova password" : "Repeat the new password";
		public static string BtnChangePassword(LanguageCode lang) => lang == LanguageCode.It ? "Aggiorna password" : "Update password";
		public static string PasswordChanged(LanguageCode lang) => lang == LanguageCode.It ? "Password aggiornata." : "Password updated.";
		#endregion

		#region Common Validation & Errors
		public static string ApiError(RealmForge.Client.Services.ApiErrorKind kind, LanguageCode lang) => (kind, lang == LanguageCode.It) switch
		{
			(RealmForge.Client.Services.ApiErrorKind.Unreachable, true) => "Impossibile contattare il server. Verifica che l'API sia avviata.",
			(RealmForge.Client.Services.ApiErrorKind.Unreachable, false) => "Cannot reach the server. Check that the API is running.",
			(RealmForge.Client.Services.ApiErrorKind.Forbidden, true) => "Operazione non consentita: puoi modificare solo i tuoi contenuti Homebrew (i contenuti Base sono in sola lettura).",
			(RealmForge.Client.Services.ApiErrorKind.Forbidden, false) => "Operation not allowed: you can only modify your own Homebrew content (Base content is read-only).",
			(RealmForge.Client.Services.ApiErrorKind.NotAvailable, true) => ContentNotAvailable(lang),
			(RealmForge.Client.Services.ApiErrorKind.NotAvailable, false) => ContentNotAvailable(lang),
			(RealmForge.Client.Services.ApiErrorKind.EmailNotConfirmed, true) => "Conferma il tuo indirizzo email per creare o modificare contenuti (trovi il pulsante per reinviare l'email nella pagina account).",
			(RealmForge.Client.Services.ApiErrorKind.EmailNotConfirmed, false) => "Confirm your e-mail address to create or edit content (the button to resend the e-mail is on the account page).",
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
		//	Homebrew visibility and sharing
		public static string LabelVisibility(LanguageCode lang) => lang == LanguageCode.It ? "Visibilità" : "Visibility";
		public static string FormatVisibility(ContentVisibility visibility, LanguageCode lang) => (visibility, lang == LanguageCode.It) switch
		{
			(ContentVisibility.Private, true) => "Privato",
			(ContentVisibility.Private, false) => "Private",
			(ContentVisibility.Link, true) => "Con link",
			(ContentVisibility.Link, false) => "With link",
			(_, true) => "Pubblico",
			(_, false) => "Public"
		};
		public static string VisibilityHint(ContentVisibility visibility, LanguageCode lang) => (visibility, lang == LanguageCode.It) switch
		{
			(ContentVisibility.Private, true) => "Solo tu puoi vederlo.",
			(ContentVisibility.Private, false) => "Only you can see it.",
			(ContentVisibility.Link, true) => "Chi ha il link può vederlo; non compare negli elenchi degli altri utenti.",
			(ContentVisibility.Link, false) => "Anyone with the link can see it; it does not appear in other users' lists.",
			(_, true) => "Visibile a tutti negli elenchi del Compendio.",
			(_, false) => "Listed for everyone in the Compendium."
		};
		public static string ShareHint(ContentVisibility visibility, LanguageCode lang) => (visibility == ContentVisibility.Link, lang == LanguageCode.It) switch
		{
			(true, true) => "Condivisibile tramite link (sola lettura).",
			(true, false) => "Shareable through its link (read-only).",
			(false, true) => "Pubblico: visibile a tutti. Puoi anche inviarne il link.",
			(false, false) => "Public: visible to everyone. You can also send its link."
		};
		public static string SharePrivateHint(LanguageCode lang) => lang == LanguageCode.It
			? "Privato: per condividerlo imposta la visibilità su \"Con link\" o \"Pubblico\" con Modifica."
			: "Private: to share it, set its visibility to \"With link\" or \"Public\" with Edit.";
		public static string BtnCopyLink(LanguageCode lang) => lang == LanguageCode.It ? "Copia link" : "Copy link";
		public static string LinkCopied(LanguageCode lang) => lang == LanguageCode.It ? "Link copiato ✓" : "Link copied ✓";
		public static string ContentNotAvailable(LanguageCode lang) => lang == LanguageCode.It
			? "Contenuto non disponibile: potrebbe essere privato o essere stato eliminato."
			: "Content not available: it may be private or it was deleted.";

		public static string BadgeBase(LanguageCode lang) => lang == LanguageCode.It ? "Base" : "Base";

		public static string FormatSource(ContentSource? source, LanguageCode lang) => (source, lang == LanguageCode.It) switch
		{
			(ContentSource.Srd51, true) => "Fonte: SRD 5.1",
			(ContentSource.Srd51, false) => "Source: SRD 5.1",
			(ContentSource.Srd52, true) => "Fonte: SRD 5.2",
			(ContentSource.Srd52, false) => "Source: SRD 5.2",
			(_, true) => "Fonte: testo RealmForge",
			(_, false) => "Source: RealmForge text"
		};

		//	Tooltip on the source label: SRD texts are reused under the Creative Commons Attribution 4.0 licence
		public static string SourceDetails(ContentSource? source, LanguageCode lang) => (source, lang == LanguageCode.It) switch
		{
			(ContentSource.Srd51 or ContentSource.Srd52, true) =>
				$"Testo tratto dal System Reference Document {(source == ContentSource.Srd51 ? "5.1" : "5.2")} di Wizards of the Coast, distribuito con licenza Creative Commons Attribuzione 4.0 (CC BY 4.0).",
			(ContentSource.Srd51 or ContentSource.Srd52, false) =>
				$"Text from the System Reference Document {(source == ContentSource.Srd51 ? "5.1" : "5.2")} by Wizards of the Coast, licensed under Creative Commons Attribution 4.0 (CC BY 4.0).",
			(_, true) => "Testo scritto per RealmForge.",
			(_, false) => "Text written for RealmForge."
		};
		public static string BadgeHomebrew(LanguageCode lang) => lang == LanguageCode.It ? "Homebrew" : "Homebrew";
		public static string LabelRequiredLevel(int level, LanguageCode lang) => lang == LanguageCode.It ? $"Livello {level}" : $"Level {level}";
		#endregion

		#region Global Filters
		public static string LabelOrigin(LanguageCode lang) => lang == LanguageCode.It ? "Origine Contenuto" : "Content Origin";
		public static string FilterAll(LanguageCode lang) => lang == LanguageCode.It ? "Tutti" : "All";
		public static string FilterRulesetAll(LanguageCode lang) => lang == LanguageCode.It ? "Tutte le Edizioni" : "All Editions";
		public static string FilterOriginAll(LanguageCode lang) => lang == LanguageCode.It ? "Tutte le Origini" : "All Origins";
		//	"Base" is the platform content (SRD text or RealmForge text), as on the card badges
		public static string FilterOnlyBase(LanguageCode lang) => lang == LanguageCode.It ? "Solo Base" : "Base Only";
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

		#region Spells Compendium
		public static string SpellsTitle(LanguageCode lang) => lang == LanguageCode.It ? "Incantesimi" : "Spells";

		public static string SpellsSubtitle(LanguageCode lang) =>
			lang == LanguageCode.It
				? "Trucchetti e incantesimi dal 1° al 9° livello, con liste per classe."
				: "Cantrips and spells of 1st to 9th level, with class spell lists.";

		public static string LoadingSpells(LanguageCode lang) =>
			lang == LanguageCode.It ? "Consultazione dei grimori..." : "Consulting the spellbooks...";

		public static string NoSpellsFound(LanguageCode lang) =>
			lang == LanguageCode.It ? "Nessun incantesimo corrisponde ai filtri." : "No spells match the filters.";

		public static string LabelSearchSpell(LanguageCode lang) => lang == LanguageCode.It ? "Cerca incantesimo" : "Search spell";
		public static string PlaceholderSearchSpells(LanguageCode lang) => lang == LanguageCode.It ? "Es. Palla di Fuoco, guarigione..." : "e.g. Fireball, healing...";
		public static string LabelSpellLevel(LanguageCode lang) => lang == LanguageCode.It ? "Livello" : "Level";
		public static string LabelSpellSchool(LanguageCode lang) => lang == LanguageCode.It ? "Scuola" : "School";
		public static string LabelSpellClass(LanguageCode lang) => lang == LanguageCode.It ? "Classe" : "Class";
		public static string FilterAllLevels(LanguageCode lang) => lang == LanguageCode.It ? "Tutti i livelli" : "All levels";
		public static string FilterAllSchools(LanguageCode lang) => lang == LanguageCode.It ? "Tutte le scuole" : "All schools";
		public static string FilterAllClasses(LanguageCode lang) => lang == LanguageCode.It ? "Tutte le classi" : "All classes";
		public static string LabelRitual(LanguageCode lang) => lang == LanguageCode.It ? "Rituale" : "Ritual";
		public static string LabelConcentration(LanguageCode lang) => lang == LanguageCode.It ? "Concentrazione" : "Concentration";
		public static string LabelCastingTime(LanguageCode lang) => lang == LanguageCode.It ? "Tempo di lancio" : "Casting time";
		public static string LabelRange(LanguageCode lang) => lang == LanguageCode.It ? "Gittata" : "Range";
		public static string LabelComponents(LanguageCode lang) => lang == LanguageCode.It ? "Componenti" : "Components";
		public static string LabelDuration(LanguageCode lang) => lang == LanguageCode.It ? "Durata" : "Duration";
		public static string LabelMaterialComponent(LanguageCode lang) => lang == LanguageCode.It ? "Componente materiale" : "Material component";
		public static string LabelHigherLevels(LanguageCode lang) => lang == LanguageCode.It ? "Ai livelli superiori" : "At higher levels";
		public static string LabelSpellLists(LanguageCode lang) => lang == LanguageCode.It ? "Liste degli incantesimi" : "Spell lists";
		public static string SpellCount(int count, LanguageCode lang) => lang == LanguageCode.It
			? (count == 1 ? "1 incantesimo" : $"{count} incantesimi")
			: (count == 1 ? "1 spell" : $"{count} spells");
		public static string BtnAddSpell(LanguageCode lang) => lang == LanguageCode.It ? "+ NUOVO INCANTESIMO" : "+ ADD SPELL";
		public static string BtnSaveSpell(LanguageCode lang) => lang == LanguageCode.It ? "SALVA INCANTESIMO" : "SAVE SPELL";
		public static string ModalTitleAddSpell(LanguageCode lang) => lang == LanguageCode.It ? "AGGIUNGI NUOVO INCANTESIMO" : "ADD NEW SPELL";
		public static string PlaceholderSpellNameIt(LanguageCode lang) => lang == LanguageCode.It ? "Es. Dardo di Brina" : "e.g. Dardo di Brina";
		public static string PlaceholderSpellNameEn(LanguageCode lang) => lang == LanguageCode.It ? "Es. Frost Dart" : "e.g. Frost Dart";
		public static string PlaceholderCastingTime(LanguageCode lang, LanguageCode field) => field == LanguageCode.It ? "1 azione" : "1 action";
		public static string PlaceholderRange(LanguageCode lang, LanguageCode field) => field == LanguageCode.It ? "18 metri" : "60 feet";
		public static string PlaceholderDuration(LanguageCode lang, LanguageCode field) => field == LanguageCode.It ? "Concentrazione, fino a 1 minuto" : "Concentration, up to 1 minute";
		public static string ErrSpellStats(LanguageCode lang) => lang == LanguageCode.It
			? "Compila tempo di lancio, gittata e durata in entrambe le lingue."
			: "Fill in casting time, range and duration in both languages.";
		public static string DeleteSpellWarning(LanguageCode lang, string spellName) =>
			lang == LanguageCode.It
				? $"Vuoi eliminare definitivamente l'incantesimo \"{spellName}\"? L'operazione non può essere annullata."
				: $"Do you want to permanently delete the spell \"{spellName}\"? This cannot be undone.";
		public static string ErrDeleteSpell(LanguageCode lang) => lang == LanguageCode.It ? "Errore durante l'eliminazione dell'incantesimo." : "Failed to delete spell.";
		#endregion

		#region Equipment Compendium
		public static string EquipmentTitle(LanguageCode lang) => lang == LanguageCode.It ? "Equipaggiamento" : "Equipment";

		public static string EquipmentSubtitle(LanguageCode lang) =>
			lang == LanguageCode.It
				? "Armi, armature, strumenti, equipaggiamento d'avventura, cavalcature e veicoli."
				: "Weapons, armor, tools, adventuring gear, mounts and vehicles.";

		public static string LoadingEquipment(LanguageCode lang) =>
			lang == LanguageCode.It ? "Inventario dell'armeria..." : "Taking stock of the armory...";

		public static string NoEquipmentFound(LanguageCode lang) =>
			lang == LanguageCode.It ? "Nessun oggetto corrisponde ai filtri." : "No items match the filters.";

		public static string LabelSearchEquipment(LanguageCode lang) => lang == LanguageCode.It ? "Cerca oggetto" : "Search item";
		public static string PlaceholderSearchEquipment(LanguageCode lang) => lang == LanguageCode.It ? "Es. spada lunga, corda, liuto..." : "e.g. longsword, rope, lute...";
		public static string LabelEquipmentCategory(LanguageCode lang) => lang == LanguageCode.It ? "Categoria" : "Category";
		public static string FilterAllCategories(LanguageCode lang) => lang == LanguageCode.It ? "Tutte le categorie" : "All categories";
		public static string LabelWeaponKind(LanguageCode lang) => lang == LanguageCode.It ? "Tipo di arma" : "Weapon kind";
		public static string FilterAllWeapons(LanguageCode lang) => lang == LanguageCode.It ? "Tutte le armi" : "All weapons";
		public static string LabelArmorKind(LanguageCode lang) => lang == LanguageCode.It ? "Tipo di armatura" : "Armor kind";
		public static string FilterAllArmor(LanguageCode lang) => lang == LanguageCode.It ? "Tutte le armature" : "All armor";
		public static string LabelToolKind(LanguageCode lang) => lang == LanguageCode.It ? "Tipo di strumento" : "Tool kind";
		public static string FilterAllTools(LanguageCode lang) => lang == LanguageCode.It ? "Tutti gli strumenti" : "All tools";
		public static string LabelMastery(LanguageCode lang) => lang == LanguageCode.It ? "Padronanza" : "Mastery";
		public static string FilterAnyMastery(LanguageCode lang) => lang == LanguageCode.It ? "Qualsiasi padronanza" : "Any mastery";
		public static string EquipmentCount(int count, LanguageCode lang) => lang == LanguageCode.It
			? (count == 1 ? "1 oggetto" : $"{count} oggetti")
			: (count == 1 ? "1 item" : $"{count} items");
		public static string ColName(LanguageCode lang) => lang == LanguageCode.It ? "Nome" : "Name";
		public static string ColDamage(LanguageCode lang) => lang == LanguageCode.It ? "Danni" : "Damage";
		public static string ColProperties(LanguageCode lang) => lang == LanguageCode.It ? "Proprietà" : "Properties";
		public static string ColWeight(LanguageCode lang) => lang == LanguageCode.It ? "Peso" : "Weight";
		public static string ColCost(LanguageCode lang) => lang == LanguageCode.It ? "Costo" : "Cost";
		public static string ColArmorClass(LanguageCode lang) => lang == LanguageCode.It ? "Classe Armatura (CA)" : "Armor Class (AC)";
		public static string ColStrength(LanguageCode lang) => lang == LanguageCode.It ? "Forza" : "Strength";
		public static string ColStealth(LanguageCode lang) => lang == LanguageCode.It ? "Furtività" : "Stealth";
		public static string StealthDisadvantage(LanguageCode lang) => lang == LanguageCode.It ? "Svantaggio" : "Disadvantage";
		public static string StrengthRequirement(int score, LanguageCode lang) => lang == LanguageCode.It ? $"For {score}" : $"Str {score}";
		public static string ColAbility(LanguageCode lang) => lang == LanguageCode.It ? "Caratteristica" : "Ability";
		public static string ColQuantity(LanguageCode lang) => lang == LanguageCode.It ? "Quantità" : "Amount";
		public static string ColSpeed(LanguageCode lang) => lang == LanguageCode.It ? "Velocità" : "Speed";
		public static string ColCapacity(LanguageCode lang) => lang == LanguageCode.It ? "Capacità di trasporto" : "Carrying capacity";
		public static string ColKind(LanguageCode lang) => lang == LanguageCode.It ? "Tipo" : "Kind";
		public static string BtnWeaponRules(LanguageCode lang) => lang == LanguageCode.It ? "Proprietà delle armi" : "Weapon properties";
		public static string WeaponRulesTitle(LanguageCode lang) => lang == LanguageCode.It ? "Proprietà delle armi" : "Weapon properties";
		public static string MasteryRulesTitle(LanguageCode lang) => lang == LanguageCode.It ? "Proprietà di padronanza (2024)" : "Mastery properties (2024)";
		public static string MasteryRulesIntro(LanguageCode lang) => lang == LanguageCode.It
			? "Si usano solo con il privilegio Padronanza nelle armi (o un talento) che sblocca quell'arma."
			: "They work only with the Weapon Mastery feature (or a feat) that unlocks that weapon.";
		public static string BtnAddEquipment(LanguageCode lang) => lang == LanguageCode.It ? "+ NUOVO OGGETTO" : "+ ADD ITEM";
		public static string BtnSaveEquipment(LanguageCode lang) => lang == LanguageCode.It ? "SALVA OGGETTO" : "SAVE ITEM";
		public static string ModalTitleAddEquipment(LanguageCode lang) => lang == LanguageCode.It ? "AGGIUNGI NUOVO OGGETTO" : "ADD NEW ITEM";
		public static string PlaceholderEquipmentNameIt(LanguageCode lang) => lang == LanguageCode.It ? "Es. Lama del Tramonto" : "e.g. Lama del Tramonto";
		public static string PlaceholderEquipmentNameEn(LanguageCode lang) => lang == LanguageCode.It ? "Es. Dusk Blade" : "e.g. Dusk Blade";
		public static string LabelCostAmount(LanguageCode lang) => lang == LanguageCode.It ? "Costo" : "Cost";
		public static string LabelCoin(LanguageCode lang) => lang == LanguageCode.It ? "Moneta" : "Coin";
		public static string CoinName(int copperValue, LanguageCode lang) => (copperValue, lang == LanguageCode.It) switch
		{
			(100, true) => "mo (oro)",
			(10, true) => "ma (argento)",
			(1, true) => "mr (rame)",
			(100, false) => "GP (gold)",
			(10, false) => "SP (silver)",
			_ => "CP (copper)"
		};
		public static string LabelWeightUnit(LanguageCode lang) => lang == LanguageCode.It ? "Peso (kg)" : "Weight (lb.)";
		public static string LabelDamageDice(LanguageCode lang) => lang == LanguageCode.It ? "Dadi di danno" : "Damage dice";
		public static string LabelDamageType(LanguageCode lang) => lang == LanguageCode.It ? "Tipo di danno" : "Damage type";
		public static string LabelVersatileDice(LanguageCode lang) => lang == LanguageCode.It ? "Danni a due mani" : "Two-handed damage";
		public static string LabelNormalRange(LanguageCode lang) => lang == LanguageCode.It ? "Gittata normale (m)" : "Normal range (ft.)";
		public static string LabelLongRange(LanguageCode lang) => lang == LanguageCode.It ? "Gittata lunga (m)" : "Long range (ft.)";
		public static string LabelBaseArmorClass(LanguageCode lang) => lang == LanguageCode.It ? "CA base (o bonus dello scudo)" : "Base AC (or shield bonus)";
		public static string LabelAddsDexterity(LanguageCode lang) => lang == LanguageCode.It ? "Somma la Destrezza" : "Adds Dexterity";
		public static string LabelMaxDexterity(LanguageCode lang) => lang == LanguageCode.It ? "Massimo di Destrezza" : "Dexterity cap";
		public static string LabelStrengthRequirement(LanguageCode lang) => lang == LanguageCode.It ? "Forza richiesta" : "Strength requirement";
		public static string LabelSpeedFeet(LanguageCode lang) => lang == LanguageCode.It ? "Velocità (m)" : "Speed (ft.)";
		public static string LabelCapacityUnit(LanguageCode lang) => lang == LanguageCode.It ? "Capacità di trasporto (kg)" : "Carrying capacity (lb.)";
		public static string LabelShipSpeed(LanguageCode lang) => lang == LanguageCode.It ? "Velocità (km/h)" : "Speed (mph)";
		public static string LabelNone(LanguageCode lang) => lang == LanguageCode.It ? "Nessuna" : "None";
		public static string ErrEquipmentStats(LanguageCode lang) => lang == LanguageCode.It
			? "Controlla le statistiche: un'arma ha bisogno di dadi di danno (es. 1d8) e tipo di danno, le armi a distanza o da lancio di una gittata, un'armatura della sua CA."
			: "Check the statistics: a weapon needs damage dice (e.g. 1d8) and a damage type, ranged or thrown weapons a range, armor its AC.";
		public static string DeleteEquipmentWarning(LanguageCode lang, string name) =>
			lang == LanguageCode.It
				? $"Vuoi eliminare definitivamente l'oggetto \"{name}\"? L'operazione non può essere annullata."
				: $"Do you want to permanently delete the item \"{name}\"? This cannot be undone.";
		public static string ErrDeleteEquipment(LanguageCode lang) => lang == LanguageCode.It ? "Errore durante l'eliminazione dell'oggetto." : "Failed to delete item.";
		#endregion

		#region Classes Compendium
		public static string ClassesTitle(LanguageCode lang) => lang == LanguageCode.It ? "Classi" : "Classes";

		public static string ClassesSubtitle(LanguageCode lang) =>
			lang == LanguageCode.It
				? "Le classi con i privilegi livello per livello, la tabella di progressione e le sottoclassi."
				: "Classes with their level-by-level features, progression table and subclasses.";

		public static string LoadingClasses(LanguageCode lang) =>
			lang == LanguageCode.It ? "Radunando gli avventurieri..." : "Gathering the adventurers...";

		public static string NoClassesFound(LanguageCode lang) =>
			lang == LanguageCode.It ? "Nessuna classe corrisponde ai filtri." : "No classes match the filters.";

		public static string LabelSearchClass(LanguageCode lang) => lang == LanguageCode.It ? "Cerca classe" : "Search class";
		public static string PlaceholderSearchClasses(LanguageCode lang) => lang == LanguageCode.It ? "Es. Mago, Berserker..." : "e.g. Wizard, Berserker...";
		public static string LabelSpellcasting(LanguageCode lang) => lang == LanguageCode.It ? "Incantesimi" : "Spellcasting";
		public static string LabelSpellcastingAbility(LanguageCode lang) => lang == LanguageCode.It ? "Caratteristica da incantatore" : "Spellcasting ability";
		public static string FilterAllCasters(LanguageCode lang) => lang == LanguageCode.It ? "Tutte" : "All";
		public static string ClassCount(int count, LanguageCode lang) => lang == LanguageCode.It
			? (count == 1 ? "1 classe" : $"{count} classi")
			: (count == 1 ? "1 class" : $"{count} classes");
		public static string SubclassCount(int count, LanguageCode lang) => lang == LanguageCode.It
			? (count == 1 ? "1 sottoclasse" : $"{count} sottoclassi")
			: (count == 1 ? "1 subclass" : $"{count} subclasses");

		public static string LabelHitDie(LanguageCode lang) => lang == LanguageCode.It ? "Dado Vita" : "Hit Die";
		public static string FormatHitDie(int hitDie, LanguageCode lang) => lang == LanguageCode.It ? $"d{hitDie} per livello" : $"d{hitDie} per level";
		public static string LabelHitPoints(LanguageCode lang) => lang == LanguageCode.It ? "Punti ferita" : "Hit points";

		//	1st level: max die + Con; later levels: average (rounded up) or a roll
		public static string FormatHitPoints(int hitDie, LanguageCode lang) => lang == LanguageCode.It
			? $"{hitDie} + mod. Costituzione al 1° livello; poi 1d{hitDie} (o {hitDie / 2 + 1}) + mod. Costituzione per livello"
			: $"{hitDie} + Con modifier at 1st level; then 1d{hitDie} (or {hitDie / 2 + 1}) + Con modifier per level";

		public static string LabelPrimaryAbility(LanguageCode lang) => lang == LanguageCode.It ? "Caratteristica primaria" : "Primary ability";
		public static string LabelSaves(LanguageCode lang) => lang == LanguageCode.It ? "Tiri salvezza" : "Saving throws";
		public static string LabelSkills(LanguageCode lang) => lang == LanguageCode.It ? "Abilità" : "Skills";
		public static string AnySkills(LanguageCode lang) => lang == LanguageCode.It ? "qualsiasi abilità" : "any skills";
		public static string FormatSkillChoice(int count, string options, LanguageCode lang) => lang == LanguageCode.It
			? $"{count} a scelta tra {options}"
			: $"Choose {count} from {options}";
		public static string LabelArmor(LanguageCode lang) => lang == LanguageCode.It ? "Armature" : "Armor";
		public static string LabelWeapons(LanguageCode lang) => lang == LanguageCode.It ? "Armi" : "Weapons";
		public static string LabelTools(LanguageCode lang) => lang == LanguageCode.It ? "Strumenti" : "Tools";
		public static string LabelStartingEquipment(LanguageCode lang) => lang == LanguageCode.It ? "Equipaggiamento iniziale" : "Starting equipment";
		public static string LabelSubclass(LanguageCode lang) => lang == LanguageCode.It ? "Sottoclasse" : "Subclass";
		public static string LabelSubclasses(LanguageCode lang) => lang == LanguageCode.It ? "Sottoclassi" : "Subclasses";
		public static string LabelSubclassesShort(LanguageCode lang) => lang == LanguageCode.It ? "Sottoclassi" : "Subclasses";
		public static string LabelSubclassTitle(LanguageCode lang) => lang == LanguageCode.It ? "Nome delle sottoclassi" : "Subclass family name";
		public static string LabelSubclassLevel(LanguageCode lang) => lang == LanguageCode.It ? "Sottoclasse al" : "Subclass at";
		public static string LabelSkillCount(LanguageCode lang) => lang == LanguageCode.It ? "Abilità a scelta" : "Skills to choose";
		public static string LabelSkillOptions(LanguageCode lang) => lang == LanguageCode.It ? "Abilità tra cui scegliere (nessuna = tutte)" : "Skill options (none = any)";
		public static string LabelProgressionTable(LanguageCode lang) => lang == LanguageCode.It ? "Tabella di progressione (Markdown)" : "Progression table (Markdown)";
		public static string LabelParentClass(LanguageCode lang) => lang == LanguageCode.It ? "Classe" : "Class";
		public static string LabelLevel(LanguageCode lang) => lang == LanguageCode.It ? "Livello" : "Level";
		public static string FormatClassLevel(int level, LanguageCode lang) => lang == LanguageCode.It ? $"{level}° livello" : $"Level {level}";
		public static string FormatClassLevelShort(int level, LanguageCode lang) => lang == LanguageCode.It ? $"{level}°" : $"Lv {level}";

		public static string TabClassOverview(LanguageCode lang) => lang == LanguageCode.It ? "Panoramica" : "Overview";
		public static string TabClassTable(LanguageCode lang) => lang == LanguageCode.It ? "Tabella" : "Table";
		public static string TabClassFeatures(LanguageCode lang) => lang == LanguageCode.It ? "Privilegi" : "Features";
		public static string NoProgressionTable(LanguageCode lang) => lang == LanguageCode.It ? "Nessuna tabella di progressione." : "No progression table.";
		public static string NoSubclasses(LanguageCode lang) => lang == LanguageCode.It ? "Nessuna sottoclasse disponibile." : "No subclasses available.";

		public static string LabelClassFeatures(LanguageCode lang) => lang == LanguageCode.It ? "Privilegi" : "Features";
		public static string BtnAddFeature(LanguageCode lang) => lang == LanguageCode.It ? "+ Privilegio" : "+ Feature";
		public static string NoFeaturesYet(LanguageCode lang) => lang == LanguageCode.It ? "Nessun privilegio." : "No features.";
		public static string MoveUp(LanguageCode lang) => lang == LanguageCode.It ? "Sposta su" : "Move up";
		public static string MoveDown(LanguageCode lang) => lang == LanguageCode.It ? "Sposta giù" : "Move down";
		public static string PlaceholderFeatureNameIt(LanguageCode lang) => lang == LanguageCode.It ? "Nome (italiano)" : "Name (Italian)";
		public static string PlaceholderFeatureNameEn(LanguageCode lang) => lang == LanguageCode.It ? "Nome (inglese)" : "Name (English)";

		public static string BtnAddClass(LanguageCode lang) => lang == LanguageCode.It ? "+ NUOVA CLASSE" : "+ ADD CLASS";
		public static string BtnAddSubclass(LanguageCode lang) => lang == LanguageCode.It ? "+ NUOVA SOTTOCLASSE" : "+ ADD SUBCLASS";
		public static string BtnSaveClass(LanguageCode lang) => lang == LanguageCode.It ? "SALVA CLASSE" : "SAVE CLASS";
		public static string BtnSaveSubclass(LanguageCode lang) => lang == LanguageCode.It ? "SALVA SOTTOCLASSE" : "SAVE SUBCLASS";
		public static string ModalTitleAddClass(LanguageCode lang) => lang == LanguageCode.It ? "FORGIA NUOVA CLASSE" : "FORGE NEW CLASS";
		public static string ModalTitleAddSubclass(LanguageCode lang) => lang == LanguageCode.It ? "FORGIA NUOVA SOTTOCLASSE" : "FORGE NEW SUBCLASS";
		public static string ErrFeatureNames(LanguageCode lang) => lang == LanguageCode.It
			? "Ogni privilegio deve avere un nome in italiano e in inglese."
			: "Every feature needs a name in Italian and in English.";
		public static string ErrDeleteClass(LanguageCode lang) => lang == LanguageCode.It ? "Errore durante l'eliminazione." : "Failed to delete.";
		public static string DeleteClassWarning(LanguageCode lang, string name, bool isSubclass) => (lang == LanguageCode.It, isSubclass) switch
		{
			(true, true) => $"Vuoi eliminare definitivamente la sottoclasse \"{name}\" e i suoi privilegi? L'operazione non può essere annullata.",
			(true, false) => $"Vuoi eliminare definitivamente la classe \"{name}\", con i suoi privilegi e le sue sottoclassi? L'operazione non può essere annullata.",
			(false, true) => $"Do you want to permanently delete the subclass \"{name}\" and its features? This cannot be undone.",
			_ => $"Do you want to permanently delete the class \"{name}\", with its features and subclasses? This cannot be undone."
		};
		#endregion

		#region Rules Glossary
		public static string RulesTitle(LanguageCode lang) => lang == LanguageCode.It ? "Glossario delle regole" : "Rules Glossary";
		public static string NavRules(LanguageCode lang) => lang == LanguageCode.It ? "Glossario" : "Glossary";

		public static string RulesSubtitle(LanguageCode lang) =>
			lang == LanguageCode.It
				? "Condizioni, azioni, aree di effetto e termini di gioco. Nei testi del compendio i termini sottolineati rimandano qui."
				: "Conditions, actions, areas of effect and game terms. Underlined terms in the compendium texts lead here.";

		public static string LoadingRules(LanguageCode lang) => lang == LanguageCode.It ? "Consultazione del glossario..." : "Opening the glossary...";

		public static string NoRulesFound(LanguageCode lang) =>
			lang == LanguageCode.It ? "Nessun termine corrisponde ai filtri." : "No terms match the filters.";

		public static string LabelSearchRules(LanguageCode lang) => lang == LanguageCode.It ? "Cerca un termine" : "Search a term";
		public static string PlaceholderSearchRules(LanguageCode lang) => lang == LanguageCode.It ? "Es. prono, azione bonus, copertura..." : "e.g. prone, bonus action, cover...";
		public static string LabelRuleCategory(LanguageCode lang) => lang == LanguageCode.It ? "Tipo di termine" : "Kind of term";
		public static string FilterAllRuleCategories(LanguageCode lang) => lang == LanguageCode.It ? "Tutti i termini" : "All terms";
		public static string SectionSeeAlso(LanguageCode lang) => lang == LanguageCode.It ? "Vedi anche" : "See also";
		public static string RulesCount(int count, LanguageCode lang) => lang == LanguageCode.It
			? (count == 1 ? "1 termine" : $"{count} termini")
			: (count == 1 ? "1 term" : $"{count} terms");

		//	Tag of an entry, as in "Prono [Condizione]"
		public static string RuleCategoryName(RuleCategory category, LanguageCode lang) => (category, lang) switch
		{
			(RuleCategory.Condition, LanguageCode.It) => "Condizione",
			(RuleCategory.Action, LanguageCode.It) => "Azione",
			(RuleCategory.AreaOfEffect, LanguageCode.It) => "Area di effetto",
			(RuleCategory.Attitude, LanguageCode.It) => "Atteggiamento",
			(RuleCategory.Hazard, LanguageCode.It) => "Pericolo",
			(RuleCategory.Rule, LanguageCode.It) => "Regola",
			(RuleCategory.AreaOfEffect, _) => "Area of Effect",
			_ => category.ToString()
		};

		//	Heading of a group of entries
		public static string RuleCategoryGroup(RuleCategory category, LanguageCode lang) => (category, lang) switch
		{
			(RuleCategory.Condition, LanguageCode.It) => "Condizioni",
			(RuleCategory.Action, LanguageCode.It) => "Azioni",
			(RuleCategory.AreaOfEffect, LanguageCode.It) => "Aree di effetto",
			(RuleCategory.Attitude, LanguageCode.It) => "Atteggiamenti",
			(RuleCategory.Hazard, LanguageCode.It) => "Pericoli",
			(RuleCategory.Rule, LanguageCode.It) => "Regole e termini di gioco",
			(RuleCategory.Condition, _) => "Conditions",
			(RuleCategory.Action, _) => "Actions",
			(RuleCategory.AreaOfEffect, _) => "Areas of Effect",
			(RuleCategory.Attitude, _) => "Attitudes",
			(RuleCategory.Hazard, _) => "Hazards",
			_ => "Rules and Game Terms"
		};
		#endregion

		#region Species Compendium
		public static string SpeciesTitle(LanguageCode lang) => lang == LanguageCode.It ? "Specie" : "Species";

		public static string SpeciesSubtitle(LanguageCode lang) =>
			lang == LanguageCode.It
				? "Archivio delle specie registrate per le tue sessioni"
				: "Archive of registered species for your tabletop sessions";

		public static string LoadingArchives(LanguageCode lang) =>
			lang == LanguageCode.It ? "Consultazione degli archivi..." : "Consulting the archives...";

		public static string LabelSearchSpecies(LanguageCode lang) => lang == LanguageCode.It ? "Cerca specie" : "Search species";
		public static string PlaceholderSearchSpecies(LanguageCode lang) => lang == LanguageCode.It ? "Es. Elfo, Nano..." : "e.g. Elf, Dwarf...";
		public static string NoSpeciesMatch(LanguageCode lang) => lang == LanguageCode.It
			? "Nessuna specie corrisponde alla ricerca."
			: "No species match your search.";
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