namespace RealmForge.Shared.Campaigns;

///	<summary>
///	What a cell of a map is for the movement: free to walk (the default, never stored), a wall or obstacle nobody walks
///	through, difficult terrain (every cell costs one more), a door or passage (free unless a closed door stands there).
///	</summary>
public enum TerrainKind
{
	Walkable = 0,
	Wall = 1,
	Difficult = 2,
	Door = 3,

	//	A low wall, a barrel, a table: half cover (+2 to the armour class), crossed as difficult terrain
	HalfCover = 4,

	//	An arrow slit, a thick tree trunk: three-quarters cover (+5), not crossed; neither blocks the sight
	ThreeQuarterCover = 5
}

///	<summary>
///	The terrain of a map: the cells that are not plain floor, as groups of three numbers (column, row, kind), and
///	whether it stops the players' tokens (the masters move freely). A move of a player follows the cheapest path that goes
///	around the walls and the closed doors: a token never goes straight through a wall or a column.
///	</summary>
public static class MapTerrain
{
	public const int MaxCells = 20_000;

	//	The longest path looked for, in cells: well past any speed (a move further than this is not checked for walls)
	public const int MaxPath = 120;

	public static bool Valid(IReadOnlyList<int>? cells) =>
		cells is not null && cells.Count % 3 == 0 && cells.Count / 3 <= MaxCells
		&& Enumerable.Range(0, cells.Count / 3).All(i => cells[i * 3] is >= -1 and < 1000 && cells[i * 3 + 1] is >= -1 and < 1000
			&& Enum.IsDefined((TerrainKind)cells[i * 3 + 2]) && cells[i * 3 + 2] != (int)TerrainKind.Walkable);

	///	<summary>The cells by their place (the last group of a cell wins).</summary>
	public static Dictionary<(int Col, int Row), TerrainKind> Read(IReadOnlyList<int>? cells)
	{
		var map = new Dictionary<(int, int), TerrainKind>();
		if (cells is null)
		{
			return map;
		}
		for (var i = 0; i + 2 < cells.Count; i += 3)
		{
			var kind = (TerrainKind)cells[i + 2];
			if (kind == TerrainKind.Walkable)
			{
				map.Remove((cells[i], cells[i + 1]));
			}
			else if (Enum.IsDefined(kind))
			{
				map[(cells[i], cells[i + 1])] = kind;
			}
		}
		return map;
	}

	///	<summary>The cells back as groups of three numbers, in a stable order.</summary>
	public static List<int> Write(IReadOnlyDictionary<(int Col, int Row), TerrainKind> cells) => cells
		.Where(c => c.Value != TerrainKind.Walkable)
		.OrderBy(c => c.Key.Row).ThenBy(c => c.Key.Col)
		.SelectMany(c => new[] { c.Key.Col, c.Key.Row, (int)c.Value })
		.ToList();

	///	<summary>
	///	Paints cells with a kind (Walkable clears them); the cells come as pairs of numbers (column, row).
	///	</summary>
	public static List<int> Paint(IReadOnlyList<int>? cells, IReadOnlyList<int> pairs, TerrainKind kind)
	{
		var map = Read(cells);
		for (var i = 0; i + 1 < pairs.Count; i += 2)
		{
			if (pairs[i] < -1 || pairs[i + 1] < -1)
			{
				continue;
			}
			if (kind == TerrainKind.Walkable)
			{
				map.Remove((pairs[i], pairs[i + 1]));
			}
			else if (map.Count < MaxCells || map.ContainsKey((pairs[i], pairs[i + 1])))
			{
				map[(pairs[i], pairs[i + 1])] = kind;
			}
		}
		return Write(map);
	}

	///	<summary>The cells a token covers at a place: its size in squares, a single hexagon.</summary>
	public static IEnumerable<(int Col, int Row)> Footprint(GridType type, int col, int row, int size)
	{
		var side = type == GridType.Square ? Math.Max(1, size) : 1;
		for (var dc = 0; dc < side; dc++)
		{
			for (var dr = 0; dr < side; dr++)
			{
				yield return (col + dc, row + dr);
			}
		}
	}

