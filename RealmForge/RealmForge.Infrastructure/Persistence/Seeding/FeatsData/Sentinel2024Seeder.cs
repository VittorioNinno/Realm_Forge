using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Sentinel feat (2024 ruleset).
///	</summary>
public static class Sentinel2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555584");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551341");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551342");

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
			PrerequisiteAbilities = new List<AbilityScore> { AbilityScore.Strength, AbilityScore.Dexterity },
			PrerequisiteMinimumScore = 13,
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Sentinel",
					Description = "Enemies near you can neither slip away nor ignore you.\n- **Strength or Dexterity +1.** Increase one of the two scores by 1, to a maximum of 20.\n- **Watchful Guard.** Right after a creature within 5 feet of you takes the Disengage action, or hits a target other than you with an attack, you can make an Opportunity Attack against it.\n- **Stop in Their Tracks.** When your Opportunity Attack hits a creature, its Speed becomes 0 for the rest of the current turn."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Sentinella",
					Description = "I nemici vicini al personaggio non possono né sgusciare via né ignorarlo.\n- **Forza o Destrezza +1.** Uno dei due punteggi aumenta di 1, fino a un massimo di 20.\n- **Guardia vigile.** Subito dopo che una creatura entro 1,5 metri da lui effettua l'azione Disimpegno, o colpisce con un attacco un bersaglio diverso da lui, può effettuare un attacco di opportunità contro di essa.\n- **Fermarli sul posto.** Quando un suo attacco di opportunità colpisce una creatura, la velocità di quella creatura diventa 0 per il resto del turno in corso."
				}
			}
		};
	}
}