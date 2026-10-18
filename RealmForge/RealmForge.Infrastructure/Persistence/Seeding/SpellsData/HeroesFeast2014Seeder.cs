using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Heroes' Feast (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class HeroesFeast2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "heroes-feast");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 6,
			School = SpellSchool.Conjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric, SpellcastingClass.Druid },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "heroes-feast", "en"),
					Language = LanguageCode.En,
					Name = "Heroes' Feast",
					CastingTime = "10 minutes",
					Range = "30 feet",
					Duration = "Instantaneous",
					MaterialComponent = "a gem-encrusted bowl worth at least 1,000 gp, which the spell consumes",
					Description = "You bring forth a great feast, including magnificent food and drink. The feast takes 1 hour to consume and disappears at the end of that time, and the beneficial effects don't set in until this hour is over. Up to twelve other creatures can partake of the feast.\n\nA creature that partakes of the feast gains several benefits. The creature is cured of all diseases and poison, becomes immune to poison and being frightened, and makes all Wisdom saving throws with advantage. Its hit point maximum also increases by 2d10, and it gains the same number of hit points. These benefits last for 24 hours.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "heroes-feast", "it"),
					Language = LanguageCode.It,
					Name = "Banchetto degli Eroi",
					CastingTime = "10 minuti",
					Range = "9 metri",
					Duration = "Istantanea",
					MaterialComponent = "una coppa incrostata di gemme del valore di almeno 1.000 mo, che l'incantesimo consuma",
					Description = "L'incantatore fa comparire un grande banchetto, con cibi e bevande sontuosi. Consumare il banchetto richiede 1 ora, al termine della quale il banchetto scompare; gli effetti benefici non si manifestano finché quell'ora non è trascorsa. Fino a dodici altre creature possono prendere parte al banchetto.\n\nUna creatura che prende parte al banchetto ottiene diversi benefici. Viene curata da tutte le malattie e da tutti i veleni, diventa immune al veleno e alla condizione di spaventato, ed effettua tutti i tiri salvezza su Saggezza con vantaggio. Inoltre, il suo massimo dei punti ferita aumenta di 2d10 e ottiene lo stesso numero di punti ferita. Questi benefici durano 24 ore.",
					HigherLevels = null
				}
			}
		};
	}
}
