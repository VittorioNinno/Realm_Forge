using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.BackgroundsData;

///	<summary>
///	Urchin (2014 ruleset). Not part of SRD 5.1: English and Italian texts are written for RealmForge, keeping the
///	official game terms and mechanics. The urchin gains no languages.
///	</summary>
public static class Urchin2014Seeder
{
	public static readonly Guid BackgroundId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "background", "urchin");

	public static Background Build()
	{
		return new Background
		{
			Id = BackgroundId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			SkillProficiencies = new List<Skill> { Skill.SleightOfHand, Skill.Stealth },
			Translations = new List<BackgroundTranslation>
			{
				new BackgroundTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "background", "urchin", "en"),
					Language = LanguageCode.En,
					Name = "Urchin",
					Description = "You grew up on the streets, alone, orphaned, and poor. With nobody to look after you or provide for you, you learned to fend for yourself. You fought hard for every scrap of food and kept a constant eye on the other desperate souls who might rob you. You slept on rooftops and in alleys, at the mercy of the weather, and lived through illness with no medicine and no place to recover. Against all odds you survived, thanks to your cunning, your strength, your speed, or some mix of all three.\n\n### A Better Life\nYou start your adventuring career with enough money to live modestly but safely for at least ten days. How did you come by that money? What allowed you to escape your desperate circumstances and set out toward a better life?",
					ToolProficiencies = "Disguise kit, thieves' tools",
					Equipment = "A small knife\nA map of the city you grew up in\nA pet mouse\nA token to remember your parents by\nA set of common clothes\nA belt pouch containing 10 gp",
					FeatureName = "City Secrets",
					FeatureDescription = "You know the hidden rhythms and currents of cities, and you can find paths through the urban sprawl that others would miss. When you are not in combat, you (and any companions you lead) can travel between any two places in the city twice as fast as your speed would normally allow.",
					CharacteristicsIntro = "Urchins are shaped by a life of desperate poverty, for better and for worse. They are usually driven either by loyalty to the people they shared street life with, or by a burning desire to find a better life, and perhaps to get even with all the rich folk who treated them badly.",
					PersonalityTraits = new List<string>
					{
						"I stash scraps of food and trinkets in my pockets.",
						"I ask a lot of questions.",
						"I like squeezing into tight spots where nobody else can reach me.",
						"I sleep with my back to a wall or a tree, hugging everything I own in a bundle.",
						"I eat like a pig and have terrible manners.",
						"I assume anyone who is kind to me is hiding bad intentions.",
						"I don't like to bathe.",
						"I bluntly say what other people only hint at or keep to themselves."
					},
					Ideals = new List<string>
					{
						"Respect. Everyone, rich or poor, deserves respect. (Good)",
						"Community. We have to look after each other, because nobody else will. (Lawful)",
						"Change. The lowly are raised up and the mighty are brought low. Change is the way of things. (Chaotic)",
						"Retribution. The rich need to be shown what life and death are like in the gutter. (Evil)",
						"People. I help those who help me: that is how we stay alive. (Neutral)",
						"Aspiration. I am going to prove that I deserve a better life. (Any)"
					},
					Bonds = new List<string>
					{
						"My town or city is my home, and I will fight to defend it.",
						"I support an orphanage so that others won't have to go through what I went through.",
						"I owe my survival to another urchin who taught me how to live on the streets.",
						"I owe a debt I can never repay to the person who took pity on me.",
						"I escaped poverty by robbing an important person, and I am wanted for it.",
						"Nobody else should have to suffer the hardships I have suffered."
					},
					Flaws = new List<string>
					{
						"If I am outnumbered, I flee the fight.",
						"Gold looks like a fortune to me, and I will do almost anything to get more of it.",
						"I will never fully trust anyone but myself.",
						"I would rather kill someone in their sleep than fight fair.",
						"It isn't stealing if I need it more than they do.",
						"People who can't look after themselves get what they deserve."
					}
				},
				new BackgroundTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "background", "urchin", "it"),
					Language = LanguageCode.It,
					Name = "Monello",
					Description = "Il monello è cresciuto per strada, solo, orfano e povero. Senza nessuno che si occupasse di lui o provvedesse ai suoi bisogni, ha imparato a cavarsela da sé. Ha lottato con le unghie e con i denti per ogni boccone e ha sempre tenuto d'occhio le altre anime disperate che avrebbero potuto derubarlo. Ha dormito sui tetti e nei vicoli, in balia delle intemperie, e ha superato le malattie senza medicine né un posto dove rimettersi in forze. Contro ogni previsione è sopravvissuto, grazie alla sua astuzia, alla sua forza, alla sua velocità o a un insieme di queste doti.\n\n### Una vita migliore\nIl monello inizia la sua carriera da avventuriero con denaro sufficiente per vivere in modo modesto ma sicuro per almeno dieci giorni. Come se l'è procurato? Che cosa gli ha permesso di uscire dalla sua condizione disperata e di partire verso una vita migliore?",
					ToolProficiencies = "Arnesi da scasso, trucchi per il camuffamento",
					Equipment = "Un coltellino\nUna mappa della città in cui è cresciuto\nUn topolino addomesticato\nUn ricordo dei suoi genitori\nUn abito comune\nUna borsa con 10 mo",
					FeatureName = "Segreti Cittadini",
					FeatureDescription = "Il monello conosce i ritmi e i flussi nascosti delle città e sa trovare, nel groviglio urbano, passaggi che agli altri sfuggirebbero. Quando non è in combattimento, lui (e i compagni che guida) può spostarsi tra due luoghi qualsiasi della città due volte più rapidamente di quanto gli consentirebbe la sua velocità normale.",
					CharacteristicsIntro = "I monelli sono plasmati da una vita di povertà disperata, nel bene e nel male. Di solito sono spinti dalla lealtà verso le persone con cui hanno condiviso la vita di strada, oppure dal desiderio bruciante di una vita migliore, e magari di prendersi una rivincita su tutti i ricchi che li hanno trattati male.",
					PersonalityTraits = new List<string>
					{
						"Nasconde nelle tasche avanzi di cibo e ninnoli.",
						"Fa un sacco di domande.",
						"Gli piace infilarsi in posti stretti dove nessun altro può raggiungerlo.",
						"Dorme con le spalle contro un muro o un albero, stringendo tra le braccia un fagotto con tutto ciò che possiede.",
						"Mangia come un maiale e ha pessime maniere.",
						"Pensa che chiunque sia gentile con lui nasconda cattive intenzioni.",
						"Non gli piace lavarsi.",
						"Dice senza mezzi termini ciò che gli altri si limitano ad accennare o tengono per sé."
					},
					Ideals = new List<string>
					{
						"Rispetto. Tutti, ricchi o poveri, meritano rispetto. (Buono)",
						"Comunità. Dobbiamo prenderci cura gli uni degli altri, perché nessun altro lo farà. (Legale)",
						"Cambiamento. Gli umili vengono innalzati e i potenti vengono abbattuti. Il cambiamento è nella natura delle cose. (Caotico)",
						"Rivalsa. Ai ricchi va mostrato com'è la vita, e la morte, nei bassifondi. (Malvagio)",
						"Persone. Aiuta chi lo aiuta: è così che si resta vivi. (Neutrale)",
						"Aspirazione. Dimostrerà di meritare una vita migliore. (Qualsiasi)"
					},
					Bonds = new List<string>
					{
						"Il suo paese o la sua città è la sua casa, e combatterà per difenderla.",
						"Sostiene un orfanotrofio perché altri non debbano subire ciò che ha subito lui.",
						"Deve la sua sopravvivenza a un altro monello che gli ha insegnato a vivere per strada.",
						"Ha un debito che non potrà mai saldare con la persona che ha avuto pietà di lui.",
						"È uscito dalla miseria derubando una persona importante, ed è ricercato per questo.",
						"Nessun altro dovrebbe patire le difficoltà che ha patito lui."
					},
					Flaws = new List<string>
					{
						"Se è in inferiorità numerica, scappa dal combattimento.",
						"L'oro gli sembra una fortuna, e farebbe quasi qualsiasi cosa per averne di più.",
						"Non si fiderà mai completamente di nessuno tranne che di se stesso.",
						"Preferisce uccidere qualcuno nel sonno piuttosto che combattere lealmente.",
						"Non è un furto se a lui serve più che a qualcun altro.",
						"Chi non sa badare a se stesso ha ciò che si merita."
					}
				}
			}
		};
	}
}
