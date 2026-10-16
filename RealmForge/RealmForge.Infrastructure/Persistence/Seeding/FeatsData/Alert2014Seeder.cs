using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

/// <summary>
/// Provides deterministic database seeding for the Alert feat (2014 ruleset).
/// </summary>
public static class Alert2014Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555502");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555521");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555522");

	///	<summary>
	///	Builds the canonical SRD definition of this feat. Persistence is handled by FeatSeeder.
	///	</summary>
	public static Feat Build()
	{
		return new Feat
		{
			Id = FeatId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Category = FeatCategory.General,
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Alert",
					Description = "Your senses never fully switch off.\n- Add +5 to your initiative rolls.\n- As long as you are conscious, you can't be surprised.\n- Creatures hidden from you don't gain advantage on attack rolls against you just because they are hidden."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Allerta",
					Description = "I sensi del personaggio restano sempre all'erta.\n- Aggiunge +5 ai tiri per l'iniziativa.\n- Finché è cosciente, non può essere sorpreso.\n- Le creature nascoste al personaggio non ottengono vantaggio ai tiri per colpirlo per il solo fatto di essere nascoste."
				}
			}
		};
	}
}