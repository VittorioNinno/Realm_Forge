using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Pass Without Trace (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class PassWithoutTrace2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "pass-without-trace");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 2,
			School = SpellSchool.Abjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Druid, SpellcastingClass.Ranger },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "pass-without-trace", "en"),
					Language = LanguageCode.En,
					Name = "Pass Without Trace",
					CastingTime = "1 action",
					Range = "Self",
					Duration = "Concentration, up to 1 hour",
					MaterialComponent = "ashes from a burned leaf of mistletoe and a sprig of spruce",
					Description = "A veil of shadows and silence radiates from you, masking you and your companions from detection. For the duration, each creature you choose within 30 feet of you (including you) has a +10 bonus to Dexterity (Stealth) checks and can't be tracked except by magical means. A creature that receives this bonus leaves behind no tracks or other traces of its passage.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "pass-without-trace", "it"),
					Language = LanguageCode.It,
					Name = "Passare Senza Tracce",
					CastingTime = "1 azione",
					Range = "Incantatore",
					Duration = "Concentrazione, fino a 1 ora",
					MaterialComponent = "le ceneri di una foglia di vischio bruciata e un rametto di abete rosso",
					Description = "Un velo di ombre e di silenzio si irradia dall'incantatore, celando lui e i suoi compagni a chi cerca di individuarli. Per la durata, ogni creatura scelta dall'incantatore entro 9 metri da lui (incluso sé stesso) ottiene un bonus di +10 alle prove di Destrezza (Furtività) e non può essere seguita se non con mezzi magici. Una creatura che riceve questo bonus non lascia tracce né altri segni del suo passaggio.",
					HigherLevels = null
				}
			}
		};
	}
}
