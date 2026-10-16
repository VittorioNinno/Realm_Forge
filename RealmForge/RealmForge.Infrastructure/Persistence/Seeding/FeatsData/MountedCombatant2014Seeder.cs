using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Mounted Combatant feat (2014 ruleset).
///	</summary>
public static class MountedCombatant2014Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555528");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555781");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555782");

	///	<summary>
	///	Builds the canonical SRD definition of this feat. Persistence is handled by FeatSeeder.
	///	</summary>
	public static Feat Build()
	{
		return new Feat
		{
			Id = FeatId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Category = FeatCategory.General,
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Mounted Combatant",
					Description = "You and your mount fight as one.\nWhile you are mounted and not incapacitated:\n- **High Ground.** You have advantage on melee attack rolls against unmounted creatures smaller than your mount.\n- **Protect the Mount.** You can make an attack aimed at your mount target you instead.\n- **Evasive Mount.** When your mount makes a Dexterity saving throw against an effect that deals half damage on a success, it takes no damage if it succeeds and only half damage if it fails."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Combattente in Sella",
					Description = "Il personaggio e la sua cavalcatura combattono come una cosa sola.\nMentre è in sella e non è incapacitato:\n- **Posizione elevata.** Ha vantaggio ai tiri per colpire in mischia contro le creature non in sella più piccole della sua cavalcatura.\n- **Proteggere la cavalcatura.** Può fare in modo che un attacco diretto alla sua cavalcatura bersagli invece lui.\n- **Cavalcatura agile.** Quando la sua cavalcatura effettua un tiro salvezza su Destrezza contro un effetto che infligge metà danni in caso di successo, non subisce danni se lo supera e subisce solo metà danni se lo fallisce."
				}
			}
		};
	}
}