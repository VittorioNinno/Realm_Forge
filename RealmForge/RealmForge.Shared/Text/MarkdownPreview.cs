using System.Text.RegularExpressions;

namespace RealmForge.Shared.Text
{
	///	<summary>
	///	Turns a Markdown description into a single line of plain text for card previews:
	///	formatting marks, headings and tables are removed, and the result is cut on a word boundary.
	///	</summary>
	public static partial class MarkdownPreview
	{
		public const int DefaultLength = 160;

		public static string ToPlainText(string? markdown, int maxLength = DefaultLength)
		{
			if (string.IsNullOrWhiteSpace(markdown))
			{
				return string.Empty;
			}

			var parts = new List<string>();

			foreach (var rawLine in markdown.Replace("\r", string.Empty).Split('\n'))
			{
				var line = rawLine.Trim();

				//	Tables and headings carry no useful preview text
				if (line.Length == 0 || line.StartsWith('|') || line.StartsWith('#'))
				{
					continue;
				}

				line = ListMarker().Replace(line, string.Empty);
				line = Link().Replace(line, "$1");
				line = Emphasis().Replace(line, string.Empty);
				parts.Add(line.Trim());
			}

			var text = Spaces().Replace(string.Join(' ', parts), " ").Trim();

			if (text.Length <= maxLength)
			{
				return text;
			}

			var cut = text.LastIndexOf(' ', maxLength - 1);
			return text[..(cut > maxLength / 2 ? cut : maxLength - 1)].TrimEnd(' ', ',', ';', ':', '.') + "…";
		}

		//	"- ", "* ", "+ ", "• " and "1. " at the start of a line
		[GeneratedRegex(@"^(?:[-*+•]|\d+\.)\s+")]
		private static partial Regex ListMarker();

		//	[text](url) -> text
		[GeneratedRegex(@"\[([^\]]+)\]\([^)]*\)")]
		private static partial Regex Link();

		//	**bold**, __bold__, *italic*, _italic_ and `code` marks
		[GeneratedRegex(@"\*{1,3}|(?<!\w)_{1,3}|_{1,3}(?!\w)|`")]
		private static partial Regex Emphasis();

		[GeneratedRegex(@"\s+")]
		private static partial Regex Spaces();
	}
}
