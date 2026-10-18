using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Banishing Smite (2014 ruleset). Not part of SRD 5.1: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class BanishingSmite2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "banishing-smite");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			Level = 5,
			School = SpellSchool.Abjuration,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "banishing-smite", "en"),
					Language = LanguageCode.En,
					Name = "Banishing Smite",
					CastingTime = "1 bonus action",
					Range = "Self",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = null,
					Description = "The next time you hit a creature with a weapon attack before this spell ends, your weapon crackles with force and the attack deals an extra 5d10 force damage. If that attack leaves the target with 50 hit points or fewer, you also banish it. A target native to another plane of existence vanishes and returns to its home plane. A target native to your current plane is sent instead to a harmless demiplane, where it is incapacitated until the spell ends; it then reappears in the space it left, or in the nearest unoccupied space if that one is taken.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "banishing-smite", "it"),
					Language = LanguageCode.It,
					Name = "Punizione Esiliante",
					CastingTime = "1 azione bonus",
					Range = "Incantatore",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = null,
					Description = "La prossima volta che l'incantatore colpisce una creatura con un attacco con un'arma prima che questo incantesimo termini, la sua arma crepita di forza e l'attacco infligge 5d10 danni da forza extra. Se l'attacco lascia il bersaglio con 50 punti ferita o meno, l'incantatore lo esilia. Un bersaglio originario di un altro piano di esistenza svanisce e fa ritorno al proprio piano d'origine. Un bersaglio originario del piano in cui si trova l'incantatore viene invece inviato in un semipiano innocuo, dove è incapacitato finché l'incantesimo non termina; a quel punto ricompare nello spazio che aveva lasciato o, se è occupato, nello spazio libero più vicino.",
					HigherLevels = null
				}
			}
		};
	}
}
