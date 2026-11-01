using RealmForge.Domain.Common;
using RealmForge.Shared.Enums;

namespace RealmForge.Domain.Entities
{
	///	<summary>
	///	Feat with category and structured prerequisites; names and descriptions are in <see cref="FeatTranslation"/>.
	///	</summary>
	public class Feat : GameEntity
	{
		//	Homebrew rule effects (JSON list of RealmForge.Shared.Characters.RuleEffect) the sheet applies; "[]" for Base content
		public string Effects { get; set; } = "[]";

		public FeatCategory Category { get; set; } = FeatCategory.General;

		//	Structured prerequisites (localized text is generated, see FeatPrerequisiteFormatter)
		public int? PrerequisiteMinimumLevel { get; set; }
		public List<AbilityScore> PrerequisiteAbilities { get; set; } = new();
		public int? PrerequisiteMinimumScore { get; set; }
		public FeatFeatureRequirement? PrerequisiteFeature { get; set; }

		public ICollection<FeatTranslation> Translations { get; set; } = new List<FeatTranslation>();
	}

	///	<summary>
	///	Texts of a feat in one language (unique per feat and language).
	///	</summary>
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