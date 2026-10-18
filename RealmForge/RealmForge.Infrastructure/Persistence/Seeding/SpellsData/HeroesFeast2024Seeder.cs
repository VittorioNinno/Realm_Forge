using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Heroes' Feast (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class HeroesFeast2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "heroes-feast");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 6,
			School = SpellSchool.Conjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Cleric, SpellcastingClass.Druid },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "heroes-feast", "en"),
					Language = LanguageCode.En,
					Name = "Heroes' Feast",
					CastingTime = "10 minutes",
					Range = "Self",
					Duration = "Instantaneous",
					MaterialComponent = "a gem-encrusted bowl worth 1,000+ GP, which the spell consumes",
					Description = "You conjure a feast that appears on a surface in an unoccupied 10-foot Cube next to you. The feast takes 1 hour to consume and disappears at the end of that time, and the beneficial effects don't set in until this hour is over. Up to twelve creatures can partake of the feast.\n\nA creature that partakes gains several benefits, which last for 24 hours. The creature has Resistance to Poison damage, and it has Immunity to the Frightened and Poisoned conditions. Its Hit Point maximum also increases by 2d10, and it gains the same number of Hit Points.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "heroes-feast", "it"),
					Language = LanguageCode.It,
					Name = "Banchetto degli Eroi",
					CastingTime = "10 minuti",
					Range = "Incantatore",
					Duration = "Istantanea",
					MaterialComponent = "una ciotola incrostata di gemme del valore di almeno 1.000 mo, che l'incantesimo consuma",
					Description = "L'incantatore evoca un banchetto che compare su una superficie in un cubo libero con spigolo di 3 metri accanto a lui. Il banchetto richiede 1 ora per essere consumato e scompare al termine di quel tempo, e gli effetti benefici non si manifestano finché quell'ora non è trascorsa. Fino a dodici creature possono partecipare al banchetto.\n\nUna creatura che partecipa al banchetto ottiene diversi benefici, che durano 24 ore. La creatura ha resistenza ai danni da veleno ed è immune alle condizioni avvelenato e spaventato. Il suo massimo dei punti ferita aumenta inoltre di 2d10, e la creatura ottiene lo stesso numero di punti ferita.",
					HigherLevels = null
				}
			}
		};
	}
}
