using RealmForge.Shared.Enums;

namespace RealmForge.Client.Localization
{
	///	<summary>
	///	Texts of the NPC registry and of the NPC dossier.
	///	</summary>
	public static partial class UiText
	{
		//	Menu, dashboard and search use the short name; the page is the registry
		public static string NpcsTitle(LanguageCode lang) => T(lang, "PNG", "NPCs");
		public static string NpcsRegistry(LanguageCode lang) => T(lang, "Registro dei PNG", "NPC registry");
		public static string NpcsSubtitle(LanguageCode lang) => T(lang,
			"I volti delle tue campagne e le creazioni della community, costruiti sugli statblock dei mostri",
			"The faces of your campaigns and the community's creations, built on the monster statblocks");
		public static string NpcImprovise(LanguageCode lang) => T(lang, "Improvvisa PNG", "Improvise NPC");
		public static string NpcImproviseHint(LanguageCode lang) => T(lang,
			"Nome, mestiere, atteggiamento e spunto casuali su uno statblock adatto: per improvvisare al tavolo",
			"Random name, trade, attitude and hook on a fitting statblock: to improvise at the table");
		public static string NpcForge(LanguageCode lang) => T(lang, "+ Forgia un PNG", "+ Forge an NPC");
		public static string LoadingNpcs(LanguageCode lang) => T(lang, "Caricamento PNG...", "Loading NPCs...");
		public static string NoNpcsFound(LanguageCode lang) => T(lang, "Nessun PNG corrisponde ai filtri.", "No NPCs match the filters.");

		//	Libraries
		public static string NpcLibraryAll(LanguageCode lang) => T(lang, "Tutti", "All");
		public static string NpcLibraryMine(LanguageCode lang) => T(lang, "Il mio cast", "My cast");
		public static string NpcLibraryCommunity(LanguageCode lang) => T(lang, "Community", "Community");

		//	Filters
		public static string PlaceholderSearchNpcs(LanguageCode lang) => T(lang, "Cerca per nome, mestiere, luogo o campagna...", "Search by name, trade, place or campaign...");
		public static string NpcCampaignAll(LanguageCode lang) => T(lang, "Tutte le campagne", "All campaigns");
		public static string NpcCampaignNone(LanguageCode lang) => T(lang, "Non assegnati", "Not assigned");
		public static string NpcChallengeAny(LanguageCode lang) => T(lang, "Qualsiasi GS", "Any CR");
		public static string NpcChallengeBand(int band, LanguageCode lang) => band switch
		{
			0 => T(lang, "Non combattenti (GS 0)", "Noncombatants (CR 0)"),
			1 => T(lang, "Basso (GS 1/8 – 1)", "Low (CR 1/8 – 1)"),
			2 => T(lang, "Medio (GS 2 – 4)", "Medium (CR 2 – 4)"),
			_ => T(lang, "Alto (GS 5+)", "High (CR 5+)")
		};
		public static string NpcFunctionLabel(LanguageCode lang) => T(lang, "Funzione:", "Function:");
		public static string NpcFunctionAll(LanguageCode lang) => T(lang, "Tutti i ruoli", "All roles");
		public static string FormatNpcArchetype(NpcArchetype archetype, LanguageCode lang) => archetype switch
		{
			NpcArchetype.Ally => T(lang, "Alleati e gregari", "Allies and followers"),
			NpcArchetype.Merchant => T(lang, "Mercanti, locandieri e artigiani", "Merchants, innkeepers and craftsfolk"),
			NpcArchetype.Contact => T(lang, "Informatori, nobili e contatti", "Informants, nobles and contacts"),
			NpcArchetype.Threat => T(lang, "Guardie, rivali e sicari", "Guards, rivals and assassins"),
			_ => archetype.ToString()
		};
		public static string FormatNpcAttitude(NpcAttitude attitude, LanguageCode lang) => attitude switch
		{
			NpcAttitude.Hostile => T(lang, "Ostile", "Hostile"),
			NpcAttitude.Indifferent => T(lang, "Indifferente", "Indifferent"),
			NpcAttitude.Friendly => T(lang, "Amichevole", "Friendly"),
			_ => attitude.ToString()
		};
		public static string NpcStatus(int count, RulesetVersion? edition, LanguageCode lang)
		{
			var shown = lang == LanguageCode.It ? (count == 1 ? "Mostrato 1 PNG" : $"Mostrati {count} PNG") : (count == 1 ? "1 NPC shown" : $"{count} NPCs shown");
			return edition is { } e ? $"{shown} • {T(lang, "Edizione", "Edition")} {FormatRuleset(e, lang)}" : shown;
		}

