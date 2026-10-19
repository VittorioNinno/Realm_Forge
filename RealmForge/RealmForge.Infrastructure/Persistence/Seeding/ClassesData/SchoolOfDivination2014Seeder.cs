using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	School of Divination (wizard, 2014 ruleset). Not in the SRD: names and mechanics as in the rules, with descriptions written for RealmForge in English and Italian.
///	</summary>
public static class SchoolOfDivination2014Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "school-of-divination");

	public static Subclass Build()
	{
		return new Subclass
		{
			Id = SubclassId,
			CharacterClassId = Wizard2014Seeder.ClassId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			CasterProgression = CasterProgression.None,
			SpellcastingAbility = null,
			Translations = new List<SubclassTranslation>
			{
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "school-of-divination", "en"), Language = LanguageCode.En, Name = "School of Divination", Description = "Kings and commoners alike seek a diviner's counsel, for everyone wants a clearer view of the past, present and future. Diviners strive to part the veils of space, time and consciousness, specializing in spells of insight, remote viewing, hidden knowledge and foresight." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "school-of-divination", "it"), Language = LanguageCode.It, Name = "Scuola di Divinazione", Description = "Re e popolani cercano allo stesso modo il consiglio di un divinatore, perché tutti desiderano vedere più chiaramente il passato, il presente e il futuro. I divinatori si sforzano di sollevare i veli dello spazio, del tempo e della coscienza, specializzandosi negli incantesimi di intuizione, visione a distanza, conoscenza nascosta e preveggenza." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-divination/divination-savant"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 2,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-divination/divination-savant", "en"), Language = LanguageCode.En, Name = "Divination Savant", Description = "From the moment you choose this school at 2nd level, the gold and time you need to copy a divination spell into your spellbook are halved." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-divination/divination-savant", "it"), Language = LanguageCode.It, Name = "Divinatore Sapiente", Description = "Dal momento in cui sceglie questa scuola al 2° livello, l'oro e il tempo necessari al mago per copiare un incantesimo di divinazione nel suo libro degli incantesimi sono dimezzati." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-divination/portent"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 2,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-divination/portent", "en"), Language = LanguageCode.En, Name = "Portent", Description = "From 2nd level, glimpses of the future start to surface in your mind. When you finish a long rest, roll two d20s and note the results. You can replace any attack roll, saving throw, or ability check made by you or by a creature you can see with one of these foretelling rolls. You must decide to do so before the roll, and you can replace a roll this way only once per turn.\n\nEach foretelling roll can be used only once, and any you haven't used are lost when you finish a long rest." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-divination/portent", "it"), Language = LanguageCode.It, Name = "Portento", Description = "Dal 2° livello, bagliori del futuro iniziano ad affiorare nella mente del mago. Quando completa un riposo lungo, il mago tira due d20 e annota i risultati. Può sostituire qualsiasi tiro per colpire, tiro salvezza o prova di caratteristica effettuato da lui o da una creatura che è in grado di vedere con uno di questi tiri di preveggenza. Deve decidere di farlo prima del tiro, e può sostituire un tiro in questo modo soltanto una volta per turno.\n\nOgni tiro di preveggenza può essere usato una sola volta, e quelli non usati vanno perduti quando il mago completa un riposo lungo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-divination/expert-divination"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 6,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-divination/expert-divination", "en"), Language = LanguageCode.En, Name = "Expert Divination", Description = "From 6th level, divination magic comes so naturally to you that it barely taxes you. When you cast a divination spell of 2nd level or higher, you regain one expended spell slot of a lower level than the spell you cast, and no higher than 5th level." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-divination/expert-divination", "it"), Language = LanguageCode.It, Name = "Divinazione Esperta", Description = "Dal 6° livello la magia di divinazione risulta così naturale al mago da affaticarlo appena. Quando lancia un incantesimo di divinazione di 2° livello o superiore, recupera uno slot incantesimo speso di livello inferiore a quello dell'incantesimo lanciato e non superiore al 5°." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-divination/the-third-eye"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 10,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-divination/the-third-eye", "en"), Language = LanguageCode.En, Name = "The Third Eye", Description = "From 10th level, you can use your action to sharpen your senses. Choose one of the following benefits, which lasts until you are incapacitated or you take a short or long rest. You can't use this feature again until you finish a rest.\n\n**Darkvision.** You gain darkvision out to 60 feet.\n\n**Ethereal Sight.** You can see into the Ethereal Plane within 60 feet of you.\n\n**Greater Comprehension.** You can read any language.\n\n**See Invisibility.** You can see invisible creatures and objects within 10 feet of you that are within line of sight." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-divination/the-third-eye", "it"), Language = LanguageCode.It, Name = "Terzo Occhio", Description = "Dal 10° livello il mago può usare la sua azione per affinare i propri sensi. Sceglie uno dei benefici seguenti, che dura finché non diventa incapacitato o non effettua un riposo breve o lungo. Non può usare di nuovo questo privilegio finché non completa un riposo.\n\n**Comprensione superiore.** Il mago è in grado di leggere qualsiasi lingua.\n\n**Scurovisione.** Il mago ottiene scurovisione entro 18 metri.\n\n**Vedere invisibilità.** Il mago vede le creature e gli oggetti invisibili entro 3 metri da lui che si trovano in linea di vista.\n\n**Vista eterea.** Il mago può vedere nel Piano Etereo entro 18 metri da lui." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-divination/greater-portent"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 14,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-divination/greater-portent", "en"), Language = LanguageCode.En, Name = "Greater Portent", Description = "From 14th level, your visions of what is to come grow sharper. You roll three d20s for your Portent feature instead of two." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-divination/greater-portent", "it"), Language = LanguageCode.It, Name = "Portento Superiore", Description = "Dal 14° livello le visioni del mago su ciò che accadrà diventano più nitide. Per il suo privilegio Portento tira tre d20 anziché due." }
					}
				}
			}
		};
	}
}
