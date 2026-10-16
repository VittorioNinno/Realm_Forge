using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Grappler feat (2014 ruleset).
///	</summary>
public static class Grappler2014Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555512");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555621");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555622");

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
			Source = ContentSource.Srd51,
			Category = FeatCategory.General,
			PrerequisiteAbilities = new List<AbilityScore> { AbilityScore.Strength },
			PrerequisiteMinimumScore = 13,
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Grappler",
					Description = "You've developed the skills necessary to hold your own in close-quarters grappling. You gain the following benefits:\n- You have advantage on attack rolls against a creature you are grappling.\n- You can use your action to try to pin a creature grappled by you. To do so, make another grapple check. If you succeed, you and the creature are both restrained until the grapple ends.\n- Creatures that are one size larger than you don't automatically succeed on checks to escape your grapple."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Lottatore",
					Description = "Il personaggio ha sviluppato le abilità necessarie per farsi valere nella lotta corpo a corpo. Ottiene i benefici seguenti:\n- Dispone di vantaggio ai tiri per colpire contro una creatura con cui sta lottando.\n- Può usare la sua azione per tentare di immobilizzare una creatura da lui afferrata. Per farlo deve effettuare un'altra prova di lotta. In caso di successo, il personaggio e la creatura sono entrambi trattenuti fino alla fine della lotta.\n- Le creature di una taglia superiore a quella del personaggio non superano automaticamente le prove per sfuggire alla sua lotta."
				}
			}
		};
	}
}