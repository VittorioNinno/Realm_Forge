using RealmForge.Shared.Campaigns;

namespace RealmForge.Tests;

public class CampaignRulesTests
{
	private const CampaignRole Master = CampaignRole.Master;
	private const CampaignRole CoMaster = CampaignRole.CoMaster;
	private const CampaignRole Player = CampaignRole.Player;

	[Fact]
	public void Only_masters_change_roles_and_run_the_campaign()
	{
		Assert.True(CampaignRules.CanChangeRoles(Master));
		Assert.False(CampaignRules.CanChangeRoles(CoMaster));
		Assert.False(CampaignRules.CanChangeRoles(Player));
		Assert.True(CampaignRules.CanDeleteCampaign(Master));
		Assert.False(CampaignRules.CanDeleteCampaign(CoMaster));
		Assert.True(CampaignRules.CanRemoveMember(Master, self: false));
		Assert.False(CampaignRules.CanRemoveMember(CoMaster, self: false));
		Assert.True(CampaignRules.CanRemoveMember(Player, self: true));
	}

	[Fact]
	public void Co_masters_invite_players_only()
	{
		Assert.True(CampaignRules.CanInvite(Master, CoMaster));
		Assert.True(CampaignRules.CanInvite(Master, Master));
		Assert.True(CampaignRules.CanInvite(CoMaster, Player));
		Assert.False(CampaignRules.CanInvite(CoMaster, CoMaster));
		Assert.False(CampaignRules.CanInvite(Player, Player));
	}

	[Fact]
	public void A_campaign_keeps_a_master()
	{
		Assert.False(CampaignRules.LeavesAMaster(1, Master, null));
		Assert.False(CampaignRules.LeavesAMaster(1, Master, CoMaster));
		Assert.True(CampaignRules.LeavesAMaster(2, Master, Player));
		Assert.True(CampaignRules.LeavesAMaster(1, Player, null));
		Assert.True(CampaignRules.LeavesAMaster(1, Master, Master));
	}

	[Fact]
	public void Players_wait_for_approval_masters_do_not()
	{
		Assert.Equal(CampaignContentStatus.Approved, CampaignRules.StatusOfNewShare(Master));
		Assert.Equal(CampaignContentStatus.Approved, CampaignRules.StatusOfNewShare(CoMaster));
		Assert.Equal(CampaignContentStatus.Pending, CampaignRules.StatusOfNewShare(Player));
		Assert.True(CampaignRules.CanReview(CoMaster));
		Assert.False(CampaignRules.CanReview(Player));
	}

	[Fact]
	public void Content_removal_follows_the_hierarchy()
	{
		//	Masters remove anything
		Assert.True(CampaignRules.CanRemoveContent(Master, sharedByMe: false, sharerRole: Master));

		//	Co-masters: their own and the players', not the masters'
		Assert.True(CampaignRules.CanRemoveContent(CoMaster, sharedByMe: true, sharerRole: CoMaster));
		Assert.True(CampaignRules.CanRemoveContent(CoMaster, sharedByMe: false, sharerRole: Player));
		Assert.True(CampaignRules.CanRemoveContent(CoMaster, sharedByMe: false, sharerRole: CoMaster));
		Assert.False(CampaignRules.CanRemoveContent(CoMaster, sharedByMe: false, sharerRole: Master));

		//	Players withdraw only what they shared
		Assert.True(CampaignRules.CanRemoveContent(Player, sharedByMe: true, sharerRole: Player));
		Assert.False(CampaignRules.CanRemoveContent(Player, sharedByMe: false, sharerRole: Player));
	}

	[Fact]
	public void Masters_and_co_masters_edit_the_characters()
	{
		Assert.True(CampaignRules.CanEditCharacter(Master, owner: false));
		Assert.True(CampaignRules.CanEditCharacter(CoMaster, owner: false));
		Assert.False(CampaignRules.CanEditCharacter(Player, owner: false));
		Assert.True(CampaignRules.CanEditCharacter(Player, owner: true));
	}

	[Fact]
	public void Notes_follow_their_kind()
	{
		Assert.False(CampaignRules.CanReadNotes(CampaignNoteKind.Masters, Player));
		Assert.True(CampaignRules.CanReadNotes(CampaignNoteKind.Masters, CoMaster));
		Assert.True(CampaignRules.CanWriteNotes(CampaignNoteKind.Journal, Player));
		Assert.False(CampaignRules.CanEditNote(author: false));

		//	Private notes: only their author; the journal: masters too, co-masters except the masters' pages
		Assert.False(CampaignRules.CanDeleteNote(CampaignNoteKind.Private, Master, author: false, authorRole: Player));
		Assert.True(CampaignRules.CanDeleteNote(CampaignNoteKind.Journal, Master, author: false, authorRole: Player));
		Assert.True(CampaignRules.CanDeleteNote(CampaignNoteKind.Journal, CoMaster, author: false, authorRole: Player));
		Assert.False(CampaignRules.CanDeleteNote(CampaignNoteKind.Journal, CoMaster, author: false, authorRole: Master));
		Assert.False(CampaignRules.CanDeleteNote(CampaignNoteKind.Journal, Player, author: false, authorRole: Player));
	}
}
