using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Thrown Weapon Fighting feat (2024 ruleset).
///	</summary>
public static class ThrownWeaponFighting2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555604");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551541");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551542");

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
			Category = FeatCategory.FightingStyle,
			PrerequisiteFeature = FeatFeatureRequirement.FightingStyle,
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Thrown Weapon Fighting",
					Description = "Your throws carry extra force.\n\nWhen you hit with a ranged attack roll using a weapon with the Thrown property, you gain a +2 bonus to the damage roll."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Combattere con Armi da Lancio",
					Description = "I lanci del personaggio hanno una forza in più.\n\nQuando colpisce con un tiro per colpire a distanza usando un'arma con la proprietà da lancio, ottiene un bonus di +2 al tiro per i danni."
				}
			}
		};
	}
}