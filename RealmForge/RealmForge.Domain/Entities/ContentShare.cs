namespace RealmForge.Domain.Entities
{
	///	<summary>
	///	A Homebrew entry shared with one account: the author chose that person (any visibility), or the person added a
	///	link-only entry to their own collection (GrantedById = UserId). Shared entries are listed for that person, also
	///	in character creation. EntityId is the id of any game entity (species, class, background, feat, spell…).
	///	</summary>
	public class ContentShare
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public Guid EntityId { get; set; }

		//	Identity user id of the person who can see the entry, and of the one who shared it
		public string UserId { get; set; } = string.Empty;
		public string GrantedById { get; set; } = string.Empty;

		public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
	}
}
