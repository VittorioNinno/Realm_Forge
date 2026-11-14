using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using RealmForge.Client.Localization;
using RealmForge.Shared.Campaigns;
using RealmForge.Shared.DTOs;

namespace RealmForge.Client.Components
{
	///	<summary>
	///	The terrain of a map: the masters paint walls, difficult terrain and doors on the cells in the map editor (a brush
	///	cell by cell or a box), the fog with the same brush; the players' tokens then go around the walls and the closed
	///	doors (the way shown while dragging, a move with no way refused), difficult terrain costing double.
	///	</summary>
	public partial class CampaignMap
	{
		private MapTerrainDto? terrain;
		private Dictionary<(int Col, int Row), TerrainKind> terrainCells = new();

		//	The editor: the tab of the inspector, the brush (select, walkable, wall, difficult, door, fog), cell by cell or a
		//	box, the colours of the zones over the map, the map as the players see it
		private string editorTab = "zones";
		private string brush = "select";
		private bool brushBox;
		private bool showZones = true;
		private bool previewPlayers;

		//	What the board was last told of the terrain (pushed again when it changes)
		private string? terrainSent;

		private void TakeTerrain(MapTerrainDto? value)
		{
			terrain = value;
			terrainCells = MapTerrain.Read(value?.Cells);
		}

		//	The zones are drawn in the editor, for the masters, unless they look at the map as the players do
		private bool ShowTerrain => !Table && RunsTheTable && showZones && !previewPlayers && terrainCells.Count > 0;

		private bool HidesFromPreview(MapTokenDto t) => previewPlayers && t.Hidden;

		private int ZoneCount(TerrainKind kind) => terrainCells.Count(c => c.Value == kind);

		//	The cells of the closed doors and gates (their tokens): nobody walks through them
		private IEnumerable<(int Col, int Row)> ClosedDoors() => tokens
			.Where(t => t.Kind == TokenKind.Prop && t.PropType is { } type && MapTerrain.Closes(type, t.PropState))
			.SelectMany(t => MapTerrain.Footprint(gridType, t.X, t.Y, t.Size));

		//	Whether this account's moves go around the walls: the players, when the masters asked for it
		private bool FollowsTerrain => !RunsTheTable && terrain is { BlockPlayers: true };

		//	The board learns the walls, the difficult cells and the closed doors for the way it shows while dragging
		private async Task PushTerrainAsync()
		{
			if (string.IsNullOrEmpty(stageElement.Id))
			{
				return;
			}
			object? data = null;
			var closed = ClosedDoors().Select(c => $"{c.Col},{c.Row}").ToList();
			if (FollowsTerrain)
			{
				data = new
				{
					block = true,
					walls = terrainCells.Where(c => c.Value == TerrainKind.Wall).Select(c => $"{c.Key.Col},{c.Key.Row}").ToList(),
					difficult = terrainCells.Where(c => c.Value == TerrainKind.Difficult).Select(c => $"{c.Key.Col},{c.Key.Row}").ToList(),
					closed
				};
			}
			var sent = data is null ? "-" : $"{terrain!.Cells.Count}:{string.Join(";", terrain.Cells.Take(60))}:{string.Join(";", closed)}:{(int)gridType}";
			if (sent == terrainSent)
			{
				return;
			}
			terrainSent = sent;
			try
			{
				await JS.InvokeVoidAsync("rfVtt.terrain", stageElement, data);
			}
			catch (JSException)
			{
				terrainSent = null;
			}
		}

		//	The way of a player's token to a cell, or null when walls and closed doors leave none; the cells it costs
		private int? WayCost(MapTokenDto t, int col, int row)
		{
			if (map is null)
			{
				return null;
			}
			var way = MapTerrain.FindPath(gridType, terrainCells, ClosedDoors().ToHashSet(), (t.X, t.Y), (col, row), t.Size, MapTerrain.MaxPath,
				(c, r) => MapGeometry.Inside(gridType, grid, offsetX, offsetY, c, r, t.Size, map.Width, map.Height));
			return way?.Cost;
		}

		// ===== The editor's brushes =====

		private async Task SetBrushAsync(string name)
		{
			brush = name;
			fogBrush = !brushBox;
			await SetToolAsync(name switch { "select" => "select", "fog" => "fog", _ => "terrain" });
		}

		private Task SelectBrushAsync() => SetBrushAsync("select");

		private void ShowZonesTab() => editorTab = "zones";

		private void ShowGridTab() => editorTab = "grid";

