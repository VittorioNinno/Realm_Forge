using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;

namespace RealmForge.Shared.DTOs
{
	///	<summary>
	///	A rule module in the list: name, a short description, what it adds (the kinds of its effects).
	///	</summary>
	public record RuleModuleResponseDto(
		Guid Id,
		string Name,
		string ShortDescription,
		RulesetVersion Ruleset,
		List<RuleEffectKind> EffectKinds,
		bool CanEdit,
		ContentVisibility Visibility,
		string? Author);

	///	<summary>
	///	A rule module with its effects and both translations (for the editor).
	///	</summary>
	public record RuleModuleDetailDto(
		Guid Id,
		string Name,
		string Description,
		RulesetVersion Ruleset,
		List<RuleEffect> Effects,
		List<RuleModuleTranslationDto> Translations,
		bool CanEdit,
		ContentVisibility Visibility,
		string? Author);

	public class RuleModuleTranslationDto
	{
		public LanguageCode Language { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
	}

	public class SaveRuleModuleDto
	{
		public RulesetVersion Ruleset { get; set; } = RulesetVersion.Dnd5e_2024;
		public ContentVisibility Visibility { get; set; } = ContentVisibility.Private;
		public List<RuleEffect> Effects { get; set; } = new();
		public List<RuleModuleTranslationDto> Translations { get; set; } = new();
	}
}
