using RealmForge.Shared.Enums;

namespace RealmForge.Shared.Characters;

///	<summary>
///	The compendium of one edition as the character rules need it (numbers, lists and keys, names in the reader's
///	language). The API builds it for the wizard and the sheet, and uses the same data to check a character on save,
///	so both sides compute the same values. Keys identify the Base content ("wizard", "hill-dwarf", "tough"…);
///	Homebrew entries have none.
///	</summary>
public sealed record CharacterContextDto(
	RulesetVersion Ruleset,
	List<ContextClass> Classes,
	List<ContextSpecies> Species,
	List<ContextBackground> Backgrounds,
	List<ContextFeat> Feats,
	List<ContextSpell> Spells,
	List<ContextItem> Items);

public sealed record ContextClass(
	Guid Id,
	string Name,
	string? Key,
	int HitDie,
	List<AbilityScore> PrimaryAbilities,
	List<AbilityScore> SavingThrows,
	int SkillChoiceCount,
	List<Skill> SkillOptions,
	CasterProgression CasterProgression,
	AbilityScore? SpellcastingAbility,
	SpellcastingClass? SpellList,
	int SubclassLevel,
	string? ProgressionTable,
	List<ContextSubclass> Subclasses,
	ContextLoadout Equipment);

public sealed record ContextSubclass(Guid Id, string Name, string? Key, CasterProgression CasterProgression, AbilityScore? SpellcastingAbility);

public sealed record ContextSpecies(Guid Id, string Name, string? Key, List<CreatureSize> Sizes, int Speed, List<ContextSubspecies> Subspecies);

public sealed record ContextSubspecies(Guid Id, string Name, string? Key, int? Speed);

public sealed record ContextBackground(
	Guid Id,
	string Name,
	string? Key,
	List<AbilityScore> AbilityOptions,
	List<Skill> Skills,
	Guid? OriginFeatId,
	int LanguageChoices,
	ContextLoadout Equipment);

///	<summary>
///	A feat with its prerequisites and the abilities its "Ability Score Increase" lets you raise (read from the
///	English text; empty when it raises none), up to <paramref name="IncreaseMaximum"/>.
///	</summary>
public sealed record ContextFeat(
	Guid Id,
	string Name,
	string? Key,
	FeatCategory Category,
	int? MinimumLevel,
	List<AbilityScore> PrerequisiteAbilities,
	int? MinimumScore,
	FeatFeatureRequirement? PrerequisiteFeature,
	List<AbilityScore> Increases,
	int IncreaseMaximum);

public sealed record ContextSpell(Guid Id, string Name, int Level, SpellSchool School, List<SpellcastingClass> Classes, bool Ritual, bool Concentration, string? Key = null);

public sealed record ContextItem(
	Guid Id,
	string Name,
	string EnglishName,
	EquipmentCategory Category,
	WeaponCategory? WeaponCategory,
	WeaponRange? WeaponRange,
	List<WeaponProperty> WeaponProperties,
	string? DamageDice,
	DamageType? DamageType,
	string? VersatileDamageDice,
	int? NormalRange,
	int? LongRange,
	WeaponMastery? Mastery,
	ArmorCategory? ArmorCategory,
	int? ArmorClass,
	bool ArmorAddsDexterity,
	int? ArmorMaxDexterityBonus,
	int? StrengthRequirement,
	bool StealthDisadvantage,
	ToolCategory? ToolCategory,
	decimal? WeightInPounds,
	int? CostInCopper);

///	<summary>
///	Starting equipment as choices: whole kits (A/B/C) or rows of options (a/b/c). The structure always comes from the
///	English text, so the letters saved with a character mean the same in every language; labels are in the reader's
///	language.
///	</summary>
public sealed record ContextLoadout(List<ContextLoadoutOption> Kits, List<ContextLoadoutRow> Rows)
{
	public static readonly ContextLoadout Empty = new(new List<ContextLoadoutOption>(), new List<ContextLoadoutRow>());
	public bool IsEmpty => Kits.Count == 0 && Rows.Count == 0;
}

public sealed record ContextLoadoutRow(List<ContextLoadoutOption> Options);

public sealed record ContextLoadoutOption(string Letter, List<ContextLoadoutItem> Items);

///	<summary>
///	One item of a starting option: a compendium item, coins, a generic choice ("any simple weapon": <see cref="Pick"/>)
///	or a free text.
///	</summary>
public sealed record ContextLoadoutItem(string Label, int Quantity, Guid? EquipmentId, int? CoinAmount, CoinType? CoinType, LoadoutPick? Pick);

public enum LoadoutPickKind
{
	SimpleWeapon = 1,
	MartialWeapon = 2,
	MusicalInstrument = 3
}

public sealed record LoadoutPick(LoadoutPickKind Kind, bool MeleeOnly, int Count);
