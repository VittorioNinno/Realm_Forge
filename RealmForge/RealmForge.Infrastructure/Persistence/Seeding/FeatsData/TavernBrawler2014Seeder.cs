using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Tavern Brawler feat (2014 ruleset).
///	</summary>
public static class TavernBrawler2014Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555540");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555901");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555902");

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
					Name = "Tavern Brawler",
					Description = "Accustomed to rough-and-tumble fighting using whatever weapons happen to be at hand, you gain the following benefits:\n- Increase your Strength or Constitution score by 1, to a maximum of 20.\n- You are proficient with improvised weapons and unarmed strikes.\n- Your unarmed strike uses a d4 for damage.\n- When you hit a creature with an unarmed strike or an improvised weapon on your turn, you can use a bonus action to attempt to grapple the target."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Lottatore da Taverna",
					Description = "Il personaggio è abituato ai combattimenti più rozzi e diretti, dove si usa qualsiasi arma si trovi a portata di mano, e ottiene i benefici seguenti:\n- Il suo punteggio di Forza o di Costituzione aumenta di 1, fino a un massimo di 20.\n- È competente nelle armi improvvisate.\n- Il suo colpo senz'armi usa un d4 per i danni.\n- Quando colpisce una creatura con un colpo senz'armi o un'arma improvvisata nel suo turno, può usare un'azione bonus per tentare di afferrare il bersaglio."
				}
			}
		};
	}
}