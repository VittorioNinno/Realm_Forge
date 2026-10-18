using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Prayer of Healing (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class PrayerOfHealing2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "prayer-of-healing");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 2,
			School = SpellSchool.Abjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric, SpellcastingClass.Paladin },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = false,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "prayer-of-healing", "en"),
					Language = LanguageCode.En,
					Name = "Prayer of Healing",
					CastingTime = "10 minutes",
					Range = "30 feet",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "Up to five creatures of your choice who remain within range for the spell's entire casting gain the benefits of a Short Rest and also regain 2d8 Hit Points. A creature can't be affected by this spell again until that creature finishes a Long Rest.",
					HigherLevels = "The healing increases by 1d8 for each spell slot level above 2."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "prayer-of-healing", "it"),
					Language = LanguageCode.It,
					Name = "Preghiera di Guarigione",
					CastingTime = "10 minuti",
					Range = "9 metri",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "Fino a cinque creature a scelta dell'incantatore che rimangono entro gittata per l'intera durata del lancio dell'incantesimo ottengono i benefici di un riposo breve e recuperano inoltre 2d8 punti ferita. Una creatura non può essere influenzata di nuovo da questo incantesimo finché non termina un riposo lungo.",
					HigherLevels = "La guarigione aumenta di 1d8 per ogni livello dello slot incantesimo superiore al 2°."
				}
			}
		};
	}
}
