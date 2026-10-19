using RealmForge.Shared.Enums;

namespace RealmForge.Shared.DTOs
{
	///	<summary>
	///	Class in the localized list (cards).
	///	</summary>
	public record ClassResponseDto(
		Guid Id,
		string Name,
		RulesetVersion Ruleset,
		bool IsOfficialSRD,
		int HitDie,
		List<AbilityScore> PrimaryAbilities,
		List<AbilityScore> SavingThrows,
		CasterProgression CasterProgression,
		AbilityScore? SpellcastingAbility,
		string? SubclassTitle,
		List<string> SubclassNames,
		string ShortDescription,
		bool CanEdit = false,
		ContentSource? Source = null,
		ContentVisibility Visibility = ContentVisibility.Public
	);

	///	<summary>
	///	Feature gained at a class level (class or subclass feature) in one language.
	///	</summary>
	public record ClassFeatureDto(
		Guid Id,
		int Level,
		int SortOrder,
		string Name,
		string Description
	);

	///	<summary>
	///	Subclass with its features in one language.
	///	</summary>
	public record SubclassResponseDto(
		Guid Id,
		Guid ClassId,
		string ClassName,
		string Name,
		string Description,
		RulesetVersion Ruleset,
		bool IsOfficialSRD,
		CasterProgression CasterProgression,
		AbilityScore? SpellcastingAbility,
		List<ClassFeatureDto> Features,
		bool CanEdit = false,
		ContentSource? Source = null,
		ContentVisibility Visibility = ContentVisibility.Public
	);

	///	<summary>
	///	Class detail in one language: core data, proficiencies, equipment, progression table, features and subclasses.
	///	</summary>
	public record ClassDetailResponseDto(
		Guid Id,
		string Name,
		string Description,
		RulesetVersion Ruleset,
		bool IsOfficialSRD,
		int HitDie,
		List<AbilityScore> PrimaryAbilities,
		List<AbilityScore> SavingThrows,
		int SkillChoiceCount,
		List<Skill> SkillOptions,
		CasterProgression CasterProgression,
		AbilityScore? SpellcastingAbility,
		int SubclassLevel,
		string? SubclassTitle,
		string? ArmorProficiencies,
		string? WeaponProficiencies,
		string? ToolProficiencies,
		string? StartingEquipment,
		string? ProgressionTable,
		List<ClassFeatureDto> Features,
		List<SubclassResponseDto> Subclasses,
		bool CanEdit = false,
		ContentSource? Source = null,
		ContentVisibility Visibility = ContentVisibility.Public
	);

	///	<summary>
	///	Homebrew class sent on create or update. Features are replaced as a whole on update, in list order.
	///	</summary>
	public class SaveClassDto
	{
		//	Ignored on create; must match the route on update
		public Guid Id { get; set; }
		public RulesetVersion Ruleset { get; set; }
		public int HitDie { get; set; } = 8;
		public List<AbilityScore> PrimaryAbilities { get; set; } = new();
		public List<AbilityScore> SavingThrows { get; set; } = new();
		public int SkillChoiceCount { get; set; } = 2;
		public List<Skill> SkillOptions { get; set; } = new();
		public CasterProgression CasterProgression { get; set; }
		public AbilityScore? SpellcastingAbility { get; set; }
		public int SubclassLevel { get; set; } = 3;
		public ContentVisibility Visibility { get; set; } = ContentVisibility.Private;
		public List<ClassTranslationDto> Translations { get; set; } = new();
		public List<SaveClassFeatureDto> Features { get; set; } = new();
	}

	///	<summary>
	///	Texts of a Homebrew class in one language.
	///	</summary>
	public class ClassTranslationDto
	{
		public LanguageCode Language { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public string? SubclassTitle { get; set; }
		public string? ArmorProficiencies { get; set; }
		public string? WeaponProficiencies { get; set; }
		public string? ToolProficiencies { get; set; }
		public string? StartingEquipment { get; set; }
		public string? ProgressionTable { get; set; }
	}

	///	<summary>
	///	Homebrew feature (class or subclass) with its texts in each language.
	///	</summary>
	public class SaveClassFeatureDto
	{
		public int Level { get; set; } = 1;
		public List<FeatureTextDto> Translations { get; set; } = new();
	}

	///	<summary>
	///	Name and description of a feature or subclass in one language.
	///	</summary>
	public class FeatureTextDto
	{
		public LanguageCode Language { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
	}

	///	<summary>
	///	Homebrew subclass sent on create or update, attached to any class the author can see.
	///	</summary>
	public class SaveSubclassDto
	{
		//	Ignored on create; must match the route on update
		public Guid Id { get; set; }
		public Guid ClassId { get; set; }
		public CasterProgression CasterProgression { get; set; }
		public AbilityScore? SpellcastingAbility { get; set; }
		public ContentVisibility Visibility { get; set; } = ContentVisibility.Private;
		public List<FeatureTextDto> Translations { get; set; } = new();
		public List<SaveClassFeatureDto> Features { get; set; } = new();
	}
}
