using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Lightning Bolt (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class LightningBolt2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "lightning-bolt");

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
			Classes = new List<SpellcastingClass> { SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "lightning-bolt", "en"),
					Language = LanguageCode.En,
					Name = "Lightning Bolt",
					CastingTime = "Action",
					Range = "Self",
					Duration = "Instantaneous",
					MaterialComponent = "a bit of fur and a crystal rod",
					Description = "A stroke of lightning forming a 100-foot-long, 5-foot-wide Line blasts out from you in a direction you choose. Each creature in the Line makes a Dexterity saving throw, taking 8d6 Lightning damage on a failed save or half as much damage on a successful one.",
					HigherLevels = "The damage increases by 1d6 for each spell slot level above 3."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "lightning-bolt", "it"),
					Language = LanguageCode.It,
					Name = "Fulmine",
					CastingTime = "Azione",
					Range = "Incantatore",
					Duration = "Istantanea",
					MaterialComponent = "un po' di pelliccia e una verga di cristallo",
					Description = "Una saetta che forma una linea lunga 30 metri e larga 1,5 metri scaturisce dall'incantatore in una direzione a sua scelta. Ogni creatura nella linea effettua un tiro salvezza su Destrezza, subendo 8d6 danni da fulmine se lo fallisce, o la metà di quei danni se lo supera.",
					HigherLevels = "I danni aumentano di 1d6 per ogni livello dello slot incantesimo superiore al 3°."
				}
			}
		};
	}
}
