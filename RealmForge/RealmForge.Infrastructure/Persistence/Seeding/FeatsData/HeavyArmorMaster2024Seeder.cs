using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Heavy Armor Master feat (2024 ruleset).
///	</summary>
public static class HeavyArmorMaster2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555569");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551191");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551192");

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
			PrerequisiteFeature = FeatFeatureRequirement.HeavyArmor,
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Heavy Armor Master",
					Description = "Your armor shrugs off blows that would fell others.\n- **Constitution or Strength +1.** Increase one of the two scores by 1, to a maximum of 20.\n- **Damage Reduction.** While you wear Heavy armor, when an attack hits you, the Bludgeoning, Piercing, and Slashing damage it deals you is reduced by your Proficiency Bonus."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Maestro delle Armature Pesanti",
					Description = "L'armatura del personaggio respinge colpi che abbatterebbero chiunque altro.\n- **Costituzione o Forza +1.** Uno dei due punteggi aumenta di 1, fino a un massimo di 20.\n- **Riduzione dei danni.** Mentre indossa un'armatura pesante, quando un attacco lo colpisce, i danni contundenti, perforanti e taglienti che gli infligge sono ridotti di un ammontare pari al suo bonus di competenza."
				}
			}
		};
	}
}