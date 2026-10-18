using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Faerie Fire (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class FaerieFire2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "faerie-fire");

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
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Druid },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = false,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "faerie-fire", "en"),
					Language = LanguageCode.En,
					Name = "Faerie Fire",
					CastingTime = "Action",
					Range = "60 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = null,
					Description = "Objects in a 20-foot Cube within range are outlined in blue, green, or violet light (your choice). Each creature in the Cube is also outlined if it fails a Dexterity saving throw. For the duration, objects and affected creatures shed Dim Light in a 10-foot radius and can't benefit from the Invisible condition.\n\nAttack rolls against an affected creature or object have Advantage if the attacker can see it.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "faerie-fire", "it"),
					Language = LanguageCode.It,
					Name = "Luminescenza",
					CastingTime = "Azione",
					Range = "18 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = null,
					Description = "Gli oggetti in un cubo con spigolo di 6 metri entro gittata vengono delineati da una luce blu, verde o viola (a scelta dell'incantatore). Anche ogni creatura nel cubo viene delineata, se fallisce un tiro salvezza su Destrezza. Per la durata, gli oggetti e le creature influenzate proiettano luce fioca in un raggio di 3 metri e non possono beneficiare della condizione invisibile.\n\nI tiri per colpire contro una creatura o un oggetto influenzati dispongono di vantaggio, se l'attaccante è in grado di vederli.",
					HigherLevels = null
				}
			}
		};
	}
}
