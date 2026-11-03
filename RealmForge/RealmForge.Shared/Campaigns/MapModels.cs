namespace RealmForge.Shared.Campaigns;

///	<summary>
///	What a token on the virtual tabletop stands for.
///	</summary>
public enum TokenKind
{
	Character = 1,
	Npc = 2,
	Monster = 3,
	Marker = 4
}

///	<summary>
///	The grid of a map: squares, or hexagons in rows (pointy top, odd rows shifted right) or in columns (flat top, odd
///	columns shifted down).
///	</summary>
public enum GridType
{
	Square = 0,
	HexRows = 1,
	HexColumns = 2
}

///	<summary>
///	Where the cells of a grid are, in pixels of the map picture. The grid size is the side of a square, or the distance
///	between two opposite sides of a hexagon; the offset moves the whole grid. A token stands on a cell (col, row): its
///	centre is the centre of the cell (a square token of size n covers n × n squares from there).
///	</summary>
public static class MapGeometry
{
	private const double Sqrt3 = 1.7320508075688772;

	public static (double Width, double Height) Cell(GridType type, int grid) => type switch
	{
		GridType.HexRows => (grid, 2 * grid / Sqrt3),
		GridType.HexColumns => (2 * grid / Sqrt3, grid),
		_ => (grid, grid)
	};

	public static (double X, double Y) Center(GridType type, int grid, int offsetX, int offsetY, int col, int row, int size = 1)
	{
		var (w, h) = Cell(type, grid);
		return type switch
		{
			GridType.HexRows => (offsetX + w / 2 + col * w + ((row & 1) == 1 ? w / 2 : 0), offsetY + h / 2 + row * 0.75 * h),
			GridType.HexColumns => (offsetX + w / 2 + col * 0.75 * w, offsetY + h / 2 + row * h + ((col & 1) == 1 ? h / 2 : 0)),
			_ => (offsetX + (col + size / 2.0) * grid, offsetY + (row + size / 2.0) * grid)
		};
	}

	///	<summary>
	///	The cell whose centre is nearest to a point (the centre of a token being dropped).
	///	</summary>
	public static (int Col, int Row) Nearest(GridType type, int grid, int offsetX, int offsetY, double x, double y, int size = 1)
	{
		if (type == GridType.Square)
		{
			return (Math.Max(0, (int)Math.Round((x - offsetX) / grid - size / 2.0)), Math.Max(0, (int)Math.Round((y - offsetY) / grid - size / 2.0)));
		}
		var (w, h) = Cell(type, grid);
		int guessCol, guessRow;
		if (type == GridType.HexRows)
		{
			guessRow = (int)Math.Round((y - offsetY - h / 2) / (0.75 * h));
			guessCol = (int)Math.Round((x - offsetX - w / 2) / w);
		}
		else
		{
			guessCol = (int)Math.Round((x - offsetX - w / 2) / (0.75 * w));
			guessRow = (int)Math.Round((y - offsetY - h / 2) / h);
		}
		var best = (Col: Math.Max(0, guessCol), Row: Math.Max(0, guessRow));
		var bestDistance = double.MaxValue;
		for (var dc = -1; dc <= 1; dc++)
		{
			for (var dr = -1; dr <= 1; dr++)
			{
				var (c, r) = (guessCol + dc, guessRow + dr);
				if (c < 0 || r < 0)
				{
					continue;
				}
				var (cx, cy) = Center(type, grid, offsetX, offsetY, c, r);
				var distance = (cx - x) * (cx - x) + (cy - y) * (cy - y);
				if (distance < bestDistance)
				{
					bestDistance = distance;
					best = (c, r);
				}
			}
		}
		return best;
	}

	///	<summary>
	///	A token on the map: on a cell of the grid with its centre inside the picture.
	///	</summary>
	public static bool Inside(GridType type, int grid, int offsetX, int offsetY, int col, int row, int size, int width, int height)
	{
		if (col < 0 || row < 0)
		{
			return false;
		}
		var (x, y) = Center(type, grid, offsetX, offsetY, col, row, size);
		return x >= 0 && y >= 0 && x <= width && y <= height;
	}

