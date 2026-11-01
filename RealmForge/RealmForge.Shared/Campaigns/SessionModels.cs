namespace RealmForge.Shared.Campaigns;

///	<summary>
///	A session of the campaign: planned (with a date), played (with its recap) or cancelled.
///	</summary>
public enum CampaignSessionStatus
{
	Planned = 1,
	Played = 2,
	Cancelled = 3
}

///	<summary>
///	The colour of each person at the table, used for their rolls in the dice log: the masters are always orange, the
///	others get a random colour of the palette when they join (one not taken yet while there are any).
///	</summary>
public static class PlayerColors
{
	public const string Master = "#ff8c00";

	//	The rolls left by a deleted account
	public const string Removed = "#6c757d";

	//	Readable on the dark page and far from the masters' orange
	public static readonly IReadOnlyList<string> Palette =
	[
		"#4fc3f7", "#81c784", "#ba68c8", "#f06292", "#4db6ac", "#e57373", "#9575cd", "#dce775", "#90a4ae", "#4dd0e1", "#f48fb1", "#aed581"
	];

	public static string Pick(IEnumerable<string?> taken, Random? random = null)
	{
		var rnd = random ?? Random.Shared;
		var used = taken.OfType<string>().ToHashSet(StringComparer.OrdinalIgnoreCase);
		var free = Palette.Where(c => !used.Contains(c)).ToList();
		var from = free.Count > 0 ? free : Palette.ToList();
		return from[rnd.Next(from.Count)];
	}

	///	<summary>
	///	The colour shown for a member: orange for a master, otherwise the one assigned.
	///	</summary>
	public static string Of(CampaignRole role, string? assigned) => role == CampaignRole.Master || string.IsNullOrEmpty(assigned) ? Master : assigned;
}

///	<summary>
///	Who may do what with the sessions and the dice log of a campaign. Used by the API and by the client.
///	</summary>
public static class SessionRules
{
	//	Most sessions and rolls kept per campaign (the oldest rolls make room for the new ones)
	public const int MaxSessions = 300;
	public const int MaxRolls = 200;

	//	Masters and co-masters plan the sessions and write their recap; the players read them
	public static bool CanManageSessions(CampaignRole role) => CampaignRules.RunsTheTable(role);

	//	The masters' notes of a session stay behind the screen
	public static bool CanSeeMasterNotes(CampaignRole role) => CampaignRules.RunsTheTable(role);

	//	A hidden roll (behind the screen) is seen by masters, co-masters and whoever rolled it
	public static bool CanRollHidden(CampaignRole role) => CampaignRules.RunsTheTable(role);

	public static bool CanSeeRoll(CampaignRole role, bool hidden, bool mine) => !hidden || mine || CampaignRules.RunsTheTable(role);

	//	Clearing the log is for the masters
	public static bool CanClearRolls(CampaignRole role) => CampaignRules.IsMaster(role);
}
