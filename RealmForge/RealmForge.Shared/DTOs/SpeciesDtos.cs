using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;

namespace RealmForge.Shared.DTOs
{
	///	<summary>
	///	Localized trait response DTO.
	///	</summary>
	public record TraitResponseDto(
		Guid Id,
		string Name,
		string Description,
		int RequiredLevel,
		RulesetVersion Ruleset,
		bool IsOfficialSRD
	);

	///	<summary>
	///	Lightweight species response DTO for archive and grid listings.
	///	Default values for counts guarantee backward compatibility with existing constructors.
	///	</summary>
	public record SpeciesResponseDto(
		Guid Id,
		string Name,
		string Description,
		int BaseSpeedInFeet,
		List<CreatureSize> AllowedSizes,
		CreatureType CreatureType,
		RulesetVersion Ruleset,
		bool IsOfficialSRD,
		LanguageCode Language,
		int TraitCount = 0,
		int SubspeciesCount = 0,
		bool CanEdit = false,
		ContentSource? Source = null,
		ContentVisibility Visibility = ContentVisibility.Public
	);

	///	<summary>
	///	Comprehensive species response DTO containing full trees of base traits and subspecies/lineages.
	///	</summary>
	public record SpeciesDetailResponseDto(
		Guid Id,
		string Name,
		string Description,
		int BaseSpeedInFeet,
		List<CreatureSize> AllowedSizes,
		CreatureType CreatureType,
		RulesetVersion Ruleset,
		bool IsOfficialSRD,
		LanguageCode Language,
		List<TraitResponseDto> BaseTraits,
		List<SubspeciesResponseDto> Subspecies,
		bool CanEdit = false,
		ContentSource? Source = null,
ContentVisibility Visibility = ContentVisibility.Public,

		//	Rule effects the sheet applies (Homebrew)
		List<RuleEffect>? Effects = null
	);

	///	<summary>
	///	Payload DTO for creating a trait along with its localized entries.
	///	</summary>
	public record CreateTraitDto(
		int RequiredLevel,
		RulesetVersion Ruleset,
		List<TraitTranslationDto> Translations
	);

	///	<summary>
	///	Payload DTO for creating a new species along with its localized entries, base traits, and subspecies.
	///	</summary>
	public record CreateSpeciesDto(
		int BaseSpeedInFeet,
		List<CreatureSize> AllowedSizes,
		CreatureType CreatureType,
		RulesetVersion Ruleset,
		List<SpeciesTranslationDto> Translations,
		List<CreateTraitDto>? BaseTraits = null,
		List<CreateSubspeciesDto>? Subspecies = null,
		ContentVisibility Visibility = ContentVisibility.Private,
		List<RuleEffect>? Effects = null
	);

	///	<summary>
	///	Payload DTO for updating an existing species.
	///	</summary>
	public record UpdateSpeciesDto(
		Guid Id,
		int BaseSpeedInFeet,
		List<CreatureSize> AllowedSizes,
		CreatureType CreatureType,
		RulesetVersion Ruleset,
		List<SpeciesTranslationDto> Translations,
		ContentVisibility Visibility = ContentVisibility.Private,
		List<RuleEffect>? Effects = null
	);

	///	<summary>
	///	Localized translation entry for species creation and editing.
	///	</summary>
	public record SpeciesTranslationDto(
		LanguageCode Language,
		string Name,
		string Description
	);

	///	<summary>
	///	Localized translation entry for trait creation and seeding.
	///	</summary>
	public record TraitTranslationDto(
		LanguageCode Language,
		string Name,
		string Description
	);
}