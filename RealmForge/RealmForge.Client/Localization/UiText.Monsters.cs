using RealmForge.Shared.Campaigns;
using RealmForge.Shared.Enums;
using RealmForge.Shared.Monsters;

namespace RealmForge.Client.Localization
{
	///	<summary>
	///	Texts of the monsters compendium, of the statblock and of the campaign encounters.
	///	</summary>
	public static partial class UiText
	{
		// ===== Compendium =====

		public static string MonstersTitle(LanguageCode lang) => T(lang, "Mostri", "Monsters");
		public static string MonstersSubtitle(LanguageCode lang) =>
			T(lang, "Statistiche pronte per gli incontri, varianti e creature Homebrew", "Statblocks ready for encounters, variants and Homebrew creatures");
		public static string LoadingMonsters(LanguageCode lang) => T(lang, "Caricamento mostri...", "Loading monsters...");
		public static string NoMonstersFound(LanguageCode lang) => T(lang, "Nessun mostro trovato.", "No monsters found.");
		public static string MonsterCount(int count, LanguageCode lang) => lang == LanguageCode.It
			? (count == 1 ? "1 mostro" : $"{count} mostri")
			: (count == 1 ? "1 monster" : $"{count} monsters");
		public static string PlaceholderSearchMonsters(LanguageCode lang) => T(lang, "Nome o tipo...", "Name or type...");
		public static string BtnNewMonster(LanguageCode lang) => T(lang, "Nuovo mostro", "New monster");
		public static string BtnCreateVariant(LanguageCode lang) => T(lang, "Crea variante", "Create variant");
		public static string BtnShowMore(int remaining, LanguageCode lang) => T(lang, $"Mostra altri ({remaining})", $"Show more ({remaining})");
		public static string SortByName(LanguageCode lang) => T(lang, "Per nome", "By name");
		public static string SortByChallenge(LanguageCode lang) => T(lang, "Per grado di sfida", "By challenge");
		public static string FilterAllTypes(LanguageCode lang) => T(lang, "Tutti i tipi", "All types");
		public static string FilterAllSizes(LanguageCode lang) => T(lang, "Tutte le taglie", "All sizes");
		public static string MonsterChallengeFrom(LanguageCode lang) => T(lang, "Sfida da", "Challenge from");
		public static string MonsterChallengeTo(LanguageCode lang) => T(lang, "Sfida fino a", "Challenge up to");
		public static string MonsterVariant(LanguageCode lang) => T(lang, "Variante", "Variant");
		public static string MonsterAuthor(string name, LanguageCode lang) => T(lang, $"Creato da {name}", $"Made by {name}");
		public static string MonsterDeleteWarning(string name, LanguageCode lang) =>
			T(lang, $"Eliminare «{name}»? Le varianti create da questo mostro restano, senza il collegamento; potrai recuperarlo dal cestino per 3 giorni.",
				$"Delete “{name}”? The variants made from this monster stay, without the link; you can restore it from the bin for 3 days.");
		public static string MonsterVariantName(string name, LanguageCode lang) => T(lang, $"{name} (variante)", $"{name} (variant)");
		public static string MonsterVariantHint(string original, LanguageCode lang) =>
			T(lang, $"Variante di «{original}»: una copia Homebrew da modificare liberamente, l'originale resta com'è.",
				$"Variant of “{original}”: a Homebrew copy you can change freely, the original stays as it is.");

		// ===== Statblock =====

