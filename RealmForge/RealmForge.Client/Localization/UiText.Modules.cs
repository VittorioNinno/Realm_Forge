using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using RealmForge.Shared.Localization;

namespace RealmForge.Client.Localization
{
	///	<summary>
	///	Texts of the Homebrew rule modules and of the rule effects (the editor and the sentences that describe them).
	///	</summary>
	public static partial class UiText
	{
		public static string ModulesTitle(LanguageCode lang) => T(lang, "Moduli di regole", "Rule modules");
		public static string ModulesSubtitle(LanguageCode lang) => T(lang,
			"Regole della casa fatte di dati: una caratteristica in più, una risorsa, bonus, competenze e difese che la scheda calcola da sola",
			"House rules made of data: an extra ability, a resource, bonuses, training and defences the sheet works out on its own");
		public static string ModulesIntro(LanguageCode lang) => T(lang,
			"Un modulo vale per i personaggi che lo scelgono nella creazione, e per tutti i personaggi delle campagne con cui lo condividi (una volta approvato dal master).",
			"A module applies to the characters that pick it when they are created, and to every character of the campaigns you share it with (once the master approves it).");
		public static string BtnAddModule(LanguageCode lang) => T(lang, "Nuovo modulo", "New module");
		public static string ModulesLoading(LanguageCode lang) => T(lang, "Caricamento dei moduli...", "Loading the modules...");
		public static string ModulesEmpty(LanguageCode lang) => T(lang,
			"Nessun modulo ancora. Crea il primo: ad esempio la caratteristica Fortuna, con i suoi punti che si ricaricano col riposo lungo.",
			"No modules yet. Create the first one: for instance the Luck ability, with its points that come back on a long rest.");
		public static string ModuleEditTitle(bool edit, LanguageCode lang) => edit ? T(lang, "Modifica il modulo", "Edit the module") : T(lang, "Nuovo modulo di regole", "New rule module");
		public static string ModuleNamePlaceholderIt(LanguageCode lang) => T(lang, "Es. Fortuna", "e.g. Fortuna");
		public static string ModuleNamePlaceholderEn(LanguageCode lang) => T(lang, "Es. Luck", "e.g. Luck");
		public static string BtnSaveModule(LanguageCode lang) => T(lang, "SALVA MODULO", "SAVE MODULE");
		public static string ModuleEffectsTitle(LanguageCode lang) => T(lang, "Effetti", "Effects");
		public static string ModuleNoEffects(LanguageCode lang) => T(lang, "Nessun effetto: il modulo non cambia la scheda.", "No effects: the module does not change the sheet.");
		public static string ModuleSaved(LanguageCode lang) => T(lang, "Modulo salvato.", "Module saved.");
		public static string ModuleDeleteWarning(string name, LanguageCode lang) => T(lang,
			$"Eliminare «{name}»? I personaggi che lo usano perdono i suoi effetti; resta nel cestino per qualche giorno.",
			$"Delete “{name}”? The characters using it lose its effects; it stays in the bin for a few days.");
		public static string ModuleEffectCount(int count, LanguageCode lang) => lang == LanguageCode.It
			? count == 1 ? "1 effetto" : $"{count} effetti"
			: count == 1 ? "1 effect" : $"{count} effects";
		public static string ModuleError(string? code, LanguageCode lang) => code switch
		{
			"TooManyEffects" => T(lang, $"Al massimo {RuleEffectRules.MaxEffects} effetti per modulo.", $"At most {RuleEffectRules.MaxEffects} effects per module."),
			"ExtraAbility" => T(lang, $"Al massimo {RuleEffectRules.MaxExtraAbilities} caratteristiche nuove, ognuna con un nome diverso.", $"At most {RuleEffectRules.MaxExtraAbilities} new abilities, each with its own name."),
			"Ability" => T(lang, "Scegli la caratteristica di ogni effetto.", "Pick the ability of each effect."),
			"Skill" => T(lang, "Scegli l'abilità di ogni effetto.", "Pick the skill of each effect."),
			"Text" => T(lang, "Scrivi cosa addestra o insegna ogni effetto (arma, armatura, strumento, lingua).", "Write what each effect trains or teaches (weapon, armor, tool, language)."),
			"DamageType" => T(lang, "Scegli il tipo di danno di ogni resistenza o immunità.", "Pick the damage type of each resistance or immunity."),
			"Value" => T(lang, "Un valore è fuori dai limiti (usi da 1 a 50, valore nell'array da 3 a 18, scurovisione fino a 90 m).", "A value is out of range (uses 1 to 50, array value 3 to 18, darkvision up to 300 ft)."),
			"Name" => T(lang, "Dai un nome a ogni caratteristica e risorsa.", "Name every ability and resource."),
			_ => T(lang, "Un effetto non è valido.", "An effect is not valid.")
		};

