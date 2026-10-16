using RealmForge.Domain.Common;
using RealmForge.Shared.Enums;

namespace RealmForge.Domain.Entities
{
	///	<summary>
	///	Character background. Mechanical data is structured; rich texts (tools, languages, equipment,
	///	the 2014 feature) are localized in BackgroundTranslation.
	///	</summary>
	public class Background : GameEntity
	{
		//	2024: the three abilities among which the background's score increases are distributed (empty for 2014)
		public List<AbilityScore> AbilityOptions { get; set; } = new();

		//	Skill proficiencies granted by the background
		public List<Skill> SkillProficiencies { get; set; } = new();

		//	2024: Origin feat granted by the background (null for 2014 backgrounds)
		public Guid? OriginFeatId { get; set; }
		public Feat? OriginFeat { get; set; }

		public ICollection<BackgroundTranslation> Translations { get; set; } = new List<BackgroundTranslation>();
	}

	public class BackgroundTranslation : ITranslation
	{
		public Guid Id { get; set; } = Guid.NewGuid();

		public Guid BackgroundId { get; set; }
		public Background Background { get; set; } = null!;

		public LanguageCode Language { get; set; }

		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;

		//	Free texts (they may contain choices, e.g. "One kind of gaming set")
		public string? ToolProficiencies { get; set; }
		public string? Languages { get; set; }
		public string? Equipment { get; set; }

		//	Variant of the origin feat, e.g. "Cleric spell list" for Magic Initiate
		public string? OriginFeatNote { get; set; }

		//	2014: background feature (e.g. "Shelter of the Faithful")
		public string? FeatureName { get; set; }
		public string? FeatureDescription { get; set; }

		//	Suggested characteristics: an introduction and the four tables (entry N = die roll N+1)
		public string? CharacteristicsIntro { get; set; }
		public List<string> PersonalityTraits { get; set; } = new();
		public List<string> Ideals { get; set; } = new();
		public List<string> Bonds { get; set; } = new();
		public List<string> Flaws { get; set; } = new();
	}
}
