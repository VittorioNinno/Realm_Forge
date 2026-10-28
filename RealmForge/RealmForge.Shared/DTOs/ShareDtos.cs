namespace RealmForge.Shared.DTOs
{
	///	<summary>
	///	An account a Homebrew entry or a character is shared with (the e-mail the owner typed).
	///	</summary>
	public record ShareUserDto(string UserId, string Email);

	public class ShareRequestDto
	{
		public string Email { get; set; } = string.Empty;
	}

	///	<summary>
	///	A Homebrew entry shared with the current user; Collected: a link-only entry the user added on their own.
	///	</summary>
	public record SharedEntryDto(Guid EntityId, bool Collected);

	///	<summary>
	///	A character another player shared with the current user (read-only sheet).
	///	</summary>
	public record SharedCharacterDto(CharacterSummaryDto Character, string OwnerName);
}
