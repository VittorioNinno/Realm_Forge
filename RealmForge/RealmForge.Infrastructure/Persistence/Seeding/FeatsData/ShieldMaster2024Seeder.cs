using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Shield Master feat (2024 ruleset).
///	</summary>
public static class ShieldMaster2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555587");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551371");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551372");

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
			PrerequisiteFeature = FeatFeatureRequirement.Shield,
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Shield Master",
					Description = "Your shield is both a wall and a weapon.\n- **Strength +1.** Increase your Strength score by 1, to a maximum of 20.\n- **Shield Slam.** Once per turn, when you hit a creature within 5 feet of you with a Melee weapon as part of the Attack action, you can strike it with your equipped Shield. The target makes a Strength saving throw (DC 8 + your Strength modifier + your Proficiency Bonus); on a failure, you either push it 5 feet away or knock it Prone, your choice.\n- **Shield Wall.** While holding a Shield, when an effect lets you make a Dexterity saving throw to take only half damage, you can use your Reaction to take no damage if you succeed."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Maestro degli Scudi",
					Description = "Lo scudo del personaggio è al tempo stesso un muro e un'arma.\n- **Forza +1.** Il punteggio di Forza aumenta di 1, fino a un massimo di 20.\n- **Colpo di scudo.** Una volta per turno, quando colpisce una creatura entro 1,5 metri con un'arma da mischia durante l'azione Attacco, può percuoterla con lo scudo che ha equipaggiato. Il bersaglio effettua un tiro salvezza su Forza (CD 8 + il modificatore di Forza del personaggio + il suo bonus di competenza); se lo fallisce, il personaggio lo spinge di 1,5 metri o lo rende prono, a sua scelta.\n- **Muro di scudi.** Mentre impugna uno scudo, quando un effetto gli consente un tiro salvezza su Destrezza per subire solo metà danni, può usare la Reazione per non subire alcun danno se lo supera."
				}
			}
		};
	}
}