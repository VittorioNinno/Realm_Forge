using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Dual Wielder feat (2024 ruleset).
///	</summary>
public static class DualWielder2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555562");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551121");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551122");

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
					Name = "Dual Wielder",
					Description = "You gain the following benefits:\n- **Ability Score Increase.** Increase your Strength or Dexterity score by 1, to a maximum of 20.\n- **Enhanced Dual Wielding.** When you take the Attack action on your turn and attack with a weapon that has the Light property, you can make one extra attack as a Bonus Action later on the same turn with a different weapon, which must be a Melee weapon that lacks the Two-Handed property. You don't add your ability modifier to the extra attack's damage unless that modifier is negative.\n- **Quick Draw.** You can draw or stow two weapons that lack the Two-Handed property when you would normally be able to draw or stow only one."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Combattente a Due Armi",
					Description = "Il personaggio ottiene i seguenti benefici:\n- **Incremento dei Punteggi di Caratteristica.** Il suo punteggio di Forza o Destrezza aumenta di 1, fino a un massimo di 20.\n- **Combattere con Due Armi Migliorato.** Quando il personaggio utilizza un'azione di Attacco nel suo turno per attaccare con un'arma Leggera, durante lo stesso turno può usare un'azione bonus per sferrarne uno extra con un'arma diversa, a patto che sia un'arma da mischia senza la proprietà a due mani. Non può aggiungere il proprio modificatore di caratteristica all'attacco extra, a meno che non sia di valore negativo.\n- **Estrazione Rapida.** Il personaggio può estrarre o rinfoderare due armi senza la proprietà a due mani quando normalmente potrebbe eseguire tali azioni solo con una."
				}
			}
		};
	}
}