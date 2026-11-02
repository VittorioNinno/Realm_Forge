using RealmForge.Shared.Enums;

namespace RealmForge.Client.Localization
{
	///	<summary>
	///	Texts of the NPC page and of the NPC sheet.
	///	</summary>
	public static partial class UiText
	{
		public static string NpcsTitle(LanguageCode lang) => T(lang, "PNG", "NPCs");
		public static string NpcsSubtitle(LanguageCode lang) => T(lang,
			"I personaggi non giocanti delle tue campagne: statblock, tratti interpretativi, ritratti e creazioni condivise",
			"The nonplayer characters of your campaigns: statblock, roleplay traits, portraits and shared creations");
		public static string BtnNewNpc(LanguageCode lang) => T(lang, "+ Nuovo PNG", "+ New NPC");
		public static string LabelSearchNpc(LanguageCode lang) => T(lang, "Cerca PNG", "Search NPCs");
		public static string PlaceholderSearchNpcs(LanguageCode lang) => T(lang, "Es. Vaelen, Guardia, Locandiere...", "E.g. Vaelen, Guard, Innkeeper...");
		public static string LabelNpcArchetype(LanguageCode lang) => T(lang, "Ruolo / archetipo", "Role / archetype");
		public static string NoNpcsFound(LanguageCode lang) => T(lang, "Nessun PNG corrisponde ai filtri.", "No NPCs match the filters.");
		public static string LoadingNpcs(LanguageCode lang) => T(lang, "Caricamento PNG...", "Loading NPCs...");
		public static string NpcCount(int count, LanguageCode lang) => lang == LanguageCode.It
			? count == 1 ? "1 PNG" : $"{count} PNG"
			: count == 1 ? "1 NPC" : $"{count} NPCs";

		//	Origin: the filter and the chips
		public static string NpcOriginAll(LanguageCode lang) => T(lang, "Tutte le origini", "All origins");
		public static string NpcOriginMine(LanguageCode lang) => T(lang, "Miei PNG (Homebrew)", "My NPCs (Homebrew)");
		public static string NpcOriginShared(LanguageCode lang) => T(lang, "Condivisi dalla community", "Shared by the community");
		public static string NpcChipAll(LanguageCode lang) => T(lang, "Tutti", "All");
		public static string NpcChipMine(LanguageCode lang) => T(lang, "Miei PNG", "My NPCs");
		public static string NpcChipShared(LanguageCode lang) => T(lang, "Condivisi", "Shared");
		public static string NpcBand(int band, LanguageCode lang) => band switch
		{
			0 => T(lang, "GS 0–1", "CR 0–1"),
			1 => T(lang, "GS 2–4", "CR 2–4"),
			_ => T(lang, "GS 5+", "CR 5+")
		};

		//	Badges
		public static string NpcBadgeMine(LanguageCode lang) => T(lang, "Mio PNG", "My NPC");
		public static string NpcBadgeShared(LanguageCode lang) => T(lang, "Condiviso", "Shared");

		public static string NpcArchetypeAll(LanguageCode lang) => T(lang, "Tutti i ruoli", "All roles");
		public static string FormatNpcArchetype(NpcArchetype archetype, LanguageCode lang) => archetype switch
		{
			NpcArchetype.Combatant => T(lang, "Combattente / Guardia", "Fighter / Guard"),
			NpcArchetype.Social => T(lang, "Volto sociale / Mercante", "Social face / Merchant"),
			NpcArchetype.Rogue => T(lang, "Furfante / Spia", "Rogue / Spy"),
			NpcArchetype.Caster => T(lang, "Incantatore / Cultista", "Spellcaster / Cultist"),
			NpcArchetype.Commoner => T(lang, "Popolano", "Commoner"),
			_ => archetype.ToString()
		};
		public static string NpcAnyAncestry(LanguageCode lang) => T(lang, "Qualsiasi specie", "Any species");
		public static string NpcCampaign(LanguageCode lang) => T(lang, "Campagna:", "Campaign:");
		public static string NpcXp(int xp, LanguageCode lang) => T(lang, $"{xp:N0} PE", $"{xp:N0} XP");

		//	Card actions
		public static string NpcOpenSheet(LanguageCode lang) => T(lang, "Apri scheda", "Open sheet");
		public static string NpcClone(LanguageCode lang) => T(lang, "Clona nei miei PNG", "Clone to my NPCs");
		public static string NpcSave(LanguageCode lang) => T(lang, "Salva nei miei PNG", "Save to my NPCs");

		//	Create slot
		public static string NpcForgeTitle(LanguageCode lang) => T(lang, "Forgia un nuovo PNG", "Forge a new NPC");
		public static string NpcForgeText(LanguageCode lang) => T(lang,
			"Crea un personaggio non giocante per la tua campagna, oppure parti da uno generato a caso su uno statblock dei mostri.",
			"Create a nonplayer character for your campaign, or start from a random one on a monster statblock.");
		public static string NpcCreateBlank(LanguageCode lang) => T(lang, "+ Crea da zero", "+ Create from scratch");
		public static string NpcGenerateRandom(LanguageCode lang) => T(lang, "Genera casuale", "Generate random");

