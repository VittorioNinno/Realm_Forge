using RealmForge.Shared.Enums;
using RealmForge.Shared.Rules;

namespace RealmForge.Shared.Characters;

///	<summary>
///	What a rule effect does. Written as data by Homebrew rule modules (and, later, by Homebrew feats, traits and
///	features), applied by the calculator: numbers (+N), training, defences and senses, an extra ability score, a
///	resource with uses.
///	</summary>
public enum RuleEffectKind
{
	//	+N to a value
	ArmorClass = 1,
	SavingThrows = 2,
	AbilityChecks = 3,
	Initiative = 4,
	Speed = 5,
	MaxHitPoints = 6,
	MaxHitPointsPerLevel = 7,
	SpellAttack = 8,
	SpellSaveDc = 9,
	AbilityScore = 10,
	Skill = 11,
	SavingThrow = 12,

	//	Training
	SkillProficiency = 20,
	Expertise = 21,
	SaveProficiency = 22,
	WeaponTraining = 23,
	ArmorTraining = 24,
	ToolProficiency = 25,
	Language = 26,

	//	Defences and senses
	Resistance = 30,
	Immunity = 31,
	Darkvision = 32,

	//	Building blocks of a module
	ExtraAbility = 40,
	Resource = 41
}

///	<summary>
///	How many uses a resource has.
///	</summary>
public enum ResourceUses
{
	Fixed = 1,
	AbilityModifier = 2,
	ProficiencyBonus = 3,
	CharacterLevel = 4
}

///	<summary>
///	One rule effect. Which fields count depends on the kind:
///	numbers: Value (and Ability or AbilityKey for AbilityScore / SavingThrow, Skill for Skill);
///	training: Skill, Ability / AbilityKey (save), Text (weapon "simple" / "martial" / a weapon's English name, armor
///	"light" / "medium" / "heavy" / "shield", a tool, a language);
///	defences: DamageType; Darkvision: Value in feet;
///	ExtraAbility: Key, NameIt / NameEn, ShortIt / ShortEn (three letters), Value = its value in the standard array
///	(default 10), Points = extra points for the point buy, Save = it has a saving throw;
///	Resource: NameIt / NameEn, Uses (with Value, Ability / AbilityKey), Reset.
///	Level: the character level from which it works (1 for modules).
///	</summary>
public sealed class RuleEffect
{
	public RuleEffectKind Kind { get; set; }
	public int Value { get; set; }
	public AbilityScore? Ability { get; set; }
	public string? AbilityKey { get; set; }
	public Skill? Skill { get; set; }
	public DamageType? DamageType { get; set; }
	public string? Text { get; set; }
	public int Level { get; set; } = 1;

	public string? Key { get; set; }
	public string? NameIt { get; set; }
	public string? NameEn { get; set; }
	public string? ShortIt { get; set; }
	public string? ShortEn { get; set; }
	public int Points { get; set; }
	public bool Save { get; set; }

	public ResourceUses Uses { get; set; } = ResourceUses.Fixed;
	public ResourceReset Reset { get; set; } = ResourceReset.LongRest;

	public string Name(LanguageCode lang) => (lang == LanguageCode.It ? NameIt ?? NameEn : NameEn ?? NameIt) ?? Key ?? string.Empty;

	public string Short(LanguageCode lang)
	{
		var value = lang == LanguageCode.It ? ShortIt ?? ShortEn : ShortEn ?? ShortIt;
		return string.IsNullOrWhiteSpace(value) ? Name(lang).Length >= 3 ? Name(lang)[..3].ToUpperInvariant() : Name(lang).ToUpperInvariant() : value;
	}
}

///	<summary>
///	A Homebrew rule module as the calculator sees it (the modules the user can read, see CharacterContextDto).
///	</summary>
public sealed record ContextModule(Guid Id, string Name, List<RuleEffect> Effects);

///	<summary>
///	An ability score added by a module (Fortuna): its definition (names, array value, saving throw), the final score
///	(base, increases, effects) and its saving throw.
///	</summary>
public sealed record ExtraAbilityScore(string Key, RuleEffect Definition, int Score, int Modifier, bool SaveProficient, int SaveBonus, string Module)
{
	public bool HasSave => Definition.Save;
}

///	<summary>
///	How the calculator uses the modules of a character: the active ones (chosen in the build, or of its campaigns),
///	their effects from the level they unlock at, the added abilities.
///	</summary>
public static class RuleModules
{
	public const int MaxScore = 30;

