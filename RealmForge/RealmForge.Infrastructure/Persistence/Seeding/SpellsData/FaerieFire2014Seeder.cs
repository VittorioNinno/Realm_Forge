using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Faerie Fire (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class FaerieFire2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "faerie-fire");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 1,
			School = SpellSchool.Evocation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Druid },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = false,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "faerie-fire", "en"),
					Language = LanguageCode.En,
					Name = "Faerie Fire",
					CastingTime = "1 action",
					Range = "60 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = null,
					Description = "Each object in a 20-foot cube within range is outlined in blue, green, or violet light (your choice). Any creature in the area when the spell is cast is also outlined in light if it fails a Dexterity saving throw. For the duration, objects and affected creatures shed dim light in a 10-foot radius.\n\nAny attack roll against an affected creature or object has advantage if the attacker can see it, and the affected creature or object can't benefit from being invisible.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "faerie-fire", "it"),
					Language = LanguageCode.It,
					Name = "Luminescenza",
					CastingTime = "1 azione",
					Range = "18 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = null,
					Description = "Ogni oggetto in un cubo con spigolo di 6 metri entro gittata viene delineato da una luce blu, verde o viola (a scelta dell'incantatore). Anche ogni creatura che si trova nell'area quando l'incantesimo viene lanciato viene delineata dalla luce, se fallisce un tiro salvezza su Destrezza. Per la durata, gli oggetti e le creature influenzate emettono luce fioca in un raggio di 3 metri.\n\nQualsiasi tiro per colpire contro una creatura o un oggetto influenzato dispone di vantaggio se l'attaccante è in grado di vederlo, e la creatura o l'oggetto influenzato non può beneficiare dell'invisibilità.",
					HigherLevels = null
				}
			}
		};
	}
}
