using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Burning Hands (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class BurningHands2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "burning-hands");

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
			Classes = new List<SpellcastingClass> { SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "burning-hands", "en"),
					Language = LanguageCode.En,
					Name = "Burning Hands",
					CastingTime = "1 action",
					Range = "Self (15-foot cone)",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "As you hold your hands with thumbs touching and fingers spread, a thin sheet of flames shoots forth from your outstretched fingertips. Each creature in a 15-foot cone must make a Dexterity saving throw. A creature takes 3d6 fire damage on a failed save, or half as much damage on a successful one.\n\nThe fire ignites any flammable objects in the area that aren't being worn or carried.",
					HigherLevels = "When you cast this spell using a spell slot of 2nd level or higher, the damage increases by 1d6 for each slot level above 1st."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "burning-hands", "it"),
					Language = LanguageCode.It,
					Name = "Mani Brucianti",
					CastingTime = "1 azione",
					Range = "Incantatore (cono di 4,5 metri)",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "Mentre l'incantatore tiene le mani con i pollici che si toccano e le dita aperte, un sottile ventaglio di fiamme scaturisce dalla punta delle sue dita tese. Ogni creatura in un cono di 4,5 metri deve effettuare un tiro salvezza su Destrezza. Una creatura subisce 3d6 danni da fuoco se fallisce il tiro salvezza, o la metà di quei danni se lo supera.\n\nIl fuoco incendia gli oggetti infiammabili nell'area che non sono indossati o trasportati.",
					HigherLevels = "Quando l'incantatore lancia questo incantesimo usando uno slot incantesimo di 2° livello o superiore, i danni aumentano di 1d6 per ogni livello dello slot superiore al 1°."
				}
			}
		};
	}
}
