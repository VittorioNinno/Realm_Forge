using RealmForge.Shared.Enums;

namespace RealmForge.Client.Services
{
	///	<summary>
	///	What the generator knows about the character: names in the reader's language and the rules keys.
	///	</summary>
	public sealed record StorySeed(
		string Name,
		Alignment Alignment,
		string? ClassKey,
		string ClassName,
		string SpeciesName,
		string BackgroundName,
		LanguageCode Language);

	public enum StoryField
	{
		Traits = 1,
		Ideals = 2,
		Bonds = 3,
		Flaws = 4,
		Appearance = 5,
		Backstory = 6
	}

	///	<summary>
	///	Short suggestions for the personality and the story of a character, from its alignment, class, species and
	///	background. The texts are written for RealmForge; every call picks new combinations, so the player can ask
	///	again until one fits and then edit it.
	///	</summary>
	public static class CharacterStoryGenerator
	{
		public static string Suggest(StoryField field, StorySeed seed, Random? random = null)
		{
			var rng = random ?? Random.Shared;
			var it = seed.Language == LanguageCode.It;
			return field switch
			{
				StoryField.Traits => Traits(seed, rng, it),
				StoryField.Ideals => Pick(rng, Ideals(seed.Alignment, it)),
				StoryField.Bonds => Bonds(seed, rng, it),
				StoryField.Flaws => Flaws(seed, rng, it),
				StoryField.Appearance => Appearance(seed, rng, it),
				_ => Backstory(seed, rng, it)
			};
		}

		private static string Pick(Random rng, IReadOnlyList<string> options) => options[rng.Next(options.Count)];

		// ===== Personality traits: one from the class, one from the alignment =====

		private static string Traits(StorySeed seed, Random rng, bool it)
		{
			var fromClass = Pick(rng, ClassTraits(seed.ClassKey, it));
			var fromAlignment = Pick(rng, AlignmentTraits(seed.Alignment, it));
			return $"{fromClass} {fromAlignment}";
		}

