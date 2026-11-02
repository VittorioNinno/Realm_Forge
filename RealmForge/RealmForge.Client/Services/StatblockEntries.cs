using System.Text.RegularExpressions;

namespace RealmForge.Client.Services
{
	///	<summary>
	///	The entries of a statblock section (Markdown, one paragraph per entry, "***Name.*** text") split for the NPC
	///	dossier, with the attack bonus and the damage of an attack ("+3 al tiro per colpire … Colpito: 4 (1d6 + 1)").
	///	</summary>
	public static partial class StatblockEntries
	{
		public sealed record Entry(string Name, string Body, string? ToHit, string? Damage);

		public static List<Entry> Parse(string? markdown)
		{
			var entries = new List<Entry>();
			if (string.IsNullOrWhiteSpace(markdown))
			{
				return entries;
			}
			foreach (var paragraph in ParagraphBreak().Split(markdown.Trim()))
			{
				var text = paragraph.Trim();
				if (text.Length == 0)
				{
					continue;
				}
				var head = Heading().Match(text);
				var name = head.Success ? head.Groups[1].Value.Trim().TrimEnd('.') : string.Empty;
				var body = head.Success ? text[head.Length..].Trim() : text;

				//	A paragraph without its own name continues the previous entry (a list of spells, a second line)
				if (name.Length == 0 && entries.Count > 0)
				{
					var last = entries[^1];
					entries[^1] = last with { Body = last.Body + "\n\n" + body };
					continue;
				}
				var hit = ToHit().Match(body);
				var damage = Damage().Match(body);
				entries.Add(new Entry(name, body, hit.Success ? hit.Groups[1].Value : null, damage.Success ? damage.Groups[1].Value.Trim() : null));
			}
			return entries;
		}

		[GeneratedRegex(@"\n\s*\n")]
		private static partial Regex ParagraphBreak();

		[GeneratedRegex(@"^\*{2,3}([^*]+?)\*{2,3}")]
		private static partial Regex Heading();

		[GeneratedRegex(@"([+\-−]\s?\d+)\s+(?:al tiro per colpire|to hit)", RegexOptions.IgnoreCase)]
		private static partial Regex ToHit();

		[GeneratedRegex(@"(?:Colpito|Hit):\**\s*(\d+\s*\([^)]*\))", RegexOptions.IgnoreCase)]
		private static partial Regex Damage();
	}
}
