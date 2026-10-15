using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Mage Slayer feat (2024 ruleset).
///	</summary>
public static class MageSlayer2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555573");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551231");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551232");

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
					Name = "Mage Slayer",
					Description = "You gain the following benefits:\n- **Ability Score Increase.** Increase your Strength or Dexterity score by 1, to a maximum of 20.\n- **Concentration Breaker.** When you damage a creature that is concentrating, it has Disadvantage on the saving throw it makes to maintain Concentration.\n- **Guarded Mind.** If you fail an Intelligence, a Wisdom, or a Charisma saving throw, you can cause yourself to succeed instead. Once you use this benefit, you can't use it again until you finish a Short or Long Rest."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Sterminatore di Maghi",
					Description = "Il personaggio ottiene i seguenti benefici:\n- **Incremento dei Punteggi di Caratteristica.** Il suo punteggio di Forza o Destrezza aumenta di 1, fino a un massimo di 20.\n- **Spezza Concentrazione.** Quando il personaggio infligge danni a una creatura che si sta concentrando, questa avrà Svantaggio ai tiri salvezza effettuati per mantenere la concentrazione.\n- **Scudo Mentale.** Se il personaggio fallisce un tiro salvezza su Intelligenza, Saggezza o Carisma, può fare in modo di superarlo. Dopo aver usato questo beneficio, non può riutilizzarlo prima di aver completato un Riposo Breve o Lungo."
				}
			}
		};
	}
}