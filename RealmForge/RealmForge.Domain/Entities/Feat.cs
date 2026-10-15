using RealmForge.Domain.Common;
using RealmForge.Shared.Enums;

namespace RealmForge.Domain.Entities
{
	public class Feat : GameEntity
	{
		public FeatCategory Category { get; set; } = FeatCategory.General;

		//	Structured prerequisites (localized text is generated, see FeatPrerequisiteFormatter)
		public int? PrerequisiteMinimumLevel { get; set; }
		public List<AbilityScore> PrerequisiteAbilities { get; set; } = new();
		public int? PrerequisiteMinimumScore { get; set; }
		public FeatFeatureRequirement? PrerequisiteFeature { get; set; }

		public ICollection<FeatTranslation> Translations { get; set; } = new List<FeatTranslation>();
	}

	public class FeatTranslation : ITranslation
	{
		public Guid Id { get; set; } = Guid.NewGuid();

		public Guid FeatId { get; set; }
		public Feat Feat { get; set; } = null!;

		public LanguageCode Language { get; set; }

		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;

		//	Free-text prerequisite that cannot be expressed in structured form (e.g. "Elf or Half-Elf")
		public string? PrerequisiteNote { get; set; }
	}
}