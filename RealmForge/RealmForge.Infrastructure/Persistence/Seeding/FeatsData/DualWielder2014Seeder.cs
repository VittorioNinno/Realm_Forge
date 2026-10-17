using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Dual Wielder feat (2014 ruleset).
///	</summary>
public static class DualWielder2014Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555508");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555581");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555582");

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
					Name = "Dual Wielder",
					Description = "Fighting with a weapon in each hand comes naturally to you.\n- While you wield a separate melee weapon in each hand, you gain a +1 bonus to AC.\n- You can fight with two weapons even when the one-handed melee weapons you wield lack the light property.\n- Whenever you could draw or stow one one-handed weapon, you can draw or stow two instead."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Combattente a Due Armi",
					Description = "Combattere con un'arma in ciascuna mano è naturale per il personaggio.\n- Mentre impugna un'arma da mischia distinta in ciascuna mano, ottiene un bonus di +1 alla CA.\n- Può combattere con due armi anche se le armi da mischia a una mano che impugna non hanno la proprietà leggera.\n- Quando potrebbe estrarre o riporre un'arma a una mano, può estrarne o riporne due."
				}
			}
		};
	}
}