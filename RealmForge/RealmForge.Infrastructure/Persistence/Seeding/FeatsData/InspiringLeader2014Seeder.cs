using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Inspiring Leader feat (2014 ruleset).
///	</summary>
public static class InspiringLeader2014Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555517");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555671");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555672");

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
			PrerequisiteAbilities = new List<AbilityScore> { AbilityScore.Charisma },
			PrerequisiteMinimumScore = 13,
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Inspiring Leader",
					Description = "Your words steel the resolve of those who follow you.\n- You can spend 10 minutes encouraging your allies. Choose up to six friendly creatures within 30 feet of you (yourself included, if you wish) that can see or hear you and can understand you. Each of them can gain temporary hit points equal to your level + your Charisma modifier.\n- A creature can't gain temporary hit points from this feat again until it finishes a short or long rest."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Condottiero Ispiratore",
					Description = "Le parole del personaggio rafforzano la determinazione di chi lo segue.\n- Può dedicare 10 minuti a incoraggiare i suoi alleati. Sceglie fino a sei creature amiche entro 9 metri (se lo desidera, anche se stesso) in grado di vederlo o sentirlo e di capirlo. Ognuna può ottenere punti ferita temporanei pari al livello del personaggio + il suo modificatore di Carisma.\n- Una creatura non può ottenere di nuovo punti ferita temporanei da questo talento finché non termina un riposo breve o lungo."
				}
			}
		};
	}
}