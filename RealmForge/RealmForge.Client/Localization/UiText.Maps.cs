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
		public static string VttDownNoActions(LanguageCode lang) => T(lang,
			"A terra, privo di sensi: niente azioni, azioni bonus né reazioni finché non torna sopra 0 punti ferita.",
			"Down and unconscious: no actions, bonus actions or reactions until back above 0 hit points.");
		public static string VttDownState(LanguageCode lang) => T(lang, "A terra", "Down");
		public static string VttTurnYours(LanguageCode lang) => T(lang, "Il tuo turno", "Your turn");
		public static string VttTurnNotYours(LanguageCode lang) => T(lang, "Turno", "Turn");
		public static string VttTurnAction(LanguageCode lang) => T(lang, "Azione", "Action");
		public static string VttTurnBonus(LanguageCode lang) => T(lang, "Azione bonus", "Bonus action");
		public static string VttTurnReaction(LanguageCode lang) => T(lang, "Reazione", "Reaction");
		public static string VttTurnInteraction(LanguageCode lang) => T(lang, "Interazione", "Interaction");
		public static string VttTurnFree(LanguageCode lang) => T(lang, "disponibile", "available");
		public static string VttTurnUsed(LanguageCode lang) => T(lang, "usata", "used");
		public static string VttTurnAttacks(int made, int most, LanguageCode lang) => T(lang, $"attacchi {made}/{most}", $"attacks {made}/{most}");
		public static string VttTurnKind(string kind, LanguageCode lang) => kind switch
		{
			"dash" => T(lang, "Scatto", "Dash"),
			"disengage" => T(lang, "Disimpegno", "Disengage"),
			"dodge" => T(lang, "Schivata", "Dodge"),
			"help" => T(lang, "Aiuto", "Help"),
			"hide" => T(lang, "Nascondersi", "Hide"),
			"ready" => T(lang, "Preparare", "Ready"),
			_ => kind
		};
		public static string VttTurnKindHint(string kind, LanguageCode lang) => kind switch
		{
			"dash" => T(lang, "Usa l'azione: il movimento di questo turno raddoppia", "Takes the action: the movement of this turn doubles"),
			"disengage" => T(lang, "Usa l'azione: uscire dalla portata dei nemici non provoca attacchi di opportunità", "Takes the action: leaving the enemies' reach provokes no attacks of opportunity"),
			"dodge" => T(lang, "Usa l'azione: gli attacchi contro di te hanno svantaggio fino al tuo prossimo turno", "Takes the action: attacks against you have disadvantage until your next turn"),
			"help" => T(lang, "Usa l'azione: un alleato ha vantaggio nella prossima prova o attacco", "Takes the action: an ally has advantage on the next check or attack"),
			"hide" => T(lang, "Usa l'azione: una prova di Furtività per nasconderti", "Takes the action: a Stealth check to hide"),
			"ready" => T(lang, "Usa l'azione ora: quando l'innesco scatta, l'azione preparata si fa con la reazione", "Takes the action now: when the trigger comes, the readied action is made with the reaction"),
			_ => kind
		};
		public static string VttTurnBonusUse(LanguageCode lang) => T(lang, "Usa azione bonus", "Use bonus action");
		public static string VttTurnBonusHint(LanguageCode lang) => T(lang, "Segna l'azione bonus del turno come usata", "Marks the bonus action of the turn as used");
		public static string VttTurnWieldNone(string kind, LanguageCode lang) => kind == "ranged" ? T(lang, "Nessuna arma a distanza nell'equipaggiamento", "No ranged weapon in the equipment") : T(lang, "Nessuna arma da mischia nell'equipaggiamento", "No melee weapon in the equipment");
		public static string VttTurnWieldHint(LanguageCode lang) => T(lang, "Il primo cambio del turno è l'interazione gratuita, il secondo usa l'azione", "The first change of the turn is the free interaction, a second one takes the action");
		public static string VttTurnWield(LanguageCode lang) => T(lang, "Arma in mano", "Weapon in hand");
		public static string VttTurnWieldKind(string kind, LanguageCode lang) => kind == "ranged" ? T(lang, "A distanza", "Ranged") : T(lang, "In mischia", "Melee");
		public static string VttOpportunity(string reactor, string target, LanguageCode lang) => T(lang, $"{reactor}: attacco di opportunità su {target}", $"{reactor}: attack of opportunity on {target}");
		public static string VttOpportunityTake(LanguageCode lang) => T(lang, "Attacca", "Attack");
		public static string VttOpportunityPass(LanguageCode lang) => T(lang, "Lascia andare", "Let it go");
		public static string VttOpportunityNoAttack(LanguageCode lang) => T(lang, "Nessun attacco in mischia: l'occasione è persa.", "No melee attack: the chance is gone.");
		public static string VttFeatureUses(LanguageCode lang) => T(lang, "Privilegi da usare", "Features to use");
		public static string VttFeatureSlot(int slot, LanguageCode lang) => slot switch
		{
			1 => T(lang, "Azione", "Action"),
			2 => T(lang, "Azione bonus", "Bonus action"),
			3 => T(lang, "Reazione", "Reaction"),
			_ => T(lang, "Libero", "Free")
		};
		public static string VttFeatureLeft(int left, int most, LanguageCode lang) => T(lang, $"{left}/{most} rimasti", $"{left}/{most} left");
		public static string VttFeatureAmount(LanguageCode lang) => T(lang, "Quanti punti", "How many points");
		public static string VttFeatureUse(LanguageCode lang) => T(lang, "Usa", "Use");
		public static string VttFeatureUsed(string name, LanguageCode lang) => T(lang, $"{name}: usato.", $"{name}: used.");
		public static string VttFeatureHealed(string name, int value, LanguageCode lang) => T(lang, $"{name}: +{value} punti ferita.", $"{name}: +{value} hit points.");
		public static string VttFeatureTemp(string name, int value, LanguageCode lang) => T(lang, $"{name}: {value} punti ferita temporanei.", $"{name}: {value} temporary hit points.");
		public static string VttDrawer(LanguageCode lang) => T(lang, "Pannello laterale", "Side panel");
		public static string VttPin(LanguageCode lang) => T(lang, "Blocca nel pannello laterale", "Pin to the side panel");
		public static string VttUnpin(LanguageCode lang) => T(lang, "Sblocca: torna sopra la mappa", "Unpin: back over the map");
		public static string VttMissed(LanguageCode lang) => T(lang, "Mancato", "Miss");
		public static string VttHit(LanguageCode lang) => T(lang, "Colpito", "Hit");
		public static string VttGroupInit(LanguageCode lang) => T(lang, "Un tiro di iniziativa per gruppo di nemici uguali", "One initiative roll per group of like enemies");
		public static string VttInitVertical(LanguageCode lang) => T(lang, "Ordine di iniziativa in verticale", "Initiative order vertical");
		public static string VttInitHorizontal(LanguageCode lang) => T(lang, "Ordine di iniziativa in orizzontale", "Initiative order horizontal");
		public static string VttWayBlocked(LanguageCode lang) => T(lang, "Muri o porte chiuse sbarrano la strada.", "Walls or closed doors are in the way.");
		public static string VttWayBlockedShort(LanguageCode lang) => T(lang, "Nessun passaggio", "No way through");

		// ----- The map editor -----
		public static string MapShownShort(LanguageCode lang) => T(lang, "Visibile ai giocatori", "Shown to the players");
		public static string MapHiddenShort(LanguageCode lang) => T(lang, "Non mostrata", "Not shown");
		public static string MapViewAs(LanguageCode lang) => T(lang, "Vista", "View");
		public static string MapViewEditor(LanguageCode lang) => T(lang, "Editor", "Editor");
		public static string MapViewPlayers(LanguageCode lang) => T(lang, "Vista giocatori", "Players' view");
		public static string MapBrushSelect(LanguageCode lang) => T(lang, "Seleziona", "Select");
		public static string MapBrushCell(LanguageCode lang) => T(lang, "Pennello", "Brush");
		public static string MapBrushBox(LanguageCode lang) => T(lang, "Rettangolo", "Box");
		public static string MapZoneName(string zone, LanguageCode lang) => zone switch
		{
			"walkable" => T(lang, "Camminabile", "Walkable"),
			"wall" => T(lang, "Muro", "Wall"),
			"difficult" => T(lang, "Difficile", "Difficult"),
			"door" => T(lang, "Porta", "Door"),
			"half" => T(lang, "Mezzo muro", "Low wall"),
			"three" => T(lang, "Copertura ¾", "¾ cover"),
			_ => T(lang, "Nebbia", "Fog")
		};
		public static string MapZoneTitle(string zone, LanguageCode lang) => zone switch
		{
			"walkable" => T(lang, "Zona camminabile", "Walkable ground"),
			"wall" => T(lang, "Muro o ostacolo", "Wall or obstacle"),
			"difficult" => T(lang, "Terreno difficile", "Difficult terrain"),
			"door" => T(lang, "Porta o passaggio", "Door or passage"),
			"half" => T(lang, "Mezza copertura", "Half cover"),
			"three" => T(lang, "Copertura tre quarti", "Three-quarters cover"),
			_ => T(lang, "Nebbia di guerra", "Fog of war")
		};
		public static string MapZoneHint(string zone, LanguageCode lang) => zone switch
		{
			"walkable" => T(lang, "Libera: cancella muri, terreno difficile e porte", "Free: clears walls, difficult terrain and doors"),
			"wall" => T(lang, "I PG non la attraversano: girano intorno a muri e colonne", "Characters cannot cross it: they go around walls and columns"),
			"difficult" => T(lang, "Ogni casella costa il doppio del movimento", "Every cell costs double movement"),
			"door" => T(lang, "Si passa, se la porta che ci sta sopra è aperta", "Passable, when the door token on it is open"),
			"half" => T(lang, "Muretto o barile: +2 alla CA di chi è dietro, si scavalca come terreno difficile", "Low wall or barrel: +2 AC behind it, crossed as difficult terrain"),
			"three" => T(lang, "Feritoia o tronco: +5 alla CA di chi è dietro, non si attraversa", "Arrow slit or trunk: +5 AC behind it, not crossed"),
			_ => T(lang, "Rivela o oscura le celle per i giocatori", "Reveals or covers the cells for the players")
		};
		public static string MapZoneCounts(int walls, int difficult, int doors, LanguageCode lang) => T(lang,
			$"Muri: {walls} · Difficili: {difficult} · Porte: {doors}", $"Walls: {walls} · Difficult: {difficult} · Doors: {doors}");
		public static string MapShowZones(LanguageCode lang) => T(lang, "Mostra i colori delle zone", "Show the zones' colours");
		public static string MapTabZones(LanguageCode lang) => T(lang, "Zone e nebbia", "Zones and fog");
		public static string MapTabGrid(LanguageCode lang) => T(lang, "Mappa e griglia", "Map and grid");
		public static string MapTabTokens(int count, LanguageCode lang) => T(lang, $"Segnalini ({count})", $"Tokens ({count})");
		public static string MapZonesTitle(LanguageCode lang) => T(lang, "Pennello delle zone", "Zone brush");
		public static string MapZonesHelp(LanguageCode lang) => T(lang,
			"Scegli una zona e dipingi le celle sulla mappa, una per una o con un rettangolo: il movimento dei giocatori ne tiene conto.",
			"Pick a zone and paint the cells on the map, one by one or with a box: the players' movement follows it.");
		public static string MapQuickTitle(LanguageCode lang) => T(lang, "Azioni rapide", "Quick actions");
		public static string MapWallEdge(LanguageCode lang) => T(lang, "Muri sul bordo", "Wall the edge");
		public static string MapAllWalkable(LanguageCode lang) => T(lang, "Tutto camminabile", "All walkable");
		public static string MapFogAll(LanguageCode lang) => T(lang, "Oscura tutta la mappa", "Cover the whole map");
		public static string MapRevealAll(LanguageCode lang) => T(lang, "Rivela tutta la mappa", "Reveal the whole map");
		public static string MapRulesTitle(LanguageCode lang) => T(lang, "Regole di movimento", "Movement rules");
		public static string MapBlockPlayers(LanguageCode lang) => T(lang, "I PG non attraversano muri e porte chiuse", "Characters do not cross walls and closed doors");
		public static string MapFogEnabled(LanguageCode lang) => T(lang, "Nebbia di guerra attiva", "Fog of war on");
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
			PropType.Stairs => T(lang, "Scale", "Stairs"),
			PropType.Portal => T(lang, "Portale", "Portal"),
			_ => T(lang, "Porta", "Door")
		};
		public static string PropStateName(PropType type, PropState state, LanguageCode lang) => (type, state) switch
		{
			(PropType.Item, _) => T(lang, "A terra", "On the ground"),
			(PropType.Stairs or PropType.Portal, PropState.Open) => T(lang, "Attivo", "Active"),
			(PropType.Stairs or PropType.Portal, PropState.Closed) => T(lang, "Inattivo", "Inactive"),
			(PropType.Stairs or PropType.Portal, PropState.Broken) => T(lang, "Distrutto", "Destroyed"),
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
			(PropType.Stairs or PropType.Portal, PropState.Open) => T(lang, "Disattiva", "Turn off"),
			(PropType.Stairs or PropType.Portal, _) => T(lang, "Attiva", "Turn on"),
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

		public static string MapReplaceImage(LanguageCode lang) => T(lang, "Sostituisci immagine", "Replace the picture");
		public static string VttGroundInfo(LanguageCode lang) => T(lang, "Apri la scheda dell'oggetto", "Open the item's card");
		public static string VttGroundNext(string who, LanguageCode lang) => T(lang, $"Accanto a <strong>{who}</strong> (entro 1,5 m)", $"Next to <strong>{who}</strong> (within 5 ft)");
		public static string VttGroundCost(LanguageCode lang) => T(lang, "Costa: l'azione del turno", "Costs: the action of the turn");
		public static string VttGroundWho(LanguageCode lang) => T(lang, "Chi lo prende", "Who takes it");
		public static string VttGroundPack(LanguageCode lang) => T(lang, "Metti nello zaino", "Put in the pack");
		public static string VttGroundWield(LanguageCode lang) => T(lang, "Prendi e impugna", "Take in hand");
		public static string VttGroundFar(string distance, LanguageCode lang) => T(lang, $"Troppo lontano per raccoglierlo ({distance})", $"Too far to pick it up ({distance})");
		public static string VttGroundNobody(LanguageCode lang) => T(lang, "Nessun tuo segnalino sulla mappa", "None of your tokens is on the map");
		public static string VttGroundFarHint(LanguageCode lang) => T(lang, "Muovi un tuo segnalino in una casella accanto (entro 1,5 m) per prenderlo.", "Move one of your tokens to a cell next to it (within 5 ft) to take it.");
		public static string VttTakenInHand(string who, LanguageCode lang) => T(lang, $"{who} lo impugna.", $"{who} takes it in hand.");
		public static string VttSheetReadOnly(LanguageCode lang) => T(lang, "Sola lettura", "Read only");
		public static string VttSheetReadOnlyHint(LanguageCode lang) => T(lang, "La scheda di un alleato: la vedi, non la usi.", "An ally's sheet: you see it, you do not use it.");
		public static string VttAimStart(string attack, LanguageCode lang) => T(lang, $"{attack}: scegli il bersaglio sulla mappa", $"{attack}: pick the target on the map");
		public static string VttAimHint(LanguageCode lang) => T(lang, "Clic su un bersaglio evidenziato (giallo: con svantaggio). Esc per annullare.", "Click a highlighted target (yellow: with disadvantage). Esc to cancel.");
		public static string VttMetamagicName(string key, LanguageCode lang) => key switch
		{
			"careful" => T(lang, "Incantesimo preciso", "Careful Spell"),
			"distant" => T(lang, "Incantesimo distante", "Distant Spell"),
			"empowered" => T(lang, "Incantesimo potenziato", "Empowered Spell"),
			"extended" => T(lang, "Incantesimo esteso", "Extended Spell"),
			"heightened" => T(lang, "Incantesimo intensificato", "Heightened Spell"),
			"quickened" => T(lang, "Incantesimo rapido", "Quickened Spell"),
			"seeking" => T(lang, "Incantesimo mirato", "Seeking Spell"),
			"subtle" => T(lang, "Incantesimo celato", "Subtle Spell"),
			"transmuted" => T(lang, "Incantesimo trasmutato", "Transmuted Spell"),
			_ => T(lang, "Incantesimo raddoppiato", "Twinned Spell")
		};
		public static string VttMetamagicHint(string key, LanguageCode lang) => key switch
		{
			"careful" => T(lang, "Scegli le creature che superano da sole il tiro salvezza (nessun danno se il successo dimezza)", "Choose the creatures that succeed on the save by themselves (no damage where a success halves it)"),
			"distant" => T(lang, "Gittata raddoppiata; a contatto diventa 9 metri", "Twice the range; a touch becomes 30 feet"),
			"empowered" => T(lang, "Ritira i dadi dei danni più bassi (fino al modificatore di Carisma)", "Reroll the lowest damage dice (up to the Charisma modifier)"),
			"heightened" => T(lang, "Un bersaglio ha svantaggio al tiro salvezza", "One target has disadvantage on the save"),
			"quickened" => T(lang, "Lanciato come azione bonus invece che come azione", "Cast as a bonus action instead of an action"),
			"seeking" => T(lang, "Se l'attacco manca, il d20 si ritira una volta", "If the attack misses, the d20 is rolled again once"),
			"transmuted" => T(lang, "Cambia il tipo di danni con un altro della lista", "Change the damage type to another of the list"),
			_ => string.Empty
		};
		public static string VttMetamagicCost(int cost, LanguageCode lang) => T(lang, $"{cost} PS", $"{cost} SP");
		public static string VttMetamagicPoints(int left, LanguageCode lang) => T(lang, $"Punti stregoneria: {left}", $"Sorcery Points: {left}");
		public static string VttCompanions(LanguageCode lang) => T(lang, "Evocazioni e cavalcature", "Summons and mounts");
		public static string VttSummonHint(LanguageCode lang) => T(lang, "Creatura da evocare (es. Gufo, Lupo)", "Creature to summon (e.g. Owl, Wolf)");
		public static string VttSummonShare(LanguageCode lang) => T(lang, "Agisce subito dopo di me", "Acts right after me");
		public static string VttSummon(LanguageCode lang) => T(lang, "Evoca", "Summon");
		public static string VttSummoned(string what, string who, LanguageCode lang) => T(lang, $"{what} compare accanto a {who}.", $"{what} appears next to {who}.");
		public static string VttSummonUnknown(string name, LanguageCode lang) => T(lang, $"Nessuna creatura del compendio si chiama «{name}».", $"No creature of the compendium is called “{name}”.");
		public static string VttDismiss(LanguageCode lang) => T(lang, "Congeda", "Dismiss");
		public static string VttMount(string mount, LanguageCode lang) => T(lang, $"Monta su {mount}", $"Mount {mount}");
		public static string VttMounted(string rider, string mount, LanguageCode lang) => T(lang, $"{rider} è in sella a {mount}: si muovono insieme.", $"{rider} rides {mount}: they move together.");
		public static string VttRiding(string mount, LanguageCode lang) => T(lang, $"In sella a {mount}", $"Riding {mount}");
		public static string VttDismount(LanguageCode lang) => T(lang, "Smonta", "Dismount");
		public static string VttAura(LanguageCode lang) => T(lang, "Aura", "Aura");
		public static string VttAuraLine(string name, string reach, bool enemies, LanguageCode lang) =>
			T(lang, $"{name}: {reach} attorno, {(enemies ? "solo i nemici" : "ogni creatura")}", $"{name}: {reach} around, {(enemies ? "enemies only" : "every creature")}");
		public static string VttAuraName(LanguageCode lang) => T(lang, "Nome (es. Aura di protezione)", "Name (e.g. Aura of Protection)");
		public static string VttAuraRadius(LanguageCode lang) => T(lang, "Raggio in caselle", "Radius in cells");
		public static string VttAuraEnemies(LanguageCode lang) => T(lang, "Solo i nemici", "Enemies only");
		public static string VttAuraAdd(LanguageCode lang) => T(lang, "Aggiungi l'aura", "Add the aura");
		public static string VttAuraRemove(LanguageCode lang) => T(lang, "Togli l'aura", "Remove the aura");
		public static string VttAuraSet(string name, string who, LanguageCode lang) => T(lang, $"«{name}» si muove con {who}: chi entra o inizia il turno dentro viene segnalato.", $"“{name}” moves with {who}: whoever enters it or starts a turn in it is told.");
		public static string VttConnection(int state, LanguageCode lang) => state switch
		{
			0 => T(lang, "In linea", "Online"),
			1 => T(lang, "Riconnessione…", "Reconnecting…"),
			_ => T(lang, "Disconnesso", "Offline")
		};
		public static string VttConnectionLive(LanguageCode lang) => T(lang, "Collegato al tavolo: le mosse arrivano subito", "Connected to the table: moves arrive at once");
		public static string VttConnectionRetry(LanguageCode lang) => T(lang, "Il server non ha risposto: nuovo tentativo in corso", "The server did not answer: trying again");
		public static string VttConnectionLost(DateTime since, LanguageCode lang) => T(lang,
			$"Nessun contatto dalle {since:HH:mm:ss}: le mosse fatte ora potrebbero non arrivare. Il tavolo si aggiorna da solo appena torna la rete",
			$"No contact since {since:HH:mm:ss}: moves made now may not get through. The table updates itself as soon as the network is back");
		public static string VttTravel(string who, LanguageCode lang) => T(lang, $"Passa: {who}", $"Go through: {who}");
		public static string VttTravelHint(LanguageCode lang) => T(lang, "Avvicina una tua creatura per passare", "Bring one of your creatures next to it to go through");
		public static string VttTravelled(string who, string where, LanguageCode lang) => T(lang, $"{who} è arrivato: {where}.", $"{who} arrived: {where}.");
		public static string VttTravelShown(LanguageCode lang) => T(lang, "Il tavolo dei giocatori ora mostra questa mappa.", "The players' table now shows this map.");
		public static string VttTravelGo(string map, LanguageCode lang) => T(lang, $"Apri «{map}»", $"Open “{map}”");
		public static string VttTravelFailed(string? reason, LanguageCode lang) => reason switch
		{
			"inactive" => T(lang, "Non è attivo.", "It is not active."),
			"far" => T(lang, "Troppo lontano: avvicinati.", "Too far: get next to it."),
			"turn" => T(lang, "Non è il suo turno.", "It is not its turn."),
			"nowhere" => T(lang, "Non porta ancora da nessuna parte.", "It leads nowhere yet."),
			"full" => T(lang, "Non c'è spazio dall'altra parte.", "There is no room at the other end."),
			_ => T(lang, "Non si passa.", "It cannot be crossed.")
		};
		public static string ToolLink(LanguageCode lang) => T(lang, "Collega", "Link");
		public static string VttLinkTo(LanguageCode lang) => T(lang, "Porta a", "Leads to");
		public static string VttLinkNone(LanguageCode lang) => T(lang, "Da nessuna parte", "Nowhere");
		public static string VttLinkBoth(LanguageCode lang) => T(lang, "Anche al ritorno", "Both ways");
		public static string VttLinkEmpty(LanguageCode lang) => T(lang, "Aggiungi altre scale o un altro portale (anche su un'altra mappa) per collegarli.", "Add other stairs or another portal (on another map too) to link them.");
		public static string VttMonsterDrawer(LanguageCode lang) => T(lang, "Cassetto mostri", "Monster drawer");
		public static string VttDrawerHint(LanguageCode lang) => T(lang, "Cerca un mostro e premi il cassetto accanto per raccoglierne più copie, poi piazzale insieme o salvale come gruppo", "Search a monster and press the drawer next to it to gather several, then place them together or save them as a group");
		public static string VttDrawerAdd(LanguageCode lang) => T(lang, "Metti nel cassetto", "Put in the drawer");
		public static string VttDrawerHidden(LanguageCode lang) => T(lang, "Piazza nascosti ai giocatori", "Place hidden from the players");
		public static string VttDrawerPlace(int count, LanguageCode lang) => T(lang, $"Piazza {count} al centro della vista", $"Place {count} in the middle of the view");
		public static string VttDrawerClear(LanguageCode lang) => T(lang, "Svuota", "Empty");
		public static string VttGroupName(LanguageCode lang) => T(lang, "Nome del gruppo (es. Pattuglia goblin)", "Group name (e.g. Goblin patrol)");
		public static string VttGroupSave(LanguageCode lang) => T(lang, "Salva gruppo", "Save group");
		public static string VttGroups(LanguageCode lang) => T(lang, "Gruppi salvati", "Saved groups");
		public static string VttGroupsShow(LanguageCode lang) => T(lang, "Mostra i gruppi salvati", "Show the saved groups");
		public static string VttGroupPlace(LanguageCode lang) => T(lang, "Piazza il gruppo al centro della vista", "Place the group in the middle of the view");
		public static string VttGroupEdit(LanguageCode lang) => T(lang, "Apri nel cassetto", "Open in the drawer");
		public static string VttGroupDelete(LanguageCode lang) => T(lang, "Elimina il gruppo", "Delete the group");
		public static string VttPlaced(int count, LanguageCode lang) => T(lang, count == 1 ? "Piazzato 1 mostro." : $"Piazzati {count} mostri.", count == 1 ? "1 monster placed." : $"{count} monsters placed.");
		public static string VttNoRoom(LanguageCode lang) => T(lang, "Non c'è spazio libero sulla mappa.", "There is no free room on the map.");
		public static string VttUndo(int left, LanguageCode lang) => left > 0
			? T(lang, $"Annulla l'ultima modifica (Ctrl+Z) · {left} disponibili", $"Undo the last edit (Ctrl+Z) · {left} left")
			: T(lang, "Niente da annullare", "Nothing to undo");
		public static string VttNothingToUndo(LanguageCode lang) => T(lang, "Niente da annullare su questa mappa.", "Nothing to undo on this map.");
		public static string VttUndone(string kind, LanguageCode lang) => kind switch
		{
			MapUndoKinds.Shapes => T(lang, "Annullata l'ultima modifica ai disegni.", "The last edit of the drawings was undone."),
			MapUndoKinds.Terrain => T(lang, "Annullata l'ultima modifica al terreno.", "The last edit of the terrain was undone."),
			MapUndoKinds.Fog => T(lang, "Annullata l'ultima modifica alla nebbia.", "The last edit of the fog was undone."),
			_ => T(lang, "Annullata l'ultima modifica ai token.", "The last edit of the tokens was undone.")
		};
		public static string VttLighting(LanguageCode lang) => T(lang, "Luce e visione", "Light and vision");
		public static string VttLightingName(MapLighting lighting, LanguageCode lang) => lighting switch
		{
			MapLighting.Dim => T(lang, "Penombra", "Dim light"),
			MapLighting.Dark => T(lang, "Buio", "Darkness"),
			_ => T(lang, "Luce piena", "Bright light")
		};
		public static string VttDynamicVision(LanguageCode lang) => T(lang, "Visione dinamica", "Dynamic vision");
		public static string VttVisionPreview(LanguageCode lang) => T(lang, "Guarda come i PG", "See as the characters");
		public static string VttLightingHint(LanguageCode lang) => T(lang,
			"Con la visione dinamica ogni giocatore vede solo ciò che vedono le sue creature: muri e porte chiuse bloccano la vista, al buio servono luci o scurovisione",
			"With dynamic vision each player sees only what their creatures see: walls and closed doors block the sight, in the dark it takes a light or darkvision");
		public static string VttLightAndSight(LanguageCode lang) => T(lang, "Luce e vista", "Light and sight");
		public static string VttLightLine(string name, string bright, string dim, LanguageCode lang) => T(lang,
			$"{name}: luce intensa {bright}, fioca per altri {dim}", $"{name}: bright light {bright}, dim for another {dim}");
		public static string VttNoLight(LanguageCode lang) => T(lang, "Nessuna luce", "No light");
		public static string VttDarkvisionLine(string range, LanguageCode lang) => T(lang, $"scurovisione {range}", $"darkvision {range}");
		public static string VttNoDarkvision(LanguageCode lang) => T(lang, "senza scurovisione", "no darkvision");
		public static string VttDarkvision(LanguageCode lang) => T(lang, "Scurovisione", "Darkvision");
		public static string VttFromSheet(LanguageCode lang) => T(lang, "dalla scheda", "from the sheet");
		public static string VttDarkvisionSave(LanguageCode lang) => T(lang, "Imposta", "Set");
		public static string VttLightPreset(string key, LanguageCode lang) => key switch
		{
			"candle" => T(lang, "Candela", "Candle"),
			"torch" => T(lang, "Torcia", "Torch"),
			"lantern" => T(lang, "Lanterna", "Lantern"),
			"light" => T(lang, "Luce", "Light"),
			"bullseye" => T(lang, "Lanterna a lente", "Bullseye lantern"),
			"daylight" => T(lang, "Luce diurna", "Daylight"),
			_ => T(lang, "Nessuna", "None")
		};
		public static string VttGrapple(LanguageCode lang) => T(lang, "Lotta", "Grapple");
		public static string VttGrappleHint(LanguageCode lang) => T(lang, "Uno degli attacchi dell'azione Attacco: afferra una creatura a portata, che poi si muove con te (a velocità dimezzata)", "One of the attacks of the Attack action: grapple a creature in reach, which then moves with you (at half speed)");
		public static string VttShove(LanguageCode lang) => T(lang, "Spinta", "Shove");
		public static string VttShoveHint(LanguageCode lang) => T(lang, "Uno degli attacchi dell'azione Attacco: spingi via di 1,5 m o butta a terra una creatura a portata", "One of the attacks of the Attack action: push a creature in reach 5 feet away or knock it prone");
		public static string VttShoveKind(string kind, LanguageCode lang) => kind == "prone" ? T(lang, "A terra", "Prone") : T(lang, "Spingi via", "Push away");
		public static string VttGrappledBy(string who, LanguageCode lang) => T(lang, $"Afferrato da {who}: velocità 0", $"Grappled by {who}: speed 0");
		public static string VttHolding(string who, LanguageCode lang) => T(lang, $"Stai afferrando {who}: si muove con te, a velocità dimezzata", $"Grappling {who}: it moves with you, at half speed");
		public static string VttEscape(LanguageCode lang) => T(lang, "Liberati", "Escape");
		public static string VttEscapeHint(LanguageCode lang) => T(lang, "Usa l'azione: Atletica o Acrobazia per liberarti", "Takes the action: Athletics or Acrobatics to escape");
		public static string VttLetGo(LanguageCode lang) => T(lang, "Lascia la presa", "Let go");
		public static string VttGrappledMove(LanguageCode lang) => T(lang, "Afferrato: non può muoversi finché non si libera.", "Grappled: it cannot move until it escapes.");
		public static string VttReadyOther(LanguageCode lang) => T(lang, "Altro", "Something else");
		public static string VttReadyWhat(LanguageCode lang) => T(lang, "Cosa prepari", "What is readied");
		public static string VttReadyTriggerHint(LanguageCode lang) => T(lang, "Innesco: es. «quando il goblin esce dal muro»", "Trigger: e.g. “when the goblin steps out of the wall”");
		public static string VttReadyGo(LanguageCode lang) => T(lang, "Prepara", "Ready");
		public static string VttReadySpell(LanguageCode lang) => T(lang, "Prepara come reazione", "Ready as a reaction");
		public static string VttReadySpellHint(LanguageCode lang) => T(lang, "Un incantesimo si prepara dalla sua scheda: lo slot si spende subito e lo tieni con la concentrazione.", "A spell is readied from its tab: the slot is spent now and you hold it with concentration.");
		public static string VttReadyNeedsTrigger(LanguageCode lang) => T(lang, "Scrivi l'innesco dell'azione preparata.", "Write the trigger of the readied action.");
		public static string VttReadied(string what, string trigger, LanguageCode lang) => T(lang, $"«{what}» preparato: {trigger}", $"“{what}” readied: {trigger}");
		public static string VttReadyBadge(string what, string trigger, LanguageCode lang) => T(lang, $"Preparato: {what} · quando {trigger}", $"Readied: {what} · when {trigger}");
		public static string VttReadyFired(string who, string what, string trigger, LanguageCode lang) => T(lang, $"{who}: innesco scattato ({trigger}) → {what}", $"{who}: the trigger came ({trigger}) → {what}");
		public static string VttReadyTrigger(LanguageCode lang) => T(lang, "Innesca", "Trigger");
		public static string VttReadyRelease(LanguageCode lang) => T(lang, "Usa (reazione)", "Use (reaction)");
		public static string VttReadyDrop(LanguageCode lang) => T(lang, "Lascia", "Let it go");
		public static string VttReadyReleased(string what, LanguageCode lang) => T(lang, $"«{what}» usato con la reazione.", $"“{what}” used with the reaction.");
		public static string VttSpellsGone(LanguageCode lang) => T(lang, "Azione e azione bonus di questo turno sono già usate", "The action and the bonus action of this turn are used");
		public static string VttMetamagicNoPoints(LanguageCode lang) => T(lang, "Punti stregoneria insufficienti.", "Not enough Sorcery Points.");
		public static string VttMetamagic(LanguageCode lang) => T(lang, "Metamagia", "Metamagic");
		public static string VttSculpt(LanguageCode lang) => T(lang, "Scolpire incantesimi", "Sculpt Spells");
		public static string VttSculptHint(LanguageCode lang) => T(lang, "Gli alleati scelti superano il tiro salvezza e non subiscono danni", "The allies chosen succeed on the save and take no damage");
		public static string VttProtect(int most, LanguageCode lang) => T(lang, $"Proteggi (fino a {most})", $"Protect (up to {most})");
		public static string VttConfirmAttack(LanguageCode lang) => T(lang, "Conferma l'attacco", "Confirm the attack");
		public static string VttConfirmSpell(LanguageCode lang) => T(lang, "Conferma l'incantesimo", "Confirm the spell");
		public static string VttConfirm(LanguageCode lang) => T(lang, "Conferma", "Confirm");
		public static string VttTargets(LanguageCode lang) => T(lang, "Bersagli", "Targets");
		public static string VttDamageType(LanguageCode lang) => T(lang, "Tipo di danni", "Damage type");
		public static string VttSavesAsked(string spell, string save, int? damage, LanguageCode lang) =>
			T(lang, $"«{spell}»: {save}{(damage is { } d ? $", {d} danni" : string.Empty)}. I bersagli tirano il tiro salvezza.", $"“{spell}”: {save}{(damage is { } d2 ? $", {d2} damage" : string.Empty)}. The targets roll their save.");
		public static string VttSavesTitle(LanguageCode lang) => T(lang, "Tiri salvezza da fare", "Saving throws to make");
		public static string VttSaveRoll(LanguageCode lang) => T(lang, "Tira", "Roll");
		public static string VttSaveRollMine(LanguageCode lang) => T(lang, "Tira per le mie creature", "Roll for my creatures");
		public static string VttSaveMade(LanguageCode lang) => T(lang, "Superato", "Made");
		public static string VttSaveFailed(LanguageCode lang) => T(lang, "Fallito", "Failed");
		public static string VttSaveDismiss(LanguageCode lang) => T(lang, "Chiudi i tiri salvezza rimasti", "Close the saves left");
		public static string VttSaveProtected(LanguageCode lang) => T(lang, "protetto", "protected");
		public static string VttSaveDisadvantage(LanguageCode lang) => T(lang, "svantaggio", "disadvantage");
		public static string VttSaveDamage(int damage, string? type, bool half, LanguageCode lang) =>
			T(lang, $"{damage} danni{(type is null ? string.Empty : " " + type)}{(half ? " (metà se superato)" : string.Empty)}", $"{damage}{(type is null ? string.Empty : " " + type)} damage{(half ? " (half on a success)" : string.Empty)}");
		public static string VttSaveDealt(int dealt, LanguageCode lang) => T(lang, $"{dealt} danni", $"{dealt} damage");
		public static string VttNoRestInFight(LanguageCode lang) => T(lang, "Durante un incontro non si riposa.", "No rest during an encounter.");
		public static string VttNotYourTurn(LanguageCode lang) => T(lang, "Non è il suo turno: in combattimento ci si muove solo nel proprio turno.", "Not its turn: in a fight a creature moves only on its own turn.");
		public static string VttTurnReset(LanguageCode lang) => T(lang, "Ridai il turno", "Give the turn back");
		public static string VttTurnResetHint(LanguageCode lang) => T(lang, "Azione, azione bonus, reazione e movimento di questo turno tornano disponibili", "Action, bonus action, reaction and movement of this turn are available again");
		public static string VttAimWall(LanguageCode lang) => T(lang, "Il bersaglio è dietro un muro: non lo raggiungi da qui.", "The target is behind a wall: you cannot reach it from here.");
		public static string VttSaveDc(string ability, int dc, LanguageCode lang) => T(lang, $"TS {ability} CD {dc}", $"{ability} save DC {dc}");
		public static string VttSpellSave(string spell, string target, string save, LanguageCode lang) => T(lang, $"«{spell}» su {target}: {save}. Il master tira il tiro salvezza e applica il danno.", $"“{spell}” on {target}: {save}. The master rolls the save and applies the damage.");
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
