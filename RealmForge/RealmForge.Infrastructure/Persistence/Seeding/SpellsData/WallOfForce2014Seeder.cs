using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Wall of Force (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class WallOfForce2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "wall-of-force");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 5,
			School = SpellSchool.Evocation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "wall-of-force", "en"),
					Language = LanguageCode.En,
					Name = "Wall of Force",
					CastingTime = "1 action",
					Range = "120 feet",
					Duration = "Concentration, up to 10 minutes",
					MaterialComponent = "a pinch of powder made by crushing a clear gemstone",
					Description = "An invisible wall of force springs into existence at a point you choose within range. The wall appears in any orientation you choose, as a horizontal or vertical barrier or at an angle. It can be free floating or resting on a solid surface. You can form it into a hemispherical dome or a sphere with a radius of up to 10 feet, or you can shape a flat surface made up of ten 10-foot-by-10-foot panels. Each panel must be contiguous with another panel. In any form, the wall is 1/4 inch thick. It lasts for the duration. If the wall cuts through a creature's space when it appears, the creature is pushed to one side of the wall (your choice which side).\n\nNothing can physically pass through the wall. It is immune to all damage and can't be dispelled by dispel magic. A disintegrate spell destroys the wall instantly, however. The wall also extends into the Ethereal Plane, blocking ethereal travel through the wall.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "wall-of-force", "it"),
					Language = LanguageCode.It,
					Name = "Muro di Forza",
					CastingTime = "1 azione",
					Range = "36 metri",
					Duration = "Concentrazione, fino a 10 minuti",
					MaterialComponent = "un pizzico di polvere ottenuta frantumando una gemma trasparente",
					Description = "Un muro di forza invisibile si materializza in un punto entro gittata scelto dall'incantatore. Il muro compare con l'orientamento scelto dall'incantatore, come barriera orizzontale o verticale oppure inclinata. Può fluttuare liberamente o poggiare su una superficie solida. L'incantatore può dargli la forma di una cupola semisferica o di una sfera con un raggio massimo di 3 metri, oppure modellare una superficie piana composta da dieci pannelli di 3 metri per 3 metri. Ogni pannello deve essere adiacente a un altro pannello. In qualsiasi forma, il muro è spesso 6 mm. Dura per la durata. Se, quando compare, il muro attraversa lo spazio di una creatura, la creatura viene spinta su uno dei lati del muro (a scelta dell'incantatore).\n\nNulla può attraversare fisicamente il muro. Il muro è immune a tutti i danni e non può essere dissolto da dissolvi magie. Un incantesimo disintegrazione, tuttavia, distrugge il muro all'istante. Il muro si estende anche nel Piano Etereo, bloccando i viaggi eterei attraverso di esso.",
					HigherLevels = null
				}
			}
		};
	}
}
