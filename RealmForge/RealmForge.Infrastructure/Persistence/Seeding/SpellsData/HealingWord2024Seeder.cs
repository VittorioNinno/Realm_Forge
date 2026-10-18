using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Healing Word (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class HealingWord2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "healing-word");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 1,
			School = SpellSchool.Abjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Cleric, SpellcastingClass.Druid },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = false,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "healing-word", "en"),
					Language = LanguageCode.En,
					Name = "Healing Word",
					CastingTime = "Bonus Action",
					Range = "60 feet",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "A creature of your choice that you can see within range regains Hit Points equal to 2d4 plus your spellcasting ability modifier.",
					HigherLevels = "The healing increases by 2d4 for each spell slot level above 1."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "healing-word", "it"),
					Language = LanguageCode.It,
					Name = "Parola Guaritrice",
					CastingTime = "Azione bonus",
					Range = "18 metri",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "Una creatura a scelta dell'incantatore entro gittata, che egli è in grado di vedere, recupera punti ferita pari a 2d4 più il modificatore di caratteristica da incantatore dell'incantatore.",
					HigherLevels = "La guarigione aumenta di 2d4 per ogni livello dello slot incantesimo superiore al 1°."
				}
			}
		};
	}
}
