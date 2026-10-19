using System.Text.RegularExpressions;

namespace RealmForge.Shared.Text
{
	///	<summary>
	///	Finds the equipment item named in a line of starting equipment ("un'ascia bipenne", "4 Handaxes", "20 frecce"):
	///	articles, quantities and notes in parentheses are ignored, and simple plurals are tried in both languages.
	///	</summary>
	public sealed partial class EquipmentNameMatcher
	{
		private readonly Dictionary<string, Guid> _items = new(StringComparer.Ordinal);

		public EquipmentNameMatcher(IEnumerable<(string Name, Guid Id)> items)
		{
			foreach (var (name, id) in items)
			{
				var key = Key(name);
				if (key.Length > 0)
				{
					_items.TryAdd(key, id);
				}
			}
		}

		public Guid? Find(string text)
		{
			foreach (var candidate in Candidates(text))
			{
				if (_items.TryGetValue(candidate, out var id))
				{
					return id;
				}
			}

			return null;
		}

		///	<summary>
		///	Lower case, straight apostrophes, no leading article or quantity, no note in parentheses.
		///	</summary>
		public static string Key(string text)
		{
			var key = text.Trim().ToLowerInvariant().Replace('’', '\'');
			key = Parenthetical().Replace(key, string.Empty);
			string previous;
			do
			{
				previous = key;
				key = Leading().Replace(key, string.Empty).Trim();
			}
			while (key != previous);

			return key.Trim(' ', '.', ',', ';', ':');
		}

		///	<summary>
		///	The key and its singular forms (English "-s"/"-es", Italian "-i"/"-e" endings word by word).
		///	</summary>
		public static IEnumerable<string> Candidates(string text)
		{
			var key = Key(text);
			if (key.Length == 0)
			{
				yield break;
			}

			yield return key;

			if (key.EndsWith("es", StringComparison.Ordinal))
			{
				yield return key[..^2];
			}
			if (key.EndsWith('s'))
			{
				yield return key[..^1];
			}

			//	Italian: every word of the name agrees ("spade corte" → "spada corta", "frecce" → "freccia")
			var words = key.Split(' ');
			if (words.Length > 3)
			{
				yield break;
			}

			IEnumerable<string> forms = new[] { string.Empty };
			foreach (var word in words)
			{
				var options = Singulars(word).Prepend(word).Distinct().ToList();
				forms = forms.SelectMany(f => options.Select(o => f.Length == 0 ? o : $"{f} {o}")).ToList();
			}

			foreach (var form in forms)
			{
				if (form != key)
				{
					yield return form;
				}
			}
		}

		private static IEnumerable<string> Singulars(string word)
		{
			if (word.Length < 4)
			{
				yield break;
			}
			if (word.EndsWith("chi", StringComparison.Ordinal)) yield return word[..^3] + "co";
			if (word.EndsWith("ghi", StringComparison.Ordinal)) yield return word[..^3] + "go";
			if (word.EndsWith("che", StringComparison.Ordinal)) yield return word[..^3] + "ca";
			if (word.EndsWith("ghe", StringComparison.Ordinal)) yield return word[..^3] + "ga";
			if (word.EndsWith("ce", StringComparison.Ordinal)) yield return word[..^2] + "cia";
			if (word.EndsWith("ge", StringComparison.Ordinal)) yield return word[..^2] + "gia";
			if (word.EndsWith('i'))
			{
				yield return word[..^1] + "o";
				yield return word[..^1] + "e";
			}
			if (word.EndsWith('e'))
			{
				yield return word[..^1] + "a";
			}
		}

		//	"(if proficient)", "(dello stesso tipo scelto sopra)"
		[GeneratedRegex(@"\s*\([^)]*\)")]
		private static partial Regex Parenthetical();

		//	Articles and quantities in both languages, also "un set di", "a set of", "un paio di"
		[GeneratedRegex(@"^(?:\d+\s+|un'|un\s+|una\s+|uno\s+|il\s+|lo\s+|la\s+|l'|i\s+|gli\s+|le\s+|degli\s+|delle\s+|dei\s+|del\s+|della\s+|due\s+|tre\s+|quattro\s+|cinque\s+|dieci\s+|a\s+|an\s+|the\s+|two\s+|three\s+|four\s+|five\s+|ten\s+|set\s+(?:of|di)\s+|paio\s+di\s+|pair\s+of\s+)")]
		private static partial Regex Leading();
	}
}
