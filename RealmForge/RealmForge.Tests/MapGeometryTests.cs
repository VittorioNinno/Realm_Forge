using RealmForge.Shared.Campaigns;

namespace RealmForge.Tests;

///	<summary>
///	The grids of the virtual tabletop: cell centres, the nearest cell to a point, what is on the map, distances.
///	</summary>
public class MapGeometryTests
{
	[Fact]
	public void Square_cells_are_squares_and_a_big_token_covers_from_its_cell()
	{
		Assert.Equal((105.0, 35.0), MapGeometry.Center(GridType.Square, 70, 0, 0, 1, 0));
		Assert.Equal((140.0, 70.0), MapGeometry.Center(GridType.Square, 70, 0, 0, 1, 0, size: 2));
		Assert.Equal((1, 0), MapGeometry.Nearest(GridType.Square, 70, 0, 0, 140, 70, size: 2));
		Assert.Equal((2, 3), MapGeometry.Nearest(GridType.Square, 70, 10, 10, 10 + 2 * 70 + 30, 10 + 3 * 70 + 40));
	}

	[Theory]
	[InlineData(GridType.HexRows)]
	[InlineData(GridType.HexColumns)]
	public void Every_hex_centre_is_its_own_nearest_cell(GridType type)
	{
		for (var col = 0; col < 8; col++)
		{
			for (var row = 0; row < 8; row++)
			{
				var (x, y) = MapGeometry.Center(type, 60, 12, 7, col, row);
				Assert.Equal((col, row), MapGeometry.Nearest(type, 60, 12, 7, x + 9, y - 11));
			}
		}
	}

	[Fact]
	public void Hex_neighbours_are_one_step_apart()
	{
		//	Pointy top, odd rows shifted right: (1, 1) touches (1, 0), (2, 0), (0, 1), (2, 1), (1, 2), (2, 2)
		foreach (var (c, r) in new[] { (1, 0), (2, 0), (0, 1), (2, 1), (1, 2), (2, 2) })
		{
			Assert.Equal(1, MapGeometry.Distance(GridType.HexRows, 1, 1, c, r));
		}
		Assert.Equal(2, MapGeometry.Distance(GridType.HexRows, 1, 1, 0, 0));
		Assert.Equal(3, MapGeometry.Distance(GridType.Square, 0, 0, 3, 2));
	}

	[Fact]
	public void A_token_is_on_the_map_when_its_centre_is_inside_the_picture()
	{
		Assert.True(MapGeometry.Inside(GridType.Square, 70, 0, 0, 9, 6, 1, 700, 490));
		Assert.False(MapGeometry.Inside(GridType.Square, 70, 0, 0, 10, 6, 1, 700, 490));
		Assert.False(MapGeometry.Inside(GridType.HexRows, 70, 0, 0, -1, 0, 1, 700, 490));
	}

	[Fact]
	public void A_box_over_one_cell_aligns_the_grid()
	{
		Assert.Equal((70, 10, 10), MapGeometry.Calibrate(GridType.Square, 150, 80, 69, 71));
		foreach (var type in new[] { GridType.HexRows, GridType.HexColumns })
		{
			var (w, h) = MapGeometry.Cell(type, 60);
			var (cx, cy) = MapGeometry.Center(type, 60, 12, 7, 3, 5);
			Assert.Equal((60, 12, 7), MapGeometry.Calibrate(type, cx - w / 2, cy - h / 2, w, h));
		}
	}

	[Fact]
	public void Spell_areas_cover_the_cells_of_the_rules()
	{
		//	A sphere of 1 cell around a square: the cell and its four sides; a line of 3 cells: the next three; a cube of 3:
		//	three by three in front; a cone of 3: one, then three, then three
		int Count(ShapeKind kind, double tx, double ty, int size) =>
			MapAreas.Cells(GridType.Square, 70, 0, 0, kind, 175, 175, tx, ty, size, 1400, 1400).Count;
		Assert.Equal(5, Count(ShapeKind.Sphere, 175, 175, 1));
		Assert.Equal(new[] { (3, 2), (4, 2), (5, 2) }, MapAreas.Cells(GridType.Square, 70, 0, 0, ShapeKind.Line, 175, 175, 500, 175, 3, 1400, 1400).OrderBy(c => c.Col));
		Assert.Equal(9, Count(ShapeKind.Cube, 500, 175, 3));
		Assert.Equal(7, Count(ShapeKind.Cone, 500, 175, 3));
		Assert.Equal(6, MapAreas.Corners(GridType.HexRows, 60, 0, 0, 2, 3).Count);
	}

