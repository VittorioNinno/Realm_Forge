using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Ensnaring Strike (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class EnsnaringStrike2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "ensnaring-strike");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 1,
			School = SpellSchool.Conjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Ranger },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = false,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "ensnaring-strike", "en"),
					Language = LanguageCode.En,
					Name = "Ensnaring Strike",
					CastingTime = "Bonus Action, which you take immediately after hitting a creature with a weapon",
					Range = "Self",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = null,
					Description = "As you hit the target, grasping vines appear on it, and it makes a Strength saving throw. A Large or larger creature has Advantage on this save. On a failed save, the target has the Restrained condition until the spell ends. On a successful save, the vines shrivel away, and the spell ends.\n\nWhile Restrained, the target takes 1d6 Piercing damage at the start of each of its turns. The target or a creature within reach of it can take an action to make a Strength (Athletics) check against your spell save DC. On a success, the spell ends.",
					HigherLevels = "The damage increases by 1d6 for each spell slot level above 1."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "ensnaring-strike", "it"),
					Language = LanguageCode.It,
					Name = "Colpo Intrappolante",
					CastingTime = "Azione bonus, che l'incantatore effettua subito dopo aver colpito una creatura con un'arma",
					Range = "Incantatore",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = null,
					Description = "Quando l'incantatore colpisce il bersaglio, sul bersaglio compaiono dei rampicanti avvinghianti e il bersaglio effettua un tiro salvezza su Forza. Una creatura di taglia Grande o superiore dispone di vantaggio a questo tiro salvezza. Se lo fallisce, il bersaglio è trattenuto finché l'incantesimo non termina. Se lo supera, i rampicanti avvizziscono e l'incantesimo termina.\n\nFinché è trattenuto, il bersaglio subisce 1d6 danni perforanti all'inizio di ogni suo turno. Il bersaglio o una creatura entro la sua portata può effettuare un'azione per compiere una prova di Forza (Atletica) contro la CD del tiro salvezza degli incantesimi dell'incantatore. Se la supera, l'incantesimo termina.",
					HigherLevels = "I danni aumentano di 1d6 per ogni livello dello slot incantesimo superiore al 1°."
				}
			}
		};
	}
}
