using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Inspiring Leader feat (2024 ruleset).
///	</summary>
public static class InspiringLeader2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555570");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551201");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551202");

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
			PrerequisiteAbilities = new List<AbilityScore> { AbilityScore.Wisdom, AbilityScore.Charisma },
			PrerequisiteMinimumScore = 13,
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Inspiring Leader",
					Description = "You gain the following benefits:\n- **Ability Score Increase.** Increase your Wisdom or Charisma score by 1, to a maximum of 20.\n- **Bolstering Performance.** When you finish a Short or Long Rest, you can give an inspiring performance: a speech, song, or dance. When you do so, choose up to six allies (which can include yourself) within 30 feet of yourself who witness the performance. The chosen creatures each gain Temporary Hit Points equal to your character level plus the modifier of the ability you increased with this feat."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Condottiero Ispiratore",
					Description = "Il personaggio ottiene i seguenti benefici:\n- **Incremento dei Punteggi di Caratteristica.** Il suo punteggio di Saggezza o Carisma aumenta di 1, fino a un massimo di 20.\n- **Spettacolo Corroborante.** Quando il personaggio completa un Riposo Breve o Lungo, può esibirsi in uno spettacolo ispiratore come un discorso, una canzone o un ballo, a cui possono assistere fino a 6 alleati a scelta (incluso se stesso) entro 9 metri da sé. Le creature selezionate ottengono ciascuna una quantità di punti ferita temporanei pari al livello del personaggio, più il modificatore della caratteristica aumentata con questo talento."
				}
			}
		};
	}
}