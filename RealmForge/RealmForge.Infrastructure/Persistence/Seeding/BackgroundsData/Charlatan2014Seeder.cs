using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.BackgroundsData;

///	<summary>
///	Charlatan (2014 ruleset). Not part of SRD 5.1: English and Italian texts are written for RealmForge,
///	keeping the official game terms and mechanics.
///	</summary>
public static class Charlatan2014Seeder
{
	public static readonly Guid BackgroundId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "background", "charlatan");

	public static Background Build()
	{
		return new Background
		{
			Id = BackgroundId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			SkillProficiencies = new List<Skill> { Skill.Deception, Skill.SleightOfHand },
			Translations = new List<BackgroundTranslation>
			{
				new BackgroundTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "background", "charlatan", "en"),
					Language = LanguageCode.En,
					Name = "Charlatan",
					Description = "People have always been easy for you to read. A few minutes of small talk and a couple of well-placed questions are enough to learn what someone longs for, and you have never been shy about turning that knowledge to your own profit.\n\nYou give people exactly what they want, or at least you promise to. Anyone sensible should be wary of offers that sound too good to be true, yet good sense tends to vanish when you start talking. A vial of pink liquid that will clear up any rash, a salve of lard and silver dust that brings back the bloom of youth, a city bridge that happens to be up for sale: none of it should be believable, but in your hands it all sounds like a bargain.\n\n### Favorite Schemes\nEvery charlatan has a con they come back to more than any other. Choose one or roll on the table.\n\n| d6 | Scheme |\n|---|---|\n| 1 | I cheat at games of chance. |\n| 2 | I clip coins or forge documents. |\n| 3 | I worm my way into people's lives, exploit their weaknesses, and take their fortunes. |\n| 4 | I change identities as easily as I change clothes. |\n| 5 | I work sleight-of-hand cons on street corners. |\n| 6 | I convince people that worthless junk is worth their hard-earned coin. |",
					ToolProficiencies = "Disguise kit, forgery kit",
					Equipment = "A set of fine clothes, a disguise kit, the tools of your favorite con (ten stoppered bottles of colored liquid, a set of weighted dice, a deck of marked cards, or a signet ring of an imaginary duke), and a belt pouch containing 15 gp",
					FeatureName = "False Identity",
					FeatureDescription = "You keep a second identity ready to use, complete with papers, acquaintances who will vouch for it, and the disguises needed to play the part. You can also forge documents, from official papers to personal letters, as long as you have seen an example of the kind of document or of the handwriting you want to copy.",
					CharacteristicsIntro = "Charlatans are colorful characters who hide their real selves behind masks of their own making, showing people what they want to see and believe. Behind the act, many are troubled by a guilty conscience, an old enemy, or a deep inability to trust anyone.",
					PersonalityTraits = new List<string>
					{
						"I fall in and out of love in a heartbeat, and I am always chasing someone new.",
						"I have a joke ready for every moment, especially the ones where nobody should be laughing.",
						"Flattery is my favorite way of getting what I want.",
						"I am a gambler at heart and can never pass up a risk that might pay off.",
						"I lie about nearly everything, even when the truth would serve me just as well.",
						"Sarcasm and insults are my weapons of choice.",
						"I carry several holy symbols and call on whichever god seems most useful at the moment.",
						"Anything that looks valuable tends to end up in my pockets."
					},
					Ideals = new List<string>
					{
						"Independence. I am a free spirit, and nobody tells me what to do. (Chaotic)",
						"Fairness. I never con people who can't afford to lose a few coins. (Lawful)",
						"Charity. I share what I take with the people who truly need it. (Good)",
						"Creativity. I never pull the same con twice. (Chaotic)",
						"Friendship. Riches come and go; the bonds of friendship last forever. (Good)",
						"Aspiration. I am determined to become someone who matters. (Any)"
					},
					Bonds = new List<string>
					{
						"I swindled the wrong person, and I must make sure they never cross paths with me or anyone I care about.",
						"I owe everything to my mentor, a terrible person who is probably rotting in a prison somewhere.",
						"Somewhere out there I have a child who doesn't know me, and I am trying to make the world better for them.",
						"I was born into a noble family, and one day I will take back the lands and title that were stolen from us.",
						"Someone powerful killed a person I loved, and one day soon I will have my revenge.",
						"I conned and ruined someone who didn't deserve it. I am trying to make amends, though I may never forgive myself."
					},
					Flaws = new List<string>
					{
						"I am helpless before a pretty face.",
						"I am always in debt, spending my ill-gotten gains on luxuries faster than I can earn them.",
						"I am sure nobody could ever fool me the way I fool others.",
						"My greed is dangerous even to me: if there is money involved, I can't resist the risk.",
						"I can't help trying to swindle people who are more powerful than I am.",
						"I hate to admit it, and I hate myself for it, but when things get rough I run to save my own skin."
					}
				},
				new BackgroundTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "background", "charlatan", "it"),
					Language = LanguageCode.It,
					Name = "Ciarlatano",
					Description = "Per il ciarlatano le persone sono sempre state facili da leggere. Pochi minuti di chiacchiere e un paio di domande ben piazzate gli bastano per scoprire ciò che il suo interlocutore desidera, e non si è mai fatto scrupoli a sfruttare questa conoscenza a proprio vantaggio.\n\nIl ciarlatano offre alla gente esattamente ciò che vuole, o almeno promette di farlo. Chiunque abbia un po' di buon senso dovrebbe diffidare delle offerte troppo belle per essere vere, eppure il buon senso sembra svanire quando il ciarlatano comincia a parlare. Una boccetta di liquido rosa che fa sparire qualsiasi irritazione, un unguento di strutto e polvere d'argento che restituisce la freschezza della giovinezza, un ponte in città che guarda caso è in vendita: nulla di tutto ciò dovrebbe sembrare credibile, ma nelle sue mani diventa un affare imperdibile.\n\n### Truffe preferite\nOgni ciarlatano ha una truffa a cui ricorre più spesso delle altre. Il giocatore ne sceglie una o tira sulla tabella.\n\n| d6 | Truffa |\n|---|---|\n| 1 | Bara ai giochi d'azzardo. |\n| 2 | Lima monete o falsifica documenti. |\n| 3 | Si insinua nella vita degli altri, ne sfrutta le debolezze e si impossessa delle loro fortune. |\n| 4 | Cambia identità con la stessa facilità con cui cambia d'abito. |\n| 5 | Mette in scena truffe di destrezza agli angoli delle strade. |\n| 6 | Convince la gente che una cianfrusaglia senza valore vale tutti i suoi sudati risparmi. |",
					ToolProficiencies = "Arnesi da falsario, trucchi per il camuffamento",
					Equipment = "Un abito pregiato, trucchi per il camuffamento, gli strumenti della sua truffa preferita (dieci bottiglie sigillate piene di un liquido colorato, un set di dadi truccati, un mazzo di carte segnate o un anello con sigillo di un duca immaginario) e una borsa contenente 15 mo",
					FeatureName = "Falsa Identità",
					FeatureDescription = "Il ciarlatano ha sempre pronta una seconda identità, completa di documenti, conoscenti disposti a garantire per lui e dei travestimenti necessari a interpretarla. Sa inoltre falsificare documenti, dalle carte ufficiali alle lettere personali, purché abbia visto un esempio del tipo di documento o della calligrafia che vuole imitare.",
					CharacteristicsIntro = "I ciarlatani sono personaggi pittoreschi che nascondono la loro vera natura dietro maschere create da loro stessi, mostrando alla gente ciò che vuole vedere e credere. Dietro la recita, molti sono tormentati da una coscienza sporca, da un vecchio nemico o da una profonda incapacità di fidarsi del prossimo.",
					PersonalityTraits = new List<string>
					{
						"Si innamora e si disinnamora in un attimo, ed è sempre a caccia di una nuova fiamma.",
						"Ha una battuta pronta per ogni momento, soprattutto per quelli in cui nessuno dovrebbe ridere.",
						"L'adulazione è il suo modo preferito per ottenere ciò che vuole.",
						"È un giocatore d'azzardo nell'animo e non sa rinunciare a un rischio che potrebbe ripagarlo.",
						"Mente su quasi tutto, anche quando la verità gli servirebbe altrettanto bene.",
						"Il sarcasmo e l'insulto sono le sue armi preferite.",
						"Porta con sé diversi simboli sacri e invoca la divinità che al momento gli sembra più utile.",
						"Tutto ciò che sembra di valore tende a finire nelle sue tasche."
					},
					Ideals = new List<string>
					{
						"Indipendenza. È uno spirito libero e nessuno può dirgli cosa fare. (Caotico)",
						"Equità. Non truffa mai chi non può permettersi di perdere qualche moneta. (Legale)",
						"Carità. Divide ciò che prende con chi ne ha davvero bisogno. (Buono)",
						"Creatività. Non mette mai a segno due volte la stessa truffa. (Caotico)",
						"Amicizia. Le ricchezze vanno e vengono; i legami d'amicizia durano per sempre. (Buono)",
						"Ambizione. È determinato a diventare qualcuno che conta. (Qualsiasi)"
					},
					Bonds = new List<string>
					{
						"Ha truffato la persona sbagliata e deve fare in modo che non incroci mai più la strada sua o di chi ama.",
						"Deve tutto al suo mentore, una persona terribile che probabilmente sta marcendo in qualche prigione.",
						"Da qualche parte ha un figlio che non lo conosce, e cerca di rendere il mondo migliore per lui.",
						"È nato in una famiglia nobile e un giorno si riprenderà le terre e il titolo che gli sono stati sottratti.",
						"Qualcuno di potente ha ucciso una persona che amava, e presto avrà la sua vendetta.",
						"Ha truffato e rovinato qualcuno che non se lo meritava. Cerca di rimediare, anche se forse non riuscirà mai a perdonarsi."
					},
					Flaws = new List<string>
					{
						"Non sa resistere a un bel viso.",
						"È sempre pieno di debiti e spende i suoi guadagni illeciti in lussi più in fretta di quanto riesca a procurarseli.",
						"È convinto che nessuno potrà mai ingannarlo come lui inganna gli altri.",
						"La sua avidità è pericolosa persino per lui: se c'è di mezzo del denaro, non sa resistere al rischio.",
						"Non riesce a trattenersi dal truffare chi è più potente di lui.",
						"Odia ammetterlo, e si odia per questo, ma quando le cose si mettono male scappa per salvarsi la pelle."
					}
				}
			}
		};
	}
}
