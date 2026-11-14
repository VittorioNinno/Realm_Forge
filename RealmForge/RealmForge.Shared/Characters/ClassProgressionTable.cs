using System.Text.RegularExpressions;

namespace RealmForge.Shared.Characters;

///	<summary>
///	The features a class gains at a class level, read from its progression table (markdown, in either language): the
///	row of that level, the column of the features ("Features", "Privilegi", "Capacità"), split at the commas.
///	</summary>
public static partial class ClassProgressionTable
{
	public static List<string> FeaturesAt(string? table, int classLevel)
	{
		var result = new List<string>();
		if (string.IsNullOrWhiteSpace(table) || classLevel < 1)
		{
			return result;
		}
		var rows = table.Split('\n').Select(l => l.Trim()).Where(l => l.StartsWith('|')).Select(Cells).ToList();
		if (rows.Count < 2)
		{
			return result;
		}
		var column = rows[0].FindIndex(h => FeatureHeader().IsMatch(h));
		if (column < 0)
		{
			return result;
		}
		foreach (var row in rows.Skip(1))
		{
			if (row.Count <= column || row.Count == 0)
			{
				continue;
			}
			var number = LeadingNumber().Match(row[0]);
			if (!number.Success || int.Parse(number.Value) != classLevel)
			{
				continue;
			}
			result.AddRange(row[column].Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
				.Where(f => f is not ("—" or "-" or "–")));
			break;
		}
		return result;
	}

	private static List<string> Cells(string line) =>
		line.Trim('|').Split('|').Select(c => c.Trim()).ToList();

	[GeneratedRegex(@"^(features?|privilegi|capacit[àa]|caratteristiche di classe)$", RegexOptions.IgnoreCase)]
	private static partial Regex FeatureHeader();

	[GeneratedRegex(@"^\d+")]
	private static partial Regex LeadingNumber();
}
