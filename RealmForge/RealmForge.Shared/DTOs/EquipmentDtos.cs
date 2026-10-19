using RealmForge.Shared.Enums;

namespace RealmForge.Shared.DTOs
{
	///	<summary>
	///	Structured data of an item (cost, weight, weapon, armor, tool, focus and mount statistics), shared by the list,
	///	the detail and the Homebrew editor. Fields that do not apply to the item's category are null.
	///	</summary>
	public class EquipmentStatsDto
	{
		public EquipmentCategory Category { get; set; } = EquipmentCategory.AdventuringGear;
		public int? CostInCopper { get; set; }
		public decimal? WeightInPounds { get; set; }
		public int Quantity { get; set; } = 1;

		public WeaponCategory? WeaponCategory { get; set; }
		public WeaponRange? WeaponRange { get; set; }
		public string? DamageDice { get; set; }
		public DamageType? DamageType { get; set; }
		public string? VersatileDamageDice { get; set; }
		public List<WeaponProperty> WeaponProperties { get; set; } = new();
		public int? NormalRange { get; set; }
		public int? LongRange { get; set; }
		public WeaponMastery? Mastery { get; set; }

		public ArmorCategory? ArmorCategory { get; set; }
		public int? ArmorClass { get; set; }
		public bool ArmorAddsDexterity { get; set; }
		public int? ArmorMaxDexterityBonus { get; set; }
		public int? StrengthRequirement { get; set; }
		public bool StealthDisadvantage { get; set; }

		public ToolCategory? ToolCategory { get; set; }
		public AbilityScore? ToolAbility { get; set; }

		public FocusType? FocusType { get; set; }

		public int? SpeedInFeet { get; set; }
		public decimal? SpeedInMilesPerHour { get; set; }
		public int? CarryingCapacityInPounds { get; set; }
	}

	///	<summary>
	///	Item in the localized list (cards).
	///	</summary>
	public record EquipmentResponseDto(
		Guid Id,
		string Name,
		RulesetVersion Ruleset,
		bool IsOfficialSRD,
		EquipmentStatsDto Stats,
		string ShortDescription,
		bool CanEdit = false,
		ContentSource? Source = null,
		ContentVisibility Visibility = ContentVisibility.Public
	);

	///	<summary>
	///	Item detail in one language.
	///	</summary>
	public record EquipmentDetailResponseDto(
		Guid Id,
		string Name,
		RulesetVersion Ruleset,
		bool IsOfficialSRD,
		EquipmentStatsDto Stats,
		string Description,
		bool CanEdit = false,
		ContentSource? Source = null,
		ContentVisibility Visibility = ContentVisibility.Public
	);

	///	<summary>
	///	Homebrew item sent on create or update, with one translation per language.
	///	</summary>
	public class SaveEquipmentDto
	{
		//	Ignored on create; must match the route on update
		public Guid Id { get; set; }
		public RulesetVersion Ruleset { get; set; }
		public EquipmentStatsDto Stats { get; set; } = new();
		public ContentVisibility Visibility { get; set; } = ContentVisibility.Private;
		public List<EquipmentTranslationDto> Translations { get; set; } = new();
	}

	///	<summary>
	///	Texts of a Homebrew item in one language.
	///	</summary>
	public class EquipmentTranslationDto
	{
		public LanguageCode Language { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
	}
}
