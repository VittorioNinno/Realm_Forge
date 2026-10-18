using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Plant Growth (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class PlantGrowth2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "plant-growth");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "plant-growth", "en"),
					Language = LanguageCode.En,
					Name = "Plant Growth",
					CastingTime = "Action (Overgrowth) or 8 hours (Enrichment)",
					Range = "150 feet",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "This spell channels vitality into plants. The casting time you use determines whether the spell has the Overgrowth or the Enrichment effect below.\n\n***Overgrowth.*** Choose a point within range. All normal plants in a 100-foot-radius Sphere centered on that point become thick and overgrown. A creature moving through that area must spend 4 feet of movement for every 1 foot it moves. You can exclude one or more areas of any size within the spell's area from being affected.\n\n***Enrichment.*** All plants in a half-mile radius centered on a point within range become enriched for 365 days. The plants yield twice the normal amount of food when harvested. They can benefit from only one *Plant Growth* per year.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "plant-growth", "it"),
					Language = LanguageCode.It,
					Name = "Crescita Vegetale",
					CastingTime = "Azione (Groviglio) o 8 ore (Fertilità)",
					Range = "45 metri",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "Questo incantesimo infonde vitalità nelle piante. Il tempo di lancio usato determina se l'incantesimo ha l'effetto Groviglio o l'effetto Fertilità descritti sotto.\n\n***Groviglio.*** L'incantatore sceglie un punto entro gittata. Tutte le piante normali in una sfera del raggio di 30 metri centrata su quel punto diventano fitte e rigogliose. Una creatura che si muove attraverso quell'area deve spendere 4 metri di movimento per ogni metro percorso. L'incantatore può escludere dall'effetto una o più aree di qualsiasi dimensione all'interno dell'area dell'incantesimo.\n\n***Fertilità.*** Tutte le piante in un raggio di 750 metri centrato su un punto entro gittata diventano fertili per 365 giorni. Al momento del raccolto, le piante producono il doppio della normale quantità di cibo. Possono beneficiare di un solo incantesimo *crescita vegetale* all'anno.",
					HigherLevels = null
				}
			}
		};
	}
}
