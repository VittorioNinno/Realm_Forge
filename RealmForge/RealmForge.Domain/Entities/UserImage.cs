namespace RealmForge.Domain.Entities
{
	///	<summary>
	///	A picture in an account's images: used for the tokens of the virtual tabletop and to picture monsters and NPCs
	///	(MonsterImageChoice). Image is a data URL, already reduced by the browser.
	///	</summary>
	public class UserImage
	{
		public const int MaxImageLength = 400_000;
		public const int MaxPerAccount = 300;

		public Guid Id { get; set; } = Guid.NewGuid();
		public string OwnerId { get; set; } = string.Empty;
		public string Name { get; set; } = string.Empty;
		public string Image { get; set; } = string.Empty;
		public int Width { get; set; }
		public int Height { get; set; }
		public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
	}

	///	<summary>
	///	The picture an account chose for a monster or an NPC (any, the Base ones included): shown on its page, its sheet
	///	and its tokens, for that account only.
	///	</summary>
	public class MonsterImageChoice
	{
		public string OwnerId { get; set; } = string.Empty;
		public Guid MonsterId { get; set; }
		public Guid ImageId { get; set; }
		public UserImage Image { get; set; } = null!;
	}
}
