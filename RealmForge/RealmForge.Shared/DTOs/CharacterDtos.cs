using RealmForge.Shared.Enums;

namespace RealmForge.Shared.DTOs
{
	///	<summary>
	///	Choices of the creation wizard. Names and texts are not stored: they come from the compendium in the reader's language.
	///	Ability arrays are in the order Strength, Dexterity, Constitution, Intelligence, Wisdom, Charisma.
	///	</summary>
	public class SaveCharacterDto
	{
		public string Name { get; set; } = string.Empty;
		public RulesetVersion Ruleset { get; set; } = RulesetVersion.Dnd5e_2024;
		public int Level { get; set; } = 1;
		public Alignment Alignment { get; set; } = Alignment.Neutral;

		public Guid SpeciesId { get; set; }
		public Guid? SubspeciesId { get; set; }
		public CreatureSize Size { get; set; } = CreatureSize.Medium;
		public Guid BackgroundId { get; set; }
		public List<string> Languages { get; set; } = new();

		public Guid ClassId { get; set; }
		public Guid? SubclassId { get; set; }
		public List<Skill> ClassSkills { get; set; } = new();

		public AbilityMethod AbilityMethod { get; set; } = AbilityMethod.StandardArray;
		public List<int> BaseScores { get; set; } = new();
		public AbilityBonusMode BonusMode { get; set; } = AbilityBonusMode.TwoAndOne;
		public List<int> AbilityBonuses { get; set; } = new();

		//	"A"/"B" for the background (2024), the kit letter or one letter per line for the class ("" for fixed lines)
		public string? BackgroundEquipment { get; set; }
		public List<string> ClassEquipment { get; set; } = new();

		public List<Guid> SpellIds { get; set; } = new();
	}

	///	<summary>
	///	A character in the list of the owner.
	///	</summary>
	public record CharacterSummaryDto(
		Guid Id,
		string Name,
		RulesetVersion Ruleset,
		int Level,
		string SpeciesName,
		string ClassName,
		string? SubclassName,
		string BackgroundName,
		int MaxHitPoints,
		int ArmorClass,
		DateTimeOffset UpdatedAt);

	///	<summary>
	///	Named reference to a compendium entry (species, class, spell…).
	///	</summary>
	public record CharacterRefDto(Guid Id, string Name);

	public record CharacterSpellDto(Guid Id, string Name, int Level);

	///	<summary>
	///	A character with everything the sheet shows, in the requested language. Derived values (hit points, Armor Class)
	///	are computed when the character is saved.
	///	</summary>
	public record CharacterDetailDto(
		Guid Id,
		string Name,
		RulesetVersion Ruleset,
		int Level,
		Alignment Alignment,
		CharacterRefDto Species,
		CharacterRefDto? Subspecies,
		CreatureSize Size,
		int SpeedInFeet,
		CharacterRefDto Background,
		CharacterRefDto? OriginFeat,
		CharacterRefDto Class,
		CharacterRefDto? Subclass,
		int HitDie,
		List<string> Languages,
		AbilityMethod AbilityMethod,
		List<int> BaseScores,
		AbilityBonusMode BonusMode,
		List<int> AbilityBonuses,
		List<int> FinalScores,
		List<AbilityScore> SavingThrows,
		List<Skill> Skills,
		int ProficiencyBonus,
		int MaxHitPoints,
		int ArmorClass,
		List<string> Equipment,
		List<CharacterSpellDto> Spells,
		AbilityScore? SpellcastingAbility,
		DateTimeOffset CreatedAt,
		DateTimeOffset UpdatedAt);
}
