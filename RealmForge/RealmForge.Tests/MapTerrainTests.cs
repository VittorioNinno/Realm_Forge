using RealmForge.Shared.Campaigns;

namespace RealmForge.Tests;

///	<summary>
///	The terrain of a map: the players' tokens go around walls and closed doors, difficult terrain costs double, a
///	diagonal does not squeeze between two walls; the cells are painted and read back.
///	</summary>
public class MapTerrainTests
{
	private static bool Board(int col, int row) => col is >= 0 and < 10 && row is >= 0 and < 10;

	private static (int Cost, List<(int Col, int Row)> Path)? Path(GridType type, Dictionary<(int, int), TerrainKind> terrain, (int, int) from, (int, int) to,
		HashSet<(int, int)>? closed = null, int size = 1) =>
		MapTerrain.FindPath(type, terrain, closed ?? new(), from, to, size, MapTerrain.MaxPath, Board);

	[Fact]
	public void A_wall_in_the_way_makes_the_token_go_around()
	{
		//	A wall from (3,0) to (3,4): from (1,2) to (5,2) the straight line is 4 squares, around the end of the wall more
		var terrain = Enumerable.Range(0, 5).ToDictionary(r => (3, r), _ => TerrainKind.Wall);
		var straight = Path(GridType.Square, new(), (1, 2), (5, 2));
		var around = Path(GridType.Square, terrain, (1, 2), (5, 2));

		Assert.Equal(4, straight!.Value.Cost);
		Assert.NotNull(around);
		Assert.True(around!.Value.Cost > 4);
		Assert.DoesNotContain(around.Value.Path, c => terrain.ContainsKey(c));
	}

	[Fact]
	public void A_closed_ring_or_a_wall_cell_cannot_be_reached()
	{
		var ring = MapTerrain.Neighbours(GridType.HexRows, (4, 4)).ToDictionary(c => c, _ => TerrainKind.Wall);
		Assert.Equal(6, ring.Count);
		Assert.Null(Path(GridType.HexRows, ring, (4, 4), (4, 8)));
		Assert.Null(Path(GridType.HexRows, ring, (4, 1), ring.Keys.First()));
	}

	[Fact]
	public void Difficult_terrain_costs_double_and_closed_doors_block()
	{
		var mud = new Dictionary<(int, int), TerrainKind> { [(2, 0)] = TerrainKind.Difficult };
		//	A corridor one square high: the mud cannot be avoided
		static bool Corridor(int col, int row) => col is >= 0 and < 5 && row == 0;
		var through = MapTerrain.FindPath(GridType.Square, mud, new HashSet<(int, int)>(), (0, 0), (4, 0), 1, MapTerrain.MaxPath, Corridor);
		Assert.Equal(5, through!.Value.Cost);

		var door = new HashSet<(int, int)> { (2, 0) };
		Assert.Null(MapTerrain.FindPath(GridType.Square, new Dictionary<(int, int), TerrainKind>(), door, (0, 0), (4, 0), 1, MapTerrain.MaxPath, Corridor));
		Assert.True(MapTerrain.Closes(PropType.Door, PropState.Locked));
		Assert.False(MapTerrain.Closes(PropType.Door, PropState.Open));
		Assert.False(MapTerrain.Closes(PropType.Chest, PropState.Closed));
	}

	[Fact]
	public void A_diagonal_does_not_squeeze_between_two_walls()
	{
		//	Walls on (1,0) and (0,1): from (0,0) the square (1,1) is not reached through the corner
		var terrain = new Dictionary<(int, int), TerrainKind> { [(1, 0)] = TerrainKind.Wall, [(0, 1)] = TerrainKind.Wall };
		static bool Small(int col, int row) => col is >= 0 and < 2 && row is >= 0 and < 2;
		Assert.Null(MapTerrain.FindPath(GridType.Square, terrain, new HashSet<(int, int)>(), (0, 0), (1, 1), 1, MapTerrain.MaxPath, Small));
	}

	[Fact]
	public void Painting_adds_replaces_and_clears_cells()
	{
		var cells = MapTerrain.Paint(null, new[] { 1, 1, 2, 1 }, TerrainKind.Wall);
		Assert.Equal(new[] { 1, 1, 1, 2, 1, 1 }, cells);
		cells = MapTerrain.Paint(cells, new[] { 1, 1 }, TerrainKind.Difficult);
		Assert.Equal(TerrainKind.Difficult, MapTerrain.Read(cells)[(1, 1)]);
		cells = MapTerrain.Paint(cells, new[] { 1, 1, 2, 1 }, TerrainKind.Walkable);
		Assert.Empty(cells);
		Assert.True(MapTerrain.Valid(new List<int> { 0, 0, 1 }));
		Assert.False(MapTerrain.Valid(new List<int> { 0, 0, 0 }));
		Assert.False(MapTerrain.Valid(new List<int> { 0, 0 }));
	}

	[Theory]
	[InlineData(TerrainKind.Walkable, 0)]
	[InlineData(TerrainKind.HalfCover, 2)]
	[InlineData(TerrainKind.ThreeQuarterCover, 5)]
	[InlineData(TerrainKind.Wall, MapTerrain.TotalCover)]
	[InlineData(TerrainKind.Difficult, 0)]
	public void What_stands_between_two_tokens_gives_cover(TerrainKind kind, int cover)
	{
		var terrain = new Dictionary<(int Col, int Row), TerrainKind> { [(2, 2)] = kind };
		Assert.Equal(cover, MapTerrain.Cover(GridType.Square, 50, 0, 0, terrain, new HashSet<(int, int)>(), (0, 2, 1), (4, 2, 1)));
	}

	[Fact]
	public void A_closed_door_hides_and_an_area_stops_at_a_wall()
	{
		var none = new Dictionary<(int Col, int Row), TerrainKind>();
		Assert.Equal(MapTerrain.TotalCover, MapTerrain.Cover(GridType.Square, 50, 0, 0, none, new HashSet<(int, int)> { (2, 2) }, (0, 2, 1), (4, 2, 1)));

		var wall = new Dictionary<(int Col, int Row), TerrainKind> { [(2, 2)] = TerrainKind.Wall };
		var origin = MapGeometry.Center(GridType.Square, 50, 0, 0, 0, 2);
		Assert.False(MapTerrain.Visible(GridType.Square, 50, 0, 0, wall, new HashSet<(int, int)>(), origin, (4, 2)));
		Assert.True(MapTerrain.Visible(GridType.Square, 50, 0, 0, wall, new HashSet<(int, int)>(), origin, (0, 4)));
		//	The wall cell itself is reached (the area touches the wall)
		Assert.True(MapTerrain.Visible(GridType.Square, 50, 0, 0, wall, new HashSet<(int, int)>(), origin, (2, 2)));
	}

	[Fact]
	public void Cover_is_crossed_or_not()
	{
		var half = Enumerable.Range(0, 10).ToDictionary(r => (3, r), _ => TerrainKind.HalfCover);
		var three = Enumerable.Range(0, 10).ToDictionary(r => (3, r), _ => TerrainKind.ThreeQuarterCover);
		Assert.Equal(5, Path(GridType.Square, half, (1, 2), (5, 2))!.Value.Cost);
		Assert.Null(Path(GridType.Square, three, (1, 2), (5, 2)));
	}
}
