using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Minor Illusion (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class MinorIllusion2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "minor-illusion");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 0,
			School = SpellSchool.Illusion,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Sorcerer, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = false,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "minor-illusion", "en"),
					Language = LanguageCode.En,
					Name = "Minor Illusion",
					CastingTime = "1 action",
					Range = "30 feet",
					Duration = "1 minute",
					MaterialComponent = "a bit of fleece",
					Description = "You create a sound or an image of an object within range that lasts for the duration. The illusion also ends if you dismiss it as an action or cast this spell again.\n\nIf you create a sound, its volume can range from a whisper to a scream. It can be your voice, someone else's voice, a lion's roar, a beating of drums, or any other sound you choose. The sound continues unabated throughout the duration, or you can make discrete sounds at different times before the spell ends.\n\nIf you create an image of an object—such as a chair, muddy footprints, or a small chest—it must be no larger than a 5-foot cube. The image can't create sound, light, smell, or any other sensory effect. Physical interaction with the image reveals it to be an illusion, because things can pass through it.\n\nIf a creature uses its action to examine the sound or image, the creature can determine that it is an illusion with a successful Intelligence (Investigation) check against your spell save DC. If a creature discerns the illusion for what it is, the illusion becomes faint to the creature.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "minor-illusion", "it"),
					Language = LanguageCode.It,
					Name = "Illusione Minore",
					CastingTime = "1 azione",
					Range = "9 metri",
					Duration = "1 minuto",
					MaterialComponent = "un po' di vello",
					Description = "L'incantatore crea un suono o l'immagine di un oggetto entro gittata, che dura per la durata. L'illusione termina anche se l'incantatore la congeda come azione o lancia di nuovo questo incantesimo.\n\nSe crea un suono, il suo volume può variare da un sussurro a un urlo. Può essere la voce dell'incantatore, la voce di qualcun altro, il ruggito di un leone, un rullo di tamburi o qualsiasi altro suono a sua scelta. Il suono prosegue senza interruzioni per tutta la durata, oppure l'incantatore può produrre suoni distinti in momenti diversi prima che l'incantesimo termini.\n\nSe crea l'immagine di un oggetto, come una sedia, delle impronte fangose o un piccolo scrigno, questa non può essere più grande di un cubo con spigolo di 1,5 metri. L'immagine non può produrre suoni, luce, odori o altri effetti sensoriali. L'interazione fisica con l'immagine rivela che si tratta di un'illusione, perché le cose possono attraversarla.\n\nSe una creatura usa la sua azione per esaminare il suono o l'immagine, può capire che si tratta di un'illusione superando una prova di Intelligenza (Indagare) contro la CD del tiro salvezza degli incantesimi dell'incantatore. Se una creatura riconosce l'illusione per ciò che è, l'illusione diventa tenue per quella creatura.",
					HigherLevels = null
				}
			}
		};
	}
}