	///	<summary>
	///	The cheapest path from one place to another for a token, around the cells that block it (walls, and the places
	///	of the closed doors given): every step costs 1 (a diagonal square too, as the rules count), 2 into difficult
	///	terrain; a diagonal step does not squeeze between two blocked squares. Null when there is no way within
	///	<paramref name="maxCost"/> or off the map (<paramref name="onMap"/>); the cells of the path with its cost otherwise (the
	///	start excluded).
	///	</summary>
	public static (int Cost, List<(int Col, int Row)> Path)? FindPath(GridType type, IReadOnlyDictionary<(int Col, int Row), TerrainKind> terrain,
		IReadOnlySet<(int Col, int Row)> closed, (int Col, int Row) from, (int Col, int Row) to, int size, int maxCost, Func<int, int, bool> onMap)
	{
		if (from == to)
		{
			return (0, new List<(int, int)>());
		}
		bool Free((int Col, int Row) at) => onMap(at.Col, at.Row)
			&& Footprint(type, at.Col, at.Row, size).All(c => !closed.Contains(c) && terrain.GetValueOrDefault(c) is not (TerrainKind.Wall or TerrainKind.ThreeQuarterCover));
		int Step((int Col, int Row) at) => Footprint(type, at.Col, at.Row, size).Any(c => terrain.GetValueOrDefault(c) is TerrainKind.Difficult or TerrainKind.HalfCover) ? 2 : 1;
		if (!Free(to))
		{
			return null;
		}

		var best = new Dictionary<(int, int), int> { [from] = 0 };
		var back = new Dictionary<(int, int), (int, int)>();
		var queue = new PriorityQueue<(int Col, int Row), int>();
		queue.Enqueue(from, 0);
		while (queue.TryDequeue(out var at, out var cost))
		{
			if (cost > best.GetValueOrDefault(at, int.MaxValue))
			{
				continue;
			}
			if (at == to)
			{
				var path = new List<(int, int)>();
				for (var p = to; p != from; p = back[p])
				{
					path.Add(p);
				}
				path.Reverse();
				return (cost, path);
			}
			foreach (var next in Neighbours(type, at))
			{
				if (!Free(next))
				{
					continue;
				}
				//	A diagonal square between two blocked ones is not a way through
				if (type == GridType.Square && next.Col != at.Col && next.Row != at.Row
					&& !Free((next.Col, at.Row)) && !Free((at.Col, next.Row)))
				{
					continue;
				}
				var total = cost + Step(next);
				if (total > maxCost || total >= best.GetValueOrDefault(next, int.MaxValue))
				{
					continue;
				}
				best[next] = total;
				back[next] = at;
				queue.Enqueue(next, total);
			}
		}
		return null;
	}

	///	<summary>
	///	The way of a token across a map, as the board sees it: the terrain, the cells of the closed doors and the cells on
	///	the picture. Null when walls and doors leave no way within <see cref="MaxPath"/>.
	///	</summary>
	public static (int Cost, List<(int Col, int Row)> Path)? Route(GridType type, int grid, int offsetX, int offsetY, int width, int height,
		IReadOnlyList<int>? cells, IEnumerable<(int Col, int Row)> closed, (int Col, int Row) from, (int Col, int Row) to, int size) =>
		FindPath(type, Read(cells), closed.ToHashSet(), from, to, size, MaxPath,
			(col, row) => MapGeometry.Inside(type, grid, offsetX, offsetY, col, row, size, width, height));

	public const int TotalCover = 99;

