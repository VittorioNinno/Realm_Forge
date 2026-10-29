using RealmForge.Shared.Campaigns;
using RealmForge.Shared.Enums;

namespace RealmForge.Client.Localization
{
	///	<summary>
	///	Texts of the campaigns: list, invitations, the campaign page (members, characters, shared content) and the link.
	///	</summary>
	public static partial class UiText
	{
		public static string CampaignsTitle(LanguageCode lang) => T(lang, "Campagne", "Campaigns");
		public static string CampaignsSubtitle(LanguageCode lang) => T(lang, "Il tavolo, i personaggi e i contenuti condivisi", "The table, the characters and the shared content");
		public static string CampaignsSignIn(LanguageCode lang) => T(lang, "Accedi per creare una campagna o unirti a un tavolo.", "Sign in to create a campaign or join a table.");
		public static string CampaignsEmpty(LanguageCode lang) => T(lang, "Non partecipi ancora a nessuna campagna: creane una o usa il link che ti ha mandato il master.",
			"You are not in any campaign yet: create one or use the link your game master sent you.");
		public static string LoadingCampaigns(LanguageCode lang) => T(lang, "Caricamento campagne...", "Loading campaigns...");
		public static string BtnNewCampaign(LanguageCode lang) => T(lang, "Nuova campagna", "New campaign");
		public static string BtnCreateCampaign(LanguageCode lang) => T(lang, "Crea campagna", "Create campaign");
		public static string CampaignName(LanguageCode lang) => T(lang, "Nome", "Name");
		public static string CampaignDescription(LanguageCode lang) => T(lang, "Descrizione", "Description");
		public static string CampaignDescriptionHint(LanguageCode lang) => T(lang, "La premessa, le regole della casa, il prossimo incontro… (Markdown)", "The premise, the house rules, the next session… (Markdown)");
		public static string CampaignEdition(LanguageCode lang) => T(lang, "Edizione", "Edition");
		public static string CampaignAnyEdition(LanguageCode lang) => T(lang, "Qualsiasi edizione", "Any edition");
		public static string CampaignNameMissing(LanguageCode lang) => T(lang, "Dai un nome alla campagna.", "Give the campaign a name.");
		public static string CampaignMembersCount(int count, LanguageCode lang) => lang == LanguageCode.It
			? (count == 1 ? "1 persona" : $"{count} persone")
			: (count == 1 ? "1 person" : $"{count} people");
		public static string CampaignCharactersCount(int count, LanguageCode lang) => lang == LanguageCode.It
			? (count == 1 ? "1 personaggio" : $"{count} personaggi")
			: (count == 1 ? "1 character" : $"{count} characters");
		public static string CampaignPendingCount(int count, LanguageCode lang) => lang == LanguageCode.It
			? (count == 1 ? "1 contenuto da approvare" : $"{count} contenuti da approvare")
			: (count == 1 ? "1 entry to approve" : $"{count} entries to approve");

		public static string CampaignRoleName(CampaignRole role, LanguageCode lang) => (role, lang == LanguageCode.It) switch
		{
			(CampaignRole.Master, true) => "Master",
			(CampaignRole.CoMaster, true) => "Co-master",
			(CampaignRole.Player, true) => "Giocatore",
			(CampaignRole.Master, false) => "Game master",
			(CampaignRole.CoMaster, false) => "Co-GM",
			_ => "Player"
		};

		public static string CampaignRoleHint(CampaignRole role, LanguageCode lang) => role switch
		{
			CampaignRole.Master => T(lang, "Autorità assoluta: nomina co-master e master, gestisce le persone e tutti i contenuti, modifica i personaggi.",
				"Absolute authority: names co-GMs and GMs, manages people and all content, edits the characters."),
			CampaignRole.CoMaster => T(lang, "Aiuta il master: invita giocatori, approva e rimuove contenuti (non quelli dei master), modifica i personaggi.",
				"Helps the GM: invites players, approves and removes content (not the GMs'), edits the characters."),
			_ => T(lang, "Porta i suoi personaggi e propone contenuti, che un master o co-master approva.",
				"Brings their characters and offers content, which a GM or co-GM approves.")
		};

