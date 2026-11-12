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
		string? Portrait = null,
		TokenLayer Layer = TokenLayer.Tokens,
		Guid? CombatantId = null,
		List<string>? Conditions = null,

		//	Hit points of a monster in the fight, for the masters; its health, for the players
		int? Hp = null,
		int? MaxHp = null,
		CombatantHealth? Health = null,

		//	The players a master lets move it (sent to the masters only)
		List<string>? ControlledBy = null,
		PropType? PropType = null,
		PropState PropState = PropState.Closed,
		bool PlayersInteract = false);

	///	<summary>
	///	The fight on a map: the encounter, the round, whose turn it is and the initiative order (what the players see of it).
	///	</summary>
	public record MapCombatDto(Guid EncounterId, string Name, int Round, Guid? CurrentId, List<MapCombatantDto> Order);

	public record MapCombatantDto(Guid Id, string Name, CombatantKind Kind, int? Initiative, Guid? TokenId, bool Hidden);

	public class StartCombatDto
	{
		public Guid EncounterId { get; set; }
	}

	public class QuickCombatDto
	{
		public List<Guid> TokenIds { get; set; } = new();
	}

	public class SetInitiativeDto
	{
		public Guid CombatantId { get; set; }
		public int Initiative { get; set; }
	}

	public class TokenStateDto
	{
		public List<string> Conditions { get; set; } = new();
		public int? Hp { get; set; }
	}

	///	<summary>
	///	Something drawn on a map (see CampaignMapShape); CanDelete: the author or a master.
	///	</summary>
	public record MapShapeDto(Guid Id, ShapeKind Kind, List<double> Points, string Color, string? Text, int Size, bool MasterOnly, bool CanDelete);

	public class SaveShapeDto
	{
		public ShapeKind Kind { get; set; } = ShapeKind.Freehand;
		public List<double> Points { get; set; } = new();
		public string? Color { get; set; }
		public string? Text { get; set; }
		public int Size { get; set; }
		public bool MasterOnly { get; set; }
	}

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
		List<MapTokenDto> Tokens,
		GridType GridType = GridType.Square,
		List<MapShapeDto>? Shapes = null,
		MapTableDto? Table = null,
		MapCombatDto? Combat = null);

	///	<summary>
	///	What the table polls every few seconds: the grid and the tokens, without the picture.
	///	</summary>
	public record MapStateDto(Guid Id, string Name, int GridSize, int GridOffsetX, int GridOffsetY, bool Shown, DateTimeOffset UpdatedAt, List<MapTokenDto> Tokens,
		GridType GridType = GridType.Square, List<MapShapeDto>? Shapes = null, MapTableDto? Table = null,
		MapCombatDto? Combat = null);

	///	<summary>
	///	The fog of war (see MapFog), the last ping and the last view the masters brought the table to.
	///	</summary>
	public record MapTableDto(bool FogEnabled, List<double> Fog, MapPingDto? Ping, MapFocusDto? Focus);

	public record MapPingDto(double X, double Y, string Color, DateTimeOffset At);

	public record MapFocusDto(double X, double Y, double Zoom, DateTimeOffset At);

	public class SaveFogDto
	{
		public bool Enabled { get; set; }
		public List<double> Fog { get; set; } = new();
	}

	public class MapPointDto
	{
		public double X { get; set; }
		public double Y { get; set; }
		public double Zoom { get; set; } = 1;
	}

	///	<summary>
	///	A new map, or its changes (Image null keeps the picture).
	///	</summary>
	public class SaveMapDto
	{
		public string Name { get; set; } = string.Empty;
		public string? Image { get; set; }
		public int Width { get; set; }
		public int Height { get; set; }
		public GridType GridType { get; set; } = GridType.Square;
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
		public TokenLayer Layer { get; set; } = TokenLayer.Tokens;
		public List<string> ControlledBy { get; set; } = new();
		public int? Hp { get; set; }
		public int? MaxHp { get; set; }
		public PropType? PropType { get; set; }
		public PropState PropState { get; set; } = PropState.Closed;
		public bool PlayersInteract { get; set; }
	}

	public class MoveTokenDto
	{
		public int X { get; set; }
		public int Y { get; set; }
	}
}
