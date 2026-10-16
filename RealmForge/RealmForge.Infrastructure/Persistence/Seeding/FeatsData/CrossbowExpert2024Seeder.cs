using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Crossbow Expert feat (2024 ruleset).
///	</summary>
public static class CrossbowExpert2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555559");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551091");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551092");

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
			Category = FeatCategory.General,
			PrerequisiteMinimumLevel = 4,
			PrerequisiteAbilities = new List<AbilityScore> { AbilityScore.Dexterity },
			PrerequisiteMinimumScore = 13,
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Crossbow Expert",
					Description = "You handle crossbows with uncommon speed and precision.\n- **Dexterity +1.** Increase your Dexterity score by 1, to a maximum of 20.\n- **Effortless Reload.** You ignore the Loading property of the hand crossbow, light crossbow, and heavy crossbow (the \"crossbows\" of this feat), and you can load one you are holding even without a free hand.\n- **Close-Quarters Shooting.** Having an enemy within 5 feet of you doesn't give you Disadvantage on attack rolls with crossbows.\n- **Paired Crossbows.** When you make the extra attack granted by the Light property with a crossbow that has that property, you can add your ability modifier to that attack's damage, unless you are already adding it."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Esperto di Balestre",
					Description = "Il personaggio maneggia le balestre con rapidità e precisione non comuni.\n- **Destrezza +1.** Il punteggio di Destrezza aumenta di 1, fino a un massimo di 20.\n- **Ricarica senza sforzo.** Ignora la proprietà ricarica della balestra a mano, della balestra leggera e della balestra pesante (le \"balestre\" di questo talento) e può caricarne una che impugna anche senza avere una mano libera.\n- **Tiro ravvicinato.** Avere un nemico entro 1,5 metri non gli impone Svantaggio ai tiri per colpire con le balestre.\n- **Balestre in coppia.** Quando effettua l'attacco aggiuntivo concesso dalla proprietà leggera con una balestra che ha quella proprietà, può aggiungere il suo modificatore di caratteristica ai danni di quell'attacco, a meno che non lo stia già aggiungendo."
				}
			}
		};
	}
}