using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Demiplane (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Demiplane2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "demiplane");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 8,
			School = SpellSchool.Conjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Sorcerer, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = false,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "demiplane", "en"),
					Language = LanguageCode.En,
					Name = "Demiplane",
					CastingTime = "Action",
					Range = "60 feet",
					Duration = "1 hour",
					MaterialComponent = null,
					Description = "You create a shadowy Medium door on a flat solid surface that you can see within range. This door can be opened and closed, and it leads to a demiplane that is an empty room 30 feet in each dimension, made of wood or stone (your choice).\n\nWhen the spell ends, the door vanishes, and any objects inside the demiplane remain there. Any creatures inside also remain unless they opt to be shunted through the door as it vanishes, landing with the Prone condition in the unoccupied spaces closest to the door's former space.\n\nEach time you cast this spell, you can create a new demiplane or connect the shadowy door to a demiplane you created with a previous casting of this spell. Additionally, if you know the nature and contents of a demiplane created by a casting of this spell by another creature, you can connect the shadowy door to that demiplane instead.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "demiplane", "it"),
					Language = LanguageCode.It,
					Name = "Semipiano",
					CastingTime = "Azione",
					Range = "18 metri",
					Duration = "1 ora",
					MaterialComponent = null,
					Description = "L'incantatore crea una porta ombrosa di taglia Media su una superficie solida e piatta entro gittata che è in grado di vedere. Questa porta può essere aperta e chiusa e conduce a un semipiano costituito da una stanza vuota di 9 metri per ogni dimensione, fatta di legno o di pietra (a scelta dell'incantatore).\n\nQuando l'incantesimo termina, la porta svanisce e gli eventuali oggetti all'interno del semipiano vi rimangono. Anche le eventuali creature all'interno vi rimangono, a meno che non scelgano di essere spinte fuori attraverso la porta mentre svanisce, ritrovandosi prone negli spazi liberi più vicini al punto in cui si trovava la porta.\n\nOgni volta che lancia questo incantesimo, l'incantatore può creare un nuovo semipiano o collegare la porta ombrosa a un semipiano creato con un precedente lancio di questo incantesimo. Inoltre, se conosce la natura e il contenuto di un semipiano creato da un'altra creatura con questo incantesimo, può invece collegare la porta ombrosa a quel semipiano.",
					HigherLevels = null
				}
			}
		};
	}
}
