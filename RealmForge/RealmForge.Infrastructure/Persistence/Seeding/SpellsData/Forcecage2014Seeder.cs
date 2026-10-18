using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Forcecage (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Forcecage2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "forcecage");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 7,
			School = SpellSchool.Evocation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "forcecage", "en"),
					Language = LanguageCode.En,
					Name = "Forcecage",
					CastingTime = "1 action",
					Range = "100 feet",
					Duration = "1 hour",
					MaterialComponent = "ruby dust worth 1,500 gp",
					Description = "An immobile, invisible, cube-shaped prison composed of magical force springs into existence around an area you choose within range. The prison can be a cage or a solid box, as you choose.\n\nA prison in the shape of a cage can be up to 20 feet on a side and is made from 1/2-inch diameter bars spaced 1/2 inch apart.\n\nA prison in the shape of a box can be up to 10 feet on a side, creating a solid barrier that prevents any matter from passing through it and blocking any spells cast into or out from the area.\n\nWhen you cast the spell, any creature that is completely inside the cage's area is trapped. Creatures only partially within the area, or those too large to fit inside the area, are pushed away from the center of the area until they are completely outside the area.\n\nA creature inside the cage can't leave it by nonmagical means. If the creature tries to use teleportation or interplanar travel to leave the cage, it must first make a Charisma saving throw. On a success, the creature can use that magic to exit the cage. On a failure, the creature can't exit the cage and wastes the use of the spell or effect. The cage also extends into the Ethereal Plane, blocking ethereal travel.\n\nThis spell can't be dispelled by dispel magic.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "forcecage", "it"),
					Language = LanguageCode.It,
					Name = "Gabbia di Forza",
					CastingTime = "1 azione",
					Range = "30 metri",
					Duration = "1 ora",
					MaterialComponent = "polvere di rubino del valore di 1.500 mo",
					Description = "Una prigione immobile, invisibile e a forma di cubo, composta di forza magica, si materializza attorno a un'area entro gittata scelta dall'incantatore. La prigione può essere una gabbia o una scatola solida, a scelta dell'incantatore.\n\nUna prigione a forma di gabbia può avere uno spigolo massimo di 6 metri ed è composta da sbarre del diametro di 1,25 cm distanziate di 1,25 cm l'una dall'altra.\n\nUna prigione a forma di scatola può avere uno spigolo massimo di 3 metri e crea una barriera solida che impedisce il passaggio di qualsiasi materia e blocca qualsiasi incantesimo lanciato dentro o fuori dall'area.\n\nQuando l'incantatore lancia l'incantesimo, qualsiasi creatura che si trovi completamente all'interno dell'area della gabbia rimane intrappolata. Le creature che si trovano solo in parte nell'area, o quelle troppo grandi per entrarvi, vengono spinte lontano dal centro dell'area finché non si trovano completamente al di fuori di essa.\n\nUna creatura all'interno della gabbia non può uscirne con mezzi non magici. Se la creatura tenta di usare il teletrasporto o un viaggio interplanare per uscire dalla gabbia, deve prima effettuare un tiro salvezza su Carisma. Se lo supera, può usare quella magia per uscire dalla gabbia. Se lo fallisce, non può uscire dalla gabbia e spreca l'utilizzo dell'incantesimo o dell'effetto. La gabbia si estende anche nel Piano Etereo, bloccando i viaggi eterei.\n\nQuesto incantesimo non può essere dissolto da dissolvi magie.",
					HigherLevels = null
				}
			}
		};
	}
}
