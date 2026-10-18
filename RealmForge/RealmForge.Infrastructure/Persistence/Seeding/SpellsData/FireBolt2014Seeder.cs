using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Fire Bolt (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class FireBolt2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "fire-bolt");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "fire-bolt", "en"),
					Language = LanguageCode.En,
					Name = "Fire Bolt",
					CastingTime = "1 action",
					Range = "120 feet",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "You hurl a mote of fire at a creature or object within range. Make a ranged spell attack against the target. On a hit, the target takes 1d10 fire damage. A flammable object hit by this spell ignites if it isn't being worn or carried.\n\nThis spell's damage increases by 1d10 when you reach 5th level (2d10), 11th level (3d10), and 17th level (4d10).",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "fire-bolt", "it"),
					Language = LanguageCode.It,
					Name = "Dardo di Fuoco",
					CastingTime = "1 azione",
					Range = "36 metri",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "L'incantatore scaglia una scintilla di fuoco contro una creatura o un oggetto entro gittata. Effettua un attacco con incantesimo a distanza contro il bersaglio. Se colpisce, il bersaglio subisce 1d10 danni da fuoco. Un oggetto infiammabile colpito da questo incantesimo prende fuoco, se non è indossato o trasportato.\n\nI danni di questo incantesimo aumentano di 1d10 quando l'incantatore raggiunge il 5° livello (2d10), l'11° livello (3d10) e il 17° livello (4d10).",
					HigherLevels = null
				}
			}
		};
	}
}