		private static IReadOnlyList<string> ClassTraits(string? key, bool it) => (key, it) switch
		{
			("barbarian", true) => new[] { "Parla poco e agisce subito: per lui un problema si risolve affrontandolo di petto.", "Ride forte, mangia tanto e si fida solo di chi ha combattuto al suo fianco." },
			("barbarian", false) => new[] { "Speaks little and acts at once: a problem is something to face head on.", "Laughs loudly, eats a lot and trusts only those who have fought beside them." },
			("bard", true) => new[] { "Trasforma ogni avventura in una storia da raccontare, meglio se con qualche abbellimento.", "Non resiste a un pubblico: una canzone, una battuta o un aneddoto sono sempre pronti." },
			("bard", false) => new[] { "Turns every adventure into a story to tell, better with a few embellishments.", "Cannot resist an audience: a song, a joke or an anecdote is always ready." },
			("cleric", true) => new[] { "Prega prima di ogni viaggio e vede nei piccoli eventi i segni della propria divinità.", "Ascolta con pazienza chiunque cerchi conforto, anche gli sconosciuti." },
			("cleric", false) => new[] { "Prays before every journey and sees the signs of their deity in small events.", "Listens patiently to anyone seeking comfort, strangers included." },
			("druid", true) => new[] { "Si sente più a casa sotto le stelle che tra le mura di una città.", "Parla alle piante e agli animali come a vecchi amici, e talvolta sembra che rispondano." },
			("druid", false) => new[] { "Feels more at home under the stars than within city walls.", "Talks to plants and animals like old friends, and sometimes they seem to answer." },
			("fighter", true) => new[] { "Controlla le armi ogni sera e non lascia nulla al caso prima di uno scontro.", "Rispetta gli avversari valorosi e disprezza chi colpisce alle spalle." },
			("fighter", false) => new[] { "Checks their weapons every evening and leaves nothing to chance before a fight.", "Respects valiant foes and despises those who strike from behind." },
			("monk", true) => new[] { "Mantiene la calma anche nel caos e misura ogni gesto.", "Si alza prima dell'alba per meditare e allenarsi, qualunque cosa accada." },
			("monk", false) => new[] { "Keeps calm even in chaos and measures every gesture.", "Rises before dawn to meditate and train, whatever happens." },
			("paladin", true) => new[] { "Mantiene sempre la parola data, anche quando gli costa cara.", "Si mette tra il pericolo e gli innocenti senza pensarci due volte." },
			("paladin", false) => new[] { "Always keeps their word, even when it costs dearly.", "Steps between danger and the innocent without a second thought." },
			("ranger", true) => new[] { "Legge le tracce come altri leggono i libri e diffida delle strade troppo battute.", "Preferisce osservare in silenzio prima di fidarsi di qualcuno." },
			("ranger", false) => new[] { "Reads tracks as others read books and distrusts roads that are too well travelled.", "Prefers to watch in silence before trusting anyone." },
			("rogue", true) => new[] { "Nota sempre le uscite di una stanza e chi tiene d'occhio chi.", "Ha una risposta pronta per tutto e un piano di riserva per il piano di riserva." },
			("rogue", false) => new[] { "Always notes the exits of a room and who is watching whom.", "Has a quick answer for everything and a backup plan for the backup plan." },
			("sorcerer", true) => new[] { "Sente la magia scorrergli nelle vene e a volte fatica a trattenerla quando si emoziona.", "È curioso di scoprire da dove venga davvero il suo potere." },
			("sorcerer", false) => new[] { "Feels magic flowing in their veins and sometimes struggles to hold it back when moved.", "Is eager to find out where their power truly comes from." },
			("warlock", true) => new[] { "Custodisce segreti sul proprio patto e cambia discorso quando qualcuno fa troppe domande.", "Ha un sorriso enigmatico e sembra sempre sapere più di quanto dica." },
			("warlock", false) => new[] { "Guards secrets about their pact and changes the subject when asked too much.", "Wears an enigmatic smile and always seems to know more than they say." },
			("wizard", true) => new[] { "Prende appunti su tutto ciò che vede e non perde occasione per correggere un errore.", "Si perde nei libri al punto da dimenticare di mangiare." },
			("wizard", false) => new[] { "Takes notes on everything they see and never misses a chance to correct a mistake.", "Gets so lost in books that they forget to eat." },
			(_, true) => new[] { "Affronta ogni giornata con curiosità e una certa testardaggine.", "Osserva molto prima di parlare e ricorda ogni dettaglio." },
			_ => new[] { "Faces every day with curiosity and a certain stubbornness.", "Watches a lot before speaking and remembers every detail." }
		};

		private static IReadOnlyList<string> AlignmentTraits(Alignment alignment, bool it)
		{
			var name = alignment.ToString();
			if (name.EndsWith("Good"))
			{
				return it
					? new[] { "Offre aiuto senza aspettarsi nulla in cambio.", "Divide volentieri il poco che ha con chi è in difficoltà." }
					: new[] { "Offers help without expecting anything in return.", "Gladly shares the little they have with those in need." };
			}
			if (name.EndsWith("Evil"))
			{
				return it
					? new[] { "Valuta ogni persona per ciò che può offrirgli.", "Non dimentica mai un torto e sa aspettare il momento giusto." }
					: new[] { "Weighs every person by what they can offer.", "Never forgets a wrong and knows how to wait for the right moment." };
			}
			if (name.StartsWith("Lawful"))
			{
				return it
					? new[] { "Segue un codice personale preciso e si aspetta che anche gli altri ne abbiano uno.", "Ama l'ordine: ogni cosa al suo posto, ogni promessa mantenuta." }
					: new[] { "Follows a precise personal code and expects others to have one too.", "Loves order: everything in its place, every promise kept." };
			}
			if (name.StartsWith("Chaotic"))
			{
				return it
					? new[] { "Detesta le regole imposte e segue l'istinto.", "Cambia idea all'improvviso, ma sempre con convinzione." }
					: new[] { "Hates imposed rules and follows instinct.", "Changes their mind suddenly, but always with conviction." };
			}

			return it
				? new[] { "Cerca sempre la via di mezzo e diffida degli estremi.", "Prende le cose come vengono, senza farsi troppe illusioni." }
				: new[] { "Always looks for a middle way and distrusts extremes.", "Takes things as they come, without too many illusions." };
		}

