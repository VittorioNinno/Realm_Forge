using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Daylight (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Daylight2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "daylight");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "daylight", "en"),
					Language = LanguageCode.En,
					Name = "Daylight",
					CastingTime = "Action",
					Range = "60 feet",
					Duration = "1 hour",
					MaterialComponent = null,
					Description = "For the duration, sunlight spreads from a point within range and fills a 60-foot-radius Sphere. The sunlight's area is Bright Light and sheds Dim Light for an additional 60 feet.\n\nAlternatively, you cast the spell on an object that isn't being worn or carried, causing the sunlight to fill a 60-foot Emanation originating from that object. Covering that object with something opaque, such as a bowl or helm, blocks the sunlight.\n\nIf any of this spell's area overlaps with an area of Darkness created by a spell of level 3 or lower, that other spell is dispelled.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "daylight", "it"),
					Language = LanguageCode.It,
					Name = "Luce Diurna",
					CastingTime = "Azione",
					Range = "18 metri",
					Duration = "1 ora",
					MaterialComponent = null,
					Description = "Per la durata, la luce del sole si espande da un punto entro gittata e riempie una sfera del raggio di 18 metri. L'area della luce del sole è illuminata da luce intensa e proietta luce fioca per altri 18 metri.\n\nIn alternativa, l'incantatore lancia l'incantesimo su un oggetto che non sia indossato o trasportato, facendo sì che la luce del sole riempia un'emanazione di 18 metri che ha origine da quell'oggetto. Coprire l'oggetto con qualcosa di opaco, come una ciotola o un elmo, blocca la luce del sole.\n\nSe una qualsiasi parte dell'area di questo incantesimo si sovrappone a un'area di oscurità creata da un incantesimo di 3° livello o inferiore, quell'altro incantesimo viene dissolto.",
					HigherLevels = null
				}
			}
		};
	}
}
