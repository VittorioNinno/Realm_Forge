using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Way of the Open Hand (monk, 2014 ruleset). SRD text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class WayOfTheOpenHand2014Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "way-of-the-open-hand");

	public static Subclass Build()
	{
		return new Subclass
		{
			Id = SubclassId,
			CharacterClassId = Monk2014Seeder.ClassId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			CasterProgression = CasterProgression.None,
			SpellcastingAbility = null,
			Translations = new List<SubclassTranslation>
			{
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "way-of-the-open-hand", "en"), Language = LanguageCode.En, Name = "Way of the Open Hand", Description = "Monks of the Way of the Open Hand are the ultimate masters of martial arts combat, whether armed or unarmed. They learn techniques to push and trip their opponents, manipulate ki to heal damage to their bodies, and practice advanced meditation that can protect them from harm." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "way-of-the-open-hand", "it"), Language = LanguageCode.It, Name = "Via della Mano Aperta", Description = "I monaci della Via della Mano Aperta sono i maestri supremi del combattimento marziale, armato o disarmato. Apprendono tecniche per spingere e sbilanciare gli avversari, manipolano il ki per guarire le ferite del proprio corpo e praticano una meditazione avanzata che può proteggerli dal pericolo." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "way-of-the-open-hand/open-hand-technique"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 3,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "way-of-the-open-hand/open-hand-technique", "en"), Language = LanguageCode.En, Name = "Open Hand Technique", Description = "Starting when you choose this tradition at 3rd level, you can manipulate your enemy's ki when you harness your own.\n\nWhenever you hit a creature with one of the attacks granted by your Flurry of Blows, you can impose one of the following effects on that target:\n- It must succeed on a Dexterity saving throw or be knocked prone.\n- It must make a Strength saving throw. If it fails, you can push it up to 15 feet away from you.\n- It can't take reactions until the end of your next turn." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "way-of-the-open-hand/open-hand-technique", "it"), Language = LanguageCode.It, Name = "Tecnica della Mano Aperta", Description = "A partire dal momento in cui sceglie questa tradizione al 3° livello, quando imbriglia il proprio ki il monaco può manipolare quello dei nemici.\n\nOgni volta che colpisce una creatura con uno degli attacchi concessi da Raffica di Colpi, può imporre al bersaglio uno degli effetti seguenti:\n- Deve superare un tiro salvezza su Destrezza, altrimenti cade prono.\n- Deve effettuare un tiro salvezza su Forza. Se lo fallisce, il monaco può spingerlo fino a 4,5 metri lontano da sé.\n- Non può effettuare reazioni fino alla fine del turno successivo del monaco." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "way-of-the-open-hand/wholeness-of-body"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 6,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "way-of-the-open-hand/wholeness-of-body", "en"), Language = LanguageCode.En, Name = "Wholeness of Body", Description = "At 6th level, you gain the ability to heal yourself. As an action, you can regain hit points equal to three times your monk level. You must finish a long rest before you can use this feature again." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "way-of-the-open-hand/wholeness-of-body", "it"), Language = LanguageCode.It, Name = "Integrità del Corpo", Description = "Al 6° livello il monaco ottiene la capacità di guarire se stesso. Come azione, può recuperare punti ferita pari a tre volte il suo livello da monaco. Deve completare un riposo lungo prima di poter usare di nuovo questo privilegio." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "way-of-the-open-hand/tranquility"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 11,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "way-of-the-open-hand/tranquility", "en"), Language = LanguageCode.En, Name = "Tranquility", Description = "Beginning at 11th level, you can enter a special meditation that surrounds you with an aura of peace. At the end of a long rest, you gain the effect of a *sanctuary* spell that lasts until the start of your next long rest (the spell can end early as normal). The saving throw DC for the spell equals 8 + your Wisdom modifier + your proficiency bonus." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "way-of-the-open-hand/tranquility", "it"), Language = LanguageCode.It, Name = "Tranquillità", Description = "A partire dall'11° livello, il monaco può entrare in una speciale meditazione che lo circonda di un'aura di pace. Al termine di un riposo lungo, ottiene l'effetto di un incantesimo *santuario* che dura fino all'inizio del suo riposo lungo successivo (l'incantesimo può terminare prima come di consueto). La CD del tiro salvezza dell'incantesimo è pari a 8 + il modificatore di Saggezza del monaco + il suo bonus di competenza." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "way-of-the-open-hand/quivering-palm"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 17,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "way-of-the-open-hand/quivering-palm", "en"), Language = LanguageCode.En, Name = "Quivering Palm", Description = "At 17th level, you gain the ability to set up lethal vibrations in someone's body. When you hit a creature with an unarmed strike, you can spend 3 ki points to start these imperceptible vibrations, which last for a number of days equal to your monk level. The vibrations are harmless unless you use your action to end them. To do so, you and the target must be on the same plane of existence. When you use this action, the creature must make a Constitution saving throw. If it fails, it is reduced to 0 hit points. If it succeeds, it takes 10d10 necrotic damage.\n\nYou can have only one creature under the effect of this feature at a time. You can choose to end the vibrations harmlessly without using an action." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "way-of-the-open-hand/quivering-palm", "it"), Language = LanguageCode.It, Name = "Palmo Tremante", Description = "Al 17° livello il monaco ottiene la capacità di innescare vibrazioni letali nel corpo di qualcuno. Quando colpisce una creatura con un colpo senz'armi, può spendere 3 punti ki per avviare queste vibrazioni impercettibili, che durano un numero di giorni pari al suo livello da monaco. Le vibrazioni sono innocue finché il monaco non usa la sua azione per porvi fine. Per farlo, il monaco e il bersaglio devono trovarsi sullo stesso piano di esistenza. Quando usa questa azione, la creatura deve effettuare un tiro salvezza su Costituzione. Se lo fallisce, scende a 0 punti ferita. Se lo supera, subisce 10d10 danni necrotici.\n\nIl monaco può avere soltanto una creatura alla volta sotto l'effetto di questo privilegio. Può scegliere di porre fine alle vibrazioni senza effetti nocivi e senza usare un'azione." }
					}
				}
			}
		};
	}
}
