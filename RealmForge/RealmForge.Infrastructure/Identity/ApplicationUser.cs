using Microsoft.AspNetCore.Identity;

namespace RealmForge.Infrastructure.Identity
{
	///	<summary>
	///	RealmForge account. Its Id is stored in GameEntity.AuthorId for Homebrew content.
	///	</summary>
	public class ApplicationUser : IdentityUser
	{
		//	Set when the account is created; null for accounts registered before this field existed
		//	(EF overwrites the initializer with the stored value when loading a user)
		public DateTimeOffset? RegisteredAt { get; set; } = DateTimeOffset.UtcNow;

		//	Public name shown to the other players instead of the e-mail; unique without regard to case
		//	(NormalizedNickname holds the upper-case form the unique index checks)
		public string? Nickname { get; set; }
		public string? NormalizedNickname { get; set; }
	}
}