		//	Invitations
		public static string CampaignInvitationsTitle(LanguageCode lang) => T(lang, "Inviti ricevuti", "Invitations");
		public static string CampaignInvitedAs(CampaignRole role, string by, LanguageCode lang) =>
			T(lang, $"Invito come {CampaignRoleName(role, lang).ToLowerInvariant()} da {by}", $"Invited as {CampaignRoleName(role, lang).ToLowerInvariant()} by {by}");
		public static string BtnAccept(LanguageCode lang) => T(lang, "Accetta", "Accept");
		public static string BtnDecline(LanguageCode lang) => T(lang, "Rifiuta", "Decline");
		public static string BtnJoinWithLink(LanguageCode lang) => T(lang, "Unisciti con un link", "Join with a link");
		public static string CampaignJoinPlaceholder(LanguageCode lang) => T(lang, "Incolla il link o il codice", "Paste the link or the code");
		public static string BtnJoin(LanguageCode lang) => T(lang, "Unisciti", "Join");

		//	Campaign page
		public static string CampaignTabOverview(LanguageCode lang) => T(lang, "Panoramica", "Overview");
		public static string CampaignTabMembers(LanguageCode lang) => T(lang, "Persone", "People");
		public static string CampaignTabCharacters(LanguageCode lang) => T(lang, "Personaggi", "Characters");
		public static string CampaignTabContent(LanguageCode lang) => T(lang, "Contenuti", "Content");
		public static string CampaignYourRole(CampaignRole role, LanguageCode lang) => T(lang, $"Il tuo ruolo: {CampaignRoleName(role, lang)}", $"Your role: {CampaignRoleName(role, lang)}");
		public static string CampaignNoDescription(LanguageCode lang) => T(lang, "Nessuna descrizione.", "No description.");
		public static string CampaignNotFound(LanguageCode lang) => T(lang, "Campagna non trovata, o non ne fai parte.", "Campaign not found, or you are not part of it.");
		public static string BtnEditCampaign(LanguageCode lang) => T(lang, "Modifica", "Edit");
		public static string BtnDeleteCampaign(LanguageCode lang) => T(lang, "Elimina campagna", "Delete campaign");
		public static string CampaignDeleteWarning(string name, LanguageCode lang) =>
			T(lang, $"Eliminare \"{name}\"? I personaggi e i contenuti restano ai loro proprietari.", $"Delete \"{name}\"? Characters and content stay with their owners.");
		public static string BtnLeaveCampaign(LanguageCode lang) => T(lang, "Lascia la campagna", "Leave the campaign");
		public static string CampaignLeaveWarning(LanguageCode lang) =>
			T(lang, "Lasciare la campagna? I tuoi personaggi ne escono e le tue proposte in attesa vengono ritirate.", "Leave the campaign? Your characters leave it and your pending entries are withdrawn.");
		public static string CampaignLastMaster(LanguageCode lang) => T(lang, "Sei l'unico master: nomina prima un altro master.", "You are the only GM: name another GM first.");

		//	Invite link
		public static string CampaignLinkTitle(LanguageCode lang) => T(lang, "Link di invito", "Invite link");
		public static string CampaignLinkHint(LanguageCode lang) => T(lang, "Chi apre il link entra come giocatore.", "Whoever opens the link joins as a player.");
		public static string CampaignLinkDisabled(LanguageCode lang) => T(lang, "Link disattivato: si entra solo su invito.", "Link disabled: people join only by invitation.");
		public static string BtnNewLink(LanguageCode lang) => T(lang, "Nuovo link", "New link");
		public static string BtnDisableLink(LanguageCode lang) => T(lang, "Disattiva", "Disable");
		public static string BtnEnableLink(LanguageCode lang) => T(lang, "Attiva il link", "Enable the link");

		//	People
		public static string CampaignInviteTitle(LanguageCode lang) => T(lang, "Invita per e-mail", "Invite by e-mail");
		public static string CampaignInviteRole(LanguageCode lang) => T(lang, "Come", "As");
		public static string BtnInvite(LanguageCode lang) => T(lang, "Invita", "Invite");
		public static string CampaignInviteSent(string email, LanguageCode lang) => T(lang, $"Invito inviato a {email}: lo troverà nelle sue campagne.", $"Invitation sent to {email}: they will find it among their campaigns.");
		public static string CampaignInviteMember(LanguageCode lang) => T(lang, "Questa persona fa già parte della campagna.", "This person is already in the campaign.");
		public static string CampaignPendingInvites(LanguageCode lang) => T(lang, "Inviti in attesa", "Pending invitations");
		public static string BtnWithdraw(LanguageCode lang) => T(lang, "Ritira", "Withdraw");
		public static string CampaignYou(LanguageCode lang) => T(lang, "tu", "you");
		public static string CampaignChangeRole(LanguageCode lang) => T(lang, "Ruolo", "Role");

