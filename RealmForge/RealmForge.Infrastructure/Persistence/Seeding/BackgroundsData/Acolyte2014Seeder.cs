using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.BackgroundsData;

///	<summary>
///	Acolyte (SRD 5.1, 2014 ruleset). English and Italian texts from the System Reference Document 5.1
///	and its official Italian translation, both licensed under CC BY 4.0.
///	</summary>
public static class Acolyte2014Seeder
{
	public static readonly Guid BackgroundId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "background", "acolyte");

	public static Background Build()
	{
		return new Background
		{
			Id = BackgroundId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			SkillProficiencies = new List<Skill> { Skill.Insight, Skill.Religion },
			Translations = new List<BackgroundTranslation>
			{
				new BackgroundTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "background", "acolyte", "en"),
					Language = LanguageCode.En,
					Name = "Acolyte",
					Description = "You have spent your life in the service of a temple to a specific god or pantheon of gods. You act as an intermediary between the realm of the holy and the mortal world, performing sacred rites and offering sacrifices in order to conduct worshipers into the presence of the divine. You are not necessarily a cleric—performing sacred rites is not the same thing as channeling divine power.\n\nChoose a god, a pantheon of gods, or some other quasi-divine being, and work with your DM to detail the nature of your religious service. Were you a lesser functionary in a temple, raised from childhood to assist the priests in the sacred rites? Or were you a high priest who suddenly experienced a call to serve your god in a different way? Perhaps you were the leader of a small cult outside of any established temple structure, or even an occult group that served a fiendish master that you now deny.",
					Languages = "Two of your choice",
					Equipment = "A holy symbol (a gift to you when you entered the priesthood)\nA prayer book or prayer wheel\n5 sticks of incense\nVestments\nA set of common clothes\nA belt pouch containing 15 gp",
					FeatureName = "Shelter of the Faithful",
					FeatureDescription = "As an acolyte, you command the respect of those who share your faith, and you can perform the religious ceremonies of your deity. You and your adventuring companions can expect to receive free healing and care at a temple, shrine, or other established presence of your faith, though you must provide any material components needed for spells. Those who share your religion will support you (but only you) at a modest lifestyle.\n\nYou might also have ties to a specific temple dedicated to your chosen deity or pantheon, and you have a residence there. This could be the temple where you used to serve, if you remain on good terms with it, or a temple where you have found a new home. While near your temple, you can call upon the priests for assistance, provided the assistance you ask for is not hazardous and you remain in good standing with your temple.",
					CharacteristicsIntro = "Acolytes are shaped by their experience in temples or other religious communities. Their study of the history and tenets of their faith and their relationships to temples, shrines, or hierarchies affect their mannerisms and ideals. Their flaws might be some hidden hypocrisy or heretical idea, or an ideal or bond taken to an extreme.",
					PersonalityTraits = new List<string>
					{
						"I idolize a particular hero of my faith, and constantly refer to that person's deeds and example.",
						"I can find common ground between the fiercest enemies, empathizing with them and always working toward peace.",
						"I see omens in every event and action. The gods try to speak to us, we just need to listen.",
						"Nothing can shake my optimistic attitude.",
						"I quote (or misquote) sacred texts and proverbs in almost every situation.",
						"I am tolerant (or intolerant) of other faiths and respect (or condemn) the worship of other gods.",
						"I've enjoyed fine food, drink, and high society among my temple's elite. Rough living grates on me.",
						"I've spent so long in the temple that I have little practical experience dealing with people in the outside world."
					},
					Ideals = new List<string>
					{
						"Tradition. The ancient traditions of worship and sacrifice must be preserved and upheld. (Lawful)",
						"Charity. I always try to help those in need, no matter what the personal cost. (Good)",
						"Change. We must help bring about the changes the gods are constantly working in the world. (Chaotic)",
						"Power. I hope to one day rise to the top of my faith's religious hierarchy. (Lawful)",
						"Faith. I trust that my deity will guide my actions. I have faith that if I work hard, things will go well. (Lawful)",
						"Aspiration. I seek to prove myself worthy of my god's favor by matching my actions against his or her teachings. (Any)"
					},
					Bonds = new List<string>
					{
						"I would die to recover an ancient relic of my faith that was lost long ago.",
						"I will someday get revenge on the corrupt temple hierarchy who branded me a heretic.",
						"I owe my life to the priest who took me in when my parents died.",
						"Everything I do is for the common people.",
						"I will do anything to protect the temple where I served.",
						"I seek to preserve a sacred text that my enemies consider heretical and seek to destroy."
					},
					Flaws = new List<string>
					{
						"I judge others harshly, and myself even more severely.",
						"I put too much trust in those who wield power within my temple's hierarchy.",
						"My piety sometimes leads me to blindly trust those that profess faith in my god.",
						"I am inflexible in my thinking.",
						"I am suspicious of strangers and expect the worst of them.",
						"Once I pick a goal, I become obsessed with it to the detriment of everything else in my life."
					}
				},
				new BackgroundTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "background", "acolyte", "it"),
					Language = LanguageCode.It,
					Name = "Accolito",
					Description = "Un accolito ha passato la sua vita a servire un tempio dedicato a una specifica divinità o un pantheon di divinità. Funge da intermediario tra il reame del sacro e il mondo dei mortali, celebrando riti solenni e offrendo sacrifici al fine di radunare nuovi fedeli presso il suo patrono divino. Non è necessariamente un chierico, in quanto celebrare i riti sacri è ben diverso da incanalare il potere divino.\n\nIl personaggio sceglie un dio, un pantheon di divinità o un altro essere semi-divino e si accorda con il DM per definire in dettaglio la natura del suo servizio religioso. Era un funzionario minore in un tempio, dove è stato cresciuto fin dall'infanzia per assistere i sacerdoti nei loro riti? Oppure è un sommo sacerdote che improvvisamente ha udito un richiamo che lo ha spinto a servire il suo dio in modo diverso? Forse era il capo di un piccolo culto al di fuori delle strutture tradizionali del tempio, o addirittura di un gruppo occulto al servizio di un padrone immondo che ora l'accolito ha rinnegato.",
					Languages = "Due a scelta",
					Equipment = "Un simbolo sacro (donatogli quando è stato ordinato come sacerdote)\nUn libro di preghiere o una ruota della preghiera\n5 bastoncini di incenso\nVesti\nUn abito comune\nUna borsa con 15 mo",
					FeatureName = "Rifugio dei Fedeli",
					FeatureDescription = "Un accolito gode del rispetto di coloro che condividono la sua fede ed è in grado di celebrare le cerimonie religiose della sua divinità. L'accolito e gli avventurieri suoi compagni possono aspettarsi di ricevere cure e guarigioni gratuite presso un tempio, un santuario o un'altra presenza stabile della sua fede, anche se dovrà fornire le eventuali componenti richieste per gli incantesimi. Coloro che condividono la sua religione lo manterranno (limitandosi soltanto a lui) offrendogli uno stile di vita modesto.\n\nUn accolito potrebbe anche avere dei legami con un tempio specifico dedicato alla divinità o al pantheon di sua scelta, e beneficiare di una dimora presso quel tempio. Potrebbe trattarsi dello stesso tempio dove aveva prestato servizio in passato, se è rimasto in buoni rapporti con i fedeli del posto, oppure di un tempio dove ha trovato accoglienza recentemente. Finché si trova nei pressi del suo tempio, l'accolito può chiedere aiuto ai sacerdoti, purché quell'aiuto non comporti pericoli ed egli goda di una buona reputazione presso il tempio.",
					CharacteristicsIntro = "Gli accoliti sono plasmati dalle loro esperienze nei templi o nelle altre comunità religiose. I loro studi storici e i dettami della loro fede, assieme al rapporto che hanno con templi, santuari o gerarchie, ne influenzano il modo di fare e gli ideali. Come difetti potrebbero nascondere qualche ipocrisia o pensiero eretico, oppure sviluppare un ideale o un legame fino a portarlo all'estremo.",
					PersonalityTraits = new List<string>
					{
						"L'accolito venera un particolare eroe della sua fede e si ispira continuamente alle sue gesta e al suo esempio.",
						"L'accolito è in grado di trovare punti in comune perfino tra due acerrimi nemici, riuscendo a fraternizzare con loro e adoperandosi sempre per una soluzione pacifica.",
						"L'accolito riesce a vedere presagi in ogni evento e gesto. Ritiene che gli dèi cerchino continuamente di parlare ai mortali, e che i mortali debbano soltanto imparare ad ascoltarli.",
						"Nulla riesce a minare l'ottimismo dell'accolito.",
						"L'accolito cita (non necessariamente con esattezza) i testi sacri e i proverbi pressoché in ogni situazione.",
						"L'accolito è tollerante (o intollerante) nei confronti delle altre fedi e rispetta (o disprezza) il culto degli altri dèi.",
						"Frequentando gli alti funzionari del suo tempio, l'accolito ha goduto dei piaceri del buon cibo e del buon vino e si è inserito nell'alta società. La povertà lo mette a disagio.",
						"L'accolito ha passato così tanto tempo all'interno del tempio che oggi ha qualche difficoltà a interagire con gli altri esseri umani nel mondo esterno."
					},
					Ideals = new List<string>
					{
						"Tradizione. Le antiche tradizioni di preghiera e sacrificio devono essere conservate e sostenute. (Legale)",
						"Carità. L'accolito cerca sempre di aiutare i bisognosi e non esita a sacrificarsi personalmente. (Buono)",
						"Cambiamento. L'accolito deve contribuire alla diffusione dei mutamenti che gli dèi operano costantemente nel mondo. (Caotico)",
						"Potere. L'accolito spera di riuscire un giorno a raggiungere le posizioni più elevate della gerarchia della sua chiesa. (Legale)",
						"Fede. L'accolito è profondamente convinto che la sua divinità guidi le sue scelte. Crede quindi che se si impegnerà a fondo, le cose non potranno che andare bene. (Legale)",
						"Ambizione. L'accolito cerca di dimostrarsi degno del favore della sua divinità e interviene per correggere le azioni che vanno contro i suoi insegnamenti. (Qualsiasi)"
					},
					Bonds = new List<string>
					{
						"L'accolito morirebbe pur di recuperare un'antica reliquia della sua fede, perduta da molto tempo.",
						"L'accolito cerca vendetta contro i corrotti ministri del suo tempio che lo accusarono di eresia.",
						"L'accolito deve la vita al sacerdote che lo fece entrare nel tempio alla morte dei suoi genitori.",
						"Tutto ciò che l'accolito fa, lo fa per la gente comune.",
						"L'accolito farà qualunque cosa pur di proteggere il tempio in cui ha servito.",
						"L'accolito cerca di proteggere un testo sacro che i suoi nemici considerano invece eretico e cercano di distruggere."
					},
					Flaws = new List<string>
					{
						"L'accolito giudica gli altri con durezza, e se stesso ancora più severamente.",
						"L'accolito si affida totalmente e acriticamente a quelli che detengono il potere all'interno del suo tempio.",
						"La religiosità dell'accolito lo induce a volte a credere ciecamente a coloro che professano la sua stessa fede.",
						"L'accolito è inflessibile.",
						"L'accolito non si fida degli sconosciuti e si aspetta sempre il peggio da essi.",
						"Quando l'accolito si prefigge un obiettivo, ne è ossessionato fino a ignorare ogni altro aspetto della sua vita."
					}
				}
			}
		};
	}
}
