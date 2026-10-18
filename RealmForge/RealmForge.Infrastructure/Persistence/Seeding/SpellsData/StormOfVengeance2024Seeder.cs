using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Storm of Vengeance (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class StormOfVengeance2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "storm-of-vengeance");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 9,
			School = SpellSchool.Conjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Druid },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "storm-of-vengeance", "en"),
					Language = LanguageCode.En,
					Name = "Storm of Vengeance",
					CastingTime = "Action",
					Range = "1 mile",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = null,
					Description = "A churning storm cloud forms for the duration, centered on a point within range and spreading to a radius of 300 feet. Each creature under the cloud when it appears must succeed on a Constitution saving throw or take 2d6 Thunder damage and have the Deafened condition for the duration.\n\nAt the start of each of your later turns, the storm produces different effects, as detailed below.\n\n***Turn 2.*** Acidic rain falls. Each creature and object under the cloud takes 4d6 Acid damage.\n\n***Turn 3.*** You call six bolts of lightning from the cloud to strike six different creatures or objects beneath it. Each target makes a Dexterity saving throw, taking 10d6 Lightning damage on a failed save or half as much damage on a successful one.\n\n***Turn 4.*** Hailstones rain down. Each creature under the cloud takes 2d6 Bludgeoning damage.\n\n***Turns 5–10.*** Gusts and freezing rain assail the area under the cloud. Each creature there takes 1d6 Cold damage. Until the spell ends, the area is Difficult Terrain and Heavily Obscured, ranged attacks with weapons are impossible there, and strong wind blows through the area.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "storm-of-vengeance", "it"),
					Language = LanguageCode.It,
					Name = "Tempesta di Vendetta",
					CastingTime = "Azione",
					Range = "1,5 km",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = null,
					Description = "Una nube temporalesca ribollente si forma per la durata, centrata su un punto entro gittata ed estesa fino a un raggio di 90 metri. Ogni creatura sotto la nube quando compare deve superare un tiro salvezza su Costituzione, altrimenti subisce 2d6 danni da tuono ed è assordata per la durata.\n\nAll'inizio di ognuno dei turni successivi dell'incantatore, la tempesta produce effetti diversi, come descritto sotto.\n\n***Turno 2.*** Cade una pioggia acida. Ogni creatura e oggetto sotto la nube subisce 4d6 danni da acido.\n\n***Turno 3.*** L'incantatore fa scaturire dalla nube sei fulmini che colpiscono sei creature od oggetti diversi sotto di essa. Ogni bersaglio effettua un tiro salvezza su Destrezza, subendo 10d6 danni da fulmine se lo fallisce, o la metà di quei danni se lo supera.\n\n***Turno 4.*** Piovono chicchi di grandine. Ogni creatura sotto la nube subisce 2d6 danni contundenti.\n\n***Turni 5-10.*** Raffiche di vento e pioggia gelata investono l'area sotto la nube. Ogni creatura che si trova lì subisce 1d6 danni da freddo. Finché l'incantesimo non termina, l'area è terreno difficile ed è pesantemente oscurata, gli attacchi a distanza con un'arma sono impossibili al suo interno e un vento forte soffia attraverso l'area.",
					HigherLevels = null
				}
			}
		};
	}
}
