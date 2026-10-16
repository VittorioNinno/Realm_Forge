using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.BackgroundsData;

///	<summary>
///	Hermit (2014 ruleset). Not part of SRD 5.1: English and Italian texts are written for RealmForge, keeping the
///	official game terms and mechanics. The seclusion table uses the same order in both languages, so a roll gives
///	the same result whatever the language.
///	</summary>
public static class Hermit2014Seeder
{
	public static readonly Guid BackgroundId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "background", "hermit");

	public static Background Build()
	{
		return new Background
		{
			Id = BackgroundId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			SkillProficiencies = new List<Skill> { Skill.Medicine, Skill.Religion },
			Translations = new List<BackgroundTranslation>
			{
				new BackgroundTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "background", "hermit", "en"),
					Language = LanguageCode.En,
					Name = "Hermit",
					Description = "For a formative stretch of your life you lived apart from the world, either in a secluded community such as a monastery or entirely on your own. Far from the noise of society you found silence, solitude, and perhaps some of the answers you were seeking.\n\n### Life of Seclusion\nWhy did you withdraw from the world, and what changed so that you could end your solitude? Work out the exact nature of your seclusion with your DM, or choose a reason or roll on the table.\n\n| d8 | Life of Seclusion |\n|---|---|\n| 1 | I was seeking spiritual enlightenment. |\n| 2 | I lived in a community, following the rules of a religious order. |\n| 3 | I was exiled for a crime I did not commit. |\n| 4 | I withdrew from society after an event that changed my life. |\n| 5 | I needed a quiet place to work on my art, my writing, my music, or my manifesto. |\n| 6 | I needed to commune with nature, far from civilization. |\n| 7 | I was the keeper of an ancient ruin or relic. |\n| 8 | I was a pilgrim searching for a person, place, or relic of spiritual importance. |\n\n### Other Hermits\nThis background assumes a contemplative kind of seclusion that leaves room for study and prayer. If you would rather play a rugged recluse who lives off the land in the wilderness and avoids other people, look at the outlander background. If you prefer a more religious path, the acolyte might suit you better. You could even be a charlatan, passing yourself off as a wise and holy figure and letting gullible believers support you.",
					ToolProficiencies = "Herbalism kit",
					Languages = "One of your choice",
					Equipment = "A scroll case full of notes from your studies or prayers\nA winter blanket\nA set of common clothes\nAn herbalism kit\n5 gp",
					FeatureName = "Discovery",
					FeatureDescription = "The long quiet of your seclusion led you to a unique and powerful discovery. What it is depends on the nature of your retreat: a great truth about the cosmos, the deities, the mighty beings of the Outer Planes, or the forces of nature; a place no one else has ever seen; a fact long forgotten; or a relic of the past that could rewrite history. It might even be knowledge that would harm the people who drove you into exile, and that is why you have returned to society.\n\nWork with your DM to define the details of your discovery and its impact on the campaign.",
					CharacteristicsIntro = "Some hermits are made for a solitary life, while others chafe against it and long for company. Whether they embrace solitude or yearn to escape it, life apart shapes their outlook and ideals, and a few are left slightly mad by their years away from society.",
					PersonalityTraits = new List<string>
					{
						"I have been alone so long that I rarely speak, preferring gestures and the odd grunt.",
						"I stay perfectly serene, even in the face of disaster.",
						"The leader of my community had a wise saying for every subject, and I can't wait to share that wisdom.",
						"I feel deep empathy for everyone who suffers.",
						"I am blind to etiquette and to what society expects of me.",
						"I see everything that happens to me as part of a grand cosmic plan.",
						"I often get so lost in my thoughts that I forget the world around me.",
						"I am working on a great philosophical theory and love sharing my ideas."
					},
					Ideals = new List<string>
					{
						"Greater Good. My gifts are meant to be shared with everyone, not used for my own gain. (Good)",
						"Logic. Emotions must not cloud our sense of what is right and true, nor our reasoning. (Lawful)",
						"Free Thinking. Questions and curiosity are the pillars of progress. (Chaotic)",
						"Power. Solitude and contemplation are the paths to mystical or magical power. (Evil)",
						"Live and Let Live. Meddling in other people's business only brings trouble. (Neutral)",
						"Self-Knowledge. Whoever knows themselves has nothing left to learn. (Any)"
					},
					Bonds = new List<string>
					{
						"Nothing matters more than the other members of my hermitage, order, or community.",
						"I withdrew from the world to hide from those who may still be hunting me. Someday I must face them.",
						"I am still searching for the enlightenment I sought in seclusion, and it still escapes me.",
						"I withdrew from the world because I loved someone I could not have.",
						"If my discovery came to light, it could bring ruin to the world.",
						"My isolation revealed to me a great evil that only I can destroy."
					},
					Flaws = new List<string>
					{
						"Now that I am back in the world, I enjoy its pleasures a little too much.",
						"I harbor dark, bloodthirsty thoughts that isolation and meditation could not quiet.",
						"I am dogmatic about my thoughts and my philosophy.",
						"My need to win every argument matters more to me than friendship and harmony.",
						"I would risk far too much to uncover a lost scrap of knowledge.",
						"I love keeping secrets and share them with no one."
					}
				},
				new BackgroundTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "background", "hermit", "it"),
					Language = LanguageCode.It,
					Name = "Eremita",
					Description = "Per un periodo decisivo della sua vita l'eremita ha vissuto lontano dal mondo, in una comunità appartata come un monastero oppure del tutto da solo. Lontano dal frastuono della società ha trovato silenzio, solitudine e forse alcune delle risposte che cercava.\n\n### Vita Solitaria\nPerché l'eremita si è ritirato dal mondo, e che cosa è cambiato perché potesse porre fine alla sua solitudine? Il giocatore definisce con il DM la natura esatta del suo isolamento, oppure sceglie un motivo o tira sulla tabella.\n\n| d8 | Vita Solitaria |\n|---|---|\n| 1 | Cercava l'illuminazione spirituale. |\n| 2 | Viveva in comunità, seguendo le regole di un ordine religioso. |\n| 3 | È stato esiliato per un crimine che non ha commesso. |\n| 4 | Si è ritirato dalla società dopo un evento che gli ha cambiato la vita. |\n| 5 | Aveva bisogno di un luogo tranquillo per lavorare alla sua arte, ai suoi scritti, alla sua musica o al suo manifesto. |\n| 6 | Aveva bisogno di entrare in comunione con la natura, lontano dalla civiltà. |\n| 7 | Era il custode di un'antica rovina o di una reliquia. |\n| 8 | Era un pellegrino in cerca di una persona, un luogo o una reliquia di grande valore spirituale. |\n\n### Altri eremiti\nQuesto background presuppone un isolamento contemplativo, che lascia spazio allo studio e alla preghiera. Chi preferisce interpretare un solitario rude che vive dei frutti della terra nelle regioni selvagge ed evita la compagnia altrui può guardare al background del forestiero. Chi cerca un'impronta più religiosa potrebbe trovarsi meglio con l'accolito. Il personaggio potrebbe perfino essere un ciarlatano che si spaccia per un saggio o un santo e si fa mantenere dai fedeli più ingenui.",
					ToolProficiencies = "Borsa da erborista",
					Languages = "Uno a scelta",
					Equipment = "Una custodia per pergamene piena di appunti di studio o di preghiere\nUna coperta invernale\nUn abito comune\nUna borsa da erborista\n5 mo",
					FeatureName = "Scoperta",
					FeatureDescription = "La lunga quiete del suo isolamento ha portato l'eremita a una scoperta unica e potente. Di che cosa si tratti dipende dalla natura del suo ritiro: una grande verità sul cosmo, sulle divinità, sulle potenti entità dei Piani Esterni o sulle forze della natura; un luogo che nessun altro ha mai visto; un fatto dimenticato da tempo; oppure una reliquia del passato capace di riscrivere la storia. Potrebbe perfino trattarsi di informazioni dannose per chi lo ha costretto all'esilio, ed è per questo che ha fatto ritorno nella società.\n\nIl giocatore definisce con il DM i dettagli della scoperta e il suo impatto sulla campagna.",
					CharacteristicsIntro = "Alcuni eremiti sono fatti per la vita solitaria, mentre altri la sopportano a fatica e desiderano compagnia. Che abbraccino la solitudine o sognino di sfuggirle, la vita appartata ne plasma la mentalità e gli ideali, e qualcuno, dopo anni lontano dalla società, ne esce un po' folle.",
					PersonalityTraits = new List<string>
					{
						"È rimasto solo così a lungo che parla di rado: preferisce i gesti e qualche grugnito.",
						"Resta perfettamente sereno, anche di fronte al disastro.",
						"Il capo della sua comunità aveva una massima saggia per ogni argomento, e lui non vede l'ora di condividerla.",
						"Prova una profonda empatia per chiunque soffra.",
						"Ignora del tutto l'etichetta e le convenzioni sociali.",
						"Vede in tutto ciò che gli accade una parte di un grandioso disegno cosmico.",
						"Si perde spesso nei suoi pensieri al punto da dimenticare il mondo che lo circonda.",
						"Sta elaborando una grande teoria filosofica e adora condividere le sue idee."
					},
					Ideals = new List<string>
					{
						"Bene superiore. I suoi doni vanno condivisi con tutti, non usati a proprio vantaggio. (Buono)",
						"Logica. Le emozioni non devono offuscare il senso di ciò che è giusto e vero, né il ragionamento. (Legale)",
						"Libero pensiero. Le domande e la curiosità sono i pilastri del progresso. (Caotico)",
						"Potere. La solitudine e la contemplazione sono le vie verso il potere mistico o magico. (Malvagio)",
						"Vivi e lascia vivere. Immischiarsi negli affari altrui porta solo guai. (Neutrale)",
						"Conoscenza di sé. Chi conosce se stesso non ha nient'altro da imparare. (Qualsiasi)"
					},
					Bonds = new List<string>
					{
						"Niente conta più degli altri membri del suo eremo, ordine o comunità.",
						"Si è ritirato dal mondo per nascondersi da chi potrebbe ancora dargli la caccia. Un giorno dovrà affrontarli.",
						"Cerca ancora l'illuminazione che inseguiva nell'isolamento, e che continua a sfuggirgli.",
						"Si è ritirato dal mondo perché amava qualcuno che non poteva avere.",
						"Se la sua scoperta venisse alla luce, potrebbe portare il mondo alla rovina.",
						"L'isolamento gli ha rivelato un grande male che solo lui può distruggere."
					},
					Flaws = new List<string>
					{
						"Ora che è tornato nel mondo, ne gode i piaceri un po' troppo.",
						"Nutre pensieri cupi e sanguinari che l'isolamento e la meditazione non sono riusciti a placare.",
						"È dogmatico riguardo ai suoi pensieri e alla sua filosofia.",
						"Il bisogno di vincere ogni discussione per lui conta più dell'amicizia e dell'armonia.",
						"Rischierebbe fin troppo pur di riportare alla luce un frammento di conoscenza perduta.",
						"Adora custodire segreti e non li condivide con nessuno."
					}
				}
			}
		};
	}
}
