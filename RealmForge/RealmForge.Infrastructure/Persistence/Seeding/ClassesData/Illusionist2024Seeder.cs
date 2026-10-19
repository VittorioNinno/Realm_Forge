using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Illusionist (wizard, 2024 ruleset). Not in the SRD: names and mechanics as in the rules, with descriptions written for RealmForge in English and Italian.
///	</summary>
public static class Illusionist2024Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "illusionist");

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
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "illusionist", "en"), Language = LanguageCode.En, Name = "Illusionist", Description = "You have devoted yourself to magic that dazzles the senses and fools the mind; the illusions you shape make the impossible look true." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "illusionist", "it"), Language = LanguageCode.It, Name = "Illusionista", Description = "L'illusionista si è dedicato alla magia che abbaglia i sensi e inganna la mente: le illusioni che plasma fanno sembrare vero l'impossibile." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "illusionist/illusion-savant"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "illusionist/illusion-savant", "en"), Language = LanguageCode.En, Name = "Illusion Savant", Description = "Pick two Wizard spells of the Illusion school, each no higher than level 2, and copy them into your spellbook at no cost.\n\nAlso, each time you unlock a new level of spell slots in this class, you can add one Illusion Wizard spell of a level you have slots for to your spellbook at no cost." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "illusionist/illusion-savant", "it"), Language = LanguageCode.It, Name = "Illusionista Sapiente", Description = "Il mago sceglie due incantesimi da mago della scuola di illusione, ognuno di livello non superiore al 2°, e li aggiunge gratuitamente al suo libro degli incantesimi.\n\nInoltre, ogni volta che ottiene accesso a un nuovo livello di slot incantesimo in questa classe, può aggiungere gratuitamente al libro un incantesimo da mago della scuola di illusione, di un livello per cui possiede slot incantesimo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "illusionist/improved-illusions"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "illusionist/improved-illusions", "en"), Language = LanguageCode.En, Name = "Improved Illusions", Description = "Your Illusion spells need no Verbal components, and any Illusion spell you cast with a range of at least 10 feet reaches 60 feet farther.\n\nYou also learn the *Minor Illusion* cantrip, or another Wizard cantrip of your choice if you already know it; this cantrip doesn't count toward your cantrips known. A single casting of *Minor Illusion* can produce both a sound and an image, and you can cast it as a Bonus Action." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "illusionist/improved-illusions", "it"), Language = LanguageCode.It, Name = "Illusioni Migliorate", Description = "Il mago può lanciare incantesimi di illusione senza fornire componenti verbali e, se un incantesimo di illusione che lancia ha una gittata di almeno 3 metri, la gittata aumenta di 18 metri.\n\nConosce inoltre il trucchetto *illusione minore*; se lo conosce già, impara invece un altro trucchetto da mago a sua scelta. Il trucchetto non conta nel numero di trucchetti conosciuti. Con un solo lancio di *illusione minore* può creare sia un suono sia un'immagine, e può lanciarlo come azione bonus." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "illusionist/phantasmal-creatures"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 6,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "illusionist/phantasmal-creatures", "en"), Language = LanguageCode.En, Name = "Phantasmal Creatures", Description = "*Summon Beast* and *Summon Fey* are always prepared for you. Whenever you cast either one, you can shift its school to Illusion, giving the summoned creature a ghostly look. You can cast the Illusion version of each spell without a spell slot, but the creature then has only half its Hit Points; after casting either spell this way, you need a Long Rest before you can do so again." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "illusionist/phantasmal-creatures", "it"), Language = LanguageCode.It, Name = "Creature Spettrali", Description = "Il mago ha sempre preparati gli incantesimi *richiama bestia* e *richiama folletto*. Ogni volta che lancia uno dei due, può cambiarne la scuola in illusione, facendo apparire spettrale la creatura evocata. Può lanciare la versione illusoria di ciascun incantesimo senza spendere uno slot incantesimo, ma in tal caso i punti ferita della creatura sono dimezzati; dopo aver lanciato uno dei due incantesimi senza slot, deve completare un riposo lungo prima di poterlo lanciare di nuovo in questo modo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "illusionist/illusory-self"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 10,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "illusionist/illusory-self", "en"), Language = LanguageCode.En, Name = "Illusory Self", Description = "When a creature hits you with an attack roll, you can use your Reaction to throw an illusory double of yourself between you and the attacker: the attack misses you automatically, and the double then fades.\n\nAfter using this feature, you need a Short or Long Rest to use it again, though spending a level 2+ spell slot (no action required) restores the use." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "illusionist/illusory-self", "it"), Language = LanguageCode.It, Name = "Sosia Illusorio", Description = "Quando una creatura lo colpisce con un tiro per colpire, il mago può usare una reazione per frapporre tra sé e l'attaccante un duplicato illusorio di se stesso: l'attacco lo manca automaticamente, poi l'illusione si dissolve.\n\nDopo aver usato questo privilegio, non può farlo di nuovo finché non completa un riposo breve o lungo, ma può ripristinarne l'utilizzo spendendo uno slot incantesimo di 2° livello o superiore (nessuna azione richiesta)." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "illusionist/illusory-reality"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 14,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "illusionist/illusory-reality", "en"), Language = LanguageCode.En, Name = "Illusory Reality", Description = "You have learned to blend shadow magic into your illusions, lending them a measure of substance. When you cast an Illusion spell with a spell slot, you can pick one inanimate, nonmagical object that is part of the illusion and make it real; you can do this as a Bonus Action on your turn while the spell lasts. The object stays real for 1 minute, during which it can't deal damage or impose conditions. You could, for instance, conjure an illusory bridge across a chasm, make it real and walk over it." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "illusionist/illusory-reality", "it"), Language = LanguageCode.It, Name = "Realtà Illusoria", Description = "Il mago ha imparato a intrecciare la magia dell'ombra nelle sue illusioni per conferire loro una parvenza di realtà. Quando lancia un incantesimo di illusione con uno slot incantesimo, può scegliere un oggetto inanimato e non magico che fa parte dell'illusione e renderlo reale; può farlo come azione bonus nel suo turno finché l'incantesimo è attivo. L'oggetto rimane reale per 1 minuto, durante il quale non può infliggere danni né imporre condizioni. Per esempio, il mago può creare l'illusione di un ponte sopra un baratro, renderlo reale e attraversarlo." }
					}
				}
			}
		};
	}
}
