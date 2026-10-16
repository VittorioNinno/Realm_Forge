using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Chef feat (2024 ruleset).
///	</summary>
public static class Chef2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555558");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551081");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551082");

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
					Name = "Chef",
					Description = "Your cooking restores body and spirit.\n- **Constitution or Wisdom +1.** Increase one of the two scores by 1, to a maximum of 20.\n- **Kitchen Training.** You gain proficiency with Cook's Utensils if you don't already have it.\n- **Hearty Meal.** During a Short Rest, if you have ingredients and Cook's Utensils, you can prepare a meal for up to 4 + your Proficiency Bonus creatures. At the end of the rest, each creature that ate it and spends one or more Hit Point Dice to heal regains an extra 1d8 Hit Points.\n- **Energizing Snacks.** With 1 hour of work, or when you finish a Long Rest, you can prepare a number of snacks equal to your Proficiency Bonus, provided you have ingredients and Cook's Utensils. The snacks stay fresh for 8 hours. A creature can eat one as a Bonus Action to gain Temporary Hit Points equal to your Proficiency Bonus."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Cuoco",
					Description = "La cucina del personaggio ristora il corpo e lo spirito.\n- **Costituzione o Saggezza +1.** Uno dei due punteggi aumenta di 1, fino a un massimo di 20.\n- **Addestramento in cucina.** Ottiene competenza negli utensili da cuoco, se non l'ha già.\n- **Pasto sostanzioso.** Durante un riposo breve, se dispone di ingredienti e utensili da cuoco, può preparare un pasto per un massimo di 4 + il suo bonus di competenza creature. Al termine del riposo, ogni creatura che lo ha mangiato e spende uno o più Dadi Vita per curarsi recupera 1d8 punti ferita aggiuntivi.\n- **Spuntini energetici.** Con 1 ora di lavoro, o quando termina un riposo lungo, può preparare un numero di spuntini pari al suo bonus di competenza, purché disponga di ingredienti e utensili da cuoco. Gli spuntini restano buoni per 8 ore. Una creatura può mangiarne uno come azione bonus per ottenere punti ferita temporanei pari al bonus di competenza del personaggio."
				}
			}
		};
	}
}