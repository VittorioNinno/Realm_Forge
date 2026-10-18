using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Reverse Gravity (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class ReverseGravity2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "reverse-gravity");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 7,
			School = SpellSchool.Transmutation,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "reverse-gravity", "en"),
					Language = LanguageCode.En,
					Name = "Reverse Gravity",
					CastingTime = "1 action",
					Range = "100 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = "a lodestone and iron filings",
					Description = "This spell reverses gravity in a 50-foot-radius, 100-foot high cylinder centered on a point within range. All creatures and objects that aren't somehow anchored to the ground in the area fall upward and reach the top of the area when you cast this spell. A creature can make a Dexterity saving throw to grab onto a fixed object it can reach, thus avoiding the fall.\n\nIf some solid object (such as a ceiling) is encountered in this fall, falling objects and creatures strike it just as they would during a normal downward fall. If an object or creature reaches the top of the area without striking anything, it remains there, oscillating slightly, for the duration.\n\nAt the end of the duration, affected objects and creatures fall back down.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "reverse-gravity", "it"),
					Language = LanguageCode.It,
					Name = "Inversione della Gravità",
					CastingTime = "1 azione",
					Range = "30 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = "una calamita e della limatura di ferro",
					Description = "Questo incantesimo inverte la gravità in un cilindro del raggio di 15 metri e alto 30 metri, centrato su un punto entro gittata. Quando l'incantatore lancia questo incantesimo, tutte le creature e gli oggetti nell'area che non sono in qualche modo ancorati al terreno cadono verso l'alto e raggiungono la sommità dell'area. Una creatura può effettuare un tiro salvezza su Destrezza per aggrapparsi a un oggetto fisso a portata, evitando così la caduta.\n\nSe durante questa caduta incontrano un oggetto solido (come un soffitto), gli oggetti e le creature in caduta lo urtano esattamente come farebbero durante una normale caduta verso il basso. Se un oggetto o una creatura raggiunge la sommità dell'area senza urtare nulla, vi rimane, oscillando leggermente, per la durata.\n\nAl termine della durata, gli oggetti e le creature influenzati ricadono verso il basso.",
					HigherLevels = null
				}
			}
		};
	}
}
