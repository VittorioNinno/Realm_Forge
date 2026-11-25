using System.Globalization;
using System.Text;
using RealmForge.Shared.Enums;

namespace RealmForge.Client.Services
{
	///	<summary>
	///	The backstory assistant without a language model (devices without WebGPU, or before the model is downloaded): it
	///	recognises the themes of the player's ideas (family, revenge, faith, magic…) and the names they invented, answers
	///	by enriching them with tables written for RealmForge, and asks a question to go further. It never repeats an
	///	answer while it has others.
	///	</summary>
	public sealed class BackstoryCoach
	{
		private sealed record Motif(string Key, string[] Words, string[] AddIt, string[] AddEn, string[] AskIt, string[] AskEn);

		private static readonly Motif[] Motifs =
		[
			new("family", ["madre", "padre", "fratell", "sorell", "famiglia", "figli", "nonn", "zio", "zia", "mother", "father", "brother", "sister", "family", "son", "daughter", "grand"],
				["La famiglia di {n} conserva un oggetto che nessuno nomina mai: una spada spezzata appesa sopra il camino, che {who} ha giurato di non riparare.", "Ogni inverno {who} scrive a {n} una lettera che non spedisce; {n} le ha trovate tutte, nascoste in una cassa, il giorno in cui è partito."],
				["{n}'s family keeps an object nobody ever mentions: a broken sword hung over the hearth that {who} swore never to mend.", "Every winter {who} writes {n} a letter that is never sent; {n} found them all, hidden in a chest, the day they left."],
				["Cosa sa {who} che {n} non sa ancora?", "Se {n} tornasse a casa domani, chi gli aprirebbe la porta, e con che faccia?"],
				["What does {who} know that {n} does not know yet?", "If {n} went home tomorrow, who would open the door, and with what face?"]),
			new("revenge", ["vendett", "ucciso", "assassin", "tradit", "nemico", "odio", "revenge", "killed", "murder", "betray", "enemy", "hate"],
				["Chi ha fatto del male a {n} oggi porta un altro nome e ha amici potenti; ma ha tenuto un vizio di allora, ed è da quel vizio che {n} potrebbe riconoscerlo.", "{n} conserva una lista: tre nomi, uno già cancellato. Il secondo appartiene a qualcuno che un tempo gli ha salvato la vita."],
				["Whoever hurt {n} now goes by another name and has powerful friends; but they kept a habit from back then, and by that habit {n} could recognise them.", "{n} keeps a list: three names, one already crossed out. The second belongs to someone who once saved their life."],
				["La vendetta è per giustizia o per {n} stesso? E cosa farebbe se scoprisse che il colpevole è cambiato davvero?", "Chi, tra le persone care a {n}, cercherebbe di fermarlo?"],
				["Is the revenge for justice or for {n} alone? And what would they do on finding the culprit has truly changed?", "Who among the people {n} loves would try to stop them?"]),
			new("faith", ["dio", "dea", "tempio", "fede", "preghier", "sacerdot", "santo", "god", "goddess", "temple", "faith", "pray", "priest", "holy"],
				["Nel tempio dove {n} è cresciuto c'è una cappella chiusa a chiave; i sacerdoti dicono che contiene una reliquia, ma {n} una notte ha sentito qualcuno piangere dietro quella porta.", "La fede di {n} è nata da un miracolo che solo lui ha visto, e che nessuno ha mai creduto."],
				["In the temple where {n} grew up there is a locked chapel; the priests say it holds a relic, but one night {n} heard someone weeping behind that door.", "{n}'s faith was born of a miracle only they saw, and nobody ever believed."],
				["Cosa chiede la divinità a {n} in cambio della sua protezione?", "C'è un precetto che {n} infrange in segreto?"],
				["What does the deity ask of {n} in return for its protection?", "Is there a precept {n} breaks in secret?"]),
			new("magic", ["magia", "incantesim", "libro", "arcan", "mago", "strega", "rituale", "magic", "spell", "book", "arcane", "wizard", "witch", "ritual"],
				["La prima magia di {n} non fu voluta: una lampada che si accese da sola, una tenda che prese fuoco. Qualcuno quella sera lo vide, e da allora lo osserva.", "Sul margine del primo libro di magia di {n} c'è una scrittura diversa dalla sua, che ogni tanto aggiunge una riga nuova."],
				["{n}'s first magic was not intended: a lamp that lit itself, a curtain that caught fire. Someone saw it that evening, and has watched ever since.", "In the margin of {n}'s first spellbook there is a handwriting not their own, which now and then adds a new line."],
				["Cosa costa la magia a {n}: un ricordo, il sonno, un po' di calore?", "Chi gli ha insegnato, e perché ha smesso?"],
				["What does magic cost {n}: a memory, sleep, a little warmth?", "Who taught them, and why did they stop?"]),
			new("crime", ["ladro", "rubat", "furto", "gilda", "contrabband", "prigion", "debito", "thief", "stole", "theft", "guild", "smuggl", "prison", "debt"],
				["L'ultimo colpo di {n} andò quasi bene: il bottino è ancora nascosto dove l'ha lasciato, ma il complice che sa dove si trova è uscito di prigione la settimana scorsa.", "{n} deve un favore a una donna che non chiede mai denaro, solo piccoli lavori. Finora."],
				["{n}'s last job almost went well: the loot is still hidden where they left it, but the accomplice who knows the place got out of prison last week.", "{n} owes a favour to a woman who never asks for money, only small jobs. So far."],
				["Qual è la regola che {n} non infrange mai, nemmeno per tanto oro?", "Chi lo cerca, oggi, e per cosa?"],
				["What rule does {n} never break, not even for a lot of gold?", "Who is looking for them today, and why?"]),
			new("war", ["guerra", "soldat", "battagli", "esercit", "assedio", "mercenari", "war", "soldier", "battle", "army", "siege", "mercenar"],
				["Durante l'assedio {n} prese una decisione che salvò la sua compagnia e condannò un villaggio. Nei rapporti ufficiali c'è scritto il contrario.", "{n} porta ancora la piastrina di un commilitone che non è tornato; sul retro c'è un indirizzo, e una promessa mai mantenuta."],
				["During the siege {n} made a choice that saved their company and doomed a village. The official reports say otherwise.", "{n} still carries the tag of a comrade who did not come back; on the back there is an address, and a promise never kept."],
				["Cosa sogna {n} la notte prima di una battaglia?", "Chi è stato il suo comandante, e lo rispetta ancora?"],
				["What does {n} dream the night before a battle?", "Who was their commander, and do they still respect them?"]),
			new("love", ["amor", "amat", "innamor", "sposa", "sposo", "fidanzat", "matrimon", "love", "lover", "beloved", "wife", "husband", "married"],
				["L'amore di {n} è rimasto dall'altra parte di una frontiera chiusa; si scrivono con un codice inventato da bambini, in lettere affidate ai mercanti.", "{n} ha promesso di tornare prima del raccolto. È il terzo raccolto che passa."],
				["{n}'s love stayed on the far side of a closed border; they write in a code invented as children, in letters entrusted to merchants.", "{n} promised to be back before the harvest. This is the third harvest gone by."],
				["Cosa ha sacrificato {n} per quell'amore, o cosa ha rifiutato di sacrificare?", "Se dovesse scegliere tra quell'amore e il gruppo, cosa farebbe?"],
				["What did {n} give up for that love, or refuse to give up?", "If they had to choose between that love and the party, what would they do?"]),
			new("loss", ["mort", "perso", "scompars", "funeral", "lutto", "orfan", "died", "dead", "lost", "vanished", "funeral", "grief", "orphan"],
				["Il corpo non fu mai trovato. {n} lo sa, e ogni volta che sente una voce simile in una locanda si volta.", "Sulla tomba c'è un nome sbagliato: {n} lo ha scoperto per caso, e da allora si chiede chi ci sia davvero sepolto."],
				["The body was never found. {n} knows it, and turns around every time a similar voice is heard in a tavern.", "The grave bears the wrong name: {n} found out by chance, and has wondered ever since who is really buried there."],
				["Cosa ha lasciato quella perdita a {n}: un oggetto, una paura, un'abitudine?", "Di chi è la colpa, secondo {n}? E secondo gli altri?"],
				["What did that loss leave {n}: an object, a fear, a habit?", "Whose fault was it, according to {n}? And according to the others?"]),
			new("nature", ["bosc", "forest", "anima", "lup", "montagn", "fium", "mare", "nave", "wood", "forest", "animal", "wolf", "mountain", "river", "sea", "ship"],
				["C'è un sentiero che solo {n} sa trovare; porta a una radura dove gli animali non hanno paura, e dove qualcuno, di recente, ha acceso un fuoco.", "Il mare ha restituito a {n} qualcosa che aveva perso anni prima, ancora asciutto, avvolto in una tela cerata."],
				["There is a path only {n} can find; it leads to a clearing where animals have no fear, and where someone recently lit a fire.", "The sea gave {n} back something lost years before, still dry, wrapped in oilcloth."],
				["Quale animale o luogo {n} considera casa più di qualsiasi città?", "Cosa minaccia oggi quel luogo?"],
				["What animal or place does {n} call home more than any town?", "What threatens that place today?"]),
			new("noble", ["nobil", "re ", "regina", "princip", "corona", "casata", "titolo", "erede", "noble", "king", "queen", "prince", "crown", "house", "title", "heir"],
				["Lo stemma della casata di {n} è stato scalpellato via dal portone di famiglia; al suo posto qualcuno ha inciso un simbolo che {n} ha già visto, in sogno.", "{n} è il legittimo erede di qualcosa: non un trono, ma un debito antico che passa di padre in figlio."],
				["The crest of {n}'s house was chiselled off the family gate; in its place someone carved a symbol {n} has already seen, in a dream.", "{n} is the rightful heir of something: not a throne, but an old debt handed down from parent to child."],
				["Cosa farebbe {n} se domani gli offrissero indietro il suo titolo?", "Chi della corte lo vuole lontano, e perché?"],
				["What would {n} do if tomorrow they were offered their title back?", "Who at court wants them far away, and why?"]),
			new("secret", ["segret", "nascost", "mistero", "maledizion", "marchio", "secret", "hidden", "mystery", "curse", "mark"],
				["Il segreto di {n} lascia un segno: una cicatrice che brucia quando mente, o un'ombra che arriva un istante in ritardo.", "Solo una persona al mondo conosce il segreto di {n}, e ha appena ricevuto un'offerta per rivelarlo."],
				["{n}'s secret leaves a mark: a scar that burns when they lie, or a shadow that arrives a moment late.", "Only one person in the world knows {n}'s secret, and has just been offered a price to reveal it."],
				["Cosa succederebbe se il gruppo scoprisse il segreto?", "{n} vuole liberarsene o proteggerlo?"],
				["What would happen if the party found out the secret?", "Does {n} want to be free of it or to protect it?"]),
			new("mentor", ["maestr", "mentore", "insegn", "allievo", "apprendist", "master", "mentor", "teacher", "taught", "apprentic", "student"],
				["Il maestro di {n} gli insegnò tutto tranne una cosa, e prima di sparire gli lasciò una chiave senza dirgli cosa apre.", "{n} non è stato l'unico allievo: un altro, più dotato, ha preso una strada diversa e oggi insegna le stesse tecniche a gente pericolosa."],
				["{n}'s master taught them everything but one thing, and before vanishing left them a key without saying what it opens.", "{n} was not the only student: another, more gifted, took a different road and now teaches the same arts to dangerous people."],
				["Quale lezione del maestro {n} ha capito solo dopo?", "Il maestro sarebbe fiero di {n}, oggi?"],
				["Which of the master's lessons did {n} understand only later?", "Would the master be proud of {n} today?"])
		];

