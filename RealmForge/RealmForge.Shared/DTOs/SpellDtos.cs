using RealmForge.Shared.Enums;

namespace RealmForge.Shared.DTOs
{
	///	<summary>
	///	Spell in the localized list (cards). Carries the structured data the client filters on.
	///	</summary>
	public record SpellResponseDto(
		Guid Id,
		string Name,
		RulesetVersion Ruleset,
		bool IsOfficialSRD,
		int Level,
		SpellSchool School,
		List<SpellcastingClass> Classes,
		bool Ritual,
		bool Concentration,
		string CastingTime,
		string Range,
		string ShortDescription,
		bool CanEdit = false,
		ContentSource? Source = null,
		ContentVisibility Visibility = ContentVisibility.Public
	);

	///	<summary>
	///	Spell detail in one language: the stat block, the description and the higher-level scaling.
	///	</summary>
	public record SpellDetailResponseDto(
		Guid Id,
		string Name,
		RulesetVersion Ruleset,
		bool IsOfficialSRD,
		int Level,
		SpellSchool School,
		List<SpellcastingClass> Classes,
		bool Ritual,
		bool Concentration,
		bool Verbal,
		bool Somatic,
		bool Material,
		string CastingTime,
		string Range,
		string Duration,
		string? MaterialComponent,
		string Description,
		string? HigherLevels,
		bool CanEdit = false,
		ContentSource? Source = null,
		ContentVisibility Visibility = ContentVisibility.Public
	);

	///	<summary>
	///	Homebrew spell sent on create or update, with one translation per language.
	///	</summary>
	public class SaveSpellDto
	{
		//	Ignored on create; must match the route on update
		public Guid Id { get; set; }
		public RulesetVersion Ruleset { get; set; }
		public int Level { get; set; }
		public SpellSchool School { get; set; } = SpellSchool.Evocation;
		public List<SpellcastingClass> Classes { get; set; } = new();
		public bool Ritual { get; set; }
		public bool Concentration { get; set; }
		public bool Verbal { get; set; }
		public bool Somatic { get; set; }
		public bool Material { get; set; }
		public ContentVisibility Visibility { get; set; } = ContentVisibility.Private;
		public List<SpellTranslationDto> Translations { get; set; } = new();
	}

	///	<summary>
	///	Texts of a Homebrew spell in one language.
	///	</summary>
	public class SpellTranslationDto
	{
		public LanguageCode Language { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public string? HigherLevels { get; set; }
		public string CastingTime { get; set; } = string.Empty;
		public string Range { get; set; } = string.Empty;
		public string Duration { get; set; } = string.Empty;
		public string? MaterialComponent { get; set; }
	}
}