		public static string WizardModulesHint(LanguageCode lang) => T(lang,
			"Regole della casa da applicare a questo personaggio. Chiedi al master quali usa il tavolo.",
			"House rules to apply to this character. Ask the master which ones the table uses.");
		public static string WizardModuleFromCampaign(LanguageCode lang) => T(lang, "dalla campagna", "from the campaign");
		public static string SheetModulesTitle(LanguageCode lang) => T(lang, "Regole della casa", "House rules");

		public static string EffectsOnSheet(int count, LanguageCode lang) => T(lang, $"Effetti sulla scheda ({count})", $"Effects on the sheet ({count})");
		public static string EffectsOnSheetTitle(LanguageCode lang) => T(lang, "Sulla scheda", "On the sheet");
		public static string EffectsOnSheetHint(LanguageCode lang) => T(lang,
			"Quello che la scheda calcola da sola per chi lo usa: il testo resta descrittivo, i numeri vengono da qui.",
			"What the sheet works out on its own for whoever uses it: the text stays descriptive, the numbers come from here.");

		//	Editor
		public static string EffectAdd(LanguageCode lang) => T(lang, "Aggiungi effetto", "Add effect");
		public static string EffectKindLabel(LanguageCode lang) => T(lang, "Effetto", "Effect");
		public static string EffectValueLabel(LanguageCode lang) => T(lang, "Valore", "Value");
		public static string EffectLevelLabel(LanguageCode lang) => T(lang, "Dal livello", "From level");
		public static string EffectAbilityLabel(LanguageCode lang) => T(lang, "Caratteristica", "Ability");
		public static string EffectSkillLabel(LanguageCode lang) => T(lang, "Abilità", "Skill");
		public static string EffectDamageLabel(LanguageCode lang) => T(lang, "Tipo di danno", "Damage type");
		public static string EffectWeaponLabel(LanguageCode lang) => T(lang, "Armi", "Weapons");
		public static string EffectWeaponOther(LanguageCode lang) => T(lang, "Un'arma (nome inglese)", "A weapon (English name)");
		public static string EffectArmorLabel(LanguageCode lang) => T(lang, "Armature", "Armor");
		public static string EffectToolLabel(LanguageCode lang) => T(lang, "Strumento", "Tool");
		public static string EffectLanguageLabel(LanguageCode lang) => T(lang, "Lingua", "Language");
		public static string EffectNameIt(LanguageCode lang) => T(lang, "Nome (italiano)", "Name (Italian)");
		public static string EffectNameEn(LanguageCode lang) => T(lang, "Nome (inglese)", "Name (English)");
		public static string EffectShortIt(LanguageCode lang) => T(lang, "Sigla IT", "Short IT");
		public static string EffectShortEn(LanguageCode lang) => T(lang, "Sigla EN", "Short EN");
		public static string EffectArrayValue(LanguageCode lang) => T(lang, "Valore nell'array", "Array value");
		public static string EffectArrayHint(LanguageCode lang) => T(lang,
			"Si aggiunge ai valori della serie standard; col point buy aggiunge i punti indicati, coi dadi si tira come le altre.",
			"It joins the standard array; with point buy it adds the points below, with dice it is rolled like the others.");
		public static string EffectPoints(LanguageCode lang) => T(lang, "Punti in più (point buy)", "Extra points (point buy)");
		public static string EffectHasSave(LanguageCode lang) => T(lang, "Ha un tiro salvezza", "Has a saving throw");
		public static string EffectUsesLabel(LanguageCode lang) => T(lang, "Usi", "Uses");
		public static string EffectResetLabel(LanguageCode lang) => T(lang, "Si ricarica", "Comes back");
		public static string EffectSpeedUnit(LanguageCode lang) => T(lang, "metri", "feet");
		public static string EffectRemove(LanguageCode lang) => T(lang, "Rimuovi", "Remove");

