using System.Runtime.CompilerServices;
using RealmForge.Client.Localization;
using RealmForge.Shared.Campaigns;
using RealmForge.Shared.DTOs;
using RealmForge.Shared.Enums;

namespace RealmForge.Client.Components
{
	///	<summary>
	///	Lights and sight at the table: the light of the map and dynamic vision (the masters set them), the lights the
	///	tokens carry and their darkvision. Under dynamic vision a player's screen is dark where their creatures see
	///	nothing, dimmed where they saw before (the creatures there are not sent), shaded where the light is dim.
	///	</summary>
	public partial class CampaignMap
	{
		private MapLighting lighting;
		private bool dynamicVision;
		private HashSet<(int Col, int Row)>? visionBright;
		private HashSet<(int Col, int Row)>? visionDim;

		//	The cells the account's creatures saw on this map (kept while the table is open)
		private readonly HashSet<(int Col, int Row)> explored = new();
		private Guid? exploredMap;

		//	The masters' bar of the light, and the darkvision being written on a token
		private bool lightBar;
		private string darkvisionText = string.Empty;

		private void ApplyVision(MapTableDto table)
		{
			lighting = table.Lighting;
			dynamicVision = table.DynamicVision;
			if (map is not null && exploredMap != map.Id)
			{
				explored.Clear();
				exploredMap = map.Id;
			}
			if (table.Vision is not { } seen)
			{
				visionBright = visionDim = null;
				return;
			}
			visionBright = Pairs(seen.Bright);
			visionDim = Pairs(seen.Dim);
			unseenDoors = Pairs(seen.Blocking ?? new());
			explored.UnionWith(visionBright);
			explored.UnionWith(visionDim);
			sightKey = SightKey();
		}

		//	The closed doors the table does not show this account (they stop the sight all the same), and what the sight
		//	was last worked out from
		private HashSet<(int Col, int Row)> unseenDoors = new();
		private string? sightKey;

		///	<summary>
		///	The sight worked out again here, at once, after a change made on this screen (a move, a door, a wall, a light,
		///	a token added or taken away): the dark follows without waiting for the server, whose answer a moment later
		///	has the last word. Nothing is done when nothing that the sight depends on changed.
		///	</summary>
		private void SeeAgain()
		{
			if (!Table || !dynamicVision || map is null || visionBright is null)
			{
				return;
			}
			var viewers = Viewers();
			//	A creature whose darkvision this account is not told (the characters of the others): the server's answer
			if (viewers.Any(v => v.Darkvision is null))
			{
				return;
			}
			var key = SightKey();
			if (key == sightKey)
			{
				return;
			}
			sightKey = key;
			var blocking = MapVision.Blocking(terrain?.Cells, ClosedDoors());
			blocking.UnionWith(unseenDoors);
			var board = new MapVision.Board(gridType, grid, offsetX, offsetY, map.Width, map.Height, blocking);
			var lights = tokens.Where(t => t.Light is { } l && l.Bright + l.Dim > 0)
				.Select(t => new MapVision.Light(t.X, t.Y, t.Size, t.Light!.Bright, t.Light.Dim)).ToList();
			var looking = viewers.Select(t => new MapVision.Viewer(t.X, t.Y, t.Size, t.Darkvision ?? 0, t.Conditions?.Contains("blinded") == true)).ToList();
			var (bright, dim) = MapVision.Seen(board, lighting, looking, lights);
			visionBright = bright;
			visionDim = dim;
			explored.UnionWith(bright);
			explored.UnionWith(dim);
		}

		//	Who looks, as the server picks them: this account's creatures on the tokens' layer (none: the characters)
		private List<MapTokenDto> Viewers()
		{
			static bool Creature(TokenKind kind) => kind is TokenKind.Character or TokenKind.Npc or TokenKind.Monster;
			var viewers = RunsTheTable ? new List<MapTokenDto>() : tokens.Where(t => t.Controlled && Creature(t.Kind) && t.Layer == TokenLayer.Tokens).ToList();
			return viewers.Count > 0 ? viewers : tokens.Where(t => t.Kind == TokenKind.Character && t.Layer == TokenLayer.Tokens && !t.Hidden).ToList();
		}

