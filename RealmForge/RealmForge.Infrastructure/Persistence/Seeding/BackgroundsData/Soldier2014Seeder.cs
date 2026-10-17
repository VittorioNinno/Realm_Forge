using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.BackgroundsData;

///	<summary>
///	Soldier (2014 ruleset). Not part of SRD 5.1: English and Italian texts are written for RealmForge, keeping the
///	official game terms and mechanics. The specialty table uses the same order in both languages, so a roll gives
///	the same result whatever the language. The soldier gains no languages.
///	</summary>
public static class Soldier2014Seeder
{
	public static readonly Guid BackgroundId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "background", "soldier");

	public static Background Build()
	{
		return new Background
		{
			Id = BackgroundId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			SkillProficiencies = new List<Skill> { Skill.Athletics, Skill.Intimidation },
			Translations = new List<BackgroundTranslation>
			{
				new BackgroundTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "background", "soldier", "en"),
					Language = LanguageCode.En,
					Name = "Soldier",
					Description = "War has been your life for as long as you can remember. You trained from a young age, learned to use weapons and armor, and mastered basic survival skills, including how to stay alive on the battlefield. You might have served in a standing national army or a mercenary company, or in a local militia that made a name for itself in a recent war.\n\nWhen you choose this background, work out with your DM which military organization you belonged to, how far you rose through its ranks, and what you lived through during your career. Was it a standing army, a city watch, or a village militia? Or perhaps the private army of a noble or a merchant, or a mercenary company?\n\n### Specialty\nAs a soldier you had a specific role in your unit or army. Choose your role, or roll on the table.\n\n| d8 | Specialty |\n|---|---|\n| 1 | Officer |\n| 2 | Scout |\n| 3 | Infantry |\n| 4 | Cavalry |\n| 5 | Healer |\n| 6 | Quartermaster |\n| 7 | Standard bearer |\n| 8 | Support staff (cook, blacksmith, or the like) |",
					ToolProficiencies = "One type of gaming set, vehicles (land)",
					Equipment = "An insignia of rank\nA trophy taken from a fallen enemy (a dagger, a broken blade, or a piece of a banner)\nA set of bone dice or a deck of cards\nA set of common clothes\nA belt pouch containing 10 gp",
					FeatureName = "Military Rank",
					FeatureDescription = "You hold a military rank from your career as a soldier. Soldiers loyal to your former military organization still recognize your authority and influence, and those of lower rank defer to you. You can use your rank to exert influence over other soldiers and to requisition simple equipment or horses for temporary use. You can usually also gain access to friendly military camps and fortresses where your rank is recognized.",
					CharacteristicsIntro = "The horrors of war and the rigid discipline of military life leave their mark on every soldier: they shape their ideals, forge strong bonds, and often leave scars that make them vulnerable to fear, shame, and hatred.",
					PersonalityTraits = new List<string>
					{
						"I am always polite and respectful.",
						"Memories of war haunt me. I can't get the images of violence out of my head.",
						"I have lost too many friends, and I am slow to make new ones.",
						"My military experience has given me an inspiring or cautionary tale for almost every combat situation.",
						"I can stare down a hell hound without flinching.",
						"I enjoy being strong, and I like breaking things.",
						"I have a crude sense of humor.",
						"I face problems head-on. A simple, direct solution is the best road to success."
					},
					Ideals = new List<string>
					{
						"Greater Good. Our lot is to give our lives in defense of others. (Good)",
						"Responsibility. I do what I must and obey just authority. (Lawful)",
						"Independence. Those who follow orders blindly embrace a kind of tyranny. (Chaotic)",
						"Might. In life as in war, the stronger force wins. (Evil)",
						"Live and Let Live. No ideal is worth killing or going to war for. (Neutral)",
						"Nation. My city, my nation, or my people are all that matter. (Any)"
					},
					Bonds = new List<string>
					{
						"I would still give my life for the people I served with.",
						"Someone saved my life on the battlefield. To this day, I never leave a friend behind.",
						"My honor is my life.",
						"I will never forget the crushing defeat my company suffered, nor the enemies who dealt it.",
						"Those who fight beside me are the ones worth dying for.",
						"I fight for those who cannot fight for themselves."
					},
					Flaws = new List<string>
					{
						"The monstrous enemy we faced in battle still leaves me trembling with fear.",
						"I have little respect for anyone who is not a proven warrior.",
						"I made a terrible mistake in battle that cost many lives, and I would do anything to keep it secret.",
						"My hatred of my enemies is blind and unreasoning.",
						"I obey the law, even when the law causes misery.",
						"I would rather eat my armor than admit I am wrong."
					}
				},
				new BackgroundTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "background", "soldier", "it"),
					Language = LanguageCode.It,
					Name = "Soldato",
					Description = "Per quanto riesca a ricordare, la guerra è sempre stata la vita del soldato. Si è addestrato fin da giovane, ha imparato a usare armi e armature e ha appreso le tecniche di sopravvivenza di base, compreso come restare vivo sul campo di battaglia. Potrebbe aver servito in un esercito nazionale permanente o in una compagnia mercenaria, oppure in una milizia locale che si è fatta un nome durante una guerra recente.\n\nQuando sceglie questo background, il giocatore definisce con il DM a quale organizzazione militare apparteneva il personaggio, fin dove è salito nei suoi ranghi e che cosa ha vissuto durante la sua carriera. Era un esercito permanente, una guardia cittadina o la milizia di un villaggio? O forse l'esercito privato di un nobile o di un mercante, o una compagnia mercenaria?\n\n### Specializzazione\nDurante il servizio il soldato aveva un ruolo preciso nella sua unità o nel suo esercito. Il giocatore sceglie il ruolo, oppure tira sulla tabella.\n\n| d8 | Specializzazione |\n|---|---|\n| 1 | Ufficiale |\n| 2 | Esploratore |\n| 3 | Fanteria |\n| 4 | Cavalleria |\n| 5 | Guaritore |\n| 6 | Furiere |\n| 7 | Portabandiera |\n| 8 | Personale di supporto (cuoco, fabbro e simili) |",
					ToolProficiencies = "Un tipo di set da gioco, veicoli (terrestri)",
					Equipment = "Un'insegna di grado\nUn trofeo strappato a un nemico caduto (un pugnale, una lama spezzata o un brandello di stendardo)\nUn set di dadi d'osso o un mazzo di carte\nUn abito comune\nUna borsa con 10 mo",
					FeatureName = "Grado Militare",
					FeatureDescription = "Il soldato ha conseguito un grado militare nel corso della sua carriera. I soldati fedeli alla sua vecchia organizzazione militare riconoscono ancora la sua autorità e la sua influenza, e quelli di grado inferiore gli obbediscono. Può far valere il suo grado per esercitare influenza su altri soldati e per requisire temporaneamente attrezzature semplici o cavalli. Di solito può anche accedere agli accampamenti e alle fortezze militari alleate in cui il suo grado è riconosciuto.",
					CharacteristicsIntro = "Gli orrori della guerra e la rigida disciplina della vita militare lasciano il segno su ogni soldato: ne plasmano gli ideali, creano legami forti e spesso lasciano cicatrici che lo rendono vulnerabile alla paura, alla vergogna e all'odio.",
					PersonalityTraits = new List<string>
					{
						"È sempre educato e rispettoso.",
						"I ricordi della guerra lo perseguitano. Non riesce a togliersi dalla testa le immagini della violenza.",
						"Ha perso troppi amici e fatica a farsene di nuovi.",
						"Dalla sua esperienza militare ha tratto un aneddoto incoraggiante o ammonitore per quasi ogni situazione di combattimento.",
						"Riesce a sostenere lo sguardo di un segugio infernale senza battere ciglio.",
						"Gli piace essere forte e adora rompere le cose.",
						"Ha un senso dell'umorismo grossolano.",
						"Affronta i problemi di petto. Una soluzione semplice e diretta è la via migliore per il successo."
					},
					Ideals = new List<string>
					{
						"Bene superiore. Il nostro destino è dare la vita in difesa degli altri. (Buono)",
						"Responsabilità. Fa ciò che deve e obbedisce all'autorità legittima. (Legale)",
						"Indipendenza. Chi obbedisce agli ordini ciecamente abbraccia una forma di tirannia. (Caotico)",
						"Potere. Nella vita come in guerra, vince la forza maggiore. (Malvagio)",
						"Vivi e lascia vivere. Nessun ideale vale un'uccisione o una guerra. (Neutrale)",
						"Patria. La sua città, la sua nazione o il suo popolo sono tutto ciò che conta. (Qualsiasi)"
					},
					Bonds = new List<string>
					{
						"Darebbe ancora la vita per le persone con cui ha prestato servizio.",
						"Qualcuno gli ha salvato la vita sul campo di battaglia. Da allora non lascia mai indietro un amico.",
						"Il suo onore è la sua vita.",
						"Non dimenticherà mai la disfatta schiacciante subita dalla sua compagnia, né i nemici che gliel'hanno inflitta.",
						"Chi combatte al suo fianco è chi merita che si muoia per lui.",
						"Combatte per chi non è in grado di combattere da sé."
					},
					Flaws = new List<string>
					{
						"Il nemico mostruoso affrontato in battaglia lo fa ancora tremare di paura.",
						"Ha poco rispetto per chi non si è dimostrato un vero guerriero.",
						"In battaglia ha commesso un errore terribile che è costato molte vite, e farebbe qualunque cosa per tenerlo segreto.",
						"Il suo odio per i nemici è cieco e irragionevole.",
						"Obbedisce alla legge, anche quando la legge porta sofferenza.",
						"Preferirebbe mangiarsi l'armatura piuttosto che ammettere di avere torto."
					}
				}
			}
		};
	}
}
