using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Sleet Storm (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class SleetStorm2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "sleet-storm");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "sleet-storm", "en"),
					Language = LanguageCode.En,
					Name = "Sleet Storm",
					CastingTime = "1 action",
					Range = "150 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = "a pinch of dust and a few drops of water",
					Description = "Until the spell ends, freezing rain and sleet fall in a 20-foot-tall cylinder with a 40-foot radius centered on a point you choose within range. The area is heavily obscured, and exposed flames in the area are doused.\n\nThe ground in the area is covered with slick ice, making it difficult terrain. When a creature enters the spell's area for the first time on a turn or starts its turn there, it must make a Dexterity saving throw. On a failed save, it falls prone.\n\nIf a creature is concentrating in the spell's area, the creature must make a successful Constitution saving throw against your spell save DC or lose concentration.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "sleet-storm", "it"),
					Language = LanguageCode.It,
					Name = "Tempesta di Nevischio",
					CastingTime = "1 azione",
					Range = "45 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = "un pizzico di polvere e qualche goccia d'acqua",
					Description = "Finché l'incantesimo non termina, pioggia gelata e nevischio cadono in un cilindro alto 6 metri e con un raggio di 12 metri, centrato su un punto entro gittata scelto dall'incantatore. L'area è pesantemente oscurata e le fiamme esposte nell'area si spengono.\n\nIl terreno nell'area è ricoperto di ghiaccio scivoloso, che lo rende terreno difficile. Quando una creatura entra nell'area dell'incantesimo per la prima volta in un turno o vi inizia il proprio turno, deve effettuare un tiro salvezza su Destrezza. Se lo fallisce, cade prona.\n\nSe una creatura sta mantenendo la concentrazione nell'area dell'incantesimo, deve superare un tiro salvezza su Costituzione contro la CD del tiro salvezza degli incantesimi dell'incantatore, altrimenti perde la concentrazione.",
					HigherLevels = null
				}
			}
		};
	}
}