		//	Everything the sight depends on, in a line: the viewers, the lights, the closed doors, the walls, the light
		private string SightKey()
		{
			var parts = new System.Text.StringBuilder();
			foreach (var v in Viewers())
			{
				parts.Append($"v{v.X},{v.Y},{v.Size},{v.Darkvision},{v.Conditions?.Contains("blinded") == true};");
			}
			foreach (var t in tokens.Where(t => t.Light is { } l && l.Bright + l.Dim > 0))
			{
				parts.Append($"l{t.X},{t.Y},{t.Size},{t.Light!.Bright},{t.Light.Dim};");
			}
			foreach (var (col, row) in ClosedDoors())
			{
				parts.Append($"d{col},{row};");
			}
			parts.Append($"w{RuntimeHelpers.GetHashCode(terrain)};{lighting};{gridType};{grid};{offsetX};{offsetY}");
			return parts.ToString();
		}

		private static HashSet<(int Col, int Row)> Pairs(List<int> cells)
		{
			var set = new HashSet<(int, int)>();
			for (var i = 0; i + 1 < cells.Count; i += 2)
			{
				set.Add((cells[i], cells[i + 1]));
			}
			return set;
		}

		//	The dark drawn over the map: on a player's table under dynamic vision, on the masters' when they look as the
		//	players do
		private bool VisionShown => Table && dynamicVision && visionBright is not null && (!RunsTheTable || previewPlayers);

		//	A creature the characters do not see, left out of the masters' preview as the players' screens leave it out
		private bool OutOfSight(MapTokenDto t) =>
			VisionShown && RunsTheTable && t.Kind is TokenKind.Character or TokenKind.Npc or TokenKind.Monster && t.CharacterId is null && t.ControlledBy is not { Count: > 0 }
			&& !MapVision.Spotted(gridType, t.X, t.Y, t.Size, visionBright!, visionDim!);

		private async Task SaveLightingAsync(MapLighting value, bool dynamic)
		{
			if (map is null)
			{
				return;
			}
			lighting = value;
			dynamicVision = dynamic;
			busy = true;
			localEdits++;
			var result = await Campaigns.SaveLightingAsync(CampaignId, map.Id, new SaveLightingDto { Lighting = value, DynamicVision = dynamic });
			busy = false;
			if (!result.Ok)
			{
				castNote = UiText.MapSaveFailed(Lang);
			}
			await RefreshAsync();
		}

		//	The light chosen among the usual ones (none puts it out)
		private Task SaveTokenLightAsync(MapTokenDto t, string preset)
		{
			var found = TokenLight.Presets.FirstOrDefault(p => p.Key == preset);
			var (bright, dim) = found.Key is null ? (0, 0) : (found.Bright, found.Dim);
			return SaveTokenVisionAsync(t, new SaveTokenVisionDto { Name = bright + dim == 0 ? string.Empty : UiText.VttLightPreset(preset, Lang), Bright = bright, Dim = dim });
		}

		//	The darkvision written (metres in Italian, feet in English); empty goes back to the sheet's
		private Task SaveDarkvisionAsync(MapTokenDto t)
		{
			var text = darkvisionText.Trim().Replace(',', '.');
			int feet = -1;
			if (text.Length > 0)
			{
				if (!double.TryParse(text, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out var typed) || typed < 0)
				{
					castNote = UiText.MapSaveFailed(Lang);
					return Task.CompletedTask;
				}
				feet = Math.Clamp((int)Math.Round(Lang == LanguageCode.It ? typed / 0.3 : typed), 0, 300);
			}
			darkvisionText = string.Empty;
			return SaveTokenVisionAsync(t, new SaveTokenVisionDto { Darkvision = feet });
		}

		private async Task SaveTokenVisionAsync(MapTokenDto t, SaveTokenVisionDto dto)
		{
			if (map is null)
			{
				return;
			}
			busy = true;
			localEdits++;
			var result = await Campaigns.SaveTokenVisionAsync(CampaignId, map.Id, t.Id, dto);
			busy = false;
			castNote = result.Ok ? null : UiText.MapSaveFailed(Lang);
			await RefreshAsync();
		}

		//	The shape of a cell for the masks of the dark
		private string CellPoints(int col, int row) => TerrainPoints(col, row);
	}
}