		//	Cards
		public static string NpcBadgeMine(LanguageCode lang) => T(lang, "Mio PNG", "My NPC");
		public static string NpcBadgeShared(LanguageCode lang) => T(lang, "Community", "Community");
		public static string NpcAnyAncestry(LanguageCode lang) => T(lang, "Qualsiasi specie", "Any species");
		public static string NpcCue(LanguageCode lang) => T(lang, "Spunto al tavolo:", "At the table:");
		public static string NpcNoCue(LanguageCode lang) => T(lang, "Nessuno spunto: aprilo e scrivi come parla e cosa vuole.", "No hook yet: open it and write how it talks and what it wants.");
		public static string NpcCampaign(LanguageCode lang) => T(lang, "Campagna:", "Campaign:");
		public static string NpcBasedOn(LanguageCode lang) => T(lang, "Statblock:", "Statblock:");
		public static string NpcOpenDossier(LanguageCode lang) => T(lang, "Apri dossier", "Open dossier");
		public static string NpcAddToCast(LanguageCode lang) => T(lang, "+ Aggiungi al mio cast", "+ Add to my cast");

		//	Empty cast
		public static string NpcEmptyKicker(LanguageCode lang) => T(lang, "Il tuo cast è ancora vuoto", "Your cast is still empty");
		public static string NpcEmptyTitle(LanguageCode lang) => T(lang, "Dai un volto agli abitanti del tuo mondo", "Give a face to the people of your world");
		public static string NpcEmptyText(LanguageCode lang) => T(lang,
			"Non hai ancora salvato nessun PNG. Forgiane uno con segreti, legami e statblock, oppure parti da uno statblock dei mostri qui a fianco: gli dai un nome e lo assegni alla tua campagna. Da ogni mostro puoi anche creare un PNG.",
			"You have not saved any NPC yet. Forge one with secrets, bonds and statblock, or start from one of the monster statblocks next to this: give it a name and assign it to your campaign. You can also make an NPC from any monster.");
		public static string NpcEmptyNew(LanguageCode lang) => T(lang, "+ Forgia il tuo primo PNG", "+ Forge your first NPC");
		public static string NpcEmptyRandom(LanguageCode lang) => T(lang, "Genera un PNG casuale", "Generate a random NPC");
		public static string NpcQuickLabel(LanguageCode lang) => T(lang, "Oppure crea in 5 secondi partendo da uno statblock:", "Or create one in 5 seconds from a statblock:");
		public static string NpcStarterClone(LanguageCode lang) => T(lang, "Dai un nome e salva →", "Name it and save →");
		public static string NpcStarterName(string key, LanguageCode lang) => key switch
		{
			"commoner" => T(lang, "Locandiere / Mercante (Popolano)", "Innkeeper / Merchant (Commoner)"),
			"veteran" => T(lang, "Capitano della guardia (Veterano)", "Captain of the guard (Veteran)"),
			_ => T(lang, "Informatore / Spia della gilda (Spia)", "Informant / Guild spy (Spy)")
		};
		public static string NpcStarterUse(string key, LanguageCode lang) => key switch
		{
			"commoner" => T(lang, "Ideale per negozi, taverne e contatti cittadini", "Good for shops, taverns and town contacts"),
			"veteran" => T(lang, "Ideale per alleati militari, scorte o rivali d'onore", "Good for military allies, escorts or honourable rivals"),
			_ => T(lang, "Ideale per intrighi, mercato nero e missioni furtive", "Good for intrigue, black markets and stealthy missions")
		};
		public static string NpcFromMonster(LanguageCode lang) => T(lang, "Crea PNG", "Make NPC");
		public static string NpcFromMonsterHint(LanguageCode lang) => T(lang, "Un PNG tuo con questo statblock: nome, ritratto, ruolo e segreti", "An NPC of yours with this statblock: name, portrait, role and secrets");

		//	Editor: the NPC part
		public static string NpcPortrait(LanguageCode lang) => T(lang, "Ritratto", "Portrait");
		public static string NpcPortraitPick(LanguageCode lang) => T(lang, "Scegli immagine", "Choose image");
		public static string NpcFunction(LanguageCode lang) => T(lang, "Funzione al tavolo", "Function at the table");
		public static string NpcAttitude(LanguageCode lang) => T(lang, "Atteggiamento", "Attitude");
		public static string NpcRole(LanguageCode lang) => T(lang, "Mestiere / ruolo", "Trade / role");
		public static string NpcRoleHint(LanguageCode lang) => T(lang, "Es. Locandiere, Informatore", "E.g. Innkeeper, Informant");
		public static string NpcAncestry(LanguageCode lang) => T(lang, "Specie / origine", "Species / ancestry");
		public static string NpcAncestryHint(LanguageCode lang) => T(lang, "Es. Mezzelfo, Nano delle colline", "E.g. Half-elf, Hill dwarf");
		public static string NpcLocation(LanguageCode lang) => T(lang, "Luogo", "Place");
		public static string NpcLocationHint(LanguageCode lang) => T(lang, "Es. Locanda del Cervo", "E.g. The Stag Inn");
		public static string NpcPersonality(LanguageCode lang) => T(lang, "Spunto al tavolo e personalità", "Table hook and personality");
		public static string NpcSecrets(LanguageCode lang) => T(lang, "Segreti (visibili solo a te)", "Secrets (only you see them)");
		public static string NpcCloneTitle(LanguageCode lang) => T(lang, "Aggiungi al mio cast", "Add to my cast");
		public static string NpcCloneHint(string original, LanguageCode lang) => T(lang,
			$"Basato su «{original}»: cambia nome, ritratto e segreti, lo statblock resta modificabile.",
			$"Based on “{original}”: change name, portrait and secrets, the statblock stays editable.");
		public static string NpcDeleteWarning(string name, LanguageCode lang) =>
			T(lang, $"Eliminare «{name}»? Potrai recuperarlo dal cestino per 3 giorni.", $"Delete “{name}”? You can restore it from the bin for 3 days.");

