using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Gust of Wind (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class GustOfWind2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "gust-of-wind");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 2,
			School = SpellSchool.Evocation,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "gust-of-wind", "en"),
					Language = LanguageCode.En,
					Name = "Gust of Wind",
					CastingTime = "1 action",
					Range = "Self (60-foot line)",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = "a legume seed",
					Description = "A line of strong wind 60 feet long and 10 feet wide blasts from you in a direction you choose for the spell's duration. Each creature that starts its turn in the line must succeed on a Strength saving throw or be pushed 15 feet away from you in a direction following the line.\n\nAny creature in the line must spend 2 feet of movement for every 1 foot it moves when moving closer to you.\n\nThe gust disperses gas or vapor, and it extinguishes candles, torches, and similar unprotected flames in the area. It causes protected flames, such as those of lanterns, to dance wildly and has a 50 percent chance to extinguish them.\n\nAs a bonus action on each of your turns before the spell ends, you can change the direction in which the line blasts from you.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "gust-of-wind", "it"),
					Language = LanguageCode.It,
					Name = "Folata di Vento",
					CastingTime = "1 azione",
					Range = "Incantatore (linea di 18 metri)",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = "un seme di legume",
					Description = "Per la durata dell'incantesimo, una linea di vento forte lunga 18 metri e larga 3 metri soffia dall'incantatore in una direzione da lui scelta. Ogni creatura che inizia il proprio turno nella linea deve superare un tiro salvezza su Forza, altrimenti viene spinta di 4,5 metri lontano dall'incantatore, nella direzione della linea.\n\nQualsiasi creatura nella linea deve spendere 2 metri di movimento per ogni metro percorso quando si avvicina all'incantatore.\n\nLa raffica disperde gas e vapori e spegne candele, torce e fiamme simili non protette nell'area. Fa tremolare violentemente le fiamme protette, come quelle delle lanterne, e ha una probabilità del 50 per cento di spegnerle.\n\nCome azione bonus in ognuno dei suoi turni, prima che l'incantesimo termini, l'incantatore può cambiare la direzione in cui la linea soffia da lui.",
					HigherLevels = null
				}
			}
		};
	}
}
