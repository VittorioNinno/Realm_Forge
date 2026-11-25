namespace RealmForge.Domain.Entities
{
	///	<summary>
	///	A code that unlocks a special look of the 3D dice (an easter egg). Only its hash is kept; Active lets a code be
	///	retired without deleting who already used it.
	///	</summary>
	public class DiceUnlockCode
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public string CodeHash { get; set; } = string.Empty;
		public string Skin { get; set; } = string.Empty;
		public bool Active { get; set; } = true;
		public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
	}

	///	<summary>A special look of the dice a user has unlocked.</summary>
	public class UserDiceSkin
	{
		public string UserId { get; set; } = string.Empty;
		public string Skin { get; set; } = string.Empty;
		public DateTimeOffset UnlockedAt { get; set; } = DateTimeOffset.UtcNow;
	}
}
