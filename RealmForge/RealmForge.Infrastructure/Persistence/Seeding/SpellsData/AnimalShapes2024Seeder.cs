using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Animal Shapes (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class AnimalShapes2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "animal-shapes");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 8,
			School = SpellSchool.Transmutation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Druid },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "animal-shapes", "en"),
					Language = LanguageCode.En,
					Name = "Animal Shapes",
					CastingTime = "Action",
					Range = "30 feet",
					Duration = "24 hours",
					MaterialComponent = null,
					Description = "Choose any number of willing creatures that you can see within range. Each target shape-shifts into a Large or smaller Beast of your choice that has a Challenge Rating of 4 or lower. You can choose a different form for each target. On later turns, you can take a Magic action to transform the targets again.\n\nA target's game statistics are replaced by the chosen Beast's statistics, but the target retains its creature type; Hit Points; Hit Point Dice; alignment; ability to communicate; and Intelligence, Wisdom, and Charisma scores. The target's actions are limited by the Beast form's anatomy, and it can't cast spells. The target's equipment melds into the new form, and the target can't use any of that equipment while in that form.\n\nThe target gains a number of Temporary Hit Points equal to the Hit Points of the first form into which it shape-shifts. These Temporary Hit Points vanish if any remain when the spell ends. The transformation lasts for the duration or until the target ends it as a Bonus Action.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "animal-shapes", "it"),
					Language = LanguageCode.It,
					Name = "Forme Animali",
					CastingTime = "Azione",
					Range = "9 metri",
					Duration = "24 ore",
					MaterialComponent = null,
					Description = "L'incantatore sceglie un qualsiasi numero di creature consenzienti entro gittata che è in grado di vedere. Ogni bersaglio si trasforma in una bestia di taglia Grande o inferiore, a scelta dell'incantatore, con un Grado di Sfida pari o inferiore a 4. L'incantatore può scegliere una forma diversa per ogni bersaglio. Nei turni successivi, può effettuare un'azione di Magia per trasformare di nuovo i bersagli.\n\nLe statistiche di gioco di un bersaglio sono sostituite da quelle della bestia scelta, ma il bersaglio mantiene il proprio tipo di creatura, i punti ferita, i Dadi Vita, l'allineamento, la capacità di comunicare e i punteggi di Intelligenza, Saggezza e Carisma. Le azioni del bersaglio sono limitate dall'anatomia della forma bestiale e il bersaglio non può lanciare incantesimi. L'equipaggiamento del bersaglio si fonde con la nuova forma e il bersaglio non può usarlo finché mantiene quella forma.\n\nIl bersaglio ottiene un numero di punti ferita temporanei pari ai punti ferita della prima forma in cui si trasforma. Gli eventuali punti ferita temporanei rimasti svaniscono quando l'incantesimo termina. La trasformazione dura per la durata o finché il bersaglio non vi pone fine con un'azione bonus.",
					HigherLevels = null
				}
			}
		};
	}
}