		private static readonly string[] GenericIt =
		[
			"Proviamo a dare un luogo preciso a questa storia: una città di confine dove le campane suonano a ore strane, e dove {n} ha lasciato un conto in sospeso.",
			"Aggiungiamo una persona: qualcuno che ha conosciuto {n} prima che diventasse {c}, e che ricorda una versione di lui molto diversa.",
			"Ogni passato ha un oggetto: un amuleto, una lettera, una moneta tagliata a metà. Quello di {n} potrebbe essere la chiave di tutto."
		];

		private static readonly string[] GenericEn =
		[
			"Let us give this story a precise place: a border town where the bells ring at odd hours, and where {n} left something unsettled.",
			"Let us add a person: someone who knew {n} before they became a {c}, and remembers a very different version of them.",
			"Every past has an object: an amulet, a letter, a coin cut in half. {n}'s could be the key to everything."
		];

		private static readonly string[] OpenIt = ["Mi piace.", "Ottimo spunto.", "Questo apre molte strade.", "Interessante."];
		private static readonly string[] OpenEn = ["I like it.", "Great idea.", "That opens many roads.", "Interesting."];

		private readonly HashSet<string> used = new();
		private readonly Random random;

		public BackstoryCoach(Random? random = null)
		{
			this.random = random ?? new Random();
		}

