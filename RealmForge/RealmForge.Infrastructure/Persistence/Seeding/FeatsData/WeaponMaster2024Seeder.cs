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
					Description = "You gain the following benefits:\n- **Ability Score Increase.** Increase your Strength or Dexterity score by 1, to a maximum of 20.\n- **Mastery Property.** Your training with weapons allows you to use the mastery property of one kind of Simple or Martial weapon of your choice, provided you have proficiency with it. Whenever you finish a Long Rest, you can change the kind of weapon to another eligible kind."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Maestro d'Armi",
					Description = "Il personaggio ottiene i seguenti benefici:\n- **Incremento dei Punteggi di Caratteristica.** Il suo punteggio di Forza o Destrezza aumenta di 1, fino a un massimo di 20.\n- **Proprietà di Padronanza.** Grazie al suo addestramento, il personaggio può avvalersi della proprietà di padronanza per un tipo di arma semplice o da guerra a sua scelta, ammesso che ne possieda già la competenza. Ogni volta che termina un Riposo Lungo, può cambiare il tipo di arma con un altro idoneo."
				}
			}
		};
	}
}