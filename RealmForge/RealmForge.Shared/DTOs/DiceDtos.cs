namespace RealmForge.Shared.DTOs
{
	///	<summary>The special dice a user has unlocked (resin is always there).</summary>
	public record DiceSkinsDto(List<string> Unlocked);

	///	<summary>
	///	An achievement as shown: earned (when; Given: by an administrator), revoked by an administrator, and how far it has
	///	come (Progress of Target). Hidden achievements reach the person only once earned.
	///	</summary>
	public record AchievementDto(string Key, string Skin, bool Hidden, bool Earned, DateTimeOffset? EarnedAt, bool Given, bool Revoked, int Progress, int Target);

	public class AchievementsSeenDto
	{
		public List<string> Keys { get; set; } = new();
	}

	///	<summary>The person's own clock (an IANA time zone, e.g. Europe/Rome), for the achievements made at night.</summary>
	public class TimeZoneDto
	{
		public string TimeZone { get; set; } = string.Empty;
	}
}
