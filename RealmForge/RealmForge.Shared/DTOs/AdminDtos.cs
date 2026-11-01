using RealmForge.Shared.Enums;

namespace RealmForge.Shared.DTOs
{
	///	<summary>
	///	Figures of the whole site for the administrators.
	///	</summary>
	public record AdminStatsDto(int Users, int ConfirmedUsers, int LockedUsers, int Characters, int Campaigns, int Homebrew, int PublicHomebrew);

	///	<summary>
	///	An account as the administrators see it: e-mail, nickname, state and what it owns. LockedUntil is set while the
	///	account cannot sign in.
	///	</summary>
	public record AdminUserDto(
		string Id,
		string Email,
		string? Nickname,
		bool EmailConfirmed,
		DateTimeOffset? RegisteredAt,
		DateTimeOffset? LockedUntil,
		bool IsAdmin,
		bool IsMe,
		int Characters,
		int Homebrew,
		int Campaigns);

	///	<summary>
	///	Blocks the sign-in of an account for some days (0 lifts the block).
	///	</summary>
	public class AdminLockDto
	{
		public int Days { get; set; }
	}

	///	<summary>
	///	A Homebrew entry for the moderation: kind, name, the page that opens it, author, visibility and how far it is
	///	shared (people and campaigns).
	///	</summary>
	public record AdminHomebrewDto(
		Guid Id,
		string Kind,
		string Name,
		string Link,
		RulesetVersion Ruleset,
		ContentVisibility Visibility,
		string? AuthorId,
		string Author,
		int SharedWith,
		int Campaigns);

	public class AdminVisibilityDto
	{
		public ContentVisibility Visibility { get; set; }
	}

	///	<summary>
	///	A hit of the global search: any section of the compendium (glossary included), with the name in the current
	///	language and, when it differs, in the other one (so "Fireball" finds "Palla di fuoco").
	///	</summary>
	public record SearchResultDto(
		Guid Id,
		string Kind,
		string Name,
		string? OtherName,
		string Link,
		RulesetVersion Ruleset,
		bool IsBase,
		bool IsMine);
}
