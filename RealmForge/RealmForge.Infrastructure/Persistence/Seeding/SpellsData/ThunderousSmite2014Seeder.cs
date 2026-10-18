using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Thunderous Smite (2014 ruleset). Not part of SRD 5.1: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class ThunderousSmite2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "thunderous-smite");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			Level = 1,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "thunderous-smite", "en"),
					Language = LanguageCode.En,
					Name = "Thunderous Smite",
					CastingTime = "1 bonus action",
					Range = "Self",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = null,
					Description = "The next time you hit with a melee weapon attack while this spell lasts, your weapon booms with thunder that can be heard up to 300 feet away, and the attack deals an extra 2d6 thunder damage. If the target is a creature, it must also succeed on a Strength saving throw or be pushed 10 feet away from you and knocked prone.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "thunderous-smite", "it"),
					Language = LanguageCode.It,
					Name = "Punizione Tonante",
					CastingTime = "1 azione bonus",
					Range = "Incantatore",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = null,
					Description = "La prossima volta che l'incantatore colpisce con un attacco con un'arma da mischia finché l'incantesimo dura, la sua arma rimbomba con un tuono udibile fino a 90 metri di distanza, e l'attacco infligge 2d6 danni da tuono extra. Se il bersaglio è una creatura, deve inoltre superare un tiro salvezza su Forza, altrimenti viene spinto di 3 metri lontano dall'incantatore e cade prono.",
					HigherLevels = null
				}
			}
		};
	}
}
