using RealmForge.Shared.Enums;
using RealmForge.Shared.Localization;
using RealmForge.Shared.Rules;

namespace RealmForge.Shared.Characters;

///	<summary>
///	A problem found in a character: blocking ones stop the save (choices against the rules), the others are choices
///	still to make (a subclass, an Ability Score Improvement, fewer spells than allowed…).
///	</summary>
public sealed record CharacterIssue(string Code, bool Blocking, string Area, IReadOnlyList<string> Args)
{
	public override string ToString() => Args.Count == 0 ? Code : $"{Code} ({string.Join(", ", Args)})";
}

///	<summary>
///	The character input: the header columns and the rules choices, plus the sheet state for the values it affects
///	(equipped armor, adjustments).
///	</summary>
public sealed class CharacterInput
{
	public string Name { get; set; } = string.Empty;
	public RulesetVersion Ruleset { get; set; } = RulesetVersion.Dnd5e_2024;
	public Guid SpeciesId { get; set; }
	public Guid? SubspeciesId { get; set; }
	public Guid BackgroundId { get; set; }
	public CharacterBuild Build { get; set; } = new();
	public CharacterSheetState Sheet { get; set; } = new();

	//	Rule modules of the campaigns the character plays in (they apply besides the ones of the build)
	public List<Guid> CampaignModuleIds { get; set; } = new();
}

public sealed record ClassLevelInfo(ContextClass Class, ContextSubclass? Subclass, int Level, CharacterClassBuild Build, bool Starting);

///	<summary>
///	What happens at one character level: the class and its level, and the choices it opens.
///	</summary>
public sealed record LevelPlanEntry(
	int Level,
	ContextClass Class,
	int ClassLevel,
	bool NewClass,
	bool Improvement,
	bool EpicBoon,
	bool SubclassChoice,
	int HitDie);

public sealed record TakenFeat(ContextFeat Feat, string Source, FeatChoice Choice);

public sealed record SpellcastingInfo(
	string Source,
	ClassLevelInfo? Class,
	AbilityScore Ability,
	int SaveDc,
	int AttackBonus,
	SpellcastingClass? SpellList,
	int Cantrips,
	int Spells,
	int MaxSpellLevel,
	IReadOnlyList<Guid> ChosenCantrips,
	IReadOnlyList<Guid> ChosenSpells,
	IReadOnlyList<Guid>? AlwaysPrepared = null)
{
	//	Spells of the subclass and of the features, always prepared (domain, oath, circle, patron spells…)
	public IReadOnlyList<Guid> Always => AlwaysPrepared ?? Array.Empty<Guid>();

	//	Every spell of the source: chosen and always prepared
	public IEnumerable<Guid> Known => ChosenCantrips.Concat(ChosenSpells).Concat(Always).Distinct();
}

///	<summary>
///	A spell a trait gives (species, subclass, feat): cantrips at will, leveled spells once per long rest without a slot.
///	</summary>
public sealed record InnateSpellInfo(string Source, ContextSpell Spell, AbilityScore Ability, int SaveDc, int AttackBonus);

public sealed record AttackInfo(Guid InventoryId, ContextItem Item, int AttackBonus, string Damage, DamageType? DamageType, bool Proficient, string? VersatileDamage);

public sealed class ComputedCharacter
{
	public required RulesetVersion Ruleset { get; init; }
	public ContextSpecies? Species { get; init; }
	public ContextSubspecies? Subspecies { get; init; }
	public ContextBackground? Background { get; init; }

	public List<CharacterIssue> Issues { get; } = new();
	public bool CanSave => Issues.All(i => !i.Blocking);

	public int Level { get; set; }
	public List<ClassLevelInfo> Classes { get; } = new();
	public List<LevelPlanEntry> Plan { get; } = new();

	public int[] BaseScores { get; set; } = new int[6];
	public int[] OriginBonuses { get; set; } = new int[6];
	public int[] LevelBonuses { get; set; } = new int[6];
	public int[] FinalScores { get; set; } = new int[6];
	public int Modifier(AbilityScore ability) => CharacterMath.Modifier(FinalScores[(int)ability - 1]);
	public int Score(AbilityScore ability) => FinalScores[(int)ability - 1];

