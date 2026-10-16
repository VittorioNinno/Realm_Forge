using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Great Weapon Master feat (2024 ruleset).
///	</summary>
public static class GreatWeaponMaster2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555567");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551171");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551172");

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
			PrerequisiteAbilities = new List<AbilityScore> { AbilityScore.Strength },
			PrerequisiteMinimumScore = 13,
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Great Weapon Master",
					Description = "Heavy weapons become an extension of your strength.\n- **Ability Score Increase.** Increase your Strength score by 1, to a maximum of 20.\n- **Heavy Weapon Mastery.** When you hit a creature with a Heavy weapon as part of the Attack action on your turn, you can have the attack deal extra damage equal to your Proficiency Bonus.\n- **Hew.** Right after you score a Critical Hit with a Melee weapon or reduce a creature to 0 Hit Points with one, you can make one attack with the same weapon as a Bonus Action."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Maestro d'Armi Possenti",
					Description = "Le armi pesanti diventano un prolungamento della forza del personaggio.\n- **Incremento dei Punteggi di Caratteristica.** Il punteggio di Forza aumenta di 1, fino a un massimo di 20.\n- **Padronanza delle Armi Pesanti.** Quando colpisce una creatura con un'arma pesante durante l'azione Attacco nel suo turno, può far sì che l'attacco infligga danni aggiuntivi pari al suo Bonus di Competenza.\n- **Abbattimento.** Subito dopo aver messo a segno un Colpo Critico con un'arma da mischia, o aver portato una creatura a 0 Punti Ferita con essa, può effettuare un attacco con la stessa arma come Azione Bonus."
				}
			}
		};
	}
}