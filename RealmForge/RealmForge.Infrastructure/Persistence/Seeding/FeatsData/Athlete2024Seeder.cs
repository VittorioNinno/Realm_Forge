using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Athlete feat (2024 ruleset).
///	</summary>
public static class Athlete2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555556");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551061");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551062");

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
			PrerequisiteAbilities = new List<AbilityScore> { AbilityScore.Strength, AbilityScore.Dexterity },
			PrerequisiteMinimumScore = 13,
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Athlete",
					Description = "Constant training has made your body agile and strong.\n- **Strength or Dexterity +1.** Increase one of the two scores by 1, to a maximum of 20.\n- **Natural Climber.** You gain a Climb Speed equal to your Speed.\n- **Quick to Rise.** Standing up from Prone costs you only 5 feet of movement.\n- **Short Run-Up.** You need to move only 5 feet before making a running Long Jump or High Jump."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Atleta",
					Description = "Un allenamento costante ha reso il corpo del personaggio agile e forte.\n- **Forza o Destrezza +1.** Uno dei due punteggi aumenta di 1, fino a un massimo di 20.\n- **Scalatore nato.** Ottiene una velocità di scalata pari alla sua velocità.\n- **Subito in piedi.** Rialzarsi dalla condizione di prono gli costa solo 1,5 metri di movimento.\n- **Rincorsa breve.** Gli basta muoversi di 1,5 metri prima di effettuare un salto in lungo o in alto con rincorsa."
				}
			}
		};
	}
}