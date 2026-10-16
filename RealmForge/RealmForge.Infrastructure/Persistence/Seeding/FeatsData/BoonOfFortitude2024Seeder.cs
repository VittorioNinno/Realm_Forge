using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Boon of Fortitude feat (2024 ruleset).
///	</summary>
public static class BoonOfFortitude2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555611");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551611");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551612");

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
					Name = "Boon of Fortitude",
					Description = "Your body has become extraordinarily hard to break.\n- **Ability +1.** Increase one ability score of your choice by 1, to a maximum of 30.\n- **Iron Constitution.** Your Hit Point maximum increases by 40.\n- **Vigorous Healing.** Whenever you regain Hit Points, you can regain extra Hit Points equal to your Constitution modifier. After doing so, you can't gain this extra healing again until the start of your next turn."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Dono della Tempra",
					Description = "Il corpo del personaggio è diventato straordinariamente difficile da abbattere.\n- **Caratteristica +1.** Un punteggio di caratteristica a scelta aumenta di 1, fino a un massimo di 30.\n- **Costituzione di ferro.** Il suo massimo dei punti ferita aumenta di 40.\n- **Guarigione vigorosa.** Ogni volta che recupera punti ferita, può recuperarne in aggiunta un numero pari al suo modificatore di Costituzione. Dopo averlo fatto, non può ottenere di nuovo questa guarigione aggiuntiva fino all'inizio del suo turno successivo."
				}
			}
		};
	}
}