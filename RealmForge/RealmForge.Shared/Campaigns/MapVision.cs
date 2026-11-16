using System.Text.RegularExpressions;

namespace RealmForge.Shared.Campaigns;

///	<summary>
///	How lit a map is where no light is carried: in bright light (a sunny day, a lit hall), in dim light (twilight, a
///	moonlit night), in darkness (a cave, a moonless night).
///	</summary>
public enum MapLighting
{
	Bright = 0,
	Dim = 1,
	Dark = 2
}

///	<summary>
///	A light carried by a token (a torch, a lantern, the Light cantrip) or set on a marker (a brazier): bright light
///	within Bright feet of the token, dim light for Dim feet more.
///	</summary>
public sealed class TokenLight
{
	public string Name { get; set; } = string.Empty;
	public int Bright { get; set; }
	public int Dim { get; set; }

	public const int MaxFeet = 120;

	//	The usual lights, in feet: candle, torch, hooded lantern, Light, bullseye lantern (its cone drawn as a circle),
	//	Daylight
	public static readonly IReadOnlyList<(string Key, int Bright, int Dim)> Presets = new[]
	{
		("candle", 5, 5), ("torch", 20, 20), ("lantern", 30, 30), ("light", 20, 20), ("bullseye", 60, 60), ("daylight", 60, 60)
	};
}

///	<summary>
///	What the creatures on a map see, cell by cell: a cell is seen when nothing blocks the sight to it (a wall, a closed
///	door) and it is lit (bright or dim light, by the map or by a light that reaches it unblocked), or it is within the
///	darkvision of the one looking (darkness as dim light). A blinded creature sees nothing past its own space.
///	</summary>
public static partial class MapVision
{
	///	<summary>A creature looking: its place and size, its darkvision in feet, whether it is blinded.</summary>
	public sealed record Viewer(int Col, int Row, int Size, int Darkvision, bool Blinded = false);

	///	<summary>A light: the place and size of the token carrying it, its bright and dim radius in feet.</summary>
	public sealed record Light(int Col, int Row, int Size, int Bright, int Dim);

	///	<summary>The map: its grid, its picture, the cells that block the sight (walls and closed doors).</summary>
	public sealed record Board(GridType Type, int Grid, int OffsetX, int OffsetY, int Width, int Height, IReadOnlySet<(int Col, int Row)> Blocking);

	//	The cells of a feet distance (5 feet a cell)
	public static int Cells(int feet) => Math.Max(0, feet) / 5;

	///	<summary>The cells that stop the sight: the walls of the terrain and the cells of the closed doors.</summary>
	public static HashSet<(int Col, int Row)> Blocking(IReadOnlyList<int>? terrain, IEnumerable<(int Col, int Row)> closed)
	{
		var cells = MapTerrain.Read(terrain).Where(c => c.Value == TerrainKind.Wall).Select(c => c.Key).ToHashSet();
		cells.UnionWith(closed);
		return cells;
	}

	///	<summary>
	///	The cells the viewers see together: the bright ones (seen in bright light) and the dim ones (in dim light, or
	///	in darkness through darkvision).
	///	</summary>
	public static (HashSet<(int Col, int Row)> Bright, HashSet<(int Col, int Row)> Dim) Seen(Board board, MapLighting lighting,
		IReadOnlyCollection<Viewer> viewers, IReadOnlyCollection<Light> lights)
	{
		var bright = new HashSet<(int, int)>();
		var dim = new HashSet<(int, int)>();
		if (viewers.Count == 0)
		{
			return (bright, dim);
		}
		var columns = MapRules.Columns(board.Width, board.Grid, board.OffsetX) + 1;
		var rows = MapRules.Rows(board.Height, board.Grid, board.OffsetY) + 1;
		var level = new Dictionary<(int, int), int>();

		//	The light each cell gets from the lights that reach it
		foreach (var light in lights)
		{
			var reach = Cells(light.Bright) + Cells(light.Dim);
			if (reach <= 0)
			{
				continue;
			}
			foreach (var cell in Around(board, light.Col, light.Row, light.Size, reach, columns, rows))
			{
				var distance = DistanceFrom(board.Type, light.Col, light.Row, light.Size, cell);
				var lit = distance <= Cells(light.Bright) ? 2 : distance <= reach ? 1 : 0;
				if (lit > level.GetValueOrDefault(cell) && Sees(board, light.Col, light.Row, light.Size, cell))
				{
					level[cell] = lit;
				}
			}
		}
		var ambient = lighting switch { MapLighting.Bright => 2, MapLighting.Dim => 1, _ => 0 };
		foreach (var viewer in viewers)
		{
			var own = MapTerrain.Footprint(board.Type, viewer.Col, viewer.Row, viewer.Size).ToList();
			foreach (var cell in own)
			{
				bright.Add(cell);
			}
			if (viewer.Blinded)
			{
				continue;
			}
			var darkvision = Cells(viewer.Darkvision);

			//	In the dark only the lit cells and the darkvision count: the cells looked at are those near the viewer and
			//	those the lights reach
			IEnumerable<(int Col, int Row)> candidates = ambient > 0
				? All(columns, rows)
				: Around(board, viewer.Col, viewer.Row, viewer.Size, darkvision, columns, rows).Concat(level.Keys).Distinct();
			foreach (var cell in candidates)
			{
				var light = Math.Max(ambient, level.GetValueOrDefault(cell));
				var near = darkvision > 0 && DistanceFrom(board.Type, viewer.Col, viewer.Row, viewer.Size, cell) <= darkvision;
				if (light == 0 && !near)
				{
					continue;
				}
				if (light == 2 ? bright.Contains(cell) : (bright.Contains(cell) || dim.Contains(cell)))
				{
					continue;
				}
				if (!Sees(board, viewer.Col, viewer.Row, viewer.Size, cell))
				{
					continue;
				}
				if (light == 2)
				{
					bright.Add(cell);
					dim.Remove(cell);
				}
				else
				{
					dim.Add(cell);
				}
			}
		}
		return (bright, dim);
	}

