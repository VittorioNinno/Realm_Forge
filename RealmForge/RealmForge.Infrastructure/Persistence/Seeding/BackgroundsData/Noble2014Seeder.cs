using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.BackgroundsData;

///	<summary>
///	Noble (2014 ruleset), with the Knight variant and the Retainers variant feature. Not part of SRD 5.1: English
///	and Italian texts are written for RealmForge, keeping the official game terms and mechanics.
///	</summary>
public static class Noble2014Seeder
{
	public static readonly Guid BackgroundId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "background", "noble");

	public static Background Build()
	{
		return new Background
		{
			Id = BackgroundId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			SkillProficiencies = new List<Skill> { Skill.History, Skill.Persuasion },
			Translations = new List<BackgroundTranslation>
			{
				new BackgroundTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "background", "noble", "en"),
					Language = LanguageCode.En,
					Name = "Noble",
					Description = "You know what wealth, power, and privilege mean. You hold a noble title, and your family owns land, collects taxes, and carries real political weight. You might be a pampered aristocrat who has never known work or hardship, a former merchant newly raised to the nobility, or a disinherited rogue who still believes the world owes them everything. Or you might be an honest, hard-working landowner who truly cares for the people living and working on your land and knows what you owe them.\n\n### Title and Family\nAgree with your DM on a suitable title and on how much authority it carries. A noble title never stands alone: it belongs to a whole family, and whatever title you hold, you will one day pass it to your children. Besides your title, work with your DM to describe your family and the influence it has on you.\n\n- Is your family an old, established line, or was the title granted only recently? How much influence does it have, and over what territory? What reputation does it have among the other aristocrats of the region, and how do the common people see it?\n- What is your place in the family? Are you the heir of the head of the house, or have you already inherited the title? How do you feel about that responsibility? Or are you so far down the line of succession that nobody cares what you do, as long as you don't embarrass the family? What does the head of the family think of your adventuring life? Are you in the family's good graces, or kept at arm's length?\n- Does your family have a coat of arms, an emblem you might wear on a signet ring, colors you always wear, or an animal seen as the symbol of your line, perhaps even as a spiritual member of the family?\n\nThese details help make your family and your title part of the campaign world.\n\n### Variant: Knight\nIn most societies knighthood is one of the lowest noble titles, but it can lead to higher rank. If you want to be a knight, take the Retainers feature instead of Position of Privilege. One of your commoner retainers is replaced by a noble who serves as your squire, helping you in exchange for training on the road to their own knighthood. Your other two retainers might be a groom who looks after your horse and a servant who polishes your armor (and perhaps helps you put it on).\n\nAs a symbol of chivalry and the ideals of courtly love, your equipment might include a banner or another token from a noble lord or lady to whom you have given your heart, in a chaste devotion. That person could be your bond.\n\n### Variant Feature: Retainers\nA character with the noble background can choose this feature instead of Position of Privilege.\n\nYou are served by three retainers loyal to your family. They can be attendants or messengers, and one of them might be a majordomo. Your retainers are commoners who handle ordinary tasks for you, but they don't fight for you, won't follow you into clearly dangerous places (such as dungeons), and will leave if they are often put in danger or mistreated.",
					ToolProficiencies = "One type of gaming set",
					Languages = "One of your choice",
					Equipment = "A set of fine clothes\nA signet ring\nA scroll of pedigree\nA purse containing 25 gp",
					FeatureName = "Position of Privilege",
					FeatureDescription = "Thanks to your noble birth, people tend to think well of you. You are welcome in high society, and people assume you have every right to be wherever you are. Common folk do their best to accommodate you and avoid your displeasure, and other people of high birth treat you as one of their own. If you need to, you can secure an audience with a local noble.",
					CharacteristicsIntro = "Nobles are born and raised to a way of life very few people ever know, and their personalities show it. A noble title brings a web of bonds: duties to family, to other nobles (the sovereign included), to the people entrusted to the family's care, and even to the title itself. Yet these same duties are often the best way to bring a noble down.",
					PersonalityTraits = new List<string>
					{
						"My elegant flattery makes whoever I speak with feel like the most wonderful and important person in the world.",
						"The common folk love me for my kindness and generosity.",
						"One look at my regal bearing and nobody could doubt that I stand far above the unwashed masses.",
						"I go to great lengths to always look my best and follow the latest fashions.",
						"I hate getting my hands dirty, and I wouldn't be caught dead in unworthy lodgings.",
						"Despite my noble birth, I don't consider myself above anyone. We all have the same blood.",
						"Once you lose my favor, you lose it forever.",
						"Wrong me and I will crush you, ruin your name, and salt your fields."
					},
					Ideals = new List<string>
					{
						"Respect. My position earns me respect, but everyone, whatever their rank, deserves to be treated with dignity. (Good)",
						"Responsibility. I must respect the authority of those above me, just as those below me must respect mine. (Lawful)",
						"Independence. I must prove that I can manage on my own, without my family coddling me. (Chaotic)",
						"Power. If I gain more power, nobody will tell me what to do. (Evil)",
						"Family. Blood is thicker than water. (Any)",
						"Noble Obligation. It is my duty to protect and care for the people beneath me. (Good)"
					},
					Bonds = new List<string>
					{
						"I will face any challenge to earn my family's approval.",
						"My house's alliance with another noble family must be upheld at any cost.",
						"Nothing matters more than the other members of my family.",
						"I am in love with the heir of a family that mine despises.",
						"My loyalty to my sovereign never wavers.",
						"The common folk must see me as a hero of the people."
					},
					Flaws = new List<string>
					{
						"Deep down I believe everyone is beneath me.",
						"I hide a truly scandalous secret that could ruin my family forever.",
						"I hear veiled insults and threats in far too many of the words spoken to me, and I am quick to anger.",
						"My hunger for the pleasures of the flesh is insatiable.",
						"The truth is, the world really does revolve around me.",
						"My words and deeds often bring shame on my family."
					}
				},
				new BackgroundTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "background", "noble", "it"),
					Language = LanguageCode.It,
					Name = "Nobile",
					Description = "Il nobile sa che cosa significano ricchezza, potere e privilegio. Detiene un titolo nobiliare e la sua famiglia possiede terre, riscuote tasse ed esercita un peso politico considerevole. Potrebbe essere un aristocratico viziato che non ha mai conosciuto la fatica né il disagio, un ex mercante appena elevato alla nobiltà o una canaglia diseredata convinta che il mondo le debba ancora tutto. Oppure potrebbe essere un proprietario terriero onesto e laborioso, che ha davvero a cuore le persone che vivono e lavorano sulle sue terre e sa quali doveri ha verso di loro.\n\n### Titolo e famiglia\nIl giocatore concorda con il DM un titolo adeguato e il grado di autorità che comporta. Un titolo nobiliare non è mai isolato: appartiene a un'intera famiglia, e qualunque titolo detenga il personaggio un giorno lo trasmetterà ai suoi figli. Oltre al titolo, il giocatore definisce con il DM la famiglia del personaggio e l'influenza che esercita su di lui.\n\n- La famiglia è un'antica stirpe consolidata, o il titolo è stato concesso solo di recente? Quanta influenza ha, e su quale territorio? Che reputazione ha presso gli altri aristocratici della regione, e come la vede la gente comune?\n- Che posto occupa il personaggio nella famiglia? È l'erede del capofamiglia, o ha già ereditato il titolo? Che cosa prova di fronte a questa responsabilità? Oppure è così in basso nella linea di successione che a nessuno importa ciò che fa, purché non metta in imbarazzo la famiglia? Che cosa pensa il capofamiglia della sua vita da avventuriero? È nelle grazie della famiglia, o viene tenuto a distanza?\n- La famiglia ha uno stemma, un emblema da portare su un anello con sigillo, dei colori che indossa sempre, o un animale considerato il simbolo della stirpe, forse perfino un membro spirituale della famiglia?\n\nQuesti dettagli aiutano a fare della famiglia e del titolo una parte del mondo della campagna.\n\n### Variante: Cavaliere\nNella maggior parte delle società il cavalierato è uno dei titoli nobiliari più bassi, ma può aprire la strada a ranghi più alti. Se il personaggio vuole essere un cavaliere, sceglie il privilegio Servitù al posto di Posizione Privilegiata. Uno dei popolani al suo servizio è sostituito da un nobile che gli fa da scudiero e lo aiuta in cambio dell'addestramento che lo porterà a diventare a sua volta cavaliere. Gli altri due servitori potrebbero essere un palafreniere che si occupa del suo cavallo e un servitore che gli lucida l'armatura (e magari lo aiuta a indossarla).\n\nCome simbolo della cavalleria e degli ideali dell'amor cortese, il suo equipaggiamento potrebbe comprendere uno stendardo o un altro pegno di un nobile signore o di una dama a cui ha donato il proprio cuore, in una devozione casta. Quella persona potrebbe essere il suo legame.\n\n### Privilegio Alternativo: Servitù\nUn personaggio con il background del nobile può scegliere questo privilegio al posto di Posizione Privilegiata.\n\nIl nobile è servito da tre servitori fedeli alla sua famiglia. Possono essere attendenti o messaggeri, e uno di loro potrebbe essere un maggiordomo. I servitori sono popolani che svolgono per lui compiti ordinari, ma non combattono per lui, non lo seguono in luoghi palesemente pericolosi (come i dungeon) e se ne vanno se vengono messi spesso in pericolo o maltrattati.",
					ToolProficiencies = "Un tipo di set da gioco",
					Languages = "Uno a scelta",
					Equipment = "Un abito pregiato\nUn anello con sigillo\nUna pergamena con l'albero genealogico\nUna borsa con 25 mo",
					FeatureName = "Posizione Privilegiata",
					FeatureDescription = "Grazie ai suoi nobili natali, la gente tende a pensare bene di lui. Il nobile è benvenuto nell'alta società, e tutti danno per scontato che abbia pieno diritto di trovarsi ovunque si trovi. I popolani fanno del loro meglio per accontentarlo ed evitare di contrariarlo, e le altre persone di alto lignaggio lo trattano come uno di loro. Se ne ha bisogno, può ottenere udienza presso un nobile locale.",
					CharacteristicsIntro = "I nobili nascono e crescono in uno stile di vita che pochissimi conoscono, e la loro personalità lo dimostra. Un titolo nobiliare porta con sé una rete di legami: doveri verso la famiglia, verso gli altri nobili (sovrano compreso), verso le persone affidate alla famiglia e perfino verso il titolo stesso. Eppure proprio questi doveri sono spesso il modo migliore per far cadere un nobile.",
					PersonalityTraits = new List<string>
					{
						"Le sue lusinghe eleganti fanno sentire chiunque gli parli la persona più meravigliosa e importante del mondo.",
						"La gente comune lo ama per la sua gentilezza e generosità.",
						"Basta uno sguardo al suo portamento regale perché nessuno dubiti che sia molto al di sopra del volgo.",
						"Fa di tutto per apparire sempre al meglio e seguire l'ultima moda.",
						"Detesta sporcarsi le mani, e non si farebbe mai vedere in un alloggio indegno di lui.",
						"Nonostante i suoi nobili natali, non si sente superiore a nessuno. Il sangue è uguale per tutti.",
						"Chi perde il suo favore lo perde per sempre.",
						"Chi gli fa un torto verrà schiacciato: rovinerà il suo nome e cospargerà di sale i suoi campi."
					},
					Ideals = new List<string>
					{
						"Rispetto. La sua posizione gli vale rispetto, ma tutti, a prescindere dal rango, meritano di essere trattati con dignità. (Buono)",
						"Responsabilità. Deve rispettare l'autorità di chi gli sta sopra, così come chi gli sta sotto deve rispettare la sua. (Legale)",
						"Indipendenza. Deve dimostrare di sapersela cavare da solo, senza le premure della famiglia. (Caotico)",
						"Potere. Se otterrà più potere, nessuno potrà dirgli cosa fare. (Malvagio)",
						"Famiglia. Il sangue non è acqua. (Qualsiasi)",
						"Obbligo nobiliare. È suo dovere proteggere e prendersi cura delle persone sotto di lui. (Buono)"
					},
					Bonds = new List<string>
					{
						"Affronterà qualunque sfida pur di ottenere l'approvazione della sua famiglia.",
						"L'alleanza del suo casato con un'altra famiglia nobile va mantenuta a ogni costo.",
						"Niente conta più degli altri membri della sua famiglia.",
						"È innamorato dell'erede di una famiglia che la sua disprezza.",
						"La sua lealtà verso il sovrano non vacilla mai.",
						"La gente comune deve vederlo come un eroe del popolo."
					},
					Flaws = new List<string>
					{
						"In cuor suo crede che tutti gli siano inferiori.",
						"Nasconde un segreto davvero scandaloso che potrebbe rovinare per sempre la sua famiglia.",
						"Coglie insulti velati e minacce in troppe delle parole che gli vengono rivolte, e si arrabbia facilmente.",
						"La sua brama per i piaceri della carne è insaziabile.",
						"La verità è che il mondo gira davvero intorno a lui.",
						"Con le sue parole e le sue azioni getta spesso vergogna sulla sua famiglia."
					}
				}
			}
		};
	}
}
