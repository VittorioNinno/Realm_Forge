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
					Description = "You have trained to hunt down spellcasters.\n- **Ability Score Increase.** Increase your Strength or Dexterity score by 1, to a maximum of 20.\n- **Concentration Breaker.** A concentrating creature you damage has Disadvantage on its saving throw to keep Concentration.\n- **Guarded Mind.** When you fail an Intelligence, Wisdom, or Charisma saving throw, you can succeed instead. You can't do this again until you finish a Short or Long Rest."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Sterminatore di Maghi",
					Description = "Il personaggio si è addestrato a dare la caccia agli incantatori.\n- **Incremento dei Punteggi di Caratteristica.** Il punteggio di Forza o Destrezza aumenta di 1, fino a un massimo di 20.\n- **Spezza Concentrazione.** Una creatura concentrata a cui infligge danni ha Svantaggio al Tiro Salvezza per mantenere la Concentrazione.\n- **Scudo Mentale.** Quando fallisce un Tiro Salvezza su Intelligenza, Saggezza o Carisma, può invece superarlo. Non può farlo di nuovo finché non termina un Riposo Breve o Lungo."
				}
			}
		};
	}
}