		public static string NpcAdventureRole(LanguageCode lang) => T(lang, "Ruolo nell'avventura", "Part in the adventure");
		public static string NpcTactics(LanguageCode lang) => T(lang, "Tattica in combattimento", "Combat tactics");
		public static string NpcGear(LanguageCode lang) => T(lang, "Cosa porta con sé (bottino / tasche)", "What it carries (loot / pockets)");
		public static string NpcSocial(LanguageCode lang) => T(lang, "Interazione sociale", "Social interaction");

		public static string NpcGuide(LanguageCode lang) => T(lang, "Guida tattica, ambiente e dotazione", "Tactics, setting and gear");
		public static string NpcGuideEmpty(LanguageCode lang) => T(lang,
			"Con Modifica puoi aggiungere il ruolo nell'avventura, la tattica, cosa porta con sé e come trattarci.",
			"With Edit you can add its part in the adventure, its tactics, what it carries and how to deal with it.");
		public static string NpcAbilities(LanguageCode lang) => T(lang, "Caratteristiche e competenze", "Abilities and proficiencies");
		public static string NpcSkills(LanguageCode lang) => T(lang, "Abilità competenti:", "Proficient skills:");
		public static string NpcOnItsTurn(LanguageCode lang) => T(lang, "Nel suo turno", "On its turn");
		public static string NpcToHit(LanguageCode lang) => T(lang, "Tiro per colpire", "To hit");
		public static string NpcDamage(LanguageCode lang) => T(lang, "Danni", "Damage");
		public static string NpcVitalChallenge(LanguageCode lang) => T(lang, "Grado sfida", "Challenge");
		public static string NpcVitalAc(LanguageCode lang) => T(lang, "Classe armatura", "Armor class");
		public static string NpcVitalHp(string dice, LanguageCode lang) => string.IsNullOrWhiteSpace(dice) ? T(lang, "Punti ferita", "Hit points") : T(lang, $"Punti ferita ({dice})", $"Hit points ({dice})");
		public static string NpcVitalHpHint(LanguageCode lang) => T(lang, "Solo su questo schermo, per il tavolo", "Only on this screen, for the table");
		public static string NpcVitalSpeed(LanguageCode lang) => T(lang, "Velocità", "Speed");
		public static string NpcVitalInitiative(LanguageCode lang) => T(lang, "Iniziativa", "Initiative");
		public static string NpcVitalPassive(LanguageCode lang) => T(lang, "Perc. passiva", "Passive Perc.");
		public static string NpcXpAndProficiency(int xp, int proficiency, LanguageCode lang) => T(lang, $"{xp:N0} PE • Comp. +{proficiency}", $"{xp:N0} XP • Prof. +{proficiency}");
		public static string NpcInitiativeFixed(int value, LanguageCode lang) => T(lang, $"{value} fisso", $"{value} fixed");
		public static string NpcLanguages(LanguageCode lang) => T(lang, "Linguaggi:", "Languages:");

		//	Dossier
		public static string NpcBack(LanguageCode lang) => T(lang, "Torna al registro dei PNG", "Back to the NPC registry");
		public static string NpcRoleplay(LanguageCode lang) => T(lang, "Spunto al tavolo", "At the table");
		public static string NpcSecretsTitle(LanguageCode lang) => T(lang, "Segreti", "Secrets");
		public static string NpcSecretsOnlyYou(LanguageCode lang) => T(lang, "Solo tu li vedi", "Only you see them");
		public static string NpcStatblock(LanguageCode lang) => T(lang, "Statblock", "Statblock");
		public static string NpcNoRoleplay(LanguageCode lang) => T(lang,
			"Nessuna nota: aggiungi il PNG al tuo cast per scriverne di tue.",
			"No notes: add the NPC to your cast to write your own.");
		public static string NpcCampaigns(LanguageCode lang) => T(lang, "Campagne", "Campaigns");
		public static string NpcNotFound(LanguageCode lang) => T(lang, "PNG non trovato.", "NPC not found.");
	}
}
