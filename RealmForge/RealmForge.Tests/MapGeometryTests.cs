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
}
