using System.Text.RegularExpressions;

namespace RealmForge.Shared.Rules;

///	<summary>
///	One group of dice of an expression: Count dice with Sides faces; Keep > 0 keeps only the highest (KeepHighest) or
///	the lowest dice, as in 2d20kh1 (advantage) and 2d20kl1 (disadvantage). Sign is -1 for a group subtracted.
///	</summary>
public sealed record DiceGroup(int Count, int Sides, int Keep = 0, bool KeepHighest = true, int Sign = 1);

///	<summary>
///	A rolled die: Dropped when advantage, disadvantage or keep left it out of the total.
///	</summary>
public sealed record RolledDie(int Sides, int Value, bool Dropped = false);

///	<summary>
///	Dice notation of the shared roller: groups like 1d20, 2d6, 4d6kh3, 2d20kl1 and whole numbers, joined by + and -
///	("1d20+5", "2d6 + 1d4 - 1", "d8"). At most 10 terms, 50 dice and 1000 faces per die, so a roll stays readable.
///	</summary>
public static partial class DiceNotation
{
	public const int MaxTerms = 10;
	public const int MaxDice = 50;
	public const int MaxSides = 1000;

	public sealed record Parsed(List<DiceGroup> Groups, int Modifier, string Text);

	public static bool TryParse(string? text, out Parsed parsed)
	{
		parsed = new Parsed(new List<DiceGroup>(), 0, string.Empty);
		//	Spaces only around the signs: "1d20 5" is not "1d205"
		var source = Spaces().Replace((text ?? string.Empty).Trim(), "$1").ToLowerInvariant();
		if (source.Length is 0 or > 80 || source.Any(char.IsWhiteSpace))
		{
			return false;
		}
		var matches = Term().Matches(source);
		if (matches.Count == 0 || matches.Count > MaxTerms || string.Concat(matches.Select(m => m.Value)) != source)
		{
			return false;
		}
		var groups = new List<DiceGroup>();
		var modifier = 0;
		var first = true;
		foreach (Match m in matches)
		{
			var sign = m.Groups["sign"].Value == "-" ? -1 : 1;
			if (!first && m.Groups["sign"].Value.Length == 0)
			{
				return false;
			}
			first = false;
			if (m.Groups["sides"].Success)
			{
				var count = m.Groups["count"].Value.Length == 0 ? 1 : int.Parse(m.Groups["count"].Value);
				var sides = int.Parse(m.Groups["sides"].Value);
				var keep = m.Groups["keep"].Success ? int.Parse(m.Groups["keep"].Value) : 0;
				if (count < 1 || sides < 2 || sides > MaxSides || keep > count || (m.Groups["keep"].Success && keep < 1))
				{
					return false;
				}
				groups.Add(new DiceGroup(count, sides, keep, m.Groups["kind"].Value != "kl", sign));
			}
			else
			{
				var value = int.Parse(m.Groups["number"].Value);
				if (value > 1000)
				{
					return false;
				}
				modifier += sign * value;
			}
		}
		if (groups.Count == 0 || groups.Sum(g => g.Count) > MaxDice)
		{
			return false;
		}
		parsed = new Parsed(groups, modifier, Format(groups, modifier));
		return true;
	}

	///	<summary>
	///	Rolls the groups with the given source of numbers (1..sides), marking the dice that are not kept.
	///	</summary>
	public static (List<RolledDie> Dice, int Total) Roll(Parsed parsed, Func<int, int> die)
	{
		var dice = new List<RolledDie>();
		var total = parsed.Modifier;
		foreach (var group in parsed.Groups)
		{
			var values = Enumerable.Range(0, group.Count).Select(_ => die(group.Sides)).ToList();
			var kept = Enumerable.Range(0, values.Count).ToList();
			if (group.Keep > 0)
			{
				kept = (group.KeepHighest
					? kept.OrderByDescending(i => values[i])
					: kept.OrderBy(i => values[i])).Take(group.Keep).ToList();
			}
			for (var i = 0; i < values.Count; i++)
			{
				var keptHere = kept.Contains(i);
				dice.Add(new RolledDie(group.Sides, values[i], !keptHere));
				if (keptHere)
				{
					total += group.Sign * values[i];
				}
			}
		}
		return (dice, total);
	}

	public static string Format(IEnumerable<DiceGroup> groups, int modifier)
	{
		var parts = new List<string>();
		foreach (var g in groups)
		{
			var text = $"{g.Count}d{g.Sides}" + (g.Keep > 0 ? $"{(g.KeepHighest ? "kh" : "kl")}{g.Keep}" : string.Empty);
			parts.Add(parts.Count == 0 ? (g.Sign < 0 ? "-" + text : text) : (g.Sign < 0 ? " - " : " + ") + text);
		}
		if (modifier != 0)
		{
			parts.Add(modifier < 0 ? $" - {-modifier}" : $" + {modifier}");
		}
		return string.Concat(parts);
	}

	[GeneratedRegex(@"(?<sign>[+-]?)(?:(?<count>\d{0,3})d(?<sides>\d{1,4})(?:(?<kind>kh|kl|k)(?<keep>\d{1,2}))?|(?<number>\d{1,4}))")]
	private static partial Regex Term();

	[GeneratedRegex(@"\s*([+-])\s*")]
	private static partial Regex Spaces();
}
