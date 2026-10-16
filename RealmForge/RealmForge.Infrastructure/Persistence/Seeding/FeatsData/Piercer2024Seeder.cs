using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Piercer feat (2024 ruleset).
///	</summary>
public static class Piercer2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555579");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551291");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551292");

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
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Piercer",
					Description = "Your thrusts find the gaps in any defense.\n- **Strength or Dexterity +1.** Increase one of the two scores by 1, to a maximum of 20.\n- **Find the Gap.** Once per turn, when an attack of yours hits a creature and deals Piercing damage, you can reroll one of the attack's damage dice; you must use the new result.\n- **Deep Wound.** When you score a Critical Hit that deals Piercing damage to a creature, you roll one additional damage die for the extra Piercing damage."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Stile Penetrante",
					Description = "Gli affondi del personaggio trovano i punti deboli di qualsiasi difesa.\n- **Forza o Destrezza +1.** Uno dei due punteggi aumenta di 1, fino a un massimo di 20.\n- **Trovare il varco.** Una volta per turno, quando un suo attacco colpisce una creatura e infligge danni perforanti, può ritirare uno dei dadi di danno dell'attacco; deve usare il nuovo risultato.\n- **Ferita profonda.** Quando mette a segno un colpo critico che infligge danni perforanti a una creatura, tira un dado di danno aggiuntivo per i danni perforanti extra."
				}
			}
		};
	}
}