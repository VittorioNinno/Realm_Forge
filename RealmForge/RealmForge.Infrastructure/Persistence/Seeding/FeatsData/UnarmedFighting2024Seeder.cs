using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Unarmed Fighting feat (2024 ruleset).
///	</summary>
public static class UnarmedFighting2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555606");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551561");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551562");

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
					Name = "Unarmed Fighting",
					Description = "Your bare hands are trained weapons.\n- **Trained Strikes.** When your Unarmed Strike hits and deals damage, you can deal Bludgeoning damage equal to 1d6 + your Strength modifier instead of the normal damage. If you are holding no weapons and no Shield when you make the attack roll, use a d8 instead of the d6.\n- **Crushing Hold.** At the start of each of your turns, you can deal 1d4 Bludgeoning damage to one creature you have Grappled."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Combattere Disarmato",
					Description = "Le mani nude del personaggio sono armi addestrate.\n- **Colpi addestrati.** Quando il suo colpo senz'armi colpisce e infligge danni, può infliggere danni contundenti pari a 1d6 + il suo modificatore di Forza invece dei danni normali. Se quando effettua il tiro per colpire non impugna armi né uno scudo, usa un d8 al posto del d6.\n- **Stretta schiacciante.** All'inizio di ogni suo turno, può infliggere 1d4 danni contundenti a una creatura che sta afferrando."
				}
			}
		};
	}
}