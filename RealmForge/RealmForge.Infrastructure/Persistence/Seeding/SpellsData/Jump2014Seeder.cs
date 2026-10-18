using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Jump (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Jump2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "jump");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 1,
			School = SpellSchool.Transmutation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Druid, SpellcastingClass.Ranger, SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "jump", "en"),
					Language = LanguageCode.En,
					Name = "Jump",
					CastingTime = "1 action",
					Range = "Touch",
					Duration = "1 minute",
					MaterialComponent = "a grasshopper's hind leg",
					Description = "You touch a creature. The creature's jump distance is tripled until the spell ends.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "jump", "it"),
					Language = LanguageCode.It,
					Name = "Saltare",
					CastingTime = "1 azione",
					Range = "Contatto",
					Duration = "1 minuto",
					MaterialComponent = "la zampa posteriore di una cavalletta",
					Description = "L'incantatore tocca una creatura. La distanza di salto della creatura triplica finché l'incantesimo non termina.",
					HigherLevels = null
				}
			}
		};
	}
}
