namespace RealmForge.Domain.Entities
{
	///	<summary>
	///	Something an account deleted (a character, a campaign, a Homebrew entry), kept for a few days so that it can be
	///	restored: the rows removed with it are saved as JSON in Payload, and put back as they were on a restore.
	///	</summary>
	public class TrashEntry
	{
		public Guid Id { get; set; } = Guid.NewGuid();

		//	Who deleted it, and so who can restore it
		public string UserId { get; set; } = string.Empty;

		//	character, campaign, species, subspecies, class, subclass, background, feat, spell, equipment, monster
		public string Kind { get; set; } = string.Empty;

		public Guid EntityId { get; set; }
		public string NameIt { get; set; } = string.Empty;
		public string NameEn { get; set; } = string.Empty;
		public DateTimeOffset DeletedAt { get; set; } = DateTimeOffset.UtcNow;
		public DateTimeOffset ExpiresAt { get; set; }

		//	The rows deleted with the entry and the references the deletion set to null (TrashBin's format)
		public string Payload { get; set; } = string.Empty;
	}
}
