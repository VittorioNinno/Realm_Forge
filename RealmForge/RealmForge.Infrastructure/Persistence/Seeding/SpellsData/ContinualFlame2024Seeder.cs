using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Continual Flame (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class ContinualFlame2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "continual-flame");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 2,
			School = SpellSchool.Evocation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric, SpellcastingClass.Druid, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "continual-flame", "en"),
					Language = LanguageCode.En,
					Name = "Continual Flame",
					CastingTime = "Action",
					Range = "Touch",
					Duration = "Until dispelled",
					MaterialComponent = "ruby dust worth 50+ GP, which the spell consumes",
					Description = "A flame springs from an object that you touch. The effect casts Bright Light in a 20-foot radius and Dim Light for an additional 20 feet. It looks like a regular flame, but it creates no heat and consumes no fuel. The flame can be covered or hidden but not smothered or quenched.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "continual-flame", "it"),
					Language = LanguageCode.It,
					Name = "Fiamma Perenne",
					CastingTime = "Azione",
					Range = "Contatto",
					Duration = "Finché non viene dissolto",
					MaterialComponent = "polvere di rubino del valore di almeno 50 mo, che l'incantesimo consuma",
					Description = "Una fiamma scaturisce da un oggetto toccato dall'incantatore. L'effetto proietta luce intensa in un raggio di 6 metri e luce fioca per altri 6 metri. Ha l'aspetto di una normale fiamma, ma non produce calore e non consuma combustibile. La fiamma può essere coperta o nascosta, ma non soffocata o spenta.",
					HigherLevels = null
				}
			}
		};
	}
}