	///	<summary>
	///	Cells between two cells, as the rules count them: squares by the longest side (every diagonal square counts 1),
	///	hexagons by the steps between them.
	///	</summary>
	public static int Distance(GridType type, int col1, int row1, int col2, int row2)
	{
		if (type == GridType.Square)
		{
			return Math.Max(Math.Abs(col1 - col2), Math.Abs(row1 - row2));
		}
		var (q1, r1) = Axial(type, col1, row1);
		var (q2, r2) = Axial(type, col2, row2);
		var (dq, dr) = (q1 - q2, r1 - r2);
		return (Math.Abs(dq) + Math.Abs(dr) + Math.Abs(dq + dr)) / 2;
	}

	///	<summary>
	///	The grid that puts a cell exactly on a box drawn over one cell of the picture: the size (the side of a square, the
	///	distance between opposite flat sides of a hexagon) and the offsets, the smallest that place a cell there.
	///	</summary>
	public static (int Grid, int OffsetX, int OffsetY) Calibrate(GridType type, double x, double y, double width, double height)
	{
		var grid = (int)Math.Round(type switch
		{
			GridType.HexRows => width,
			GridType.HexColumns => height,
			_ => (width + height) / 2
		});
		grid = Math.Clamp(grid, MapRules.MinGrid, MapRules.MaxGrid);
		var (w, h) = Cell(type, grid);
		double ox, oy;
		if (type == GridType.Square)
		{
			(ox, oy) = (x, y);
		}
		else
		{
			//	As if the hexagon in the box were the first one, then back by whole rows (or columns) towards the corner
			ox = x + width / 2 - w / 2;
			oy = y + height / 2 - h / 2;
			if (type == GridType.HexRows)
			{
				var rows = (int)Math.Floor(oy / (0.75 * h));
				oy -= rows * 0.75 * h;
				if ((rows & 1) == 1)
				{
					ox -= w / 2;
				}
			}
			else
			{
				var cols = (int)Math.Floor(ox / (0.75 * w));
				ox -= cols * 0.75 * w;
				if ((cols & 1) == 1)
				{
					oy -= h / 2;
				}
			}
		}
		var offsetX = Modulo((int)Math.Round(ox), type == GridType.HexColumns ? (int)Math.Round(0.75 * w) : grid);
		var offsetY = Modulo((int)Math.Round(oy), type == GridType.HexRows ? (int)Math.Round(0.75 * h) : grid);
		return (grid, Math.Min(offsetX, grid - 1), Math.Min(offsetY, grid - 1));
	}

	private static int Modulo(int value, int by) => by <= 0 ? 0 : ((value % by) + by) % by;

	private static (int Q, int R) Axial(GridType type, int col, int row) => type == GridType.HexRows
		? (col - (row - (row & 1)) / 2, row)
		: (col, row - (col - (col & 1)) / 2);
}

///	<summary>
///	Limits of the virtual tabletop: maps per campaign, tokens per map, the picture (a JPEG data URL), the grid.
///	</summary>
public static class MapRules
{
	public const int MaxMaps = 20;
	public const int MaxTokens = 200;
	public const int MaxImageLength = 4_000_000;
	public const int MaxImageSide = 4096;
	public const int MinGrid = 16;
	public const int MaxGrid = 300;
	public const int MaxTokenSize = 6;

	//	Cells across a map: the picture over the grid, at least one
	public static int Columns(int width, int grid, int offset) => Math.Max(1, (width - offset + grid - 1) / grid);

	public static int Rows(int height, int grid, int offset) => Math.Max(1, (height - offset + grid - 1) / grid);

	///	<summary>
	///	Who moves a token: the masters any token; a player only the token of a character they own, on a map shown to the
	///	table, when the token is not hidden.
	///	</summary>
	public static bool CanMove(CampaignRole role, bool ownsCharacter, bool mapShown, bool hidden) =>
		CampaignRules.RunsTheTable(role) || (ownsCharacter && mapShown && !hidden);
}
