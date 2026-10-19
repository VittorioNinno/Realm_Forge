using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Path of the Berserker (barbarian, 2014 ruleset). SRD text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class PathOfTheBerserker2014Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "path-of-the-berserker");

	public static Subclass Build()
	{
		return new Subclass
		{
			Id = SubclassId,
			CharacterClassId = Barbarian2014Seeder.ClassId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			CasterProgression = CasterProgression.None,
			SpellcastingAbility = null,
			Translations = new List<SubclassTranslation>
			{
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "path-of-the-berserker", "en"), Language = LanguageCode.En, Name = "Path of the Berserker", Description = "For some barbarians, rage is a means to an end—that end being violence. The Path of the Berserker is a path of untrammeled fury, slick with blood. As you enter the berserker's rage, you thrill in the chaos of battle, heedless of your own health or well-being." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "path-of-the-berserker", "it"), Language = LanguageCode.It, Name = "Cammino del Berserker", Description = "Per alcuni barbari l'ira è un mezzo per raggiungere un fine, e quel fine è la violenza. Il Cammino del Berserker è una strada di furia sfrenata, intrisa di sangue. Quando entra nell'ira del berserker, il barbaro si esalta nel caos della battaglia, incurante della propria salute e del proprio benessere." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "path-of-the-berserker/frenzy"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 3,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "path-of-the-berserker/frenzy", "en"), Language = LanguageCode.En, Name = "Frenzy", Description = "Starting when you choose this path at 3rd level, you can go into a frenzy when you Rage. If you do so, for the duration of your rage you can make a single melee weapon attack as a bonus action on each of your turns after this one. When your rage ends, you suffer one level of exhaustion." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "path-of-the-berserker/frenzy", "it"), Language = LanguageCode.It, Name = "Frenesia", Description = "A partire dal momento in cui sceglie questo cammino al 3° livello, quando entra in ira il barbaro può scatenare una frenesia. Se lo fa, per la durata dell'ira può effettuare un singolo attacco con un'arma da mischia come azione bonus in ognuno dei suoi turni successivi a quello. Quando l'ira termina, subisce un livello di indebolimento." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "path-of-the-berserker/mindless-rage"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 6,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "path-of-the-berserker/mindless-rage", "en"), Language = LanguageCode.En, Name = "Mindless Rage", Description = "Beginning at 6th level, you can't be charmed or frightened while raging. If you are charmed or frightened when you enter your Rage, the effect is suspended for the duration of the rage." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "path-of-the-berserker/mindless-rage", "it"), Language = LanguageCode.It, Name = "Ira Incontenibile", Description = "A partire dal 6° livello, il barbaro non può essere affascinato o spaventato mentre è in ira. Se è affascinato o spaventato quando entra in ira, l'effetto è sospeso per la durata dell'ira." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "path-of-the-berserker/intimidating-presence"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 10,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "path-of-the-berserker/intimidating-presence", "en"), Language = LanguageCode.En, Name = "Intimidating Presence", Description = "Beginning at 10th level, you can use your action to frighten someone with your menacing presence.\n\nWhen you do so, choose one creature that you can see within 30 feet of you. If the creature can see or hear you, it must succeed on a Wisdom saving throw (DC equal to 8 + your proficiency bonus + your Charisma modifier) or be frightened of you until the end of your next turn. On subsequent turns, you can use your action to extend the duration of this effect on the frightened creature until the end of your next turn. This effect ends if the creature ends its turn out of line of sight or more than 60 feet away from you.\n\nIf the creature succeeds on its saving throw, you can't use this feature on that creature again for 24 hours." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "path-of-the-berserker/intimidating-presence", "it"), Language = LanguageCode.It, Name = "Presenza Intimidatoria", Description = "A partire dal 10° livello, il barbaro può usare la sua azione per spaventare qualcuno con la propria presenza minacciosa.\n\nIn questo caso, sceglie una creatura entro 9 metri da lui che è in grado di vedere. Se la creatura è in grado di vederlo o di sentirlo, deve superare un tiro salvezza su Saggezza (CD pari a 8 + il bonus di competenza del barbaro + il suo modificatore di Carisma), altrimenti è spaventata dal barbaro fino alla fine del turno successivo di quest'ultimo. Nei turni successivi, il barbaro può usare la sua azione per prolungare la durata di questo effetto sulla creatura spaventata fino alla fine del proprio turno successivo. L'effetto termina se la creatura conclude il proprio turno fuori dalla linea di vista del barbaro o a più di 18 metri da lui.\n\nSe la creatura supera il tiro salvezza, il barbaro non può usare di nuovo questo privilegio su di essa per 24 ore." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "path-of-the-berserker/retaliation"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 14,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "path-of-the-berserker/retaliation", "en"), Language = LanguageCode.En, Name = "Retaliation", Description = "Starting at 14th level, when you take damage from a creature that is within 5 feet of you, you can use your reaction to make a melee weapon attack against that creature." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "path-of-the-berserker/retaliation", "it"), Language = LanguageCode.It, Name = "Ritorsione", Description = "A partire dal 14° livello, quando subisce danni da una creatura che si trova entro 1,5 metri da lui, il barbaro può usare la sua reazione per effettuare un attacco con un'arma da mischia contro quella creatura." }
					}
				}
			}
		};
	}
}
