using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Spike Growth (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class SpikeGrowth2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "spike-growth");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 2,
			School = SpellSchool.Transmutation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Druid, SpellcastingClass.Ranger },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "spike-growth", "en"),
					Language = LanguageCode.En,
					Name = "Spike Growth",
					CastingTime = "Action",
					Range = "150 feet",
					Duration = "Concentration, up to 10 minutes",
					MaterialComponent = "seven thorns",
					Description = "The ground in a 20-foot-radius Sphere centered on a point within range sprouts hard spikes and thorns. The area becomes Difficult Terrain for the duration. When a creature moves into or within the area, it takes 2d4 Piercing damage for every 5 feet it travels.\n\nThe transformation of the ground is camouflaged to look natural. Any creature that can't see the area when the spell is cast must take a Search action and succeed on a Wisdom (Perception or Survival) check against your spell save DC to recognize the terrain as hazardous before entering it.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "spike-growth", "it"),
					Language = LanguageCode.It,
					Name = "Crescita di Spine",
					CastingTime = "Azione",
					Range = "45 metri",
					Duration = "Concentrazione, fino a 10 minuti",
					MaterialComponent = "sette spine",
					Description = "Il terreno in una sfera del raggio di 6 metri centrata su un punto entro gittata si ricopre di aculei e spine acuminati. L'area diventa terreno difficile per la durata. Quando una creatura entra nell'area o si muove al suo interno, subisce 2d4 danni perforanti per ogni 1,5 metri percorso.\n\nLa trasformazione del terreno è camuffata in modo da sembrare naturale. Qualsiasi creatura che non è in grado di vedere l'area quando l'incantesimo viene lanciato deve effettuare l'azione di Ricerca e superare una prova di Saggezza (Percezione o Sopravvivenza) contro la CD del tiro salvezza degli incantesimi dell'incantatore per riconoscere il terreno come pericoloso prima di entrarvi.",
					HigherLevels = null
				}
			}
		};
	}
}
