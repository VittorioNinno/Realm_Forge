using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealmForge.Api.Security;
using RealmForge.Domain.Entities;
using RealmForge.Infrastructure.Persistence;
using RealmForge.Shared.Campaigns;
using RealmForge.Shared.DTOs;
using RealmForge.Shared.Enums;

namespace RealmForge.Api.Controllers
{
	///	<summary>
	///	The virtual tabletop of a campaign: maps with a grid and tokens. Masters and co-masters prepare the maps, show them
	///	to the table and move every token; a player sees the maps shown and moves the tokens of their own characters. The
	///	table polls the tokens (without the picture) every few seconds. Non-members get 404, like the campaign itself.
	///	</summary>
	[ApiController]
	[Route("api/campaigns/{campaignId:guid}/maps")]
	[Authorize]
	public class MapsController : ControllerBase
	{
		private readonly RealmForgeDbContext _context;

		public MapsController(RealmForgeDbContext context)
		{
			_context = context;
		}

		private string UserId => ContentAccess.GetUserId(User) ?? string.Empty;

		//	GET: api/campaigns/{campaignId}/maps — the masters see every map, the players the ones shown
		[HttpGet]
		public async Task<ActionResult<List<CampaignMapSummaryDto>>> GetMaps(Guid campaignId)
		{
			if (await CampaignAccess.RoleAsync(_context, campaignId, UserId) is not { } role)
			{
				return NotFound();
			}
			var runs = CampaignRules.RunsTheTable(role);
			var maps = await _context.CampaignMaps.AsNoTracking()
				.Where(m => m.CampaignId == campaignId && (runs || m.Shown))
				.OrderBy(m => m.CreatedAt)
				.Select(m => new CampaignMapSummaryDto(m.Id, m.Name, m.Shown, m.Width, m.Height, m.UpdatedAt))
				.ToListAsync();
			return Ok(maps);
		}

		//	GET: api/campaigns/{campaignId}/maps/{mapId} — with the picture
		[HttpGet("{mapId:guid}")]
		public async Task<ActionResult<CampaignMapDto>> GetMap(Guid campaignId, Guid mapId)
		{
			var (map, role) = await LoadAsync(campaignId, mapId, withTokens: true);
			if (map is null || role is null)
			{
				return NotFound();
			}
			var fight = await FightAsync(map);
			var tokens = await TokensAsync(map, role.Value, fight);
			return Ok(new CampaignMapDto(map.Id, map.Name, map.Image, map.Width, map.Height, map.GridSize, map.GridOffsetX, map.GridOffsetY,
				map.Shown, CampaignRules.RunsTheTable(role.Value), Latest(map, fight), tokens, map.GridType, ShapesOf(map, role.Value), TableOf(map, role.Value),
				CombatOf(map, fight, role.Value)));
		}

		//	GET: api/campaigns/{campaignId}/maps/{mapId}/state — what the table polls: the grid and the tokens
		//	With after: the answer waits (up to 20 seconds) for something to change after that moment, so that the table
		//	sees a move as soon as it happens instead of at the next poll
		[HttpGet("{mapId:guid}/state")]
		public async Task<ActionResult<MapStateDto>> GetState(Guid campaignId, Guid mapId, [FromQuery] DateTimeOffset? after)
		{
			if (after is { } since)
			{
				await WaitForChangeAsync(campaignId, mapId, since, HttpContext.RequestAborted);
			}
			var (map, role) = await LoadAsync(campaignId, mapId, withTokens: true);
			if (map is null || role is null)
			{
				return NotFound();
			}
			var fight = await FightAsync(map);
			return Ok(new MapStateDto(map.Id, map.Name, map.GridSize, map.GridOffsetX, map.GridOffsetY, map.Shown, Latest(map, fight),
				await TokensAsync(map, role.Value, fight), map.GridType, ShapesOf(map, role.Value), TableOf(map, role.Value), CombatOf(map, fight, role.Value)));
		}

