using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Savage Attacker feat (2024 ruleset).
///	</summary>
public static class SavageAttacker2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555550");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551001");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551002");

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
			Source = ContentSource.Srd52,
			Category = FeatCategory.Origin,
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Savage Attacker",
					Description = "You've trained to deal particularly damaging strikes. Once per turn when you hit a target with a weapon, you can roll the weapon's damage dice twice and use either roll against the target."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Aggressore Selvaggio",
					Description = "Il personaggio si è allenato per sferrare colpi particolarmente letali. Una volta per turno, quando colpisce un bersaglio con un'arma, può tirare due volte per i danni e scegliere il risultato che preferisce."
				}
			}
		};
	}
}