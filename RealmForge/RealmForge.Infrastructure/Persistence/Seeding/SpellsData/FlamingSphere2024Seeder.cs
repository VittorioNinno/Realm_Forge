using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Flaming Sphere (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class FlamingSphere2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "flaming-sphere");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 2,
			School = SpellSchool.Conjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Druid, SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "flaming-sphere", "en"),
					Language = LanguageCode.En,
					Name = "Flaming Sphere",
					CastingTime = "Action",
					Range = "60 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = "a ball of wax",
					Description = "You create a 5-foot-diameter sphere of fire in an unoccupied space on the ground within range. It lasts for the duration. Any creature that ends its turn within 5 feet of the sphere makes a Dexterity saving throw, taking 2d6 Fire damage on a failed save or half as much damage on a successful one.\n\nAs a Bonus Action, you can move the sphere up to 30 feet, rolling it along the ground. If you move the sphere into a creature's space, that creature makes the save against the sphere, and the sphere stops moving for the turn.\n\nWhen you move the sphere, you can direct it over barriers up to 5 feet tall and jump it across pits up to 10 feet wide. Flammable objects that aren't being worn or carried start burning if touched by the sphere, and it sheds Bright Light in a 20-foot radius and Dim Light for an additional 20 feet.",
					HigherLevels = "The damage increases by 1d6 for each spell slot level above 2."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "flaming-sphere", "it"),
					Language = LanguageCode.It,
					Name = "Sfera Infuocata",
					CastingTime = "Azione",
					Range = "18 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = "una pallina di cera",
					Description = "L'incantatore crea una sfera di fuoco del diametro di 1,5 metri in uno spazio libero sul terreno entro gittata. La sfera permane per la durata. Qualsiasi creatura che termina il proprio turno entro 1,5 metri dalla sfera effettua un tiro salvezza su Destrezza, subendo 2d6 danni da fuoco se lo fallisce, o la metà di quei danni se lo supera.\n\nCome azione bonus, l'incantatore può spostare la sfera fino a 9 metri, facendola rotolare sul terreno. Se sposta la sfera nello spazio di una creatura, quella creatura effettua il tiro salvezza contro la sfera e la sfera smette di muoversi per quel turno.\n\nQuando sposta la sfera, l'incantatore può dirigerla oltre barriere alte fino a 1,5 metri e farla saltare oltre fosse larghe fino a 3 metri. Gli oggetti infiammabili che non sono indossati o trasportati prendono fuoco se toccati dalla sfera, che proietta luce intensa in un raggio di 6 metri e luce fioca per altri 6 metri.",
					HigherLevels = "I danni aumentano di 1d6 per ogni livello dello slot incantesimo superiore al 2°."
				}
			}
		};
	}
}
