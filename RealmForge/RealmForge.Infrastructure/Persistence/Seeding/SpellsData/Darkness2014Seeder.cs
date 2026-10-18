using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Darkness (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Darkness2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "darkness");

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
			Classes = new List<SpellcastingClass> { SpellcastingClass.Sorcerer, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = false,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "darkness", "en"),
					Language = LanguageCode.En,
					Name = "Darkness",
					CastingTime = "1 action",
					Range = "60 feet",
					Duration = "Concentration, up to 10 minutes",
					MaterialComponent = "bat fur and a drop of pitch or piece of coal",
					Description = "Magical darkness spreads from a point you choose within range to fill a 15-foot-radius sphere for the duration. The darkness spreads around corners. A creature with darkvision can't see through this darkness, and nonmagical light can't illuminate it.\n\nIf the point you choose is on an object you are holding or one that isn't being worn or carried, the darkness emanates from the object and moves with it. Completely covering the source of the darkness with an opaque object, such as a bowl or a helm, blocks the darkness.\n\nIf any of this spell's area overlaps with an area of light created by a spell of 2nd level or lower, the spell that created the light is dispelled.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "darkness", "it"),
					Language = LanguageCode.It,
					Name = "Oscurità",
					CastingTime = "1 azione",
					Range = "18 metri",
					Duration = "Concentrazione, fino a 10 minuti",
					MaterialComponent = "pelo di pipistrello e una goccia di pece o un pezzo di carbone",
					Description = "Per la durata, un'oscurità magica si espande da un punto entro gittata scelto dall'incantatore fino a riempire una sfera del raggio di 4,5 metri. L'oscurità si propaga dietro gli angoli. Una creatura dotata di scurovisione non può vedere attraverso questa oscurità e la luce non magica non può illuminarla.\n\nSe il punto scelto si trova su un oggetto che l'incantatore impugna o su un oggetto che non è indossato o trasportato, l'oscurità emana dall'oggetto e si sposta con esso. Coprire completamente la fonte dell'oscurità con un oggetto opaco, come una ciotola o un elmo, blocca l'oscurità.\n\nSe una parte qualsiasi dell'area di questo incantesimo si sovrappone a un'area di luce creata da un incantesimo di 2° livello o inferiore, l'incantesimo che ha creato la luce viene dissolto.",
					HigherLevels = null
				}
			}
		};
	}
}
