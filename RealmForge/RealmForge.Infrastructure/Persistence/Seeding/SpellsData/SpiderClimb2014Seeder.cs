using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Spider Climb (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class SpiderClimb2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "spider-climb");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 2,
			School = SpellSchool.Transmutation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Sorcerer, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "spider-climb", "en"),
					Language = LanguageCode.En,
					Name = "Spider Climb",
					CastingTime = "1 action",
					Range = "Touch",
					Duration = "Concentration, up to 1 hour",
					MaterialComponent = "a drop of bitumen and a spider",
					Description = "Until the spell ends, one willing creature you touch gains the ability to move up, down, and across vertical surfaces and upside down along ceilings, while leaving its hands free. The target also gains a climbing speed equal to its walking speed.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "spider-climb", "it"),
					Language = LanguageCode.It,
					Name = "Movimenti del Ragno",
					CastingTime = "1 azione",
					Range = "Contatto",
					Duration = "Concentrazione, fino a 1 ora",
					MaterialComponent = "una goccia di bitume e un ragno",
					Description = "Finché l'incantesimo non termina, una creatura consenziente toccata dall'incantatore ottiene la capacità di salire, scendere e muoversi lungo le superfici verticali e a testa in giù lungo i soffitti, lasciando le mani libere. Il bersaglio ottiene inoltre una velocità di scalare pari alla sua velocità base sul terreno.",
					HigherLevels = null
				}
			}
		};
	}
}
