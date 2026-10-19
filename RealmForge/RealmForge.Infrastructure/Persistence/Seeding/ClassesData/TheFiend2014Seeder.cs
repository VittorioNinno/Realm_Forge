using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	The Fiend (warlock, 2014 ruleset). SRD text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class TheFiend2014Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "the-fiend");

	public static Subclass Build()
	{
		return new Subclass
		{
			Id = SubclassId,
			CharacterClassId = Warlock2014Seeder.ClassId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			CasterProgression = CasterProgression.None,
			SpellcastingAbility = null,
			Translations = new List<SubclassTranslation>
			{
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "the-fiend", "en"), Language = LanguageCode.En, Name = "The Fiend", Description = "You have made a pact with a fiend from the lower planes, a being whose aims are evil, even if you strive against them. Such beings desire the corruption or destruction of all things, ultimately including you. Only the mightiest fiends, such as demon lords, archdevils and the greatest of their servants, are powerful enough to forge a pact." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "the-fiend", "it"), Language = LanguageCode.It, Name = "L'Immondo", Description = "Il warlock ha stretto un patto con un immondo dei piani inferiori, un essere dagli scopi malvagi, anche se il warlock si oppone a quegli scopi. Creature del genere desiderano la corruzione o la distruzione di ogni cosa, compreso alla fine il warlock stesso. Soltanto gli immondi più potenti, come i signori dei demoni, gli arcidiavoli e i più grandi tra i loro servitori, sono in grado di stringere un patto." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "the-fiend/dark-one-s-blessing"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 1,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "the-fiend/dark-one-s-blessing", "en"), Language = LanguageCode.En, Name = "Dark One's Blessing", Description = "Starting at 1st level, when you reduce a hostile creature to 0 hit points, you gain temporary hit points equal to your Charisma modifier + your warlock level (minimum of 1)." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "the-fiend/dark-one-s-blessing", "it"), Language = LanguageCode.It, Name = "Benedizione dell'Oscuro", Description = "A partire dal 1° livello, quando riduce una creatura ostile a 0 punti ferita, il warlock ottiene punti ferita temporanei pari al suo modificatore di Carisma + il suo livello da warlock (minimo 1)." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "the-fiend/expanded-spell-list"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 1,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "the-fiend/expanded-spell-list", "en"), Language = LanguageCode.En, Name = "Expanded Spell List", Description = "The Fiend lets you choose from an expanded list of spells when you learn a warlock spell. The following spells are added to the warlock spell list for you.\n\n| Spell Level | Spells |\n|---|---|\n| 1st | *burning hands*, *command* |\n| 2nd | *blindness/deafness*, *scorching ray* |\n| 3rd | *fireball*, *stinking cloud* |\n| 4th | *fire shield*, *wall of fire* |\n| 5th | *flame strike*, *hallow* |" },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "the-fiend/expanded-spell-list", "it"), Language = LanguageCode.It, Name = "Lista Ampliata degli Incantesimi", Description = "L'Immondo permette al warlock di scegliere da una lista ampliata di incantesimi quando apprende un incantesimo da warlock. I seguenti incantesimi vengono aggiunti alla lista degli incantesimi del warlock.\n\n| Livello dell'incantesimo | Incantesimi |\n|---|---|\n| 1° | *comando*, *mani brucianti* |\n| 2° | *cecità/sordità*, *raggio rovente* |\n| 3° | *nube maleodorante*, *palla di fuoco* |\n| 4° | *muro di fuoco*, *scudo di fuoco* |\n| 5° | *colpo infuocato*, *santificare* |" }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "the-fiend/dark-one-s-own-luck"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 6,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "the-fiend/dark-one-s-own-luck", "en"), Language = LanguageCode.En, Name = "Dark One's Own Luck", Description = "Starting at 6th level, you can call on your patron to alter fate in your favor. When you make an ability check or a saving throw, you can use this feature to add a d10 to your roll. You can do so after seeing the initial roll but before any of the roll's effects occur.\n\nOnce you use this feature, you can't use it again until you finish a short or long rest." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "the-fiend/dark-one-s-own-luck", "it"), Language = LanguageCode.It, Name = "Fortuna dell'Oscuro", Description = "A partire dal 6° livello, il warlock può invocare il suo patrono affinché alteri il fato a suo favore. Quando effettua una prova di caratteristica o un tiro salvezza, può usare questo privilegio per aggiungere un d10 al tiro. Può farlo dopo avere visto il risultato iniziale, ma prima che si verifichi qualsiasi effetto del tiro.\n\nUna volta usato questo privilegio, non può usarlo di nuovo finché non completa un riposo breve o lungo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "the-fiend/fiendish-resilience"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 10,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "the-fiend/fiendish-resilience", "en"), Language = LanguageCode.En, Name = "Fiendish Resilience", Description = "Starting at 10th level, you can choose one damage type when you finish a short or long rest. You gain resistance to that damage type until you choose a different one with this feature. Damage from magical weapons or silver weapons ignores this resistance." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "the-fiend/fiendish-resilience", "it"), Language = LanguageCode.It, Name = "Resilienza Immonda", Description = "A partire dal 10° livello, quando completa un riposo breve o lungo, il warlock può scegliere un tipo di danno. Ottiene resistenza a quel tipo di danno finché non ne sceglie uno diverso con questo privilegio. I danni inflitti da armi magiche o da armi d'argento ignorano questa resistenza." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "the-fiend/hurl-through-hell"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 14,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "the-fiend/hurl-through-hell", "en"), Language = LanguageCode.En, Name = "Hurl Through Hell", Description = "Starting at 14th level, when you hit a creature with an attack, you can use this feature to instantly transport the target through the lower planes. The creature disappears and hurtles through a nightmare landscape.\n\nAt the end of your next turn, the target returns to the space it previously occupied, or the nearest unoccupied space. If the target is not a fiend, it takes 10d10 psychic damage as it reels from its horrific experience.\n\nOnce you use this feature, you can't use it again until you finish a long rest." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "the-fiend/hurl-through-hell", "it"), Language = LanguageCode.It, Name = "Scagliare all'Inferno", Description = "A partire dal 14° livello, quando colpisce una creatura con un attacco, il warlock può usare questo privilegio per trasportare istantaneamente il bersaglio attraverso i piani inferiori. La creatura scompare e precipita attraverso un paesaggio da incubo.\n\nAlla fine del turno successivo del warlock, il bersaglio ritorna nello spazio che occupava in precedenza o nello spazio libero più vicino. Se il bersaglio non è un immondo, subisce 10d10 danni psichici, sconvolto dall'orrenda esperienza.\n\nUna volta usato questo privilegio, il warlock non può usarlo di nuovo finché non completa un riposo lungo." }
					}
				}
			}
		};
	}
}