		//	Characters
		public static string CampaignCharactersEmpty(LanguageCode lang) => T(lang, "Nessun personaggio al tavolo.", "No characters at the table yet.");
		public static string CampaignAddCharacter(LanguageCode lang) => T(lang, "Porta un tuo personaggio", "Bring one of your characters");
		public static string CampaignNoCharacterToAdd(LanguageCode lang) => T(lang, "Non hai personaggi da portare (di questa edizione).", "You have no characters to bring (of this edition).");
		public static string BtnBring(LanguageCode lang) => T(lang, "Porta", "Bring");
		public static string BtnOpenSheet(LanguageCode lang) => T(lang, "Apri scheda", "Open sheet");
		public static string BtnEditAsMaster(LanguageCode lang) => T(lang, "Modifica scheda", "Edit sheet");
		public static string BtnTakeOut(LanguageCode lang) => T(lang, "Togli dalla campagna", "Take out of the campaign");
		public static string BtnTakeOutShort(LanguageCode lang) => T(lang, "Togli", "Take out");
		public static string CampaignPlayedBy(string email, LanguageCode lang) => T(lang, $"di {email}", $"by {email}");

		//	Content
		public static string CampaignContentApproved(LanguageCode lang) => T(lang, "Condivisi con il tavolo", "Shared with the table");
		public static string CampaignContentPending(LanguageCode lang) => T(lang, "In attesa di approvazione", "Waiting for approval");
		public static string CampaignContentEmpty(LanguageCode lang) => T(lang, "Nessun contenuto condiviso.", "No shared content yet.");
		public static string CampaignContentHint(RulesetVersion? ruleset, LanguageCode lang) =>
			T(lang, "I contenuti approvati compaiono a tutti nel compendio e nella creazione dei personaggi.", "Approved content shows up for everyone in the compendium and in character creation.");
		public static string CampaignShareTitle(LanguageCode lang) => T(lang, "Condividi un tuo contenuto Homebrew", "Share one of your Homebrew entries");
		public static string CampaignShareHintPlayer(LanguageCode lang) => T(lang, "Un master o un co-master deve approvarlo.", "A GM or co-GM must approve it.");
		public static string CampaignShareHintMaster(LanguageCode lang) => T(lang, "Visibile subito a tutto il tavolo.", "Visible to the whole table right away.");
		public static string CampaignNothingToShare(LanguageCode lang) => T(lang, "Non hai contenuti Homebrew da condividere.", "You have no Homebrew to share.");
		public static string BtnShareWithTable(LanguageCode lang) => T(lang, "Condividi", "Share");
		public static string BtnApprove(LanguageCode lang) => T(lang, "Approva", "Approve");
		public static string CampaignSharedBy(string email, CampaignRole? role, LanguageCode lang) =>
			role is { } r ? T(lang, $"da {email} ({CampaignRoleName(r, lang).ToLowerInvariant()})", $"by {email} ({CampaignRoleName(r, lang).ToLowerInvariant()})") : T(lang, $"da {email}", $"by {email}");
		public static string CampaignKindName(string kind, LanguageCode lang) => (kind, lang == LanguageCode.It) switch
		{
			("species", true) => "Specie",
			("subspecies", true) => "Sottospecie",
			("class", true) => "Classe",
			("subclass", true) => "Sottoclasse",
			("background", true) => "Background",
			("feat", true) => "Talento",
			("spell", true) => "Incantesimo",
			("equipment", true) => "Equipaggiamento",
			("monster", true) => "Mostro",
			("species", false) => "Species",
			("subspecies", false) => "Subspecies",
			("class", false) => "Class",
			("subclass", false) => "Subclass",
			("background", false) => "Background",
			("feat", false) => "Feat",
			("spell", false) => "Spell",
			("equipment", false) => "Equipment",
			("monster", false) => "Monster",
			_ => kind
		};