	///	<summary>
	///	The cover between two tokens (from the middle of one to the middle of the other, through the cells crossed, the
	///	cells of the two tokens left out): 0 none, 2 half, 5 three-quarters, TotalCover behind a wall or a closed door.
	///	</summary>
	public static int Cover(GridType type, int grid, int offsetX, int offsetY, IReadOnlyDictionary<(int Col, int Row), TerrainKind> terrain,
		IReadOnlySet<(int Col, int Row)> closed, (int Col, int Row, int Size) from, (int Col, int Row, int Size) to)
	{
		var a = MapGeometry.Center(type, grid, offsetX, offsetY, from.Col, from.Row, from.Size);
		var b = MapGeometry.Center(type, grid, offsetX, offsetY, to.Col, to.Row, to.Size);
		var own = Footprint(type, from.Col, from.Row, from.Size).Concat(Footprint(type, to.Col, to.Row, to.Size)).ToHashSet();
		return CoverAlong(type, grid, offsetX, offsetY, terrain, closed, a, b, own);
	}

	///	<summary>Whether a cell is seen from a point (the origin of an area): no wall or closed door in between.</summary>
	public static bool Visible(GridType type, int grid, int offsetX, int offsetY, IReadOnlyDictionary<(int Col, int Row), TerrainKind> terrain,
		IReadOnlySet<(int Col, int Row)> closed, (double X, double Y) origin, (int Col, int Row) cell)
	{
		var b = MapGeometry.Center(type, grid, offsetX, offsetY, cell.Col, cell.Row);
		var start = MapGeometry.Nearest(type, grid, offsetX, offsetY, origin.X, origin.Y);
		return CoverAlong(type, grid, offsetX, offsetY, terrain, closed, origin, b, new HashSet<(int, int)> { start, cell }) < TotalCover;
	}

	private static int CoverAlong(GridType type, int grid, int offsetX, int offsetY, IReadOnlyDictionary<(int Col, int Row), TerrainKind> terrain,
		IReadOnlySet<(int Col, int Row)> closed, (double X, double Y) a, (double X, double Y) b, HashSet<(int, int)> own)
	{
		var length = Math.Sqrt((b.X - a.X) * (b.X - a.X) + (b.Y - a.Y) * (b.Y - a.Y));
		var steps = Math.Max(1, (int)Math.Ceiling(length / Math.Max(1, grid / 6.0)));
		var cover = 0;
		for (var i = 1; i < steps; i++)
		{
			var x = a.X + (b.X - a.X) * i / steps;
			var y = a.Y + (b.Y - a.Y) * i / steps;
			var cell = MapGeometry.Nearest(type, grid, offsetX, offsetY, x, y);
			if (own.Contains(cell))
			{
				continue;
			}
			if (closed.Contains(cell))
			{
				return TotalCover;
			}
			switch (terrain.GetValueOrDefault(cell))
			{
				case TerrainKind.Wall:
					return TotalCover;
				case TerrainKind.ThreeQuarterCover:
					cover = Math.Max(cover, 5);
					break;
				case TerrainKind.HalfCover:
					cover = Math.Max(cover, 2);
					break;
			}
		}
		return cover;
	}

	///	<summary>The cells next to a cell: eight squares, six hexagons.</summary>
	public static IEnumerable<(int Col, int Row)> Neighbours(GridType type, (int Col, int Row) at)
	{
		if (type == GridType.Square)
		{
			for (var dc = -1; dc <= 1; dc++)
			{
				for (var dr = -1; dr <= 1; dr++)
				{
					if (dc != 0 || dr != 0)
					{
						yield return (at.Col + dc, at.Row + dr);
					}
				}
			}
			yield break;
		}
		var (q, r) = type == GridType.HexRows ? (at.Col - (at.Row - (at.Row & 1)) / 2, at.Row) : (at.Col, at.Row - (at.Col - (at.Col & 1)) / 2);
		foreach (var (dq, dr) in new[] { (1, 0), (-1, 0), (0, 1), (0, -1), (1, -1), (-1, 1) })
		{
			var (nq, nr) = (q + dq, r + dr);
			yield return type == GridType.HexRows ? (nq + (nr - (nr & 1)) / 2, nr) : (nq, nr + (nq - (nq & 1)) / 2);
		}
	}

	///	<summary>Whether a door or gate in this state stops a token.</summary>
	public static bool Closes(PropType type, PropState state) =>
		type is PropType.Door or PropType.Gate or PropType.Secret && state is PropState.Closed or PropState.Locked or PropState.Barred;
}
