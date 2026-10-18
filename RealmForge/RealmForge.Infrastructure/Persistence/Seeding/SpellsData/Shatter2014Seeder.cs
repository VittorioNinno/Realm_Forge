using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Shatter (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Shatter2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "shatter");

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
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Sorcerer, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "shatter", "en"),
					Language = LanguageCode.En,
					Name = "Shatter",
					CastingTime = "1 action",
					Range = "60 feet",
					Duration = "Instantaneous",
					MaterialComponent = "a chip of mica",
					Description = "A sudden loud ringing noise, painfully intense, erupts from a point of your choice within range. Each creature in a 10-foot-radius sphere centered on that point must make a Constitution saving throw. A creature takes 3d8 thunder damage on a failed save, or half as much damage on a successful one. A creature made of inorganic material such as stone, crystal, or metal has disadvantage on this saving throw.\n\nA nonmagical object that isn't being worn or carried also takes the damage if it's in the spell's area.",
					HigherLevels = "When you cast this spell using a spell slot of 3rd level or higher, the damage increases by 1d8 for each slot level above 2nd."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "shatter", "it"),
					Language = LanguageCode.It,
					Name = "Frantumare",
					CastingTime = "1 azione",
					Range = "18 metri",
					Duration = "Istantanea",
					MaterialComponent = "una scaglia di mica",
					Description = "Un improvviso e fortissimo suono squillante, dolorosamente intenso, erompe da un punto entro gittata a scelta dell'incantatore. Ogni creatura in una sfera del raggio di 3 metri centrata su quel punto deve effettuare un tiro salvezza su Costituzione. Una creatura subisce 3d8 danni da tuono se fallisce il tiro salvezza, o la metà di quei danni se lo supera. Una creatura fatta di materiale inorganico, come pietra, cristallo o metallo, subisce svantaggio a questo tiro salvezza.\n\nAnche un oggetto non magico che non è indossato o trasportato subisce i danni se si trova nell'area dell'incantesimo.",
					HigherLevels = "Quando l'incantatore lancia questo incantesimo usando uno slot incantesimo di 3° livello o superiore, i danni aumentano di 1d8 per ogni livello dello slot superiore al 2°."
				}
			}
		};
	}
}
