using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Athlete feat (2014 ruleset).
///	</summary>
public static class Athlete2014Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555503");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555531");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555532");

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
					Name = "Athlete",
					Description = "Hard training has made your body agile and powerful.\n- **Strength or Dexterity +1.** Increase one of the two scores by 1, to a maximum of 20.\n- **Back on Your Feet.** Getting up from prone uses only 5 feet of your movement.\n- **Climber.** Climbing doesn't halve your speed.\n- **Short Run-Up.** A running long jump or high jump needs only a 5-foot run-up on foot instead of 10 feet."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Atleta",
					Description = "Un duro allenamento ha reso il corpo del personaggio agile e potente.\n- **Forza o Destrezza +1.** Uno dei due punteggi aumenta di 1, fino a un massimo di 20.\n- **Subito in piedi.** Rialzarsi da prono costa solo 1,5 metri di movimento.\n- **Scalatore.** Arrampicarsi non dimezza la velocità.\n- **Rincorsa breve.** Per un salto in lungo o in alto con rincorsa bastano 1,5 metri di corsa a piedi invece di 3."
				}
			}
		};
	}
}