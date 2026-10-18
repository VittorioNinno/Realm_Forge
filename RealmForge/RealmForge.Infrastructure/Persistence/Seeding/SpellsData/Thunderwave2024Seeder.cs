using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Thunderwave (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Thunderwave2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "thunderwave");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 1,
			School = SpellSchool.Evocation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Druid, SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "thunderwave", "en"),
					Language = LanguageCode.En,
					Name = "Thunderwave",
					CastingTime = "Action",
					Range = "Self",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "You unleash a wave of thunderous energy. Each creature in a 15-foot Cube originating from you makes a Constitution saving throw. On a failed save, a creature takes 2d8 Thunder damage and is pushed 10 feet away from you. On a successful save, a creature takes half as much damage only.\n\nIn addition, unsecured objects that are entirely within the Cube are pushed 10 feet away from you, and a thunderous boom is audible within 300 feet.",
					HigherLevels = "The damage increases by 1d8 for each spell slot level above 1."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "thunderwave", "it"),
					Language = LanguageCode.It,
					Name = "Onda Tonante",
					CastingTime = "Azione",
					Range = "Incantatore",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "L'incantatore scatena un'onda di energia tonante. Ogni creatura in un cubo con spigolo di 4,5 metri che ha origine dall'incantatore effettua un tiro salvezza su Costituzione. Se lo fallisce, una creatura subisce 2d8 danni da tuono e viene spinta di 3 metri lontano dall'incantatore. Se lo supera, una creatura subisce soltanto la metà dei danni.\n\nInoltre, gli oggetti non fissati che si trovano interamente all'interno del cubo vengono spinti di 3 metri lontano dall'incantatore, e un boato tonante è udibile entro 90 metri.",
					HigherLevels = "I danni aumentano di 1d8 per ogni livello dello slot incantesimo superiore al 1°."
				}
			}
		};
	}
}
