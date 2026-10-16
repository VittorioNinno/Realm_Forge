using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Resilient feat (2024 ruleset).
///	</summary>
public static class Resilient2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555582");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551321");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551322");

	///	<summary>
	///	Builds the canonical SRD definition of this feat. Persistence is handled by FeatSeeder.
	///	</summary>
	public static Feat Build()
	{
		return new Feat
		{
			Id = FeatId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Category = FeatCategory.General,
			PrerequisiteMinimumLevel = 4,
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Resilient",
					Description = "You have hardened yourself against one kind of threat.\n- **Ability Score Increase.** Choose an ability whose saving throws you aren't proficient in, and increase that score by 1, to a maximum of 20.\n- **Saving Throw Proficiency.** You gain saving throw proficiency with the chosen ability."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Resiliente",
					Description = "Il personaggio si è temprato contro un tipo di minaccia.\n- **Incremento dei Punteggi di Caratteristica.** Sceglie una caratteristica nei cui Tiri Salvezza non ha competenza e ne aumenta il punteggio di 1, fino a un massimo di 20.\n- **Competenza nei Tiri Salvezza.** Ottiene competenza nei Tiri Salvezza di quella caratteristica."
				}
			}
		};
	}
}