		public static string CampaignActionFailed(System.Net.HttpStatusCode? status, LanguageCode lang) => status switch
		{
			System.Net.HttpStatusCode.Forbidden => T(lang, "Il tuo ruolo non lo permette.", "Your role does not allow it."),
			System.Net.HttpStatusCode.NotFound => T(lang, "Non trovato: aggiorna la pagina.", "Not found: refresh the page."),
			System.Net.HttpStatusCode.Conflict => T(lang, "Già fatto.", "Already done."),
			System.Net.HttpStatusCode.BadRequest => T(lang, "Non è possibile: controlla i limiti (edizione, numero di persone, ultimo master).", "Not possible: check the limits (edition, number of people, last GM)."),
			_ => T(lang, "Qualcosa è andato storto. Riprova.", "Something went wrong. Try again.")
		};

		//	Join page
		public static string CampaignJoinTitle(LanguageCode lang) => T(lang, "Invito a una campagna", "Campaign invitation");
		public static string CampaignJoinInvalid(LanguageCode lang) => T(lang, "Il link non è valido o è stato disattivato.", "The link is not valid or was disabled.");
		public static string CampaignJoinAlready(LanguageCode lang) => T(lang, "Fai già parte di questa campagna.", "You are already part of this campaign.");
		public static string CampaignJoinAs(LanguageCode lang) => T(lang, "Entrerai come giocatore.", "You will join as a player.");
		public static string BtnGoToCampaign(LanguageCode lang) => T(lang, "Vai alla campagna", "Go to the campaign");

		//	Requirements of the campaign for a character
		public static string CampaignCheckTitle(LanguageCode lang) => T(lang, "Il personaggio non può unirsi a questa campagna:", "The character cannot join this campaign:");
		public static string CampaignIssueText(RealmForge.Shared.DTOs.CampaignCheckIssueDto issue, RulesetVersion? campaignRuleset, LanguageCode lang)
		{
			var what = issue.Kind is { } kind ? $"{CampaignKindName(kind, lang)} «{issue.Name}»" : string.Empty;
			return issue.Issue switch
			{
				CampaignCheckIssue.Edition => T(lang,
					$"è un personaggio {(issue.Ruleset is { } r ? FormatRuleset(r, lang) : "?")}, la campagna usa {(campaignRuleset is { } c ? FormatRuleset(c, lang) : "?")}.",
					$"it is a {(issue.Ruleset is { } r2 ? FormatRuleset(r2, lang) : "?")} character, the campaign uses {(campaignRuleset is { } c2 ? FormatRuleset(c2, lang) : "?")}."),
				CampaignCheckIssue.HomebrewNotShared => T(lang,
					$"{what} è un tuo contenuto Homebrew non ancora condiviso con la campagna (o in attesa di approvazione): condividilo dalla sezione Contenuti.",
					$"{what} is your Homebrew, not yet shared with the campaign (or waiting for approval): share it from the Content tab."),
				CampaignCheckIssue.HomebrewUnavailable => T(lang,
					$"{what} è un contenuto Homebrew di un altro autore che il tavolo non può vedere.",
					$"{what} is someone else's Homebrew the table cannot see."),
				_ => T(lang,
					$"{what} è un contenuto Homebrew di un'altra edizione ({(issue.Ruleset is { } e ? FormatRuleset(e, lang) : "?")}).",
					$"{what} is Homebrew of another edition ({(issue.Ruleset is { } e2 ? FormatRuleset(e2, lang) : "?")}).")
			};
		}
		public static string PortraitCropTitle(LanguageCode lang) => T(lang, "Inquadra il ritratto", "Frame the portrait");
		public static string PortraitCropHint(LanguageCode lang) => T(lang, "Trascina l'immagine (o usa le frecce) per centrarla nel riquadro e lo zoom per avvicinarla.", "Drag the picture (or use the arrows) to centre it in the frame, and the zoom to bring it closer.");
		public static string PortraitZoom(LanguageCode lang) => T(lang, "Zoom", "Zoom");
		public static string BtnPortraitChange(LanguageCode lang) => T(lang, "Cambia ritratto", "Change portrait");
		public static string BtnCampaign(LanguageCode lang) => T(lang, "Campagna", "Campaign");
		public static string SheetCampaignTitle(LanguageCode lang) => T(lang, "Porta il personaggio in una campagna", "Bring the character to a campaign");
		public static string SheetCampaignNone(LanguageCode lang) => T(lang, "Non partecipi a nessuna campagna.", "You are not in any campaign.");
		public static string SheetCampaignJoined(string name, LanguageCode lang) => T(lang, $"Il personaggio siede ora al tavolo di «{name}».", $"The character now sits at the table of “{name}”.");
		public static string SheetCampaignAlready(LanguageCode lang) => T(lang, "Già al tavolo", "Already at the table");
		public static string SheetCampaignLeft(string name, LanguageCode lang) => T(lang, $"Il personaggio ha lasciato il tavolo di «{name}».", $"The character left the table of “{name}”.");

