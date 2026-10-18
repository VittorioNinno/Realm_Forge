using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Nondetection (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Nondetection2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "nondetection");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "nondetection", "en"),
					Language = LanguageCode.En,
					Name = "Nondetection",
					CastingTime = "Action",
					Range = "Touch",
					Duration = "8 hours",
					MaterialComponent = "a pinch of diamond dust worth 25+ GP, which the spell consumes",
					Description = "For the duration, you hide a target that you touch from Divination spells. The target can be a willing creature, or it can be a place or an object no larger than 10 feet in any dimension. The target can't be targeted by any Divination spell or perceived through magical scrying sensors.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "nondetection", "it"),
					Language = LanguageCode.It,
					Name = "Anti-individuazione",
					CastingTime = "Azione",
					Range = "Contatto",
					Duration = "8 ore",
					MaterialComponent = "un pizzico di polvere di diamante del valore di almeno 25 mo, che l'incantesimo consuma",
					Description = "Per la durata, l'incantatore nasconde un bersaglio che tocca dagli incantesimi di divinazione. Il bersaglio può essere una creatura consenziente oppure un luogo o un oggetto non più grande di 3 metri in nessuna dimensione. Il bersaglio non può essere preso come bersaglio da alcun incantesimo di divinazione né essere percepito tramite sensori di scrutamento magico.",
					HigherLevels = null
				}
			}
		};
	}
}
