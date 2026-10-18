using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Sanctuary (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Sanctuary2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "sanctuary");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 1,
			School = SpellSchool.Abjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "sanctuary", "en"),
					Language = LanguageCode.En,
					Name = "Sanctuary",
					CastingTime = "1 bonus action",
					Range = "30 feet",
					Duration = "1 minute",
					MaterialComponent = "a small silver mirror",
					Description = "You ward a creature within range against attack. Until the spell ends, any creature who targets the warded creature with an attack or a harmful spell must first make a Wisdom saving throw. On a failed save, the creature must choose a new target or lose the attack or spell. This spell doesn't protect the warded creature from area effects, such as the explosion of a fireball.\n\nIf the warded creature makes an attack or casts a spell that affects an enemy creature, this spell ends.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "sanctuary", "it"),
					Language = LanguageCode.It,
					Name = "Santuario",
					CastingTime = "1 azione bonus",
					Range = "9 metri",
					Duration = "1 minuto",
					MaterialComponent = "un piccolo specchio d'argento",
					Description = "L'incantatore protegge dagli attacchi una creatura entro gittata. Finché l'incantesimo non termina, qualsiasi creatura che bersagli la creatura protetta con un attacco o con un incantesimo dannoso deve prima effettuare un tiro salvezza su Saggezza. Se lo fallisce, deve scegliere un nuovo bersaglio o rinunciare all'attacco o all'incantesimo. Questo incantesimo non protegge la creatura protetta dagli effetti ad area, come l'esplosione di una palla di fuoco.\n\nSe la creatura protetta effettua un attacco o lancia un incantesimo che influenza una creatura nemica, questo incantesimo termina.",
					HigherLevels = null
				}
			}
		};
	}
}