	public int ProficiencyBonus { get; set; }

	public int MaxHitPoints { get; set; }
	public List<(int Die, int Count)> HitDice { get; } = new();

	public ArmorTraining ArmorTraining { get; set; }
	public bool MartialWeapons { get; set; }

	public int ArmorClass { get; set; }
	public ContextItem? WornArmor { get; set; }
	public ContextItem? Shield { get; set; }
	public UnarmoredDefense UnarmoredDefense { get; set; }

	public int Initiative { get; set; }
	public int Speed { get; set; }
	public int PassivePerception { get; set; }
	public bool JackOfAllTrades { get; set; }

	public HashSet<AbilityScore> SaveProficiencies { get; } = new();
	public int SaveBonusAll { get; set; }
	public HashSet<Skill> SkillProficiencies { get; } = new();
	public HashSet<Skill> Expertise { get; } = new();

	public List<string> FixedLanguages { get; } = new();
	public int LanguageChoices { get; set; }
	public List<string> Languages { get; } = new();

	public List<TakenFeat> Feats { get; } = new();

	public List<SpellcastingInfo> Spellcasting { get; } = new();
	public int[] SpellSlots { get; set; } = new int[9];
	public int PactSlots { get; set; }
	public int PactSlotLevel { get; set; }

	public List<AttackInfo> Attacks { get; } = new();

	public int SaveBonus(AbilityScore ability) =>
		Modifier(ability) + (SaveProficiencies.Contains(ability) ? ProficiencyBonus : 0) + SaveBonusAll + SaveBonusOne[(int)ability - 1];

	// ----- Homebrew rule modules -----

	//	Effects of the active modules with the module they come from, the abilities they add, the extra training
	public List<(RuleEffect Effect, string Module)> ModuleEffects { get; set; } = new();
	public List<ContextModule> Modules { get; set; } = new();
	public List<ExtraAbilityScore> ExtraAbilities { get; } = new();
	public int[] SaveBonusOne { get; } = new int[6];
	public Dictionary<Skill, int> SkillBonusExtra { get; } = new();
	public HashSet<string> ExtraTools { get; } = new(StringComparer.OrdinalIgnoreCase);

	//	Base scores, origin and level increases of the added abilities while the calculator runs (by key)
	internal Dictionary<string, int> ExtraRunning { get; } = new(StringComparer.OrdinalIgnoreCase);
	internal Dictionary<string, int> ExtraLevelBonus { get; } = new(StringComparer.OrdinalIgnoreCase);

	public int ModuleSum(RuleEffectKind kind) => ModuleEffects.Where(e => e.Effect.Kind == kind).Sum(e => e.Effect.Value);

	public ExtraAbilityScore? Extra(string? key) => key is null ? null : ExtraAbilities.FirstOrDefault(a => string.Equals(a.Key, key, StringComparison.OrdinalIgnoreCase));

	//	Bonus to every ability check (magic items) and the damage types resisted thanks to items
	public int CheckBonusAll { get; set; }
	public List<DamageType> Resistances { get; } = new();

	//	Senses and speeds of the traits (feet; 0: none)
	public int Darkvision { get; set; }
	public int Blindsight { get; set; }
	public int Truesight { get; set; }
	public int ClimbSpeed { get; set; }
	public int SwimSpeed { get; set; }
	public int FlySpeed { get; set; }
	public List<DamageType> Immunities { get; } = new();

	//	Heavy Armor Master: bludgeoning, piercing and slashing damage reduced by this much
	public int DamageReduction { get; set; }
	public BreathWeapon? Breath { get; set; }
	public List<InnateSpellInfo> InnateSpells { get; } = new();

	//	Weapons known by name besides the categories (2014 dwarven and elven weapon training)
	public HashSet<string> ExtraWeapons { get; } = new(StringComparer.OrdinalIgnoreCase);

	//	Bonus to the checks of one ability (2024 Fey Wanderer: Wisdom to Charisma checks), and the abilities whose
	//	checks get half the Proficiency Bonus rounded up when not proficient (2014 Remarkable Athlete)
	public int[] AbilityCheckBonus { get; } = new int[6];
	public HashSet<AbilityScore> RemarkableAthlete { get; } = new();

