using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Demiplane (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Demiplane2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "demiplane");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 8,
			School = SpellSchool.Conjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = false,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "demiplane", "en"),
					Language = LanguageCode.En,
					Name = "Demiplane",
					CastingTime = "1 action",
					Range = "60 feet",
					Duration = "1 hour",
					MaterialComponent = null,
					Description = "You create a shadowy door on a flat solid surface that you can see within range. The door is large enough to allow Medium creatures to pass through unhindered. When opened, the door leads to a demiplane that appears to be an empty room 30 feet in each dimension, made of wood or stone. When the spell ends, the door disappears, and any creatures or objects inside the demiplane remain trapped there, as the door also disappears from the other side.\n\nEach time you cast this spell, you can create a new demiplane, or have the shadowy door connect to a demiplane you created with a previous casting of this spell. Additionally, if you know the nature and contents of a demiplane created by a casting of this spell by another creature, you can have the shadowy door connect to its demiplane instead.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "demiplane", "it"),
					Language = LanguageCode.It,
					Name = "Semipiano",
					CastingTime = "1 azione",
					Range = "18 metri",
					Duration = "1 ora",
					MaterialComponent = null,
					Description = "L'incantatore crea una porta d'ombra su una superficie solida e piana entro gittata che sia in grado di vedere. La porta è abbastanza grande da permettere a creature di taglia Media di attraversarla senza impedimenti. Una volta aperta, la porta conduce a un semipiano che ha l'aspetto di una stanza vuota di 9 metri per ogni dimensione, fatta di legno o di pietra. Quando l'incantesimo termina, la porta scompare e tutte le creature o gli oggetti che si trovano all'interno del semipiano vi restano intrappolati, poiché la porta scompare anche dall'altro lato.\n\nOgni volta che lancia questo incantesimo, l'incantatore può creare un nuovo semipiano, oppure collegare la porta d'ombra a un semipiano creato con un lancio precedente di questo incantesimo. Inoltre, se conosce la natura e il contenuto di un semipiano creato da un'altra creatura con questo incantesimo, può collegare invece la porta d'ombra a quel semipiano.",
					HigherLevels = null
				}
			}
		};
	}
}
