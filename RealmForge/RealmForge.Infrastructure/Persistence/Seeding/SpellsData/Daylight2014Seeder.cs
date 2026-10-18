using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Daylight (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Daylight2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "daylight");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 3,
			School = SpellSchool.Evocation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric, SpellcastingClass.Druid, SpellcastingClass.Paladin, SpellcastingClass.Ranger, SpellcastingClass.Sorcerer },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "daylight", "en"),
					Language = LanguageCode.En,
					Name = "Daylight",
					CastingTime = "1 action",
					Range = "60 feet",
					Duration = "1 hour",
					MaterialComponent = null,
					Description = "A 60-foot-radius sphere of light spreads out from a point you choose within range. The sphere is bright light and sheds dim light for an additional 60 feet.\n\nIf you chose a point on an object you are holding or one that isn't being worn or carried, the light shines from the object and moves with it. Completely covering the affected object with an opaque object, such as a bowl or a helm, blocks the light.\n\nIf any of this spell's area overlaps with an area of darkness created by a spell of 3rd level or lower, the spell that created the darkness is dispelled.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "daylight", "it"),
					Language = LanguageCode.It,
					Name = "Luce Diurna",
					CastingTime = "1 azione",
					Range = "18 metri",
					Duration = "1 ora",
					MaterialComponent = null,
					Description = "Una sfera di luce del raggio di 18 metri si espande da un punto entro gittata scelto dall'incantatore. La sfera è luce intensa ed emette luce fioca per ulteriori 18 metri.\n\nSe il punto scelto si trova su un oggetto che l'incantatore impugna o su un oggetto che non è indossato o trasportato, la luce risplende dall'oggetto e si sposta con esso. Coprire completamente l'oggetto influenzato con un oggetto opaco, come una ciotola o un elmo, blocca la luce.\n\nSe una parte qualsiasi dell'area di questo incantesimo si sovrappone a un'area di oscurità creata da un incantesimo di 3° livello o inferiore, l'incantesimo che ha creato l'oscurità viene dissolto.",
					HigherLevels = null
				}
			}
		};
	}
}