		// ===== Ideals by alignment =====

		private static IReadOnlyList<string> Ideals(Alignment alignment, bool it) => (alignment, it) switch
		{
			(Alignment.LawfulGood, true) => new[] { "Giustizia. Le leggi eque proteggono i deboli e vanno difese.", "Dovere. Chi ha la forza di aiutare ha anche il dovere di farlo." },
			(Alignment.LawfulGood, false) => new[] { "Justice. Fair laws protect the weak and must be defended.", "Duty. Those strong enough to help are bound to do so." },
			(Alignment.NeutralGood, true) => new[] { "Compassione. Ogni vita merita una seconda possibilità.", "Bene comune. Conta ciò che si fa, non le regole con cui lo si fa." },
			(Alignment.NeutralGood, false) => new[] { "Compassion. Every life deserves a second chance.", "Common good. What matters is what you do, not the rules you follow." },
			(Alignment.ChaoticGood, true) => new[] { "Libertà. Nessuno dovrebbe vivere in catene, di ferro o di leggi ingiuste.", "Ribellione. I tiranni cadono quando qualcuno ha il coraggio di sfidarli." },
			(Alignment.ChaoticGood, false) => new[] { "Freedom. No one should live in chains, of iron or of unjust laws.", "Rebellion. Tyrants fall when someone dares to defy them." },
			(Alignment.LawfulNeutral, true) => new[] { "Ordine. Senza regole il mondo scivola nel caos.", "Tradizione. Le usanze degli antenati vanno rispettate e tramandate." },
			(Alignment.LawfulNeutral, false) => new[] { "Order. Without rules the world slides into chaos.", "Tradition. The customs of the ancestors must be respected and handed down." },
			(Alignment.Neutral, true) => new[] { "Equilibrio. Ogni eccesso porta con sé il suo contrario.", "Conoscenza. Capire il mondo viene prima di giudicarlo." },
			(Alignment.Neutral, false) => new[] { "Balance. Every excess carries its opposite.", "Knowledge. Understanding the world comes before judging it." },
			(Alignment.ChaoticNeutral, true) => new[] { "Indipendenza. Decido io la mia strada, nessun altro.", "Cambiamento. Ciò che resta fermo marcisce." },
			(Alignment.ChaoticNeutral, false) => new[] { "Independence. I choose my own road, nobody else.", "Change. What stands still rots." },
			(Alignment.LawfulEvil, true) => new[] { "Potere. Chi comanda scrive le regole, e io intendo scriverle.", "Gerarchia. Ognuno ha il suo posto, e il mio è in alto." },
			(Alignment.LawfulEvil, false) => new[] { "Power. Whoever rules writes the rules, and I mean to write them.", "Hierarchy. Everyone has their place, and mine is at the top." },
			(Alignment.NeutralEvil, true) => new[] { "Avidità. Prendo ciò che voglio, quando posso.", "Sopravvivenza. Prima io, poi tutti gli altri." },
			(Alignment.NeutralEvil, false) => new[] { "Greed. I take what I want, when I can.", "Survival. Me first, then everyone else." },
			(_, true) => new[] { "Forza. Solo il più forte merita di sopravvivere.", "Caos. Il mondo è più interessante quando brucia." },
			_ => new[] { "Might. Only the strongest deserve to survive.", "Chaos. The world is more interesting when it burns." }
		};

		// ===== Bonds: people, places and promises tied to the background and the class =====

