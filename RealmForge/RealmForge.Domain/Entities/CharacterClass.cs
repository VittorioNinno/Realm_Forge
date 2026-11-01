using RealmForge.Domain.Common;
using RealmForge.Shared.Enums;

namespace RealmForge.Domain.Entities
{
	///	<summary>
	///	Character class (Barbarian, Wizard...) with its core data, the features gained level by level
	///	and its subclasses. Mechanical data is structured; proficiencies, equipment and the progression table are
	///	localized texts in <see cref="CharacterClassTranslation"/>.
	///	</summary>
	public class CharacterClass : GameEntity
	{
		//	Hit die size (6, 8, 10 or 12)
		public int HitDie { get; set; } = 8;

		public List<AbilityScore> PrimaryAbilities { get; set; } = new();
		public List<AbilityScore> SavingThrows { get; set; } = new();

		//	Skill proficiencies: choose SkillChoiceCount from SkillOptions (empty list = any skill)
		public int SkillChoiceCount { get; set; } = 2;
		public List<Skill> SkillOptions { get; set; } = new();

		//	Spellcasting (None for non-casters)
		public CasterProgression CasterProgression { get; set; } = CasterProgression.None;
		public AbilityScore? SpellcastingAbility { get; set; }

		//	Class level at which the subclass is chosen
		public int SubclassLevel { get; set; } = 3;

		public ICollection<CharacterClassTranslation> Translations { get; set; } = new List<CharacterClassTranslation>();
		public ICollection<ClassFeature> Features { get; set; } = new List<ClassFeature>();
		public ICollection<Subclass> Subclasses { get; set; } = new List<Subclass>();
	}

	///	<summary>
	///	Texts of a class in one language (unique per class and language).
	///	</summary>
	public class CharacterClassTranslation : ITranslation
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public Guid CharacterClassId { get; set; }
		public CharacterClass CharacterClass { get; set; } = null!;
		public LanguageCode Language { get; set; }

		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;

		//	Name of the subclass family, e.g. "Primal Path" / "Cammino Primordiale"
		public string? SubclassTitle { get; set; }

		//	Free texts (they may contain choices)
		public string? ArmorProficiencies { get; set; }
		public string? WeaponProficiencies { get; set; }
		public string? ToolProficiencies { get; set; }
		public string? StartingEquipment { get; set; }

		//	Class table (Markdown): level, proficiency bonus, features and class-specific columns
		public string? ProgressionTable { get; set; }
	}

	///	<summary>
	///	Subclass (Path of the Berserker, School of Evocation...) of a class, with its own features.
	///	</summary>
	public class Subclass : GameEntity
	{
		public Guid CharacterClassId { get; set; }
		public CharacterClass CharacterClass { get; set; } = null!;

		//	Subclasses that grant spellcasting to a non-caster class (Eldritch Knight, Arcane Trickster)
		public CasterProgression CasterProgression { get; set; } = CasterProgression.None;
		public AbilityScore? SpellcastingAbility { get; set; }

		public ICollection<SubclassTranslation> Translations { get; set; } = new List<SubclassTranslation>();
		public ICollection<ClassFeature> Features { get; set; } = new List<ClassFeature>();
	}

	///	<summary>
	///	Texts of a subclass in one language (unique per subclass and language).
	///	</summary>
	public class SubclassTranslation : ITranslation
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public Guid SubclassId { get; set; }
		public Subclass Subclass { get; set; } = null!;
		public LanguageCode Language { get; set; }

		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
	}

	///	<summary>
	///	Feature gained at a class level, owned by a class or by one of its subclasses.
	///	</summary>
	public class ClassFeature : GameEntity
	{
		//	Homebrew rule effects (JSON list of RealmForge.Shared.Characters.RuleEffect) the sheet applies; "[]" for Base content
		public string Effects { get; set; } = "[]";

		public int Level { get; set; } = 1;

		//	Order of the features gained at the same level
		public int SortOrder { get; set; }

		public Guid? CharacterClassId { get; set; }
		public CharacterClass? CharacterClass { get; set; }

		public Guid? SubclassId { get; set; }
		public Subclass? Subclass { get; set; }

		public ICollection<ClassFeatureTranslation> Translations { get; set; } = new List<ClassFeatureTranslation>();
	}

	///	<summary>
	///	Texts of a class feature in one language (unique per feature and language).
	///	</summary>
	public class ClassFeatureTranslation : ITranslation
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public Guid ClassFeatureId { get; set; }
		public ClassFeature ClassFeature { get; set; } = null!;
		public LanguageCode Language { get; set; }

		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
	}
}
