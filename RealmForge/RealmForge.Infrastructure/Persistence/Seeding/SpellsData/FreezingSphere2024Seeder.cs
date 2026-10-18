using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Freezing Sphere (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class FreezingSphere2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "freezing-sphere");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 6,
			School = SpellSchool.Evocation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "freezing-sphere", "en"),
					Language = LanguageCode.En,
					Name = "Freezing Sphere",
					CastingTime = "Action",
					Range = "300 feet",
					Duration = "Instantaneous",
					MaterialComponent = "a miniature crystal sphere",
					Description = "A frigid globe streaks from you to a point of your choice within range, where it explodes in a 60-foot-radius Sphere. Each creature in that area makes a Constitution saving throw, taking 10d6 Cold damage on failed save or half as much damage on a successful one.\n\nIf the globe strikes a body of water, it freezes the water to a depth of 6 inches over an area 30 feet square. This ice lasts for 1 minute. Creatures that were swimming on the surface of frozen water are trapped in the ice and have the Restrained condition. A trapped creature can take an action to make a Strength (Athletics) check against your spell save DC to break free.\n\nYou can refrain from firing the globe after completing the spell's casting. If you do so, a globe about the size of a sling bullet, cool to the touch, appears in your hand. At any time, you or a creature you give the globe to can throw the globe (to a range of 40 feet) or hurl it with a sling (to the sling's normal range). It shatters on impact, with the same effect as a normal casting of the spell. You can also set the globe down without shattering it. After 1 minute, if the globe hasn't already shattered, it explodes.",
					HigherLevels = "The damage increases by 1d6 for each spell slot level above 6."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "freezing-sphere", "it"),
					Language = LanguageCode.It,
					Name = "Sfera Congelante",
					CastingTime = "Azione",
					Range = "90 metri",
					Duration = "Istantanea",
					MaterialComponent = "una sfera di cristallo in miniatura",
					Description = "Un globo gelido sfreccia dall'incantatore verso un punto a sua scelta entro gittata, dove esplode in una sfera del raggio di 18 metri. Ogni creatura in quell'area effettua un tiro salvezza su Costituzione, subendo 10d6 danni da freddo se lo fallisce, o la metà di quei danni se lo supera.\n\nSe il globo colpisce una distesa d'acqua, congela l'acqua fino a una profondità di 15 centimetri su un'area quadrata di 9 metri di lato. Questo ghiaccio dura 1 minuto. Le creature che stavano nuotando sulla superficie dell'acqua congelata rimangono intrappolate nel ghiaccio e sono trattenute. Una creatura intrappolata può effettuare un'azione per compiere una prova di Forza (Atletica) contro la CD del tiro salvezza degli incantesimi dell'incantatore per liberarsi.\n\nDopo aver completato il lancio dell'incantesimo, l'incantatore può astenersi dallo scagliare il globo. In tal caso, nella sua mano compare un globo grande all'incirca quanto un proiettile da fionda, freddo al tatto. In qualsiasi momento, l'incantatore o una creatura a cui ha dato il globo può lanciarlo (fino a una distanza di 12 metri) o scagliarlo con una fionda (fino alla gittata normale della fionda). Il globo si frantuma all'impatto, con lo stesso effetto di un normale lancio dell'incantesimo. L'incantatore può anche posare il globo senza frantumarlo. Dopo 1 minuto, se il globo non si è già frantumato, esplode.",
					HigherLevels = "I danni aumentano di 1d6 per ogni livello dello slot incantesimo superiore al 6°."
				}
			}
		};
	}
}