	[Fact]
	public void Fog_hexagons_cover_their_cell_and_not_the_next()
	{
		//	A pointy-top hexagon of a 60 px grid (rows) at (100, 100): radius 60 / √3
		var radius = 60 / Math.Sqrt(3);
		var fog = new List<double> { MapFog.Reveal, 0, 0, 400, 400, MapFog.CoverHex, 100, 100, radius, (int)GridType.HexRows };
		Assert.True(MapFog.Covered(fog, 100, 100));
		Assert.True(MapFog.Covered(fog, 100, 100 + radius - 1));
		Assert.False(MapFog.Covered(fog, 100 + 31, 100));
		Assert.False(MapFog.Covered(fog, 160, 100));
		//	Flat-top (columns): wide along x, the corner on the side
		Assert.True(MapFog.InHex(100, 100, radius, (int)GridType.HexColumns, 100 + radius - 1, 100));
		Assert.False(MapFog.InHex(100, 100, radius, (int)GridType.HexColumns, 100, 100 + radius - 1));
		Assert.True(MapFog.Valid(fog));
		Assert.False(MapFog.Valid(new List<double> { 7, 0, 0, 1, 1 }));
	}

	[Fact]
	public void Drawings_stay_with_their_author_and_the_masters_share_texts_on_purpose()
	{
		//	Strokes are always private; a player's text too; a master's text only when not shared; areas for everyone
		Assert.True(MapRules.IsPrivate(ShapeKind.Freehand, runsTheTable: true, shared: true));
		Assert.True(MapRules.IsPrivate(ShapeKind.Text, runsTheTable: false, shared: true));
		Assert.True(MapRules.IsPrivate(ShapeKind.Text, runsTheTable: true, shared: false));
		Assert.False(MapRules.IsPrivate(ShapeKind.Text, runsTheTable: true, shared: true));
		Assert.False(MapRules.IsPrivate(ShapeKind.Cone, runsTheTable: false, shared: false));
		//	Someone else's stroke is never seen, even an old one not marked private; a shared text and an area are
		Assert.False(MapRules.Sees(ShapeKind.Freehand, isPrivate: false, mine: false));
		Assert.True(MapRules.Sees(ShapeKind.Freehand, isPrivate: true, mine: true));
		Assert.False(MapRules.Sees(ShapeKind.Text, isPrivate: true, mine: false));
		Assert.True(MapRules.Sees(ShapeKind.Text, isPrivate: false, mine: false));
		Assert.True(MapRules.Sees(ShapeKind.Sphere, isPrivate: false, mine: false));
		//	A master removes and moves what the table sees, never someone's private drawing; a player only their own
		Assert.True(MapRules.CanDeleteShape(ShapeKind.Text, isPrivate: false, mine: false, runsTheTable: true));
		Assert.False(MapRules.CanDeleteShape(ShapeKind.Text, isPrivate: true, mine: false, runsTheTable: true));
		Assert.False(MapRules.CanDeleteShape(ShapeKind.Sphere, isPrivate: false, mine: false, runsTheTable: false));
		Assert.True(MapRules.CanMoveShape(ShapeKind.Text, isPrivate: true, mine: true, runsTheTable: false));
		Assert.True(MapRules.CanMoveShape(ShapeKind.Text, isPrivate: false, mine: false, runsTheTable: true));
		Assert.False(MapRules.CanMoveShape(ShapeKind.Text, isPrivate: false, mine: false, runsTheTable: false));
		Assert.False(MapRules.CanMoveShape(ShapeKind.Freehand, isPrivate: true, mine: true, runsTheTable: true));
	}

	[Fact]
	public void An_open_table_closes_on_its_own_only_when_nothing_happens_at_it()
	{
		var now = new DateTimeOffset(2026, 11, 12, 21, 0, 0, TimeSpan.Zero);
		var idle = CampaignRules.TableIdleHours;
		Assert.True(CampaignRules.IsTableOpen(now.AddHours(-1), null, now));
		//	A session of 20 hours with a token moved ten minutes ago stays open
		Assert.True(CampaignRules.IsTableOpen(now.AddHours(-20), now.AddMinutes(-10), now));
		//	Opened long ago with nothing done since (or only before the opening): closed
		Assert.False(CampaignRules.IsTableOpen(now.AddHours(-idle), null, now));
		Assert.False(CampaignRules.IsTableOpen(now.AddHours(-idle - 1), now.AddHours(-idle - 5), now));
		Assert.False(CampaignRules.IsTableOpen(now.AddHours(-20), now.AddHours(-idle - 1), now));
		Assert.False(CampaignRules.IsTableOpen(null, now, now));
	}
}
