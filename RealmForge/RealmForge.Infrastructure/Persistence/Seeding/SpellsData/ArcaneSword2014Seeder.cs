using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Arcane Sword (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class ArcaneSword2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "arcane-sword");

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
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "arcane-sword", "en"),
					Language = LanguageCode.En,
					Name = "Arcane Sword",
					CastingTime = "1 action",
					Range = "60 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = "a miniature platinum sword with a grip and pommel of copper and zinc, worth 250 gp",
					Description = "You create a sword-shaped plane of force that hovers within range. It lasts for the duration.\n\nWhen the sword appears, you make a melee spell attack against a target of your choice within 5 feet of the sword. On a hit, the target takes 3d10 force damage. Until the spell ends, you can use a bonus action on each of your turns to move the sword up to 20 feet to a spot you can see and repeat this attack against the same target or a different one.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "arcane-sword", "it"),
					Language = LanguageCode.It,
					Name = "Spada Arcana",
					CastingTime = "1 azione",
					Range = "18 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = "una spada di platino in miniatura con l'impugnatura e il pomolo di rame e zinco, del valore di 250 mo",
					Description = "L'incantatore crea un piano di forza a forma di spada che fluttua entro gittata. La spada dura per la durata dell'incantesimo.\n\nQuando la spada compare, l'incantatore effettua un attacco con incantesimo in mischia contro un bersaglio a sua scelta entro 1,5 metri dalla spada. Se colpisce, il bersaglio subisce 3d10 danni da forza. Finché l'incantesimo non termina, in ognuno dei suoi turni l'incantatore può usare un'azione bonus per spostare la spada di un massimo di 6 metri fino a un punto che sia in grado di vedere e ripetere l'attacco contro lo stesso bersaglio o contro un bersaglio diverso.",
					HigherLevels = null
				}
			}
		};
	}
}
