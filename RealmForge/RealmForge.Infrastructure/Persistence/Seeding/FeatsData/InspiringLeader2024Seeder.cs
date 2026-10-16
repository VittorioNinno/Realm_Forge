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
					Description = "Your words and presence steel your companions.\n- **Ability Score Increase.** Increase your Wisdom or Charisma score by 1, to a maximum of 20.\n- **Bolstering Performance.** When you finish a Short or Long Rest, you can deliver a speech, song, or dance. Up to six allies of your choice (you can include yourself) within 30 feet who witness it each gain Temporary Hit Points equal to your character level + the modifier of the ability you increased with this feat."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Condottiero Ispiratore",
					Description = "Le parole e la presenza del personaggio rafforzano i suoi compagni.\n- **Incremento dei Punteggi di Caratteristica.** Il punteggio di Saggezza o Carisma aumenta di 1, fino a un massimo di 20.\n- **Spettacolo Corroborante.** Quando termina un Riposo Breve o Lungo, può tenere un discorso, cantare o danzare. Fino a sei alleati a sua scelta (può includere sé stesso) entro 9 metri che assistono all'esibizione ottengono ciascuno Punti Ferita Temporanei pari al suo livello del personaggio + il modificatore della caratteristica aumentata con questo talento."
				}
			}
		};
	}
}