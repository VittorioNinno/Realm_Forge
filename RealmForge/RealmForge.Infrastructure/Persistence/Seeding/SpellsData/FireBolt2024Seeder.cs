using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Fire Bolt (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class FireBolt2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "fire-bolt");

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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "fire-bolt", "en"),
					Language = LanguageCode.En,
					Name = "Fire Bolt",
					CastingTime = "Action",
					Range = "120 feet",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "You hurl a mote of fire at a creature or an object within range. Make a ranged spell attack against the target. On a hit, the target takes 1d10 Fire damage. A flammable object hit by this spell starts burning if it isn't being worn or carried.",
					HigherLevels = "The damage increases by 1d10 when you reach levels 5 (2d10), 11 (3d10), and 17 (4d10)."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "fire-bolt", "it"),
					Language = LanguageCode.It,
					Name = "Dardo di Fuoco",
					CastingTime = "Azione",
					Range = "36 metri",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "L'incantatore scaglia un granello di fuoco contro una creatura o un oggetto entro gittata ed effettua un attacco con incantesimo a distanza contro il bersaglio. Se colpisce, il bersaglio subisce 1d10 danni da fuoco. Un oggetto infiammabile colpito da questo incantesimo prende fuoco, se non è indossato o trasportato.",
					HigherLevels = "I danni aumentano di 1d10 quando l'incantatore raggiunge il 5° livello (2d10), l'11° livello (3d10) e il 17° livello (4d10)."
				}
			}
		};
	}
}