		//	POST: api/campaigns/{campaignId}/maps — masters and co-masters
		[HttpPost]
		public async Task<ActionResult<CampaignMapSummaryDto>> CreateMap(Guid campaignId, [FromBody] SaveMapDto dto)
		{
			if (await CampaignAccess.RoleAsync(_context, campaignId, UserId) is not { } role)
			{
				return NotFound();
			}
			if (!CampaignRules.RunsTheTable(role))
			{
				return Forbid();
			}
			if (Validate(dto, requireImage: true) is { } error)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: error);
			}
			if (await _context.CampaignMaps.CountAsync(m => m.CampaignId == campaignId) >= MapRules.MaxMaps)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: $"At most {MapRules.MaxMaps} maps per campaign.");
			}
			var map = new CampaignMap { CampaignId = campaignId };
			Apply(map, dto);
			_context.CampaignMaps.Add(map);
			await _context.SaveChangesAsync();
			return Ok(new CampaignMapSummaryDto(map.Id, map.Name, map.Shown, map.Width, map.Height, map.UpdatedAt));
		}

		//	PUT: api/campaigns/{campaignId}/maps/{mapId} — name, grid, shown to the table, a new picture
		[HttpPut("{mapId:guid}")]
		public async Task<IActionResult> UpdateMap(Guid campaignId, Guid mapId, [FromBody] SaveMapDto dto)
		{
			var (map, role) = await LoadAsync(campaignId, mapId, withTokens: false);
			if (map is null || role is null)
			{
				return NotFound();
			}
			if (!CampaignRules.RunsTheTable(role.Value))
			{
				return Forbid();
			}
			if (Validate(dto, requireImage: false) is { } error)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: error);
			}
			Apply(map, dto);
			await _context.SaveChangesAsync();
			return NoContent();
		}

		//	POST: api/campaigns/{campaignId}/maps/{mapId}/duplicate — a copy with its tokens, put away from the players
		[HttpPost("{mapId:guid}/duplicate")]
		public async Task<ActionResult<CampaignMapSummaryDto>> DuplicateMap(Guid campaignId, Guid mapId, [FromQuery] string? name)
		{
			var (map, role) = await LoadAsync(campaignId, mapId, withTokens: true);
			if (map is null || role is null)
			{
				return NotFound();
			}
			if (!CampaignRules.RunsTheTable(role.Value))
			{
				return Forbid();
			}
			if (await _context.CampaignMaps.CountAsync(m => m.CampaignId == campaignId) >= MapRules.MaxMaps)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: $"At most {MapRules.MaxMaps} maps per campaign.");
			}
			var title = string.IsNullOrWhiteSpace(name) ? $"{map.Name} (2)" : name.Trim();
			var copy = new CampaignMap
			{
				CampaignId = campaignId,
				Name = title.Length > 120 ? title[..120] : title,
				Image = map.Image,
				Width = map.Width,
				Height = map.Height,
				GridType = map.GridType,
				GridSize = map.GridSize,
				GridOffsetX = map.GridOffsetX,
				GridOffsetY = map.GridOffsetY,
				Shown = false,
				FogEnabled = map.FogEnabled,
				Fog = map.Fog.ToList()
			};
			foreach (var t in map.Tokens)
			{
				copy.Tokens.Add(new CampaignToken
				{
					Label = t.Label, Color = t.Color, Kind = t.Kind, CharacterId = t.CharacterId, MonsterId = t.MonsterId,
					X = t.X, Y = t.Y, Size = t.Size, Hidden = t.Hidden, Layer = t.Layer,
					ControlledBy = t.ControlledBy.ToList(), Hp = t.Hp, MaxHp = t.MaxHp, Conditions = t.Conditions.ToList(),
					PropType = t.PropType, PropState = t.PropState, PlayersInteract = t.PlayersInteract, ImageId = t.ImageId
				});
			}
			foreach (var shape in map.Shapes)
			{
				copy.Shapes.Add(new CampaignMapShape
				{
					OwnerId = shape.OwnerId, Kind = shape.Kind, Points = shape.Points.ToList(), Color = shape.Color, Text = shape.Text,
					Size = shape.Size, MasterOnly = shape.MasterOnly
				});
			}
			_context.CampaignMaps.Add(copy);
			await _context.SaveChangesAsync();
			return Ok(new CampaignMapSummaryDto(copy.Id, copy.Name, copy.Shown, copy.Width, copy.Height, copy.UpdatedAt));
		}

		//	POST: api/campaigns/{campaignId}/maps/{mapId}/display — the map on the players' table; the others are put away
		[HttpPost("{mapId:guid}/display")]
		public async Task<IActionResult> DisplayMap(Guid campaignId, Guid mapId)
		{
			var (map, role) = await LoadAsync(campaignId, mapId, withTokens: false);
			if (map is null || role is null)
			{
				return NotFound();
			}
			if (!CampaignRules.RunsTheTable(role.Value))
			{
				return Forbid();
			}
			var now = DateTimeOffset.UtcNow;
			foreach (var other in await _context.CampaignMaps.Where(m => m.CampaignId == campaignId && m.Id != mapId && m.Shown).ToListAsync())
			{
				other.Shown = false;
				other.UpdatedAt = now;
			}
			map.Shown = true;
			map.UpdatedAt = now;
			await _context.SaveChangesAsync();
			return NoContent();
		}

		//	DELETE: api/campaigns/{campaignId}/maps/{mapId}/display — the map taken off the players' table
		[HttpDelete("{mapId:guid}/display")]
		public async Task<IActionResult> HideMap(Guid campaignId, Guid mapId)
		{
			var (map, role) = await LoadAsync(campaignId, mapId, withTokens: false);
			if (map is null || role is null)
			{
				return NotFound();
			}
			if (!CampaignRules.RunsTheTable(role.Value))
			{
				return Forbid();
			}
			map.Shown = false;
			map.UpdatedAt = DateTimeOffset.UtcNow;
			await _context.SaveChangesAsync();
			return NoContent();
		}

		//	DELETE: api/campaigns/{campaignId}/maps/{mapId}
		[HttpDelete("{mapId:guid}")]
		public async Task<IActionResult> DeleteMap(Guid campaignId, Guid mapId)
		{
			var (map, role) = await LoadAsync(campaignId, mapId, withTokens: false);
			if (map is null || role is null)
			{
				return NotFound();
			}
			if (!CampaignRules.RunsTheTable(role.Value))
			{
				return Forbid();
			}
			_context.CampaignMaps.Remove(map);
			await _context.SaveChangesAsync();
			return NoContent();
		}

		//	POST: api/campaigns/{campaignId}/maps/{mapId}/tokens — masters and co-masters
		[HttpPost("{mapId:guid}/tokens")]
		public async Task<ActionResult<MapTokenDto>> AddToken(Guid campaignId, Guid mapId, [FromBody] SaveTokenDto dto)
		{
			var (map, role) = await LoadAsync(campaignId, mapId, withTokens: true);
			if (map is null || role is null)
			{
				return NotFound();
			}
			if (!CampaignRules.RunsTheTable(role.Value))
			{
				return Forbid();
			}
			if (map.Tokens.Count >= MapRules.MaxTokens)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: $"At most {MapRules.MaxTokens} tokens per map.");
			}
			if (await ValidateTokenAsync(campaignId, map, dto) is { } error)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: error);
			}
			var token = new CampaignToken { MapId = map.Id };
			await ApplyAsync(campaignId, token, dto);
			_context.CampaignTokens.Add(token);
			map.UpdatedAt = DateTimeOffset.UtcNow;
			await _context.SaveChangesAsync();
			return Ok(ToDto(token, true));
		}

		//	PUT: api/campaigns/{campaignId}/maps/{mapId}/tokens/{tokenId} — masters and co-masters
		[HttpPut("{mapId:guid}/tokens/{tokenId:guid}")]
		public async Task<IActionResult> UpdateToken(Guid campaignId, Guid mapId, Guid tokenId, [FromBody] SaveTokenDto dto)
		{
			var (map, role) = await LoadAsync(campaignId, mapId, withTokens: true);
			var token = map?.Tokens.FirstOrDefault(t => t.Id == tokenId);
			if (map is null || role is null || token is null)
			{
				return NotFound();
			}
			if (!CampaignRules.RunsTheTable(role.Value))
			{
				//	Whoever controls a token chooses the colour of its ring, nothing else
				if (!await ControlsAsync(token))
				{
					return Forbid();
				}
				if (dto.Color is not { } ring || !System.Text.RegularExpressions.Regex.IsMatch(ring, "^#[0-9a-fA-F]{6}$"))
				{
					return Problem(statusCode: StatusCodes.Status400BadRequest, title: "Choose a colour.");
				}
				token.Color = ring.ToLowerInvariant();
				token.UpdatedAt = map.UpdatedAt = DateTimeOffset.UtcNow;
				await _context.SaveChangesAsync();
				return NoContent();
			}
			if (await ValidateTokenAsync(campaignId, map, dto) is { } error)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: error);
			}
			await ApplyAsync(campaignId, token, dto);
			map.UpdatedAt = DateTimeOffset.UtcNow;
			await _context.SaveChangesAsync();
			return NoContent();
		}

		//	POST: api/campaigns/{campaignId}/maps/{mapId}/tokens/{tokenId}/interact — a player opens or closes an object the
		//	masters let them use (a locked or barred one stays as it is: 409); a master toggles any
		[HttpPost("{mapId:guid}/tokens/{tokenId:guid}/interact")]
		public async Task<ActionResult<MapTokenDto>> Interact(Guid campaignId, Guid mapId, Guid tokenId)
		{
			var (map, role) = await LoadAsync(campaignId, mapId, withTokens: true);
			var token = map?.Tokens.FirstOrDefault(t => t.Id == tokenId);
			var runs = role is { } r && CampaignRules.RunsTheTable(r);
			if (map is null || role is null || token is null || token.Kind != TokenKind.Prop || (!runs && token.Hidden))
			{
				return NotFound();
			}
			if (!runs && (!token.PlayersInteract || !map.Shown || (map.FogEnabled && UnderFog(map, token))))
			{
				return Forbid();
			}
			if (PropRules.Toggle(token.PropState) is not { } next)
			{
				return Problem(statusCode: StatusCodes.Status409Conflict, title: "It does not move.", detail: token.PropState.ToString());
			}
			token.PropState = next;
			token.UpdatedAt = map.UpdatedAt = DateTimeOffset.UtcNow;
			await _context.SaveChangesAsync();
			return Ok(ToDto(token, runs));
		}

		//	POST: api/campaigns/{campaignId}/maps/{mapId}/tokens/{tokenId}/move — a master any token, a player their own
		[HttpPost("{mapId:guid}/tokens/{tokenId:guid}/move")]
		public async Task<IActionResult> MoveToken(Guid campaignId, Guid mapId, Guid tokenId, [FromBody] MoveTokenDto dto)
		{
			var (map, role) = await LoadAsync(campaignId, mapId, withTokens: true);
			var token = map?.Tokens.FirstOrDefault(t => t.Id == tokenId);
			if (map is null || role is null || token is null || (!CampaignRules.RunsTheTable(role.Value) && token.Hidden))
			{
				return NotFound();
			}
			if (!MapRules.CanMove(role.Value, await ControlsAsync(token), map.Shown, token.Hidden))
			{
				return Forbid();
			}
			if (!OnMap(map, dto.X, dto.Y, token.Size))
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "The token would leave the map.");
			}
			token.X = dto.X;
			token.Y = dto.Y;
			token.UpdatedAt = map.UpdatedAt = DateTimeOffset.UtcNow;
			await _context.SaveChangesAsync();
			return NoContent();
		}

		//	DELETE: api/campaigns/{campaignId}/maps/{mapId}/tokens/{tokenId}
		[HttpDelete("{mapId:guid}/tokens/{tokenId:guid}")]
		public async Task<IActionResult> DeleteToken(Guid campaignId, Guid mapId, Guid tokenId)
		{
			var (map, role) = await LoadAsync(campaignId, mapId, withTokens: true);
			var token = map?.Tokens.FirstOrDefault(t => t.Id == tokenId);
			if (map is null || role is null || token is null)
			{
				return NotFound();
			}
			if (!CampaignRules.RunsTheTable(role.Value))
			{
				return Forbid();
			}
			_context.CampaignTokens.Remove(token);
			map.UpdatedAt = DateTimeOffset.UtcNow;
			await _context.SaveChangesAsync();
			return NoContent();
		}

		// ===== Drawings, texts, notes, areas =====

		//	POST: api/campaigns/{campaignId}/maps/{mapId}/shapes — everyone at the table draws for themselves (MapRules.IsPrivate);
		//	the areas of spells, and the masters' texts they share, are for the whole table
		[HttpPost("{mapId:guid}/shapes")]
		public async Task<ActionResult<MapShapeDto>> AddShape(Guid campaignId, Guid mapId, [FromBody] SaveShapeDto dto)
		{
			var (map, role) = await LoadAsync(campaignId, mapId, withTokens: true);
			if (map is null || role is null)
			{
				return NotFound();
			}
			var runs = CampaignRules.RunsTheTable(role.Value);
			var needed = dto.Kind switch
			{
				ShapeKind.Freehand => 4,
				ShapeKind.Text => 2,
				_ => 4
			};
			if (!Enum.IsDefined(dto.Kind) || dto.Points.Count < needed || dto.Points.Count > MapRules.MaxShapePoints || dto.Points.Count % 2 == 1
				|| dto.Points.Any(v => double.IsNaN(v) || double.IsInfinity(v) || v < -map.Width - map.Height || v > 2 * (map.Width + map.Height))
				|| (dto.Kind == ShapeKind.Text && (string.IsNullOrWhiteSpace(dto.Text) || dto.Text.Trim().Length > MapRules.MaxShapeText))
				|| (MapRules.IsArea(dto.Kind) && dto.Size is < 1 or > MapRules.MaxAreaSize)
				|| (dto.Color is { } color && !System.Text.RegularExpressions.Regex.IsMatch(color, "^#[0-9a-fA-F]{6}$")))
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "Kind, points, text, size or colour out of range.");
			}
			if (map.Shapes.Count >= MapRules.MaxShapes)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: $"At most {MapRules.MaxShapes} drawings per map.");
			}
			var colors = await CampaignAccess.EnsureColorsAsync(_context, campaignId);
			var shape = new CampaignMapShape
			{
				MapId = map.Id,
				OwnerId = UserId,
				Kind = dto.Kind,
				Points = dto.Points.Select(v => Math.Round(v, 1)).ToList(),
				Color = dto.Color ?? (runs ? PlayerColors.Master : colors.TryGetValue(UserId, out var mine) ? mine : PlayerColors.Master),
				Text = dto.Kind == ShapeKind.Text ? dto.Text!.Trim() : null,
				Size = MapRules.IsArea(dto.Kind) ? dto.Size : 0,
				MasterOnly = MapRules.IsPrivate(dto.Kind, runs, dto.Shared)
			};
			_context.CampaignMapShapes.Add(shape);
			map.UpdatedAt = DateTimeOffset.UtcNow;
			await _context.SaveChangesAsync();
			return Ok(ShapeDto(shape, runs));
		}

		//	PUT: api/campaigns/{campaignId}/maps/{mapId}/shapes/{shapeId}/move — a text somewhere else: its author, or a master
		//	for a text the table sees
		[HttpPut("{mapId:guid}/shapes/{shapeId:guid}/move")]
		public async Task<ActionResult<MapShapeDto>> MoveShape(Guid campaignId, Guid mapId, Guid shapeId, [FromBody] MoveShapeDto dto)
		{
			var (map, role) = await LoadAsync(campaignId, mapId, withTokens: true);
			var shape = map?.Shapes.FirstOrDefault(s => s.Id == shapeId);
			if (map is null || role is null || shape is null || !MapRules.Sees(shape.Kind, shape.MasterOnly, shape.OwnerId == UserId))
			{
				return NotFound();
			}
			var runs = CampaignRules.RunsTheTable(role.Value);
			if (!MapRules.CanMoveShape(shape.Kind, shape.MasterOnly, shape.OwnerId == UserId, runs))
			{
				return Forbid();
			}
			if (dto.Points.Count != 2 || dto.Points.Any(v => double.IsNaN(v) || double.IsInfinity(v))
				|| dto.Points[0] < 0 || dto.Points[1] < 0 || dto.Points[0] > map.Width || dto.Points[1] > map.Height)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "The text must stay on the map.");
			}
			shape.Points = dto.Points.Select(v => Math.Round(v, 1)).ToList();
			map.UpdatedAt = DateTimeOffset.UtcNow;
			await _context.SaveChangesAsync();
			return Ok(ShapeDto(shape, runs));
		}

		//	DELETE: api/campaigns/{campaignId}/maps/{mapId}/shapes/{shapeId} — its author, or a master for what the table sees
		[HttpDelete("{mapId:guid}/shapes/{shapeId:guid}")]
		public async Task<IActionResult> DeleteShape(Guid campaignId, Guid mapId, Guid shapeId)
		{
			var (map, role) = await LoadAsync(campaignId, mapId, withTokens: true);
			var shape = map?.Shapes.FirstOrDefault(s => s.Id == shapeId);
			if (map is null || role is null || shape is null || !MapRules.Sees(shape.Kind, shape.MasterOnly, shape.OwnerId == UserId))
			{
				return NotFound();
			}
			if (!MapRules.CanDeleteShape(shape.Kind, shape.MasterOnly, shape.OwnerId == UserId, CampaignRules.RunsTheTable(role.Value)))
			{
				return Forbid();
			}
			_context.CampaignMapShapes.Remove(shape);
			map.UpdatedAt = DateTimeOffset.UtcNow;
			await _context.SaveChangesAsync();
			return NoContent();
		}

		//	DELETE: api/campaigns/{campaignId}/maps/{mapId}/shapes — clears the drawings, texts and areas: a player their own, a
		//	master also everything the table sees (never what the others keep for themselves)
		[HttpDelete("{mapId:guid}/shapes")]
		public async Task<IActionResult> ClearShapes(Guid campaignId, Guid mapId)
		{
			var (map, role) = await LoadAsync(campaignId, mapId, withTokens: true);
			if (map is null || role is null)
			{
				return NotFound();
			}
			var runs = CampaignRules.RunsTheTable(role.Value);
			var gone = map.Shapes.Where(s => MapRules.Sees(s.Kind, s.MasterOnly, s.OwnerId == UserId)
				&& MapRules.CanDeleteShape(s.Kind, s.MasterOnly, s.OwnerId == UserId, runs)).ToList();
			_context.CampaignMapShapes.RemoveRange(gone);
			map.UpdatedAt = DateTimeOffset.UtcNow;
			await _context.SaveChangesAsync();
			return NoContent();
		}

		//	POST: api/campaigns/{campaignId}/maps/{mapId}/shapes/erase — the drawings, texts and areas in a box that the
		//	account may remove (the same as one by one)
		[HttpPost("{mapId:guid}/shapes/erase")]
		public async Task<ActionResult<int>> EraseArea(Guid campaignId, Guid mapId, [FromBody] EraseAreaDto dto)
		{
			var (map, role) = await LoadAsync(campaignId, mapId, withTokens: true);
			if (map is null || role is null)
			{
				return NotFound();
			}
			if (new[] { dto.X, dto.Y, dto.Width, dto.Height }.Any(v => double.IsNaN(v) || double.IsInfinity(v)) || dto.Width <= 0 || dto.Height <= 0)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "Draw a box on the map.");
			}
			var runs = CampaignRules.RunsTheTable(role.Value);
			var gone = map.Shapes.Where(s => MapRules.Sees(s.Kind, s.MasterOnly, s.OwnerId == UserId)
				&& MapRules.CanDeleteShape(s.Kind, s.MasterOnly, s.OwnerId == UserId, runs)
				&& MapRules.Touches(s.Points, dto.X, dto.Y, dto.Width, dto.Height)).ToList();
			if (gone.Count > 0)
			{
				_context.CampaignMapShapes.RemoveRange(gone);
				map.UpdatedAt = DateTimeOffset.UtcNow;
				await _context.SaveChangesAsync();
			}
			return Ok(gone.Count);
		}

		// ===== Fog of war, pings, the view =====

		//	PUT: api/campaigns/{campaignId}/maps/{mapId}/fog — masters and co-masters
		[HttpPut("{mapId:guid}/fog")]
		public async Task<IActionResult> SaveFog(Guid campaignId, Guid mapId, [FromBody] SaveFogDto dto)
		{
			var (map, role) = await LoadAsync(campaignId, mapId, withTokens: false);
			if (map is null || role is null)
			{
				return NotFound();
			}
			if (!CampaignRules.RunsTheTable(role.Value))
			{
				return Forbid();
			}
			if (!MapFog.Valid(dto.Fog))
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "Fog steps out of range.");
			}
			map.FogEnabled = dto.Enabled;
			map.Fog = dto.Fog.Select(v => Math.Round(v, 1)).ToList();
			map.UpdatedAt = DateTimeOffset.UtcNow;
			await _context.SaveChangesAsync();
			return NoContent();
		}

		//	POST: api/campaigns/{campaignId}/maps/{mapId}/ping — anyone at the table points at something
		[HttpPost("{mapId:guid}/ping")]
		public async Task<IActionResult> Ping(Guid campaignId, Guid mapId, [FromBody] MapPointDto dto)
		{
			var (map, role) = await LoadAsync(campaignId, mapId, withTokens: false);
			if (map is null || role is null)
			{
				return NotFound();
			}
			if (dto.X < 0 || dto.Y < 0 || dto.X > map.Width || dto.Y > map.Height)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "The point is outside the map.");
			}
			var colors = await CampaignAccess.EnsureColorsAsync(_context, campaignId);
			map.PingX = Math.Round(dto.X, 1);
			map.PingY = Math.Round(dto.Y, 1);
			map.PingColor = CampaignRules.RunsTheTable(role.Value) ? PlayerColors.Master : colors.TryGetValue(UserId, out var mine) ? mine : PlayerColors.Master;
			map.PingAt = map.UpdatedAt = DateTimeOffset.UtcNow;
			await _context.SaveChangesAsync();
			return NoContent();
		}

		//	POST: api/campaigns/{campaignId}/maps/{mapId}/focus — the masters bring every player's view to a point
		[HttpPost("{mapId:guid}/focus")]
		public async Task<IActionResult> Focus(Guid campaignId, Guid mapId, [FromBody] MapPointDto dto)
		{
			var (map, role) = await LoadAsync(campaignId, mapId, withTokens: false);
			if (map is null || role is null)
			{
				return NotFound();
			}
			if (!CampaignRules.RunsTheTable(role.Value))
			{
				return Forbid();
			}
			if (dto.X < 0 || dto.Y < 0 || dto.X > map.Width || dto.Y > map.Height || dto.Zoom is < 0.1 or > 3)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "The point is outside the map.");
			}
			map.FocusX = Math.Round(dto.X, 1);
			map.FocusY = Math.Round(dto.Y, 1);
			map.FocusZoom = Math.Round(dto.Zoom, 2);
			map.FocusAt = map.UpdatedAt = DateTimeOffset.UtcNow;
			await _context.SaveChangesAsync();
			return NoContent();
		}

		// ===== Combat =====

		//	POST: api/campaigns/{campaignId}/maps/{mapId}/combat — an encounter starts on the map: shown to the players, the
		//	initiative rolled for whoever has none, a token for every combatant without one (the characters' tokens are
		//	reused)
		[HttpPost("{mapId:guid}/combat")]
		public async Task<IActionResult> StartCombat(Guid campaignId, Guid mapId, [FromBody] StartCombatDto dto)
		{
			var (map, role) = await LoadAsync(campaignId, mapId, withTokens: true);
			if (map is null || role is null)
			{
				return NotFound();
			}
			if (!CampaignRules.RunsTheTable(role.Value))
			{
				return Forbid();
			}
			var encounter = await _context.CampaignEncounters.FirstOrDefaultAsync(e => e.Id == dto.EncounterId && e.CampaignId == campaignId);
			if (encounter is null)
			{
				return NotFound();
			}
			var combatants = EncountersController.Read(encounter.Combatants);
			foreach (var c in combatants.Where(c => c.Initiative is null))
			{
				c.Initiative = Random.Shared.Next(1, 21) + c.InitiativeBonus;
			}
			var monsterIds = combatants.Where(c => c.MonsterId is not null).Select(c => c.MonsterId!.Value).Distinct().ToList();
			var sizes = await _context.Monsters.AsNoTracking().Where(m => monsterIds.Contains(m.Id)).ToDictionaryAsync(m => m.Id, m => new { m.Size, m.IsNpc });
			var colors = await CampaignAccess.EnsureColorsAsync(_context, campaignId);
			foreach (var c in combatants)
			{
				var token = map.Tokens.FirstOrDefault(t => t.CombatantId == c.Id)
					?? (c.CharacterId is { } characterId ? map.Tokens.FirstOrDefault(t => t.CharacterId == characterId) : null);
				if (token is not null)
				{
					token.CombatantId = c.Id;
					continue;
				}
				var info = c.MonsterId is { } monsterId && sizes.TryGetValue(monsterId, out var found) ? found : null;
				var size = info?.Size switch { CreatureSize.Large => 2, CreatureSize.Huge => 3, CreatureSize.Gargantuan => 4, _ => 1 };
				var (x, y) = MapGeometry.FreeCell(map.GridType, map.GridSize, map.GridOffsetX, map.GridOffsetY, size, map.Width, map.Height,
					map.Tokens.Select(t => (t.X, t.Y, t.Size)));
				var owner = c.CharacterId is { } ownedId
					? await _context.Characters.AsNoTracking().Where(ch => ch.Id == ownedId).Select(ch => ch.OwnerId).FirstOrDefaultAsync()
					: null;
				//	Added to the context: a new token with its id already set would otherwise be taken for an existing one
				var added = new CampaignToken
				{
					MapId = map.Id,
					Label = c.Name.Length > 100 ? c.Name[..100] : c.Name,
					Kind = c.Kind switch
					{
						CombatantKind.Character => TokenKind.Character,
						CombatantKind.Monster => info?.IsNpc == true ? TokenKind.Npc : TokenKind.Monster,
						_ => TokenKind.Marker
					},
					CharacterId = c.CharacterId,
					MonsterId = c.MonsterId,
					CombatantId = c.Id,
					Color = c.Kind == CombatantKind.Character
						? owner is not null && colors.TryGetValue(owner, out var color) ? color : PlayerColors.Master
						: info?.IsNpc == true ? "#ab47bc" : c.Kind == CombatantKind.Monster ? "#dc3545" : "#9e9e9e",
					X = x,
					Y = y,
					Size = size,
					Hidden = c.Hidden
				};
				_context.CampaignTokens.Add(added);
				map.Tokens.Add(added);
			}
			var order = EncounterRules.Order(combatants);
			encounter.Status = EncounterStatus.Running;
			encounter.Shown = true;
			encounter.Round = Math.Max(1, encounter.Round);
			encounter.CurrentId = encounter.CurrentId is { } current && combatants.Any(c => c.Id == current) ? current : order.FirstOrDefault()?.Id;
			encounter.Combatants = System.Text.Json.JsonSerializer.Serialize(combatants, new System.Text.Json.JsonSerializerOptions(System.Text.Json.JsonSerializerDefaults.Web));
			encounter.Version++;
			encounter.UpdatedAt = DateTimeOffset.UtcNow;
			map.EncounterId = encounter.Id;
			map.UpdatedAt = DateTimeOffset.UtcNow;
			await _context.SaveChangesAsync();
			return NoContent();
		}

		//	POST: api/campaigns/{campaignId}/maps/{mapId}/combat/quick — a fight with tokens on the map, without a prepared
		//	encounter: an encounter is made for it, the initiative of the monsters is rolled, the players roll their own
		[HttpPost("{mapId:guid}/combat/quick")]
		public async Task<IActionResult> QuickCombat(Guid campaignId, Guid mapId, [FromBody] QuickCombatDto dto)
		{
			var (map, role) = await LoadAsync(campaignId, mapId, withTokens: true);
			if (map is null || role is null)
			{
				return NotFound();
			}
			if (!CampaignRules.RunsTheTable(role.Value))
			{
				return Forbid();
			}
			var chosen = map.Tokens.Where(t => dto.TokenIds.Contains(t.Id)).ToList();
			if (chosen.Count == 0 || await FightAsync(map) is not null)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "Choose tokens of this map, with no fight already under way.");
			}
			var combatants = new List<EncounterCombatant>();
			foreach (var token in chosen)
			{
				combatants.Add(await CombatantOfAsync(token));
			}
			var encounter = new CampaignEncounter
			{
				CampaignId = campaignId,
				Name = map.Name.Length > 100 ? map.Name[..100] : map.Name,
				Status = EncounterStatus.Running,
				Shown = true,
				Round = 1,
				CreatedById = UserId
			};
			encounter.CurrentId = EncounterRules.Order(combatants).FirstOrDefault()?.Id;
			encounter.Combatants = System.Text.Json.JsonSerializer.Serialize(combatants, new System.Text.Json.JsonSerializerOptions(System.Text.Json.JsonSerializerDefaults.Web));
			_context.CampaignEncounters.Add(encounter);
			map.EncounterId = encounter.Id;
			map.UpdatedAt = DateTimeOffset.UtcNow;
			await _context.SaveChangesAsync();
			return NoContent();
		}

		//	POST: api/campaigns/{campaignId}/maps/{mapId}/combat/tokens/{tokenId} — a token joins the fight
		[HttpPost("{mapId:guid}/combat/tokens/{tokenId:guid}")]
		public async Task<IActionResult> JoinFight(Guid campaignId, Guid mapId, Guid tokenId)
		{
			var (map, role) = await LoadAsync(campaignId, mapId, withTokens: true);
			var token = map?.Tokens.FirstOrDefault(t => t.Id == tokenId);
			if (map is null || role is null || token is null)
			{
				return NotFound();
			}
			if (!CampaignRules.RunsTheTable(role.Value))
			{
				return Forbid();
			}
			if (await FightAsync(map, track: true) is not { } fight)
			{
				return NotFound();
			}
			if (token.CombatantId is { } existing && fight.Combatants.Any(c => c.Id == existing))
			{
				return NoContent();
			}
			var combatant = await CombatantOfAsync(token);
			fight.Combatants.Add(combatant);
			fight.Encounter.CurrentId ??= combatant.Id;
			Save(fight, fight.Combatants);
			map.UpdatedAt = DateTimeOffset.UtcNow;
			await _context.SaveChangesAsync();
			return NoContent();
		}

		//	DELETE: api/campaigns/{campaignId}/maps/{mapId}/combat/tokens/{tokenId} — a token leaves the fight (it keeps its
		//	hit points and conditions)
		[HttpDelete("{mapId:guid}/combat/tokens/{tokenId:guid}")]
		public async Task<IActionResult> LeaveFight(Guid campaignId, Guid mapId, Guid tokenId)
		{
			var (map, role) = await LoadAsync(campaignId, mapId, withTokens: true);
			var token = map?.Tokens.FirstOrDefault(t => t.Id == tokenId);
			if (map is null || role is null || token is null)
			{
				return NotFound();
			}
			if (!CampaignRules.RunsTheTable(role.Value))
			{
				return Forbid();
			}
			if (await FightAsync(map, track: true) is { } fight && token.CombatantId is { } id && fight.Combatants.FirstOrDefault(c => c.Id == id) is { } combatant)
			{
				if (fight.Encounter.CurrentId == id)
				{
					var order = EncounterRules.Order(fight.Combatants);
					var next = order.SkipWhile(c => c.Id != id).Skip(1).FirstOrDefault() ?? order.FirstOrDefault(c => c.Id != id);
					fight.Encounter.CurrentId = next?.Id;
				}
				fight.Combatants.Remove(combatant);
				KeepState(token, combatant);
				Save(fight, fight.Combatants);
			}
			token.CombatantId = null;
			map.UpdatedAt = DateTimeOffset.UtcNow;
			await _context.SaveChangesAsync();
			return NoContent();
		}

		//	PUT: api/campaigns/{campaignId}/maps/{mapId}/combat/initiative — a master any combatant, a player their character
		[HttpPut("{mapId:guid}/combat/initiative")]
		public async Task<IActionResult> SetInitiative(Guid campaignId, Guid mapId, [FromBody] SetInitiativeDto dto)
		{
			var (map, role) = await LoadAsync(campaignId, mapId, withTokens: false);
			if (map is null || role is null)
			{
				return NotFound();
			}
			if (await FightAsync(map, track: true) is not { } fight || fight.Combatants.FirstOrDefault(c => c.Id == dto.CombatantId) is not { } combatant)
			{
				return NotFound();
			}
			if (!CampaignRules.RunsTheTable(role.Value) && !await OwnsAsync(combatant.CharacterId))
			{
				return Forbid();
			}
			combatant.Initiative = Math.Clamp(dto.Initiative, -10, 99);
			Save(fight, fight.Combatants);
			await _context.SaveChangesAsync();
			return NoContent();
		}

		//	A combatant made from a token: a character (its initiative rolled by its player), a monster with its statblock
		//	and the token's hit points, any other token
		private async Task<EncounterCombatant> CombatantOfAsync(CampaignToken token)
		{
			var monster = token.MonsterId is { } monsterId
				? await _context.Monsters.AsNoTracking().Where(m => m.Id == monsterId)
					.Select(m => new { m.ArmorClass, m.HitPoints, m.Dexterity, m.Xp, m.ChallengeRating }).FirstOrDefaultAsync()
				: null;
			var combatant = new EncounterCombatant
			{
				Kind = token.CharacterId is not null ? CombatantKind.Character : monster is not null ? CombatantKind.Monster : CombatantKind.Other,
				CharacterId = token.CharacterId,
				MonsterId = token.CharacterId is null ? token.MonsterId : null,
				Name = token.Label,
				Hidden = token.Hidden,
				Conditions = token.CharacterId is null ? token.Conditions.ToList() : new()
			};
			if (monster is not null && token.CharacterId is null)
			{
				combatant.ArmorClass = monster.ArmorClass;
				combatant.MaxHp = token.MaxHp ?? monster.HitPoints;
				combatant.Hp = token.Hp ?? combatant.MaxHp;
				combatant.InitiativeBonus = (int)Math.Floor((monster.Dexterity - 10) / 2.0);
				combatant.Xp = monster.Xp;
				combatant.ChallengeRating = monster.ChallengeRating;
			}
			else if (token.CharacterId is null)
			{
				combatant.MaxHp = token.MaxHp ?? 0;
				combatant.Hp = token.Hp ?? combatant.MaxHp;
			}
			if (combatant.Kind != CombatantKind.Character)
			{
				combatant.Initiative = Random.Shared.Next(1, 21) + combatant.InitiativeBonus;
			}
			token.CombatantId = combatant.Id;
			return combatant;
		}

		//	What a token keeps of its combatant when the fight is over for it
		private static void KeepState(CampaignToken token, EncounterCombatant combatant)
		{
			if (combatant.Kind == CombatantKind.Character)
			{
				return;
			}
			if (combatant.MaxHp > 0)
			{
				token.MaxHp = combatant.MaxHp;
				token.Hp = combatant.Hp;
			}
			token.Conditions = combatant.Conditions.ToList();
		}

		//	POST: api/campaigns/{campaignId}/maps/{mapId}/combat/next — the next turn (a new round after the last one); the
		//	monsters at 0 hit points are skipped
		[HttpPost("{mapId:guid}/combat/next")]
		public async Task<IActionResult> NextTurn(Guid campaignId, Guid mapId)
		{
			var (map, role) = await LoadAsync(campaignId, mapId, withTokens: false);
			if (map is null || role is null)
			{
				return NotFound();
			}
			if (!CampaignRules.RunsTheTable(role.Value))
			{
				return Forbid();
			}
			if (await FightAsync(map, track: true) is not { } fight)
			{
				return NotFound();
			}
			var order = EncounterRules.Order(fight.Combatants).Where(c => c.Kind == CombatantKind.Character || c.Hp > 0 || c.MaxHp == 0).ToList();
			if (order.Count == 0)
			{
				return NoContent();
			}
			var index = order.FindIndex(c => c.Id == fight.Encounter.CurrentId);
			var next = index + 1;
			if (next >= order.Count)
			{
				next = 0;
				fight.Encounter.Round++;
			}
			fight.Encounter.CurrentId = order[next].Id;
			fight.Encounter.Version++;
			fight.Encounter.UpdatedAt = DateTimeOffset.UtcNow;
			await _context.SaveChangesAsync();
			return NoContent();
		}

		//	POST: api/campaigns/{campaignId}/maps/{mapId}/combat/previous — the turn goes back one (to the previous round
		//	from the first of the order)
		[HttpPost("{mapId:guid}/combat/previous")]
		public async Task<IActionResult> PreviousTurn(Guid campaignId, Guid mapId)
		{
			var (map, role) = await LoadAsync(campaignId, mapId, withTokens: false);
			if (map is null || role is null)
			{
				return NotFound();
			}
			if (!CampaignRules.RunsTheTable(role.Value))
			{
				return Forbid();
			}
			if (await FightAsync(map, track: true) is not { } fight)
			{
				return NotFound();
			}
			var order = EncounterRules.Order(fight.Combatants).Where(c => c.Kind == CombatantKind.Character || c.Hp > 0 || c.MaxHp == 0).ToList();
			if (order.Count == 0)
			{
				return NoContent();
			}
			var index = order.FindIndex(c => c.Id == fight.Encounter.CurrentId);
			var previous = index - 1;
			if (previous < 0)
			{
				if (fight.Encounter.Round <= 1)
				{
					return NoContent();
				}
				previous = order.Count - 1;
				fight.Encounter.Round--;
			}
			fight.Encounter.CurrentId = order[previous].Id;
			fight.Encounter.Version++;
			fight.Encounter.UpdatedAt = DateTimeOffset.UtcNow;
			await _context.SaveChangesAsync();
			return NoContent();
		}

		//	PUT: api/campaigns/{campaignId}/maps/{mapId}/combat/health — whether the players see how hurt the enemies are
		[HttpPut("{mapId:guid}/combat/health")]
		public async Task<IActionResult> ShowCombatHealth(Guid campaignId, Guid mapId, [FromBody] CombatHealthDto dto)
		{
			var (map, role) = await LoadAsync(campaignId, mapId, withTokens: false);
			if (map is null || role is null)
			{
				return NotFound();
			}
			if (!CampaignRules.RunsTheTable(role.Value))
			{
				return Forbid();
			}
			if (await FightAsync(map, track: true) is not { } fight)
			{
				return NotFound();
			}
			fight.Encounter.ShowHealth = dto.Show;
			fight.Encounter.Version++;
			fight.Encounter.UpdatedAt = DateTimeOffset.UtcNow;
			await _context.SaveChangesAsync();
			return NoContent();
		}

		//	POST: api/campaigns/{campaignId}/maps/{mapId}/combat/end — the encounter is over; the tokens stay
		[HttpPost("{mapId:guid}/combat/end")]
		public async Task<IActionResult> EndCombat(Guid campaignId, Guid mapId)
		{
			var (map, role) = await LoadAsync(campaignId, mapId, withTokens: false);
			if (map is null || role is null)
			{
				return NotFound();
			}
			if (!CampaignRules.RunsTheTable(role.Value))
			{
				return Forbid();
			}
			if (await FightAsync(map, track: true) is { } fight)
			{
				foreach (var token in await _context.CampaignTokens.Where(t => t.MapId == map.Id && t.CombatantId != null).ToListAsync())
				{
					if (fight.Combatants.FirstOrDefault(c => c.Id == token.CombatantId) is { } combatant)
					{
						KeepState(token, combatant);
					}
					token.CombatantId = null;
				}
				fight.Encounter.Status = EncounterStatus.Finished;
				fight.Encounter.Version++;
				fight.Encounter.UpdatedAt = DateTimeOffset.UtcNow;
			}
			map.EncounterId = null;
			map.UpdatedAt = DateTimeOffset.UtcNow;
			await _context.SaveChangesAsync();
			return NoContent();
		}

		//	PUT: api/campaigns/{campaignId}/maps/{mapId}/tokens/{tokenId}/state — conditions and hit points of a token, written
		//	to its combatant in a fight (a character's live on its sheet)
		[HttpPut("{mapId:guid}/tokens/{tokenId:guid}/state")]
		public async Task<IActionResult> SetTokenState(Guid campaignId, Guid mapId, Guid tokenId, [FromBody] TokenStateDto dto)
		{
			var (map, role) = await LoadAsync(campaignId, mapId, withTokens: true);
			var token = map?.Tokens.FirstOrDefault(t => t.Id == tokenId);
			if (map is null || role is null || token is null)
			{
				return NotFound();
			}
			//	The masters; whoever controls the token its hit points (not its conditions)
			var runs = CampaignRules.RunsTheTable(role.Value);
			if (!runs && !await ControlsAsync(token))
			{
				return Forbid();
			}
			if (token.CharacterId is not null)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "A character's conditions and hit points live on its sheet.");
			}
			var fight = await FightAsync(map, track: true);
			var combatant = token.CombatantId is { } cid ? fight?.Combatants.FirstOrDefault(c => c.Id == cid) : null;
			var conditions = runs
				? (dto.Conditions ?? new()).Where(k => EncounterRules.Conditions.Contains(k)).Distinct().ToList()
				: combatant?.Conditions ?? token.Conditions;
			if (dto.TempHp is { } temp)
			{
				token.TempHp = temp > 0 ? Math.Min(temp, 10_000) : null;
			}
			if (fight is not null && combatant is not null)
			{
				combatant.Conditions = conditions;
				if (dto.Hp is { } hp)
				{
					combatant.Hp = Math.Clamp(hp, 0, Math.Max(combatant.MaxHp, 0) + 1000);
				}
				if (dto.TempHp is { } fightTemp)
				{
					combatant.TempHp = Math.Clamp(fightTemp, 0, 10_000);
				}
				Save(fight, fight.Combatants);
			}
			else
			{
				token.Conditions = conditions;
				if (dto.MaxHp is { } newMax && newMax > 0)
				{
					token.MaxHp = Math.Min(newMax, 100_000);
					token.Hp = Math.Min(token.Hp ?? newMax, token.MaxHp.Value + 1000);
				}
				if (dto.Hp is { } tokenHp && token.MaxHp is { } tokenMax)
				{
					token.Hp = Math.Clamp(tokenHp, 0, tokenMax + 1000);
				}
			}
			token.UpdatedAt = map.UpdatedAt = DateTimeOffset.UtcNow;
			await _context.SaveChangesAsync();
			return NoContent();
		}

		// ===== Helpers =====

		//	The map and the role of the account; a player only reaches the maps shown
		private async Task<(CampaignMap? Map, CampaignRole? Role)> LoadAsync(Guid campaignId, Guid mapId, bool withTokens)
		{
			if (await CampaignAccess.RoleAsync(_context, campaignId, UserId) is not { } role)
			{
				return (null, null);
			}
			var query = _context.CampaignMaps.Where(m => m.Id == mapId && m.CampaignId == campaignId);
			if (withTokens)
			{
				query = query.Include(m => m.Tokens).Include(m => m.Shapes);
			}
			var map = await query.FirstOrDefaultAsync();
			if (map is null || (!CampaignRules.RunsTheTable(role) && !map.Shown))
			{
				return (null, null);
			}
			return (map, role);
		}

		//	The tokens as the account sees them, with their conditions (a character's from its sheet, a combatant's from the
		//	fight) and, in a fight, the hit points of the monsters (the masters) or how hurt they look (the players)
		private async Task<List<MapTokenDto>> TokensAsync(CampaignMap map, CampaignRole role, Fight? fight = null)
		{
			var runs = CampaignRules.RunsTheTable(role);
			var characterIds = map.Tokens.Where(t => t.CharacterId is not null).Select(t => t.CharacterId!.Value).Distinct().ToList();
			var characters = await _context.Characters.AsNoTracking()
				.Where(c => characterIds.Contains(c.Id)).Select(c => new { c.Id, c.OwnerId, c.Sheet }).ToListAsync();
			var mine = characters.Where(c => c.OwnerId == UserId).Select(c => c.Id).ToHashSet();
			var sheetConditions = characters.ToDictionary(c => c.Id, c => EncounterSheetSync.ConditionsOf(CharactersController.ReadSheet(c.Sheet)));
			return map.Tokens
				.Where(t => runs || !t.Hidden)
				.Where(t => runs || !map.FogEnabled || (t.CharacterId is { } own && mine.Contains(own)) || !UnderFog(map, t))
				.OrderBy(t => t.Kind).ThenBy(t => t.Label)
				.Select(t =>
				{
					var controls = (t.CharacterId is { } id && mine.Contains(id)) || t.ControlledBy.Contains(UserId);
					var dto = ToDto(t, MapRules.CanMove(role, controls, map.Shown, t.Hidden) && (runs || t.Layer == TokenLayer.Tokens)) with { Controlled = controls };
					//	The masters and whoever controls it know its numbers; the others how hurt it looks
					var knows = runs || controls;
					if (knows)
					{
						dto = dto with { TempHp = t.TempHp };
					}
					if (runs)
					{
						dto = dto with { ControlledBy = t.ControlledBy.ToList() };
					}
					var combatant = t.CombatantId is { } cid ? fight?.Combatants.FirstOrDefault(c => c.Id == cid) : null;
					var conditions = t.CharacterId is { } characterId && sheetConditions.TryGetValue(characterId, out var fromSheet) ? fromSheet
						: combatant is not null ? combatant.Conditions
						: t.Conditions;
					dto = dto with { Conditions = conditions.ToList() };
					if (combatant is null && t.CharacterId is null && t.MaxHp is { } tokenMax && tokenMax > 0)
					{
						var tokenHp = t.Hp ?? tokenMax;
						dto = knows
							? dto with { Hp = tokenHp, MaxHp = tokenMax }
							: dto with { Health = EncounterRules.HealthOf(tokenHp, tokenMax) };
					}
					if (combatant is not null && combatant.Kind != CombatantKind.Character)
					{
						dto = knows
							? dto with { Hp = combatant.Hp, MaxHp = combatant.MaxHp, TempHp = combatant.TempHp > 0 ? combatant.TempHp : null }
							: dto with { Health = EncounterRules.HealthOf(combatant.Hp, combatant.MaxHp) };
					}
					return dto;
				})
				.ToList();
		}

		// ----- The fight on a map -----

		private sealed record Fight(CampaignEncounter Encounter, List<EncounterCombatant> Combatants);

		//	The encounter under way on the map, if any
		private async Task<Fight?> FightAsync(CampaignMap map, bool track = false)
		{
			if (map.EncounterId is not { } id)
			{
				return null;
			}
			var query = _context.CampaignEncounters.Where(e => e.Id == id && e.CampaignId == map.CampaignId);
			var encounter = track ? await query.FirstOrDefaultAsync() : await query.AsNoTracking().FirstOrDefaultAsync();
			return encounter is null || encounter.Status != EncounterStatus.Running ? null : new Fight(encounter, EncountersController.Read(encounter.Combatants));
		}

		private static DateTimeOffset Latest(CampaignMap map, Fight? fight) =>
			fight is not null && fight.Encounter.UpdatedAt > map.UpdatedAt ? fight.Encounter.UpdatedAt : map.UpdatedAt;

		private static MapCombatDto? CombatOf(CampaignMap map, Fight? fight, CampaignRole role)
		{
			if (fight is null)
			{
				return null;
			}
			var runs = CampaignRules.RunsTheTable(role);
			var order = EncounterRules.Order(fight.Combatants)
				.Where(c => runs || !c.Hidden)
				.Select(c => new MapCombatantDto(c.Id, c.Name, c.Kind, c.Initiative, map.Tokens.FirstOrDefault(t => t.CombatantId == c.Id)?.Id, c.Hidden, c.InitiativeBonus))
				.ToList();
			var current = fight.Encounter.CurrentId is { } id && order.Any(c => c.Id == id) ? fight.Encounter.CurrentId : null;
			return new MapCombatDto(fight.Encounter.Id, fight.Encounter.Name, fight.Encounter.Round, current, order, fight.Encounter.ShowHealth);
		}

		private static void Save(Fight fight, List<EncounterCombatant> combatants)
		{
			fight.Encounter.Combatants = System.Text.Json.JsonSerializer.Serialize(combatants, new System.Text.Json.JsonSerializerOptions(System.Text.Json.JsonSerializerDefaults.Web));
			fight.Encounter.Version++;
			fight.Encounter.UpdatedAt = DateTimeOffset.UtcNow;
		}

		private async Task WaitForChangeAsync(Guid campaignId, Guid mapId, DateTimeOffset since, CancellationToken aborted)
		{
			var until = DateTimeOffset.UtcNow.AddSeconds(20);
			try
			{
				while (DateTimeOffset.UtcNow < until)
				{
					var stamp = await _context.CampaignMaps.AsNoTracking()
						.Where(m => m.Id == mapId && m.CampaignId == campaignId)
						.Select(m => new { m.UpdatedAt, m.EncounterId })
						.FirstOrDefaultAsync(aborted);
					if (stamp is null)
					{
						return;
					}
					var latest = stamp.UpdatedAt;
					if (stamp.EncounterId is { } encounterId)
					{
						var fought = await _context.CampaignEncounters.AsNoTracking().Where(e => e.Id == encounterId).Select(e => (DateTimeOffset?)e.UpdatedAt).FirstOrDefaultAsync(aborted);
						if (fought is { } at && at > latest)
						{
							latest = at;
						}
					}
					//	The database keeps microseconds
					if (latest.UtcTicks / 10 != since.UtcTicks / 10)
					{
						return;
					}
					await Task.Delay(400, aborted);
				}
			}
			catch (OperationCanceledException)
			{
				//	The table was closed
			}
		}

		//	Whether the account moves this token besides being a master: its character, or assigned by a master
		private async Task<bool> ControlsAsync(CampaignToken token) =>
			token.ControlledBy.Contains(UserId) || await OwnsAsync(token.CharacterId);

		private async Task<bool> OwnsAsync(Guid? characterId) =>
			characterId is { } id && await _context.Characters.AnyAsync(c => c.Id == id && c.OwnerId == UserId);

		private static MapTokenDto ToDto(CampaignToken t, bool canMove) =>
			new(t.Id, t.Label, t.Color, t.Kind, t.CharacterId, t.MonsterId, t.X, t.Y, t.Size, t.Hidden, canMove, null, t.Layer, t.CombatantId,
				PropType: t.PropType, PropState: t.PropState, PlayersInteract: t.PlayersInteract, ImageId: t.ImageId);

		private static bool UnderFog(CampaignMap map, CampaignToken t)
		{
			var (x, y) = MapGeometry.Center(map.GridType, map.GridSize, map.GridOffsetX, map.GridOffsetY, t.X, t.Y, t.Size);
			return MapFog.Covered(map.Fog, x, y);
		}

		private static MapTableDto TableOf(CampaignMap map, CampaignRole role) => new(
			map.FogEnabled,
			map.FogEnabled || CampaignRules.RunsTheTable(role) ? map.Fog : new List<double>(),
			map.PingAt is { } pingAt ? new MapPingDto(map.PingX ?? 0, map.PingY ?? 0, map.PingColor ?? PlayerColors.Master, pingAt) : null,
			map.FocusAt is { } focusAt ? new MapFocusDto(map.FocusX ?? 0, map.FocusY ?? 0, map.FocusZoom ?? 1, focusAt) : null);

		//	Everyone sees their own drawings and what is for the whole table (MapRules.Sees)
		private List<MapShapeDto> ShapesOf(CampaignMap map, CampaignRole role)
		{
			var runs = CampaignRules.RunsTheTable(role);
			return map.Shapes
				.Where(s => MapRules.Sees(s.Kind, s.MasterOnly, s.OwnerId == UserId))
				.OrderBy(s => s.CreatedAt)
				.Select(s => ShapeDto(s, runs))
				.ToList();
		}

		private MapShapeDto ShapeDto(CampaignMapShape s, bool runs)
		{
			var mine = s.OwnerId == UserId;
			return new MapShapeDto(s.Id, s.Kind, s.Points, s.Color, s.Text, s.Size, s.MasterOnly || s.Kind == ShapeKind.Freehand,
				MapRules.CanDeleteShape(s.Kind, s.MasterOnly, mine, runs), MapRules.CanMoveShape(s.Kind, s.MasterOnly, mine, runs));
		}

		private static bool OnMap(CampaignMap map, int x, int y, int size) =>
			MapGeometry.Inside(map.GridType, map.GridSize, map.GridOffsetX, map.GridOffsetY, x, y, size, map.Width, map.Height);

		private static string? Validate(SaveMapDto dto, bool requireImage)
		{
			if (string.IsNullOrWhiteSpace(dto.Name) || dto.Name.Trim().Length > 120)
			{
				return "A name of at most 120 characters is required.";
			}
			if (requireImage && string.IsNullOrEmpty(dto.Image))
			{
				return "The map needs a picture.";
			}
			if (dto.Image is { } image && (image.Length > MapRules.MaxImageLength
				|| !(image.StartsWith("data:image/jpeg;base64,", StringComparison.Ordinal) || image.StartsWith("data:image/png;base64,", StringComparison.Ordinal)
					|| image.StartsWith("data:image/webp;base64,", StringComparison.Ordinal))))
			{
				return "The picture must be a JPEG, PNG or WebP image of at most 3 MB.";
			}
			if (dto.Width is < 1 or > MapRules.MaxImageSide || dto.Height is < 1 or > MapRules.MaxImageSide)
			{
				return "Picture size out of range.";
			}
			if (!Enum.IsDefined(dto.GridType) || dto.GridSize is < MapRules.MinGrid or > MapRules.MaxGrid || dto.GridOffsetX < 0 || dto.GridOffsetY < 0
				|| dto.GridOffsetX >= dto.GridSize || dto.GridOffsetY >= dto.GridSize)
			{
				return "Grid out of range.";
			}
			return null;
		}

		private static void Apply(CampaignMap map, SaveMapDto dto)
		{
			map.Name = dto.Name.Trim();
			if (dto.Image is { } image)
			{
				map.Image = image;
			}
			map.Width = dto.Width;
			map.Height = dto.Height;
			map.GridType = dto.GridType;
			map.GridSize = dto.GridSize;
			map.GridOffsetX = dto.GridOffsetX;
			map.GridOffsetY = dto.GridOffsetY;
			map.Shown = dto.Shown;
			map.UpdatedAt = DateTimeOffset.UtcNow;
		}

		private async Task<string?> ValidateTokenAsync(Guid campaignId, CampaignMap map, SaveTokenDto dto)
		{
			if (string.IsNullOrWhiteSpace(dto.Label) || dto.Label.Trim().Length > 100)
			{
				return "A label of at most 100 characters is required.";
			}
			if (!Enum.IsDefined(dto.Kind) || !Enum.IsDefined(dto.Layer) || dto.Size is < 1 or > MapRules.MaxTokenSize || !OnMap(map, dto.X, dto.Y, dto.Size))
			{
				return "Unknown kind, size out of range or outside the map.";
			}
			if (dto.Color is { } color && !System.Text.RegularExpressions.Regex.IsMatch(color, "^#[0-9a-fA-F]{6}$"))
			{
				return "The colour must be #rrggbb.";
			}
			if (dto.ImageId is { } imageId && !await _context.UserImages.AnyAsync(i => i.Id == imageId))
			{
				return "Unknown image.";
			}
			if (dto.Kind == TokenKind.Prop && (dto.PropType is not { } propType || !Enum.IsDefined(propType) || !PropRules.Valid(propType, dto.PropState)))
			{
				return "An object needs a kind and one of its states.";
			}
			if (dto.ControlledBy.Count > 0)
			{
				var members = await _context.CampaignMembers.AsNoTracking().Where(m => m.CampaignId == campaignId).Select(m => m.UserId).ToListAsync();
				if (dto.ControlledBy.Any(id => !members.Contains(id)))
				{
					return "Tokens can be assigned only to members of the campaign.";
				}
			}
			if (dto.CharacterId is { } characterId
				&& !await _context.CampaignCharacters.AnyAsync(cc => cc.CampaignId == campaignId && cc.CharacterId == characterId))
			{
				return "The character is not at this table.";
			}
			return null;
		}

		//	A character's token takes the colour of its owner at this table
		private async Task ApplyAsync(Guid campaignId, CampaignToken token, SaveTokenDto dto)
		{
			token.Label = dto.Label.Trim();
			token.Kind = dto.Kind;
			token.CharacterId = dto.CharacterId;
			token.MonsterId = dto.MonsterId;
			token.X = dto.X;
			token.Y = dto.Y;
			token.Size = dto.Size;
			token.Hidden = dto.Hidden;
			token.Layer = dto.Layer;
			token.ControlledBy = dto.ControlledBy.Distinct().Take(MapRules.MaxControllers).ToList();
			token.ImageId = dto.ImageId;
			token.PropType = dto.Kind == TokenKind.Prop ? dto.PropType : null;
			token.PropState = dto.Kind == TokenKind.Prop ? dto.PropState : PropState.Closed;
			token.PlayersInteract = dto.Kind == TokenKind.Prop && dto.PlayersInteract;
			token.MaxHp = dto.MaxHp is { } max && max > 0 ? Math.Min(max, 100_000) : null;
			token.Hp = token.MaxHp is null ? null : Math.Clamp(dto.Hp ?? token.MaxHp.Value, 0, token.MaxHp.Value + 1000);
			token.UpdatedAt = DateTimeOffset.UtcNow;
			token.Color = dto.Color ?? PlayerColors.Master;
			if (dto.CharacterId is { } characterId && dto.Color is null)
			{
				var owner = await _context.Characters.AsNoTracking().Where(c => c.Id == characterId).Select(c => c.OwnerId).FirstOrDefaultAsync();
				var colors = await CampaignAccess.EnsureColorsAsync(_context, campaignId);
				token.Color = owner is not null && colors.TryGetValue(owner, out var color) ? color : PlayerColors.Master;
			}
		}
	}
}
