namespace RealmForge.Domain.Entities
{
	///	<summary>
	///	A collection of Homebrew: entries of one author under one name and one link (Code). Whoever has the link reads
	///	it, adds every entry to their own collection, or switches it on in a campaign as a block (CampaignContent rows
	///	with its CollectionId).
	///	</summary>
	public class ContentCollection
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public string AuthorId { get; set; } = string.Empty;
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public string Code { get; set; } = string.Empty;
		public List<Guid> EntityIds { get; set; } = new();
		public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
		public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
	}
}
