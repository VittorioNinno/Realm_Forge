using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Crossbow Expert feat (2014 ruleset).
///	</summary>
public static class CrossbowExpert2014Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555506");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555561");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555562");

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
					Name = "Crossbow Expert",
					Description = "Crossbows hold no secrets for you.\n- You ignore the loading property of crossbows you are proficient with.\n- Having a hostile creature within 5 feet of you doesn't give you disadvantage on ranged attack rolls.\n- When you take the Attack action and attack with a one-handed weapon, you can use a bonus action to attack with a loaded hand crossbow you are holding."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Esperto di Balestre",
					Description = "Le balestre non hanno segreti per il personaggio.\n- Ignora la proprietà ricarica delle balestre in cui ha competenza.\n- Avere una creatura ostile entro 1,5 metri non gli impone svantaggio ai tiri per colpire a distanza.\n- Quando usa l'azione Attacco e attacca con un'arma a una mano, può usare un'azione bonus per attaccare con una balestra a mano carica che impugna."
				}
			}
		};
	}
}