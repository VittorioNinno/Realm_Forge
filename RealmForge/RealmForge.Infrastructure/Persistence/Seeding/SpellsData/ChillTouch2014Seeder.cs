using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Chill Touch (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class ChillTouch2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "chill-touch");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 0,
			School = SpellSchool.Necromancy,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Sorcerer, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "chill-touch", "en"),
					Language = LanguageCode.En,
					Name = "Chill Touch",
					CastingTime = "1 action",
					Range = "120 feet",
					Duration = "1 round",
					MaterialComponent = null,
					Description = "You create a ghostly, skeletal hand in the space of a creature within range. Make a ranged spell attack against the creature to assail it with the chill of the grave. On a hit, the target takes 1d8 necrotic damage, and it can't regain hit points until the start of your next turn. Until then, the hand clings to the target.\n\nIf you hit an undead target, it also has disadvantage on attack rolls against you until the end of your next turn.\n\nThis spell's damage increases by 1d8 when you reach 5th level (2d8), 11th level (3d8), and 17th level (4d8).",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "chill-touch", "it"),
					Language = LanguageCode.It,
					Name = "Tocco Gelido",
					CastingTime = "1 azione",
					Range = "36 metri",
					Duration = "1 round",
					MaterialComponent = null,
					Description = "L'incantatore crea una mano spettrale e scheletrica nello spazio di una creatura entro gittata. Effettua un attacco con incantesimo a distanza contro la creatura per assalirla con il gelo della tomba. Se colpisce, il bersaglio subisce 1d8 danni necrotici e non può recuperare punti ferita fino all'inizio del turno successivo dell'incantatore. Fino ad allora, la mano rimane aggrappata al bersaglio.\n\nSe l'incantatore colpisce un bersaglio non morto, quest'ultimo subisce anche svantaggio ai tiri per colpire contro l'incantatore fino alla fine del turno successivo dell'incantatore.\n\nI danni di questo incantesimo aumentano di 1d8 quando l'incantatore raggiunge il 5° livello (2d8), l'11° livello (3d8) e il 17° livello (4d8).",
					HigherLevels = null
				}
			}
		};
	}
}
