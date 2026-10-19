using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Oath of Devotion (paladin, 2014 ruleset). SRD text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class OathOfDevotion2014Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "oath-of-devotion");

	public static Subclass Build()
	{
		return new Subclass
		{
			Id = SubclassId,
			CharacterClassId = Paladin2014Seeder.ClassId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			CasterProgression = CasterProgression.None,
			SpellcastingAbility = null,
			Translations = new List<SubclassTranslation>
			{
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "oath-of-devotion", "en"), Language = LanguageCode.En, Name = "Oath of Devotion", Description = "The Oath of Devotion binds a paladin to the loftiest ideals of justice, virtue, and order. Sometimes called cavaliers, white knights, or holy warriors, these paladins meet the ideal of the knight in shining armor, acting with honor in pursuit of justice and the greater good. They hold themselves to the highest standards of conduct, and some, for better or worse, hold the rest of the world to the same standards. Many who swear this oath are devoted to gods of law and good and use their gods' tenets as the measure of their devotion. They hold angels—the perfect servants of good—as their ideals, and incorporate images of angelic wings into their helmets or coats of arms. \n\n**Tenets of Devotion**\n\nThough the exact words and strictures of the Oath of Devotion vary, paladins of this oath share these tenets.\n\n**Honesty.** Don't lie or cheat. Let your word be your promise.\n\n**Courage.** Never fear to act, though caution is wise.\n\n**Compassion.** Aid others, protect the weak, and punish those who threaten them. Show mercy to your foes, but temper it with wisdom.\n\n**Honor.** Treat others with fairness, and let your honorable deeds be an example to them. Do as much good as possible while causing the least amount of harm.\n\n**Duty.** Be responsible for your actions and their consequences, protect those entrusted to your care, and obey those who have just authority over you." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "oath-of-devotion", "it"), Language = LanguageCode.It, Name = "Giuramento di Devozione", Description = "Il Giuramento di Devozione vincola il paladino ai più alti ideali di giustizia, virtù e ordine. Chiamati a volte cavalieri, cavalieri bianchi o guerrieri santi, questi paladini incarnano l'ideale del cavaliere dalla scintillante armatura, agendo con onore nel perseguire la giustizia e il bene superiore. Si attengono ai più alti standard di condotta, e alcuni, nel bene o nel male, pretendono gli stessi standard dal resto del mondo. Molti di coloro che prestano questo giuramento sono devoti agli dèi della legge e del bene e usano i dettami dei loro dèi come metro della propria devozione. Considerano gli angeli, servitori perfetti del bene, come il loro ideale e ne riprendono le ali nelle decorazioni dei loro elmi o dei loro stemmi.\n\n**Dettami di Devozione**\n\nSebbene le parole esatte e i precetti del Giuramento di Devozione varino, i paladini di questo giuramento condividono questi dettami.\n\n**Onestà.** Non mentire né imbrogliare. Che la tua parola sia la tua promessa.\n\n**Coraggio.** Non avere mai paura di agire, anche se la prudenza è saggia.\n\n**Compassione.** Aiuta gli altri, proteggi i deboli e punisci chi li minaccia. Mostra pietà ai tuoi nemici, ma temperala con la saggezza.\n\n**Onore.** Tratta gli altri con equità, e fa' che le tue azioni onorevoli siano per loro un esempio. Fai quanto più bene possibile causando il minor danno possibile.\n\n**Dovere.** Sii responsabile delle tue azioni e delle loro conseguenze, proteggi chi è affidato alle tue cure e obbedisci a chi ha una giusta autorità su di te." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "oath-of-devotion/oath-of-devotion-spells"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 3,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "oath-of-devotion/oath-of-devotion-spells", "en"), Language = LanguageCode.En, Name = "Oath of Devotion Spells", Description = "You gain oath spells at the paladin levels listed. See the Sacred Oath class feature for how oath spells work.\n\n| Paladin Level | Spells |\n|---|---|\n| 3rd | protection from evil and good, sanctuary |\n| 5th | lesser restoration, zone of truth |\n| 9th | beacon of hope, dispel magic |\n| 13th | freedom of movement, guardian of faith |\n| 17th | commune, flame strike |" },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "oath-of-devotion/oath-of-devotion-spells", "it"), Language = LanguageCode.It, Name = "Incantesimi del Giuramento di Devozione", Description = "Il paladino ottiene gli incantesimi di giuramento ai livelli da paladino indicati. Il funzionamento degli incantesimi di giuramento è descritto nel privilegio di classe Giuramento Sacro.\n\n| Livello da paladino | Incantesimi |\n|---|---|\n| 3° | protezione dal bene e dal male, santuario |\n| 5° | ristorare inferiore, zona di verità |\n| 9° | dissolvi magie, faro di speranza |\n| 13° | guardiano della fede, libertà di movimento |\n| 17° | colpo infuocato, comunione |" }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "oath-of-devotion/channel-divinity-sacred-weapon"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 3,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "oath-of-devotion/channel-divinity-sacred-weapon", "en"), Language = LanguageCode.En, Name = "Channel Divinity: Sacred Weapon", Description = "As an action, you can imbue one weapon that you are holding with positive energy, using your Channel Divinity.\n\nFor 1 minute, you add your Charisma modifier to attack rolls made with that weapon (with a minimum bonus of +1). The weapon also emits bright light in a 20-foot radius and dim light 20 feet beyond that. If the weapon is not already magical, it becomes magical for the duration.\n\nYou can end this effect on your turn as part of any other action. If you are no longer holding or carrying this weapon, or if you fall unconscious, this effect ends." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "oath-of-devotion/channel-divinity-sacred-weapon", "it"), Language = LanguageCode.It, Name = "Incanalare Divinità: Arma Consacrata", Description = "Come azione, il paladino può infondere energia positiva in un'arma che impugna, usando Incanalare Divinità.\n\nPer 1 minuto, aggiunge il suo modificatore di Carisma ai tiri per colpire effettuati con quell'arma (con un bonus minimo di +1). L'arma emana inoltre luce intensa in un raggio di 6 metri e luce fioca per altri 6 metri. Se l'arma non è già magica, diventa magica per la durata.\n\nIl paladino può porre fine a questo effetto nel proprio turno come parte di qualsiasi altra azione. Se non impugna né trasporta più quell'arma, o se perde i sensi, l'effetto termina." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "oath-of-devotion/channel-divinity-turn-the-unholy"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 3,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "oath-of-devotion/channel-divinity-turn-the-unholy", "en"), Language = LanguageCode.En, Name = "Channel Divinity: Turn the Unholy", Description = "As an action, you present your holy symbol and speak a prayer censuring fiends and undead, using your Channel Divinity. Each fiend or undead that can see or hear you within 30 feet of you must make a Wisdom saving throw. If the creature fails its saving throw, it is turned for 1 minute or until it takes damage.\n\nA turned creature must spend its turns trying to move as far away from you as it can, and it can't willingly move to a space within 30 feet of you. It also can't take reactions. For its action, it can use only the Dash action or try to escape from an effect that prevents it from moving. If there's nowhere to move, the creature can use the Dodge action." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "oath-of-devotion/channel-divinity-turn-the-unholy", "it"), Language = LanguageCode.It, Name = "Incanalare Divinità: Scacciare i Sacrileghi", Description = "Come azione, il paladino presenta il suo simbolo sacro e pronuncia una preghiera di condanna contro immondi e non morti, usando Incanalare Divinità. Ogni immondo o non morto entro 9 metri da lui che è in grado di vederlo o di sentirlo deve effettuare un tiro salvezza su Saggezza. Se lo fallisce, la creatura è scacciata per 1 minuto o finché non subisce danni.\n\nUna creatura scacciata deve passare i suoi turni cercando di allontanarsi il più possibile dal paladino e non può spostarsi volontariamente in uno spazio entro 9 metri da lui. Inoltre non può effettuare reazioni. Come azione può usare soltanto l'azione di Scatto o cercare di liberarsi da un effetto che le impedisce di muoversi. Se non ha alcun posto in cui muoversi, la creatura può usare l'azione di Schivata." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "oath-of-devotion/aura-of-devotion"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 7,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "oath-of-devotion/aura-of-devotion", "en"), Language = LanguageCode.En, Name = "Aura of Devotion", Description = "Starting at 7th level, you and friendly creatures within 10 feet of you can't be charmed while you are conscious.\n\nAt 18th level, the range of this aura increases to 30 feet." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "oath-of-devotion/aura-of-devotion", "it"), Language = LanguageCode.It, Name = "Aura di Devozione", Description = "A partire dal 7° livello, il paladino e le creature amiche entro 3 metri da lui non possono essere affascinati finché il paladino è cosciente.\n\nAl 18° livello il raggio di questa aura aumenta a 9 metri." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "oath-of-devotion/purity-of-spirit"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 15,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "oath-of-devotion/purity-of-spirit", "en"), Language = LanguageCode.En, Name = "Purity of Spirit", Description = "Beginning at 15th level, you are always under the effects of a *protection from evil and good* spell." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "oath-of-devotion/purity-of-spirit", "it"), Language = LanguageCode.It, Name = "Purezza di Spirito", Description = "A partire dal 15° livello, il paladino è sempre sotto gli effetti di un incantesimo *protezione dal bene e dal male*." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "oath-of-devotion/holy-nimbus"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 20,
					SortOrder = 5,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "oath-of-devotion/holy-nimbus", "en"), Language = LanguageCode.En, Name = "Holy Nimbus", Description = "At 20th level, as an action, you can emanate an aura of sunlight. For 1 minute, bright light shines from you in a 30-foot radius, and dim light shines 30 feet beyond that. Whenever an enemy creature starts its turn in the bright light, the creature takes 10 radiant damage.\n\nIn addition, for the duration, you have advantage on saving throws against spells cast by fiends or undead.\n\nOnce you use this feature, you can't use it again until you finish a long rest." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "oath-of-devotion/holy-nimbus", "it"), Language = LanguageCode.It, Name = "Nube Sacra", Description = "Al 20° livello, come azione, il paladino può emanare un'aura di luce solare. Per 1 minuto, una luce intensa si irradia da lui in un raggio di 9 metri, e una luce fioca per altri 9 metri. Ogni volta che una creatura nemica inizia il proprio turno nella luce intensa, subisce 10 danni radiosi.\n\nInoltre, per la durata, il paladino dispone di vantaggio ai tiri salvezza contro gli incantesimi lanciati da immondi o non morti.\n\nUna volta usato questo privilegio, il paladino non può usarlo di nuovo finché non completa un riposo lungo." }
					}
				}
			}
		};
	}
}
