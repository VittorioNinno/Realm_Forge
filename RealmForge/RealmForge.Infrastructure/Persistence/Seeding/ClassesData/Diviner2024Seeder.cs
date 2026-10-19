using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Diviner (wizard, 2024 ruleset). Not in the SRD: names and mechanics as in the rules, with descriptions written for RealmForge in English and Italian.
///	</summary>
public static class Diviner2024Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "diviner");

	public static Subclass Build()
	{
		return new Subclass
		{
			Id = SubclassId,
			CharacterClassId = Wizard2024Seeder.ClassId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			CasterProgression = CasterProgression.None,
			SpellcastingAbility = null,
			Translations = new List<SubclassTranslation>
			{
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "diviner", "en"), Language = LanguageCode.En, Name = "Diviner", Description = "People seek out a Diviner when they want to see the past, the present and the future more clearly. As a Diviner, you work to lift the veils of space, time and thought, mastering spells of insight, far sight, hidden knowledge and prophecy." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "diviner", "it"), Language = LanguageCode.It, Name = "Divinatore", Description = "Ci si rivolge a un divinatore quando si vuole vedere con maggiore chiarezza il passato, il presente e il futuro. Il divinatore si sforza di sollevare i veli dello spazio, del tempo e della coscienza, padroneggiando incantesimi di discernimento, visione a distanza, conoscenza nascosta e profezia." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "diviner/divination-savant"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "diviner/divination-savant", "en"), Language = LanguageCode.En, Name = "Divination Savant", Description = "Pick two Wizard spells of the Divination school, each no higher than level 2, and copy them into your spellbook at no cost.\n\nAlso, each time you unlock a new level of spell slots in this class, you can add one Divination Wizard spell of a level you have slots for to your spellbook at no cost." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "diviner/divination-savant", "it"), Language = LanguageCode.It, Name = "Divinatore Sapiente", Description = "Il mago sceglie due incantesimi da mago della scuola di divinazione, ognuno di livello non superiore al 2°, e li aggiunge gratuitamente al suo libro degli incantesimi.\n\nInoltre, ogni volta che ottiene accesso a un nuovo livello di slot incantesimo in questa classe, può aggiungere gratuitamente al libro un incantesimo da mago della scuola di divinazione, di un livello per cui possiede slot incantesimo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "diviner/portent"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "diviner/portent", "en"), Language = LanguageCode.En, Name = "Portent", Description = "Flashes of what is to come begin to crowd your mind. After each Long Rest, roll two d20s and note the results. You can swap any D20 Test made by you or by a creature you can see for one of these foretold numbers, as long as you decide before the roll and do so no more than once per turn.\n\nEach foretold number can be used only once, and any you haven't used are lost when you finish a Long Rest." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "diviner/portent", "it"), Language = LanguageCode.It, Name = "Portento", Description = "Barlumi del futuro iniziano a farsi strada nella coscienza del mago. Ogni volta che completa un riposo lungo, tira due d20 e ne annota i risultati. Può sostituire con uno di questi tiri profetici qualsiasi prova del d20 effettuata da lui o da una creatura che è in grado di vedere, purché lo decida prima del tiro e non più di una volta per turno.\n\nOgni tiro profetico può essere usato una sola volta, e quelli non usati vanno persi quando il mago completa un riposo lungo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "diviner/expert-divination"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 6,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "diviner/expert-divination", "en"), Language = LanguageCode.En, Name = "Expert Divination", Description = "Divination magic comes so easily to you that it barely taxes your reserves. When you cast a Divination spell with a level 2+ spell slot, you regain one expended spell slot of a lower level than the one you used, and no higher than level 5." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "diviner/expert-divination", "it"), Language = LanguageCode.It, Name = "Divinazione Esperta", Description = "Lanciare incantesimi di divinazione è così naturale per il mago da richiedergli solo una frazione delle sue energie. Quando lancia un incantesimo di divinazione usando uno slot di 2° livello o superiore, recupera uno slot incantesimo speso, di livello inferiore a quello usato e non superiore al 5°." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "diviner/the-third-eye"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 10,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "diviner/the-third-eye", "en"), Language = LanguageCode.En, Name = "The Third Eye", Description = "You can sharpen your senses. As a Bonus Action, pick one of these benefits, which lasts until you begin a Short or Long Rest; you can't use this feature again until you finish a Short or Long Rest.\n\n**Darkvision.** Your eyes pierce the dark out to 120 feet, as Darkvision.\n\n**Greater Comprehension.** Every written language is legible to you.\n\n**See Invisibility.** *See Invisibility* is yours to cast with no spell slot required." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "diviner/the-third-eye", "it"), Language = LanguageCode.It, Name = "Terzo Occhio", Description = "Il mago può affinare le sue capacità di percezione. Come azione bonus, sceglie uno dei benefici seguenti, che dura finché non inizia un riposo breve o lungo; non può usare di nuovo questo privilegio finché non completa un riposo breve o lungo.\n\n**Scurovisione.** Il mago ottiene scurovisione con un raggio di 36 metri.\n\n**Comprensione superiore.** Il mago è in grado di leggere qualsiasi lingua.\n\n**Vedere invisibilità.** Il mago può lanciare *vedere invisibilità* senza spendere uno slot incantesimo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "diviner/greater-portent"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 14,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "diviner/greater-portent", "en"), Language = LanguageCode.En, Name = "Greater Portent", Description = "The visions in your dreams grow sharper, showing you more of what lies ahead: you roll three d20s for Portent instead of two." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "diviner/greater-portent", "it"), Language = LanguageCode.It, Name = "Portento Superiore", Description = "Le visioni nei sogni del mago si fanno più intense e gli dipingono un quadro più preciso di ciò che verrà: per il privilegio Portento tira tre d20 anziché due." }
					}
				}
			}
		};
	}
}
