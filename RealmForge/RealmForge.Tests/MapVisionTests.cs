using RealmForge.Shared.Campaigns;

namespace RealmForge.Tests;

public class MapVisionTests
{
	//	A 20 × 10 squares map of 50 px cells, with a wall down column 10 (rows 0-9) unless told otherwise
	private static MapVision.Board Board(bool wall = true) => new(GridType.Square, 50, 0, 0, 1000, 500,
		wall ? Enumerable.Range(0, 10).Select(r => (10, r)).ToHashSet() : new HashSet<(int, int)>());

	[Fact]
	public void In_bright_light_a_wall_hides_what_is_behind_it()
	{
		var (bright, _) = MapVision.Seen(Board(), MapLighting.Bright, new[] { new MapVision.Viewer(2, 5, 1, 0) }, Array.Empty<MapVision.Light>());
		Assert.Contains((8, 5), bright);
		Assert.Contains((10, 5), bright);
		Assert.DoesNotContain((12, 5), bright);
		Assert.DoesNotContain((15, 2), bright);
	}

	[Fact]
	public void In_the_dark_only_a_light_or_darkvision_shows_the_cells()
	{
		var board = Board(wall: false);
		var none = MapVision.Seen(board, MapLighting.Dark, new[] { new MapVision.Viewer(2, 5, 1, 0) }, Array.Empty<MapVision.Light>());
		Assert.Single(none.Bright);
		Assert.Empty(none.Dim);

		//	Darkvision 60 ft: 12 cells, darkness seen as dim light
		var dark = MapVision.Seen(board, MapLighting.Dark, new[] { new MapVision.Viewer(2, 5, 1, 60) }, Array.Empty<MapVision.Light>());
		Assert.Contains((14, 5), dark.Dim);
		Assert.DoesNotContain((15, 5), dark.Dim);

		//	A torch at 15,5: bright 4 cells, dim 4 more, seen from afar
		var torch = MapVision.Seen(board, MapLighting.Dark, new[] { new MapVision.Viewer(2, 5, 1, 0) }, new[] { new MapVision.Light(15, 5, 1, 20, 20) });
		Assert.Contains((15, 5), torch.Bright);
		Assert.Contains((19, 5), torch.Bright);
		Assert.Contains((11, 5), torch.Bright);
		Assert.Contains((10, 5), torch.Dim);
		Assert.DoesNotContain((6, 5), torch.Dim.Concat(torch.Bright));
	}

	[Fact]
	public void A_light_behind_a_wall_lights_nothing_on_this_side()
	{
		var (bright, dim) = MapVision.Seen(Board(), MapLighting.Dark, new[] { new MapVision.Viewer(5, 5, 1, 0) }, new[] { new MapVision.Light(12, 5, 1, 20, 20) });
		Assert.DoesNotContain((9, 5), bright);
		Assert.DoesNotContain((9, 5), dim);
		Assert.DoesNotContain((12, 5), bright);
	}

	[Fact]
	public void A_blinded_creature_sees_only_its_own_space()
	{
		var (bright, dim) = MapVision.Seen(Board(wall: false), MapLighting.Bright, new[] { new MapVision.Viewer(2, 5, 1, 60, Blinded: true) }, Array.Empty<MapVision.Light>());
		Assert.Equal(new[] { (2, 5) }, bright.ToArray());
		Assert.Empty(dim);
	}

	[Fact]
	public void A_creature_is_spotted_when_part_of_its_space_is_seen()
	{
		var bright = new HashSet<(int Col, int Row)> { (4, 4) };
		var dim = new HashSet<(int Col, int Row)>();
		Assert.True(MapVision.Spotted(GridType.Square, 3, 3, 2, bright, dim));
		Assert.False(MapVision.Spotted(GridType.Square, 5, 5, 1, bright, dim));
	}

	[Theory]
	[InlineData("darkvision 60 ft., passive Perception 13", 60)]
	[InlineData("blindsight 30 ft., darkvision 120 ft., passive Perception 18", 120)]
	[InlineData("Percezione passiva 16, scurovisione 27 m", 90)]
	[InlineData("Percezione passiva 11, vista cieca 3 m", 10)]
	[InlineData("Percezione passiva 19", 0)]
	[InlineData(null, 0)]
	public void The_senses_of_a_statblock_give_its_sight_in_the_dark(string? senses, int feet) =>
		Assert.Equal(feet, MapVision.DarkvisionOf(senses));
}
