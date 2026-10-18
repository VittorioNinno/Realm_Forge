using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Blink (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Blink2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "blink");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 3,
			School = SpellSchool.Transmutation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "blink", "en"),
					Language = LanguageCode.En,
					Name = "Blink",
					CastingTime = "1 action",
					Range = "Self",
					Duration = "1 minute",
					MaterialComponent = null,
					Description = "Roll a d20 at the end of each of your turns for the duration of the spell. On a roll of 11 or higher, you vanish from your current plane of existence and appear in the Ethereal Plane (the spell fails and the casting is wasted if you were already on that plane). At the start of your next turn, and when the spell ends if you are on the Ethereal Plane, you return to an unoccupied space of your choice that you can see within 10 feet of the space you vanished from. If no unoccupied space is available within that range, you appear in the nearest unoccupied space (chosen at random if more than one space is equally near). You can dismiss this spell as an action.\n\nWhile on the Ethereal Plane, you can see and hear the plane you originated from, which is cast in shades of gray, and you can't see anything there more than 60 feet away. You can only affect and be affected by other creatures on the Ethereal Plane. Creatures that aren't there can't perceive you or interact with you, unless they have the ability to do so.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "blink", "it"),
					Language = LanguageCode.It,
					Name = "Intermittenza",
					CastingTime = "1 azione",
					Range = "Incantatore",
					Duration = "1 minuto",
					MaterialComponent = null,
					Description = "Per la durata dell'incantesimo, l'incantatore tira un d20 alla fine di ogni suo turno. Con un risultato di 11 o superiore, svanisce dal suo attuale piano di esistenza e compare nel Piano Etereo (l'incantesimo fallisce e il lancio va sprecato se si trovava già su quel piano). All'inizio del suo turno successivo, e quando l'incantesimo termina se si trova nel Piano Etereo, ritorna in uno spazio libero a sua scelta che sia in grado di vedere entro 3 metri dallo spazio da cui era svanito. Se entro quella distanza non c'è alcuno spazio libero disponibile, compare nello spazio libero più vicino (scelto casualmente se più spazi sono ugualmente vicini). L'incantatore può congedare questo incantesimo come azione.\n\nFinché si trova nel Piano Etereo, l'incantatore può vedere e sentire il piano da cui proviene, che appare in sfumature di grigio, e non può vedere nulla che si trovi a più di 18 metri di distanza. Può influenzare soltanto le altre creature presenti nel Piano Etereo ed essere influenzato soltanto da esse. Le creature che non si trovano lì non possono percepirlo né interagire con lui, a meno che non ne abbiano la capacità.",
					HigherLevels = null
				}
			}
		};
	}
}
