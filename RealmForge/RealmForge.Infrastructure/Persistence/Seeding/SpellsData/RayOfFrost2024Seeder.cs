using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Ray of Frost (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class RayOfFrost2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "ray-of-frost");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 0,
			School = SpellSchool.Evocation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "ray-of-frost", "en"),
					Language = LanguageCode.En,
					Name = "Ray of Frost",
					CastingTime = "Action",
					Range = "60 feet",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "A frigid beam of blue-white light streaks toward a creature within range. Make a ranged spell attack against the target. On a hit, it takes 1d8 Cold damage, and its Speed is reduced by 10 feet until the start of your next turn.",
					HigherLevels = "The damage increases by 1d8 when you reach levels 5 (2d8), 11 (3d8), and 17 (4d8)."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "ray-of-frost", "it"),
					Language = LanguageCode.It,
					Name = "Raggio di Gelo",
					CastingTime = "Azione",
					Range = "18 metri",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "Un raggio gelido di luce bianco-azzurra sfreccia verso una creatura entro gittata. L'incantatore effettua un attacco con incantesimo a distanza contro il bersaglio. Se colpisce, il bersaglio subisce 1d8 danni da freddo e la sua velocità si riduce di 3 metri fino all'inizio del turno successivo dell'incantatore.",
					HigherLevels = "I danni aumentano di 1d8 quando l'incantatore raggiunge il 5° livello (2d8), l'11° livello (3d8) e il 17° livello (4d8)."
				}
			}
		};
	}
}
