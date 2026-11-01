using RealmForge.Shared.Campaigns;
using RealmForge.Shared.Enums;

namespace RealmForge.Domain.Entities
{
	///	<summary>
	///	A campaign: the people playing it (with their role), the characters taking part, the Homebrew shared with the table
	///	and the pending invitations. Ruleset, when set, is the edition of its characters.
	///	</summary>
	public class Campaign
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public string Name { get; set; } = string.Empty;

		//	Markdown: the premise, the house rules, the next session…
		public string Description { get; set; } = string.Empty;

		public RulesetVersion? Ruleset { get; set; }

		//	Code of the invite link (anyone with the link joins as a player); null when the link is disabled
		public string? InviteCode { get; set; }

		public string CreatedById { get; set; } = string.Empty;
		public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
		public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;

		public ICollection<CampaignMember> Members { get; set; } = new List<CampaignMember>();
		public ICollection<CampaignInvite> Invites { get; set; } = new List<CampaignInvite>();
		public ICollection<CampaignCharacter> Characters { get; set; } = new List<CampaignCharacter>();
		public ICollection<CampaignContent> Contents { get; set; } = new List<CampaignContent>();
		public ICollection<CampaignNote> Notes { get; set; } = new List<CampaignNote>();
		public ICollection<CampaignEncounter> Encounters { get; set; } = new List<CampaignEncounter>();
		public ICollection<CampaignSession> Sessions { get; set; } = new List<CampaignSession>();
		public ICollection<CampaignRoll> Rolls { get; set; } = new List<CampaignRoll>();
	}

	///	<summary>
	///	A session of the campaign, numbered in order: its date, status, the plan the players read beforehand, the recap
	///	afterwards and the notes of the masters (never sent to the players).
	///	</summary>
	public class CampaignSession
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public Guid CampaignId { get; set; }
		public Campaign Campaign { get; set; } = null!;
		public int Number { get; set; }
		public string Title { get; set; } = string.Empty;
		public DateTimeOffset? ScheduledAt { get; set; }
		public CampaignSessionStatus Status { get; set; } = CampaignSessionStatus.Planned;

		//	Markdown
		public string Plan { get; set; } = string.Empty;
		public string Recap { get; set; } = string.Empty;
		public string MasterNotes { get; set; } = string.Empty;

		public string UpdatedById { get; set; } = string.Empty;
		public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
		public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
	}

	///	<summary>
	///	A roll of the shared dice log: made on the campaign page (rolled by the server) or on a character sheet. Dice is
	///	the JSON of the dice (sides, value, dropped). Only the last SessionRules.MaxRolls of a campaign are kept.
	///	</summary>
	public class CampaignRoll
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public Guid CampaignId { get; set; }
		public Campaign Campaign { get; set; } = null!;
		public string UserId { get; set; } = string.Empty;
		public Guid? CharacterId { get; set; }
		public string? CharacterName { get; set; }
		public string Label { get; set; } = string.Empty;
		public string Expression { get; set; } = string.Empty;
		public string Dice { get; set; } = "[]";
		public int Modifier { get; set; }
		public int Total { get; set; }
		public string? Note { get; set; }
		public bool Hidden { get; set; }
		public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
	}

	///	<summary>
	///	An encounter prepared (and then run) by the masters and co-masters: the combatants with initiative, hit points and
	///	conditions (JSON of EncounterCombatant), the characters it is balanced for, round and turn. Shown makes an
	///	encounter under way visible to the players.
	///	</summary>
	public class CampaignEncounter
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public Guid CampaignId { get; set; }
		public Campaign Campaign { get; set; } = null!;
		public string Name { get; set; } = string.Empty;
		public string Notes { get; set; } = string.Empty;
		public EncounterStatus Status { get; set; } = EncounterStatus.Planned;
		public int Round { get; set; }
		//	The combatant whose turn it is
		public Guid? CurrentId { get; set; }
		public bool Shown { get; set; }

		//	JSON array of EncounterCombatant
		public string Combatants { get; set; } = "[]";
		public List<Guid> PartyIds { get; set; } = new();

		public int Version { get; set; } = 1;
		public string CreatedById { get; set; } = string.Empty;
		public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
		public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
	}

	///	<summary>
	///	An account playing the campaign, with its role (unique per campaign and account).
	///	</summary>
	public class CampaignMember
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public Guid CampaignId { get; set; }
		public Campaign Campaign { get; set; } = null!;
		public string UserId { get; set; } = string.Empty;
		public CampaignRole Role { get; set; } = CampaignRole.Player;
		public DateTimeOffset JoinedAt { get; set; } = DateTimeOffset.UtcNow;
	}

	///	<summary>
	///	An invitation to an account, with the role it will have; it becomes a member when the person accepts.
	///	</summary>
	public class CampaignInvite
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public Guid CampaignId { get; set; }
		public Campaign Campaign { get; set; } = null!;
		public string UserId { get; set; } = string.Empty;
		public CampaignRole Role { get; set; } = CampaignRole.Player;
		public string InvitedById { get; set; } = string.Empty;
		public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
	}

	///	<summary>
	///	A character taking part in the campaign: its masters and co-masters can open and change it.
	///	</summary>
	public class CampaignCharacter
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public Guid CampaignId { get; set; }
		public Campaign Campaign { get; set; } = null!;
		public Guid CharacterId { get; set; }
		public Character Character { get; set; } = null!;
		public string AddedById { get; set; } = string.Empty;
		public DateTimeOffset AddedAt { get; set; } = DateTimeOffset.UtcNow;

		//	An inactive character stays at the table but sits out: it is not counted in the party of new encounters
		public bool Inactive { get; set; }
	}

	///	<summary>
	///	A note of the campaign: private (its author only), for the masters, or a page of the shared journal.
	///	</summary>
	public class CampaignNote
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public Guid CampaignId { get; set; }
		public Campaign Campaign { get; set; } = null!;
		public CampaignNoteKind Kind { get; set; } = CampaignNoteKind.Journal;
		public string AuthorId { get; set; } = string.Empty;
		public string Title { get; set; } = string.Empty;

		//	Markdown
		public string Body { get; set; } = string.Empty;
		public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
		public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
	}

	///	<summary>
	///	A Homebrew entry shared with the campaign (any kind: species, class, feat, spell…). Once approved, every member
	///	sees it in the compendium and in character creation, as if it were shared with them.
	///	</summary>
	public class CampaignContent
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public Guid CampaignId { get; set; }
		public Campaign Campaign { get; set; } = null!;
		public Guid EntityId { get; set; }
		public string SharedById { get; set; } = string.Empty;
		public CampaignContentStatus Status { get; set; } = CampaignContentStatus.Pending;
		public string? ReviewedById { get; set; }
		public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
	}
}
