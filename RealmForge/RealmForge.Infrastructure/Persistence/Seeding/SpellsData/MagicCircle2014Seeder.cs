using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Magic Circle (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class MagicCircle2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "magic-circle");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 3,
			School = SpellSchool.Abjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric, SpellcastingClass.Paladin, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "magic-circle", "en"),
					Language = LanguageCode.En,
					Name = "Magic Circle",
					CastingTime = "1 minute",
					Range = "10 feet",
					Duration = "1 hour",
					MaterialComponent = "holy water or powdered silver and iron worth at least 100 gp, which the spell consumes",
					Description = "You create a 10-foot radius, 20-foot-tall cylinder of magical energy centered on a point on the ground that you can see within range. Glowing runes appear whenever the cylinder intersects with the floor or other surface.\n\nChoose one or more of the following types of creatures: celestials, elementals, fey, fiends, or undead. The circle affects a creature of the chosen type in the following ways:\n\n- The creature can't willingly enter the cylinder by nonmagical means. If the creature tries to use teleportation or interplanar travel to do so, it must first succeed on a Charisma saving throw.\n\n- The creature has disadvantage on attack rolls against targets within the cylinder.\n\n- Targets within the cylinder can't be charmed, frightened, or possessed by the creature.\n\nWhen you cast this spell, you can elect to cause its magic to operate in the reverse direction, preventing a creature of the specified type from leaving the cylinder and protecting targets outside it.",
					HigherLevels = "When you cast this spell using a spell slot of 4th level or higher, the duration increases by 1 hour for each slot level above 3rd."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "magic-circle", "it"),
					Language = LanguageCode.It,
					Name = "Cerchio Magico",
					CastingTime = "1 minuto",
					Range = "3 metri",
					Duration = "1 ora",
					MaterialComponent = "acqua santa oppure polvere d'argento e di ferro del valore di almeno 100 mo, che l'incantesimo consuma",
					Description = "L'incantatore crea un cilindro di energia magica del raggio di 3 metri e alto 6 metri, centrato su un punto del terreno entro gittata che sia in grado di vedere. Delle rune luminose compaiono ovunque il cilindro intersechi il pavimento o un'altra superficie.\n\nL'incantatore sceglie uno o più dei tipi di creature seguenti: celestiali, elementali, folletti, immondi o non morti. Il cerchio influenza una creatura del tipo scelto nei modi seguenti:\n\n- La creatura non può entrare volontariamente nel cilindro con mezzi non magici. Se tenta di farlo usando il teletrasporto o un viaggio interplanare, deve prima superare un tiro salvezza su Carisma.\n\n- La creatura subisce svantaggio ai tiri per colpire contro i bersagli all'interno del cilindro.\n\n- I bersagli all'interno del cilindro non possono essere affascinati, spaventati o posseduti dalla creatura.\n\nQuando lancia questo incantesimo, l'incantatore può decidere di far funzionare la sua magia in senso inverso, impedendo a una creatura del tipo specificato di uscire dal cilindro e proteggendo i bersagli all'esterno.",
					HigherLevels = "Quando l'incantatore lancia questo incantesimo usando uno slot incantesimo di 4° livello o superiore, la durata aumenta di 1 ora per ogni livello dello slot superiore al 3°."
				}
			}
		};
	}
}
