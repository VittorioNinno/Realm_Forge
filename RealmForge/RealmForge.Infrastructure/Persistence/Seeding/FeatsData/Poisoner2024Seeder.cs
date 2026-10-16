using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Poisoner feat (2024 ruleset).
///	</summary>
public static class Poisoner2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555580");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551301");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551302");

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
					Name = "Poisoner",
					Description = "You prepare toxins that work even on the hardiest victims.\n- **Ability Score Increase.** Increase your Dexterity or Intelligence score by 1, to a maximum of 20.\n- **Potent Poison.** Poison damage you deal ignores Resistance to Poison damage.\n- **Brew Poison.** You gain proficiency with the Poisoner's Kit. With 1 hour of work with the kit and 50 GP of materials, you prepare a number of doses equal to your Proficiency Bonus. As a Bonus Action, you can coat a weapon or piece of ammunition with a dose; the coating lasts 1 minute or until you deal damage with that item, whichever comes first. A creature damaged by the coated item makes a Constitution saving throw (DC 8 + the modifier of the ability increased by this feat + your Proficiency Bonus); on a failure, it takes 2d8 Poison damage and has the Poisoned condition until the end of your next turn."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Maestria dei Veleni",
					Description = "Il personaggio prepara tossine che funzionano anche sulle vittime più resistenti.\n- **Incremento dei Punteggi di Caratteristica.** Il punteggio di Destrezza o Intelligenza aumenta di 1, fino a un massimo di 20.\n- **Veleno Potente.** I danni da veleno che infligge ignorano la Resistenza ai danni da veleno.\n- **Creare Veleni.** Ottiene competenza nella borsa da avvelenatore. Con 1 ora di lavoro con la borsa e 50 mo di materiali, prepara un numero di dosi pari al suo Bonus di Competenza. Come Azione Bonus, può ricoprire con una dose un'arma o una munizione; il veleno resta attivo per 1 minuto o finché non infligge danni con quell'oggetto, a seconda di cosa avviene prima. Una creatura danneggiata dall'oggetto avvelenato effettua un Tiro Salvezza su Costituzione (CD 8 + il modificatore della caratteristica aumentata con questo talento + il Bonus di Competenza del personaggio); se lo fallisce, subisce 2d8 danni da veleno e ha la condizione Avvelenato fino alla fine del turno successivo del personaggio."
				}
			}
		};
	}
}