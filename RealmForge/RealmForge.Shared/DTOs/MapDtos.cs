using RealmForge.Shared.Campaigns;

namespace RealmForge.Shared.DTOs
{
	///	<summary>
	///	A map in the list of the campaign (without its picture).
	///	</summary>
	public record CampaignMapSummaryDto(Guid Id, string Name, bool Shown, int Width, int Height, DateTimeOffset UpdatedAt);

	///	<summary>
	///	A token as the table sees it: CanMove when the account can drag it; Portrait for a character with one.
	///	</summary>
	public record MapTokenDto(
		Guid Id,
		string Label,
		string Color,
		TokenKind Kind,
		Guid? CharacterId,
		Guid? MonsterId,
		int X,
		int Y,
		int Size,
		bool Hidden,
		bool CanMove,
		string? Portrait = null);

	///	<summary>
	///	A map with its picture, its grid and its tokens (the hidden ones only for the masters).
	///	</summary>
	public record CampaignMapDto(
		Guid Id,
		string Name,
		string Image,
		int Width,
		int Height,
		int GridSize,
		int GridOffsetX,
		int GridOffsetY,
		bool Shown,
		bool CanEdit,
		DateTimeOffset UpdatedAt,
		List<MapTokenDto> Tokens);

	///	<summary>
	///	What the table polls every few seconds: the grid and the tokens, without the picture.
	///	</summary>
	public record MapStateDto(Guid Id, string Name, int GridSize, int GridOffsetX, int GridOffsetY, bool Shown, DateTimeOffset UpdatedAt, List<MapTokenDto> Tokens);

	///	<summary>
	///	A new map, or its changes (Image null keeps the picture).
	///	</summary>
	public class SaveMapDto
	{
		public string Name { get; set; } = string.Empty;
		public string? Image { get; set; }
		public int Width { get; set; }
		public int Height { get; set; }
		public int GridSize { get; set; } = 70;
		public int GridOffsetX { get; set; }
		public int GridOffsetY { get; set; }
		public bool Shown { get; set; }
	}

	///	<summary>
	///	A new token, or its changes.
	///	</summary>
	public class SaveTokenDto
	{
		public string Label { get; set; } = string.Empty;
		public string? Color { get; set; }
		public TokenKind Kind { get; set; } = TokenKind.Marker;
		public Guid? CharacterId { get; set; }
		public Guid? MonsterId { get; set; }
		public int X { get; set; }
		public int Y { get; set; }
		public int Size { get; set; } = 1;
		public bool Hidden { get; set; }
	}

	public class MoveTokenDto
	{
		public int X { get; set; }
		public int Y { get; set; }
	}
}