	public static void Activate(CharacterInput input, CharacterContextDto context, ComputedCharacter result)
	{
		var available = context.Modules ?? new List<ContextModule>();
		foreach (var id in input.Build.ModuleIds.Where(id => available.All(m => m.Id != id)))
		{
			result.Error(IssueCodes.Module, id.ToString());
		}
		var ids = input.Build.ModuleIds.Concat(input.CampaignModuleIds).ToHashSet();
		result.Modules = available.Where(m => ids.Contains(m.Id)).ToList();
		result.ModuleEffects = result.Modules
			.SelectMany(m => m.Effects.Where(e => e.Level <= result.Level).Select(e => (e, m.Name)))
			.ToList();

		//	The effects of the Homebrew the character uses: species and lineage, feats (from the character level), class
		//	and subclass features (from the class level)
		void From(IEnumerable<RuleEffect>? effects, string? source, int reach)
		{
			if (effects is not null)
			{
				result.ModuleEffects.AddRange(effects.Where(e => e.Level <= reach).Select(e => (e, source ?? string.Empty)));
			}
		}
		var build = input.Build;
		var species = context.Species.FirstOrDefault(s => s.Id == input.SpeciesId);
		From(species?.Effects, species?.Name, result.Level);
		var subspecies = species?.Subspecies.FirstOrDefault(s => s.Id == input.SubspeciesId);
		From(subspecies?.Effects, subspecies?.Name, result.Level);

		var originFeat = context.Backgrounds.FirstOrDefault(b => b.Id == input.BackgroundId)?.OriginFeatId;
		var feats = new[] { build.SpeciesFeatId, originFeat }
			.Concat(build.Levels.Select(l => l.FeatId))
			.Concat(build.Classes.Select(c => c.FightingStyleFeatId))
			.OfType<Guid>()
			.Distinct();
		foreach (var id in feats)
		{
			if (context.Feats.FirstOrDefault(f => f.Id == id) is { Effects: not null } feat)
			{
				From(feat.Effects, feat.Name, result.Level);
			}
		}

		foreach (var entry in build.Classes)
		{
			if (context.Classes.FirstOrDefault(c => c.Id == entry.ClassId) is not { } cls)
			{
				continue;
			}
			var classLevel = build.Levels.Count(l => l.ClassId == cls.Id);
			From(cls.Effects, cls.Name, classLevel);
			var subclass = cls.Subclasses.FirstOrDefault(s => s.Id == entry.SubclassId);
			From(subclass?.Effects, subclass?.Name, classLevel);
		}
	}

	///	<summary>
	///	The abilities added by the active modules, once each (the first module with a key wins), in module order.
	///	</summary>
	public static List<(RuleEffect Definition, string Module)> ExtraDefinitions(ComputedCharacter result) => result.ModuleEffects
		.Where(e => e.Effect.Kind == RuleEffectKind.ExtraAbility && !string.IsNullOrWhiteSpace(e.Effect.Key))
		.GroupBy(e => e.Effect.Key!.Trim().ToLowerInvariant())
		.Select(g => g.First())
		.ToList();

	///	<summary>
	///	Base scores of the added abilities from the build (10 when missing), validated with the six by the caller.
	///	</summary>
	public static List<int> ExtraBaseScores(CharacterBuild build, List<(RuleEffect Definition, string Module)> extras) => extras
		.Select(e => build.ExtraScores.FirstOrDefault(kv => string.Equals(kv.Key, e.Definition.Key, StringComparison.OrdinalIgnoreCase)) is { Key: not null } kv ? kv.Value : 10)
		.ToList();

	public static int ArrayValue(RuleEffect definition) => definition.Value is >= 3 and <= 18 ? definition.Value : 10;

	//	+N to one of the six scores
	public static void ApplyToScores(ComputedCharacter result, int[] running)
	{
		foreach (var (effect, _) in result.ModuleEffects.Where(e => e.Effect.Kind == RuleEffectKind.AbilityScore && e.Effect.Ability is { } a && Enum.IsDefined(a)))
		{
			var index = (int)effect.Ability!.Value - 1;
			running[index] = Math.Min(MaxScore, running[index] + effect.Value);
		}
	}

