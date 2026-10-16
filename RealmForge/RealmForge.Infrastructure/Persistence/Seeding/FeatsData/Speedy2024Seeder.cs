using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Speedy feat (2024 ruleset).
///	</summary>
public static class Speedy2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555591");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551411");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551412");

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
			PrerequisiteAbilities = new List<AbilityScore> { AbilityScore.Dexterity, AbilityScore.Constitution },
			PrerequisiteMinimumScore = 13,
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Speedy",
					Description = "You are fast and hard to pin down.\n- **Dexterity or Constitution +1.** Increase one of the two scores by 1, to a maximum of 20.\n- **Faster.** Your Speed increases by 10 feet.\n- **Sure-Footed Dash.** On a turn in which you take the Dash action, Difficult Terrain costs you no extra movement for the rest of that turn.\n- **Hard to Catch.** Opportunity Attacks against you have Disadvantage."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Rapidità",
					Description = "Il personaggio è veloce e difficile da bloccare.\n- **Destrezza o Costituzione +1.** Uno dei due punteggi aumenta di 1, fino a un massimo di 20.\n- **Più veloce.** La sua velocità aumenta di 3 metri.\n- **Scatto sicuro.** Nel turno in cui effettua l'azione Scatto, il terreno difficile non gli costa movimento aggiuntivo per il resto di quel turno.\n- **Difficile da prendere.** Gli attacchi di opportunità contro di lui hanno Svantaggio."
				}
			}
		};
	}
}