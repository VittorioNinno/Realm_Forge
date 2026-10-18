using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Fog Cloud (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class FogCloud2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "fog-cloud");

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
			Classes = new List<SpellcastingClass> { SpellcastingClass.Druid, SpellcastingClass.Ranger, SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "fog-cloud", "en"),
					Language = LanguageCode.En,
					Name = "Fog Cloud",
					CastingTime = "Action",
					Range = "120 feet",
					Duration = "Concentration, up to 1 hour",
					MaterialComponent = null,
					Description = "You create a 20-foot-radius Sphere of fog centered on a point within range. The Sphere is Heavily Obscured. It lasts for the duration or until a strong wind (such as one created by *Gust of Wind*) disperses it.",
					HigherLevels = "The fog's radius increases by 20 feet for each spell slot level above 1."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "fog-cloud", "it"),
					Language = LanguageCode.It,
					Name = "Nube di Nebbia",
					CastingTime = "Azione",
					Range = "36 metri",
					Duration = "Concentrazione, fino a 1 ora",
					MaterialComponent = null,
					Description = "L'incantatore crea una sfera di nebbia del raggio di 6 metri centrata su un punto entro gittata. La sfera è pesantemente oscurata. Permane per la durata o finché un vento forte (come quello creato da *folata di vento*) non la disperde.",
					HigherLevels = "Il raggio della nebbia aumenta di 6 metri per ogni livello dello slot incantesimo superiore al 1°."
				}
			}
		};
	}
}
