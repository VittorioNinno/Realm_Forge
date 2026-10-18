using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Mind Blank (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class MindBlank2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "mind-blank");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 8,
			School = SpellSchool.Abjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "mind-blank", "en"),
					Language = LanguageCode.En,
					Name = "Mind Blank",
					CastingTime = "1 action",
					Range = "Touch",
					Duration = "24 hours",
					MaterialComponent = null,
					Description = "Until the spell ends, one willing creature you touch is immune to psychic damage, any effect that would sense its emotions or read its thoughts, divination spells, and the charmed condition. The spell even foils wish spells and spells or effects of similar power used to affect the target's mind or to gain information about the target.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "mind-blank", "it"),
					Language = LanguageCode.It,
					Name = "Vuoto Mentale",
					CastingTime = "1 azione",
					Range = "Contatto",
					Duration = "24 ore",
					MaterialComponent = null,
					Description = "Finché l'incantesimo non termina, una creatura consenziente toccata dall'incantatore è immune ai danni psichici, a qualsiasi effetto che permetterebbe di percepirne le emozioni o di leggerne i pensieri, agli incantesimi di divinazione e alla condizione di affascinato. L'incantesimo ostacola perfino gli incantesimi desiderio e gli incantesimi o gli effetti di potere simile usati per influenzare la mente del bersaglio o per ottenere informazioni sul suo conto.",
					HigherLevels = null
				}
			}
		};
	}
}
