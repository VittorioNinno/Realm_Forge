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
					Description = "You have practiced moving in medium armor to gain the following benefits:\n- Wearing medium armor doesn't impose disadvantage on your Dexterity (Stealth) checks.\n- When you wear medium armor, you can add 3, rather than 2, to your AC if you have a Dexterity of 16 or higher."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Maestro delle Armature Medie",
					Description = "Il personaggio si è addestrato per muoversi con efficacia quando indossa un'armatura media e ottiene i benefici seguenti:\n- Se indossa un'armatura media non subisce svantaggio alle proprie prove di Destrezza (Furtività).\n- Quando indossa un'armatura media, può aggiungere +3 anziché +2 alla propria CA se possiede una Destrezza pari o superiore a 16."
				}
			}
		};
	}
}