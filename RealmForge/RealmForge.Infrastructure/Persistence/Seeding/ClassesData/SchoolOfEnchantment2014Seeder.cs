using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	School of Enchantment (wizard, 2014 ruleset). Not in the SRD: names and mechanics as in the rules, with descriptions written for RealmForge in English and Italian.
///	</summary>
public static class SchoolOfEnchantment2014Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "school-of-enchantment");

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
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "school-of-enchantment", "en"), Language = LanguageCode.En, Name = "School of Enchantment", Description = "Enchanters have honed the art of beguiling and charming people and monsters. Some are peacemakers who soothe the violent into lowering their weapons and coax mercy from the cruel; others are tyrants who bend the unwilling to their service. Most fall somewhere between the two." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "school-of-enchantment", "it"), Language = LanguageCode.It, Name = "Scuola di Ammaliamento", Description = "Gli ammaliatori hanno affinato l'arte di sedurre e affascinare persone e mostri. Alcuni sono pacificatori che inducono i violenti ad abbassare le armi e strappano pietà ai crudeli; altri sono tiranni che piegano al proprio servizio chi non vorrebbe servirli. La maggior parte si colloca a metà strada." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-enchantment/enchantment-savant"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 2,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-enchantment/enchantment-savant", "en"), Language = LanguageCode.En, Name = "Enchantment Savant", Description = "From the moment you choose this school at 2nd level, the gold and time you need to copy an enchantment spell into your spellbook are halved." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-enchantment/enchantment-savant", "it"), Language = LanguageCode.It, Name = "Ammaliatore Sapiente", Description = "Dal momento in cui sceglie questa scuola al 2° livello, l'oro e il tempo necessari al mago per copiare un incantesimo di ammaliamento nel suo libro degli incantesimi sono dimezzati." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-enchantment/hypnotic-gaze"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 2,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-enchantment/hypnotic-gaze", "en"), Language = LanguageCode.En, Name = "Hypnotic Gaze", Description = "From 2nd level, your soothing words and fixed gaze can entrance another creature. As an action, choose a creature you can see within 5 feet of you. If it can see or hear you, it must succeed on a Wisdom saving throw against your wizard spell save DC or be charmed by you until the end of your next turn. While charmed this way, its speed drops to 0 and it is incapacitated and visibly dazed.\n\nOn later turns, you can use your action to keep the effect going until the end of your next turn. The effect ends if you move more than 5 feet away from the creature, if it can neither see nor hear you, or if it takes damage.\n\nOnce the effect ends, or if the creature succeeds on its first save against it, you can't use this feature on that creature again until you finish a long rest." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-enchantment/hypnotic-gaze", "it"), Language = LanguageCode.It, Name = "Sguardo Ipnotico", Description = "Dal 2° livello le parole suadenti e lo sguardo fisso del mago possono incantare un'altra creatura. Come azione, il mago sceglie una creatura che è in grado di vedere entro 1,5 metri da lui. Se la creatura può vederlo o sentirlo, deve superare un tiro salvezza su Saggezza contro la CD dei suoi incantesimi da mago, altrimenti è affascinata dal mago fino alla fine del turno successivo del mago. Finché è affascinata in questo modo, la sua velocità scende a 0 ed è incapacitata e visibilmente stordita.\n\nNei turni successivi il mago può usare la sua azione per mantenere l'effetto fino alla fine del suo turno successivo. L'effetto termina se il mago si allontana a più di 1,5 metri dalla creatura, se la creatura non può né vederlo né sentirlo o se subisce danni.\n\nUna volta terminato l'effetto, o se la creatura supera il primo tiro salvezza contro di esso, il mago non può usare di nuovo questo privilegio su quella creatura finché non completa un riposo lungo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-enchantment/instinctive-charm"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 6,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-enchantment/instinctive-charm", "en"), Language = LanguageCode.En, Name = "Instinctive Charm", Description = "From 6th level, when a creature you can see within 30 feet of you makes an attack roll against you, you can use your reaction to divert the attack, as long as another creature is within the attack's range. The attacker makes a Wisdom saving throw against your wizard spell save DC. On a failure, it must target the creature closest to it, other than you or itself; if several creatures are equally close, the attacker chooses. On a success, you can't use this feature on that attacker again until you finish a long rest.\n\nYou must decide to use this feature before knowing whether the attack hits or misses. Creatures that can't be charmed are immune to it." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-enchantment/instinctive-charm", "it"), Language = LanguageCode.It, Name = "Fascino Istintivo", Description = "Dal 6° livello il fascino del mago lo protegge anche d'istinto. Se una creatura visibile a non più di 9 metri sta per attaccarlo e un'altra creatura si trova alla portata dell'attacco, il mago può spendere la reazione per distogliere il colpo. L'attaccante tenta un tiro salvezza su Saggezza contro la CD dei suoi incantesimi da mago: in caso di fallimento, deve invece colpire la creatura a lui più vicina che non sia né il mago né sé stesso (a parità di distanza, la sceglie l'attaccante). In caso di successo, il mago dovrà completare un riposo lungo prima di poter usare di nuovo questo privilegio contro quella stessa creatura.\n\nLa decisione va presa prima che si sappia l'esito dell'attacco. Questo privilegio non ha effetto sulle creature immuni alla condizione di affascinato." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-enchantment/split-enchantment"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 10,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-enchantment/split-enchantment", "en"), Language = LanguageCode.En, Name = "Split Enchantment", Description = "From 10th level, when you cast an enchantment spell of 1st level or higher that targets only one creature, you can have it target a second creature as well." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-enchantment/split-enchantment", "it"), Language = LanguageCode.It, Name = "Ammaliamento Condiviso", Description = "Dal 10° livello, quando lancia un incantesimo di ammaliamento di 1° livello o superiore che bersaglia una sola creatura, il mago può fargli bersagliare anche una seconda creatura." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-enchantment/alter-memories"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 14,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-enchantment/alter-memories", "en"), Language = LanguageCode.En, Name = "Alter Memories", Description = "At 14th level, you can make a creature forget that it fell under your magic. When you cast an enchantment spell to charm one or more creatures, you can alter one creature's perception so that it doesn't realize it is charmed.\n\nIn addition, once before the spell ends, you can use your action to try to erase part of the time the creature spent charmed. It must succeed on an Intelligence saving throw against your wizard spell save DC or lose a number of hours of memories equal to 1 + your Charisma modifier (minimum 1). You can make it forget less time, and the amount can't exceed the duration of your enchantment spell." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-enchantment/alter-memories", "it"), Language = LanguageCode.It, Name = "Alterare Ricordi", Description = "Al 14° livello il mago può far dimenticare a una creatura di essere caduta sotto l'effetto della sua magia. Quando lancia un incantesimo di ammaliamento per affascinare una o più creature, può alterare la percezione di una di esse in modo che non si renda conto di essere affascinata.\n\nInoltre, una volta prima che l'incantesimo termini, può usare la sua azione per tentare di cancellare parte del tempo che la creatura ha trascorso affascinata. La creatura deve superare un tiro salvezza su Intelligenza contro la CD dei suoi incantesimi da mago, altrimenti perde un numero di ore di ricordi pari a 1 + il modificatore di Carisma del mago (minimo 1). Il mago può farle dimenticare meno tempo, e la quantità non può superare la durata del suo incantesimo di ammaliamento." }
					}
				}
			}
		};
	}
}
