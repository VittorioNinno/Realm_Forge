using RealmForge.Shared.Enums;

namespace RealmForge.Shared.DTOs
{
	public record BackgroundResponseDto(
		Guid Id,
		string Name,
		RulesetVersion Ruleset,
		bool IsOfficialSRD,
		string ShortDescription,
		List<AbilityScore> AbilityOptions,
		List<Skill> SkillProficiencies,
		Guid? OriginFeatId,
		string? OriginFeatName,
		bool CanEdit = false
	);

	public record BackgroundDetailResponseDto(
		Guid Id,
		string Name,
		RulesetVersion Ruleset,
		bool IsOfficialSRD,
		string Description,
		List<AbilityScore> AbilityOptions,
		List<Skill> SkillProficiencies,
		Guid? OriginFeatId,
		string? OriginFeatName,
		string? OriginFeatNote,
		string? ToolProficiencies,
		string? Languages,
		string? Equipment,
		string? FeatureName,
		string? FeatureDescription,
		string? CharacteristicsIntro,
		List<string> PersonalityTraits,
		List<string> Ideals,
		List<string> Bonds,
		List<string> Flaws,
		bool CanEdit = false
	);

	public class SaveBackgroundDto
	{
		//	Ignored on create; must match the route on update
		public Guid Id { get; set; }
		public RulesetVersion Ruleset { get; set; }
		public List<AbilityScore> AbilityOptions { get; set; } = new();
		public List<Skill> SkillProficiencies { get; set; } = new();
		public Guid? OriginFeatId { get; set; }
		public List<BackgroundTranslationDto> Translations { get; set; } = new();
	}

	public class BackgroundTranslationDto
	{
		public LanguageCode Language { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public string? ToolProficiencies { get; set; }
		public string? Languages { get; set; }
		public string? Equipment { get; set; }
		public string? OriginFeatNote { get; set; }
		public string? FeatureName { get; set; }
		public string? FeatureDescription { get; set; }
		public string? CharacteristicsIntro { get; set; }
		public List<string> PersonalityTraits { get; set; } = new();
		public List<string> Ideals { get; set; } = new();
		public List<string> Bonds { get; set; } = new();
		public List<string> Flaws { get; set; } = new();
	}
}
