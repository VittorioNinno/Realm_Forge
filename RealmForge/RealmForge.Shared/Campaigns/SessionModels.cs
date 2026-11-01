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
