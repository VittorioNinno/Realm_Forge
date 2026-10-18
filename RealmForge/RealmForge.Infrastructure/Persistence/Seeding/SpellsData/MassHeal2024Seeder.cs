using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Mass Heal (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class MassHeal2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "mass-heal");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 9,
			School = SpellSchool.Abjuration,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "mass-heal", "en"),
					Language = LanguageCode.En,
					Name = "Mass Heal",
					CastingTime = "Action",
					Range = "60 feet",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "A flood of healing energy flows from you into creatures around you. You restore up to 700 Hit Points, divided as you choose among any number of creatures that you can see within range. Creatures healed by this spell also have the Blinded, Deafened, and Poisoned conditions removed from them.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "mass-heal", "it"),
					Language = LanguageCode.It,
					Name = "Guarigione di Massa",
					CastingTime = "Azione",
					Range = "18 metri",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "Un flusso di energia curativa scorre dall'incantatore nelle creature attorno a lui. L'incantatore fa recuperare fino a 700 punti ferita, suddivisi a sua scelta tra un qualsiasi numero di creature entro gittata che è in grado di vedere. Le creature curate da questo incantesimo vengono inoltre liberate dalle condizioni accecato, assordato e avvelenato.",
					HigherLevels = null
				}
			}
		};
	}
}
