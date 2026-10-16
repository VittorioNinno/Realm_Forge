using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Boon of Speed feat (2024 ruleset).
///	</summary>
public static class BoonOfSpeed2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555615");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551651");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551652");

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
			Category = FeatCategory.EpicBoon,
			PrerequisiteMinimumLevel = 19,
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Boon of Speed",
					Description = "You move faster than the eye can follow.\n- **Ability Score Increase.** Increase one ability score of your choice by 1, to a maximum of 30.\n- **Escape Artist.** As a Bonus Action, you can take the Disengage action; doing so also ends the Grappled condition on you.\n- **Quickness.** Your Speed increases by 30 feet."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Dono della Velocità",
					Description = "Il personaggio si muove più veloce di quanto l'occhio riesca a seguire.\n- **Incremento dei Punteggi di Caratteristica.** Un punteggio di caratteristica a scelta aumenta di 1, fino a un massimo di 30.\n- **Artista della Fuga.** Come Azione Bonus, può effettuare l'azione Disimpegno; così facendo pone anche fine alla condizione Afferrato su di sé.\n- **Rapidità.** La sua velocità aumenta di 9 metri."
				}
			}
		};
	}
}