using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Oath of Vengeance (paladin, 2014 ruleset). Not in the SRD: names and mechanics as in the rules, with descriptions written for RealmForge in English and Italian.
///	</summary>
public static class OathOfVengeance2014Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "oath-of-vengeance");

	public static Subclass Build()
	{
		return new Subclass
		{
			Id = SubclassId,
			CharacterClassId = Paladin2014Seeder.ClassId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			CasterProgression = CasterProgression.None,
			SpellcastingAbility = null,
			Translations = new List<SubclassTranslation>
			{
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "oath-of-vengeance", "en"), Language = LanguageCode.En, Name = "Oath of Vengeance", Description = "This oath is a grim promise to punish those guilty of terrible wrongs. When evil slaughters the helpless, when a whole people defies the gods, when a guild of thieves grows too violent or a dragon lays waste to the land, paladins rise and swear vengeance to set things right. For these avengers, sometimes called dark knights, delivering justice matters more than keeping their own hands clean.\n\n**Tenets of Vengeance**\n\nThe exact wording changes from one paladin to the next, but every version is about punishing wrongdoers by whatever means it takes. Many of these paladins are willing to give up their own righteousness to bring evildoers to justice, so they are often neutral or lawful neutral. The core of the oath is brutally simple:\n\n**Fight the Greater Evil.** Given the choice between my sworn foes and a lesser evil, I go after the greater one.\n\n**No Mercy for the Wicked.** Common enemies may earn my mercy; my sworn foes never will.\n\n**By Any Means Necessary.** My doubts will not stand between me and the destruction of my enemies.\n\n**Restitution.** If my foes bring ruin to the world, it is because I failed to stop them, so I must help those they have harmed." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "oath-of-vengeance", "it"), Language = LanguageCode.It, Name = "Giuramento di Vendetta", Description = "Questo giuramento è una cupa promessa di punire i colpevoli di torti terribili. Quando il male massacra gli indifesi, quando un intero popolo sfida gli dèi, quando una gilda di ladri diventa troppo violenta o un drago devasta le terre, i paladini si levano e giurano vendetta per rimettere le cose a posto. Per questi vendicatori, chiamati talvolta cavalieri oscuri, fare giustizia conta più che mantenere pulite le proprie mani.\n\n**Dettami di Vendetta**\n\nLe parole esatte cambiano da un paladino all'altro, ma ogni versione riguarda la punizione dei malvagi con qualsiasi mezzo sia necessario. Molti di questi paladini sono disposti a sacrificare la propria rettitudine pur di consegnare i malvagi alla giustizia, perciò sono spesso neutrali o legali neutrali. Il nucleo del giuramento è brutalmente semplice:\n\n**Combattere il Male Peggiore.** Se devo scegliere tra i miei nemici giurati e un male minore, inseguo il male peggiore.\n\n**Nessuna Pietà per i Malvagi.** I nemici comuni possono guadagnarsi la mia pietà; i miei nemici giurati mai.\n\n**Costi Quel Che Costi.** I miei dubbi non si frapporranno tra me e la distruzione dei miei nemici.\n\n**Risarcimento.** Se i miei nemici portano rovina nel mondo, è perché non sono riuscito a fermarli, perciò devo aiutare chi hanno danneggiato." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "oath-of-vengeance/oath-of-vengeance-spells"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 3,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "oath-of-vengeance/oath-of-vengeance-spells", "en"), Language = LanguageCode.En, Name = "Oath of Vengeance Spells", Description = "You gain these oath spells at the paladin levels shown. See the Sacred Oath class feature for how oath spells work.\n\n| Paladin Level | Spells |\n|---|---|\n| 3rd | bane, hunter's mark |\n| 5th | hold person, misty step |\n| 9th | haste, protection from energy |\n| 13th | banishment, dimension door |\n| 17th | hold monster, scrying |" },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "oath-of-vengeance/oath-of-vengeance-spells", "it"), Language = LanguageCode.It, Name = "Incantesimi del Giuramento di Vendetta", Description = "Il paladino ottiene questi incantesimi di giuramento ai livelli da paladino indicati. Il funzionamento degli incantesimi di giuramento è descritto nel privilegio di classe Giuramento Sacro.\n\n| Livello da paladino | Incantesimi |\n|---|---|\n| 3° | anatema, marchio del cacciatore |\n| 5° | blocca persone, passo velato |\n| 9° | protezione dall'energia, velocità |\n| 13° | esilio, porta dimensionale |\n| 17° | blocca mostri, scrutare |" }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "oath-of-vengeance/channel-divinity-abjure-enemy"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 3,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "oath-of-vengeance/channel-divinity-abjure-enemy", "en"), Language = LanguageCode.En, Name = "Channel Divinity: Abjure Enemy", Description = "When you take this oath at 3rd level, you can use your Channel Divinity, as an action, to raise your holy symbol and denounce a creature you can see within 60 feet of you. Unless it is immune to being frightened, it makes a Wisdom saving throw, with disadvantage if it is a fiend or undead.\n- **Failure.** It is frightened for 1 minute or until it takes any damage; while frightened, its speed is 0 and can't be increased by any bonus.\n- **Success.** Its speed is halved for 1 minute or until it takes any damage." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "oath-of-vengeance/channel-divinity-abjure-enemy", "it"), Language = LanguageCode.It, Name = "Incanalare Divinità: Abiurare Nemico", Description = "Quando presta questo giuramento al 3° livello, il paladino può usare Incanalare Divinità, come azione, per sollevare il suo simbolo sacro e denunciare una creatura entro 18 metri che è in grado di vedere. A meno che non sia immune all'essere spaventata, la creatura effettua un tiro salvezza su Saggezza, con svantaggio se è un immondo o un non morto.\n- **Fallimento.** È spaventata per 1 minuto o finché non subisce danni; finché è spaventata, la sua velocità è 0 e non può essere aumentata da alcun bonus.\n- **Successo.** La sua velocità è dimezzata per 1 minuto o finché non subisce danni." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "oath-of-vengeance/channel-divinity-vow-of-enmity"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 3,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "oath-of-vengeance/channel-divinity-vow-of-enmity", "en"), Language = LanguageCode.En, Name = "Channel Divinity: Vow of Enmity", Description = "Also at 3rd level, you can use your Channel Divinity, as a bonus action, to swear enmity against a creature you can see within 10 feet of you. You have advantage on attack rolls against it for 1 minute, or until it drops to 0 hit points or falls unconscious." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "oath-of-vengeance/channel-divinity-vow-of-enmity", "it"), Language = LanguageCode.It, Name = "Incanalare Divinità: Giuramento di Inimicizia", Description = "Sempre al 3° livello, il paladino può usare Incanalare Divinità, come azione bonus, per giurare inimicizia contro una creatura entro 3 metri che è in grado di vedere. Dispone di vantaggio ai tiri per colpire contro di essa per 1 minuto, o finché la creatura non scende a 0 punti ferita o perde i sensi." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "oath-of-vengeance/relentless-avenger"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 7,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "oath-of-vengeance/relentless-avenger", "en"), Language = LanguageCode.En, Name = "Relentless Avenger", Description = "From 7th level, your focus cuts off your foes' escape. When you hit a creature with an opportunity attack, you can move up to half your speed right after the attack, as part of the same reaction, without provoking opportunity attacks." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "oath-of-vengeance/relentless-avenger", "it"), Language = LanguageCode.It, Name = "Vendicatore Implacabile", Description = "Dal 7° livello la determinazione del paladino taglia la via di fuga ai nemici. Quando colpisce una creatura con un attacco di opportunità, può muoversi fino a metà della sua velocità subito dopo l'attacco, come parte della stessa reazione, senza provocare attacchi di opportunità." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "oath-of-vengeance/soul-of-vengeance"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 15,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "oath-of-vengeance/soul-of-vengeance", "en"), Language = LanguageCode.En, Name = "Soul of Vengeance", Description = "From 15th level, when a creature under your Vow of Enmity makes an attack, you can use your reaction to make a melee weapon attack against it if it is within your reach." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "oath-of-vengeance/soul-of-vengeance", "it"), Language = LanguageCode.It, Name = "Anima di Vendetta", Description = "Dal 15° livello, quando una creatura soggetta al suo Giuramento di Inimicizia effettua un attacco, il paladino può usare la sua reazione per effettuare un attacco con un'arma da mischia contro di essa, se si trova entro la sua portata." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "oath-of-vengeance/avenging-angel"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 20,
					SortOrder = 5,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "oath-of-vengeance/avenging-angel", "en"), Language = LanguageCode.En, Name = "Avenging Angel", Description = "At 20th level, you can use your action to take the form of an angelic avenger for 1 hour, gaining these benefits:\n- Wings sprout from your back, giving you a flying speed of 60 feet.\n- You radiate a menacing aura in a 30-foot radius. The first time an enemy enters the aura or starts its turn there during a battle, it must succeed on a Wisdom saving throw or be frightened of you for 1 minute or until it takes any damage. Attack rolls against a creature frightened this way have advantage.\n\nOnce you use this feature, you can't use it again until you finish a long rest." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "oath-of-vengeance/avenging-angel", "it"), Language = LanguageCode.It, Name = "Angelo Vendicatore", Description = "Al 20° livello il paladino può usare la sua azione per assumere la forma di un vendicatore angelico per 1 ora, ottenendo questi benefici:\n- Dalla sua schiena spuntano delle ali che gli conferiscono una velocità di volare di 18 metri.\n- Emana un'aura minacciosa in un raggio di 9 metri. La prima volta in una battaglia in cui un nemico entra nell'aura o vi inizia il proprio turno, deve superare un tiro salvezza su Saggezza, altrimenti è spaventato dal paladino per 1 minuto o finché non subisce danni. I tiri per colpire contro una creatura spaventata in questo modo hanno vantaggio.\n\nUna volta usato questo privilegio, il paladino non può usarlo di nuovo finché non completa un riposo lungo." }
					}
				}
			}
		};
	}
}
