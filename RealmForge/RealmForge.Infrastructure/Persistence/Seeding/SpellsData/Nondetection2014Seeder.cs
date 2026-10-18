using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Nondetection (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Nondetection2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "nondetection");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 3,
			School = SpellSchool.Abjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Ranger, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "nondetection", "en"),
					Language = LanguageCode.En,
					Name = "Nondetection",
					CastingTime = "1 action",
					Range = "Touch",
					Duration = "8 hours",
					MaterialComponent = "a pinch of diamond dust worth 25 gp sprinkled over the target, which the spell consumes",
					Description = "For the duration, you hide a target that you touch from divination magic. The target can be a willing creature or a place or an object no larger than 10 feet in any dimension. The target can't be targeted by any divination magic or perceived through magical scrying sensors.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "nondetection", "it"),
					Language = LanguageCode.It,
					Name = "Anti-individuazione",
					CastingTime = "1 azione",
					Range = "Contatto",
					Duration = "8 ore",
					MaterialComponent = "un pizzico di polvere di diamante del valore di 25 mo cosparso sul bersaglio, che l'incantesimo consuma",
					Description = "Per la durata, l'incantatore nasconde alla magia di divinazione un bersaglio che tocca. Il bersaglio può essere una creatura consenziente, oppure un luogo o un oggetto le cui dimensioni non superano i 3 metri in ogni direzione. Il bersaglio non può essere bersagliato da alcuna magia di divinazione né essere percepito tramite sensori di scrutamento magici.",
					HigherLevels = null
				}
			}
		};
	}
}