		public string Reply(StorySeed seed, string idea)
		{
			var it = seed.Language == LanguageCode.It;
			var text = " " + idea.ToLowerInvariant() + " ";
			var names = NamesIn(idea, seed.Name);
			var name = string.IsNullOrWhiteSpace(seed.Name) ? (it ? "il tuo personaggio" : "your character") : seed.Name.Trim();
			var who = names.FirstOrDefault() ?? (it ? "qualcuno di caro" : "someone dear");
			string Fill(string s) => s.Replace("{n}", name).Replace("{who}", who)
				.Replace("{c}", seed.ClassName.Length > 0 ? seed.ClassName.ToLowerInvariant() : (it ? "avventuriero" : "adventurer"));

			var matched = Motifs.Where(m => m.Words.Any(w => text.Contains(w))).OrderBy(_ => random.Next()).Take(2).ToList();
			var sb = new StringBuilder();
			sb.Append(Pick(it ? OpenIt : OpenEn, "open"));
			if (names.Count > 0)
			{
				sb.Append(' ').Append(it ? $"Teniamo {string.Join(" e ", names.Take(2))} al centro." : $"Let us keep {string.Join(" and ", names.Take(2))} at the centre.");
			}
			if (matched.Count == 0)
			{
				sb.Append(' ').Append(Fill(Pick(it ? GenericIt : GenericEn, "generic")));
			}
			foreach (var motif in matched)
			{
				sb.Append(' ').Append(Fill(Pick(it ? motif.AddIt : motif.AddEn, motif.Key + "+")));
			}
			var ask = matched.Count > 0
				? Pick(it ? matched[0].AskIt : matched[0].AskEn, matched[0].Key + "?")
				: (it ? "Cosa vuole {n} più di ogni altra cosa, e cosa è disposto a perdere per averlo?" : "What does {n} want more than anything, and what would they lose to get it?");
			sb.Append("\n\n").Append(Fill(ask));
			return sb.ToString();
		}

