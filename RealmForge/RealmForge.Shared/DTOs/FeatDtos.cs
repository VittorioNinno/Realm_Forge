using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;

namespace RealmForge.Shared.DTOs
{
	///	<summary>
	///	Structured, language-invariant feat prerequisites.
	///	The localized text is produced by <see cref="Localization.FeatPrerequisiteFormatter"/>.
	///	</summary>
	public class FeatPrerequisiteDto
	{
		//	Minimum character level (e.g. 4 or 19), null when there is no level requirement
		public int? MinimumLevel { get; set; }

		//	Abilities of which at least ONE must reach MinimumScore (e.g. "Strength or Dexterity 13+")
		public List<AbilityScore> Abilities { get; set; } = new();

		//	Minimum score for the abilities above (usually 13)
		public int? MinimumScore { get; set; }

		//	Required class feature or training
		public FeatFeatureRequirement? Feature { get; set; }

		public bool IsEmpty =>
			MinimumLevel is null && Feature is null && (Abilities.Count == 0 || MinimumScore is null);
	}

	///	<summary>
	///	Feat in the localized list (cards), with the prerequisite already formatted.
	///	</summary>
	public record FeatResponseDto(
		Guid Id,
		string Name,
		FeatCategory Category,
		string? Prerequisite,
		RulesetVersion Ruleset,
		bool IsOfficialSRD,
		string ShortDescription,
		bool CanEdit = false,
		ContentSource? Source = null,
		ContentVisibility Visibility = ContentVisibility.Public
	);

	///	<summary>
	///	Feat detail in one language.
	///	</summary>
	public record FeatDetailResponseDto(
		Guid Id,
		string Name,
		FeatCategory Category,
		string? Prerequisite,
		RulesetVersion Ruleset,
		bool IsOfficialSRD,
		string Description,
		FeatPrerequisiteDto Prerequisites,
		string? PrerequisiteNote,
		bool CanEdit = false,
		ContentSource? Source = null,
ContentVisibility Visibility = ContentVisibility.Public,

		//	Rule effects the sheet applies (Homebrew)
		List<RuleEffect>? Effects = null
	);

	///	<summary>
	///	Homebrew feat sent on create, with one translation per language.
	///	</summary>
	public class CreateFeatDto
	{
		public ContentVisibility Visibility { get; set; } = ContentVisibility.Private;
		public FeatCategory Category { get; set; }
		public FeatPrerequisiteDto Prerequisites { get; set; } = new();
		public RulesetVersion Ruleset { get; set; }
		public List<CreateFeatTranslationDto> Translations { get; set; } = new();
		public List<RuleEffect> Effects { get; set; } = new();
	}

	///	<summary>
	///	Texts of a new Homebrew feat in one language.
	///	</summary>
	public class CreateFeatTranslationDto
	{
		public LanguageCode Language { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;

		//	Free-text prerequisite that cannot be expressed in structured form (e.g. "Elf or Half-Elf")
		public string? PrerequisiteNote { get; set; }
	}

	///	<summary>
	///	Homebrew feat sent on update.
	///	</summary>
	public class UpdateFeatDto
	{
		public ContentVisibility Visibility { get; set; } = ContentVisibility.Private;
		public Guid Id { get; set; }
		public FeatCategory Category { get; set; }
		public FeatPrerequisiteDto Prerequisites { get; set; } = new();
		public RulesetVersion Ruleset { get; set; }
		public List<UpdateFeatTranslationDto> Translations { get; set; } = new();
		public List<RuleEffect> Effects { get; set; } = new();
	}

	///	<summary>
	///	Texts of a Homebrew feat in one language, on update.
	///	</summary>
	public class UpdateFeatTranslationDto
	{
		public LanguageCode Language { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public string? PrerequisiteNote { get; set; }
	}
}
