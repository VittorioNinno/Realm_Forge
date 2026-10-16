using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the War Caster feat (2024 ruleset).
///	</summary>
public static class WarCaster2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555595");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551451");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551452");

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
			PrerequisiteFeature = FeatFeatureRequirement.SpellcastingOrPactMagic,
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "War Caster",
					Description = "You cast spells calmly even in the thick of battle.\n- **Intelligence, Wisdom, or Charisma +1.** Increase one of these scores by 1, to a maximum of 20.\n- **Steady Concentration.** You have Advantage on Constitution saving throws to maintain Concentration.\n- **Spell Instead of Strike.** When a creature provokes an Opportunity Attack from you by leaving your reach, you can use your Reaction to cast a spell at it instead. The spell must have a casting time of one action and must target only that creature.\n- **Hands Full.** You can perform Somatic components even with weapons or a Shield in one or both hands."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Incantatore da Guerra",
					Description = "Il personaggio lancia incantesimi con calma anche nel pieno della battaglia.\n- **Intelligenza, Saggezza o Carisma +1.** Uno di questi punteggi aumenta di 1, fino a un massimo di 20.\n- **Concentrazione salda.** Ha Vantaggio ai tiri salvezza su Costituzione per mantenere la Concentrazione.\n- **Incantesimo invece del colpo.** Quando una creatura provoca un suo attacco di opportunità uscendo dalla sua portata, può invece usare la Reazione per lanciarle contro un incantesimo. L'incantesimo deve avere un tempo di lancio di un'azione e bersagliare solo quella creatura.\n- **Mani occupate.** Può eseguire le componenti somatiche anche con armi o uno scudo in una o entrambe le mani."
				}
			}
		};
	}
}