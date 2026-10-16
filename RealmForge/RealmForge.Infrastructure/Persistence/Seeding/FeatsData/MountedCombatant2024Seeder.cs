using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Mounted Combatant feat (2024 ruleset).
///	</summary>
public static class MountedCombatant2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555577");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551271");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551272");

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
					Name = "Mounted Combatant",
					Description = "You and your mount fight as one.\n- **Strength, Dexterity, or Wisdom +1.** Increase one of these scores by 1, to a maximum of 20.\n- **High Ground.** While mounted, you have Advantage on attack rolls against unmounted creatures within 5 feet of your mount that are at least one size smaller than it.\n- **Evasive Mount.** When your mount makes a Dexterity saving throw against an effect that deals half damage on a success, it takes no damage if it succeeds and only half damage if it fails. This works only while you are riding it and neither of you has the Incapacitated condition.\n- **Take the Blow.** While mounted and not Incapacitated, you can have an attack that hits your mount hit you instead."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Combattente in Sella",
					Description = "Il personaggio e la sua cavalcatura combattono come una cosa sola.\n- **Forza, Destrezza o Saggezza +1.** Uno di questi punteggi aumenta di 1, fino a un massimo di 20.\n- **Posizione elevata.** Mentre è in sella, ha Vantaggio ai tiri per colpire contro le creature non in sella entro 1,5 metri dalla cavalcatura che siano almeno di una taglia più piccole di essa.\n- **Cavalcatura agile.** Quando la sua cavalcatura effettua un tiro salvezza su Destrezza contro un effetto che infligge metà danni in caso di successo, non subisce danni se lo supera e subisce solo metà danni se lo fallisce. Funziona solo mentre il personaggio la cavalca e nessuno dei due ha la condizione di incapacitato.\n- **Prendere il colpo.** Mentre è in sella e non è incapacitato, può fare in modo che un attacco che colpisce la cavalcatura colpisca invece lui."
				}
			}
		};
	}
}