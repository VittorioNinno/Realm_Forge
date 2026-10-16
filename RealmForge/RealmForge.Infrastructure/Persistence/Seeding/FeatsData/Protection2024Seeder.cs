using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Protection feat (2024 ruleset).
///	</summary>
public static class Protection2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555603");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551531");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551532");

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
					Name = "Protection",
					Description = "You raise your shield to guard those beside you.\n\nWhen a creature you can see attacks a target other than you within 5 feet of you, you can use your Reaction to interpose your Shield, if you are holding one. That attack roll, and every other attack roll against the target until the start of your next turn, has Disadvantage, as long as you stay within 5 feet of the target."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Protezione",
					Description = "Il personaggio alza lo scudo per proteggere chi gli sta accanto.\n\nQuando una creatura che può vedere attacca un bersaglio diverso da lui entro 1,5 metri, può usare la Reazione per frapporre il suo scudo, se ne impugna uno. Quel tiro per colpire, e ogni altro tiro per colpire contro il bersaglio fino all'inizio del suo turno successivo, ha Svantaggio, purché resti entro 1,5 metri dal bersaglio."
				}
			}
		};
	}
}