		public static string EffectGroup(int group, LanguageCode lang) => group switch
		{
			1 => T(lang, "Bonus +N", "+N bonus"),
			2 => T(lang, "Competenze", "Training"),
			3 => T(lang, "Difese e sensi", "Defences and senses"),
			_ => T(lang, "Caratteristiche e risorse", "Abilities and resources")
		};

		public static int EffectGroupOf(RuleEffectKind kind) => (int)kind switch
		{
			< 20 => 1,
			< 30 => 2,
			< 40 => 3,
			_ => 4
		};

		public static string EffectKindName(RuleEffectKind kind, LanguageCode lang) => kind switch
		{
			RuleEffectKind.ArmorClass => T(lang, "+N alla Classe Armatura", "+N to Armor Class"),
			RuleEffectKind.SavingThrows => T(lang, "+N a tutti i tiri salvezza", "+N to all saving throws"),
			RuleEffectKind.AbilityChecks => T(lang, "+N a tutte le prove di caratteristica", "+N to all ability checks"),
			RuleEffectKind.Initiative => T(lang, "+N all'Iniziativa", "+N to Initiative"),
			RuleEffectKind.Speed => T(lang, "+N alla velocità", "+N to Speed"),
			RuleEffectKind.MaxHitPoints => T(lang, "+N ai punti ferita massimi", "+N to hit point maximum"),
			RuleEffectKind.MaxHitPointsPerLevel => T(lang, "+N punti ferita massimi per livello", "+N hit point maximum per level"),
			RuleEffectKind.SpellAttack => T(lang, "+N al tiro per colpire degli incantesimi", "+N to spell attacks"),
			RuleEffectKind.SpellSaveDc => T(lang, "+N alla CD degli incantesimi", "+N to spell save DC"),
			RuleEffectKind.AbilityScore => T(lang, "+N a un punteggio di caratteristica", "+N to an ability score"),
			RuleEffectKind.Skill => T(lang, "+N a un'abilità", "+N to a skill"),
			RuleEffectKind.SavingThrow => T(lang, "+N a un tiro salvezza", "+N to one saving throw"),
			RuleEffectKind.SkillProficiency => T(lang, "Competenza in un'abilità", "Skill proficiency"),
			RuleEffectKind.Expertise => T(lang, "Maestria in un'abilità", "Skill expertise"),
			RuleEffectKind.SaveProficiency => T(lang, "Competenza in un tiro salvezza", "Saving throw proficiency"),
			RuleEffectKind.WeaponTraining => T(lang, "Addestramento nelle armi", "Weapon training"),
			RuleEffectKind.ArmorTraining => T(lang, "Addestramento nelle armature", "Armor training"),
			RuleEffectKind.ToolProficiency => T(lang, "Competenza in uno strumento", "Tool proficiency"),
			RuleEffectKind.Language => T(lang, "Una lingua", "A language"),
			RuleEffectKind.Resistance => T(lang, "Resistenza a un tipo di danno", "Damage resistance"),
			RuleEffectKind.Immunity => T(lang, "Immunità a un tipo di danno", "Damage immunity"),
			RuleEffectKind.Darkvision => T(lang, "Scurovisione", "Darkvision"),
			RuleEffectKind.ExtraAbility => T(lang, "Una caratteristica in più", "An extra ability score"),
			RuleEffectKind.Resource => T(lang, "Una risorsa con usi che si ricaricano", "A resource with uses that come back"),
			_ => kind.ToString()
		};