		public static string MonsterSize(LanguageCode lang) => T(lang, "Taglia", "Size");
		public static string MonsterType(LanguageCode lang) => T(lang, "Tipo", "Type");
		public static string MonsterArmorClass(LanguageCode lang) => T(lang, "Classe Armatura", "Armor Class");
		public static string MonsterArmorClassShort(LanguageCode lang) => T(lang, "CA", "AC");
		public static string MonsterHitPoints(LanguageCode lang) => T(lang, "Punti Ferita", "Hit Points");
		public static string MonsterHitPointsShort(LanguageCode lang) => T(lang, "PF", "HP");
		public static string MonsterHitDice(LanguageCode lang) => T(lang, "Dadi Vita", "Hit dice");
		public static string MonsterSpeed(LanguageCode lang) => T(lang, "Velocità", "Speed");
		public static string MonsterSpeedFeet(LanguageCode lang) => T(lang, "Velocità (piedi)", "Speed (feet)");
		public static string MonsterSavingThrows(LanguageCode lang) => T(lang, "Tiri Salvezza", "Saving Throws");
		public static string MonsterSkills(LanguageCode lang) => T(lang, "Abilità", "Skills");
		public static string MonsterVulnerabilities(LanguageCode lang) => T(lang, "Vulnerabilità ai Danni", "Damage Vulnerabilities");
		public static string MonsterResistances(LanguageCode lang) => T(lang, "Resistenze ai Danni", "Damage Resistances");
		public static string MonsterImmunities(LanguageCode lang) => T(lang, "Immunità ai Danni", "Damage Immunities");
		public static string MonsterConditionImmunities(LanguageCode lang) => T(lang, "Immunità alle Condizioni", "Condition Immunities");
		public static string MonsterSenses(LanguageCode lang) => T(lang, "Sensi", "Senses");
		public static string MonsterLanguages(LanguageCode lang) => T(lang, "Linguaggi", "Languages");
		public static string MonsterChallenge(LanguageCode lang) => T(lang, "Sfida", "Challenge");
		public static string MonsterChallengeShort(LanguageCode lang) => T(lang, "GS", "CR");
		public static string MonsterProficiency(LanguageCode lang) => T(lang, "Bonus di competenza", "Proficiency Bonus");
		public static string MonsterProficiencyShort(LanguageCode lang) => T(lang, "Comp.", "Prof.");
		public static string MonsterXpShort(LanguageCode lang) => T(lang, "PE", "XP");
		public static string XpLabel(LanguageCode lang) => T(lang, "PE", "XP");
		public static string MonsterPassivePerception(LanguageCode lang) => T(lang, "Percezione passiva", "Passive Perception");
		public static string MonsterPassiveShort(LanguageCode lang) => T(lang, "Perc. pass.", "Passive");
		public static string MonsterTraits(LanguageCode lang) => T(lang, "Tratti", "Traits");
		public static string MonsterActions(LanguageCode lang) => T(lang, "Azioni", "Actions");
		public static string MonsterBonusActions(LanguageCode lang) => T(lang, "Azioni bonus", "Bonus Actions");
		public static string MonsterReactions(LanguageCode lang) => T(lang, "Reazioni", "Reactions");
		public static string MonsterLegendaryActions(LanguageCode lang) => T(lang, "Azioni leggendarie", "Legendary Actions");
		public static string MonsterDescription(LanguageCode lang) => T(lang, "Descrizione", "Description");

		// ===== Editor =====

		public static string MonsterAlias(LanguageCode lang) => T(lang, "Altro nome (facoltativo)", "Other name (optional)");
		public static string MonsterSubtitle(LanguageCode lang) => T(lang, "Taglia, tipo e allineamento", "Size, type and alignment");
		public static string MonsterSubtitleHint(LanguageCode lang) => T(lang, "Umanoide Medio (goblinoide), neutrale malvagio", "Medium humanoid (goblinoid), neutral evil");
		public static string MonsterArmorHint(LanguageCode lang) => T(lang, "15 (armatura di cuoio, scudo)", "15 (leather armor, shield)");
		public static string MonsterSpeedHint(LanguageCode lang) => T(lang, "9 m, scalare 6 m", "30 ft., climb 20 ft.");
		public static string MonsterEntriesHint(LanguageCode lang) =>
			T(lang, "Una voce per paragrafo, nella forma «***Nome.*** testo» (riga vuota tra le voci). Markdown ammesso.",
				"One entry per paragraph, written as “***Name.*** text” (a blank line between entries). Markdown allowed.");
		public static string MonsterNameMissing(LanguageCode lang) => T(lang, "Serve almeno un nome (in italiano o in inglese).", "At least one name is needed (Italian or English).");
		public static string MonsterInvalid(LanguageCode lang) =>
			T(lang, "Alcuni valori non sono validi: controlla caratteristiche (1-30), CA, punti ferita e lunghezza dei testi.",
				"Some values are not valid: check abilities (1-30), AC, hit points and the length of the texts.");

		// ===== Encounters =====