	//	Ability check without a skill: modifier, Jack of All Trades / Remarkable Athlete, bonuses
	public int AbilityCheck(AbilityScore ability) => Modifier(ability) + HalfProficiency(ability) + AbilityCheckBonus[(int)ability - 1] + CheckBonusAll;

	private int HalfProficiency(AbilityScore ability) =>
		RemarkableAthlete.Contains(ability) ? (ProficiencyBonus + 1) / 2 : JackOfAllTrades ? ProficiencyBonus / 2 : 0;

	public int SkillBonus(Skill skill) => SkillBase(skill) + CheckBonusAll + AbilityCheckBonus[(int)GameTerms.SkillAbility(skill) - 1] + SkillBonusExtra.GetValueOrDefault(skill);

	private int SkillBase(Skill skill)
	{
		var mod = Modifier(GameTerms.SkillAbility(skill));
		if (Expertise.Contains(skill))
		{
			return mod + 2 * ProficiencyBonus;
		}
		if (SkillProficiencies.Contains(skill))
		{
			return mod + ProficiencyBonus;
		}

		return mod + HalfProficiency(GameTerms.SkillAbility(skill));
	}

	public int ClassLevel(string key) => Classes.Where(c => c.Class.Key == key).Sum(c => c.Level);

	///	<summary>
	///	The spellcasting sources and, as sources without a class, the spells of the traits grouped by where they come
	///	from (species, subclass, a feat): what the sheet, the turn summary and the PDF list.
	///	</summary>
	public IEnumerable<SpellcastingInfo> AllSpellSources()
	{
		foreach (var source in Spellcasting)
		{
			yield return source;
		}
		foreach (var group in InnateSpells.GroupBy(s => (s.Source, s.Ability)))
		{
			var first = group.First();
			var cantrips = group.Where(s => s.Spell.Level == 0).Select(s => s.Spell.Id).ToList();
			var leveled = group.Where(s => s.Spell.Level > 0).Select(s => s.Spell.Id).ToList();
			yield return new SpellcastingInfo(group.Key.Source, null, group.Key.Ability, first.SaveDc, first.AttackBonus, null,
				cantrips.Count, leveled.Count, group.Max(s => s.Spell.Level), cantrips, leveled);
		}
	}

	public void Error(string code, params object?[] args) => Add(code, true, IssueAreas.Of(code), args);

	public void Todo(string code, params object?[] args) => Add(code, false, IssueAreas.Of(code), args);

	public void ErrorIn(string area, string code, params object?[] args) => Add(code, true, area, args);

	public void TodoIn(string area, string code, params object?[] args) => Add(code, false, area, args);

	private void Add(string code, bool blocking, string area, object?[] args) =>
		Issues.Add(new CharacterIssue(code, blocking, area, args.Select(a => a?.ToString() ?? string.Empty).ToList()));
}

///	<summary>
///	Wizard step where an issue is fixed.
///	</summary>
public static class IssueAreas
{
	public const string Identity = "identity";
	public const string Species = "species";
	public const string Class = "class";
	public const string Background = "background";
	public const string Abilities = "abilities";
	public const string Progression = "progression";
	public const string Languages = "languages";
	public const string Equipment = "equipment";
	public const string Spells = "spells";

	public static string OfSource(string source) => source switch
	{
		"origin" => Background,
		"species" => Species,
		_ => Progression
	};

	public static string Of(string code) => code switch
	{
		IssueCodes.Name or IssueCodes.Level => Identity,
		IssueCodes.Species or IssueCodes.Subspecies or IssueCodes.SubspeciesMissing or IssueCodes.Size or IssueCodes.SpeciesFeatMissing
			or IssueCodes.SpeciesOption or IssueCodes.SpeciesOptionMissing => Species,
		IssueCodes.Background => Background,
		IssueCodes.Class => Class,
		IssueCodes.BaseScores or IssueCodes.ScoreCap => Abilities,
		IssueCodes.Languages or IssueCodes.LanguagesMissing => Languages,
		IssueCodes.Spells or IssueCodes.CantripsMissing or IssueCodes.SpellsMissing => Spells,
		IssueCodes.Equipment => Equipment,
		_ => Progression
	};
}
