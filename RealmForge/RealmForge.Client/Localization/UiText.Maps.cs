using RealmForge.Shared.Campaigns;
using RealmForge.Shared.Enums;

namespace RealmForge.Client.Localization
{
	///	<summary>
	///	Texts of the virtual tabletop of a campaign.
	///	</summary>
	public static partial class UiText
	{
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
		public static string CampaignTabMaps(LanguageCode lang) => T(lang, "Mappe", "Maps");
		public static string MapGridType(LanguageCode lang) => T(lang, "Griglia", "Grid");
		public static string MapGridTypeName(GridType type, LanguageCode lang) => type switch
		{
			GridType.HexRows => T(lang, "Esagoni (a righe)", "Hexes (in rows)"),
			GridType.HexColumns => T(lang, "Esagoni (a colonne)", "Hexes (in columns)"),
			_ => T(lang, "Quadrati", "Squares")
		};
		public static string MapPrepHint(LanguageCode lang) => T(lang,
			"Qui prepari mappe e segnalini lontano dagli occhi dei giocatori. Al tavolo virtuale scegli quale mappa mostrare.",
			"Here you prepare maps and tokens away from the players' eyes. At the virtual tabletop you choose which map to show.");
		public static string TokenKindName(TokenKind kind, LanguageCode lang) => kind switch
		{
			TokenKind.Character => T(lang, "Personaggio", "Character"),
			TokenKind.Npc => T(lang, "PNG", "NPC"),
			TokenKind.Monster => T(lang, "Mostro", "Monster"),
			_ => T(lang, "Segnalino", "Marker")
		};
		public static string TokenArmorClass(int value, LanguageCode lang) => T(lang, $"CA {value}", $"AC {value}");
		public static string TokenHitPoints(int current, int max, LanguageCode lang) => T(lang, $"PF {current}/{max}", $"HP {current}/{max}");
		public static string TokenHitPointsMax(int max, LanguageCode lang) => T(lang, $"PF {max}", $"HP {max}");
		public static string TokenLevel(int level, string classLine, LanguageCode lang) => T(lang, $"Liv. {level} · {classLine}", $"Lv. {level} · {classLine}");
		public static string TokenOpenSheet(LanguageCode lang) => T(lang, "Apri la scheda", "Open the sheet");
		public static string TokenOpenMonster(LanguageCode lang) => T(lang, "Apri la scheda del mostro", "Open the monster's page");
		public static string TokenClose(LanguageCode lang) => T(lang, "Chiudi", "Close");
		public static string VttTitle(LanguageCode lang) => T(lang, "Tavolo virtuale", "Virtual tabletop");
		public static string VttBack(LanguageCode lang) => T(lang, "Torna alla campagna", "Back to the campaign");
		public static string VttToolSelect(LanguageCode lang) => T(lang, "Seleziona e sposta i segnalini", "Select and move tokens");
		public static string VttToolPan(LanguageCode lang) => T(lang, "Sposta la vista", "Move the view");
		public static string VttToolRuler(LanguageCode lang) => T(lang, "Righello", "Ruler");
		public static string VttToolTokens(LanguageCode lang) => T(lang, "Segnalini e mappa", "Tokens and map");
		public static string VttFullscreen(LanguageCode lang) => T(lang, "Schermo intero", "Full screen");
		public static string VttFit(LanguageCode lang) => T(lang, "Adatta allo schermo", "Fit to screen");
		public static string VttDisplay(LanguageCode lang) => T(lang, "Mostra ai giocatori", "Show to the players");
		public static string VttDisplayed(LanguageCode lang) => T(lang, "Visibile ai giocatori", "Visible to the players");
		public static string VttPrepare(LanguageCode lang) => T(lang, "Prepara le mappe", "Prepare maps");
		public static string VttUnit(LanguageCode lang) => T(lang, "m", "ft");
		public static double VttPerCell(LanguageCode lang) => lang == LanguageCode.It ? 1.5 : 5;
		public static string MapDuplicate(LanguageCode lang) => T(lang, "Duplica", "Duplicate");
		public static string MapCopyName(string name, LanguageCode lang) => T(lang, $"{name} (copia)", $"{name} (copy)");
		public static string MapCalibrate(LanguageCode lang) => T(lang, "Allinea la griglia", "Align the grid");
		public static string MapCalibrateHint(GridType type, LanguageCode lang) => type == GridType.Square
			? T(lang, "Trascina un riquadro esattamente sopra una casella disegnata sulla mappa, poi salva.",
				"Drag a box exactly over one cell drawn on the map, then save.")
			: T(lang, "Trascina un riquadro attorno a un esagono disegnato sulla mappa (da lato piatto a lato piatto), poi salva.",
				"Drag a box around one hexagon drawn on the map (flat side to flat side), then save.");
		public static string VttToolArea(LanguageCode lang) => T(lang, "Area di un incantesimo", "Spell area");
		public static string VttToolDraw(LanguageCode lang) => T(lang, "Disegna", "Draw");
		public static string VttToolText(LanguageCode lang) => T(lang, "Testo e note", "Text and notes");
		public static string VttToolErase(LanguageCode lang) => T(lang, "Cancella", "Erase");
		public static string AreaName(ShapeKind kind, LanguageCode lang) => kind switch
		{
			ShapeKind.Sphere => T(lang, "Sfera", "Sphere"),
			ShapeKind.Line => T(lang, "Linea", "Line"),
			ShapeKind.Cube => T(lang, "Cubo", "Cube"),
			_ => T(lang, "Cono", "Cone")
		};
		public static string VttAreaHint(LanguageCode lang) => T(lang,
			"Trascina dalla casella di chi lancia verso il bersaglio: le caselle colpite si colorano.",
			"Drag from the caster's cell towards the target: the cells hit light up.");
		public static string VttDrawHint(LanguageCode lang) => T(lang, "Trascina sulla mappa per disegnare.", "Drag on the map to draw.");
		public static string VttTextPlace(LanguageCode lang) => T(lang, "Fai clic sulla mappa dove scrivere.", "Click on the map where to write.");
		public static string VttTextHint(LanguageCode lang) => T(lang, "Testo…", "Text…");
		public static string VttMasterNote(LanguageCode lang) => T(lang, "Nota solo per i master", "Note for the masters only");
		public static string VttEraseHint(LanguageCode lang) => T(lang, "Fai clic su un disegno, un testo o un'area per toglierlo.", "Click a drawing, a text or an area to remove it.");
		public static string VttClearAll(LanguageCode lang) => T(lang, "Cancella tutti i disegni", "Clear all drawings");
		public static string VttClearMine(LanguageCode lang) => T(lang, "Cancella i miei disegni", "Clear my drawings");
		public static string MapTokenBelow(LanguageCode lang) => T(lang, "Sotto gli altri segnalini", "Under the other tokens");
		public static string VttToolFog(LanguageCode lang) => T(lang, "Nebbia di guerra", "Fog of war");
		public static string VttFogOn(LanguageCode lang) => T(lang, "Nebbia attiva", "Fog on");
		public static string VttFogReveal(LanguageCode lang) => T(lang, "Rivela", "Reveal");
		public static string VttFogCover(LanguageCode lang) => T(lang, "Copri", "Cover");
		public static string VttFogRect(LanguageCode lang) => T(lang, "Riquadro", "Box");
		public static string VttFogBrush(LanguageCode lang) => T(lang, "Pennello", "Brush");
		public static string VttFogRevealAll(LanguageCode lang) => T(lang, "Rivela tutto", "Reveal all");
		public static string VttFogCoverAll(LanguageCode lang) => T(lang, "Copri tutto", "Cover all");
		public static string VttFocus(LanguageCode lang) => T(lang, "Porta qui la vista dei giocatori", "Bring the players' view here");
		public static string VttCombat(LanguageCode lang) => T(lang, "Combattimento", "Combat");
		public static string VttNoEncounters(LanguageCode lang) => T(lang,
			"Prepara un incontro nella scheda Incontri della campagna per avviarlo qui.", "Prepare an encounter in the campaign's Encounters tab to start it here.");
		public static string VttStartCombat(LanguageCode lang) => T(lang, "Avvia sulla mappa", "Start on the map");
		public static string VttRound(int round, LanguageCode lang) => T(lang, $"Round {round}", $"Round {round}");
		public static string VttNextTurn(LanguageCode lang) => T(lang, "Turno successivo", "Next turn");
		public static string VttEndCombat(LanguageCode lang) => T(lang, "Termina", "End");
		public static string TokenHp(int max, LanguageCode lang) => T(lang, $"Punti ferita (max {max})", $"Hit points (max {max})");
		public static string TokenConditions(LanguageCode lang) => T(lang, "Condizioni", "Conditions");
		public static string TokenRolls(LanguageCode lang) => T(lang, "Tiri", "Rolls");
		public static string RollInitiative(LanguageCode lang) => T(lang, "Iniziativa", "Initiative");
		public static string RollAttack(string weapon, LanguageCode lang) => T(lang, $"{weapon}: attacco", $"{weapon}: attack");
		public static string RollDamage(string weapon, LanguageCode lang) => T(lang, $"{weapon}: danni", $"{weapon}: damage");
		public static string RollSave(string ability, LanguageCode lang) => T(lang, $"TS {ability}", $"{ability} save");
		public static string RollCheck(string ability, LanguageCode lang) => T(lang, $"Prova {ability}", $"{ability} check");
		public static string TokenRename(LanguageCode lang) => T(lang, "Rinomina", "Rename");
		public static string ToolHp(LanguageCode lang) => T(lang, "PF", "HP");
		public static string ToolHpMax(LanguageCode lang) => T(lang, "PF massimi", "Max HP");
		public static string ToolHpOnSheet(LanguageCode lang) => T(lang, "si cambiano dalla scheda", "changed from the sheet");
		public static string ToolHide(LanguageCode lang) => T(lang, "Nascondi", "Hide");
		public static string ToolRing(LanguageCode lang) => T(lang, "Anello", "Ring");
		public static string ToolSize(LanguageCode lang) => T(lang, "Taglia", "Size");
		public static string ToolMore(LanguageCode lang) => T(lang, "Altro", "More");
		public static string ToolNoConditions(LanguageCode lang) => T(lang, "Nessuna condizione.", "No conditions.");
		public static string ToolSizeName(int cells, LanguageCode lang) => cells switch
		{
			1 => T(lang, "Media (1)", "Medium (1)"),
			2 => T(lang, "Grande (2)", "Large (2)"),
			3 => T(lang, "Enorme (3)", "Huge (3)"),
			4 => T(lang, "Mastodontica (4)", "Gargantuan (4)"),
			_ => $"{cells}×{cells}"
		};
		public static string ToolControlledBy(LanguageCode lang) => T(lang, "Possono muoverlo anche", "Can also be moved by");
		public static string ToolDuplicate(LanguageCode lang) => T(lang, "Duplica", "Duplicate");
		public static string ToolMoveHint(LanguageCode lang) => T(lang,
			"Trascinalo sulla mappa, oppure usa le frecce della tastiera.", "Drag it on the map, or use the arrow keys.");
		public static string VttInitiative(LanguageCode lang) => T(lang, "Iniziativa", "Initiative");
		public static string VttDice(LanguageCode lang) => T(lang, "Dadi", "Dice");
		public static string VttQuickCombat(LanguageCode lang) => T(lang, "Combattimento con i segnalini", "Fight with the tokens");
		public static string VttQuickCombatEmpty(LanguageCode lang) => T(lang, "Metti sulla mappa personaggi e mostri per combattere.", "Put characters and monsters on the map to fight.");
		public static string VttQuickCombatStart(LanguageCode lang) => T(lang, "Tira l'iniziativa e inizia", "Roll initiative and start");
		public static string VttNoCombat(LanguageCode lang) => T(lang, "Nessun combattimento in corso.", "No fight under way.");
		public static string VttJoinFight(LanguageCode lang) => T(lang, "Aggiungi all'iniziativa", "Add to the initiative");
		public static string VttLeaveFight(LanguageCode lang) => T(lang, "Togli dall'iniziativa", "Remove from the initiative");
		public static string VttFightAlone(LanguageCode lang) => T(lang, "Inizia un combattimento con questo segnalino", "Start a fight with this token");
		public static string ToolAdd(LanguageCode lang) => T(lang, "Iniziativa", "Initiative");
		public static string ToolOut(LanguageCode lang) => T(lang, "Fuori", "Out");
	}
}
