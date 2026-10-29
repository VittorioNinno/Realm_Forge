namespace RealmForge.Shared.DTOs
{
	///	<summary>
	///	Something in my bin: what it is, its name, when it was deleted and when it will be gone for good.
	///	</summary>
	public record TrashEntryDto(Guid Id, string Kind, Guid EntityId, string Name, DateTimeOffset DeletedAt, DateTimeOffset ExpiresAt);

	///	<summary>
	///	A restored entry and the client page that shows it.
	///	</summary>
	public record TrashRestoredDto(string Kind, Guid EntityId, string Link);
}
