using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Sleet Storm (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class SleetStorm2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "sleet-storm");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 3,
			School = SpellSchool.Conjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Druid, SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "sleet-storm", "en"),
					Language = LanguageCode.En,
					Name = "Sleet Storm",
					CastingTime = "Action",
					Range = "150 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = "a miniature umbrella",
					Description = "Until the spell ends, sleet falls in a 40-foot-tall, 20-foot-radius Cylinder centered on a point you choose within range. The area is Heavily Obscured, and exposed flames in the area are doused.\n\nGround in the Cylinder is Difficult Terrain. When a creature enters the Cylinder for the first time on a turn or starts its turn there, it must succeed on a Dexterity saving throw or have the Prone condition and lose Concentration.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "sleet-storm", "it"),
					Language = LanguageCode.It,
					Name = "Tempesta di Nevischio",
					CastingTime = "Azione",
					Range = "45 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = "un ombrello in miniatura",
					Description = "Finché l'incantesimo non termina, il nevischio cade in un cilindro alto 12 metri e del raggio di 6 metri, centrato su un punto entro gittata a scelta dell'incantatore. L'area è pesantemente oscurata e le fiamme esposte nell'area si spengono.\n\nIl terreno nel cilindro è terreno difficile. Quando una creatura entra nel cilindro per la prima volta in un turno o vi inizia il proprio turno, deve superare un tiro salvezza su Destrezza, altrimenti cade prona e perde la concentrazione.",
					HigherLevels = null
				}
			}
		};
	}
}
