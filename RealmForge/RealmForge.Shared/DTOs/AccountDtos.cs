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

	public record HomebrewCountsDto(int Feats, int Species, int Subspecies, int Backgrounds)
	{
		public int Total => Feats + Species + Subspecies + Backgrounds;
	}
}
