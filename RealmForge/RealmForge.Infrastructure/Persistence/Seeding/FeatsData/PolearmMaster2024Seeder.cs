using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Polearm Master feat (2024 ruleset).
///	</summary>
public static class PolearmMaster2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555581");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551311");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551312");

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
					Name = "Polearm Master",
					Description = "Long weapons let you control the space around you.\n- **Ability Score Increase.** Increase your Dexterity or Strength score by 1, to a maximum of 20.\n- **Pole Strike.** Right after you take the Attack action and attack with a Quarterstaff, a Spear, or a weapon with both the Heavy and Reach properties, you can use a Bonus Action to make a melee attack with the other end of the weapon. It deals Bludgeoning damage, with a d4 as its damage die.\n- **Reactive Strike.** While holding one of those weapons, you can use your Reaction to make one melee attack against a creature that enters your reach with it."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Maestro delle Armi su Asta",
					Description = "Le armi lunghe permettono al personaggio di controllare lo spazio intorno a sé.\n- **Incremento dei Punteggi di Caratteristica.** Il punteggio di Destrezza o Forza aumenta di 1, fino a un massimo di 20.\n- **Colpo d'Asta.** Subito dopo aver effettuato l'azione Attacco e aver attaccato con un bastone ferrato, una lancia o un'arma che abbia sia la proprietà pesante sia la proprietà portata, può usare un'Azione Bonus per effettuare un attacco in mischia con l'altra estremità dell'arma. Infligge danni contundenti, con un d4 come dado di danno.\n- **Colpo Reattivo.** Mentre impugna una di quelle armi, può usare la Reazione per effettuare un attacco in mischia contro una creatura che entra nella portata che ha con essa."
				}
			}
		};
	}
}