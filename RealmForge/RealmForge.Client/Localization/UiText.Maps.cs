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
		public static string VttTextShared(LanguageCode lang) => T(lang, "Visibile ai giocatori", "Shown to the players");
		public static string VttOnlyYou(LanguageCode lang) => T(lang, "Lo vedi solo tu.", "Only you see it.");
		public static string VttToolPing(LanguageCode lang) => T(lang, "Segnala un punto (ping)", "Ping a spot");
		public static string VttLockPlayers(LanguageCode lang) => T(lang, "Blocca aree e ping dei giocatori", "Stop the players' areas and pings");
		public static string VttUnlockPlayers(LanguageCode lang) => T(lang, "Aree e ping dei giocatori bloccati: clic per sbloccarli", "The players' areas and pings are stopped: click to allow them");
		public static string VttTurnSlot(int slot, LanguageCode lang) => slot switch
		{
			1 => T(lang, "Azioni", "Actions"),
			2 => T(lang, "Azioni bonus", "Bonus actions"),
			_ => T(lang, "Reazioni", "Reactions")
		};
		public static string VttPactSlots(int left, int max, int level, LanguageCode lang) => T(lang, $"Patto ({level}°): {left}/{max}", $"Pact ({level}): {left}/{max}");
		public static string VttSpellAttack(LanguageCode lang) => T(lang, "Attacco con incantesimo", "Spell attack");
		public static string VttSpellNumbers(int dc, string attack, LanguageCode lang) => T(lang, $"CD {dc} · Attacco {attack}", $"DC {dc} · Attack {attack}");
		public static string VttInnateSpells(LanguageCode lang) => T(lang, "Incantesimi innati", "Innate spells");
		public static string VttResources(LanguageCode lang) => T(lang, "Usi rimasti", "Uses left");
		public static string VttFeats(LanguageCode lang) => T(lang, "Talenti", "Feats");
		public static string VttFeatureLevel(int level, LanguageCode lang) => T(lang, $"Liv. {level}", $"Lv. {level}");
		public static string VttMonsterDetails(LanguageCode lang) => T(lang, "Caratteristiche", "Details");
		public static string VttMonsterSkills(LanguageCode lang) => T(lang, "Abilità", "Skills");
		public static string VttMonsterVulnerable(LanguageCode lang) => T(lang, "Vulnerabilità", "Vulnerabilities");
		public static string VttMonsterResistant(LanguageCode lang) => T(lang, "Resistenze", "Resistances");
		public static string VttMonsterImmune(LanguageCode lang) => T(lang, "Immunità ai danni", "Damage immunities");
		public static string VttMonsterConditionImmune(LanguageCode lang) => T(lang, "Immunità alle condizioni", "Condition immunities");
		public static string VttMonsterSenses(LanguageCode lang) => T(lang, "Sensi", "Senses");
		public static string VttMonsterLanguages(LanguageCode lang) => T(lang, "Linguaggi", "Languages");
		public static string VttSheetTab(string key, LanguageCode lang) => key switch
		{
			"actions" => T(lang, "Azioni", "Actions"),
			"spells" => T(lang, "Incantesimi", "Spells"),
			"features" => T(lang, "Privilegi", "Features"),
			"notes" => T(lang, "Note", "Notes"),
			"loot" => T(lang, "Bottino", "Loot"),
			_ => T(lang, "Generale", "General")
		};
		public static string VttSpellLevelName(int level, LanguageCode lang) => level == 0 ? T(lang, "Trucchetti", "Cantrips") : T(lang, $"{level}° livello", $"Level {level}");
		public static string VttHideHint(LanguageCode lang) => T(lang, "I giocatori vedono questa mappa: clic per nasconderla.", "The players see this map: click to hide it.");
		public static string VttEraseClick(LanguageCode lang) => T(lang, "Clic", "Click");
		public static string VttEraseArea(LanguageCode lang) => T(lang, "Area", "Area");
		public static string VttEraseAreaHint(LanguageCode lang) => T(lang, "Trascina un riquadro: disegni, testi e aree che tocca vengono tolti.", "Drag a box: the drawings, texts and areas it touches are removed.");
		public static string VttTooFar(LanguageCode lang) => T(lang, "Oltre la velocità di movimento.", "Beyond the movement speed.");
		public static string VttEraseHint(LanguageCode lang) => T(lang, "Fai clic su un disegno, un testo o un'area per toglierlo.", "Click a drawing, a text or an area to remove it.");
		public static string VttClearAll(LanguageCode lang) => T(lang, "Rimuovi i disegni che vedi", "Remove the drawings you see");
		public static string VttClearMine(LanguageCode lang) => T(lang, "Rimuovi i miei disegni", "Remove my drawings");
		public static string MapTokenBelow(LanguageCode lang) => T(lang, "Sotto gli altri segnalini", "Under the other tokens");
		public static string VttToolFog(LanguageCode lang) => T(lang, "Nebbia di guerra", "Fog of war");
		public static string VttFogOn(LanguageCode lang) => T(lang, "Nebbia attiva", "Fog on");
		public static string VttFogReveal(LanguageCode lang) => T(lang, "Rivela", "Reveal");
		public static string VttFogCover(LanguageCode lang) => T(lang, "Copri", "Cover");
		public static string VttFogRect(LanguageCode lang) => T(lang, "Riquadro", "Box");
		public static string VttFogBrush(LanguageCode lang) => T(lang, "Pennello", "Brush");
		public static string VttFogBrushSize(LanguageCode lang) => T(lang, "Caselle del pennello", "Brush cells");
		public static string VttFogFull(LanguageCode lang) => T(lang,
			"La nebbia ha troppi passaggi: usa Rivela tutto o Copri tutto e ricomincia.", "The fog has too many steps: use Reveal all or Cover all and start again.");
		public static string VttFogRevealAll(LanguageCode lang) => T(lang, "Rivela tutto", "Reveal all");
		public static string VttFogCoverAll(LanguageCode lang) => T(lang, "Copri tutto", "Cover all");
		public static string VttFocus(LanguageCode lang) => T(lang, "Porta qui la vista dei giocatori", "Bring the players' view here");
		public static string VttCombat(LanguageCode lang) => T(lang, "Combattimento", "Combat");
		public static string VttNoEncounters(LanguageCode lang) => T(lang,
			"Prepara un incontro nella scheda Incontri della campagna per avviarlo qui.", "Prepare an encounter in the campaign's Encounters tab to start it here.");
		public static string VttStartCombat(LanguageCode lang) => T(lang, "Avvia sulla mappa", "Start on the map");
		public static string VttRound(int round, LanguageCode lang) => T(lang, $"Round {round}", $"Round {round}");
		public static string VttNoFight(LanguageCode lang) => T(lang, "Nessuno scontro attivo", "No fight under way");
		public static string VttFromEncounter(LanguageCode lang) => T(lang, "Da incontro", "From an encounter");
		public static string VttAskInitiative(LanguageCode lang) => T(lang, "Richiedi iniziativa", "Ask for initiative");
		public static string VttInitPhase(LanguageCode lang) => T(lang, "Fase di iniziativa", "Initiative phase");
		public static string VttInitPhaseHint(LanguageCode lang) => T(lang, "Tira o inserisci i valori", "Roll or write the values");
		public static string VttInitMod(string bonus, LanguageCode lang) => T(lang, $"Mod {bonus}", $"Mod {bonus}");
		public static string VttInitRoll(string bonus, LanguageCode lang) => T(lang, $"Tira ({bonus})", $"Roll ({bonus})");
		public static string VttRollAll(LanguageCode lang) => T(lang, "Tira tutti", "Roll all");
		public static string VttRollAllHint(LanguageCode lang) => T(lang, "Tira per chi manca, tranne i personaggi dei giocatori", "Roll for whoever is missing, but the players' characters");
		public static string VttBegin(LanguageCode lang) => T(lang, "Avvia", "Start");
		public static string VttActiveTurn(LanguageCode lang) => T(lang, "Turno attivo", "Active turn");
		public static string VttTurnShort(LanguageCode lang) => T(lang, "Turno", "Turn");
		public static string VttRoundLabel(LanguageCode lang) => T(lang, "Round", "Round");
		public static string VttPreviousTurn(LanguageCode lang) => T(lang, "Turno precedente", "Previous turn");
		public static string VttShowHealth(LanguageCode lang) => T(lang, "Mostra ai giocatori la salute dei nemici", "Show the enemies' health to the players");
		public static string VttHideHealth(LanguageCode lang) => T(lang, "Nascondi ai giocatori la salute dei nemici", "Hide the enemies' health from the players");
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
		public static string PropTypeName(PropType type, LanguageCode lang) => type switch
		{
			PropType.Gate => T(lang, "Cancello", "Gate"),
			PropType.Window => T(lang, "Finestra", "Window"),
			PropType.Chest => T(lang, "Forziere", "Chest"),
			PropType.Lever => T(lang, "Leva", "Lever"),
			PropType.Trap => T(lang, "Trappola", "Trap"),
			PropType.Secret => T(lang, "Passaggio segreto", "Secret passage"),
			PropType.Item => T(lang, "Oggetto", "Item"),
			_ => T(lang, "Porta", "Door")
		};
		public static string PropStateName(PropType type, PropState state, LanguageCode lang) => (type, state) switch
		{
			(PropType.Item, _) => T(lang, "A terra", "On the ground"),
			(PropType.Lever, PropState.Open) => T(lang, "Alzata", "Up"),
			(PropType.Lever, PropState.Closed) => T(lang, "Abbassata", "Down"),
			(PropType.Trap, PropState.Closed) => T(lang, "Armata", "Armed"),
			(PropType.Trap, PropState.Open) => T(lang, "Scattata", "Sprung"),
			(PropType.Trap, PropState.Broken) => T(lang, "Disinnescata", "Disarmed"),
			(_, PropState.Open) => T(lang, "Aperto", "Open"),
			(_, PropState.Ajar) => T(lang, "Socchiuso", "Ajar"),
			(_, PropState.Locked) => T(lang, "Chiuso a chiave", "Locked"),
			(_, PropState.Barred) => T(lang, "Sbarrato", "Barred"),
			(_, PropState.Broken) => T(lang, "Rotto", "Broken"),
			(_, PropState.Empty) => T(lang, "Vuoto", "Empty"),
			_ => T(lang, "Chiuso", "Closed")
		};
		public static string PropAction(PropType type, PropState state, LanguageCode lang) => (type, state) switch
		{
			(PropType.Lever, PropState.Open) => T(lang, "Abbassa", "Pull down"),
			(PropType.Lever, _) => T(lang, "Alza", "Pull up"),
			(_, PropState.Open) => T(lang, "Chiudi", "Close"),
			_ => T(lang, "Apri", "Open")
		};
		public static string PropStuck(PropType type, PropState state, LanguageCode lang) =>
			T(lang, $"Non si muove: {PropStateName(type, state, lang).ToLowerInvariant()}.", $"It does not move: {PropStateName(type, state, lang).ToLowerInvariant()}.");
		public static string PropPlayers(LanguageCode lang) => T(lang, "I giocatori possono usarlo", "The players can use it");
		public static string PropAdd(LanguageCode lang) => T(lang, "Oggetti", "Objects");
		public static string ToolState(LanguageCode lang) => T(lang, "Stato", "State");

		// ===== The layout of the table: dock, side panel, quick sheet =====
		public static string VttRoundWord(LanguageCode lang) => "Round";
		public static string VttDiceShort(LanguageCode lang) => T(lang, "Dadi", "Dice");
		public static string VttTokensShort(LanguageCode lang) => T(lang, "Segnalini", "Tokens");
		public static string VttTabRolls(LanguageCode lang) => T(lang, "Tiri", "Rolls");
		public static string VttRollLog(LanguageCode lang) => T(lang, "Log dei tiri", "Roll log");
		public static string VttTokensMap(LanguageCode lang) => T(lang, "Segnalini e mappa", "Tokens and map");
		public static string VttPanelHide(LanguageCode lang) => T(lang, "Nascondi il pannello", "Hide the panel");
		public static string VttPanelShow(LanguageCode lang) => T(lang, "Mostra il pannello", "Show the panel");
		public static string VttOpenDice(LanguageCode lang) => T(lang, "Apri la console dei dadi", "Open the dice console");
		public static string VttQuickSheet(LanguageCode lang) => T(lang, "Scheda", "Sheet");
		public static string VttQuickSheetOpen(LanguageCode lang) => T(lang, "Scheda rapida a lato", "Quick sheet on the side");
		public static string VttQuickSheetFull(LanguageCode lang) => T(lang, "Apri la scheda completa", "Open the full sheet");
		public static string VttHitPointsShort(LanguageCode lang) => T(lang, "Punti ferita", "Hit points");
		public static string VttSaves(LanguageCode lang) => T(lang, "Tiri salvezza", "Saving throws");
		public static string VttPassives(LanguageCode lang) => T(lang, "Sensi passivi", "Passive senses");
		public static string VttQuickAttacks(LanguageCode lang) => T(lang, "Attacchi", "Attacks");
		public static string VttOnMap(int count, LanguageCode lang) => T(lang, $"Sulla mappa ({count})", $"On the map ({count})");
		public static string VttOnMapEmpty(LanguageCode lang) => T(lang, "Nessun segnalino sulla mappa.", "No tokens on the map.");
		public static string VttCenter(LanguageCode lang) => T(lang, "Centra", "Center");
		public static string VttProficiency(LanguageCode lang) => T(lang, "Competenza", "Proficiency");
		public static string VttBonus(LanguageCode lang) => "Bonus";
		public static string VttWalk(LanguageCode lang) => T(lang, "Camminata", "Walking");
		public static string VttSpeed(LanguageCode lang) => T(lang, "Velocità", "Speed");
		public static string VttArmor(LanguageCode lang) => T(lang, "Armatura", "Armor");
		public static string VttArmorClass(LanguageCode lang) => T(lang, "Classe (CA)", "Class (AC)");
		public static string VttPassivePerception(LanguageCode lang) => T(lang, "Percezione", "Perception");
		public static string VttPassiveInvestigation(LanguageCode lang) => T(lang, "Indagare", "Investigation");
		public static string VttPassiveInsight(LanguageCode lang) => T(lang, "Intuizione", "Insight");
		public static string VttNpcPersonality(LanguageCode lang) => T(lang, "Al tavolo", "At the table");
		public static string VttNpcSecrets(LanguageCode lang) => T(lang, "Segreti", "Secrets");
		public static string VttTraits(LanguageCode lang) => T(lang, "Tratti", "Traits");
		public static string VttActions(LanguageCode lang) => T(lang, "Azioni", "Actions");
		public static string VttBonusActions(LanguageCode lang) => T(lang, "Azioni bonus", "Bonus actions");
		public static string VttReactions(LanguageCode lang) => T(lang, "Reazioni", "Reactions");
		public static string VttLegendary(LanguageCode lang) => T(lang, "Azioni leggendarie", "Legendary actions");
		public static string ToolBelow(LanguageCode lang) => T(lang, "Sotto", "Below");
		public static string ToolAssign(LanguageCode lang) => T(lang, "Assegna", "Assign");
		public static string ToolBack(LanguageCode lang) => T(lang, "Indietro", "Back");
		public static string ToolHeal(LanguageCode lang) => T(lang, "Cura", "Heal");
		public static string ToolDamage(LanguageCode lang) => T(lang, "Danno", "Damage");
		public static string ToolHpAmount(LanguageCode lang) => T(lang, "Quantità", "Amount");
		public static string ToolArmorClass(LanguageCode lang) => T(lang, "Classe armatura", "Armour class");
		public static string ToolHpShown(LanguageCode lang) => T(lang, "PF visibili ai giocatori", "Hit points shown to the players");
		public static string ToolHpHidden(LanguageCode lang) => T(lang, "PF nascosti ai giocatori", "Hit points hidden from the players");
		public static string TokenCopyName(string name, LanguageCode lang) => T(lang, $"{name} (copia)", $"{name} (copy)");
		public static string ToolTempHp(LanguageCode lang) => T(lang, "PF temporanei", "Temporary HP");
		public static string ToolHpMaxEdit(LanguageCode lang) => T(lang, "Modifica PF max", "Change max HP");
		public static string ToolHpNow(LanguageCode lang) => T(lang, "PF attuali", "Current HP");

		// ===== The table open now =====
		public static string TableOpen(LanguageCode lang) => T(lang, "Avvia il tavolo", "Start the table");
		public static string TableOpenHint(LanguageCode lang) => T(lang,
			"I giocatori ricevono un avviso e trovano il tavolo in cima alla campagna.", "The players get a notice and find the table at the top of the campaign.");
		public static string TableClose(LanguageCode lang) => T(lang, "Chiudi il tavolo", "Close the table");
		public static string TableLive(LanguageCode lang) => T(lang, "Tavolo aperto", "Table open");
		public static string TableLiveNow(LanguageCode lang) => T(lang, "Al tavolo ora", "At the table now");
		public static string TableLiveTitle(string campaign, LanguageCode lang) => T(lang, $"Il tavolo di «{campaign}» è aperto", $"The table of “{campaign}” is open");
		public static string TableSessionLive(LanguageCode lang) => T(lang, "Sessione in corso", "Session in progress");
		public static string TableOpenedBy(string name, DateTimeOffset at, LanguageCode lang)
		{
			var time = at.ToLocalTime().ToString("HH:mm", System.Globalization.CultureInfo.InvariantCulture);
			return string.IsNullOrWhiteSpace(name)
				? T(lang, $"Aperto alle {time}", $"Opened at {time}")
				: T(lang, $"Aperto da {name} alle {time}", $"Opened by {name} at {time}");
		}
		public static string TableJoin(LanguageCode lang) => T(lang, "Entra al tavolo", "Join the table");
		public static string TableNotifyMe(LanguageCode lang) => T(lang, "Avvisami anche fuori dalla scheda", "Notify me outside this tab too");
		public static string TableNotifyOn(LanguageCode lang) => T(lang, "Avvisi del browser attivi", "Browser notices on");
		public static string TableDismiss(LanguageCode lang) => T(lang, "Chiudi l'avviso", "Dismiss");

		// ===== Fighting on the map: aiming, casting, dropped weapons, loot =====

		public static string VttAimStart(string attack, LanguageCode lang) => T(lang, $"{attack}: scegli il bersaglio sulla mappa", $"{attack}: pick the target on the map");
		public static string VttAimHint(LanguageCode lang) => T(lang, "Clic su un bersaglio evidenziato (giallo: con svantaggio). Esc per annullare.", "Click a highlighted target (yellow: with disadvantage). Esc to cancel.");
		public static string VttAimOut(LanguageCode lang) => T(lang, "Fuori portata: avvicinati o scegli un altro bersaglio.", "Out of reach: move closer or pick another target.");
		public static string VttAimArmor(int armor, LanguageCode lang) => T(lang, $"CA {armor}", $"AC {armor}");
		public static string VttAimMode(int mode, LanguageCode lang) => mode switch
		{
			> 0 => T(lang, "Vantaggio", "Advantage"),
			< 0 => T(lang, "Svantaggio", "Disadvantage"),
			_ => T(lang, "Normale", "Normal")
		};
		public static string VttAimCondition(LanguageCode lang) => T(lang, "Condizione inflitta se colpisce", "Condition imposed on a hit");
		public static string VttAimNoCondition(LanguageCode lang) => T(lang, "Nessuna condizione", "No condition");
		public static string VttCast(LanguageCode lang) => T(lang, "Lancia", "Cast");
		public static string VttCastDetails(LanguageCode lang) => T(lang, "Apri l'incantesimo", "Open the spell");
		public static string VttCastNoSlot(LanguageCode lang) => T(lang, "Nessuno slot disponibile per questo incantesimo.", "No slot left for this spell.");
		public static string VttCastDone(string spell, string? how, LanguageCode lang) => how is null
			? T(lang, $"Lanciato «{spell}».", $"Cast “{spell}”.")
			: T(lang, $"Lanciato «{spell}» ({how}).", $"Cast “{spell}” ({how}).");
		public static string VttCastLocked(string spell, LanguageCode lang) => T(lang, $"Lanciato «{spell}»: il master ha bloccato le aree, chiedigli di piazzarla.", $"Cast “{spell}”: the master locked the areas, ask them to place it.");
		public static string VttCastFromCaster(LanguageCode lang) => T(lang, "Parte da te: muovi il puntatore per orientarla e clicca. Esc per annullare.", "It starts from you: point it and click. Esc to cancel.");
		public static string VttCastAnywhere(LanguageCode lang) => T(lang, "Clicca dove centrarla. Esc per annullare.", "Click where to centre it. Esc to cancel.");
		public static string VttCastWithin(string range, LanguageCode lang) => T(lang, $"Clicca un punto entro {range} (rosso: troppo lontano). Esc per annullare.", $"Click a point within {range} (red: too far). Esc to cancel.");
		public static string VttCastInside(string spell, string names, LanguageCode lang) => T(lang, $"«{spell}»: nell'area {names}.", $"“{spell}”: in the area {names}.");
		public static string VttCastNobody(string spell, LanguageCode lang) => T(lang, $"«{spell}»: nessuno nell'area.", $"“{spell}”: nobody in the area.");
		public static string ToolDrop(LanguageCode lang) => T(lang, "Disarma", "Disarm");
		public static string VttDropHint(LanguageCode lang) => T(lang, "L'arma cade a terra accanto al segnalino:", "The weapon falls next to the token:");
		public static string VttDropNone(LanguageCode lang) => T(lang, "Nessuna arma da far cadere.", "No weapon to drop.");
		public static string VttDropped(string weapon, LanguageCode lang) => T(lang, $"«{weapon}» è a terra.", $"“{weapon}” is on the ground.");
		public static string VttDisarmed(string weapons, LanguageCode lang) => T(lang, $"Disarmato: {weapons} (a terra)", $"Disarmed: {weapons} (on the ground)");
		public static string VttLoot(LanguageCode lang) => T(lang, "Bottino", "Loot");
		public static string VttLootHint(LanguageCode lang) => T(lang, "Quello che porta con sé: i giocatori lo vedono e lo prendono quando è a terra.", "What it carries: the players see it and take it once it is down.");
		public static string VttLootItem(LanguageCode lang) => T(lang, "Oggetto (es. Spada corta, Pozione di guarigione)", "Item (e.g. Shortsword, Potion of healing)");
		public static string VttLootCoins(LanguageCode lang) => T(lang, "Monete d'oro", "Gold pieces");
		public static string VttLootCoinsValue(int coins, LanguageCode lang) => T(lang, $"{coins} mo", $"{coins} gp");
		public static string VttLootSaved(LanguageCode lang) => T(lang, "Bottino salvato.", "Loot saved.");
		public static string VttLootEmpty(LanguageCode lang) => T(lang, "Non c'è niente da prendere.", "There is nothing to take.");
		public static string VttTake(LanguageCode lang) => T(lang, "Prendi", "Take");
		public static string VttTakeBy(string who, LanguageCode lang) => T(lang, $"Lo prende {who}", $"{who} takes it");
		public static string VttTakeNear(LanguageCode lang) => T(lang, "Porta accanto un tuo segnalino per prenderlo.", "Bring one of your tokens next to it to take it.");
		public static string VttTakeCost(LanguageCode lang) => T(lang, "In combattimento costa l'azione del turno.", "In a fight it costs the action of the turn.");
		public static string VttTaken(string who, LanguageCode lang) => T(lang, $"Preso da {who}: è nel suo inventario.", $"Taken by {who}: it is in their inventory.");
	}
}
