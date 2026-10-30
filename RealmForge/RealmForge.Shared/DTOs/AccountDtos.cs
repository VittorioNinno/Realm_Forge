namespace RealmForge.Shared.DTOs
{
	///	<summary>
	///	Profile shown on the account page: identity data plus the Homebrew content the user has created.
	///	</summary>
	public record AccountSummaryDto(
		string Email,
		bool EmailConfirmed,
		bool IsAdmin,
		DateTimeOffset? RegisteredAt,
		HomebrewCountsDto Homebrew,

		//	Public name shown to the other players (null: not chosen yet)
		string? Nickname = null
	);

	public class NicknameRequestDto
	{
		public string? Nickname { get; set; }
	}

	///	<summary>
	///	Number of Homebrew entries created by the user, per module.
	///	</summary>
	public record HomebrewCountsDto(int Feats, int Species, int Subspecies, int Backgrounds, int Spells = 0, int Classes = 0, int Subclasses = 0, int Equipment = 0, int Monsters = 0, int MagicItems = 0)
	{
		public int Total => Feats + Species + Subspecies + Backgrounds + Spells + Classes + Subclasses + Equipment + Monsters + MagicItems;
	}
}
