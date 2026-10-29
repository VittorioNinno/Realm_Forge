using RealmForge.Domain.Common;
using RealmForge.Shared.Enums;

namespace RealmForge.Domain.Entities
{
	///	<summary>
	///	A monster's statblock. The numbers the encounters use (armor class, hit points, challenge, experience, abilities)
	///	are structured; the lines and the entries of the statblock are text in <see cref="MonsterTranslation"/>.
	///	A Homebrew monster made from another one ("Crea variante") keeps the original in VariantOfId.
	///	</summary>
	public class Monster : GameEntity
	{
		public CreatureSize Size { get; set; } = CreatureSize.Medium;
		public CreatureType Type { get; set; } = CreatureType.Humanoid;

		public int ArmorClass { get; set; }
		public int HitPoints { get; set; }

		//	"19d12 + 133"
		public string HitDice { get; set; } = string.Empty;

		//	Walking speed in feet
		public int Speed { get; set; }

		public int Strength { get; set; } = 10;
		public int Dexterity { get; set; } = 10;
		public int Constitution { get; set; } = 10;
		public int Intelligence { get; set; } = 10;
		public int Wisdom { get; set; } = 10;
		public int Charisma { get; set; } = 10;

		//	0, 0.125, 0.25, 0.5, 1…30
		public decimal ChallengeRating { get; set; }
		public int Xp { get; set; }
		public int ProficiencyBonus { get; set; } = 2;
		public int PassivePerception { get; set; } = 10;

		public Guid? VariantOfId { get; set; }
		public Monster? VariantOf { get; set; }

		public ICollection<MonsterTranslation> Translations { get; set; } = new List<MonsterTranslation>();
	}

	///	<summary>
	///	Texts of a statblock in one language (unique per monster and language), see MonsterTextDto.
	///	</summary>
	public class MonsterTranslation : ITranslation
	{
		public Guid Id { get; set; } = Guid.NewGuid();

		public Guid MonsterId { get; set; }
		public Monster Monster { get; set; } = null!;

		public LanguageCode Language { get; set; }

		public string Name { get; set; } = string.Empty;
		public string? Alias { get; set; }
		public string Subtitle { get; set; } = string.Empty;
		public string ArmorClass { get; set; } = string.Empty;
		public string Speed { get; set; } = string.Empty;
		public string SavingThrows { get; set; } = string.Empty;
		public string Skills { get; set; } = string.Empty;
		public string DamageVulnerabilities { get; set; } = string.Empty;
		public string DamageResistances { get; set; } = string.Empty;
		public string DamageImmunities { get; set; } = string.Empty;
		public string ConditionImmunities { get; set; } = string.Empty;
		public string Senses { get; set; } = string.Empty;
		public string Languages { get; set; } = string.Empty;
		public string Traits { get; set; } = string.Empty;
		public string Actions { get; set; } = string.Empty;
		public string BonusActions { get; set; } = string.Empty;
		public string Reactions { get; set; } = string.Empty;
		public string LegendaryActions { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
	}
}
