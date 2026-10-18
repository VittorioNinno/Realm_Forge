using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Staggering Smite (2014 ruleset). Not part of SRD 5.1: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class StaggeringSmite2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "staggering-smite");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			Level = 4,
			School = SpellSchool.Evocation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Paladin },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = false,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "staggering-smite", "en"),
					Language = LanguageCode.En,
					Name = "Staggering Smite",
					CastingTime = "1 bonus action",
					Range = "Self",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = null,
					Description = "The next time you hit a creature with a melee weapon attack while this spell lasts, your weapon strikes at both body and mind, and the attack deals an extra 4d6 psychic damage. The target must make a Wisdom saving throw. On a failure, until the end of its next turn it has disadvantage on attack rolls and ability checks and can't take reactions.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "staggering-smite", "it"),
					Language = LanguageCode.It,
					Name = "Punizione Demoralizzante",
					CastingTime = "1 azione bonus",
					Range = "Incantatore",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = null,
					Description = "La prossima volta che l'incantatore colpisce una creatura con un attacco con un'arma da mischia finché l'incantesimo dura, la sua arma colpisce sia il corpo sia la mente, e l'attacco infligge 4d6 danni psichici extra. Il bersaglio deve effettuare un tiro salvezza su Saggezza. Se lo fallisce, fino alla fine del suo turno successivo subisce svantaggio ai tiri per colpire e alle prove di caratteristica e non può effettuare reazioni.",
					HigherLevels = null
				}
			}
		};
	}
}
