using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	The Great Old One (warlock, 2014 ruleset). Not in the SRD: names and mechanics as in the rules, with descriptions written for RealmForge in English and Italian.
///	</summary>
public static class TheGreatOldOne2014Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "the-great-old-one");

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
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "the-great-old-one", "en"), Language = LanguageCode.En, Name = "The Great Old One", Description = "Your patron is a mysterious entity utterly foreign to the fabric of reality. It may come from the void beyond the known planes, or be one of the elder gods whispered about only in legend. Its goals are beyond mortal understanding, and its knowledge is so vast and ancient that the greatest libraries pale beside it. It may not even know you exist, yet the secrets you have uncovered let you draw your magic from it." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "the-great-old-one", "it"), Language = LanguageCode.It, Name = "Il Grande Antico", Description = "Il patrono del warlock è un'entità misteriosa del tutto estranea al tessuto della realtà. Potrebbe provenire dal vuoto oltre i piani conosciuti, o essere uno degli dei antichi di cui si sussurra soltanto nelle leggende. I suoi scopi vanno oltre la comprensione dei mortali, e la sua conoscenza è così vasta e antica che le più grandi biblioteche impallidiscono al confronto. Potrebbe perfino ignorare l'esistenza del warlock, eppure i segreti che il warlock ha scoperto gli permettono di trarre da esso la sua magia." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "the-great-old-one/expanded-spell-list"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 1,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "the-great-old-one/expanded-spell-list", "en"), Language = LanguageCode.En, Name = "Expanded Spell List", Description = "When you learn a warlock spell, the Great Old One lets you pick from an expanded list. The following spells are added to the warlock spell list for you.\n\n| Spell Level | Spells |\n|---|---|\n| 1st | *dissonant whispers*, *hideous laughter* |\n| 2nd | *detect thoughts*, *phantasmal force* |\n| 3rd | *clairvoyance*, *sending* |\n| 4th | *black tentacles*, *dominate beast* |\n| 5th | *dominate person*, *telekinesis* |" },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "the-great-old-one/expanded-spell-list", "it"), Language = LanguageCode.It, Name = "Lista Ampliata degli Incantesimi", Description = "Quando il warlock apprende un incantesimo da warlock, il Grande Antico gli consente di scegliere da una lista ampliata. I seguenti incantesimi vengono aggiunti alla lista degli incantesimi del warlock.\n\n| Livello dell'incantesimo | Incantesimi |\n|---|---|\n| 1° | *risata incontenibile*, *sussurri dissonanti* |\n| 2° | *allucinazione di forza*, *individuazione dei pensieri* |\n| 3° | *chiaroveggenza*, *inviare* |\n| 4° | *dominare bestie*, *tentacoli neri* |\n| 5° | *dominare persone*, *telecinesi* |" }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "the-great-old-one/awakened-mind"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 1,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "the-great-old-one/awakened-mind", "en"), Language = LanguageCode.En, Name = "Awakened Mind", Description = "From 1st level, your alien knowledge lets you touch the minds of others. You can speak telepathically to any creature you can see within 30 feet of you. You don't need to share a language with it for it to understand you, but it must understand at least one language." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "the-great-old-one/awakened-mind", "it"), Language = LanguageCode.It, Name = "Mente Risvegliata", Description = "Dal 1° livello le conoscenze aliene del warlock gli permettono di sfiorare la mente altrui. Può parlare telepaticamente con qualsiasi creatura che è in grado di vedere entro 9 metri da lui. Non è necessario che condivida una lingua con la creatura perché questa lo capisca, ma la creatura deve comprendere almeno una lingua." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "the-great-old-one/entropic-ward"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 6,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "the-great-old-one/entropic-ward", "en"), Language = LanguageCode.En, Name = "Entropic Ward", Description = "At 6th level, you learn to shield yourself magically and turn an enemy's miss into your opening. When a creature makes an attack roll against you, you can use your reaction to impose disadvantage on that roll. If the attack misses you, your next attack roll against that creature has advantage, as long as you make it before the end of your next turn.\n\nOnce you use this feature, you can't use it again until you finish a short or long rest." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "the-great-old-one/entropic-ward", "it"), Language = LanguageCode.It, Name = "Interdizione Entropica", Description = "Al 6° livello il warlock impara a proteggersi con la magia e a trasformare il colpo mancato di un nemico in un'occasione propizia. Quando una creatura effettua un tiro per colpire contro di lui, il warlock può usare la sua reazione per imporre svantaggio a quel tiro. Se l'attacco lo manca, il suo tiro per colpire successivo contro quella creatura dispone di vantaggio, purché lo effettui prima della fine del suo turno successivo.\n\nUna volta usato questo privilegio, il warlock non può usarlo di nuovo finché non completa un riposo breve o lungo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "the-great-old-one/thought-shield"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 10,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "the-great-old-one/thought-shield", "en"), Language = LanguageCode.En, Name = "Thought Shield", Description = "From 10th level, your thoughts can't be read by telepathy or any other means unless you allow it. You also have resistance to psychic damage, and whenever a creature deals psychic damage to you, it takes the same amount of damage." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "the-great-old-one/thought-shield", "it"), Language = LanguageCode.It, Name = "Scudo del Pensiero", Description = "Dal 10° livello i pensieri del warlock non possono essere letti tramite telepatia o altri mezzi, a meno che lui non lo permetta. Il warlock ha inoltre resistenza ai danni psichici e, ogni volta che una creatura gli infligge danni psichici, quella creatura subisce la stessa quantità di danni." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "the-great-old-one/create-thrall"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 14,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "the-great-old-one/create-thrall", "en"), Language = LanguageCode.En, Name = "Create Thrall", Description = "At 14th level, you can taint a humanoid's mind with your patron's alien magic. As an action, you touch an incapacitated humanoid, and it becomes charmed by you until a *remove curse* spell is cast on it, the charmed condition is removed from it, or you use this feature again.\n\nWhile you and the charmed creature are on the same plane of existence, you can communicate with it telepathically." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "the-great-old-one/create-thrall", "it"), Language = LanguageCode.It, Name = "Creare Servitore", Description = "Al 14° livello il warlock può contaminare la mente di un umanoide con la magia aliena del suo patrono. Come azione, tocca un umanoide incapacitato, che diventa affascinato da lui finché su di esso non viene lanciato un incantesimo *rimuovi maledizione*, la condizione di affascinato non gli viene rimossa o il warlock non usa di nuovo questo privilegio.\n\nFinché il warlock e la creatura affascinata si trovano sullo stesso piano di esistenza, il warlock può comunicare telepaticamente con essa." }
					}
				}
			}
		};
	}
}
