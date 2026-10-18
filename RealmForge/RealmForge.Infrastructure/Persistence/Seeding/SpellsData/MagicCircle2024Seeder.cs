using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Magic Circle (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class MagicCircle2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "magic-circle");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "magic-circle", "en"),
					Language = LanguageCode.En,
					Name = "Magic Circle",
					CastingTime = "1 minute",
					Range = "10 feet",
					Duration = "1 hour",
					MaterialComponent = "salt and powdered silver worth 100+ GP, which the spell consumes",
					Description = "You create a 10-foot-radius, 20-foot-tall Cylinder of magical energy centered on a point on the ground that you can see within range. Glowing runes appear wherever the Cylinder intersects with the floor or other surface.\n\nChoose one or more of the following types of creatures: Celestials, Elementals, Fey, Fiends, or Undead. The circle affects a creature of the chosen type in the following ways:\n\n- The creature can't willingly enter the Cylinder by nonmagical means. If the creature tries to use teleportation or interplanar travel to do so, it must first succeed on a Charisma saving throw.\n- The creature has Disadvantage on attack rolls against targets within the Cylinder.\n- Targets within the Cylinder can't be possessed by or gain the Charmed or Frightened condition from the creature.\n\nEach time you cast this spell, you can cause its magic to operate in the reverse direction, preventing a creature of the specified type from leaving the Cylinder and protecting targets outside it.",
					HigherLevels = "The duration increases by 1 hour for each spell slot level above 3."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "magic-circle", "it"),
					Language = LanguageCode.It,
					Name = "Cerchio Magico",
					CastingTime = "1 minuto",
					Range = "3 metri",
					Duration = "1 ora",
					MaterialComponent = "sale e argento in polvere del valore di almeno 100 mo, che l'incantesimo consuma",
					Description = "L'incantatore crea un cilindro di energia magica del raggio di 3 metri e alto 6 metri, centrato su un punto sul terreno entro gittata che è in grado di vedere. Rune luminose compaiono ovunque il cilindro intersechi il pavimento o un'altra superficie.\n\nL'incantatore sceglie uno o più dei seguenti tipi di creature: celestiali, elementali, folletti, immondi o non morti. Il cerchio influenza una creatura del tipo scelto nei modi seguenti:\n\n- La creatura non può entrare volontariamente nel cilindro con mezzi non magici. Se la creatura tenta di usare il teletrasporto o un viaggio interplanare per farlo, deve prima superare un tiro salvezza su Carisma.\n- La creatura subisce svantaggio ai tiri per colpire contro i bersagli all'interno del cilindro.\n- I bersagli all'interno del cilindro non possono essere posseduti, affascinati o spaventati dalla creatura.\n\nOgni volta che lancia questo incantesimo, l'incantatore può far funzionare la sua magia nella direzione opposta, impedendo a una creatura del tipo specificato di uscire dal cilindro e proteggendo i bersagli che si trovano all'esterno.",
					HigherLevels = "La durata aumenta di 1 ora per ogni livello dello slot incantesimo superiore al 3°."
				}
			}
		};
	}
}
