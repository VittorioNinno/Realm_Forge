using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	School of Illusion (wizard, 2014 ruleset). Not in the SRD: names and mechanics as in the rules, with descriptions written for RealmForge in English and Italian.
///	</summary>
public static class SchoolOfIllusion2014Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "school-of-illusion");

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
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "school-of-illusion", "en"), Language = LanguageCode.En, Name = "School of Illusion", Description = "Illusionists study magic that dazzles the senses, befuddles the mind and fools even the wisest. Their magic is subtle, but the illusions of a sharp mind can make the impossible seem real. Some illusionists are good-natured tricksters who use their spells to entertain; others are darker masters of deception who frighten and fool others for their own gain." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "school-of-illusion", "it"), Language = LanguageCode.It, Name = "Scuola di Illusione", Description = "Gli illusionisti studiano la magia che abbaglia i sensi, confonde la mente e inganna perfino i più saggi. La loro magia è sottile, ma le illusioni di una mente acuta possono far sembrare reale l'impossibile. Alcuni illusionisti sono burloni bonari che usano i loro incantesimi per intrattenere; altri sono maestri dell'inganno dall'animo più cupo, che spaventano e raggirano il prossimo per il proprio tornaconto." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-illusion/illusion-savant"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 2,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-illusion/illusion-savant", "en"), Language = LanguageCode.En, Name = "Illusion Savant", Description = "From the moment you choose this school at 2nd level, the gold and time you need to copy an illusion spell into your spellbook are halved." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-illusion/illusion-savant", "it"), Language = LanguageCode.It, Name = "Illusionista Sapiente", Description = "Dal momento in cui sceglie questa scuola al 2° livello, l'oro e il tempo necessari al mago per copiare un incantesimo di illusione nel suo libro degli incantesimi sono dimezzati." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-illusion/improved-minor-illusion"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 2,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-illusion/improved-minor-illusion", "en"), Language = LanguageCode.En, Name = "Improved Minor Illusion", Description = "At 2nd level, you learn the *minor illusion* cantrip; if you already know it, you learn a different wizard cantrip of your choice. This cantrip doesn't count against your number of cantrips known. When you cast *minor illusion*, you can create both a sound and an image with a single casting." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-illusion/improved-minor-illusion", "it"), Language = LanguageCode.It, Name = "Illusione Minore Migliorata", Description = "Al 2° livello il mago apprende il trucchetto *illusione minore*; se lo conosce già, apprende un altro trucchetto da mago a sua scelta. Questo trucchetto non conta ai fini del numero di trucchetti conosciuti. Quando lancia *illusione minore*, può creare sia un suono sia un'immagine con un unico lancio." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-illusion/malleable-illusions"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 6,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-illusion/malleable-illusions", "en"), Language = LanguageCode.En, Name = "Malleable Illusions", Description = "From 6th level, when you cast an illusion spell with a duration of 1 minute or longer, you can use your action to change the nature of that illusion, within the spell's normal limits, as long as you can see it." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-illusion/malleable-illusions", "it"), Language = LanguageCode.It, Name = "Illusioni Duttili", Description = "Dal 6° livello, quando lancia un incantesimo di illusione con una durata di 1 minuto o superiore, il mago può usare la sua azione per cambiare la natura di quell'illusione, entro i normali limiti dell'incantesimo, purché sia in grado di vederla." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-illusion/illusory-self"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 10,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-illusion/illusory-self", "en"), Language = LanguageCode.En, Name = "Illusory Self", Description = "From 10th level, you can conjure an illusory double of yourself as a near-instant reaction to danger. When a creature makes an attack roll against you, you can use your reaction to put the double between you and the attacker: the attack automatically misses you, and the illusion fades.\n\nOnce you use this feature, you can't use it again until you finish a short or long rest." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-illusion/illusory-self", "it"), Language = LanguageCode.It, Name = "Sosia Illusorio", Description = "Dal 10° livello, davanti al pericolo il mago è capace di proiettare all'istante una copia illusoria di sé. Se una creatura tenta un tiro per colpire contro di lui, il mago spende la reazione per porre il suo doppio sulla traiettoria del colpo: l'attacco va automaticamente a vuoto e l'immagine si dissolve.\n\nDopo averlo usato, il mago potrà ricorrere di nuovo a questo privilegio solo dopo un riposo breve o lungo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-illusion/illusory-reality"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 14,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-illusion/illusory-reality", "en"), Language = LanguageCode.En, Name = "Illusory Reality", Description = "At 14th level, you learn to weave shadow magic into your illusions to give them a touch of reality. When you cast an illusion spell of 1st level or higher, you can pick one inanimate, nonmagical object that is part of the illusion and make it real. You do so as a bonus action on your turn while the spell lasts, and the object stays real for 1 minute. For example, you could create an illusory bridge over a chasm and make it real long enough for your allies to cross.\n\nThe object can't deal damage or directly harm anyone." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-illusion/illusory-reality", "it"), Language = LanguageCode.It, Name = "Realtà Illusoria", Description = "Al 14° livello il mago impara a intrecciare la magia dell'ombra nelle sue illusioni per conferire loro un tocco di realtà. Quando lancia un incantesimo di illusione di 1° livello o superiore, può scegliere un oggetto inanimato e non magico che fa parte dell'illusione e renderlo reale. Lo fa come azione bonus nel suo turno finché l'incantesimo dura, e l'oggetto rimane reale per 1 minuto. Per esempio, potrebbe creare l'illusione di un ponte su un baratro e renderla reale abbastanza a lungo da permettere ai suoi alleati di attraversarlo.\n\nL'oggetto non può infliggere danni né ferire direttamente nessuno." }
					}
				}
			}
		};
	}
}
