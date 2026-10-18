using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Stinking Cloud (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class StinkingCloud2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "stinking-cloud");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 3,
			School = SpellSchool.Conjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "stinking-cloud", "en"),
					Language = LanguageCode.En,
					Name = "Stinking Cloud",
					CastingTime = "1 action",
					Range = "90 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = "a rotten egg or several skunk cabbage leaves",
					Description = "You create a 20-foot-radius sphere of yellow, nauseating gas centered on a point within range. The cloud spreads around corners, and its area is heavily obscured. The cloud lingers in the air for the duration.\n\nEach creature that is completely within the cloud at the start of its turn must make a Constitution saving throw against poison. On a failed save, the creature spends its action that turn retching and reeling. Creatures that don't need to breathe or are immune to poison automatically succeed on this saving throw.\n\nA moderate wind (at least 10 miles per hour) disperses the cloud after 4 rounds. A strong wind (at least 20 miles per hour) disperses it after 1 round.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "stinking-cloud", "it"),
					Language = LanguageCode.It,
					Name = "Nube Maleodorante",
					CastingTime = "1 azione",
					Range = "27 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = "un uovo marcio o alcune foglie di cavolo puzzolente",
					Description = "L'incantatore crea una sfera di gas giallo e nauseabondo del raggio di 6 metri, centrata su un punto entro gittata. La nube si propaga dietro gli angoli e la sua area è pesantemente oscurata. La nube rimane sospesa nell'aria per la durata.\n\nOgni creatura che si trova completamente all'interno della nube all'inizio del proprio turno deve effettuare un tiro salvezza su Costituzione contro il veleno. Se lo fallisce, la creatura trascorre la sua azione di quel turno a vomitare e barcollare. Le creature che non hanno bisogno di respirare o che sono immuni al veleno superano automaticamente questo tiro salvezza.\n\nUn vento moderato (almeno 15 km orari) disperde la nube dopo 4 round. Un vento forte (almeno 30 km orari) la disperde dopo 1 round.",
					HigherLevels = null
				}
			}
		};
	}
}