		public static string CampaignTabEncounters(LanguageCode lang) => T(lang, "Incontri", "Encounters");
		public static string EncountersHintMaster(LanguageCode lang) =>
			T(lang, "Prepara gli incontri con i mostri del compendio e i personaggi della campagna, controlla la difficoltà e gestisci iniziativa, punti ferita e condizioni. Mostra un incontro in corso per farlo seguire ai giocatori.",
				"Prepare encounters with the compendium's monsters and the campaign's characters, check their difficulty and run initiative, hit points and conditions. Show an encounter under way to let the players follow it.");
		public static string EncountersHintPlayer(LanguageCode lang) =>
			T(lang, "Qui compaiono gli incontri in corso che i master hanno reso visibili.", "The encounters under way that the masters made visible show up here.");
		public static string EncountersEmpty(LanguageCode lang) => T(lang, "Nessun incontro.", "No encounters.");
		public static string EncounterNew(LanguageCode lang) => T(lang, "Nuovo incontro", "New encounter");
		public static string EncounterNamePlaceholder(LanguageCode lang) => T(lang, "Imboscata al ponte", "Ambush at the bridge");
		public static string BtnCreate(LanguageCode lang) => T(lang, "Crea", "Create");
		public static string EncountersBack(LanguageCode lang) => T(lang, "Incontri", "Encounters");
		public static string EncounterNotFound(LanguageCode lang) => T(lang, "Incontro non disponibile.", "Encounter not available.");
		public static string EncounterName(LanguageCode lang) => T(lang, "Nome dell'incontro", "Encounter name");
		public static string EncounterStatusName(EncounterStatus status, LanguageCode lang) => status switch
		{
			EncounterStatus.Running => T(lang, "In corso", "Under way"),
			EncounterStatus.Finished => T(lang, "Concluso", "Finished"),
			_ => T(lang, "In preparazione", "Planned")
		};
		public static string EncounterRound(int round, LanguageCode lang) => T(lang, $"Round {round}", $"Round {round}");
		public static string EncounterMonsterCount(int count, LanguageCode lang) => lang == LanguageCode.It
			? (count == 1 ? "1 mostro" : $"{count} mostri")
			: (count == 1 ? "1 monster" : $"{count} monsters");
		public static string EncounterShownShort(LanguageCode lang) => T(lang, "visibile", "shown");
		public static string EncounterStart(LanguageCode lang) => T(lang, "Inizia il combattimento", "Start the fight");
		public static string EncounterNextTurn(LanguageCode lang) => T(lang, "Turno successivo", "Next turn");
		public static string EncounterFinish(LanguageCode lang) => T(lang, "Concludi", "Finish");
		public static string EncounterReopen(LanguageCode lang) => T(lang, "Riporta in preparazione", "Back to planning");
		public static string EncounterShown(LanguageCode lang) => T(lang, "Visibile ai giocatori", "Shown to players");
		public static string EncounterHidden(LanguageCode lang) => T(lang, "Nascosto ai giocatori", "Hidden from players");
		public static string EncounterShownHint(LanguageCode lang) =>
			T(lang, "Quando è in corso, i giocatori vedono l'ordine di iniziativa, le condizioni e lo stato dei mostri (non i loro punti ferita).",
				"While it is under way, the players see the initiative order, the conditions and how hurt the monsters look (not their hit points).");
		public static string EncounterDifficulty(LanguageCode lang) => T(lang, "Difficoltà", "Difficulty");
		public static string EncounterNoCharacters(LanguageCode lang) =>
			T(lang, "Nessun personaggio nella campagna: la difficoltà si calcola sui personaggi del gruppo.", "No characters in the campaign: the difficulty is computed on the party's characters.");
		public static string EncounterRating(RulesetVersion ruleset, int rating, LanguageCode lang) => ruleset == RulesetVersion.Dnd5e_2014
			? rating switch
			{
				0 => T(lang, "Banale", "Trivial"),
				1 => T(lang, "Facile", "Easy"),
				2 => T(lang, "Medio", "Medium"),
				3 => T(lang, "Difficile", "Hard"),
				_ => T(lang, "Mortale", "Deadly")
			}
			: rating switch
			{
				0 => T(lang, "Sotto il budget basso", "Below the low budget"),
				1 => T(lang, "Basso", "Low"),
				2 => T(lang, "Moderato", "Moderate"),
				_ => T(lang, "Alto", "High")
			};
		public static string EncounterXpLine(int total, double multiplier, int adjusted, RulesetVersion ruleset, LanguageCode lang)
		{
			var xp = XpLabel(lang);
			return ruleset == RulesetVersion.Dnd5e_2014
				? T(lang, $"{MonsterMath.Thousands(total, lang)} {xp} × {multiplier:0.#} = {MonsterMath.Thousands(adjusted, lang)} {xp} adattati",
					$"{MonsterMath.Thousands(total, lang)} {xp} × {multiplier:0.#} = {MonsterMath.Thousands(adjusted, lang)} adjusted {xp}")
				: $"{MonsterMath.Thousands(total, lang)} {xp}";
		}
		public static string EncounterThresholds(RulesetVersion ruleset, int[] thresholds, LanguageCode lang)
		{
			var names = ruleset == RulesetVersion.Dnd5e_2014
				? new[] { T(lang, "facile", "easy"), T(lang, "medio", "medium"), T(lang, "difficile", "hard"), T(lang, "mortale", "deadly") }
				: new[] { T(lang, "basso", "low"), T(lang, "moderato", "moderate"), T(lang, "alto", "high") };
			return string.Join(" · ", thresholds.Select((t, i) => $"{names.ElementAtOrDefault(i)} {MonsterMath.Thousands(t, lang)}"));
		}
		public static string EncounterXpEach(int xp, LanguageCode lang) =>
			T(lang, $"{MonsterMath.Thousands(xp, lang)} PE a personaggio", $"{MonsterMath.Thousands(xp, lang)} XP per character");
		public static string EncounterCombatants(LanguageCode lang) => T(lang, "Ordine di iniziativa", "Initiative order");
		public static string EncounterNoCombatants(LanguageCode lang) => T(lang, "Ancora nessun partecipante.", "No combatants yet.");
		public static string EncounterRollInitiative(LanguageCode lang) => T(lang, "Tira l'iniziativa mancante", "Roll missing initiative");
		public static string EncounterInitiative(LanguageCode lang) => T(lang, "Iniziativa", "Initiative");
		public static string EncounterCurrentTurn(LanguageCode lang) => T(lang, "Tocca a lui", "Its turn");
		public static string EncounterStatblock(LanguageCode lang) => T(lang, "statistiche", "statblock");
		public static string EncounterStatblockMissing(LanguageCode lang) => T(lang, "Le statistiche di questo mostro non sono più disponibili.", "This monster's statblock is no longer available.");
		public static string EncounterDamage(LanguageCode lang) => T(lang, "Danni", "Damage");
		public static string EncounterHeal(LanguageCode lang) => T(lang, "Cura", "Heal");
		public static string EncounterTempHp(LanguageCode lang) => T(lang, "Punti ferita temporanei", "Temporary hit points");
		public static string EncounterHideHint(LanguageCode lang) => T(lang, "Nascondi ai giocatori (imboscata)", "Hide from the players (ambush)");
		public static string EncounterCondition(LanguageCode lang) => T(lang, "condizione", "condition");
		public static string EncounterAddMonsters(LanguageCode lang) => T(lang, "Aggiungi partecipanti", "Add combatants");
		public static string EncounterRollHp(LanguageCode lang) => T(lang, "Tira i punti ferita", "Roll hit points");
		public static string EncounterAddParty(LanguageCode lang) => T(lang, "Personaggi del gruppo", "Party characters");
		public static string EncounterOtherPlaceholder(LanguageCode lang) => T(lang, "Altro (PNG, trappola...)", "Other (NPC, trap...)");
		public static string EncounterNotes(LanguageCode lang) => T(lang, "Note dei master", "Masters' notes");
		public static string EncounterNotesHint(LanguageCode lang) => T(lang, "Tattiche, terreno, tesoro... (solo master e co-master)", "Tactics, terrain, treasure... (masters and co-masters only)");
		public static string EncounterDeleteConfirm(LanguageCode lang) => T(lang, "Elimina l'incontro", "Delete the encounter");
		public static string EncounterConflict(LanguageCode lang) =>
			T(lang, "Un altro master ha modificato l'incontro: è stato ricaricato, ripeti l'ultima modifica.", "Another master changed the encounter: it was reloaded, repeat your last change.");
		public static string EncounterTooMany(LanguageCode lang) =>
			T(lang, $"Al massimo {EncounterRules.MaxCombatants} partecipanti per incontro.", $"At most {EncounterRules.MaxCombatants} combatants per encounter.");

