using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Reverse Gravity (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class ReverseGravity2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "reverse-gravity");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "reverse-gravity", "en"),
					Language = LanguageCode.En,
					Name = "Reverse Gravity",
					CastingTime = "Action",
					Range = "100 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = "a lodestone and iron filings",
					Description = "This spell reverses gravity in a 50-foot-radius, 100-foot high Cylinder centered on a point within range. All creatures and objects in that area that aren't anchored to the ground fall upward and reach the top of the Cylinder. A creature can make a Dexterity saving throw to grab a fixed object it can reach, thus avoiding the fall upward.\n\nIf a ceiling or an anchored object is encountered in this upward fall, creatures and objects strike it just as they would during a downward fall. If an affected creature or object reaches the Cylinder's top without striking anything, it hovers there for the duration. When the spell ends, affected objects and creatures fall downward.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "reverse-gravity", "it"),
					Language = LanguageCode.It,
					Name = "Inversione della Gravità",
					CastingTime = "Azione",
					Range = "30 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = "una calamita e della limatura di ferro",
					Description = "Questo incantesimo inverte la gravità in un cilindro del raggio di 15 metri e alto 30 metri, centrato su un punto entro gittata. Tutte le creature e gli oggetti in quell'area che non sono ancorati al terreno cadono verso l'alto e raggiungono la sommità del cilindro. Una creatura può effettuare un tiro salvezza su Destrezza per afferrare un oggetto fisso che può raggiungere, evitando così la caduta verso l'alto.\n\nSe durante questa caduta verso l'alto incontrano un soffitto o un oggetto ancorato, le creature e gli oggetti vi sbattono contro proprio come farebbero durante una caduta verso il basso. Se una creatura o un oggetto influenzati raggiungono la sommità del cilindro senza urtare nulla, vi fluttuano per la durata. Quando l'incantesimo termina, gli oggetti e le creature influenzati cadono verso il basso.",
					HigherLevels = null
				}
			}
		};
	}
}
