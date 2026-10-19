using RealmForge.Domain.Common;
using RealmForge.Shared.Enums;

namespace RealmForge.Domain.Entities
{
	///	<summary>
	///	An item of the equipment chapter: weapon, armor, tool, gear, pack, mount or vehicle. Cost, weight and the weapon,
	///	armor and tool statistics are structured (used by the filters and, later, by the character sheet); names and
	///	descriptions are localized in <see cref="EquipmentTranslation"/>.
	///	</summary>
	public class Equipment : GameEntity
	{
		public EquipmentCategory Category { get; set; }

		//	Price in copper pieces (1 gp = 100 cp); null when the price varies or is not listed
		public int? CostInCopper { get; set; }

		//	Weight in pounds as in the English rules (the client shows kilograms, 1 lb = 0.5 kg as in the Italian books); null = negligible
		public decimal? WeightInPounds { get; set; }

		//	Number of pieces sold together (20 arrows, 1,000 ball bearings)
		public int Quantity { get; set; } = 1;

		//	Weapons
		public WeaponCategory? WeaponCategory { get; set; }
		public WeaponRange? WeaponRange { get; set; }
		public string? DamageDice { get; set; }
		public DamageType? DamageType { get; set; }
		public string? VersatileDamageDice { get; set; }
		public List<WeaponProperty> WeaponProperties { get; set; } = new();
		//	Range in feet of ranged and thrown weapons (normal / long)
		public int? NormalRange { get; set; }
		public int? LongRange { get; set; }
		public WeaponMastery? Mastery { get; set; }

		//	Armor: base AC (or the bonus of a shield), whether Dexterity is added and its cap (null = no cap)
		public ArmorCategory? ArmorCategory { get; set; }
		public int? ArmorClass { get; set; }
		public bool ArmorAddsDexterity { get; set; }
		public int? ArmorMaxDexterityBonus { get; set; }
		public int? StrengthRequirement { get; set; }
		public bool StealthDisadvantage { get; set; }

		//	Tools: kind and (2024 rules) the ability used with them
		public ToolCategory? ToolCategory { get; set; }
		public AbilityScore? ToolAbility { get; set; }

		//	Spellcasting focus kind
		public FocusType? FocusType { get; set; }

		//	Mounts: speed in feet and carrying capacity in pounds; ships: speed in miles per hour
		public int? SpeedInFeet { get; set; }
		public decimal? SpeedInMilesPerHour { get; set; }
		public int? CarryingCapacityInPounds { get; set; }

		public ICollection<EquipmentTranslation> Translations { get; set; } = new List<EquipmentTranslation>();
	}

	///	<summary>
	///	Texts of an item in one language (unique per item and language). Description is Markdown.
	///	</summary>
	public class EquipmentTranslation : ITranslation
	{
		public Guid Id { get; set; } = Guid.NewGuid();

		public Guid EquipmentId { get; set; }
		public Equipment Equipment { get; set; } = null!;

		public LanguageCode Language { get; set; }

		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
	}
}
