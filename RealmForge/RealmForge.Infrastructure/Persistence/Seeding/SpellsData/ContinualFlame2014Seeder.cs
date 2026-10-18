using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Continual Flame (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class ContinualFlame2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "continual-flame");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 2,
			School = SpellSchool.Evocation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "continual-flame", "en"),
					Language = LanguageCode.En,
					Name = "Continual Flame",
					CastingTime = "1 action",
					Range = "Touch",
					Duration = "Until dispelled",
					MaterialComponent = "ruby dust worth 50 gp, which the spell consumes",
					Description = "A flame, equivalent in brightness to a torch, springs forth from an object that you touch. The effect looks like a regular flame, but it creates no heat and doesn't use oxygen. A continual flame can be covered or hidden but not smothered or quenched.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "continual-flame", "it"),
					Language = LanguageCode.It,
					Name = "Fiamma Perenne",
					CastingTime = "1 azione",
					Range = "Contatto",
					Duration = "Finché non viene dissolto",
					MaterialComponent = "polvere di rubino del valore di 50 mo, che l'incantesimo consuma",
					Description = "Una fiamma, luminosa quanto una torcia, scaturisce da un oggetto toccato dall'incantatore. L'effetto ha l'aspetto di una normale fiamma, ma non produce calore e non consuma ossigeno. Una fiamma perenne può essere coperta o nascosta, ma non soffocata né spenta.",
					HigherLevels = null
				}
			}
		};
	}
}
