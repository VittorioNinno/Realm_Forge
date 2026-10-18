using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Lightning Bolt (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class LightningBolt2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "lightning-bolt");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 3,
			School = SpellSchool.Evocation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "lightning-bolt", "en"),
					Language = LanguageCode.En,
					Name = "Lightning Bolt",
					CastingTime = "1 action",
					Range = "Self (100-foot line)",
					Duration = "Instantaneous",
					MaterialComponent = "a bit of fur and a rod of amber, crystal, or glass",
					Description = "A stroke of lightning forming a line 100 feet long and 5 feet wide blasts out from you in a direction you choose. Each creature in the line must make a Dexterity saving throw. A creature takes 8d6 lightning damage on a failed save, or half as much damage on a successful one.\n\nThe lightning ignites flammable objects in the area that aren't being worn or carried.",
					HigherLevels = "When you cast this spell using a spell slot of 4th level or higher, the damage increases by 1d6 for each slot level above 3rd."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "lightning-bolt", "it"),
					Language = LanguageCode.It,
					Name = "Fulmine",
					CastingTime = "1 azione",
					Range = "Incantatore (linea di 30 metri)",
					Duration = "Istantanea",
					MaterialComponent = "un po' di pelliccia e una bacchetta d'ambra, di cristallo o di vetro",
					Description = "Un fulmine che forma una linea lunga 30 metri e larga 1,5 metri scaturisce dall'incantatore in una direzione da lui scelta. Ogni creatura nella linea deve effettuare un tiro salvezza su Destrezza. Una creatura subisce 8d6 danni da fulmine se fallisce il tiro salvezza, o la metà di quei danni se lo supera.\n\nIl fulmine incendia gli oggetti infiammabili nell'area che non sono indossati o trasportati.",
					HigherLevels = "Quando l'incantatore lancia questo incantesimo usando uno slot incantesimo di 4° livello o superiore, i danni aumentano di 1d6 per ogni livello dello slot superiore al 3°."
				}
			}
		};
	}
}
