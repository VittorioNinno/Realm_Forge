using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Weapon Master feat (2024 ruleset).
///	</summary>
public static class WeaponMaster2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555596");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551461");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551462");

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
					Name = "Weapon Master",
					Description = "Long practice has taught you the finer techniques of a weapon.\n- **Ability Score Increase.** Increase your Strength or Dexterity score by 1, to a maximum of 20.\n- **Mastery Property.** Choose one kind of Simple or Martial weapon you are proficient with: you can use its mastery property. You can switch to another eligible kind of weapon whenever you finish a Long Rest."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Maestro d'Armi",
					Description = "Una lunga pratica ha insegnato al personaggio le tecniche più raffinate di un'arma.\n- **Incremento dei Punteggi di Caratteristica.** Il punteggio di Forza o Destrezza aumenta di 1, fino a un massimo di 20.\n- **Proprietà di Padronanza.** Sceglie un tipo di arma semplice o da guerra in cui ha competenza: può usarne la proprietà di padronanza. Può passare a un altro tipo di arma idoneo ogni volta che termina un Riposo Lungo."
				}
			}
		};
	}
}