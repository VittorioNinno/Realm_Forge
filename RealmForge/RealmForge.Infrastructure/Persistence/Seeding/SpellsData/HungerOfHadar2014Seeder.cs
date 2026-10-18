using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Hunger of Hadar (2014 ruleset). Not part of SRD 5.1: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class HungerOfHadar2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "hunger-of-hadar");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			Level = 3,
			School = SpellSchool.Conjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Warlock },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "hunger-of-hadar", "en"),
					Language = LanguageCode.En,
					Name = "Hunger of Hadar",
					CastingTime = "1 action",
					Range = "150 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = "a pickled octopus tentacle",
					Description = "You tear open a passage to the dark void between the stars, a realm haunted by unknown horrors. A 20-foot-radius sphere of blackness and bitter cold appears, centered on a point within range, and lasts for the duration. Faint whispers and wet, slurping sounds echo from the void and can be heard up to 30 feet away. No light, magical or otherwise, can illuminate the area, and a creature fully inside it is blinded.\n\nThe void warps space around it, making the area difficult terrain. A creature that starts its turn in the area takes 2d6 cold damage. A creature that ends its turn there must succeed on a Dexterity saving throw or take 2d6 acid damage as pale, otherworldly tentacles brush against it.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "hunger-of-hadar", "it"),
					Language = LanguageCode.It,
					Name = "Fame di Hadar",
					CastingTime = "1 azione",
					Range = "45 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = "un tentacolo di piovra sotto aceto",
					Description = "L'incantatore squarcia un passaggio verso il vuoto oscuro tra le stelle, un regno infestato da orrori sconosciuti. Una sfera di oscurità e di freddo pungente del raggio di 6 metri compare centrata su un punto entro gittata e dura per la durata. Dal vuoto provengono deboli sussurri e rumori umidi di risucchio, udibili fino a 9 metri di distanza. Nessuna luce, magica o meno, può illuminare l'area, e una creatura che si trova interamente al suo interno è accecata.\n\nIl vuoto deforma lo spazio circostante, rendendo l'area terreno difficile. Una creatura che inizia il proprio turno nell'area subisce 2d6 danni da freddo. Una creatura che vi termina il proprio turno deve superare un tiro salvezza su Destrezza, altrimenti subisce 2d6 danni da acido, mentre pallidi tentacoli ultraterreni la sfiorano.",
					HigherLevels = null
				}
			}
		};
	}
}