		public static string CombatantKindName(CombatantKind kind, LanguageCode lang) => kind switch
		{
			CombatantKind.Monster => T(lang, "Mostro", "Monster"),
			CombatantKind.Character => T(lang, "Personaggio", "Character"),
			_ => T(lang, "Altro", "Other")
		};

		public static string HealthName(CombatantHealth health, LanguageCode lang) => health switch
		{
			CombatantHealth.Unharmed => T(lang, "Illeso", "Unharmed"),
			CombatantHealth.Wounded => T(lang, "Ferito", "Wounded"),
			CombatantHealth.Bloodied => T(lang, "Malconcio", "Bloodied"),
			_ => T(lang, "A terra", "Down")
		};

		public static string ConditionName(string key, LanguageCode lang) => key switch
		{
			"blinded" => T(lang, "Accecato", "Blinded"),
			"charmed" => T(lang, "Affascinato", "Charmed"),
			"deafened" => T(lang, "Assordato", "Deafened"),
			"frightened" => T(lang, "Spaventato", "Frightened"),
			"grappled" => T(lang, "Afferrato", "Grappled"),
			"incapacitated" => T(lang, "Incapacitato", "Incapacitated"),
			"invisible" => T(lang, "Invisibile", "Invisible"),
			"paralyzed" => T(lang, "Paralizzato", "Paralyzed"),
			"petrified" => T(lang, "Pietrificato", "Petrified"),
			"poisoned" => T(lang, "Avvelenato", "Poisoned"),
			"prone" => T(lang, "Prono", "Prone"),
			"restrained" => T(lang, "Trattenuto", "Restrained"),
			"stunned" => T(lang, "Stordito", "Stunned"),
			"unconscious" => T(lang, "Privo di sensi", "Unconscious"),
			"exhaustion" => T(lang, "Indebolimento", "Exhaustion"),
			"concentrating" => T(lang, "Concentrazione", "Concentrating"),
			_ => key
		};
	}
}
