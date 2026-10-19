using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace RealmForge.Shared.Text
{
	///	<summary>
	///	A rules term that can be linked: its glossary entry, the label and summary shown in the tooltip, and its forms.
	///	Forms are case-insensitive; "=Term" matches only with that exact case, "~regex" is a regular expression.
	///	</summary>
	public record GlossaryTerm(Guid Id, string Name, string Label, string Summary, IReadOnlyList<string> Aliases);

	///	<summary>
	///	Links the rules terms of one edition and language in rendered HTML: the first occurrence of each term becomes
	///	a link to its glossary entry, with the data of the tooltip. Text inside links, code, headings and italics (spell names) is left alone.
	///	</summary>
	public sealed class GlossaryLinker
	{
		public const string CssClass = "rf-term";

		private const int CacheLimit = 400;

		//	Elements whose text is never linked
		private static readonly HashSet<string> SkippedElements = new(StringComparer.OrdinalIgnoreCase) { "a", "code", "pre", "em", "h1", "h2", "h3", "h4", "h5", "h6" };

		private static readonly Regex HtmlParts = new(@"(<[^>]*>)", RegexOptions.Compiled);
		private static readonly Regex TagName = new(@"^<(/?)([a-zA-Z0-9]+)", RegexOptions.Compiled);
		private static readonly Regex Apostrophes = new("['’]", RegexOptions.Compiled);

		private readonly Regex? _terms;
		private readonly GlossaryTerm[] _termOfGroup = Array.Empty<GlossaryTerm>();
		private readonly int[] _groupNumbers = Array.Empty<int>();
		private readonly Dictionary<string, string> _cache = new();

		public GlossaryLinker(IEnumerable<GlossaryTerm> terms)
		{
			//	Longer forms first, so "azione bonus" wins over a shorter form that starts at the same point
			var forms = terms
				.SelectMany(t => t.Aliases.Where(a => !string.IsNullOrWhiteSpace(a)).Select(a => (Term: t, Alias: a.Trim())))
				.OrderByDescending(f => f.Alias.TrimStart('=', '~').Length)
				.ToList();

			if (forms.Count == 0)
			{
				return;
			}

			_termOfGroup = forms.Select(f => f.Term).ToArray();
			var alternatives = string.Join("|", forms.Select((f, i) => $"(?<t{i}>{ToPattern(f.Alias)})"));

			//	Whole words only (letters, digits and underscore around the term are not allowed)
			_terms = new Regex($@"(?<![\p{{L}}\p{{N}}_])(?:{alternatives})(?![\p{{L}}\p{{N}}_])",
				RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);

			_groupNumbers = Enumerable.Range(0, forms.Count).Select(i => _terms.GroupNumberFromName($"t{i}")).ToArray();
		}

		public bool HasTerms => _terms is not null;

		///	<summary>
		///	Returns the HTML with the terms linked; the entry <paramref name="exclude"/> (the one being shown) is never linked.
		///	</summary>
		public string Link(string html, Guid? exclude = null)
		{
			if (_terms is null || string.IsNullOrEmpty(html))
			{
				return html;
			}

			var cacheKey = $"{exclude}|{html}";
			if (_cache.TryGetValue(cacheKey, out var cached))
			{
				return cached;
			}

			var linked = new HashSet<Guid>();
			if (exclude is { } excluded)
			{
				linked.Add(excluded);
			}

			var result = new StringBuilder(html.Length + 256);
			var skipDepth = 0;

			foreach (var part in HtmlParts.Split(html))
			{
				if (part.Length == 0)
				{
					continue;
				}

				if (part[0] == '<')
				{
					var tag = TagName.Match(part);
					if (tag.Success && SkippedElements.Contains(tag.Groups[2].Value) && !part.EndsWith("/>", StringComparison.Ordinal))
					{
						skipDepth = tag.Groups[1].Value == "/" ? Math.Max(0, skipDepth - 1) : skipDepth + 1;
					}

					result.Append(part);
					continue;
				}

				result.Append(skipDepth > 0 ? part : _terms.Replace(part, match => Replace(match, linked)));
			}

			if (_cache.Count >= CacheLimit)
			{
				_cache.Clear();
			}

			var text = result.ToString();
			_cache[cacheKey] = text;
			return text;
		}

		private string Replace(Match match, HashSet<Guid> linked)
		{
			GlossaryTerm? term = null;
			for (var i = 0; i < _groupNumbers.Length; i++)
			{
				if (match.Groups[_groupNumbers[i]].Success)
				{
					term = _termOfGroup[i];
					break;
				}
			}

			//	Only the first occurrence of each term, so the text does not turn into a sea of links
			if (term is null || !linked.Add(term.Id))
			{
				return match.Value;
			}

			return $"<a class=\"{CssClass}\" href=\"rules?id={term.Id}\" data-term-name=\"{WebUtility.HtmlEncode(term.Name)}\" " +
				$"data-term-label=\"{WebUtility.HtmlEncode(term.Label)}\" data-term-tip=\"{WebUtility.HtmlEncode(term.Summary)}\">{match.Value}</a>";
		}

		private static string ToPattern(string alias)
		{
			if (alias.StartsWith('~'))
			{
				return $"(?:{alias[1..]})";
			}

			var exactCase = alias.StartsWith('=');
			var text = exactCase ? alias[1..] : alias;

			//	Spaces match any run of white space, straight and typographic apostrophes are interchangeable
			var pattern = Regex.Escape(text).Replace(@"\ ", @"\s+");
			pattern = Apostrophes.Replace(pattern, "['’]");

			return exactCase ? $"(?-i:{pattern})" : pattern;
		}
	}
}
