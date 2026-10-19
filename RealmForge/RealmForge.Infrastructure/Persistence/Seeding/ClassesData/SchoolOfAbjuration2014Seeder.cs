using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	School of Abjuration (wizard, 2014 ruleset). Not in the SRD: names and mechanics as in the rules, with descriptions written for RealmForge in English and Italian.
///	</summary>
public static class SchoolOfAbjuration2014Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "school-of-abjuration");

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
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "school-of-abjuration", "en"), Language = LanguageCode.En, Name = "School of Abjuration", Description = "Abjurers study the magic of blocking, banishing and protecting. Critics call it a tradition of denial, but its followers know that warding off harm, sheltering the weak and driving out evil is anything but passive. Abjurers are sought out to lay restless spirits to rest, guard important places against magical spying, and seal portals to other planes." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "school-of-abjuration", "it"), Language = LanguageCode.It, Name = "Scuola di Abiurazione", Description = "Gli abiuratori studiano la magia che blocca, esilia e protegge. I detrattori la definiscono una tradizione della negazione, ma i suoi seguaci sanno che respingere il pericolo, riparare i deboli e scacciare il male è tutt'altro che passivo. Gli abiuratori sono richiesti per placare gli spiriti inquieti, proteggere luoghi importanti dallo spionaggio magico e sigillare i portali verso altri piani." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-abjuration/abjuration-savant"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 2,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-abjuration/abjuration-savant", "en"), Language = LanguageCode.En, Name = "Abjuration Savant", Description = "From the moment you choose this school at 2nd level, the gold and time you need to copy an abjuration spell into your spellbook are halved." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-abjuration/abjuration-savant", "it"), Language = LanguageCode.It, Name = "Abiuratore Sapiente", Description = "Dal momento in cui sceglie questa scuola al 2° livello, l'oro e il tempo necessari al mago per copiare un incantesimo di abiurazione nel suo libro degli incantesimi sono dimezzati." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-abjuration/arcane-ward"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 2,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-abjuration/arcane-ward", "en"), Language = LanguageCode.En, Name = "Arcane Ward", Description = "From 2nd level, you can weave a protective field around yourself. When you cast an abjuration spell of 1st level or higher, you can use a thread of its magic to create a ward on yourself that lasts until you finish a long rest. The ward has a hit point maximum equal to twice your wizard level + your Intelligence modifier. Whenever you take damage, the ward takes it instead; if the damage reduces the ward to 0 hit points, you take any damage left over.\n\nAt 0 hit points the ward can no longer absorb damage, but its magic lingers. Whenever you cast an abjuration spell of 1st level or higher, the ward regains hit points equal to twice the spell's level.\n\nOnce you create the ward, you can't create it again until you finish a long rest." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-abjuration/arcane-ward", "it"), Language = LanguageCode.It, Name = "Interdizione Arcana", Description = "Dal 2° livello il mago può intessere un campo protettivo intorno a sé. Quando lancia un incantesimo di abiurazione di 1° livello o superiore, può usare un filo della sua magia per creare su di sé un'interdizione che dura finché non completa un riposo lungo. Il massimo dei punti ferita dell'interdizione è pari al doppio del livello da mago + il modificatore di Intelligenza del mago. Ogni volta che il mago subisce danni, è l'interdizione a subirli al suo posto; se i danni la riducono a 0 punti ferita, il mago subisce i danni rimanenti.\n\nA 0 punti ferita l'interdizione non può più assorbire danni, ma la sua magia permane. Ogni volta che il mago lancia un incantesimo di abiurazione di 1° livello o superiore, l'interdizione recupera punti ferita pari al doppio del livello dell'incantesimo.\n\nUna volta creata l'interdizione, il mago non può crearla di nuovo finché non completa un riposo lungo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-abjuration/projected-ward"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 6,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-abjuration/projected-ward", "en"), Language = LanguageCode.En, Name = "Projected Ward", Description = "From 6th level, when a creature you can see within 30 feet of you takes damage, you can use your reaction to have your Arcane Ward absorb it. If the damage reduces the ward to 0 hit points, the protected creature takes any damage left over." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-abjuration/projected-ward", "it"), Language = LanguageCode.It, Name = "Interdizione Proiettata", Description = "Dal 6° livello il mago può estendere la sua protezione agli altri. Se un'altra creatura visibile, a non più di 9 metri, sta per subire danni, il mago può spendere la reazione perché sia la sua Interdizione Arcana a incassarli. Quando i danni esauriscono i punti ferita dell'interdizione, l'eccedenza ricade sulla creatura." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-abjuration/improved-abjuration"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 10,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-abjuration/improved-abjuration", "en"), Language = LanguageCode.En, Name = "Improved Abjuration", Description = "From 10th level, when you cast an abjuration spell that calls for an ability check as part of casting it (such as *counterspell* or *dispel magic*), you add your proficiency bonus to that check." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-abjuration/improved-abjuration", "it"), Language = LanguageCode.It, Name = "Abiurazione Migliorata", Description = "Dal 10° livello il mago è più abile a contrastare la magia altrui. Alcuni incantesimi di abiurazione, come *controincantesimo* e *dissolvi magie*, gli chiedono di superare una prova di caratteristica durante il lancio: a questa prova somma il suo bonus di competenza." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-abjuration/spell-resistance"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 14,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-abjuration/spell-resistance", "en"), Language = LanguageCode.En, Name = "Spell Resistance", Description = "From 14th level, you have advantage on saving throws against spells, and you have resistance to the damage of spells." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-abjuration/spell-resistance", "it"), Language = LanguageCode.It, Name = "Resistenza agli Incantesimi", Description = "Dal 14° livello il mago dispone di vantaggio ai tiri salvezza contro gli incantesimi e ha resistenza ai danni degli incantesimi." }
					}
				}
			}
		};
	}
}
