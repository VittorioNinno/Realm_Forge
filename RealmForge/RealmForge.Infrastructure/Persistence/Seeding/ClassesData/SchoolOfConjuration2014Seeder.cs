using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	School of Conjuration (wizard, 2014 ruleset). Not in the SRD: names and mechanics as in the rules, with descriptions written for RealmForge in English and Italian.
///	</summary>
public static class SchoolOfConjuration2014Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "school-of-conjuration");

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
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "school-of-conjuration", "en"), Language = LanguageCode.En, Name = "School of Conjuration", Description = "Conjurers favor spells that make objects and creatures appear out of thin air, from billowing clouds of deadly fog to allies called from far away to fight at their side. As their mastery grows, they also learn travel and teleportation magic that can carry them across great distances, or to other planes, in an instant." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "school-of-conjuration", "it"), Language = LanguageCode.It, Name = "Scuola di Evocazione", Description = "Gli evocatori prediligono gli incantesimi che fanno apparire oggetti e creature dal nulla, dalle nubi ondeggianti di nebbia letale agli alleati richiamati da luoghi lontani per combattere al loro fianco. Man mano che la loro padronanza cresce, apprendono anche la magia del viaggio e del teletrasporto, che può portarli in un istante attraverso grandi distanze o su altri piani." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-conjuration/conjuration-savant"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 2,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-conjuration/conjuration-savant", "en"), Language = LanguageCode.En, Name = "Conjuration Savant", Description = "From the moment you choose this school at 2nd level, the gold and time you need to copy a conjuration spell into your spellbook are halved." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-conjuration/conjuration-savant", "it"), Language = LanguageCode.It, Name = "Evocatore Sapiente", Description = "Dal momento in cui sceglie questa scuola al 2° livello, l'oro e il tempo necessari al mago per copiare un incantesimo di evocazione nel suo libro degli incantesimi sono dimezzati." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-conjuration/minor-conjuration"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 2,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-conjuration/minor-conjuration", "en"), Language = LanguageCode.En, Name = "Minor Conjuration", Description = "From 2nd level, you can use your action to conjure an inanimate object in your hand or on the ground in an unoccupied space you can see within 10 feet of you. It can be no larger than 3 feet on a side and weigh no more than 10 pounds, and it must take the form of a nonmagical object you have seen. The object is visibly magical and sheds dim light out to 5 feet.\n\nIt disappears after 1 hour, when you use this feature again, or if it takes any damage." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-conjuration/minor-conjuration", "it"), Language = LanguageCode.It, Name = "Evocazione Minore", Description = "Dal 2° livello, spendendo un'azione, il mago fa apparire dal nulla un oggetto inanimato, che si materializza nella sua mano oppure a terra, in un punto libero visibile a non più di 3 metri. L'oggetto deve riprodurre un oggetto non magico che il mago abbia già visto, non può superare i 90 cm per lato e i 5 kg di peso, ed è chiaramente di natura magica: emana una luce fioca fino a 1,5 metri.\n\nL'oggetto svanisce trascorsa 1 ora, se subisce un qualsiasi danno o quando il mago ricorre una seconda volta a questo privilegio." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-conjuration/benign-transposition"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 6,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-conjuration/benign-transposition", "en"), Language = LanguageCode.En, Name = "Benign Transposition", Description = "From 6th level, you can use your action to teleport up to 30 feet to an unoccupied space you can see. Instead, you can pick a space within range occupied by a Small or Medium creature: if it is willing, you both teleport, swapping places.\n\nOnce you use this feature, you can't use it again until you finish a long rest or cast a conjuration spell of 1st level or higher." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-conjuration/benign-transposition", "it"), Language = LanguageCode.It, Name = "Trasposizione Benevola", Description = "Dal 6° livello il mago può spostarsi in un battito di ciglia. Spendendo un'azione, si teletrasporta in un punto libero e visibile distante al massimo 9 metri. Il punto scelto può anche essere occupato da una creatura Piccola o Media: se questa acconsente, i due si scambiano di posizione.\n\nDopo averlo usato, il mago riottiene questo privilegio quando completa un riposo lungo, oppure non appena lancia un incantesimo di evocazione di 1° livello o superiore." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-conjuration/focused-conjuration"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 10,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-conjuration/focused-conjuration", "en"), Language = LanguageCode.En, Name = "Focused Conjuration", Description = "From 10th level, taking damage can't break your concentration on a conjuration spell." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-conjuration/focused-conjuration", "it"), Language = LanguageCode.It, Name = "Evocazione Focalizzata", Description = "Dal 10° livello, subire danni non può interrompere la concentrazione del mago su un incantesimo di evocazione." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-conjuration/durable-summons"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 14,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-conjuration/durable-summons", "en"), Language = LanguageCode.En, Name = "Durable Summons", Description = "From 14th level, any creature you summon or create with a conjuration spell has 30 temporary hit points." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-conjuration/durable-summons", "it"), Language = LanguageCode.It, Name = "Evocazioni Perduranti", Description = "Dal 14° livello, qualsiasi creatura che il mago evoca o crea con un incantesimo di evocazione ha 30 punti ferita temporanei." }
					}
				}
			}
		};
	}
}
