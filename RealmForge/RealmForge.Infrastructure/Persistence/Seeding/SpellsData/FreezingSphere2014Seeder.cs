using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Freezing Sphere (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class FreezingSphere2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "freezing-sphere");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 6,
			School = SpellSchool.Evocation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "freezing-sphere", "en"),
					Language = LanguageCode.En,
					Name = "Freezing Sphere",
					CastingTime = "1 action",
					Range = "300 feet",
					Duration = "Instantaneous",
					MaterialComponent = "a small crystal sphere",
					Description = "A frigid globe of cold energy streaks from your fingertips to a point of your choice within range, where it explodes in a 60-foot-radius sphere. Each creature within the area must make a Constitution saving throw. On a failed save, a creature takes 10d6 cold damage. On a successful save, it takes half as much damage.\n\nIf the globe strikes a body of water or a liquid that is principally water (not including water-based creatures), it freezes the liquid to a depth of 6 inches over an area 30 feet square. This ice lasts for 1 minute. Creatures that were swimming on the surface of frozen water are trapped in the ice. A trapped creature can use an action to make a Strength check against your spell save DC to break free.\n\nYou can refrain from firing the globe after completing the spell, if you wish. A small globe about the size of a sling stone, cool to the touch, appears in your hand. At any time, you or a creature you give the globe to can throw the globe (to a range of 40 feet) or hurl it with a sling (to the sling's normal range). It shatters on impact, with the same effect as the normal casting of the spell. You can also set the globe down without shattering it. After 1 minute, if the globe hasn't already shattered, it explodes.",
					HigherLevels = "When you cast this spell using a spell slot of 7th level or higher, the damage increases by 1d6 for each slot level above 6th."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "freezing-sphere", "it"),
					Language = LanguageCode.It,
					Name = "Sfera Congelante",
					CastingTime = "1 azione",
					Range = "90 metri",
					Duration = "Istantanea",
					MaterialComponent = "una piccola sfera di cristallo",
					Description = "Un globo gelido di energia fredda sfreccia dalla punta delle dita dell'incantatore verso un punto entro gittata da lui scelto, dove esplode in una sfera del raggio di 18 metri. Ogni creatura nell'area deve effettuare un tiro salvezza su Costituzione. Se lo fallisce, la creatura subisce 10d6 danni da freddo. Se lo supera, subisce la metà di quei danni.\n\nSe il globo colpisce uno specchio d'acqua o un liquido composto principalmente d'acqua (escluse le creature fatte d'acqua), congela il liquido fino a una profondità di 15 cm su un'area di 9 metri di lato. Il ghiaccio dura 1 minuto. Le creature che nuotavano sulla superficie dell'acqua congelata restano intrappolate nel ghiaccio. Una creatura intrappolata può usare un'azione per effettuare una prova di Forza contro la CD del tiro salvezza degli incantesimi dell'incantatore per liberarsi.\n\nSe lo desidera, l'incantatore può astenersi dallo scagliare il globo dopo aver completato l'incantesimo. In tal caso, nella sua mano compare un piccolo globo, grande all'incirca quanto un proiettile da fionda e fresco al tatto. In qualsiasi momento, l'incantatore o una creatura a cui ha consegnato il globo può lanciarlo (fino a una distanza di 12 metri) o scagliarlo con una fionda (fino alla gittata normale della fionda). Il globo si frantuma all'impatto, con lo stesso effetto del lancio normale dell'incantesimo. L'incantatore può anche posare il globo senza frantumarlo. Dopo 1 minuto, se non si è già frantumato, il globo esplode.",
					HigherLevels = "Quando l'incantatore lancia questo incantesimo usando uno slot incantesimo di 7° livello o superiore, i danni aumentano di 1d6 per ogni livello dello slot superiore al 6°."
				}
			}
		};
	}
}