	///	<summary>Whether a creature's space is in the cells seen.</summary>
	public static bool Spotted(GridType type, int col, int row, int size, IReadOnlySet<(int Col, int Row)> bright, IReadOnlySet<(int Col, int Row)> dim) =>
		MapTerrain.Footprint(type, col, row, size).Any(c => bright.Contains(c) || dim.Contains(c));

	///	<summary>
	///	Whether the sight reaches a cell from a token's space: from the middle of one of its cells to the middle of the
	///	cell, no wall or closed door crossed (the cell itself can be a wall: it is seen).
	///	</summary>
	public static bool Sees(Board board, int col, int row, int size, (int Col, int Row) cell)
	{
		var target = MapGeometry.Center(board.Type, board.Grid, board.OffsetX, board.OffsetY, cell.Col, cell.Row);
		foreach (var from in MapTerrain.Footprint(board.Type, col, row, size))
		{
			if (from == cell)
			{
				return true;
			}
			var start = MapGeometry.Center(board.Type, board.Grid, board.OffsetX, board.OffsetY, from.Col, from.Row);
			if (Clear(board, start, target, from, cell))
			{
				return true;
			}
		}
		return false;
	}

	private static bool Clear(Board board, (double X, double Y) a, (double X, double Y) b, (int, int) from, (int, int) to)
	{
		if (board.Blocking.Count == 0)
		{
			return true;
		}
		var length = Math.Sqrt((b.X - a.X) * (b.X - a.X) + (b.Y - a.Y) * (b.Y - a.Y));
		var steps = Math.Max(1, (int)Math.Ceiling(length / Math.Max(1, board.Grid / 5.0)));
		for (var i = 1; i < steps; i++)
		{
			var x = a.X + (b.X - a.X) * i / steps;
			var y = a.Y + (b.Y - a.Y) * i / steps;
			var cell = board.Type == GridType.Square
				? ((int)Math.Floor((x - board.OffsetX) / board.Grid), (int)Math.Floor((y - board.OffsetY) / board.Grid))
				: MapGeometry.Nearest(board.Type, board.Grid, board.OffsetX, board.OffsetY, x, y);
			if (cell != from && cell != to && board.Blocking.Contains(cell))
			{
				return false;
			}
		}
		return true;
	}

	private static int DistanceFrom(GridType type, int col, int row, int size, (int Col, int Row) cell) =>
		MapTerrain.Footprint(type, col, row, size).Min(c => MapGeometry.Distance(type, c.Col, c.Row, cell.Col, cell.Row));

	private static IEnumerable<(int Col, int Row)> All(int columns, int rows)
	{
		for (var c = -1; c < columns; c++)
		{
			for (var r = -1; r < rows; r++)
			{
				yield return (c, r);
			}
		}
	}

	//	The cells of the map within a distance of a token's space (a box around it, cut to the map)
	private static IEnumerable<(int Col, int Row)> Around(Board board, int col, int row, int size, int reach, int columns, int rows)
	{
		var side = board.Type == GridType.Square ? Math.Max(1, size) : 1;
		var margin = reach + 1;
		for (var c = Math.Max(-1, col - margin); c <= Math.Min(columns - 1, col + side + margin); c++)
		{
			for (var r = Math.Max(-1, row - margin); r <= Math.Min(rows - 1, row + side + margin); r++)
			{
				if (DistanceFrom(board.Type, col, row, size, (c, r)) <= reach)
				{
					yield return (c, r);
				}
			}
		}
	}

	///	<summary>
	///	The farthest a statblock's senses see in the dark, in feet: darkvision, blindsight, truesight ("darkvision 60
	///	ft.", "scurovisione 18 m", "vista cieca 3 m", "vista pura 36 m").
	///	</summary>
	public static int DarkvisionOf(string? senses)
	{
		var best = 0;
		foreach (Match m in SensesPattern().Matches(senses ?? string.Empty))
		{
			if (!int.TryParse(m.Groups["n"].Value, out var n))
			{
				continue;
			}
			var feet = m.Groups["unit"].Value.StartsWith("m", StringComparison.OrdinalIgnoreCase) ? (int)Math.Round(n / 0.3) : n;
			best = Math.Max(best, feet);
		}
		return Math.Min(best, 300);
	}

	[GeneratedRegex(@"(?:darkvision|blindsight|truesight|scurovisione|vista\s+cieca|vista\s+pura|vista\s+del\s+vero)\s*(?<n>\d+)\s*(?<unit>ft|feet|piedi|m)\b", RegexOptions.IgnoreCase)]
	private static partial Regex SensesPattern();
}
