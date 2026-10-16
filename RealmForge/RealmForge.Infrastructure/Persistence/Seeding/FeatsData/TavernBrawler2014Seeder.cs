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
					Description = "Any object within reach can be a weapon in your hands.\n- **Strength or Constitution +1.** Increase one of the two scores by 1, to a maximum of 20.\n- **Brawler's Training.** You are proficient with improvised weapons and unarmed strikes.\n- **Heavy Fists.** Your unarmed strikes use a d4 as their damage die.\n- **Grab Hold.** When you hit a creature with an unarmed strike or an improvised weapon on your turn, you can use a bonus action to try to grapple it."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Lottatore da Taverna",
					Description = "Qualsiasi oggetto a portata di mano può diventare un'arma per il personaggio.\n- **Forza o Costituzione +1.** Uno dei due punteggi aumenta di 1, fino a un massimo di 20.\n- **Addestramento da rissa.** Ha competenza nelle armi improvvisate e nei colpi senz'armi.\n- **Pugni pesanti.** I suoi colpi senz'armi usano un d4 come dado di danno.\n- **Presa.** Quando colpisce una creatura con un colpo senz'armi o un'arma improvvisata durante il suo turno, può usare un'azione bonus per tentare di afferrarla."
				}
			}
		};
	}
}