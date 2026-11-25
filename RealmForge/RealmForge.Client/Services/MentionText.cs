using System.Net;
using System.Text.RegularExpressions;
using Markdig;
using RealmForge.Shared.DTOs;

namespace RealmForge.Client.Services
{
	///	<summary>
	///	Text written by the members of a campaign (notes, journal, secrets): Markdown without raw HTML, and the @mentions
	///	(@[Name](kind:id)) shown as links to what they name (a character's sheet, an NPC's dossier, a page of the journal)
	///	or as tags.
	///	</summary>
	public static partial class MentionText
	{
		private static readonly MarkdownPipeline Pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().DisableHtml().Build();

		[GeneratedRegex(@"@\[(?<name>[^\]\n]{1,120})\]\((?<kind>[a-z]+):(?<id>[0-9a-fA-F-]{36})\)")]
		private static partial Regex TokenPattern();

		public static string Token(MentionDto m) => $"@[{m.Name.Replace("]", ")").Replace("[", "(")}]({m.Kind}:{m.Id})";

		public static string ToHtml(string? text)
		{
			if (string.IsNullOrWhiteSpace(text))
			{
				return string.Empty;
			}
			//	The mentions leave the text as placeholders Markdown does not touch, then come back as links
			var found = new List<string>();
			var marked = TokenPattern().Replace(text.Replace("\r", string.Empty), m =>
			{
				found.Add(Link(m.Groups["kind"].Value, m.Groups["id"].Value, m.Groups["name"].Value));
				return $"RFMENTION{found.Count - 1}X";
			});
			var html = Markdown.ToHtml(marked, Pipeline);
			for (var i = found.Count - 1; i >= 0; i--)
			{
				html = html.Replace($"RFMENTION{i}X", found[i]);
			}
			return html;
		}

		private static string Link(string kind, string id, string name)
		{
			var label = WebUtility.HtmlEncode("@" + name);
			var css = $"rf-mention rf-mention-{WebUtility.HtmlEncode(kind)}";
			var href = kind switch
			{
				"character" => $"characters/{id}",
				"npc" => $"npcs/{id}",
				_ => null
			};
			return href is null
				? $"<span class=\"{css}\">{label}</span>"
				: $"<a class=\"{css}\" href=\"{WebUtility.HtmlEncode(href)}\">{label}</a>";
		}
	}
}
