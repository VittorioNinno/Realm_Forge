using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Plant Growth (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class PlantGrowth2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "plant-growth");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 3,
			School = SpellSchool.Transmutation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Druid, SpellcastingClass.Ranger },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "plant-growth", "en"),
					Language = LanguageCode.En,
					Name = "Plant Growth",
					CastingTime = "1 action or 8 hours",
					Range = "150 feet",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "This spell channels vitality into plants within a specific area. There are two possible uses for the spell, granting either immediate or long-term benefits.\n\nIf you cast this spell using 1 action, choose a point within range. All normal plants in a 100-foot radius centered on that point become thick and overgrown. A creature moving through the area must spend 4 feet of movement for every 1 foot it moves.\n\nYou can exclude one or more areas of any size within the spell's area from being affected.\n\nIf you cast this spell over 8 hours, you enrich the land. All plants in a half-mile radius centered on a point within range become enriched for 1 year. The plants yield twice the normal amount of food when harvested.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "plant-growth", "it"),
					Language = LanguageCode.It,
					Name = "Crescita Vegetale",
					CastingTime = "1 azione o 8 ore",
					Range = "45 metri",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "Questo incantesimo infonde vitalità nei vegetali all'interno di un'area specifica. L'incantesimo ha due usi possibili, che conferiscono benefici immediati o a lungo termine.\n\nSe l'incantatore lancia questo incantesimo usando 1 azione, sceglie un punto entro gittata. Tutti i vegetali normali in un raggio di 30 metri centrato su quel punto diventano fitti e rigogliosi. Una creatura che si muove attraverso l'area deve spendere 4 metri di movimento per ogni metro percorso.\n\nL'incantatore può escludere dall'effetto una o più aree di qualsiasi dimensione all'interno dell'area dell'incantesimo.\n\nSe lancia questo incantesimo nell'arco di 8 ore, l'incantatore arricchisce la terra. Tutti i vegetali in un raggio di 750 metri centrato su un punto entro gittata diventano più rigogliosi per 1 anno. Quando vengono raccolti, i vegetali producono il doppio della normale quantità di cibo.",
					HigherLevels = null
				}
			}
		};
	}
}
