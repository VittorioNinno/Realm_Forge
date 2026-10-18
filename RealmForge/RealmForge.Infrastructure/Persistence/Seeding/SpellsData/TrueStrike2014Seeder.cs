using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	True Strike (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class TrueStrike2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "true-strike");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 0,
			School = SpellSchool.Divination,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Sorcerer, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = false,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "true-strike", "en"),
					Language = LanguageCode.En,
					Name = "True Strike",
					CastingTime = "1 action",
					Range = "30 feet",
					Duration = "Concentration, up to 1 round",
					MaterialComponent = null,
					Description = "You extend your hand and point a finger at a target in range. Your magic grants you a brief insight into the target's defenses. On your next turn, you gain advantage on your first attack roll against the target, provided that this spell hasn't ended.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "true-strike", "it"),
					Language = LanguageCode.It,
					Name = "Colpo Accurato",
					CastingTime = "1 azione",
					Range = "9 metri",
					Duration = "Concentrazione, fino a 1 round",
					MaterialComponent = null,
					Description = "L'incantatore tende la mano e punta il dito verso un bersaglio entro gittata. La sua magia gli fornisce una breve intuizione sulle difese del bersaglio. Nel suo turno successivo, dispone di vantaggio al primo tiro per colpire contro il bersaglio, purché questo incantesimo non sia terminato.",
					HigherLevels = null
				}
			}
		};
	}
}
