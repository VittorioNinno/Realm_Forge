using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Major Image (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class MajorImage2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "major-image");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 3,
			School = SpellSchool.Illusion,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Sorcerer, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "major-image", "en"),
					Language = LanguageCode.En,
					Name = "Major Image",
					CastingTime = "1 action",
					Range = "120 feet",
					Duration = "Concentration, up to 10 minutes",
					MaterialComponent = "a bit of fleece",
					Description = "You create the image of an object, a creature, or some other visible phenomenon that is no larger than a 20-foot cube. The image appears at a spot that you can see within range and lasts for the duration. It seems completely real, including sounds, smells, and temperature appropriate to the thing depicted. You can't create sufficient heat or cold to cause damage, a sound loud enough to deal thunder damage or deafen a creature, or a smell that might sicken a creature (like a troglodyte's stench).\n\nAs long as you are within range of the illusion, you can use your action to cause the image to move to any other spot within range. As the image changes location, you can alter its appearance so that its movements appear natural for the image. For example, if you create an image of a creature and move it, you can alter the image so that it appears to be walking. Similarly, you can cause the illusion to make different sounds at different times, even making it carry on a conversation, for example.\n\nPhysical interaction with the image reveals it to be an illusion, because things can pass through it. A creature that uses its action to examine the image can determine that it is an illusion with a successful Intelligence (Investigation) check against your spell save DC. If a creature discerns the illusion for what it is, the creature can see through the image, and its other sensory qualities become faint to the creature.",
					HigherLevels = "When you cast this spell using a spell slot of 6th level or higher, the spell lasts until dispelled, without requiring your concentration."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "major-image", "it"),
					Language = LanguageCode.It,
					Name = "Immagine Maggiore",
					CastingTime = "1 azione",
					Range = "36 metri",
					Duration = "Concentrazione, fino a 10 minuti",
					MaterialComponent = "un po' di vello",
					Description = "L'incantatore crea l'immagine di un oggetto, di una creatura o di un altro fenomeno visibile non più grande di un cubo con spigolo di 6 metri. L'immagine compare in un punto entro gittata che l'incantatore sia in grado di vedere e dura per la durata. Sembra del tutto reale, inclusi i suoni, gli odori e la temperatura appropriati a ciò che raffigura. L'incantatore non può creare un calore o un freddo sufficienti a infliggere danni, un suono abbastanza forte da infliggere danni da tuono o assordare una creatura, o un odore che potrebbe nauseare una creatura (come il fetore di un troglodita).\n\nFinché si trova entro la gittata dell'illusione, l'incantatore può usare la sua azione per spostare l'immagine in qualsiasi altro punto entro gittata. Mentre l'immagine cambia posizione, l'incantatore può modificarne l'aspetto in modo che i suoi movimenti appaiano naturali. Per esempio, se crea l'immagine di una creatura e la sposta, può modificarla in modo che sembri camminare. Allo stesso modo, può far emettere all'illusione suoni diversi in momenti diversi, facendole persino sostenere una conversazione, per esempio.\n\nL'interazione fisica con l'immagine rivela che si tratta di un'illusione, perché le cose possono attraversarla. Una creatura che usa la sua azione per esaminare l'immagine può capire che si tratta di un'illusione superando una prova di Intelligenza (Indagare) contro la CD del tiro salvezza degli incantesimi dell'incantatore. Se una creatura riconosce l'illusione per ciò che è, può vedere attraverso l'immagine, e le altre qualità sensoriali dell'immagine diventano tenui per quella creatura.",
					HigherLevels = "Quando l'incantatore lancia questo incantesimo usando uno slot incantesimo di 6° livello o superiore, l'incantesimo dura finché non viene dissolto, senza richiedere la concentrazione dell'incantatore."
				}
			}
		};
	}
}
