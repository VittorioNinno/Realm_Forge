using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	See Invisibility (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class SeeInvisibility2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "see-invisibility");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 2,
			School = SpellSchool.Divination,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "see-invisibility", "en"),
					Language = LanguageCode.En,
					Name = "See Invisibility",
					CastingTime = "Action",
					Range = "Self",
					Duration = "1 hour",
					MaterialComponent = "a pinch of talc",
					Description = "For the duration, you see creatures and objects that have the Invisible condition as if they were visible, and you can see into the Ethereal Plane. Creatures and objects there appear ghostly.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "see-invisibility", "it"),
					Language = LanguageCode.It,
					Name = "Vedere Invisibilità",
					CastingTime = "Azione",
					Range = "Incantatore",
					Duration = "1 ora",
					MaterialComponent = "un pizzico di talco",
					Description = "Per la durata, l'incantatore vede le creature e gli oggetti invisibili come se fossero visibili, e può vedere nel Piano Etereo. Le creature e gli oggetti che si trovano lì appaiono spettrali.",
					HigherLevels = null
				}
			}
		};
	}
}
