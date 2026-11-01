namespace RealmForge.Shared.Text
{
	///	<summary>
	///	How well an entry matches the text typed in a list's search box, so the entry named like the text comes first
	///	(searching "Paralizzato" opens with the condition, then the entries that only mention it): 0 = the name (or an
	///	alias) is the text, 1 = it starts with it, 2 = a word of it starts with it, 3 = it contains it, 4 = only the
	///	description does.
	///	</summary>
	public static class SearchRank
	{
		public const int TextOnly = 4;

		public static int Of(string? term, string name, IEnumerable<string?>? aliases = null)
		{
			var text = term?.Trim() ?? string.Empty;
			if (text.Length == 0)
			{
				return 0;
			}
			var best = TextOnly;
			foreach (var candidate in new[] { name }.Concat(aliases ?? Array.Empty<string?>()))
			{
				if (string.IsNullOrWhiteSpace(candidate))
				{
					continue;
				}
				var value = candidate.TrimStart('=').Trim();
				var rank = value.Equals(text, StringComparison.OrdinalIgnoreCase) ? 0
					: value.StartsWith(text, StringComparison.OrdinalIgnoreCase) ? 1
					: WordStarts(value, text) ? 2
					: value.Contains(text, StringComparison.OrdinalIgnoreCase) ? 3
					: TextOnly;
				best = Math.Min(best, rank);
			}
			return best;
		}

		//	"Palla di fuoco" for "fuoco", "Sguardo dell'esploratore" for "esploratore"
		private static bool WordStarts(string value, string text)
		{
			for (var i = value.IndexOf(text, StringComparison.OrdinalIgnoreCase); i > 0; i = value.IndexOf(text, i + 1, StringComparison.OrdinalIgnoreCase))
			{
				if (!char.IsLetterOrDigit(value[i - 1]))
				{
					return true;
				}
			}
			return false;
		}
	}
}
