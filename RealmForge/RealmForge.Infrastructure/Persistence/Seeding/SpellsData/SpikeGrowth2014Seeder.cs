using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Spike Growth (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class SpikeGrowth2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "spike-growth");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "spike-growth", "en"),
					Language = LanguageCode.En,
					Name = "Spike Growth",
					CastingTime = "1 action",
					Range = "150 feet",
					Duration = "Concentration, up to 10 minutes",
					MaterialComponent = "seven sharp thorns or seven small twigs, each sharpened to a point",
					Description = "The ground in a 20-foot radius centered on a point within range twists and sprouts hard spikes and thorns. The area becomes difficult terrain for the duration. When a creature moves into or within the area, it takes 2d4 piercing damage for every 5 feet it travels.\n\nThe transformation of the ground is camouflaged to look natural. Any creature that can't see the area at the time the spell is cast can make a Wisdom (Perception) check against your spell save DC to recognize the terrain as hazardous before entering it.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "spike-growth", "it"),
					Language = LanguageCode.It,
					Name = "Crescita di Spine",
					CastingTime = "1 azione",
					Range = "45 metri",
					Duration = "Concentrazione, fino a 10 minuti",
					MaterialComponent = "sette spine acuminate o sette piccoli ramoscelli, ognuno affilato a punta",
					Description = "Il terreno in un raggio di 6 metri centrato su un punto entro gittata si contorce e fa spuntare aculei e spine resistenti. Per la durata, l'area diventa terreno difficile. Quando una creatura entra nell'area o vi si muove all'interno, subisce 2d4 danni perforanti per ogni 1,5 metri percorsi.\n\nLa trasformazione del terreno è camuffata in modo da sembrare naturale. Qualsiasi creatura che non è in grado di vedere l'area nel momento in cui l'incantesimo viene lanciato può effettuare una prova di Saggezza (Percezione) contro la CD del tiro salvezza degli incantesimi dell'incantatore per riconoscere il terreno come pericoloso prima di entrarvi.",
					HigherLevels = null
				}
			}
		};
	}
}
