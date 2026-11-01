using RealmForge.Shared.Campaigns;
using RealmForge.Shared.Enums;

namespace RealmForge.Shared.DTOs
{
	///	<summary>
	///	A campaign in the list of the current user: their role, how many people and characters, and (for masters and
	///	co-masters) the entries waiting for approval.
	///	</summary>
	public record CampaignSummaryDto(
		Guid Id,
		string Name,
		RulesetVersion? Ruleset,
		CampaignRole MyRole,
		int Members,
		int Characters,
		int PendingContents,
		DateTimeOffset UpdatedAt);

	///	<summary>
	///	An invitation the current user received (accept or decline).
	///	</summary>
	public record CampaignInvitationDto(Guid Id, Guid CampaignId, string CampaignName, CampaignRole Role, string InvitedBy, DateTimeOffset CreatedAt);

	///	<summary>
	///	A member as the others see them: the nickname (never the e-mail address).
	///	</summary>
	public record CampaignMemberDto(string UserId, string Name, CampaignRole Role, bool IsMe, DateTimeOffset JoinedAt, string Color = PlayerColors.Master);

	///	<summary>
	///	An invitation sent and not answered yet (shown to masters and co-masters).
	///	</summary>
	public record CampaignPendingInviteDto(Guid Id, string Name, CampaignRole Role, string InvitedBy, DateTimeOffset CreatedAt);

	///	<summary>
	///	A character taking part in the campaign. CanOpen: the owner, masters and co-masters open the sheet; CanEdit:
	///	masters and co-masters change the character itself, not only a view of it.
	///	</summary>
	public record CampaignCharacterDto(CharacterSummaryDto Character, string OwnerId, string OwnerName, bool IsMine, bool CanOpen, bool CanEdit, bool CanRemove,
		bool Active = true);

	public class CampaignCharacterActiveDto
	{
		public bool Active { get; set; }
	}

	///	<summary>
	///	A Homebrew entry shared with the campaign. Kind: species, subspecies, class, subclass, background, feat, spell,
	///	equipment; Link: the client route of its page.
	///	</summary>
	public record CampaignContentDto(
		Guid EntityId,
		string Kind,
		string Name,
		string Link,
		CampaignContentStatus Status,
		string SharedById,
		string SharedBy,
		CampaignRole? SharedByRole,
		DateTimeOffset CreatedAt,
		bool CanRemove,
		bool CanReview);

	///	<summary>
	///	Everything the campaign page shows, with what the current user is allowed to do.
	///	</summary>
	public record CampaignDetailDto(
		Guid Id,
		string Name,
		string Description,
		RulesetVersion? Ruleset,
		CampaignRole MyRole,
		string? InviteCode,
		List<CampaignMemberDto> Members,
		List<CampaignPendingInviteDto> Invites,
		List<CampaignCharacterDto> Characters,
		List<CampaignContentDto> Contents,
		DateTimeOffset CreatedAt,
		DateTimeOffset UpdatedAt);

	public class SaveCampaignDto
	{
		public string Name { get; set; } = string.Empty;
		public string? Description { get; set; }
		public RulesetVersion? Ruleset { get; set; }
	}

	public class CampaignInviteRequestDto
	{
		public string Email { get; set; } = string.Empty;
		public CampaignRole Role { get; set; } = CampaignRole.Player;
	}

	public class CampaignRoleRequestDto
	{
		public CampaignRole Role { get; set; }
	}

	public class CampaignCharacterRequestDto
	{
		public Guid CharacterId { get; set; }
	}

	public class CampaignContentRequestDto
	{
		public Guid EntityId { get; set; }
	}

	public class CampaignJoinRequestDto
	{
		public string Code { get; set; } = string.Empty;
	}

	///	<summary>
	///	What an invite link shows before joining.
	///	</summary>
	public record CampaignJoinPreviewDto(Guid Id, string Name, RulesetVersion? Ruleset, int Members, bool AlreadyMember);

	///	<summary>
	///	One reason a character cannot join: Kind and Name of the Homebrew entry (null for the edition), Ruleset of the
	///	character or of the entry when the edition is the problem.
	///	</summary>
	public record CampaignCheckIssueDto(CampaignCheckIssue Issue, string? Kind, string? Name, RulesetVersion? Ruleset, Guid? EntityId = null);

	public record CampaignCharacterCheckDto(bool Ok, List<CampaignCheckIssueDto> Issues);

	///	<summary>
	///	A campaign note (Markdown). Author: nickname; CanEdit/CanDelete: what the reader may do.
	///	</summary>
	public record CampaignNoteDto(Guid Id, CampaignNoteKind Kind, string Title, string Body, string AuthorId, string Author, bool IsMine,
		DateTimeOffset CreatedAt, DateTimeOffset UpdatedAt, bool CanEdit, bool CanDelete);

	public class SaveCampaignNoteDto
	{
		public CampaignNoteKind Kind { get; set; } = CampaignNoteKind.Journal;
		public string Title { get; set; } = string.Empty;
		public string Body { get; set; } = string.Empty;
	}

	///	<summary>
	///	A Homebrew entry of the current user that could be shared with a campaign.
	///	</summary>
	public record ShareableEntryDto(Guid EntityId, string Kind, string Name, RulesetVersion Ruleset);
}
