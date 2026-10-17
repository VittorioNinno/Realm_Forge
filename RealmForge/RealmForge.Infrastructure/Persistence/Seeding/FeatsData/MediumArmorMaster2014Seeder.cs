using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Medium Armor Master feat (2014 ruleset).
///	</summary>
public static class MediumArmorMaster2014Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555525");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555751");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555752");

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
			PrerequisiteFeature = FeatFeatureRequirement.MediumArmor,
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Medium Armor Master",
					Description = "You move in medium armor as if it weren't there.\n- Medium armor doesn't give you disadvantage on Dexterity (Stealth) checks.\n- While wearing medium armor, you can add up to 3, rather than 2, to your AC if your Dexterity is 16 or higher."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Maestro delle Armature Medie",
					Description = "Il personaggio si muove in armatura media come se non la indossasse.\n- Le armature medie non gli impongono svantaggio alle prove di Destrezza (Furtività).\n- Mentre indossa un'armatura media, se ha Destrezza 16 o superiore può aggiungere alla CA fino a 3 anziché fino a 2."
				}
			}
		};
	}
}