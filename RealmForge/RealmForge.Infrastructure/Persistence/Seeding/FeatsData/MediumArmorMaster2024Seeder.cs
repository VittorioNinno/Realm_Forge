using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Medium Armor Master feat (2024 ruleset).
///	</summary>
public static class MediumArmorMaster2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555575");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551251");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551252");

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
			PrerequisiteFeature = FeatFeatureRequirement.MediumArmor,
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Medium Armor Master",
					Description = "You move in medium armor as if it weren't there.\n- **Ability Score Increase.** Increase your Strength or Dexterity score by 1, to a maximum of 20.\n- **Dexterous Wearer.** While wearing Medium armor, you can add up to 3, rather than 2, to your AC if your Dexterity is 16 or higher."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Maestro delle Armature Medie",
					Description = "Il personaggio si muove in armatura media come se non la indossasse.\n- **Incremento dei Punteggi di Caratteristica.** Il punteggio di Forza o Destrezza aumenta di 1, fino a un massimo di 20.\n- **Agilità con Armatura.** Mentre indossa un'armatura media, se ha Destrezza 16 o superiore può aggiungere alla CA fino a 3 anziché fino a 2."
				}
			}
		};
	}
}