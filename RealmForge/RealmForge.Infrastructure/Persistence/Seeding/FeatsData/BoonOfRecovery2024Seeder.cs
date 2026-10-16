using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Boon of Recovery feat (2024 ruleset).
///	</summary>
public static class BoonOfRecovery2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555613");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551631");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551632");

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
					Name = "Boon of Recovery",
					Description = "Your life force refuses to give out.\n- **Ability Score Increase.** Increase one ability score of your choice by 1, to a maximum of 30.\n- **Last Stand.** When you would drop to 0 Hit Points, you can drop to 1 Hit Point instead and then regain Hit Points equal to half your Hit Point maximum. You can't do this again until you finish a Long Rest.\n- **Recover Vitality.** You have a reserve of ten d10s. As a Bonus Action, you can spend any number of dice from the reserve, roll them, and regain Hit Points equal to the total. You recover all spent dice when you finish a Long Rest."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Dono del Recupero",
					Description = "La forza vitale del personaggio si rifiuta di cedere.\n- **Incremento dei Punteggi di Caratteristica.** Un punteggio di caratteristica a scelta aumenta di 1, fino a un massimo di 30.\n- **Incrollabile.** Quando scenderebbe a 0 Punti Ferita, può invece scendere a 1 Punto Ferita e poi recuperare Punti Ferita pari alla metà del suo massimo. Non può farlo di nuovo finché non termina un Riposo Lungo.\n- **Recupero di Vitalità.** Dispone di una riserva di dieci d10. Come Azione Bonus, può spendere un qualsiasi numero di dadi della riserva, tirarli e recuperare Punti Ferita pari al totale. Recupera tutti i dadi spesi quando termina un Riposo Lungo."
				}
			}
		};
	}
}