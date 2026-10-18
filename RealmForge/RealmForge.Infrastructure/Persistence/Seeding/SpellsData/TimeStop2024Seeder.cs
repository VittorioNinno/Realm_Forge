using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Time Stop (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class TimeStop2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "time-stop");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 9,
			School = SpellSchool.Transmutation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = false,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "time-stop", "en"),
					Language = LanguageCode.En,
					Name = "Time Stop",
					CastingTime = "Action",
					Range = "Self",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "You briefly stop the flow of time for everyone but yourself. No time passes for other creatures, while you take 1d4 + 1 turns in a row, during which you can use actions and move as normal.\n\nThis spell ends if one of the actions you use during this period, or any effects that you create during it, affects a creature other than you or an object being worn or carried by someone other than you. In addition, the spell ends if you move to a place more than 1,000 feet from the location where you cast it.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "time-stop", "it"),
					Language = LanguageCode.It,
					Name = "Fermare il Tempo",
					CastingTime = "Azione",
					Range = "Incantatore",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "L'incantatore arresta brevemente lo scorrere del tempo per tutti tranne che per sé stesso. Per le altre creature non trascorre alcun tempo, mentre l'incantatore svolge 1d4 + 1 turni consecutivi, durante i quali può usare azioni e muoversi normalmente.\n\nQuesto incantesimo termina se una delle azioni usate dall'incantatore durante questo periodo, o qualsiasi effetto da lui creato in questo periodo, influenza una creatura diversa da lui o un oggetto indossato o trasportato da qualcuno che non sia lui. Inoltre, l'incantesimo termina se l'incantatore si sposta in un luogo a più di 300 metri dal punto in cui lo ha lanciato.",
					HigherLevels = null
				}
			}
		};
	}
}
