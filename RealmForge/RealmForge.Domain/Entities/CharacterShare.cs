namespace RealmForge.Domain.Entities
{
	///	<summary>
	///	A character shared by its owner with another account (the game master): that person can open the sheet read-only.
	///	</summary>
	public class CharacterShare
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public Guid CharacterId { get; set; }
		public Character Character { get; set; } = null!;

		//	Identity user id of the person who can read the sheet
		public string UserId { get; set; } = string.Empty;

		public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
	}
}
