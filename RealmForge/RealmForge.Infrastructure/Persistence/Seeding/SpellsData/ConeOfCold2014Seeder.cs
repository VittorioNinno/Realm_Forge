using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Cone of Cold (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class ConeOfCold2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "cone-of-cold");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 5,
			School = SpellSchool.Evocation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "cone-of-cold", "en"),
					Language = LanguageCode.En,
					Name = "Cone of Cold",
					CastingTime = "1 action",
					Range = "Self (60-foot cone)",
					Duration = "Instantaneous",
					MaterialComponent = "a small crystal or glass cone",
					Description = "A blast of cold air erupts from your hands. Each creature in a 60-foot cone must make a Constitution saving throw. A creature takes 8d8 cold damage on a failed save, or half as much damage on a successful one.\n\nA creature killed by this spell becomes a frozen statue until it thaws.",
					HigherLevels = "When you cast this spell using a spell slot of 6th level or higher, the damage increases by 1d8 for each slot level above 5th."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "cone-of-cold", "it"),
					Language = LanguageCode.It,
					Name = "Cono di Freddo",
					CastingTime = "1 azione",
					Range = "Incantatore (cono di 18 metri)",
					Duration = "Istantanea",
					MaterialComponent = "un piccolo cono di cristallo o di vetro",
					Description = "Una raffica di aria gelida erompe dalle mani dell'incantatore. Ogni creatura in un cono di 18 metri deve effettuare un tiro salvezza su Costituzione. Una creatura subisce 8d8 danni da freddo se fallisce il tiro salvezza, o la metà di quei danni se lo supera.\n\nUna creatura uccisa da questo incantesimo diventa una statua congelata finché non si scongela.",
					HigherLevels = "Quando l'incantatore lancia questo incantesimo usando uno slot incantesimo di 6° livello o superiore, i danni aumentano di 1d8 per ogni livello dello slot superiore al 5°."
				}
			}
		};
	}
}