		public static string EffectUsesName(ResourceUses uses, LanguageCode lang) => uses switch
		{
			ResourceUses.AbilityModifier => T(lang, "Modificatore di caratteristica + N", "Ability modifier + N"),
			ResourceUses.ProficiencyBonus => T(lang, "Bonus di competenza + N", "Proficiency bonus + N"),
			ResourceUses.CharacterLevel => T(lang, "Livello del personaggio + N", "Character level + N"),
			_ => T(lang, "Numero fisso", "Fixed number")
		};

		public static string EffectArmorName(string text, LanguageCode lang) => text switch
		{
			"light" => T(lang, "armature leggere", "light armor"),
			"medium" => T(lang, "armature medie", "medium armor"),
			"heavy" => T(lang, "armature pesanti", "heavy armor"),
			"shield" => T(lang, "scudi", "shields"),
			_ => text
		};

		public static string EffectWeaponName(string text, LanguageCode lang) => text switch
		{
			"simple" => T(lang, "armi semplici", "simple weapons"),
			"martial" => T(lang, "armi da guerra", "martial weapons"),
			_ => text
		};

		//	Distances: stored in feet, shown in metres in Italian (5 ft = 1,5 m)
		public static string Distance(int feet, LanguageCode lang) => lang == LanguageCode.It
			? $"{(feet * 0.3m).ToString("0.#", System.Globalization.CultureInfo.GetCultureInfo("it-IT"))} m"
			: $"{feet} ft";

		private static string Signed(int value) => value >= 0 ? $"+{value}" : $"−{-value}";

