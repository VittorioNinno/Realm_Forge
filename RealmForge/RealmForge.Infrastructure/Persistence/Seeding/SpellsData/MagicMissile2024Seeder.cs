using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Magic Missile (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class MagicMissile2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "magic-missile");

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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "magic-missile", "en"),
					Language = LanguageCode.En,
					Name = "Magic Missile",
					CastingTime = "Action",
					Range = "120 feet",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "You create three glowing darts of magical force. Each dart strikes a creature of your choice that you can see within range. A dart deals 1d4 + 1 Force damage to its target. The darts all strike simultaneously, and you can direct them to hit one creature or several.",
					HigherLevels = "The spell creates one more dart for each spell slot level above 1."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "magic-missile", "it"),
					Language = LanguageCode.It,
					Name = "Dardo Incantato",
					CastingTime = "Azione",
					Range = "36 metri",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "L'incantatore crea tre dardi luminosi di forza magica. Ogni dardo colpisce una creatura a sua scelta entro gittata che egli è in grado di vedere. Un dardo infligge 1d4 + 1 danni da forza al proprio bersaglio. I dardi colpiscono tutti simultaneamente e l'incantatore può dirigerli contro una sola creatura o contro più creature.",
					HigherLevels = "L'incantesimo crea un dardo in più per ogni livello dello slot incantesimo superiore al 1°."
				}
			}
		};
	}
}