		//	Empty state: no NPC of the account yet
		public static string NpcEmptyKicker(LanguageCode lang) => T(lang, "Nessun PNG personalizzato presente", "No custom NPC yet");
		public static string NpcEmptyTitle(LanguageCode lang) => T(lang, "La tua galleria di personaggi non giocanti è ancora vuota", "Your gallery of nonplayer characters is still empty");
		public static string NpcEmptyText(LanguageCode lang) => T(lang,
			"Crea da zero i volti della tua campagna (locandieri, alleati, rivali, boss) oppure parti da uno statblock dei mostri qui accanto per dargli un nome, un ritratto e dei segreti in pochi secondi. Da ogni mostro puoi anche creare un PNG.",
			"Create the faces of your campaign from scratch (innkeepers, allies, rivals, bosses) or start from one of the monster statblocks next to this to give it a name, a portrait and secrets in a few seconds. You can also make an NPC from any monster.");
		public static string NpcEmptyNew(LanguageCode lang) => T(lang, "+ Nuovo PNG da zero", "+ New NPC from scratch");
		public static string NpcEmptyShowMonsters(LanguageCode lang) => T(lang, "Scegli uno statblock tra i mostri", "Pick a statblock among the monsters");
		public static string NpcFromMonster(LanguageCode lang) => T(lang, "Crea PNG", "Make NPC");
		public static string NpcFromMonsterHint(LanguageCode lang) => T(lang, "Un PNG tuo con questo statblock: nome, ritratto, ruolo e segreti", "An NPC of yours with this statblock: name, portrait, role and secrets");
		public static string NpcStarterClone(LanguageCode lang) => T(lang, "Clona e dai un nome →", "Clone and name it →");
		public static string NpcStarterName(string key, LanguageCode lang) => key switch
		{
			"commoner" => T(lang, "Popolano / Mercante", "Commoner / Merchant"),
			"guard" => T(lang, "Guardia / Soldato", "Guard / Soldier"),
			_ => T(lang, "Spia / Informatore", "Spy / Informant")
		};
		public static string NpcStarterUse(string key, LanguageCode lang) => key switch
		{
			"commoner" => T(lang, "Locandieri, artigiani, guide", "Innkeepers, craftsfolk, guides"),
			"guard" => T(lang, "Milizia, scorte, pattuglie", "Militia, escorts, patrols"),
			_ => T(lang, "Contatti, ladri, agenti", "Contacts, thieves, agents")
		};

		//	Editor: the NPC part
		public static string NpcPortrait(LanguageCode lang) => T(lang, "Ritratto", "Portrait");
		public static string NpcPortraitPick(LanguageCode lang) => T(lang, "Scegli immagine", "Choose image");
		public static string NpcRole(LanguageCode lang) => T(lang, "Ruolo", "Role");
		public static string NpcRoleHint(LanguageCode lang) => T(lang, "Es. Locandiere, Informatore", "E.g. Innkeeper, Informant");
		public static string NpcAncestry(LanguageCode lang) => T(lang, "Specie / origine", "Species / ancestry");
		public static string NpcAncestryHint(LanguageCode lang) => T(lang, "Es. Mezzelfo, Nano delle colline", "E.g. Half-elf, Hill dwarf");
		public static string NpcPersonality(LanguageCode lang) => T(lang, "Personalità e spunti di interpretazione", "Personality and roleplay hooks");
		public static string NpcSecrets(LanguageCode lang) => T(lang, "Segreti (visibili solo a te)", "Secrets (only you see them)");
		public static string NpcCloneTitle(LanguageCode lang) => T(lang, "Clona nei miei PNG", "Clone to my NPCs");
		public static string NpcCloneHint(string original, LanguageCode lang) => T(lang,
			$"Copia privata di «{original}»: cambia nome, ritratto e segreti, lo statblock resta modificabile.",
			$"Private copy of “{original}”: change name, portrait and secrets, the statblock stays editable.");
		public static string NpcDeleteWarning(string name, LanguageCode lang) =>
			T(lang, $"Eliminare «{name}»? Potrai recuperarlo dal cestino per 3 giorni.", $"Delete “{name}”? You can restore it from the bin for 3 days.");

		//	Sheet
		public static string NpcBack(LanguageCode lang) => T(lang, "Tutti i PNG", "All NPCs");
		public static string NpcRoleplay(LanguageCode lang) => T(lang, "Interpretazione", "Roleplay");
		public static string NpcSecretsTitle(LanguageCode lang) => T(lang, "Segreti", "Secrets");
		public static string NpcSecretsOnlyYou(LanguageCode lang) => T(lang, "Solo tu li vedi", "Only you see them");
		public static string NpcStatblock(LanguageCode lang) => T(lang, "Statblock", "Statblock");
		public static string NpcNoRoleplay(LanguageCode lang) => T(lang,
			"Nessuna nota di interpretazione: clona il PNG per scriverne una tutta tua.",
			"No roleplay notes: clone the NPC to write your own.");
		public static string NpcCampaigns(LanguageCode lang) => T(lang, "Campagne", "Campaigns");
		public static string NpcNotFound(LanguageCode lang) => T(lang, "PNG non trovato.", "NPC not found.");
	}
}