		///	<summary>
		///	One effect as a sentence ("+2 all'Iniziativa", "Resistenza ai danni da fuoco", "Nuova caratteristica: Fortuna (FRT)").
		///	The added abilities of the same list name the ability keys.
		///	</summary>
		public static string EffectText(RuleEffect e, IEnumerable<RuleEffect>? siblings, LanguageCode lang)
		{
			var it = lang == LanguageCode.It;
			string Ability()
			{
				if (e.Ability is { } a && Enum.IsDefined(a))
				{
					return FeatPrerequisiteFormatter.AbilityName(a, lang);
				}
				var extra = siblings?.FirstOrDefault(x => x.Kind == RuleEffectKind.ExtraAbility && string.Equals(x.Key, e.AbilityKey, StringComparison.OrdinalIgnoreCase));
				return extra?.Name(lang) ?? e.AbilityKey ?? "?";
			}
			var skill = e.Skill is { } s ? GameTerms.SkillName(s, lang) : "?";
			var damage = e.DamageType is { } d ? EquipmentTerms.DamageTypeName(d, lang) : "?";
			var text = e.Kind switch
			{
				RuleEffectKind.ArmorClass => T(lang, $"{Signed(e.Value)} alla Classe Armatura", $"{Signed(e.Value)} to Armor Class"),
				RuleEffectKind.SavingThrows => T(lang, $"{Signed(e.Value)} a tutti i tiri salvezza", $"{Signed(e.Value)} to all saving throws"),
				RuleEffectKind.AbilityChecks => T(lang, $"{Signed(e.Value)} a tutte le prove di caratteristica", $"{Signed(e.Value)} to all ability checks"),
				RuleEffectKind.Initiative => T(lang, $"{Signed(e.Value)} all'Iniziativa", $"{Signed(e.Value)} to Initiative"),
				RuleEffectKind.Speed => T(lang, $"{(e.Value >= 0 ? "+" : "−")}{Distance(Math.Abs(e.Value), lang)} alla velocità", $"{(e.Value >= 0 ? "+" : "−")}{Distance(Math.Abs(e.Value), lang)} to Speed"),
				RuleEffectKind.MaxHitPoints => T(lang, $"{Signed(e.Value)} ai punti ferita massimi", $"{Signed(e.Value)} to hit point maximum"),
				RuleEffectKind.MaxHitPointsPerLevel => T(lang, $"{Signed(e.Value)} punti ferita massimi per livello", $"{Signed(e.Value)} hit point maximum per level"),
				RuleEffectKind.SpellAttack => T(lang, $"{Signed(e.Value)} al tiro per colpire degli incantesimi", $"{Signed(e.Value)} to spell attacks"),
				RuleEffectKind.SpellSaveDc => T(lang, $"{Signed(e.Value)} alla CD degli incantesimi", $"{Signed(e.Value)} to spell save DC"),
				RuleEffectKind.AbilityScore => T(lang, $"{Signed(e.Value)} a {Ability()}", $"{Signed(e.Value)} to {Ability()}"),
				RuleEffectKind.Skill => T(lang, $"{Signed(e.Value)} a {skill}", $"{Signed(e.Value)} to {skill}"),
				RuleEffectKind.SavingThrow => T(lang, $"{Signed(e.Value)} ai tiri salvezza su {Ability()}", $"{Signed(e.Value)} to {Ability()} saving throws"),
				RuleEffectKind.SkillProficiency => T(lang, $"Competenza in {skill}", $"Proficiency in {skill}"),
				RuleEffectKind.Expertise => T(lang, $"Maestria in {skill}", $"Expertise in {skill}"),
				RuleEffectKind.SaveProficiency => T(lang, $"Competenza nei tiri salvezza su {Ability()}", $"Proficiency in {Ability()} saving throws"),
				RuleEffectKind.WeaponTraining => T(lang, $"Addestramento: {EffectWeaponName(e.Text ?? "?", lang)}", $"Training: {EffectWeaponName(e.Text ?? "?", lang)}"),
				RuleEffectKind.ArmorTraining => T(lang, $"Addestramento: {EffectArmorName(e.Text ?? "?", lang)}", $"Training: {EffectArmorName(e.Text ?? "?", lang)}"),
				RuleEffectKind.ToolProficiency => T(lang, $"Competenza: {e.Text}", $"Proficiency: {e.Text}"),
				RuleEffectKind.Language => T(lang, $"Lingua: {e.Text}", $"Language: {e.Text}"),
				RuleEffectKind.Resistance => T(lang, $"Resistenza ai danni {damage}", $"Resistance to {damage} damage"),
				RuleEffectKind.Immunity => T(lang, $"Immunità ai danni {damage}", $"Immunity to {damage} damage"),
				RuleEffectKind.Darkvision => T(lang, $"Scurovisione {Distance(e.Value, lang)}", $"Darkvision {Distance(e.Value, lang)}"),
				RuleEffectKind.ExtraAbility => T(lang, $"Nuova caratteristica: {e.Name(lang)} ({e.Short(lang)})", $"New ability score: {e.Name(lang)} ({e.Short(lang)})")
					+ (e.Save ? T(lang, ", con tiro salvezza", ", with a saving throw") : string.Empty),
				RuleEffectKind.Resource => T(lang, $"Risorsa: {e.Name(lang)}, {UsesText(e, Ability, lang)}, si ricarica con {ResetText(e.Reset, lang)}",
					$"Resource: {e.Name(lang)}, {UsesText(e, Ability, lang)}, comes back on {ResetText(e.Reset, lang)}"),
				_ => e.Kind.ToString()
			};
			return e.Level > 1 ? text + T(lang, $" (dal {e.Level}° livello)", $" (from level {e.Level})") : text;
		}

		private static string UsesText(RuleEffect e, Func<string> ability, LanguageCode lang)
		{
			var plus = e.Value == 0 ? string.Empty : $" {Signed(e.Value)}";
			return e.Uses switch
			{
				ResourceUses.AbilityModifier => T(lang, $"usi pari al modificatore di {ability()}{plus}", $"uses equal to the {ability()} modifier{plus}"),
				ResourceUses.ProficiencyBonus => T(lang, $"usi pari al bonus di competenza{plus}", $"uses equal to the proficiency bonus{plus}"),
				ResourceUses.CharacterLevel => T(lang, $"usi pari al livello{plus}", $"uses equal to the level{plus}"),
				_ => T(lang, e.Value == 1 ? "1 uso" : $"{e.Value} usi", e.Value == 1 ? "1 use" : $"{e.Value} uses")
			};
		}

		private static string ResetText(ResourceReset reset, LanguageCode lang) => reset switch
		{
			ResourceReset.ShortRest => ResetShortRest(lang),
			ResourceReset.OneOnShortRest => ResetOneOnShortRest(lang),
			_ => ResetLongRest(lang)
		};
	}
}