	//	The added abilities with their final score and saving throw
	public static void FinishExtras(ComputedCharacter result)
	{
		foreach (var (definition, module) in ExtraDefinitions(result))
		{
			var key = definition.Key!;
			var score = result.ExtraRunning.GetValueOrDefault(key, 10)
				+ result.ModuleEffects.Where(e => e.Effect.Kind == RuleEffectKind.AbilityScore && e.Effect.Ability is null && Is(e.Effect.AbilityKey, key)).Sum(e => e.Effect.Value);
			score = Math.Clamp(score, 1, MaxScore);
			var modifier = CharacterMath.Modifier(score);
			var proficient = result.ModuleEffects.Any(e => e.Effect.Kind == RuleEffectKind.SaveProficiency && Is(e.Effect.AbilityKey, key));
			var save = modifier + (proficient ? result.ProficiencyBonus : 0) + result.SaveBonusAll
				+ result.ModuleEffects.Where(e => e.Effect.Kind == RuleEffectKind.SavingThrow && Is(e.Effect.AbilityKey, key)).Sum(e => e.Effect.Value);
			result.ExtraAbilities.Add(new ExtraAbilityScore(key, definition, score, modifier, proficient, save, module));
		}
	}

	//	Training, per-save and per-skill bonuses, defences and senses
	public static void ApplyTraining(ComputedCharacter result)
	{
		foreach (var (e, _) in result.ModuleEffects)
		{
			switch (e.Kind)
			{
				case RuleEffectKind.SaveProficiency when e.Ability is { } a && Enum.IsDefined(a):
					result.SaveProficiencies.Add(a);
					break;
				case RuleEffectKind.SavingThrow when e.Ability is { } a && Enum.IsDefined(a):
					result.SaveBonusOne[(int)a - 1] += e.Value;
					break;
				case RuleEffectKind.SkillProficiency when e.Skill is { } skill:
					result.SkillProficiencies.Add(skill);
					break;
				case RuleEffectKind.Expertise when e.Skill is { } skill:
					result.SkillProficiencies.Add(skill);
					result.Expertise.Add(skill);
					break;
				case RuleEffectKind.Skill when e.Skill is { } skill:
					result.SkillBonusExtra[skill] = result.SkillBonusExtra.GetValueOrDefault(skill) + e.Value;
					break;
				case RuleEffectKind.WeaponTraining when e.Text is { } text:
					if (string.Equals(text, "martial", StringComparison.OrdinalIgnoreCase))
					{
						result.MartialWeapons = true;
					}
					else if (!string.Equals(text, "simple", StringComparison.OrdinalIgnoreCase))
					{
						result.ExtraWeapons.Add(text.Trim());
					}
					break;
				case RuleEffectKind.ArmorTraining when e.Text is { } text:
					result.ArmorTraining |= text.ToLowerInvariant() switch
					{
						"light" => ArmorTraining.Light,
						"medium" => ArmorTraining.Medium,
						"heavy" => ArmorTraining.Heavy,
						"shield" => ArmorTraining.Shield,
						_ => ArmorTraining.None
					};
					break;
				case RuleEffectKind.ToolProficiency when !string.IsNullOrWhiteSpace(e.Text):
					result.ExtraTools.Add(e.Text.Trim());
					break;
				case RuleEffectKind.Resistance when e.DamageType is { } damage && !result.Resistances.Contains(damage):
					result.Resistances.Add(damage);
					break;
				case RuleEffectKind.Immunity when e.DamageType is { } damage && !result.Immunities.Contains(damage):
					result.Immunities.Add(damage);
					break;
				case RuleEffectKind.Darkvision:
					result.Darkvision = Math.Max(result.Darkvision, e.Value);
					break;
			}
		}
		result.Resistances.RemoveAll(d => result.Immunities.Contains(d));
	}

	///	<summary>
	///	Uses of a module resource for this character (at least 1).
	///	</summary>
	public static int Uses(RuleEffect e, ComputedCharacter c) => Math.Max(1, e.Uses switch
	{
		ResourceUses.AbilityModifier when e.Ability is { } a && Enum.IsDefined(a) => c.Modifier(a) + e.Value,
		ResourceUses.AbilityModifier => (c.Extra(e.AbilityKey)?.Modifier ?? 0) + e.Value,
		ResourceUses.ProficiencyBonus => c.ProficiencyBonus + e.Value,
		ResourceUses.CharacterLevel => c.Level + e.Value,
		_ => e.Value
	});

	private static bool Is(string? key, string other) => key is not null && string.Equals(key.Trim(), other, StringComparison.OrdinalIgnoreCase);
}

///	<summary>
///	Checks of the effects written by a person (the API refuses the module otherwise).
///	</summary>
public static class RuleEffectRules
{
	public const int MaxEffects = 30;
	public const int MaxExtraAbilities = 3;

	public static readonly string[] WeaponTexts = ["simple", "martial"];
	public static readonly string[] ArmorTexts = ["light", "medium", "heavy", "shield"];

