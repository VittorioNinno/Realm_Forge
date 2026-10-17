using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Defensive Duelist feat (2014 ruleset).
///	</summary>
public static class DefensiveDuelist2014Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555507");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555571");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555572");

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
					Name = "Defensive Duelist",
					Description = "Your blade is as much a shield as a weapon.\n- While you wield a finesse weapon you are proficient with, when a creature hits you with a melee attack you can use your reaction to add your proficiency bonus to your AC against that attack, possibly turning the hit into a miss."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Duellante Difensivo",
					Description = "La lama del personaggio è tanto uno scudo quanto un'arma.\n- Mentre impugna un'arma accurata in cui ha competenza, quando una creatura lo colpisce con un attacco in mischia può usare la reazione per aggiungere il suo bonus di competenza alla CA contro quell'attacco, che potrebbe così mancarlo."
				}
			}
		};
	}
}