using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Life Domain (cleric, 2014 ruleset). SRD text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class LifeDomain2014Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "life-domain");

	public static Subclass Build()
	{
		return new Subclass
		{
			Id = SubclassId,
			CharacterClassId = Cleric2014Seeder.ClassId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			CasterProgression = CasterProgression.None,
			SpellcastingAbility = null,
			Translations = new List<SubclassTranslation>
			{
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "life-domain", "en"), Language = LanguageCode.En, Name = "Life Domain", Description = "The Life domain focuses on the vibrant positive energy—one of the fundamental forces of the universe—that sustains all life. The gods of life promote vitality and health through healing the sick and wounded, caring for those in need, and driving away the forces of death and undeath. Almost any non-evil deity can claim influence over this domain, particularly agricultural deities (such as Chauntea, Arawai, and Demeter), sun gods (such as Lathander, Pelor, and Re-Horakhty), gods of healing or endurance (such as Ilmater, Mishakal, Apollo, and Diancecht), and gods of home and community (such as Hestia, Hathor, and Boldrei)." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "life-domain", "it"), Language = LanguageCode.It, Name = "Dominio della Vita", Description = "Il dominio della Vita è incentrato sulla vibrante energia positiva, una delle forze fondamentali dell'universo, che sostiene ogni forma di vita. Gli dèi della vita promuovono vitalità e salute guarendo i malati e i feriti, prendendosi cura dei bisognosi e scacciando le forze della morte e della non morte. Quasi ogni divinità non malvagia può rivendicare un'influenza su questo dominio, in particolare le divinità dell'agricoltura (come Chauntea, Arawai e Demetra), gli dèi del sole (come Lathander, Pelor e Ra-Horakhty), gli dèi della guarigione o della resistenza (come Ilmater, Mishakal, Apollo e Diancecht) e gli dèi della casa e della comunità (come Estia, Hathor e Boldrei)." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "life-domain/life-domain-spells"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 1,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "life-domain/life-domain-spells", "en"), Language = LanguageCode.En, Name = "Life Domain Spells", Description = "You gain domain spells at the cleric levels listed in the Life Domain Spells table. See the Divine Domain class feature for how domain spells work.\n\n| Cleric Level | Spells |\n|---|---|\n| 1st | bless, cure wounds |\n| 3rd | lesser restoration, spiritual weapon |\n| 5th | beacon of hope, revivify |\n| 7th | death ward, guardian of faith |\n| 9th | mass cure wounds, raise dead |" },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "life-domain/life-domain-spells", "it"), Language = LanguageCode.It, Name = "Incantesimi del Dominio della Vita", Description = "Il chierico ottiene incantesimi di dominio ai livelli da chierico indicati nella tabella degli incantesimi del Dominio della Vita. Il funzionamento degli incantesimi di dominio è descritto nel privilegio di classe Dominio Divino.\n\n| Livello da chierico | Incantesimi |\n|---|---|\n| 1° | benedizione, cura ferite |\n| 3° | arma spirituale, ristorare inferiore |\n| 5° | faro di speranza, rinascita |\n| 7° | guardiano della fede, interdizione alla morte |\n| 9° | cura ferite di massa, rianimare morti |" }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "life-domain/bonus-proficiency"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 1,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "life-domain/bonus-proficiency", "en"), Language = LanguageCode.En, Name = "Bonus Proficiency", Description = "When you choose this domain at 1st level, you gain proficiency with heavy armor." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "life-domain/bonus-proficiency", "it"), Language = LanguageCode.It, Name = "Competenza Bonus", Description = "Quando sceglie questo dominio al 1° livello, il chierico ottiene competenza nelle armature pesanti." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "life-domain/disciple-of-life"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 1,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "life-domain/disciple-of-life", "en"), Language = LanguageCode.En, Name = "Disciple of Life", Description = "Starting at 1st level, your healing spells are more effective.\n\nWhenever you use a spell of 1st level or higher to restore hit points to a creature, the creature regains additional hit points equal to 2 + the spell's level." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "life-domain/disciple-of-life", "it"), Language = LanguageCode.It, Name = "Discepolo della Vita", Description = "A partire dal 1° livello, gli incantesimi di guarigione del chierico sono più efficaci.\n\nOgni volta che il chierico usa un incantesimo di 1° livello o superiore per ripristinare punti ferita a una creatura, quella creatura recupera punti ferita aggiuntivi pari a 2 + il livello dell'incantesimo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "life-domain/channel-divinity-preserve-life"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 2,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "life-domain/channel-divinity-preserve-life", "en"), Language = LanguageCode.En, Name = "Channel Divinity: Preserve Life", Description = "Starting at 2nd level, you can use your Channel Divinity to heal the badly injured.\n\nAs an action, you present your holy symbol and evoke healing energy that can restore a number of hit points equal to five times your cleric level.\n\nChoose any creatures within 30 feet of you, and divide those hit points among them. This feature can restore a creature to no more than half of its hit point maximum. You can't use this feature on an undead or a construct." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "life-domain/channel-divinity-preserve-life", "it"), Language = LanguageCode.It, Name = "Incanalare Divinità: Preservare Vita", Description = "A partire dal 2° livello, il chierico può usare Incanalare Divinità per guarire chi è gravemente ferito.\n\nCome azione, il chierico presenta il suo simbolo sacro ed evoca un'energia curativa in grado di ripristinare un numero di punti ferita pari a cinque volte il suo livello da chierico.\n\nSceglie qualsiasi creatura entro 9 metri da lui e divide quei punti ferita tra di esse. Questo privilegio non può riportare una creatura oltre la metà del suo massimo dei punti ferita. Il chierico non può usare questo privilegio su un non morto o su un costrutto." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "life-domain/blessed-healer"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 6,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "life-domain/blessed-healer", "en"), Language = LanguageCode.En, Name = "Blessed Healer", Description = "Beginning at 6th level, the healing spells you cast on others heal you as well.\n\nWhen you cast a spell of 1st level or higher that restores hit points to a creature other than you, you regain hit points equal to 2 + the spell's level." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "life-domain/blessed-healer", "it"), Language = LanguageCode.It, Name = "Guaritore Benedetto", Description = "A partire dal 6° livello, gli incantesimi di guarigione che il chierico lancia sugli altri guariscono anche lui.\n\nQuando lancia un incantesimo di 1° livello o superiore che ripristina punti ferita a una creatura diversa da lui, il chierico recupera punti ferita pari a 2 + il livello dell'incantesimo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "life-domain/divine-strike"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 8,
					SortOrder = 5,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "life-domain/divine-strike", "en"), Language = LanguageCode.En, Name = "Divine Strike", Description = "At 8th level, you gain the ability to infuse your weapon strikes with divine energy.\n\nOnce on each of your turns when you hit a creature with a weapon attack, you can cause the attack to deal an extra 1d8 radiant damage to the target. When you reach 14th level, the extra damage increases to 2d8." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "life-domain/divine-strike", "it"), Language = LanguageCode.It, Name = "Colpo Divino", Description = "All'8° livello il chierico ottiene la capacità di infondere energia divina nei colpi delle sue armi.\n\nUna volta in ognuno dei suoi turni, quando colpisce una creatura con un attacco con un'arma, può fare in modo che l'attacco infligga al bersaglio 1d8 danni radiosi extra. Quando il chierico raggiunge il 14° livello, i danni extra aumentano a 2d8." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "life-domain/supreme-healing"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 17,
					SortOrder = 6,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "life-domain/supreme-healing", "en"), Language = LanguageCode.En, Name = "Supreme Healing", Description = "Starting at 17th level, when you would normally roll one or more dice to restore hit points with a spell, you instead use the highest number possible for each die. For example, instead of restoring 2d6 hit points to a creature, you restore 12." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "life-domain/supreme-healing", "it"), Language = LanguageCode.It, Name = "Guarigione Suprema", Description = "A partire dal 17° livello, quando normalmente tirerebbe uno o più dadi per ripristinare punti ferita con un incantesimo, il chierico usa invece il risultato massimo possibile per ogni dado. Per esempio, invece di ripristinare 2d6 punti ferita a una creatura, ne ripristina 12." }
					}
				}
			}
		};
	}
}
