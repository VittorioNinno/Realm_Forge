using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Crusher feat (2024 ruleset).
///	</summary>
public static class Crusher2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555560");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551101");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551102");

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
					Name = "Crusher",
					Description = "Your blunt blows shove and stagger your foes.\n- **Ability Score Increase.** Increase your Strength or Constitution score by 1, to a maximum of 20.\n- **Push.** Once per turn, when an attack of yours hits a creature and deals Bludgeoning damage, you can move the target 5 feet into an unoccupied space, provided it is no more than one size larger than you.\n- **Enhanced Critical.** When you score a Critical Hit that deals Bludgeoning damage to a creature, attack rolls against it have Advantage until the start of your next turn."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Martello Vivente",
					Description = "I colpi contundenti del personaggio spingono e frastornano i nemici.\n- **Incremento dei Punteggi di Caratteristica.** Il punteggio di Forza o Costituzione aumenta di 1, fino a un massimo di 20.\n- **Spinta.** Una volta per turno, quando un suo attacco colpisce una creatura e infligge danni contundenti, può spostare il bersaglio di 1,5 metri in uno spazio libero, purché non sia più di una taglia più grande di lui.\n- **Critico Migliorato.** Quando mette a segno un Colpo Critico che infligge danni contundenti a una creatura, i tiri per colpire contro quella creatura hanno Vantaggio fino all'inizio del turno successivo del personaggio."
				}
			}
		};
	}
}