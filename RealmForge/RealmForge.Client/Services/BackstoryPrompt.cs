using System.Text;
using RealmForge.Shared.Enums;

namespace RealmForge.Client.Services
{
	///	<summary>
	///	What the backstory assistant's model reads: who the character is, what is already written on the sheet, and the
	///	latest turns of the conversation. Older turns drop out to stay inside the model's window, so the conversation can
	///	go on for ever; what matters is kept because the player moves it into the story.
	///	</summary>
	public static class BackstoryPrompt
	{
		public sealed record Message(string Role, string Content);

		///	<summary>The parts of the sheet the assistant builds on, and can fill.</summary>
		public sealed record Sheet(string Traits, string Ideals, string Bonds, string Flaws, string Backstory);

		//	The model's window is 4096 tokens: the prompt stays well below, leaving room for the answer
		private const int BudgetChars = 7000;
		private const int SheetChars = 1600;

		public static List<Message> Build(StorySeed seed, Sheet sheet, IReadOnlyList<Message> turns)
		{
			var system = System(seed, sheet);
			var kept = new List<Message>();
			var used = system.Length;
			for (var i = turns.Count - 1; i >= 0; i--)
			{
				var turn = turns[i];
				if (used + turn.Content.Length > BudgetChars && kept.Count > 0)
				{
					break;
				}
				kept.Insert(0, turn);
				used += turn.Content.Length;
			}
			//	The window starts with the player
			while (kept.Count > 1 && kept[0].Role != "user")
			{
				kept.RemoveAt(0);
			}
			var messages = new List<Message> { new("system", system) };
			messages.AddRange(kept);
			return messages;
		}

		private static string System(StorySeed seed, Sheet sheet)
		{
			var it = seed.Language == LanguageCode.It;
			var sb = new StringBuilder();
			sb.AppendLine(it
				? "Sei un narratore esperto di giochi di ruolo fantasy. Aiuti un giocatore a costruire il passato del suo personaggio."
				: "You are a storyteller skilled in fantasy roleplaying games. You help a player build their character's past.");
			sb.AppendLine(it
				? "Regole: rispondi sempre in italiano; al massimo 150 parole; prendi gli spunti del giocatore e arricchiscili con dettagli concreti (persone con un nome, luoghi, un conflitto, un segreto); non contraddire ciò che ha già deciso; inventa nomi originali, non usare personaggi o luoghi di libri, film o manuali; chiudi con UNA domanda per approfondire."
				: "Rules: always answer in English; at most 150 words; take the player's ideas and enrich them with concrete details (named people, places, a conflict, a secret); never contradict what they already decided; invent original names, never use characters or places from books, films or rulebooks; end with ONE question to dig deeper.");
			sb.AppendLine();
			sb.AppendLine(it ? "Il personaggio:" : "The character:");
			Line(sb, it ? "Nome" : "Name", seed.Name);
			Line(sb, it ? "Specie" : "Species", seed.SpeciesName);
			Line(sb, it ? "Classe" : "Class", seed.ClassName);
			Line(sb, "Background", seed.BackgroundName);
			Line(sb, it ? "Allineamento" : "Alignment", seed.Alignment.ToString());
			var written = new StringBuilder();
			Line(written, it ? "Tratti" : "Traits", sheet.Traits);
			Line(written, it ? "Ideali" : "Ideals", sheet.Ideals);
			Line(written, it ? "Legami" : "Bonds", sheet.Bonds);
			Line(written, it ? "Difetti" : "Flaws", sheet.Flaws);
			Line(written, it ? "Storia" : "Story", sheet.Backstory);
			if (written.Length > 0)
			{
				sb.AppendLine();
				sb.AppendLine(it ? "Già scritto sulla scheda (è canone, rispettalo):" : "Already on the sheet (canon, respect it):");
				var text = written.ToString();
				sb.Append(text.Length > SheetChars ? text[..SheetChars] + "…\n" : text);
			}
			return sb.ToString();
		}

		private static void Line(StringBuilder sb, string label, string? value)
		{
			if (!string.IsNullOrWhiteSpace(value))
			{
				sb.Append("- ").Append(label).Append(": ").AppendLine(value.Trim());
			}
		}

		///	<summary>The request that turns the conversation into the four personality fields, one per line.</summary>
		public static string FieldsRequest(LanguageCode lang) => lang == LanguageCode.It
			? "Riassumi quello che abbiamo deciso in quattro righe, esattamente in questo formato e senza altro testo:\nTratti: ...\nIdeali: ...\nLegami: ...\nDifetti: ..."
			: "Sum up what we decided in four lines, exactly in this format and with no other text:\nTraits: ...\nIdeals: ...\nBonds: ...\nFlaws: ...";

		///	<summary>The four fields read back from the model's answer (null where a line is missing).</summary>
		public static (string? Traits, string? Ideals, string? Bonds, string? Flaws) ReadFields(string answer)
		{
			string? traits = null, ideals = null, bonds = null, flaws = null;
			foreach (var raw in answer.Split('\n'))
			{
				var line = raw.Trim().TrimStart('-', '*', ' ').Replace("**", string.Empty);
				var colon = line.IndexOf(':');
				if (colon <= 0)
				{
					continue;
				}
				var key = line[..colon].Trim().ToLowerInvariant();
				var value = line[(colon + 1)..].Trim();
				if (value.Length == 0)
				{
					continue;
				}
				switch (key)
				{
					case "tratti" or "traits" or "tratti caratteriali" or "personality traits":
						traits = value;
						break;
					case "ideali" or "ideals":
						ideals = value;
						break;
					case "legami" or "bonds":
						bonds = value;
						break;
					case "difetti" or "flaws":
						flaws = value;
						break;
				}
			}
			return (traits, ideals, bonds, flaws);
		}
	}
}
