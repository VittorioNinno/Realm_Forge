using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Gust of Wind (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class GustOfWind2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "gust-of-wind");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 2,
			School = SpellSchool.Evocation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Druid, SpellcastingClass.Ranger, SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "gust-of-wind", "en"),
					Language = LanguageCode.En,
					Name = "Gust of Wind",
					CastingTime = "Action",
					Range = "Self",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = "a legume seed",
					Description = "A Line of strong wind 60 feet long and 10 feet wide blasts from you in a direction you choose for the duration. Each creature in the Line must succeed on a Strength saving throw or be pushed 15 feet away from you in a direction following the Line. A creature that ends its turn in the Line must make the same save.\n\nAny creature in the Line must spend 2 feet of movement for every 1 foot it moves when moving closer to you.\n\nThe gust disperses gas or vapor, and it extinguishes candles and similar unprotected flames in the area. It causes protected flames, such as those of lanterns, to dance wildly and has a 50 percent chance to extinguish them.\n\nAs a Bonus Action on your later turns, you can change the direction in which the Line blasts from you.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "gust-of-wind", "it"),
					Language = LanguageCode.It,
					Name = "Folata di Vento",
					CastingTime = "Azione",
					Range = "Incantatore",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = "un seme di legume",
					Description = "Per la durata, una linea di vento forte lunga 18 metri e larga 3 metri soffia dall'incantatore in una direzione a sua scelta. Ogni creatura nella linea deve superare un tiro salvezza su Forza, altrimenti viene spinta di 4,5 metri lontano dall'incantatore, in una direzione che segue la linea. Una creatura che termina il proprio turno nella linea deve effettuare lo stesso tiro salvezza.\n\nQualsiasi creatura nella linea deve spendere 2 metri di movimento per ogni metro percorso quando si avvicina all'incantatore.\n\nLa raffica disperde gas e vapori e spegne candele e simili fiamme non protette nell'area. Fa danzare violentemente le fiamme protette, come quelle delle lanterne, e ha una probabilità del 50 per cento di spegnerle.\n\nCome azione bonus nei turni successivi, l'incantatore può cambiare la direzione in cui la linea soffia da lui.",
					HigherLevels = null
				}
			}
		};
	}
}
