using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Vicious Mockery (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class ViciousMockery2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "vicious-mockery");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 0,
			School = SpellSchool.Enchantment,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = false,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "vicious-mockery", "en"),
					Language = LanguageCode.En,
					Name = "Vicious Mockery",
					CastingTime = "Action",
					Range = "60 feet",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "You unleash a string of insults laced with subtle enchantments at one creature you can see or hear within range. The target must succeed on a Wisdom saving throw or take 1d6 Psychic damage and have Disadvantage on the next attack roll it makes before the end of its next turn.",
					HigherLevels = "The damage increases by 1d6 when you reach levels 5 (2d6), 11 (3d6), and 17 (4d6)."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "vicious-mockery", "it"),
					Language = LanguageCode.It,
					Name = "Beffa Crudele",
					CastingTime = "Azione",
					Range = "18 metri",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "L'incantatore scaglia una sfilza di insulti intrisi di sottili ammaliamenti contro una creatura entro gittata che è in grado di vedere o di sentire. Il bersaglio deve superare un tiro salvezza su Saggezza, altrimenti subisce 1d6 danni psichici e subisce svantaggio al successivo tiro per colpire che effettua prima della fine del suo turno successivo.",
					HigherLevels = "I danni aumentano di 1d6 quando l'incantatore raggiunge il 5° livello (2d6), l'11° livello (3d6) e il 17° livello (4d6)."
				}
			}
		};
	}
}
