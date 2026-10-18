using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Guardian of Faith (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class GuardianOfFaith2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "guardian-of-faith");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "guardian-of-faith", "en"),
					Language = LanguageCode.En,
					Name = "Guardian of Faith",
					CastingTime = "Action",
					Range = "30 feet",
					Duration = "8 hours",
					MaterialComponent = null,
					Description = "A Large spectral guardian appears and hovers for the duration in an unoccupied space that you can see within range. The guardian occupies that space and is invulnerable, and it appears in a form appropriate for your deity or pantheon.\n\nAny enemy that moves to a space within 10 feet of the guardian for the first time on a turn or starts its turn there makes a Dexterity saving throw, taking 20 Radiant damage on a failed save or half as much damage on a successful one. The guardian vanishes when it has dealt a total of 60 damage.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "guardian-of-faith", "it"),
					Language = LanguageCode.It,
					Name = "Guardiano della Fede",
					CastingTime = "Azione",
					Range = "9 metri",
					Duration = "8 ore",
					MaterialComponent = null,
					Description = "Un guardiano spettrale Grande compare e fluttua per la durata in uno spazio libero entro gittata che l'incantatore è in grado di vedere. Il guardiano occupa quello spazio ed è invulnerabile, e compare in una forma appropriata alla divinità o al pantheon dell'incantatore.\n\nQualsiasi nemico che si sposta in uno spazio entro 3 metri dal guardiano per la prima volta in un turno o vi inizia il proprio turno effettua un tiro salvezza su Destrezza, subendo 20 danni radiosi se lo fallisce, o la metà di quei danni se lo supera. Il guardiano svanisce dopo aver inflitto un totale di 60 danni.",
					HigherLevels = null
				}
			}
		};
	}
}
