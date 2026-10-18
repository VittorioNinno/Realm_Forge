using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Blinding Smite (2014 ruleset). Not part of SRD 5.1: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class BlindingSmite2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "blinding-smite");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			Level = 3,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "blinding-smite", "en"),
					Language = LanguageCode.En,
					Name = "Blinding Smite",
					CastingTime = "1 bonus action",
					Range = "Self",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = null,
					Description = "The next time you hit a creature with a melee weapon attack while this spell lasts, your weapon blazes with dazzling light and the attack deals an extra 3d8 radiant damage. The target must also succeed on a Constitution saving throw or be blinded until the spell ends.\n\nA creature blinded this way repeats the Constitution saving throw at the end of each of its turns, and stops being blinded on a success.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "blinding-smite", "it"),
					Language = LanguageCode.It,
					Name = "Punizione Accecante",
					CastingTime = "1 azione bonus",
					Range = "Incantatore",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = null,
					Description = "La prossima volta che l'incantatore colpisce una creatura con un attacco con un'arma da mischia finché l'incantesimo dura, la sua arma divampa di una luce abbagliante e l'attacco infligge 3d8 danni radiosi extra. Il bersaglio deve inoltre superare un tiro salvezza su Costituzione, altrimenti è accecato finché l'incantesimo non termina.\n\nUna creatura accecata in questo modo ripete il tiro salvezza su Costituzione alla fine di ogni suo turno e, se lo supera, non è più accecata.",
					HigherLevels = null
				}
			}
		};
	}
}