		//	One of the lines not used yet (all used: start again)
		private string Pick(string[] lines, string key)
		{
			var fresh = Enumerable.Range(0, lines.Length).Where(i => !used.Contains($"{key}{i}")).ToList();
			if (fresh.Count == 0)
			{
				used.RemoveWhere(u => u.StartsWith(key, StringComparison.Ordinal));
				fresh = Enumerable.Range(0, lines.Length).ToList();
			}
			var index = fresh[random.Next(fresh.Count)];
			used.Add($"{key}{index}");
			return lines[index];
		}

		//	The names the player invented: capitalised words not at the start of a sentence
		private static List<string> NamesIn(string idea, string character)
		{
			var names = new List<string>();
			var words = idea.Split([' ', '\n', '\t'], StringSplitOptions.RemoveEmptyEntries);
			for (var i = 1; i < words.Length; i++)
			{
				var previous = words[i - 1];
				if (previous.EndsWith('.') || previous.EndsWith('!') || previous.EndsWith('?'))
				{
					continue;
				}
				var word = words[i].Trim(',', '.', ';', ':', '!', '?', '"', '«', '»', '(', ')');
				if (word.Length > 2 && char.IsUpper(word[0]) && !string.Equals(word, character.Trim(), StringComparison.CurrentCultureIgnoreCase)
					&& !names.Contains(word))
				{
					names.Add(word);
				}
			}
			return names;
		}
	}
}
