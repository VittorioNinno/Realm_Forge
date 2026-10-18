using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Silent Image (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class SilentImage2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "silent-image");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 1,
			School = SpellSchool.Illusion,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "silent-image", "en"),
					Language = LanguageCode.En,
					Name = "Silent Image",
					CastingTime = "Action",
					Range = "60 feet",
					Duration = "Concentration, up to 10 minutes",
					MaterialComponent = "a bit of fleece",
					Description = "You create the image of an object, a creature, or some other visible phenomenon that is no larger than a 15-foot Cube. The image appears at a spot within range and lasts for the duration. The image is purely visual; it isn't accompanied by sound, smell, or other sensory effects.\n\nAs a Magic action, you can cause the image to move to any spot within range. As the image changes location, you can alter its appearance so that its movements appear natural for the image. For example, if you create an image of a creature and move it, you can alter the image so that it appears to be walking.\n\nPhysical interaction with the image reveals it to be an illusion, since things can pass through it. A creature that takes a Study action to examine the image can determine that it is an illusion with a successful Intelligence (Investigation) check against your spell save DC. If a creature discerns the illusion for what it is, the creature can see through the image.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "silent-image", "it"),
					Language = LanguageCode.It,
					Name = "Immagine Silenziosa",
					CastingTime = "Azione",
					Range = "18 metri",
					Duration = "Concentrazione, fino a 10 minuti",
					MaterialComponent = "un pezzetto di vello",
					Description = "L'incantatore crea l'immagine di un oggetto, di una creatura o di qualche altro fenomeno visibile che non sia più grande di un cubo con spigolo di 4,5 metri. L'immagine compare in un punto entro gittata e permane per la durata. L'immagine è puramente visiva: non è accompagnata da suoni, odori o altri effetti sensoriali.\n\nCome azione di Magia, l'incantatore può spostare l'immagine in qualsiasi punto entro gittata. Mentre l'immagine cambia posizione, può alterarne l'aspetto in modo che i suoi movimenti sembrino naturali. Per esempio, se crea l'immagine di una creatura e la sposta, può alterare l'immagine in modo che sembri camminare.\n\nL'interazione fisica con l'immagine rivela che si tratta di un'illusione, perché le cose possono attraversarla. Una creatura che effettua l'azione di Studio per esaminare l'immagine può capire che si tratta di un'illusione superando una prova di Intelligenza (Indagare) contro la CD del tiro salvezza degli incantesimi dell'incantatore. Se una creatura riconosce l'illusione per ciò che è, può vedere attraverso l'immagine.",
					HigherLevels = null
				}
			}
		};
	}
}
