using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Elemental Adept feat (2014 ruleset).
///	</summary>
public static class ElementalAdept2014Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555511");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555611");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555612");

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
			PrerequisiteFeature = FeatFeatureRequirement.Spellcasting,
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Elemental Adept",
					Description = "You bend one element to your will.\n- **Chosen Element.** Pick acid, cold, fire, lightning, or thunder.\n- **Pierce Resistance.** Your spells ignore resistance to damage of the chosen type.\n- **Steady Power.** When you roll damage for one of your spells that deals the chosen type, any 1 on a damage die counts as a 2.\n- **Repeatable.** You can take this feat more than once, choosing a different damage type each time."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Adepto Elementale",
					Description = "Il personaggio piega un elemento al proprio volere.\n- **Elemento prescelto.** Sceglie acido, freddo, fuoco, fulmine o tuono.\n- **Oltre le resistenze.** I suoi incantesimi ignorano la resistenza ai danni del tipo scelto.\n- **Potere costante.** Quando tira i danni di un suo incantesimo che infligge il tipo scelto, ogni 1 su un dado di danno conta come 2.\n- **Ripetibile.** Può ottenere questo talento più volte, scegliendo ogni volta un tipo di danno diverso."
				}
			}
		};
	}
}