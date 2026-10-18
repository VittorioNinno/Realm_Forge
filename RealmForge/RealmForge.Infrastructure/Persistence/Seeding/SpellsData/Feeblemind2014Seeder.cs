using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Feeblemind (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Feeblemind2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "feeblemind");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 8,
			School = SpellSchool.Enchantment,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Druid, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "feeblemind", "en"),
					Language = LanguageCode.En,
					Name = "Feeblemind",
					CastingTime = "1 action",
					Range = "150 feet",
					Duration = "Instantaneous",
					MaterialComponent = "a handful of clay, crystal, glass, or mineral spheres",
					Description = "You blast the mind of a creature that you can see within range, attempting to shatter its intellect and personality. The target takes 4d6 psychic damage and must make an Intelligence saving throw.\n\nOn a failed save, the creature's Intelligence and Charisma scores become 1. The creature can't cast spells, activate magic items, understand language, or communicate in any intelligible way. The creature can, however, identify its friends, follow them, and even protect them.\n\nAt the end of every 30 days, the creature can repeat its saving throw against this spell. If it succeeds on its saving throw, the spell ends.\n\nThe spell can also be ended by greater restoration, heal, or wish.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "feeblemind", "it"),
					Language = LanguageCode.It,
					Name = "Regressione Mentale",
					CastingTime = "1 azione",
					Range = "45 metri",
					Duration = "Istantanea",
					MaterialComponent = "una manciata di sfere di argilla, cristallo, vetro o minerale",
					Description = "L'incantatore colpisce la mente di una creatura entro gittata che sia in grado di vedere, nel tentativo di frantumarne l'intelletto e la personalità. Il bersaglio subisce 4d6 danni psichici e deve effettuare un tiro salvezza su Intelligenza.\n\nSe lo fallisce, i punteggi di Intelligenza e di Carisma della creatura diventano 1. La creatura non può lanciare incantesimi, attivare oggetti magici, comprendere i linguaggi o comunicare in alcun modo comprensibile. Può tuttavia riconoscere i propri amici, seguirli e perfino proteggerli.\n\nAl termine di ogni periodo di 30 giorni, la creatura può ripetere il tiro salvezza contro questo incantesimo. Se lo supera, l'incantesimo termina.\n\nÈ possibile porre fine all'incantesimo anche con ristorare superiore, guarigione o desiderio.",
					HigherLevels = null
				}
			}
		};
	}
}
