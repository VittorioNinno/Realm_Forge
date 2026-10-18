using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Poison Spray (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class PoisonSpray2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "poison-spray");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 0,
			School = SpellSchool.Conjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Druid, SpellcastingClass.Sorcerer, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "poison-spray", "en"),
					Language = LanguageCode.En,
					Name = "Poison Spray",
					CastingTime = "1 action",
					Range = "10 feet",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "You extend your hand toward a creature you can see within range and project a puff of noxious gas from your palm. The creature must succeed on a Constitution saving throw or take 1d12 poison damage.\n\nThis spell's damage increases by 1d12 when you reach 5th level (2d12), 11th level (3d12), and 17th level (4d12).",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "poison-spray", "it"),
					Language = LanguageCode.It,
					Name = "Spruzzo Velenoso",
					CastingTime = "1 azione",
					Range = "3 metri",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "L'incantatore tende la mano verso una creatura entro gittata che sia in grado di vedere e proietta dal palmo uno sbuffo di gas nocivo. La creatura deve superare un tiro salvezza su Costituzione, altrimenti subisce 1d12 danni da veleno.\n\nI danni di questo incantesimo aumentano di 1d12 quando l'incantatore raggiunge il 5° livello (2d12), l'11° livello (3d12) e il 17° livello (4d12).",
					HigherLevels = null
				}
			}
		};
	}
}