		//	Notes
		public static string CampaignTabNotes(LanguageCode lang) => T(lang, "Note", "Notes");
		public static string CampaignNoteKindName(CampaignNoteKind kind, LanguageCode lang) => (kind, lang == LanguageCode.It) switch
		{
			(CampaignNoteKind.Private, true) => "Personali",
			(CampaignNoteKind.Masters, true) => "Per i master",
			(CampaignNoteKind.Journal, true) => "Diario di viaggio",
			(CampaignNoteKind.Private, false) => "Private",
			(CampaignNoteKind.Masters, false) => "For the GMs",
			_ => "Travel journal"
		};
		public static string CampaignNoteKindHint(CampaignNoteKind kind, LanguageCode lang) => kind switch
		{
			CampaignNoteKind.Private => T(lang, "Solo tu le vedi.", "Only you see them."),
			CampaignNoteKind.Masters => T(lang, "Le vedono e le scrivono solo master e co-master.", "Only GMs and co-GMs see and write them."),
			_ => T(lang, "Il diario del gruppo: tutti leggono e scrivono.", "The party's journal: everyone reads and writes.")
		};
		public static string CampaignNotesEmpty(LanguageCode lang) => T(lang, "Ancora nessuna nota.", "No notes yet.");
		public static string BtnNewNote(LanguageCode lang) => T(lang, "Nuova nota", "New note");
		public static string CampaignNoteTitle(LanguageCode lang) => T(lang, "Titolo", "Title");
		public static string CampaignNoteBody(LanguageCode lang) => T(lang, "Testo (Markdown)", "Text (Markdown)");
		public static string CampaignNoteEdited(LanguageCode lang) => T(lang, "modificata", "edited");
		public static string CampaignNoteEmpty(LanguageCode lang) => T(lang, "Scrivi un titolo o un testo.", "Write a title or a text.");

		//	Nickname
		public static string NicknameTitle(LanguageCode lang) => T(lang, "Nickname", "Nickname");
		public static string NicknameHint(LanguageCode lang) => T(lang, "Il nome con cui ti vedono gli altri giocatori, al posto dell'e-mail. È unico: nessun altro può usarlo.",
			"The name other players see instead of your e-mail. It is unique: nobody else can use it.");
		public static string NicknamePlaceholder(LanguageCode lang) => T(lang, "Es. Sylas il Bardo", "E.g. Sylas the Bard");
		public static string BtnSaveNickname(LanguageCode lang) => T(lang, "Salva", "Save");
		public static string NicknameSaved(string name, LanguageCode lang) => T(lang, $"Ora gli altri ti vedono come {name}.", $"Others now see you as {name}.");
		public static string NicknameRemoved(LanguageCode lang) => T(lang, "Nickname rimosso: gli altri vedono solo le prime lettere della tua e-mail.", "Nickname removed: others see only the first letters of your e-mail.");
		public static string NicknameTaken(LanguageCode lang) => T(lang, "Questo nickname è già usato da un altro account.", "This nickname is already used by another account.");
		public static string NicknameInvalid(LanguageCode lang) => T(lang, "Da 3 a 24 caratteri: lettere, numeri, spazi, punti, trattini o trattini bassi.", "3 to 24 characters: letters, digits, spaces, dots, dashes or underscores.");
		public static string NicknameMissingHint(LanguageCode lang) => T(lang, "Scegli un nickname nel tuo account: al tavolo gli altri vedranno quello, non la tua e-mail.",
			"Choose a nickname in your account: at the table the others will see it, not your e-mail.");

		//	Sheet opened by a master
		public static string SheetEditingAsMaster(string owner, LanguageCode lang) =>
			T(lang, $"Stai modificando il personaggio di {owner} come master: le modifiche valgono per il personaggio stesso.",
				$"You are editing {owner}'s character as GM: changes apply to the character itself.");
		public static string SheetLastEditedBy(string email, LanguageCode lang) => T(lang, $"Ultima modifica di {email}", $"Last changed by {email}");
	}
}
