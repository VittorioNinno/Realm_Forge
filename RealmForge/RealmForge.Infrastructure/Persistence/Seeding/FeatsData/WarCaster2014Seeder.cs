using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the War Caster feat (2014 ruleset).
///	</summary>
public static class WarCaster2014Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555542");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555921");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555922");

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
					Name = "War Caster",
					Description = "You cast spells calmly even in the thick of battle.\n- You have advantage on Constitution saving throws to keep concentrating on a spell when you take damage.\n- You can perform somatic components even with weapons or a shield in one or both hands.\n- When a hostile creature's movement provokes an opportunity attack from you, you can use your reaction to cast a spell at it instead. The spell must have a casting time of 1 action and must target only that creature."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Incantatore da Guerra",
					Description = "Il personaggio lancia incantesimi con calma anche nel pieno della battaglia.\n- Ha vantaggio ai tiri salvezza su Costituzione per mantenere la concentrazione su un incantesimo quando subisce danni.\n- Può eseguire le componenti somatiche anche con armi o uno scudo in una o entrambe le mani.\n- Quando il movimento di una creatura ostile provoca un suo attacco di opportunità, può invece usare la reazione per lanciarle contro un incantesimo. L'incantesimo deve avere un tempo di lancio di 1 azione e bersagliare solo quella creatura."
				}
			}
		};
	}
}