		private static string Bonds(StorySeed seed, Random rng, bool it)
		{
			var options = it
				? new[]
				{
					$"Deve tutto a un mentore conosciuto ai tempi in cui era {Article(seed.BackgroundName, it)}: un giorno vuole ripagare quel debito.",
					$"Porta con sé un ricordo della propria famiglia, l'unica cosa che gli resta della sua gente {seed.SpeciesName.ToLowerInvariant()}.",
					$"Ha giurato di proteggere il villaggio che lo ha accolto quando ha mosso i primi passi come {seed.ClassName.ToLowerInvariant()}.",
					"Cerca qualcuno che è scomparso anni fa e non smetterà finché non avrà una risposta.",
					"Ha un vecchio amico d'infanzia a cui scrive ogni volta che può, anche quando le lettere tornano indietro."
				}
				: new[]
				{
					$"Owes everything to a mentor met in their days as {Article(seed.BackgroundName, it)}, and means to repay that debt one day.",
					$"Carries a keepsake of their family, the only thing left of their {seed.SpeciesName.ToLowerInvariant()} kin.",
					$"Swore to protect the village that took them in when they took their first steps as a {seed.ClassName.ToLowerInvariant()}.",
					"Is looking for someone who disappeared years ago and will not stop until they find an answer.",
					"Writes to a childhood friend whenever they can, even when the letters come back."
				};
			return Pick(rng, options);
		}

		// ===== Flaws =====

		private static string Flaws(StorySeed seed, Random rng, bool it)
		{
			var general = it
				? new List<string> { "Non sa dire di no a una scommessa.", "Si fida troppo in fretta di chi lo lusinga.", "Quando perde la pazienza, la perde del tutto.", "Ha paura del buio, anche se non lo ammetterebbe mai.", "Non ammette mai di aver sbagliato." }
				: new List<string> { "Cannot refuse a bet.", "Trusts flatterers far too quickly.", "When they lose their temper, they lose it completely.", "Is afraid of the dark, though they would never admit it.", "Never admits being wrong." };
			var name = seed.Alignment.ToString();
			if (name.EndsWith("Good"))
			{
				general.Add(it ? "Aiuta chiunque glielo chieda, anche quando è evidentemente una trappola." : "Helps anyone who asks, even when it is plainly a trap.");
			}
			if (name.EndsWith("Evil"))
			{
				general.Add(it ? "Non sopporta che qualcuno sia più ammirato di lui." : "Cannot stand anyone being more admired than they are.");
			}
			if (name.StartsWith("Lawful"))
			{
				general.Add(it ? "Segue le regole anche quando portano chiaramente al disastro." : "Follows the rules even when they plainly lead to disaster.");
			}
			if (name.StartsWith("Chaotic"))
			{
				general.Add(it ? "Agisce d'impulso e pensa alle conseguenze solo dopo." : "Acts on impulse and thinks of the consequences only afterwards.");
			}
			return Pick(rng, general);
		}

		// ===== Appearance =====

		private static string Appearance(StorySeed seed, Random rng, bool it)
		{
			var build = it
				? new[] { "Ha un fisico asciutto e nervoso", "È robusto e dalle spalle larghe", "Ha una corporatura minuta ma agile", "È alto e un po' allampanato" }
				: new[] { "Has a lean, wiry build", "Is sturdy and broad-shouldered", "Has a small but nimble frame", "Is tall and somewhat lanky" };
			var detail = it
				? new[] { "una vecchia cicatrice sul sopracciglio", "occhi attenti che non stanno mai fermi", "capelli raccolti in una treccia disordinata", "mani segnate dal lavoro", "un sorriso storto che mette a proprio agio" }
				: new[] { "an old scar across one eyebrow", "watchful eyes that never stay still", "hair tied in an untidy braid", "hands marked by hard work", "a crooked smile that puts people at ease" };
			var gear = (seed.ClassKey, it) switch
			{
				("wizard" or "sorcerer" or "warlock", true) => "veste abiti comodi, con le tasche piene di pergamene e componenti",
				("wizard" or "sorcerer" or "warlock", false) => "wears comfortable clothes with pockets full of scrolls and components",
				("cleric" or "paladin", true) => "porta sempre in vista il simbolo della propria fede",
				("cleric" or "paladin", false) => "always wears the symbol of their faith in plain sight",
				("druid" or "ranger", true) => "veste colori della terra, con foglie e piume intrecciate negli abiti",
				("druid" or "ranger", false) => "wears earthy colours, with leaves and feathers woven into their clothes",
				("rogue", true) => "veste abiti scuri e silenziosi che non attirano l'attenzione",
				("rogue", false) => "wears dark, quiet clothes that draw no attention",
				("bard", true) => "veste colori vivaci e non si separa mai dal proprio strumento",
				("bard", false) => "wears bright colours and is never without their instrument",
				(_, true) => "veste un equipaggiamento pratico e ben curato",
				_ => "wears practical, well-kept gear"
			};
			return it
				? $"{Pick(rng, build)}, con {Pick(rng, detail)}; {gear}. Si riconosce subito come {Article(seed.SpeciesName, it)}."
				: $"{Pick(rng, build)}, with {Pick(rng, detail)}; {gear}. Unmistakably {Article(seed.SpeciesName, it)}.";
		}

