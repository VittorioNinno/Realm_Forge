using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Regenerate (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Regenerate2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "regenerate");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 7,
			School = SpellSchool.Transmutation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Cleric, SpellcastingClass.Druid },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "regenerate", "en"),
					Language = LanguageCode.En,
					Name = "Regenerate",
					CastingTime = "1 minute",
					Range = "Touch",
					Duration = "1 hour",
					MaterialComponent = "a prayer wheel",
					Description = "A creature you touch regains 4d8 + 15 Hit Points. For the duration, the target regains 1 Hit Point at the start of each of its turns, and any severed body parts regrow after 2 minutes.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "regenerate", "it"),
					Language = LanguageCode.It,
					Name = "Rigenerazione",
					CastingTime = "1 minuto",
					Range = "Contatto",
					Duration = "1 ora",
					MaterialComponent = "una ruota di preghiera",
					Description = "Una creatura toccata dall'incantatore recupera 4d8 + 15 punti ferita. Per la durata, il bersaglio recupera 1 punto ferita all'inizio di ogni suo turno, e le eventuali parti del corpo recise ricrescono dopo 2 minuti.",
					HigherLevels = null
				}
			}
		};
	}
}
