using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Skulker feat (2014 ruleset).
///	</summary>
public static class Skulker2014Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555538");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555881");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555882");

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
			PrerequisiteAbilities = new List<AbilityScore> { AbilityScore.Dexterity },
			PrerequisiteMinimumScore = 13,
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Skulker",
					Description = "Shadows are your natural element.\n- **Hide in Light Cover.** You can try to hide from a creature even when you are only lightly obscured from it.\n- **Silent Misses.** If you are hidden from a creature and miss it with a ranged weapon attack, the attack doesn't give away your position.\n- **Eyes in the Gloom.** Dim light doesn't give you disadvantage on Wisdom (Perception) checks that rely on sight."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Appostato",
					Description = "L'ombra è l'elemento naturale del personaggio.\n- **Nascondersi nella penombra.** Può tentare di nascondersi da una creatura anche quando è solo leggermente oscurato rispetto a essa.\n- **Mancati silenziosi.** Se è nascosto a una creatura e la manca con un attacco con un'arma a distanza, l'attacco non rivela la sua posizione.\n- **Occhi nella penombra.** La luce fioca non gli impone svantaggio alle prove di Saggezza (Percezione) basate sulla vista."
				}
			}
		};
	}
}