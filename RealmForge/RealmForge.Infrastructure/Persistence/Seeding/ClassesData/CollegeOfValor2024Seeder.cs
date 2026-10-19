using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	College of Valor (bard, 2024 ruleset). Not in the SRD: names and mechanics as in the rules, with descriptions written for RealmForge in English and Italian.
///	</summary>
public static class CollegeOfValor2024Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "college-of-valor");

	public static Subclass Build()
	{
		return new Subclass
		{
			Id = SubclassId,
			CharacterClassId = Bard2024Seeder.ClassId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			CasterProgression = CasterProgression.None,
			SpellcastingAbility = null,
			Translations = new List<SubclassTranslation>
			{
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "college-of-valor", "en"), Language = LanguageCode.En, Name = "College of Valor", Description = "Bards of the College of Valor keep the great heroes of the past alive in their stories. They sing of mighty deeds in grand halls and around roaring bonfires, travel to see history unfold with their own eyes, and use their songs to push a new generation toward the same glory." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "college-of-valor", "it"), Language = LanguageCode.It, Name = "Collegio del Valore", Description = "I bardi del Collegio del Valore mantengono vivi nei loro racconti i grandi eroi del passato. Cantano imprese leggendarie nelle sale dei castelli e attorno a grandi falò, viaggiano per assistere di persona agli eventi della storia e con le loro canzoni spingono una nuova generazione verso la stessa gloria." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "college-of-valor/combat-inspiration"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "college-of-valor/combat-inspiration", "en"), Language = LanguageCode.En, Name = "Combat Inspiration", Description = "Your quick wit can turn a fight around. A creature holding one of your Bardic Inspiration dice can spend it on one of these effects.\n\n**Defense.** When an attack roll hits the creature, it can use its Reaction to roll the Bardic Inspiration die and add the result to its AC against that attack, which might make the attack miss.\n\n**Offense.** Right after the creature hits a target with an attack roll, it can roll the Bardic Inspiration die and add the result to that attack's damage against the target." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "college-of-valor/combat-inspiration", "it"), Language = LanguageCode.It, Name = "Ispirazione in Combattimento", Description = "Il bardo sa usare il suo ingegno per cambiare le sorti di una battaglia. Una creatura che possiede un suo dado di Ispirazione bardica può usarlo per uno degli effetti seguenti.\n\n**Difesa.** Quando viene colpita da un tiro per colpire, la creatura può usare la propria reazione per tirare il dado di Ispirazione bardica e sommare il risultato alla propria CA contro quell'attacco, con la possibilità di farlo mancare.\n\n**Offesa.** Subito dopo aver colpito un bersaglio con un tiro per colpire, la creatura può tirare il dado di Ispirazione bardica e sommare il risultato ai danni dell'attacco contro quel bersaglio." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "college-of-valor/martial-training"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "college-of-valor/martial-training", "en"), Language = LanguageCode.En, Name = "Martial Training", Description = "You become proficient with Martial weapons and gain training with Medium armor and Shields.\n\nYou can also cast the spells of your Bard spell list using a Simple or Martial weapon as your Spellcasting Focus." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "college-of-valor/martial-training", "it"), Language = LanguageCode.It, Name = "Addestramento Marziale", Description = "Il bardo ottiene competenza nelle armi da guerra e addestramento nelle armature medie e negli scudi.\n\nInoltre, può usare un'arma semplice o da guerra come focus da incantatore per lanciare gli incantesimi della sua lista degli incantesimi da bardo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "college-of-valor/extra-attack"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 6,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "college-of-valor/extra-attack", "en"), Language = LanguageCode.En, Name = "Extra Attack", Description = "Whenever you take the Attack action on your turn, you make two attacks rather than one.\n\nYou can also swap one of those attacks for casting one of your cantrips whose casting time is an action." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "college-of-valor/extra-attack", "it"), Language = LanguageCode.It, Name = "Attacco Extra", Description = "Ogni volta che sceglie l'azione di Attacco nel proprio turno, il bardo effettua due attacchi invece di uno.\n\nInoltre, al posto di uno di quegli attacchi può lanciare uno dei suoi trucchetti che ha un tempo di lancio di un'azione." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "college-of-valor/battle-magic"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 14,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "college-of-valor/battle-magic", "en"), Language = LanguageCode.En, Name = "Battle Magic", Description = "Once you have cast a spell whose casting time is an action, you can use a Bonus Action to make one weapon attack." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "college-of-valor/battle-magic", "it"), Language = LanguageCode.It, Name = "Magia da Combattimento", Description = "Quando il bardo ha appena lanciato un incantesimo che richiede un'azione, può usare un'azione bonus per sferrare un attacco con un'arma." }
					}
				}
			}
		};
	}
}
