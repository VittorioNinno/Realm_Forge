using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Slasher feat (2024 ruleset).
///	</summary>
public static class Slasher2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555590");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551401");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551402");

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
					Name = "Slasher",
					Description = "Your cuts slow and weaken your enemies.\n- **Ability Score Increase.** Increase your Strength or Dexterity score by 1, to a maximum of 20.\n- **Hamstring.** Once per turn, when an attack of yours hits a creature and deals Slashing damage, you can reduce its Speed by 10 feet until the start of your next turn.\n- **Enhanced Critical.** When you score a Critical Hit that deals Slashing damage to a creature, it has Disadvantage on attack rolls until the start of your next turn."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Bisturi da Battaglia",
					Description = "I fendenti del personaggio rallentano e indeboliscono i nemici.\n- **Incremento dei Punteggi di Caratteristica.** Il punteggio di Forza o Destrezza aumenta di 1, fino a un massimo di 20.\n- **Colpo Debilitante.** Una volta per turno, quando un suo attacco colpisce una creatura e infligge danni taglienti, può ridurne la velocità di 3 metri fino all'inizio del suo turno successivo.\n- **Critico Migliorato.** Quando mette a segno un Colpo Critico che infligge danni taglienti a una creatura, quella creatura ha Svantaggio ai tiri per colpire fino all'inizio del turno successivo del personaggio."
				}
			}
		};
	}
}