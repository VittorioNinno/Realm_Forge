using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Heal (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Heal2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "heal");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 6,
			School = SpellSchool.Abjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric, SpellcastingClass.Druid },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "heal", "en"),
					Language = LanguageCode.En,
					Name = "Heal",
					CastingTime = "Action",
					Range = "60 feet",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "Choose a creature that you can see within range. Positive energy washes through the target, restoring 70 Hit Points. This spell also ends the Blinded, Deafened, and Poisoned conditions on the target.",
					HigherLevels = "The healing increases by 10 for each spell slot level above 6."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "heal", "it"),
					Language = LanguageCode.It,
					Name = "Guarigione",
					CastingTime = "Azione",
					Range = "18 metri",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "L'incantatore sceglie una creatura entro gittata che è in grado di vedere. Un'ondata di energia positiva pervade il bersaglio, facendogli recuperare 70 punti ferita. Questo incantesimo pone inoltre fine alle condizioni accecato, assordato e avvelenato sul bersaglio.",
					HigherLevels = "La guarigione aumenta di 10 per ogni livello dello slot incantesimo superiore al 6°."
				}
			}
		};
	}
}
