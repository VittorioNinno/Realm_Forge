using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Abjurer (wizard, 2024 ruleset). Not in the SRD: names and mechanics as in the rules, with descriptions written for RealmForge in English and Italian.
///	</summary>
public static class Abjurer2024Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "abjurer");

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
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "abjurer", "en"), Language = LanguageCode.En, Name = "Abjurer", Description = "Your magical studies center on spells that block, banish and shield: undoing harmful effects, driving out evil influences and guarding the defenseless. Abjurers are called upon when malevolent spirits must be exorcised, when a place must be hidden from magical prying or when a gateway to another plane needs sealing, and adventuring companies prize the protection they offer against hostile magic and every other kind of assault." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "abjurer", "it"), Language = LanguageCode.It, Name = "Abiuratore", Description = "Gli studi magici dell'abiuratore si concentrano sugli incantesimi che bloccano, esiliano e proteggono: annullano gli effetti dannosi, scacciano le influenze malvagie e difendono gli indifesi. Gli abiuratori vengono chiamati quando bisogna esorcizzare spiriti maligni, nascondere un luogo agli sguardi magici o sigillare un portale verso un altro piano, e i gruppi di avventurieri apprezzano la protezione che offrono contro la magia ostile e ogni altro tipo di attacco." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "abjurer/abjuration-savant"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "abjurer/abjuration-savant", "en"), Language = LanguageCode.En, Name = "Abjuration Savant", Description = "Pick two Wizard spells of the Abjuration school, each no higher than level 2, and copy them into your spellbook at no cost.\n\nAlso, each time you unlock a new level of spell slots in this class, you can add one Abjuration Wizard spell of a level you have slots for to your spellbook at no cost." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "abjurer/abjuration-savant", "it"), Language = LanguageCode.It, Name = "Abiuratore Sapiente", Description = "Il mago sceglie due incantesimi da mago della scuola di abiurazione, ognuno di livello non superiore al 2°, e li aggiunge gratuitamente al suo libro degli incantesimi.\n\nInoltre, ogni volta che ottiene accesso a un nuovo livello di slot incantesimo in questa classe, può aggiungere gratuitamente al libro un incantesimo da mago della scuola di abiurazione, di un livello per cui possiede slot incantesimo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "abjurer/arcane-ward"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "abjurer/arcane-ward", "en"), Language = LanguageCode.En, Name = "Arcane Ward", Description = "You can wrap protective magic around yourself. When you cast an Abjuration spell with a spell slot, you can at the same moment use a thread of its magic to raise a ward on yourself that lasts until you finish a Long Rest. The ward's Hit Point maximum is twice your Wizard level plus your Intelligence modifier. Whenever you take damage, the ward absorbs it instead, after any Resistances or Vulnerabilities you have are applied; if the damage drops the ward to 0 Hit Points, you take what is left over. At 0 Hit Points the ward absorbs nothing, but its magic lingers.\n\nEach time you cast an Abjuration spell with a spell slot, the ward regains Hit Points equal to twice the slot's level. Or, as a Bonus Action, you can spend a spell slot to restore Hit Points to the ward equal to twice that slot's level.\n\nAfter creating the ward, you need a Long Rest before you can create it again." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "abjurer/arcane-ward", "it"), Language = LanguageCode.It, Name = "Interdizione Arcana", Description = "Il mago sa intrecciare la magia attorno a sé per proteggersi. Quando lancia un incantesimo di abiurazione con uno slot incantesimo, può usare contemporaneamente un filamento della magia dell'incantesimo per creare su di sé un'interdizione magica che dura finché non completa un riposo lungo. L'interdizione ha un massimo dei punti ferita pari al doppio del livello da mago + il modificatore di Intelligenza. Ogni volta che il mago subisce danni, è l'interdizione a subirli al suo posto, dopo aver applicato eventuali resistenze o vulnerabilità del mago; se i danni riducono l'interdizione a 0 punti ferita, il mago subisce i danni rimanenti. Mentre l'interdizione ha 0 punti ferita non può assorbire danni, ma la sua magia rimane.\n\nOgni volta che il mago lancia un incantesimo di abiurazione con uno slot incantesimo, l'interdizione recupera punti ferita pari al doppio del livello dello slot. In alternativa, come azione bonus, il mago può spendere uno slot incantesimo per far recuperare all'interdizione punti ferita pari al doppio del livello dello slot speso.\n\nDopo aver creato l'interdizione, il mago non può crearla di nuovo finché non completa un riposo lungo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "abjurer/projected-ward"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 6,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "abjurer/projected-ward", "en"), Language = LanguageCode.En, Name = "Projected Ward", Description = "When a creature you can see within 30 feet of you takes damage, you can use your Reaction to have your Arcane Ward soak up that damage. If the ward drops to 0 Hit Points, the protected creature takes whatever damage remains; that creature's Resistances or Vulnerabilities apply before the ward loses Hit Points." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "abjurer/projected-ward", "it"), Language = LanguageCode.It, Name = "Interdizione Proiettata", Description = "Quando una creatura che il mago è in grado di vedere entro 9 metri da lui subisce danni, il mago può usare una reazione per far assorbire quei danni alla sua Interdizione arcana. Se i danni riducono l'interdizione a 0 punti ferita, la creatura protetta subisce i danni rimanenti; le eventuali resistenze o vulnerabilità di quella creatura si applicano prima di ridurre i punti ferita dell'interdizione." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "abjurer/spell-breaker"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 10,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "abjurer/spell-breaker", "en"), Language = LanguageCode.En, Name = "Spell Breaker", Description = "*Counterspell* and *Dispel Magic* are always prepared for you. You can also cast *Dispel Magic* as a Bonus Action and add your Proficiency Bonus to its ability check.\n\nIf you cast either spell with a spell slot and it fails to stop a spell, the slot isn't spent." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "abjurer/spell-breaker", "it"), Language = LanguageCode.It, Name = "Spezzamagia", Description = "Il mago ha sempre preparati gli incantesimi *controincantesimo* e *dissolvi magie*. Inoltre, può lanciare *dissolvi magie* come azione bonus e sommare il suo bonus di competenza alla prova di caratteristica dell'incantesimo.\n\nQuando lancia uno dei due incantesimi con uno slot incantesimo, lo slot non viene speso se l'incantesimo non riesce a fermare un incantesimo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "abjurer/spell-resistance"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 14,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "abjurer/spell-resistance", "en"), Language = LanguageCode.En, Name = "Spell Resistance", Description = "Spells struggle to touch you: you make saving throws against them with Advantage, and their damage meets your Resistance." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "abjurer/spell-resistance", "it"), Language = LanguageCode.It, Name = "Resistenza agli Incantesimi", Description = "Il mago dispone di vantaggio ai tiri salvezza contro gli incantesimi e ha resistenza ai danni degli incantesimi." }
					}
				}
			}
		};
	}
}
