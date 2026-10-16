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
					Description = "Fighting with a weapon in each hand comes naturally to you.\n- **Ability Score Increase.** Increase your Strength or Dexterity score by 1, to a maximum of 20.\n- **Enhanced Dual Wielding.** When you take the Attack action and attack with a Light weapon, you can make one extra attack as a Bonus Action later that turn with a different weapon, which must be a Melee weapon without the Two-Handed property. You don't add your ability modifier to this extra attack's damage unless the modifier is negative.\n- **Quick Draw.** Whenever you could draw or stow one weapon without the Two-Handed property, you can draw or stow two instead."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Combattente a Due Armi",
					Description = "Combattere con un'arma in ciascuna mano è naturale per il personaggio.\n- **Incremento dei Punteggi di Caratteristica.** Il punteggio di Forza o Destrezza aumenta di 1, fino a un massimo di 20.\n- **Combattere con Due Armi Migliorato.** Quando effettua l'azione Attacco e attacca con un'arma leggera, può effettuare un attacco aggiuntivo come Azione Bonus più avanti nello stesso turno con un'arma diversa, che deve essere un'arma da mischia senza la proprietà a due mani. Non aggiunge il modificatore di caratteristica ai danni di questo attacco aggiuntivo, a meno che non sia negativo.\n- **Estrazione Rapida.** Quando potrebbe estrarre o riporre un'arma senza la proprietà a due mani, può estrarne o riporne due."
				}
			}
		};
	}
}