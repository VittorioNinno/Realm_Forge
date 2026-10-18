using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Mass Healing Word (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class MassHealingWord2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "mass-healing-word");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 3,
			School = SpellSchool.Abjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Cleric },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = false,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "mass-healing-word", "en"),
					Language = LanguageCode.En,
					Name = "Mass Healing Word",
					CastingTime = "Bonus Action",
					Range = "60 feet",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "Up to six creatures of your choice that you can see within range regain Hit Points equal to 2d4 plus your spellcasting ability modifier.",
					HigherLevels = "The healing increases by 1d4 for each spell slot level above 3."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "mass-healing-word", "it"),
					Language = LanguageCode.It,
					Name = "Parola Guaritrice di Massa",
					CastingTime = "Azione bonus",
					Range = "18 metri",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "Fino a sei creature a scelta dell'incantatore entro gittata, che egli è in grado di vedere, recuperano punti ferita pari a 2d4 più il modificatore di caratteristica da incantatore dell'incantatore.",
					HigherLevels = "La guarigione aumenta di 1d4 per ogni livello dello slot incantesimo superiore al 3°."
				}
			}
		};
	}
}
