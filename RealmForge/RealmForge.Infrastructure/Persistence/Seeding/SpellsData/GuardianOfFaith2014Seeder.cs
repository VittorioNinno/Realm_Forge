using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Guardian of Faith (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class GuardianOfFaith2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "guardian-of-faith");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 4,
			School = SpellSchool.Conjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = false,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "guardian-of-faith", "en"),
					Language = LanguageCode.En,
					Name = "Guardian of Faith",
					CastingTime = "1 action",
					Range = "30 feet",
					Duration = "8 hours",
					MaterialComponent = null,
					Description = "A Large spectral guardian appears and hovers for the duration in an unoccupied space of your choice that you can see within range. The guardian occupies that space and is indistinct except for a gleaming sword and shield emblazoned with the symbol of your deity.\n\nAny creature hostile to you that moves to a space within 10 feet of the guardian for the first time on a turn must succeed on a Dexterity saving throw. The creature takes 20 radiant damage on a failed save, or half as much damage on a successful one. The guardian vanishes when it has dealt a total of 60 damage.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "guardian-of-faith", "it"),
					Language = LanguageCode.It,
					Name = "Guardiano della Fede",
					CastingTime = "1 azione",
					Range = "9 metri",
					Duration = "8 ore",
					MaterialComponent = null,
					Description = "Un guardiano spettrale di taglia Grande compare e fluttua per la durata in uno spazio libero entro gittata, scelto dall'incantatore e che egli sia in grado di vedere. Il guardiano occupa quello spazio ed è indistinto, a eccezione di una spada scintillante e di uno scudo che reca il simbolo della divinità dell'incantatore.\n\nQualsiasi creatura ostile all'incantatore che si sposta per la prima volta in un turno in uno spazio entro 3 metri dal guardiano deve superare un tiro salvezza su Destrezza. La creatura subisce 20 danni radiosi se fallisce il tiro salvezza, o la metà di quei danni se lo supera. Il guardiano svanisce dopo aver inflitto un totale di 60 danni.",
					HigherLevels = null
				}
			}
		};
	}
}
