using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Shield Master feat (2014 ruleset).
///	</summary>
public static class ShieldMaster2014Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555536");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555861");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555862");

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
					Name = "Shield Master",
					Description = "Your shield is both a wall and a weapon.\nWhile you wield a shield:\n- If you take the Attack action on your turn, you can use a bonus action to try to shove a creature within 5 feet of you with your shield.\n- If you aren't incapacitated, you add your shield's AC bonus to Dexterity saving throws against spells or other harmful effects that target only you.\n- When an effect lets you make a Dexterity saving throw to take only half damage, you can use your reaction to take no damage if you succeed, raising your shield between yourself and the source of the effect."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Maestro degli Scudi",
					Description = "Lo scudo del personaggio è al tempo stesso un muro e un'arma.\nMentre impugna uno scudo:\n- Se usa l'azione Attacco nel suo turno, può usare un'azione bonus per tentare di spingere con lo scudo una creatura entro 1,5 metri da lui.\n- Se non è incapacitato, aggiunge il bonus alla CA dello scudo ai tiri salvezza su Destrezza contro incantesimi o altri effetti dannosi che bersagliano solo lui.\n- Quando un effetto gli consente un tiro salvezza su Destrezza per subire solo metà danni, può usare la reazione per non subire alcun danno se lo supera, frapponendo lo scudo tra sé e la fonte dell'effetto."
				}
			}
		};
	}
}