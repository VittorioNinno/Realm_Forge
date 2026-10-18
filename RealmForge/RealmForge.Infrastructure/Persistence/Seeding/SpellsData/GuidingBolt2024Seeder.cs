using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Guiding Bolt (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class GuidingBolt2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "guiding-bolt");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 1,
			School = SpellSchool.Evocation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "guiding-bolt", "en"),
					Language = LanguageCode.En,
					Name = "Guiding Bolt",
					CastingTime = "Action",
					Range = "120 feet",
					Duration = "1 round",
					MaterialComponent = null,
					Description = "You hurl a bolt of light toward a creature within range. Make a ranged spell attack against the target. On a hit, it takes 4d6 Radiant damage, and the next attack roll made against it before the end of your next turn has Advantage.",
					HigherLevels = "The damage increases by 1d6 for each spell slot level above 1."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "guiding-bolt", "it"),
					Language = LanguageCode.It,
					Name = "Dardo Tracciante",
					CastingTime = "Azione",
					Range = "36 metri",
					Duration = "1 round",
					MaterialComponent = null,
					Description = "L'incantatore scaglia un dardo di luce verso una creatura entro gittata ed effettua un attacco con incantesimo a distanza contro il bersaglio. Se colpisce, il bersaglio subisce 4d6 danni radiosi e il successivo tiro per colpire effettuato contro di esso prima della fine del turno successivo dell'incantatore dispone di vantaggio.",
					HigherLevels = "I danni aumentano di 1d6 per ogni livello dello slot incantesimo superiore al 1°."
				}
			}
		};
	}
}