		// ===== Backstory: a short paragraph from origin, background and class =====

		private static string Backstory(StorySeed seed, Random rng, bool it)
		{
			var name = string.IsNullOrWhiteSpace(seed.Name) ? (it ? "Il personaggio" : "The character") : seed.Name.Trim();
			var start = it
				? new[] { "è cresciuto ai margini di una piccola comunità", "è nato in una città affollata e rumorosa", "ha trascorso l'infanzia viaggiando di villaggio in villaggio", "è stato allevato da parenti lontani dopo aver perso la famiglia" }
				: new[] { "grew up on the edge of a small community", "was born in a crowded, noisy city", "spent their childhood travelling from village to village", "was raised by distant relatives after losing their family" };
			var turn = it
				? new[] { "finché un evento inatteso non ha cambiato tutto", "fino al giorno in cui ha scoperto di avere un talento fuori dal comune", "finché un debito, o forse una promessa, non lo ha spinto lontano da casa", "finché la curiosità non ha avuto la meglio sulla prudenza" }
				: new[] { "until an unexpected event changed everything", "until the day they discovered an uncommon talent", "until a debt, or perhaps a promise, drove them far from home", "until curiosity got the better of caution" };
			var goal = it
				? new[] { "Ora cerca un posto nel mondo e compagni di cui potersi fidare.", "Ora vuole dimostrare a se stesso, e agli altri, di cosa è capace.", "Ora insegue una vecchia storia che potrebbe essere più vera di quanto sembri.", "Ora viaggia per mettere alla prova ciò che ha imparato." }
				: new[] { "Now they seek a place in the world and companions they can trust.", "Now they want to prove to themselves, and to others, what they can do.", "Now they chase an old tale that might be truer than it seems.", "Now they travel to put what they have learned to the test." };
			return it
				? $"{name}, {Article(seed.SpeciesName, it)}, {Pick(rng, start)}. Gli anni come {seed.BackgroundName.ToLowerInvariant()} gli hanno insegnato a cavarsela, {Pick(rng, turn)}: così ha intrapreso la strada di {Article(seed.ClassName, it)}. {Pick(rng, goal)}"
				: $"{name}, {Article(seed.SpeciesName, it)}, {Pick(rng, start)}. The years as {Article(seed.BackgroundName, it)} taught them to get by, {Pick(rng, turn)}: so they took up the path of {Article(seed.ClassName, it)}. {Pick(rng, goal)}";
		}

		//	"un elfo" / "an elf": an indefinite article before a lower-case noun
		private static string Article(string noun, bool it)
		{
			var word = noun.Trim().ToLowerInvariant();
			if (word.Length == 0)
			{
				return word;
			}
			if (it)
			{
				var uno = word.StartsWith("gn") || word.StartsWith("ps") || word.StartsWith('z') || word.StartsWith('x') || (word.StartsWith('s') && word.Length > 1 && !"aeiou".Contains(word[1]));
				return uno ? $"uno {word}" : $"un {word}";
			}
			return "aeiou".Contains(word[0]) ? $"an {word}" : $"a {word}";
		}
	}
}
