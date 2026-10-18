using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Revivify (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Revivify2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "revivify");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 3,
			School = SpellSchool.Necromancy,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric, SpellcastingClass.Druid, SpellcastingClass.Paladin, SpellcastingClass.Ranger },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "revivify", "en"),
					Language = LanguageCode.En,
					Name = "Revivify",
					CastingTime = "Action",
					Range = "Touch",
					Duration = "Instantaneous",
					MaterialComponent = "a diamond worth 300+ GP, which the spell consumes",
					Description = "You touch a creature that has died within the last minute. That creature revives with 1 Hit Point. This spell can't revive a creature that has died of old age, nor does it restore any missing body parts.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "revivify", "it"),
					Language = LanguageCode.It,
					Name = "Rinascita",
					CastingTime = "Azione",
					Range = "Contatto",
					Duration = "Istantanea",
					MaterialComponent = "un diamante del valore di almeno 300 mo, che l'incantesimo consuma",
					Description = "L'incantatore tocca una creatura morta nell'ultimo minuto. Quella creatura torna in vita con 1 punto ferita. Questo incantesimo non può riportare in vita una creatura morta di vecchiaia, né ripristina le parti del corpo mancanti.",
					HigherLevels = null
				}
			}
		};
	}
}
