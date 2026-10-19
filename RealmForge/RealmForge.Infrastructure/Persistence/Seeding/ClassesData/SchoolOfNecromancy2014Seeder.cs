using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	School of Necromancy (wizard, 2014 ruleset). Not in the SRD: names and mechanics as in the rules, with descriptions written for RealmForge in English and Italian.
///	</summary>
public static class SchoolOfNecromancy2014Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "school-of-necromancy");

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
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "school-of-necromancy", "en"), Language = LanguageCode.En, Name = "School of Necromancy", Description = "Necromancers explore the cosmic forces of life, death and undeath, learning to manipulate the energy that animates all living things. With mastery they can drain a creature's life force, ruin its body with magic, and turn that stolen vitality into further power. Many people see necromancers as sinister or even evil; not all are, but the forces they handle are taboo in many societies." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "school-of-necromancy", "it"), Language = LanguageCode.It, Name = "Scuola di Necromanzia", Description = "I necromanti esplorano le forze cosmiche della vita, della morte e della non morte, imparando a manipolare l'energia che anima ogni essere vivente. Con la padronanza possono prosciugare la forza vitale di una creatura, devastarne il corpo con la magia e trasformare quella vitalità sottratta in ulteriore potere. Molti considerano i necromanti sinistri o addirittura malvagi; non tutti lo sono, ma le forze che maneggiano sono un tabù in molte società." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-necromancy/necromancy-savant"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 2,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-necromancy/necromancy-savant", "en"), Language = LanguageCode.En, Name = "Necromancy Savant", Description = "From the moment you choose this school at 2nd level, the gold and time you need to copy a necromancy spell into your spellbook are halved." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-necromancy/necromancy-savant", "it"), Language = LanguageCode.It, Name = "Necromante Sapiente", Description = "Dal momento in cui sceglie questa scuola al 2° livello, l'oro e il tempo necessari al mago per copiare un incantesimo di necromanzia nel suo libro degli incantesimi sono dimezzati." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-necromancy/grim-harvest"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 2,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-necromancy/grim-harvest", "en"), Language = LanguageCode.En, Name = "Grim Harvest", Description = "At 2nd level, you can reap the life energy of creatures your spells kill. Once per turn, when you kill one or more creatures with a spell of 1st level or higher, you regain hit points equal to twice the spell's level, or three times its level if it is a necromancy spell. You gain no benefit for killing constructs or undead." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-necromancy/grim-harvest", "it"), Language = LanguageCode.It, Name = "Raccolto Macabro", Description = "Al 2° livello il mago impara a nutrirsi della vita che i suoi incantesimi spengono. Se nel suo turno uno dei suoi incantesimi di 1° livello o superiore abbatte una o più creature, il mago recupera due punti ferita per ogni livello dell'incantesimo (tre per livello se l'incantesimo appartiene alla scuola di necromanzia). Questo beneficio si ottiene una sola volta per turno e non vale per l'uccisione di costrutti o non morti." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-necromancy/undead-thralls"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 6,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-necromancy/undead-thralls", "en"), Language = LanguageCode.En, Name = "Undead Thralls", Description = "At 6th level, you add *animate dead* to your spellbook if it isn't there already. When you cast *animate dead*, you can target one extra corpse or pile of bones, creating another zombie or skeleton as appropriate.\n\nWhenever you create an undead with a necromancy spell, it gains these benefits:\n- its hit point maximum increases by an amount equal to your wizard level;\n- it adds your proficiency bonus to its weapon damage rolls." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-necromancy/undead-thralls", "it"), Language = LanguageCode.It, Name = "Servitori Non Morti", Description = "Al 6° livello il mago aggiunge *animare morti* al suo libro degli incantesimi, se non è già presente. Quando lancia *animare morti*, può bersagliare un cadavere o un mucchio di ossa aggiuntivo, creando un altro zombi o scheletro a seconda del caso.\n\nOgni volta che crea un non morto con un incantesimo di necromanzia, quella creatura ottiene questi benefici:\n- il suo massimo dei punti ferita aumenta di un ammontare pari al livello da mago del mago;\n- aggiunge il bonus di competenza del mago ai suoi tiri per i danni con le armi." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-necromancy/inured-to-undeath"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 10,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-necromancy/inured-to-undeath", "en"), Language = LanguageCode.En, Name = "Inured to Undeath", Description = "From 10th level, your long dealings with the undead and the forces that drive them have hardened you against their worst effects. You have resistance to necrotic damage, and your hit point maximum can't be reduced." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-necromancy/inured-to-undeath", "it"), Language = LanguageCode.It, Name = "Impervio alla Non Morte", Description = "Dal 10° livello, anni passati a contatto con i non morti e con l'energia che li muove hanno reso il mago refrattario ai loro effetti più temibili: è resistente ai danni necrotici e nulla può ridurre il suo massimo dei punti ferita." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-necromancy/command-undead"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 14,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-necromancy/command-undead", "en"), Language = LanguageCode.En, Name = "Command Undead", Description = "From 14th level, you can use magic to bring undead under your control, even those made by other wizards. As an action, choose one undead you can see within 60 feet of you. It must make a Charisma saving throw against your wizard spell save DC. On a success, you can't use this feature on it again. On a failure, it becomes friendly to you and obeys your commands until you use this feature again.\n\nIntelligent undead resist this control more easily. If the target has an Intelligence of 8 or higher, it has advantage on the saving throw. If it fails and has an Intelligence of 12 or higher, it can repeat the saving throw at the end of every hour until it succeeds and breaks free." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-necromancy/command-undead", "it"), Language = LanguageCode.It, Name = "Comandare Non Morti", Description = "Dal 14° livello il mago può imporre la sua volontà ai non morti, compresi quelli creati da altri incantatori. Spendendo un'azione, prende di mira un non morto visibile a non più di 18 metri, che tenta un tiro salvezza su Carisma contro la CD dei suoi incantesimi da mago. In caso di successo, il mago non potrà più usare questo privilegio su quel non morto. In caso di fallimento, il non morto diventa amichevole verso il mago ed esegue i suoi ordini, fino a quando il mago non ricorre di nuovo a questo privilegio.\n\nPiù un non morto è intelligente, più è difficile da soggiogare: con Intelligenza 8 o superiore tira il tiro salvezza con vantaggio, e se fallisce pur avendo Intelligenza 12 o superiore può ritentarlo al termine di ogni ora, liberandosi al primo successo." }
					}
				}
			}
		};
	}
}
