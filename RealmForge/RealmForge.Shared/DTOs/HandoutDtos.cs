using RealmForge.Shared.Enums;

namespace RealmForge.Shared.DTOs
{
	///	<summary>
	///	A handout of a campaign. The masters get both languages (to edit them); a player reads Title and Body in their
	///	language (the other one when it has only that).
	///	</summary>
	public record CampaignHandoutDto(
		Guid Id,
		string Title,
		string Body,
		Guid? ImageId,
		DateTimeOffset? RevealedAt,
		DateTimeOffset UpdatedAt,
		string? TitleIt = null,
		string? TitleEn = null,
		string? BodyIt = null,
		string? BodyEn = null);

	public class SaveCampaignHandoutDto
	{
		public string TitleIt { get; set; } = string.Empty;
		public string TitleEn { get; set; } = string.Empty;
		public string BodyIt { get; set; } = string.Empty;
		public string BodyEn { get; set; } = string.Empty;
		public Guid? ImageId { get; set; }
	}

	//	The handout revealed last at a table: the players' screens open it when it is new to them
	public record HandoutShownDto(Guid Id, DateTimeOffset RevealedAt);
}
