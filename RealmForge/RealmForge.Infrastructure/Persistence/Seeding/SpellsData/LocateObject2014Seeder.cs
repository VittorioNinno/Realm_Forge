using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Locate Object (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class LocateObject2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "locate-object");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 2,
			School = SpellSchool.Divination,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Cleric, SpellcastingClass.Druid, SpellcastingClass.Paladin, SpellcastingClass.Ranger, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "locate-object", "en"),
					Language = LanguageCode.En,
					Name = "Locate Object",
					CastingTime = "1 action",
					Range = "Self",
					Duration = "Concentration, up to 10 minutes",
					MaterialComponent = "a forked twig",
					Description = "Describe or name an object that is familiar to you. You sense the direction to the object's location, as long as that object is within 1,000 feet of you. If the object is in motion, you know the direction of its movement.\n\nThe spell can locate a specific object known to you, as long as you have seen it up close—within 30 feet—at least once. Alternatively, the spell can locate the nearest object of a particular kind, such as a certain kind of apparel, jewelry, furniture, tool, or weapon.\n\nThis spell can't locate an object if any thickness of lead, even a thin sheet, blocks a direct path between you and the object.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "locate-object", "it"),
					Language = LanguageCode.It,
					Name = "Localizza Oggetto",
					CastingTime = "1 azione",
					Range = "Incantatore",
					Duration = "Concentrazione, fino a 10 minuti",
					MaterialComponent = "un ramoscello biforcuto",
					Description = "L'incantatore descrive o nomina un oggetto a lui familiare. Percepisce la direzione in cui si trova l'oggetto, purché sia entro 300 metri da lui. Se l'oggetto è in movimento, conosce la direzione del suo movimento.\n\nL'incantesimo può localizzare uno specifico oggetto conosciuto dall'incantatore, purché lo abbia visto da vicino (entro 9 metri) almeno una volta. In alternativa, l'incantesimo può localizzare l'oggetto più vicino di un tipo particolare, come un certo tipo di indumento, gioiello, mobile, attrezzo o arma.\n\nQuesto incantesimo non può localizzare un oggetto se uno strato di piombo, anche sottile, blocca il percorso diretto tra l'incantatore e l'oggetto.",
					HigherLevels = null
				}
			}
		};
	}
}