	///	<summary>
	///	The first problem of a list of effects (a code for the client), or null.
	///	</summary>
	public static string? Validate(IReadOnlyList<RuleEffect> effects)
	{
		if (effects.Count > MaxEffects)
		{
			return "TooManyEffects";
		}
		var keys = effects.Where(e => e.Kind == RuleEffectKind.ExtraAbility).Select(e => e.Key?.Trim().ToLowerInvariant()).ToList();
		if (keys.Count > MaxExtraAbilities || keys.Any(string.IsNullOrEmpty) || keys.Distinct().Count() != keys.Count)
		{
			return "ExtraAbility";
		}
		foreach (var e in effects)
		{
			if (!Enum.IsDefined(e.Kind) || e.Level is < 1 or > 20 || Math.Abs(e.Value) > 100 || (e.Text?.Length ?? 0) > 60
				|| (e.NameIt?.Length ?? 0) > 40 || (e.NameEn?.Length ?? 0) > 40 || (e.ShortIt?.Length ?? 0) > 4 || (e.ShortEn?.Length ?? 0) > 4)
			{
				return "Invalid";
			}
			var problem = e.Kind switch
			{
				RuleEffectKind.AbilityScore or RuleEffectKind.SavingThrow or RuleEffectKind.SaveProficiency
					when e.Ability is null && string.IsNullOrWhiteSpace(e.AbilityKey) => "Ability",
				RuleEffectKind.Skill or RuleEffectKind.SkillProficiency or RuleEffectKind.Expertise when e.Skill is null => "Skill",
				RuleEffectKind.WeaponTraining when string.IsNullOrWhiteSpace(e.Text) => "Text",
				RuleEffectKind.ArmorTraining when !ArmorTexts.Contains(e.Text) => "Text",
				RuleEffectKind.ToolProficiency or RuleEffectKind.Language when string.IsNullOrWhiteSpace(e.Text) => "Text",
				RuleEffectKind.Resistance or RuleEffectKind.Immunity when e.DamageType is null => "DamageType",
				RuleEffectKind.Darkvision when e.Value is <= 0 or > 300 => "Value",
				RuleEffectKind.ExtraAbility when string.IsNullOrWhiteSpace(e.NameIt) && string.IsNullOrWhiteSpace(e.NameEn) => "Name",
				RuleEffectKind.ExtraAbility when e.Value is < 3 or > 18 && e.Value != 0 => "Value",
				RuleEffectKind.Resource when string.IsNullOrWhiteSpace(e.NameIt) && string.IsNullOrWhiteSpace(e.NameEn) => "Name",
				RuleEffectKind.Resource when e.Uses == ResourceUses.Fixed && e.Value is < 1 or > 50 => "Value",
				RuleEffectKind.Resource when e.Uses == ResourceUses.AbilityModifier && e.Ability is null && string.IsNullOrWhiteSpace(e.AbilityKey) => "Ability",
				_ => null
			};
			if (problem is not null)
			{
				return problem;
			}
		}
		return null;
	}
}

///	<summary>
///	The JSON of a list of effects as stored with a module, a feat, a species or a class feature.
///	</summary>
public static class RuleEffectJson
{
	private static readonly System.Text.Json.JsonSerializerOptions Options = new(System.Text.Json.JsonSerializerDefaults.Web);

	public static List<RuleEffect> Read(string? json)
	{
		try
		{
			return string.IsNullOrWhiteSpace(json) ? new() : System.Text.Json.JsonSerializer.Deserialize<List<RuleEffect>>(json, Options) ?? new();
		}
		catch (System.Text.Json.JsonException)
		{
			return new();
		}
	}

	///	<summary>
	///	Cleaned JSON (keys in lower case, texts trimmed, empty names dropped) of the effects of a Homebrew entry.
	///	</summary>
	public static string Write(IEnumerable<RuleEffect>? effects) => System.Text.Json.JsonSerializer.Serialize(Clean(effects?.ToList() ?? new()), Options);

	public static List<RuleEffect> Clean(List<RuleEffect> effects)
	{
		static string? Trim(string? text) => string.IsNullOrWhiteSpace(text) ? null : text.Trim();
		foreach (var e in effects)
		{
			e.Key = Trim(e.Key)?.ToLowerInvariant();
			e.AbilityKey = Trim(e.AbilityKey)?.ToLowerInvariant();
			e.Text = Trim(e.Text);
			e.NameIt = Trim(e.NameIt);
			e.NameEn = Trim(e.NameEn);
			e.ShortIt = Trim(e.ShortIt)?.ToUpperInvariant();
			e.ShortEn = Trim(e.ShortEn)?.ToUpperInvariant();
		}
		return effects;
	}
}
