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
		HomebrewCountsDto Homebrew
	);

	///	<summary>
	///	Number of Homebrew entries created by the user, per module.
	///	</summary>
	public record HomebrewCountsDto(int Feats, int Species, int Subspecies, int Backgrounds, int Spells = 0, int Classes = 0, int Subclasses = 0)
	{
		public int Total => Feats + Species + Subspecies + Backgrounds + Spells + Classes + Subclasses;
	}
}
