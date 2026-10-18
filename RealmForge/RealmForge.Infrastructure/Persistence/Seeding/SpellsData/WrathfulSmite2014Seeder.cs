using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Wrathful Smite (2014 ruleset). Not part of SRD 5.1: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class WrathfulSmite2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "wrathful-smite");

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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "wrathful-smite", "en"),
					Language = LanguageCode.En,
					Name = "Wrathful Smite",
					CastingTime = "1 bonus action",
					Range = "Self",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = null,
					Description = "The next time you hit with a melee weapon attack while this spell lasts, the attack deals an extra 1d6 psychic damage. If the target is a creature, it must also succeed on a Wisdom saving throw or be frightened of you until the spell ends. As an action, the frightened creature can make a Wisdom check against your spell save DC to master its fear and end the spell.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "wrathful-smite", "it"),
					Language = LanguageCode.It,
					Name = "Punizione Collerica",
					CastingTime = "1 azione bonus",
					Range = "Incantatore",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = null,
					Description = "La prossima volta che l'incantatore colpisce con un attacco con un'arma da mischia finché l'incantesimo dura, l'attacco infligge 1d6 danni psichici extra. Se il bersaglio è una creatura, deve inoltre superare un tiro salvezza su Saggezza, altrimenti è spaventato dall'incantatore finché l'incantesimo non termina. Come azione, la creatura spaventata può effettuare una prova di Saggezza contro la CD del tiro salvezza degli incantesimi dell'incantatore per dominare la propria paura e porre fine all'incantesimo.",
					HigherLevels = null
				}
			}
		};
	}
}
