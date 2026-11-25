using RealmForge.Shared.Enums;

namespace RealmForge.Client.Services
{
	///	<summary>
	///	The background assistant of the wizard, offline: three different ideas for a character's past, each built on a
	///	theme drawn from weighted tables (the class, the alignment and the background tilt the odds), with its hook, a
	///	bond, a flaw and a short backstory. The texts are written for RealmForge; the player picks one and edits it.
	///	</summary>
	public static class BackgroundIdeas
	{
		public sealed record Idea(string Theme, string Hook, string Traits, string Ideals, string Bonds, string Flaws, string Backstory);

		private sealed record Theme(
			string Key, string NameIt, string NameEn, string HookIt, string HookEn, string BondIt, string BondEn, string FlawIt, string FlawEn,
			string StoryIt, string StoryEn, string[] Classes, string? Axis);

		//	{n}: name, {c}: class, {s}: species, {b}: background
		private static readonly Theme[] Themes =
		[
			new("debt", "Il debito", "The debt",
				"Deve una somma enorme a qualcuno che non dimentica.", "Owes a huge sum to someone who never forgets.",
				"Il prestatore che gli ha salvato la vita, e che ora la reclama a rate.", "The moneylender who saved their life, and now claims it in instalments.",
				"Accetta lavori che dovrebbe rifiutare, se pagano bene.", "Takes jobs they should refuse, if they pay well.",
				"{n} era {b} quando un affare andato storto lo lasciò con un debito impossibile. Il creditore non vuole solo denaro: vuole favori, e ogni favore lo porta più lontano da ciò che era. Diventare {c} è il modo più rapido che ha trovato per pagare, o per sparire.",
				"{n} was {b} when a deal gone wrong left them with an impossible debt. The creditor wants more than coin: favours, and each one takes them further from who they were. Becoming a {c} was the fastest way they found to pay, or to disappear.",
				["rogue", "bard", "warlock", "fighter"], "Chaotic"),
			new("lost", "La famiglia perduta", "The lost family",
				"Cerca un fratello scomparso la notte in cui il villaggio bruciò.", "Searches for a sibling who vanished the night the village burned.",
				"Un ciondolo spezzato: l'altra metà è al collo di chi sta cercando.", "A broken locket: the other half hangs around the neck of the one they seek.",
				"Si fida di chiunque dica di avere notizie, anche dei bugiardi.", "Trusts anyone who claims to have news, liars included.",
				"Il villaggio di {n}, tra i {s}, fu dato alle fiamme da predoni senza insegne. Tra le ceneri mancava un solo corpo. Da allora {n} segue ogni voce e ogni traccia, e ha imparato la via del {c} perché la strada non perdona chi è debole.",
				"{n}'s village, among the {s}, was put to the torch by raiders without banners. Among the ashes one body was missing. Since then {n} follows every rumour and track, and learnt the way of the {c} because the road does not forgive the weak.",
				["ranger", "fighter", "paladin", "barbarian"], "Good"),
			new("oath", "Il giuramento", "The oath",
				"Ha giurato di proteggere qualcuno che ora non vuole più essere protetto.", "Swore to protect someone who no longer wants protecting.",
				"Il giuramento pronunciato davanti a un altare che oggi non esiste più.", "The oath spoken before an altar that no longer exists.",
				"Non sa distinguere la lealtà dall'ostinazione.", "Cannot tell loyalty from stubbornness.",
				"Da {b}, {n} pronunciò un voto solenne: vegliare su una giovane erede. L'erede è cresciuta, è fuggita e ha sciolto {n} dal giuramento. Ma un voto non si scioglie a parole, e così {n}, ora {c}, la segue a distanza, convinto che il pericolo vero non sia ancora arrivato.",
				"As {b}, {n} took a solemn vow: to watch over a young heir. The heir grew up, ran away and released {n} from the oath. But a vow does not end with words, so {n}, now a {c}, follows at a distance, sure the real danger has not come yet.",
				["paladin", "cleric", "fighter", "monk"], "Lawful"),
			new("forbidden", "Il sapere proibito", "Forbidden knowledge",
				"Ha letto una pagina che non avrebbe dovuto leggere.", "Read a page they should never have read.",
				"Il maestro che li espulse, l'unico che sappia cosa c'era scritto.", "The master who cast them out, the only one who knows what was written.",
				"Non resiste a un libro chiuso a chiave.", "Cannot resist a locked book.",
				"In una biblioteca dove {n} lavorava come {b}, un volume senza titolo si aprì da solo. Le parole lette quella notte tornano nei sogni, e insegnano. {n} è diventato {c} per capire quel sapere prima che sia il sapere a capire lui.",
				"In a library where {n} worked as {b}, an untitled volume opened by itself. The words read that night return in dreams, and they teach. {n} became a {c} to understand that knowledge before it understands them.",
				["wizard", "warlock", "sorcerer", "cleric"], null),
			new("exile", "L'esilio", "The exile",
				"È stato bandito per un crimine che non ha commesso, o forse sì.", "Was banished for a crime they did not commit, or perhaps did.",
				"La sorella rimasta in patria, che scrive in codice ogni luna nuova.", "The sister left at home, who writes in code every new moon.",
				"Reagisce male a chiunque gli dia ordini.", "Reacts badly to anyone giving orders.",
				"La gente di {n}, {s} orgogliosi, non perdona chi infrange il codice. Un tribunale lo dichiarò colpevole e lo cacciò oltre i confini con il marchio dell'esilio. Ora {n} vive da {c} tra stranieri, deciso a tornare a casa con la prova della propria innocenza, o con un esercito.",
				"{n}'s people, proud {s}, do not forgive those who break the code. A court found them guilty and drove them past the borders with the mark of exile. Now {n} lives as a {c} among strangers, set on going home with proof of their innocence, or with an army.",
				["barbarian", "fighter", "rogue", "ranger"], "Chaotic"),
			new("calling", "La chiamata", "The calling",
				"Una voce gli parla nei momenti di silenzio, e finora ha avuto ragione.", "A voice speaks to them in moments of silence, and so far it has been right.",
				"Il luogo sacro dove la voce si fece sentire la prima volta.", "The holy place where the voice was first heard.",
				"Segue i segni anche quando portano verso il disastro.", "Follows the signs even when they lead to disaster.",
				"{n} viveva come {b} quando, durante una tempesta, sentì una voce chiamarlo per nome. Da quel giorno la voce torna, indica strade, avverte di pericoli. Che sia una divinità, un patrono o la sua stessa magia, {n} l'ha seguita fino a diventare {c}, e non sa dove lo condurrà.",
				"{n} was living as {b} when, during a storm, a voice called them by name. Since that day the voice returns, points out roads, warns of dangers. Whether a deity, a patron or their own magic, {n} followed it into becoming a {c}, and does not know where it will lead.",
				["cleric", "druid", "sorcerer", "warlock", "paladin"], null),
			new("rival", "Il rivale", "The rival",
				"Ha un rivale che lo supera sempre di un passo.", "Has a rival who is always one step ahead.",
				"Il rivale di sempre, che in fondo è l'amico più vero che abbia.", "The lifelong rival, who deep down is the truest friend they have.",
				"Non sopporta di perdere, neppure a dadi.", "Cannot bear to lose, not even at dice.",
				"{n} e il suo rivale crebbero insieme, gareggiando in tutto: chi correva più veloce, chi parlava meglio, chi diventava il miglior {c}. Poi il rivale partì per una grande impresa e non tornò. {n} non sa se piangerlo o raggiungerlo, ma ha preso la strada per scoprirlo.",
				"{n} and their rival grew up together, competing in everything: who ran faster, who spoke better, who became the best {c}. Then the rival left on a great quest and never came back. {n} does not know whether to mourn or catch up, but took to the road to find out.",
				["fighter", "bard", "monk", "rogue", "wizard"], null),
			new("wild", "Cresciuto nella natura", "Raised by the wild",
				"Fu allevato lontano da ogni città e le leggi degli uomini gli sembrano strane.", "Was raised far from any town and the laws of people seem strange to them.",
				"Il bosco antico dove è cresciuto, oggi minacciato dalle asce.", "The ancient wood where they grew up, now threatened by axes.",
				"Diffida di chi abita tra le mura.", "Distrusts those who live behind walls.",
				"Nessuno sa come {n} sia finito nella foresta da bambino: i {s} che lo trovarono anni dopo dissero che i lupi lo trattavano come uno di loro. Imparò tardi a parlare e presto a cacciare. Ora che il bosco è in pericolo, {n} ha scelto la via del {c} per difenderlo da chi lo vuole abbattere.",
				"Nobody knows how {n} ended up in the forest as a child: the {s} who found them years later said the wolves treated them as one of their own. They learnt to speak late and to hunt early. Now that the wood is in danger, {n} chose the way of the {c} to defend it from those who would fell it.",
				["druid", "ranger", "barbarian"], "Neutral"),
			new("crown", "Il sangue nobile", "Noble blood",
				"Ha rinunciato a un titolo, ma il titolo non ha rinunciato a lui.", "Gave up a title, but the title did not give them up.",
				"La casata, che vuole riportarlo a casa per un matrimonio di convenienza.", "The house, which wants them home for a marriage of convenience.",
				"Dà per scontato che gli altri lo servano.", "Assumes others will serve them.",
				"Terzo figlio di una casata minore, {n} era destinato a una vita di ricevimenti e alleanze. Scelse invece di diventare {c}, cambiò nome e partì. Ma gli stemmi hanno occhi ovunque, e un giorno qualcuno lo riconoscerà.",
				"Third child of a minor house, {n} was meant for a life of feasts and alliances. Instead they chose to become a {c}, changed their name and left. But crests have eyes everywhere, and one day someone will recognise them.",
				["paladin", "fighter", "bard", "wizard"], "Lawful"),
			new("survivor", "L'unico sopravvissuto", "The sole survivor",
				"È l'unico tornato vivo da una spedizione di cui nessuno parla.", "Is the only one who came back alive from an expedition nobody talks about.",
				"I compagni caduti, i cui nomi ripete ogni notte.", "The fallen companions, whose names they repeat every night.",
				"Si espone al pericolo come se la sua vita valesse meno delle altre.", "Throws themselves into danger as if their life were worth less than others'.",
				"La compagnia di {n} scese sotto le montagne in cerca di una città perduta. Tornò solo {n}, senza ricordare come. Da allora il {c} che è diventato porta addosso un oggetto che non sa di aver preso, e che a volte è caldo al tatto.",
				"{n}'s company went under the mountains seeking a lost city. Only {n} came back, with no memory of how. Since then the {c} they became carries an object they do not remember taking, which is sometimes warm to the touch.",
				["fighter", "ranger", "rogue", "warlock", "barbarian"], null),
			new("redemption", "Il riscatto", "Redemption",
				"Un tempo ha fatto del male, e vuole rimediare prima che sia tardi.", "Once did harm, and wants to make amends before it is too late.",
				"La persona a cui ha fatto del male, che ancora non sa chi fosse.", "The person they wronged, who still does not know who it was.",
				"Si accusa di tutto ciò che va storto.", "Blames themselves for everything that goes wrong.",
				"Prima di diventare {c}, {n} era al servizio di gente che non faceva domande. Un incarico finì con un innocente ferito, e quella notte {n} se ne andò. Ora cerca di pareggiare i conti, un'azione giusta alla volta, sapendo che il passato prima o poi busserà alla porta.",
				"Before becoming a {c}, {n} served people who asked no questions. One job ended with an innocent hurt, and that night {n} walked away. Now they try to even the scales, one right deed at a time, knowing the past will come knocking sooner or later.",
				["paladin", "cleric", "rogue", "monk", "fighter"], "Good"),
			new("ambition", "L'ambizione", "Ambition",
				"Vuole un posto nella storia, e non gli importa quanto costi.", "Wants a place in history, and does not care what it costs.",
				"Il mentore che gli ha promesso grandezza, in cambio di obbedienza.", "The mentor who promised greatness, in exchange for obedience.",
				"Sacrifica gli amici se è l'unico modo per salire.", "Sacrifices friends if it is the only way up.",
				"{n} è cresciuto tra i {s} ascoltando le canzoni degli eroi, e ha deciso presto che un giorno ne avrebbero cantata una su di lui. Da {b} è diventato {c} con una sola idea in testa: essere ricordato. Il modo, per ora, è un dettaglio.",
				"{n} grew up among the {s} listening to songs of heroes, and decided early that one day there would be one about them. From {b} they became a {c} with a single thought: to be remembered. The how, for now, is a detail.",
				["sorcerer", "warlock", "wizard", "bard", "fighter"], "Evil")
		];

