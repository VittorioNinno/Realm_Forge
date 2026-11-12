namespace RealmForge.Shared.DTOs
{
	///	<summary>
	///	A picture of the account's images (without the picture itself: it is served by api/images/{id}/file). Monsters:
	///	the monsters and NPCs it pictures for the account.
	///	</summary>
	public record UserImageDto(Guid Id, string Name, int Width, int Height, DateTimeOffset CreatedAt, List<Guid> Monsters);

	public class SaveImageDto
	{
		public string Name { get; set; } = string.Empty;

		//	A data URL (image/jpeg, png or webp); left out when only renaming
		public string? Image { get; set; }
		public int Width { get; set; }
		public int Height { get; set; }
	}

	public class ChooseImageDto
	{
		//	null: back to the monster's own portrait, or to its initials
		public Guid? ImageId { get; set; }
	}
}
