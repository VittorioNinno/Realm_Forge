using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Guiding Bolt (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class GuidingBolt2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "guiding-bolt");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "guiding-bolt", "en"),
					Language = LanguageCode.En,
					Name = "Guiding Bolt",
					CastingTime = "1 action",
					Range = "120 feet",
					Duration = "1 round",
					MaterialComponent = null,
					Description = "A flash of light streaks toward a creature of your choice within range. Make a ranged spell attack against the target. On a hit, the target takes 4d6 radiant damage, and the next attack roll made against this target before the end of your next turn has advantage, thanks to the mystical dim light glittering on the target until then.",
					HigherLevels = "When you cast this spell using a spell slot of 2nd level or higher, the damage increases by 1d6 for each slot level above 1st."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "guiding-bolt", "it"),
					Language = LanguageCode.It,
					Name = "Dardo Tracciante",
					CastingTime = "1 azione",
					Range = "36 metri",
					Duration = "1 round",
					MaterialComponent = null,
					Description = "Un lampo di luce sfreccia verso una creatura entro gittata scelta dall'incantatore. L'incantatore effettua un attacco con incantesimo a distanza contro il bersaglio. Se colpisce, il bersaglio subisce 4d6 danni radiosi e il successivo tiro per colpire effettuato contro di esso prima della fine del turno successivo dell'incantatore dispone di vantaggio, grazie alla mistica luce fioca che scintilla sul bersaglio fino ad allora.",
					HigherLevels = "Quando l'incantatore lancia questo incantesimo usando uno slot incantesimo di 2° livello o superiore, i danni aumentano di 1d6 per ogni livello dello slot superiore al 1°."
				}
			}
		};
	}
}