		//	The weight of a theme for the character: higher when it fits the class or the alignment
		private static int Weight(Theme theme, StorySeed seed)
		{
			var weight = 2;
			if (seed.ClassKey is { } key && theme.Classes.Contains(key))
			{
				weight += 4;
			}
			var alignment = seed.Alignment.ToString();
			if (theme.Axis is { } axis && (alignment.StartsWith(axis) || alignment.EndsWith(axis) || (axis == "Neutral" && alignment.Contains("Neutral"))))
			{
				weight += 3;
			}
			return weight;
		}

		public static IReadOnlyList<Idea> Three(StorySeed seed, Random? random = null)
		{
			var rng = random ?? Random.Shared;
			var pool = Themes.ToList();
			var ideas = new List<Idea>();
			while (ideas.Count < 3 && pool.Count > 0)
			{
				var total = pool.Sum(t => Weight(t, seed));
				var roll = rng.Next(total);
				var picked = pool[0];
				foreach (var theme in pool)
				{
					roll -= Weight(theme, seed);
					if (roll < 0)
					{
						picked = theme;
						break;
					}
				}
				pool.Remove(picked);
				ideas.Add(Build(picked, seed, rng));
			}
			return ideas;
		}

		private static Idea Build(Theme theme, StorySeed seed, Random rng)
		{
			var it = seed.Language == LanguageCode.It;
			string Fill(string text) => text
				.Replace("{n}", seed.Name.Trim().Length > 0 ? seed.Name.Trim() : (it ? "Il personaggio" : "The character"))
				.Replace("{c}", seed.ClassName.Length > 0 ? seed.ClassName.ToLowerInvariant() : (it ? "avventuriero" : "adventurer"))
				.Replace("{s}", seed.SpeciesName.Length > 0 ? seed.SpeciesName : (it ? "viandanti" : "wanderers"))
				.Replace("{b}", seed.BackgroundName.Length > 0 ? seed.BackgroundName.ToLowerInvariant() : (it ? "girovago" : "a wanderer"));
			return new Idea(
				it ? theme.NameIt : theme.NameEn,
				it ? theme.HookIt : theme.HookEn,
				CharacterStoryGenerator.Suggest(StoryField.Traits, seed, rng),
				CharacterStoryGenerator.Suggest(StoryField.Ideals, seed, rng),
				it ? theme.BondIt : theme.BondEn,
				it ? theme.FlawIt : theme.FlawEn,
				Fill(it ? theme.StoryIt : theme.StoryEn));
		}
	}
}