		private void ShowTokensTab() => editorTab = "tokens";

		private Task SetFogCoverAsync(bool cover)
		{
			fogCover = cover;
			return SetBrushAsync("fog");
		}

		private static string ZoneIcon(string name) => name switch
		{
			"walkable" => "check",
			"wall" => "bricks",
			"difficult" => "triangle-half",
			"door" => "door-open",
			_ => "cloud-fog2"
		};

		private async Task SetBrushBoxAsync(bool box)
		{
			brushBox = box;
			fogBrush = !box;
			await SetToolAsync(tool);
		}

		private static TerrainKind? KindOf(string name) => name switch
		{
			"walkable" => TerrainKind.Walkable,
			"wall" => TerrainKind.Wall,
			"difficult" => TerrainKind.Difficult,
			"door" => TerrainKind.Door,
			_ => null
		};

		//	Cells painted with the brush (pairs of column and row): drawn at once, then saved
		[JSInvokable]
		public async Task TerrainPainted(int[] cells)
		{
			if (map is null || !RunsTheTable || KindOf(brush) is not { } kind || cells.Length < 2)
			{
				return;
			}
			var before = terrain;
			TakeTerrain(new MapTerrainDto(MapTerrain.Paint(terrain?.Cells, cells, kind), terrain?.BlockPlayers ?? true));
			StateHasChanged();
			await SaveTerrainAsync(new SaveTerrainDto { Cells = cells.ToList(), Kind = kind, BlockPlayers = terrain?.BlockPlayers ?? true }, before);
		}

		private async Task SaveTerrainAsync(SaveTerrainDto dto, MapTerrainDto? before)
		{
			if (map is null)
			{
				return;
			}
			localEdits++;
			var saved = await Campaigns.SaveTerrainAsync(CampaignId, map.Id, dto);
			localEdits++;
			if (saved is null)
			{
				TakeTerrain(before);
				message = UiText.MapSaveFailed(Lang);
			}
			else
			{
				TakeTerrain(saved);
				message = null;
			}
			StateHasChanged();
		}

		//	Every cell back to plain floor
		private async Task ClearTerrainAsync()
		{
			var before = terrain;
			TakeTerrain(new MapTerrainDto(new List<int>(), terrain?.BlockPlayers ?? true));
			await SaveTerrainAsync(new SaveTerrainDto { Replace = true, BlockPlayers = terrain?.BlockPlayers ?? true }, before);
		}

		//	The edge of the map as a wall: the first and last row and column
		private async Task WallTheEdgeAsync()
		{
			if (map is null)
			{
				return;
			}
			var cells = new List<int>();
			int columns = 0, rows = 0;
			while (columns < 1000 && MapGeometry.Inside(gridType, grid, offsetX, offsetY, columns, 0, 1, map.Width, map.Height))
			{
				columns++;
			}
			while (rows < 1000 && MapGeometry.Inside(gridType, grid, offsetX, offsetY, 0, rows, 1, map.Width, map.Height))
			{
				rows++;
			}
			for (var c = 0; c < columns; c++)
			{
				cells.AddRange(new[] { c, 0, c, rows - 1 });
			}
			for (var r = 0; r < rows; r++)
			{
				cells.AddRange(new[] { 0, r, columns - 1, r });
			}
			if (columns == 0 || rows == 0)
			{
				return;
			}
			var before = terrain;
			TakeTerrain(new MapTerrainDto(MapTerrain.Paint(terrain?.Cells, cells, TerrainKind.Wall), terrain?.BlockPlayers ?? true));
			await SaveTerrainAsync(new SaveTerrainDto { Cells = cells, Kind = TerrainKind.Wall, BlockPlayers = terrain?.BlockPlayers ?? true }, before);
		}

		private async Task SetBlockPlayersAsync(ChangeEventArgs e)
		{
			var block = e.Value is true || (e.Value is string text && bool.TryParse(text, out var parsed) && parsed);
			var before = terrain;
			TakeTerrain(new MapTerrainDto(terrain?.Cells ?? new List<int>(), block));
			await SaveTerrainAsync(new SaveTerrainDto { Cells = terrain!.Cells.ToList(), Replace = true, BlockPlayers = block }, before);
		}

		private string TerrainPoints(int col, int row) =>
			string.Join(' ', MapAreas.Corners(gridType, grid, offsetX, offsetY, col, row).Select(p => $"{N(p.X)},{N(p.Y)}"));
	}
}
