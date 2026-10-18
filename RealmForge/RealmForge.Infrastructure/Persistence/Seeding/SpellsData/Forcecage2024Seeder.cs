using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Forcecage (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Forcecage2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "forcecage");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 7,
			School = SpellSchool.Evocation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "forcecage", "en"),
					Language = LanguageCode.En,
					Name = "Forcecage",
					CastingTime = "Action",
					Range = "100 feet",
					Duration = "Concentration, up to 1 hour",
					MaterialComponent = "ruby dust worth 1,500+ GP, which the spell consumes",
					Description = "An immobile, Invisible, Cube-shaped prison composed of magical force springs into existence around an area you choose within range. The prison can be a cage or a solid box, as you choose.\n\nA prison in the shape of a cage can be up to 20 feet on a side and is made from 1/2-inch diameter bars spaced 1/2 inch apart. A prison in the shape of a box can be up to 10 feet on a side, creating a solid barrier that prevents any matter from passing through it and blocking any spells cast into or out from the area.\n\nWhen you cast the spell, any creature that is completely inside the cage's area is trapped. Creatures only partially within the area, or those too large to fit inside it, are pushed away from the center of the area until they are completely outside it.\n\nA creature inside the cage can't leave it by nonmagical means. If the creature tries to use teleportation or interplanar travel to leave, it must first make a Charisma saving throw. On a successful save, the creature can use that magic to exit the cage. On a failed save, the creature doesn't exit the cage and wastes the spell or effect. The cage also extends into the Ethereal Plane, blocking ethereal travel.\n\nThis spell can't be dispelled by *Dispel Magic*.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "forcecage", "it"),
					Language = LanguageCode.It,
					Name = "Gabbia di Forza",
					CastingTime = "Azione",
					Range = "30 metri",
					Duration = "Concentrazione, fino a 1 ora",
					MaterialComponent = "polvere di rubino del valore di almeno 1.500 mo, che l'incantesimo consuma",
					Description = "Una prigione cubica, immobile e invisibile, fatta di forza magica, prende forma attorno a un'area entro gittata a scelta dell'incantatore. La prigione può essere una gabbia o una scatola solida, a scelta dell'incantatore.\n\nUna prigione a forma di gabbia può avere un lato lungo fino a 6 metri ed è fatta di sbarre del diametro di 1,25 centimetri distanti 1,25 centimetri l'una dall'altra. Una prigione a forma di scatola può avere un lato lungo fino a 3 metri e crea una barriera solida che impedisce a qualsiasi materia di attraversarla e blocca qualsiasi incantesimo lanciato verso l'interno o verso l'esterno dell'area.\n\nQuando l'incantatore lancia l'incantesimo, qualsiasi creatura che si trova completamente all'interno dell'area della gabbia è intrappolata. Le creature che si trovano solo parzialmente nell'area, o quelle troppo grandi per entrarvi, vengono spinte lontano dal centro dell'area finché non ne sono completamente fuori.\n\nUna creatura all'interno della gabbia non può uscirne con mezzi non magici. Se la creatura tenta di usare il teletrasporto o un viaggio interplanare per uscirne, deve prima effettuare un tiro salvezza su Carisma. Se lo supera, la creatura può usare quella magia per uscire dalla gabbia. Se lo fallisce, la creatura non esce dalla gabbia e spreca l'incantesimo o l'effetto. La gabbia si estende anche nel Piano Etereo, bloccando i viaggi eterei.\n\nQuesto incantesimo non può essere dissolto da *dissolvi magie*.",
					HigherLevels = null
				}
			}
		};
	}
}
