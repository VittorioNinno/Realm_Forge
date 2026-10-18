using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Blink (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Blink2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "blink");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "blink", "en"),
					Language = LanguageCode.En,
					Name = "Blink",
					CastingTime = "Action",
					Range = "Self",
					Duration = "1 minute",
					MaterialComponent = null,
					Description = "Roll 1d6 at the end of each of your turns for the duration. On a roll of 4–6, you vanish from your current plane of existence and appear in the Ethereal Plane (the spell ends instantly if you are already on that plane). While on the Ethereal Plane, you can perceive the plane you left, which is cast in shades of gray, but you can't see anything there more than 60 feet away. You can affect and be affected only by other creatures on the Ethereal Plane, and creatures on the other plane can't perceive you unless they have a special ability that lets them perceive things on the Ethereal Plane.\n\nYou return to the other plane at the start of your next turn and when the spell ends if you are on the Ethereal Plane. You return to an unoccupied space of your choice that you can see within 10 feet of the space you left. If no unoccupied space is available within that range, you appear in the nearest unoccupied space.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "blink", "it"),
					Language = LanguageCode.It,
					Name = "Intermittenza",
					CastingTime = "Azione",
					Range = "Incantatore",
					Duration = "1 minuto",
					MaterialComponent = null,
					Description = "Per la durata, l'incantatore tira 1d6 alla fine di ogni suo turno. Con un risultato di 4-6, svanisce dal piano di esistenza in cui si trova e compare nel Piano Etereo (l'incantesimo termina immediatamente se si trova già su quel piano). Mentre si trova nel Piano Etereo, l'incantatore può percepire il piano che ha lasciato, che appare in sfumature di grigio, ma non può vedere nulla che si trovi a più di 18 metri di distanza. Può influenzare ed essere influenzato soltanto da altre creature che si trovano nel Piano Etereo, e le creature dell'altro piano non possono percepirlo, a meno che non dispongano di una capacità speciale che consenta loro di percepire ciò che si trova nel Piano Etereo.\n\nSe si trova nel Piano Etereo, l'incantatore ritorna all'altro piano all'inizio del suo turno successivo e quando l'incantesimo termina. Ritorna in uno spazio libero a sua scelta che è in grado di vedere entro 3 metri dallo spazio che aveva lasciato. Se entro quella distanza non c'è alcuno spazio libero disponibile, compare nello spazio libero più vicino.",
					HigherLevels = null
				}
			}
		};
	}
}
