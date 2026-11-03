using RealmForge.Shared.Enums;

namespace RealmForge.Client.Localization
{
	///	<summary>
	///	Texts of the virtual tabletop of a campaign.
	///	</summary>
	public static partial class UiText
	{
		public static string CampaignTabMap(LanguageCode lang) => T(lang, "Mappa", "Map");
		public static string MapSave(LanguageCode lang) => T(lang, "Salva", "Save");
		public static string MapZoom(LanguageCode lang) => T(lang, "Zoom", "Zoom");
		public static string MapNew(LanguageCode lang) => T(lang, "Nuova mappa", "New map");
		public static string MapDefaultName(int number, LanguageCode lang) => T(lang, $"Mappa {number}", $"Map {number}");
		public static string MapEmptyMaster(LanguageCode lang) => T(lang,
			"Nessuna mappa: creane una con un'immagine (una pianta del dungeon, una città, un campo di battaglia) e mostrala al tavolo quando serve.",
			"No maps yet: create one from a picture (a dungeon plan, a town, a battlefield) and show it to the table when needed.");
		public static string MapEmptyPlayer(LanguageCode lang) => T(lang,
			"Il master non ha ancora mostrato nessuna mappa. Questa pagina si aggiorna da sola.",
			"The master has not shown any map yet. This page updates on its own.");
		public static string MapNotShown(LanguageCode lang) => T(lang, "non mostrata", "not shown");
		public static string MapSettings(LanguageCode lang) => T(lang, "Mappa e griglia", "Map and grid");
		public static string MapName(LanguageCode lang) => T(lang, "Nome", "Name");
		public static string MapGrid(LanguageCode lang) => T(lang, "Casella (px)", "Cell (px)");
		public static string MapOffsetX(LanguageCode lang) => T(lang, "Scostamento X", "Offset X");
		public static string MapOffsetY(LanguageCode lang) => T(lang, "Scostamento Y", "Offset Y");
		public static string MapShown(LanguageCode lang) => T(lang, "Mostra ai giocatori", "Show to the players");
		public static string MapAddTokens(LanguageCode lang) => T(lang, "Aggiungi segnalini", "Add tokens");
		public static string MapMonsterSearch(LanguageCode lang) => T(lang, "Mostro o PNG (es. Goblin)…", "Monster or NPC (e.g. Goblin)…");
		public static string MapMarkerHint(LanguageCode lang) => T(lang, "Segnalino (es. Porta, Trappola)", "Marker (e.g. Door, Trap)");
		public static string MapColor(LanguageCode lang) => T(lang, "Colore", "Colour");
		public static string MapTokenSize(LanguageCode lang) => T(lang, "Dimensione (caselle)", "Size (cells)");
		public static string MapTokenHidden(LanguageCode lang) => T(lang, "Nascosto ai giocatori", "Hidden from the players");
		public static string MapTokenHint(LanguageCode lang) => T(lang,
			"Seleziona un segnalino per cambiarne la dimensione, nasconderlo o toglierlo; trascinalo per spostarlo.",
			"Select a token to change its size, hide it or remove it; drag it to move it.");
		public static string MapPlayerHint(LanguageCode lang) => T(lang,
			"Trascina il segnalino del tuo personaggio per muoverlo: gli altri lo vedono spostarsi in un paio di secondi.",
			"Drag your character's token to move it: the others see it move within a couple of seconds.");
		public static string MapPickImage(LanguageCode lang) => T(lang, "Scegli l'immagine", "Choose the picture");
		public static string MapNewHint(LanguageCode lang) => T(lang,
			"L'immagine viene ridotta a 2048 px sul lato lungo. Dopo averla creata, regola la dimensione della casella finché la griglia combacia con quella della mappa.",
			"The picture is scaled down to 2048 px on its longer side. Once created, adjust the cell size until the grid matches the map's.");
		public static string MapImageTooLarge(LanguageCode lang) => T(lang, "Immagine non leggibile o troppo grande.", "The picture cannot be read or is too large.");
		public static string MapSaveFailed(LanguageCode lang) => T(lang, "Salvataggio non riuscito, riprova.", "Saving failed, try again.");
		public static string MapMoveFailed(LanguageCode lang) => T(lang, "Spostamento non riuscito: il segnalino torna dov'era.", "Move failed: the token goes back.");
		public static string MapDeleteConfirm(string name, LanguageCode lang) => T(lang,
			$"Eliminare la mappa «{name}» con tutti i suoi segnalini?", $"Delete the map “{name}” with all its tokens?");
	}
}
