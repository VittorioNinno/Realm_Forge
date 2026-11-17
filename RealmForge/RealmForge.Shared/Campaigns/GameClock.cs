using System.Text.RegularExpressions;

namespace RealmForge.Shared.Campaigns;

///	<summary>
///	The time inside the game of a campaign, in minutes from the start of day 1 (a new campaign starts at 08:00): the
///	masters move it on (ten minutes, an hour, a long rest, days of travel) and the effects that last on it end.
///	</summary>
public static class GameClock
{
	public const int MinutesPerDay = 24 * 60;
	public const long Start = 8 * 60;

	//	At most a month in one step, and a clock up to about 2700 years
	public const int MaxStep = 30 * MinutesPerDay;
	public const long MaxMinutes = 1_000_000 * (long)MinutesPerDay;

	//	The shortest duration followed on the clock: the shorter ones belong to the rounds of a fight
	public const int ShortestTracked = 10;

	public static long Day(long minutes) => minutes / MinutesPerDay + 1;

	public static int Hour(long minutes) => (int)(minutes % MinutesPerDay / 60);

	public static int Minute(long minutes) => (int)(minutes % 60);

	//	The days that begin between two moments (the dawns crossed by a step of the clock)
	public static int DaysCrossed(long from, long to) => to <= from ? 0 : (int)(Day(to) - Day(from));

	private static readonly Regex DurationPattern = new(
		@"(\d+)\s*(minut[eoi]s?|hours?|or[ae]|days?|giorn[oi])\b", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);

	///	<summary>
	///	The minutes a spell lasts, from its duration as printed ("8 hours", "Concentrazione, fino a 1 ora", "10 days"):
	///	null for an instant, a few rounds, until dispelled or anything shorter than <see cref="ShortestTracked"/>.
	///	</summary>
	public static int? DurationMinutes(string? text)
	{
		if (string.IsNullOrWhiteSpace(text) || DurationPattern.Match(text) is not { Success: true } match
			|| !int.TryParse(match.Groups[1].Value, out var amount))
		{
			return null;
		}
		var unit = match.Groups[2].Value.ToLowerInvariant();
		long minutes = unit.StartsWith("minut") ? amount
			: unit.StartsWith("hour") || unit.StartsWith("or") ? amount * 60L
			: amount * (long)MinutesPerDay;
		return minutes < ShortestTracked || minutes > MaxStep * 12L ? null : (int)minutes;
	}
}
