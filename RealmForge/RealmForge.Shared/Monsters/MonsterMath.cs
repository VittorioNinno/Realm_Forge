using RealmForge.Shared.Enums;

namespace RealmForge.Shared.Monsters;

///	<summary>
///	Numbers of a statblock: challenge ratings (with their experience points and proficiency bonus), ability modifiers.
///	</summary>
public static class MonsterMath
{
	///	<summary>
	///	Every challenge rating, in order, with the experience points it is worth.
	///	</summary>
	public static readonly IReadOnlyList<(decimal Rating, int Xp)> Challenges = new (decimal, int)[]
	{
		(0m, 10), (0.125m, 25), (0.25m, 50), (0.5m, 100),
		(1m, 200), (2m, 450), (3m, 700), (4m, 1100), (5m, 1800), (6m, 2300), (7m, 2900), (8m, 3900), (9m, 5000), (10m, 5900),
		(11m, 7200), (12m, 8400), (13m, 10000), (14m, 11500), (15m, 13000), (16m, 15000), (17m, 18000), (18m, 20000),
		(19m, 22000), (20m, 25000), (21m, 33000), (22m, 41000), (23m, 50000), (24m, 62000), (25m, 75000), (26m, 90000),
		(27m, 105000), (28m, 120000), (29m, 135000), (30m, 155000)
	};

	public static bool IsChallenge(decimal rating) => Challenges.Any(c => c.Rating == rating);

	///	<summary>
	///	Experience points of a challenge rating (0 for a rating that does not exist).
	///	</summary>
	public static int XpFor(decimal rating) => Challenges.FirstOrDefault(c => c.Rating == rating).Xp;

	public static int ProficiencyFor(decimal rating) => rating switch
	{
		< 5 => 2,
		< 9 => 3,
		< 13 => 4,
		< 17 => 5,
		< 21 => 6,
		< 25 => 7,
		< 29 => 8,
		_ => 9
	};

	///	<summary>
	///	"1/8", "1/4", "1/2", "3"…
	///	</summary>
	public static string FormatChallenge(decimal rating) => rating switch
	{
		0.125m => "1/8",
		0.25m => "1/4",
		0.5m => "1/2",
		_ => ((int)rating).ToString()
	};

	public static int Modifier(int score) => (int)Math.Floor((score - 10) / 2.0);

	public static string Signed(int value) => value >= 0 ? $"+{value}" : value.ToString();

	///	<summary>
	///	"15 (+2)"
	///	</summary>
	public static string Score(int score) => $"{score} ({Signed(Modifier(score))})";

	///	<summary>
	///	Thousands with the separator of the language: 18.000 PE, 18,000 XP.
	///	</summary>
	public static string Thousands(int value, LanguageCode lang) =>
		value.ToString("#,0", System.Globalization.CultureInfo.InvariantCulture).Replace(",", lang == LanguageCode.It ? "." : ",");

	///	<summary>
	///	The challenge line of the statblock: "17 (18.000 PE)", "1/4 (50 XP)".
	///	</summary>
	public static string ChallengeLine(decimal rating, int xp, LanguageCode lang) =>
		$"{FormatChallenge(rating)} ({Thousands(xp, lang)} {(lang == LanguageCode.It ? "PE" : "XP")})";

	///	<summary>
	///	Average of a dice formula ("19d12 + 133" → 256); null when it cannot be read.
	///	</summary>
	public static int? Average(string? formula)
	{
		var text = (formula ?? string.Empty).Replace(" ", string.Empty).ToLowerInvariant();
		var match = System.Text.RegularExpressions.Regex.Match(text, @"^(\d+)d(\d+)([+-]\d+)?$");
		if (!match.Success)
		{
			return null;
		}
		var count = int.Parse(match.Groups[1].Value);
		var faces = int.Parse(match.Groups[2].Value);
		var bonus = match.Groups[3].Success ? int.Parse(match.Groups[3].Value) : 0;
		if (count is < 1 or > 200 || faces is < 1 or > 100)
		{
			return null;
		}
		return (int)Math.Floor(count * (faces + 1) / 2.0) + bonus;
	}
}
