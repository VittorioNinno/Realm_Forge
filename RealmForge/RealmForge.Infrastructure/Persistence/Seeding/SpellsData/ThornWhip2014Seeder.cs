using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Thorn Whip (2014 ruleset). Not part of SRD 5.1: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class ThornWhip2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "thorn-whip");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			Level = 0,
			School = SpellSchool.Transmutation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Druid },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "thorn-whip", "en"),
					Language = LanguageCode.En,
					Name = "Thorn Whip",
					CastingTime = "1 action",
					Range = "30 feet",
					Duration = "Instantaneous",
					MaterialComponent = "the stem of a plant with thorns",
					Description = "You conjure a long, thorny, vine-like whip that lashes out at a creature within range at your command. Make a melee spell attack against the target. On a hit, the target takes 1d6 piercing damage, and if it is Large or smaller, you pull it up to 10 feet closer to you.\n\nThis spell's damage increases by 1d6 when you reach 5th level (2d6), 11th level (3d6), and 17th level (4d6).",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "thorn-whip", "it"),
					Language = LanguageCode.It,
					Name = "Frusta di Spine",
					CastingTime = "1 azione",
					Range = "9 metri",
					Duration = "Istantanea",
					MaterialComponent = "lo stelo di una pianta spinosa",
					Description = "L'incantatore evoca una lunga frusta spinosa simile a un rampicante, che al suo comando sferza una creatura entro gittata. L'incantatore effettua un attacco con incantesimo in mischia contro il bersaglio. Se colpisce, il bersaglio subisce 1d6 danni perforanti e, se è di taglia Grande o inferiore, l'incantatore lo trascina fino a 3 metri più vicino a sé.\n\nI danni di questo incantesimo aumentano di 1d6 quando l'incantatore raggiunge il 5° livello (2d6), l'11° livello (3d6) e il 17° livello (4d6).",
					HigherLevels = null
				}
			}
		};
	}
}
