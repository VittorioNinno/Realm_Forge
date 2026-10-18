using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Sunburst (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Sunburst2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "sunburst");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 8,
			School = SpellSchool.Evocation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric, SpellcastingClass.Druid, SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "sunburst", "en"),
					Language = LanguageCode.En,
					Name = "Sunburst",
					CastingTime = "Action",
					Range = "150 feet",
					Duration = "Instantaneous",
					MaterialComponent = "a piece of sunstone",
					Description = "Brilliant sunlight flashes in a 60-foot-radius Sphere centered on a point you choose within range. Each creature in the Sphere makes a Constitution saving throw. On a failed save, a creature takes 12d6 Radiant damage and has the Blinded condition for 1 minute. On a successful save, it takes half as much damage only.\n\nA creature Blinded by this spell makes another Constitution saving throw at the end of each of its turns, ending the effect on itself on a success.\n\nThis spell dispels Darkness in its area that was created by any spell.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "sunburst", "it"),
					Language = LanguageCode.It,
					Name = "Esplosione Solare",
					CastingTime = "Azione",
					Range = "45 metri",
					Duration = "Istantanea",
					MaterialComponent = "un frammento di pietra del sole",
					Description = "Una luce solare splendente lampeggia in una sfera del raggio di 18 metri centrata su un punto entro gittata a scelta dell'incantatore. Ogni creatura nella sfera effettua un tiro salvezza su Costituzione. Se lo fallisce, una creatura subisce 12d6 danni radiosi ed è accecata per 1 minuto. Se lo supera, subisce soltanto la metà dei danni.\n\nUna creatura accecata da questo incantesimo effettua un altro tiro salvezza su Costituzione alla fine di ogni suo turno e, se lo supera, l'effetto termina su di lei.\n\nQuesto incantesimo dissolve l'oscurità nella sua area creata da qualsiasi incantesimo.",
					HigherLevels = null
				}
			}
		};
	}
}
