namespace RealmForge.Shared.Campaigns;

///	<summary>
///	Role of an account in a campaign. A campaign always has at least one master.
///	</summary>
public enum CampaignRole
{
	//	Absolute authority: promotes and demotes, removes members and any shared content, edits every character
	Master = 1,

	//	Helps the masters: invites players, approves and removes content (not the masters' own), edits every character
	CoMaster = 2,

	Player = 3
}

///	<summary>
///	A Homebrew entry offered to a campaign: the masters' entries are approved at once, the players' wait for a master
///	or a co-master.
///	</summary>
public enum CampaignContentStatus
{
	Pending = 1,
	Approved = 2
}

///	<summary>
///	Who may do what in a campaign. Used by the API (the rule) and by the client (which buttons to show).
///	</summary>
public static class CampaignRules
{
	public static bool IsMaster(CampaignRole role) => role == CampaignRole.Master;

	//	Masters and co-masters run the table: they see and edit every character, approve and remove content
	public static bool RunsTheTable(CampaignRole role) => role is CampaignRole.Master or CampaignRole.CoMaster;

	public static bool CanEditCampaign(CampaignRole role) => IsMaster(role);

	public static bool CanDeleteCampaign(CampaignRole role) => IsMaster(role);

	//	Co-masters invite players; only masters invite (or later promote) co-masters and masters
	public static bool CanInvite(CampaignRole role, CampaignRole invitedAs) =>
		IsMaster(role) || (role == CampaignRole.CoMaster && invitedAs == CampaignRole.Player);

	public static bool CanManageInviteLink(CampaignRole role) => RunsTheTable(role);

	public static bool CanChangeRoles(CampaignRole role) => IsMaster(role);

	//	Masters remove anyone (the last master stays, see LeavesAMaster); everyone can leave
	public static bool CanRemoveMember(CampaignRole role, bool self) => self || IsMaster(role);

	///	<summary>
	///	True when, after the change, the campaign still has a master.
	///	</summary>
	public static bool LeavesAMaster(int masters, CampaignRole before, CampaignRole? after) =>
		before != CampaignRole.Master || after == CampaignRole.Master || masters > 1;

	//	Shared content: approved at once for masters and co-masters, pending for players
	public static CampaignContentStatus StatusOfNewShare(CampaignRole role) =>
		RunsTheTable(role) ? CampaignContentStatus.Approved : CampaignContentStatus.Pending;

	public static bool CanReview(CampaignRole role) => RunsTheTable(role);

	///	<summary>
	///	Removing an entry from the campaign: masters remove anything; co-masters their own and the players' (not the
	///	ones shared by a master); a player withdraws only what they shared.
	///	</summary>
	public static bool CanRemoveContent(CampaignRole role, bool sharedByMe, CampaignRole? sharerRole) => role switch
	{
		CampaignRole.Master => true,
		CampaignRole.CoMaster => sharedByMe || sharerRole != CampaignRole.Master,
		_ => sharedByMe
	};

	//	Characters: the owner adds and removes their own; masters and co-masters edit and can take one out
	public static bool CanEditCharacter(CampaignRole role, bool owner) => owner || RunsTheTable(role);

	public static bool CanRemoveCharacter(CampaignRole role, bool owner) => owner || RunsTheTable(role);
}
