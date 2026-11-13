using System.Text.RegularExpressions;

namespace RealmForge.Client.Services
{
	///	<summary>
	///	Reads the statblock texts of a monster to show them in pieces: the entries ("***Name.*** text"), the roll to hit,
	///	the damage, the saving throw and the uses per day of an action, the cost of a legendary action, lists split by
	///	commas. Both the Italian and the English wording.
	///	</summary>
	public static class StatblockText
	{
		public sealed record Entry(string Name, string Body);

		public static List<Entry> Entries(string? markdown)
		{
			var list = new List<Entry>();
			if (string.IsNullOrWhiteSpace(markdown))
			{
				return list;
			}
			foreach (var block in Regex.Split(markdown.Trim(), @"\r?\n\s*\r?\n|\r?\n(?=\*{2,3}[^*])"))
			{
				var text = block.Trim();
				if (text.Length == 0)
				{
					continue;
				}
				var m = Regex.Match(text, @"^\*{2,3}(?<name>[^*]+?)\*{2,3}\s*(?<body>.*)$", RegexOptions.Singleline);
				list.Add(m.Success ? new Entry(m.Groups["name"].Value.Trim().TrimEnd('.', ':').Trim(), m.Groups["body"].Value.Trim()) : new Entry(string.Empty, text));
			}
			return list;
		}

		//	"+4 al tiro per colpire", "+4 to hit"
		public static string? Hit(string body) => Regex.Match(body, @"([+\-−]\s?\d+)\s*(?:al tiro per colpire|to hit)", RegexOptions.IgnoreCase) is { Success: true } m
			? m.Groups[1].Value.Replace(" ", string.Empty).Replace('-', '−')
			: null;

		//	"12 (2d6 + 5) danni contundenti", "12 (2d6 + 5) bludgeoning damage": the first damage of the text
		public static string? Damage(string body)
		{
			var m = Regex.Match(body, @"(\d+)\s*\((\d+d\d+(?:\s*[+\-−]\s*\d+)?)\)\s*(?:danni\s+(?:da\s+)?(\w+)|(\w+)\s+damage)", RegexOptions.IgnoreCase);
			if (!m.Success)
			{
				return null;
			}
			var type = m.Groups[3].Success ? m.Groups[3].Value : m.Groups[4].Value;
			return $"{m.Groups[1].Value} ({m.Groups[2].Value}) {type}".Trim();
		}

		private static readonly (string Word, string Short)[] Abilities =
		{
			("Forza", "FOR"), ("Destrezza", "DES"), ("Costituzione", "COS"), ("Intelligenza", "INT"), ("Saggezza", "SAG"), ("Carisma", "CAR"),
			("Strength", "STR"), ("Dexterity", "DEX"), ("Constitution", "CON"), ("Intelligence", "INT"), ("Wisdom", "WIS"), ("Charisma", "CHA")
		};

		//	"tiro salvezza su Costituzione con CD 14", "DC 14 Constitution saving throw" → "TS COS CD 14" / "DC 14 CON"
		public static string? Save(string body, bool italian)
		{
			string? ability = null;
			string? dc = null;
			var it = Regex.Match(body, @"(?:tiro salvezza|TS)\s+su\s+(\w+)\s+(?:con\s+)?CD\s*(\d+)", RegexOptions.IgnoreCase);
			var en = Regex.Match(body, @"DC\s*(\d+)\s+(\w+)\s+saving throw", RegexOptions.IgnoreCase);
			if (it.Success)
			{
				(ability, dc) = (it.Groups[1].Value, it.Groups[2].Value);
			}
			else if (en.Success)
			{
				(ability, dc) = (en.Groups[2].Value, en.Groups[1].Value);
			}
			if (ability is null || Abilities.FirstOrDefault(a => a.Word.Equals(ability, StringComparison.OrdinalIgnoreCase)) is not { Word: not null } found)
			{
				return null;
			}
			return italian ? $"TS {found.Short} CD {dc}" : $"DC {dc} {found.Short}";
		}

		//	"Schiavizzare (3/giorno)", "Enslave (3/Day)" → the name and 3 uses; "(Ricarica 5–6)" stays in the name
		public static (string Name, int Uses) Uses(string name)
		{
			var m = Regex.Match(name, @"^(.*?)\s*\((\d+)\s*/\s*(?:giorno|day)[^)]*\)\s*$", RegexOptions.IgnoreCase);
			return m.Success ? (m.Groups[1].Value.Trim(), int.Parse(m.Groups[2].Value)) : (name, 0);
		}

		//	"Risucchio psichico (Costa 2 Azioni)", "Psychic Drain (Costs 2 Actions)"
		public static (string Name, int Cost) Cost(string name)
		{
			var m = Regex.Match(name, @"^(.*?)\s*\((?:costa|costs)\s+(\d+)\s+(?:azioni|actions)\)\s*$", RegexOptions.IgnoreCase);
			return m.Success ? (m.Groups[1].Value.Trim(), int.Parse(m.Groups[2].Value)) : (name, 1);
		}

		public static bool IsMultiattack(Entry e) => e.Name.StartsWith("Multiattac", StringComparison.OrdinalIgnoreCase);

		public static List<string> List(string? text) => string.IsNullOrWhiteSpace(text)
			? new List<string>()
			: Regex.Split(text, @",\s*(?![^()]*\))").Select(x => x.Trim()).Where(x => x.Length > 0).ToList();

		//	"Percezione +10" → ("Percezione", "+10"); "scurovisione 36 m" → ("scurovisione", "36 m")
		public static (string Label, string? Value) Split(string item)
		{
			var m = Regex.Match(item, @"^(.*?)\s+([+\-−]?\d+(?:[.,]\d+)?(?:\s*(?:m|ft\.?|feet|metri))?)$");
			return m.Success ? (m.Groups[1].Value, m.Groups[2].Value) : (item, null);
		}

		//	"17 (armatura naturale)" → ("17", "armatura naturale")
		public static (string Main, string? Note) Lead(string? text, string fallback)
		{
			if (string.IsNullOrWhiteSpace(text))
			{
				return (fallback, null);
			}
			var m = Regex.Match(text.Trim(), @"^([^,(]+?)\s*(?:\((.+)\)|,\s*(.+))?$");
			return m.Success ? (m.Groups[1].Value.Trim(), m.Groups[2].Success ? m.Groups[2].Value : m.Groups[3].Success ? m.Groups[3].Value : null) : (text, null);
		}
	}
}
