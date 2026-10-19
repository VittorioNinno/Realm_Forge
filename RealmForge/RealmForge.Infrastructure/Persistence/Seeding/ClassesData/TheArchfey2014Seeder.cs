using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	The Archfey (warlock, 2014 ruleset). Not in the SRD: names and mechanics as in the rules, with descriptions written for RealmForge in English and Italian.
///	</summary>
public static class TheArchfey2014Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "the-archfey");

	public static Subclass Build()
	{
		return new Subclass
		{
			Id = SubclassId,
			CharacterClassId = Warlock2014Seeder.ClassId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			CasterProgression = CasterProgression.None,
			SpellcastingAbility = null,
			Translations = new List<SubclassTranslation>
			{
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "the-archfey", "en"), Language = LanguageCode.En, Name = "The Archfey", Description = "Your patron is a lord or lady of the fey, an ancient and legendary being who guards secrets that were old before mortal peoples were born. Its motives are often hard to read and sometimes fickle: it may hunger for more magical power, or want an age-old grudge finally settled. Fey royalty of the summer and winter courts and the most ancient hags are among such patrons." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "the-archfey", "it"), Language = LanguageCode.It, Name = "Il Signore Fatato", Description = "Il patrono del warlock è un signore o una dama dei folletti, un essere antico e leggendario che custodisce segreti già vecchi quando i popoli mortali nacquero. Le sue motivazioni sono spesso difficili da decifrare e a volte volubili: potrebbe bramare altro potere magico o volere che un rancore antico di secoli venga finalmente saldato. Tra questi patroni si annoverano i sovrani fatati delle corti dell'estate e dell'inverno e le megere più antiche." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "the-archfey/expanded-spell-list"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 1,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "the-archfey/expanded-spell-list", "en"), Language = LanguageCode.En, Name = "Expanded Spell List", Description = "When you learn a warlock spell, the Archfey lets you pick from an expanded list. The following spells are added to the warlock spell list for you.\n\n| Spell Level | Spells |\n|---|---|\n| 1st | *faerie fire*, *sleep* |\n| 2nd | *calm emotions*, *phantasmal force* |\n| 3rd | *blink*, *plant growth* |\n| 4th | *dominate beast*, *greater invisibility* |\n| 5th | *dominate person*, *seeming* |" },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "the-archfey/expanded-spell-list", "it"), Language = LanguageCode.It, Name = "Lista Ampliata degli Incantesimi", Description = "Quando il warlock apprende un incantesimo da warlock, il Signore Fatato gli consente di scegliere da una lista ampliata. I seguenti incantesimi vengono aggiunti alla lista degli incantesimi del warlock.\n\n| Livello dell'incantesimo | Incantesimi |\n|---|---|\n| 1° | *luminescenza*, *sonno* |\n| 2° | *allucinazione di forza*, *calmare emozioni* |\n| 3° | *crescita vegetale*, *intermittenza* |\n| 4° | *dominare bestie*, *invisibilità superiore* |\n| 5° | *dominare persone*, *sembrare* |" }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "the-archfey/fey-presence"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 1,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "the-archfey/fey-presence", "en"), Language = LanguageCode.En, Name = "Fey Presence", Description = "From 1st level, your patron lets you radiate the alluring yet unsettling presence of the fey. As an action, you force each creature in a 10-foot cube originating from you to make a Wisdom saving throw against your warlock spell save DC. Each creature that fails is charmed or frightened by you (your choice) until the end of your next turn.\n\nOnce you use this feature, you can't use it again until you finish a short or long rest." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "the-archfey/fey-presence", "it"), Language = LanguageCode.It, Name = "Presenza Fatata", Description = "Dal 1° livello il patrono permette al warlock di emanare la presenza seducente e al tempo stesso inquietante dei folletti. Come azione, il warlock costringe ogni creatura in un cubo con spigolo di 3 metri che parte da lui a effettuare un tiro salvezza su Saggezza contro la CD dei suoi incantesimi da warlock. Ogni creatura che lo fallisce è affascinata o spaventata dal warlock (a sua scelta) fino alla fine del turno successivo del warlock.\n\nUna volta usato questo privilegio, il warlock non può usarlo di nuovo finché non completa un riposo breve o lungo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "the-archfey/misty-escape"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 6,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "the-archfey/misty-escape", "en"), Language = LanguageCode.En, Name = "Misty Escape", Description = "From 6th level, you can vanish in a wisp of mist when you are hurt. When you take damage, you can use your reaction to turn invisible and teleport up to 60 feet to an unoccupied space you can see. You stay invisible until the start of your next turn or until you attack or cast a spell.\n\nOnce you use this feature, you can't use it again until you finish a short or long rest." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "the-archfey/misty-escape", "it"), Language = LanguageCode.It, Name = "Fuga Velata", Description = "Dal 6° livello, quando viene ferito, il warlock può dissolversi in un velo di nebbia. Appena subisce danni, può spendere la reazione per sparire alla vista e riapparire in un punto libero e visibile distante al massimo 18 metri. L'invisibilità dura fino all'inizio del suo prossimo turno, ma cessa prima se il warlock attacca o lancia un incantesimo.\n\nDopo averlo usato, il warlock potrà ricorrere di nuovo a questo privilegio solo dopo un riposo breve o lungo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "the-archfey/beguiling-defenses"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 10,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "the-archfey/beguiling-defenses", "en"), Language = LanguageCode.En, Name = "Beguiling Defenses", Description = "From 10th level, your patron teaches you to turn mind-affecting magic back on those who wield it. You can't be charmed, and when another creature attempts to charm you, you can use your reaction to try to reflect the effect onto it. That creature must succeed on a Wisdom saving throw against your warlock spell save DC or be charmed by you for 1 minute or until it takes damage." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "the-archfey/beguiling-defenses", "it"), Language = LanguageCode.It, Name = "Difese Seducenti", Description = "Dal 10° livello il patrono insegna al warlock a ritorcere la magia che influenza la mente contro chi la usa. Il warlock non può essere affascinato e, quando un'altra creatura tenta di affascinarlo, può usare la sua reazione per provare a riflettere l'effetto su di essa. Quella creatura deve superare un tiro salvezza su Saggezza contro la CD dei suoi incantesimi da warlock, altrimenti è affascinata dal warlock per 1 minuto o finché non subisce danni." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "the-archfey/dark-delirium"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 14,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "the-archfey/dark-delirium", "en"), Language = LanguageCode.En, Name = "Dark Delirium", Description = "From 14th level, you can trap a creature in an illusory realm. As an action, choose a creature you can see within 60 feet of you. It makes a Wisdom saving throw against your warlock spell save DC; on a failure, it is charmed or frightened by you (your choice) for 1 minute or until your concentration is broken (as if you were concentrating on a spell). The effect ends early if the creature takes damage.\n\nUntil the illusion ends, the creature believes it is lost in a misty realm whose appearance you decide. It can see and hear only itself, you, and the illusion.\n\nYou must finish a short or long rest before you can use this feature again." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "the-archfey/dark-delirium", "it"), Language = LanguageCode.It, Name = "Delirio Oscuro", Description = "Dal 14° livello il warlock è capace di imprigionare la mente altrui in un mondo di illusioni. Spendendo un'azione, prende di mira una creatura visibile a non più di 18 metri, che effettua un tiro salvezza su Saggezza contro la CD dei suoi incantesimi da warlock. In caso di fallimento, la creatura resta affascinata oppure spaventata (decide il warlock) per 1 minuto, oppure fino a quando il warlock perde la concentrazione, come accadrebbe mantenendo un incantesimo; l'effetto cessa in anticipo se la creatura viene ferita.\n\nPer tutta la durata, la vittima è convinta di vagare in una terra avvolta dalla nebbia, il cui aspetto è scelto dal warlock, e non percepisce con la vista o con l'udito nient'altro che sé stessa, il warlock e il paesaggio illusorio.\n\nDopo averlo usato, il warlock potrà ricorrere di nuovo a questo privilegio solo dopo un riposo breve o lungo." }
					}
				}
			}
		};
	}
}
