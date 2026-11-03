using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealmForge.Api.Security;
using RealmForge.Domain.Entities;
using RealmForge.Infrastructure.Persistence;
using RealmForge.Shared.Campaigns;
using RealmForge.Shared.DTOs;

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
			var tokens = await TokensAsync(map, role.Value);
			return Ok(new CampaignMapDto(map.Id, map.Name, map.Image, map.Width, map.Height, map.GridSize, map.GridOffsetX, map.GridOffsetY,
				map.Shown, CampaignRules.RunsTheTable(role.Value), map.UpdatedAt, tokens));
		}

		//	GET: api/campaigns/{campaignId}/maps/{mapId}/state — what the table polls: the grid and the tokens
		[HttpGet("{mapId:guid}/state")]
		public async Task<ActionResult<MapStateDto>> GetState(Guid campaignId, Guid mapId)
		{
			var (map, role) = await LoadAsync(campaignId, mapId, withTokens: true);
			if (map is null || role is null)
			{
				return NotFound();
			}
			return Ok(new MapStateDto(map.Id, map.Name, map.GridSize, map.GridOffsetX, map.GridOffsetY, map.Shown, map.UpdatedAt,
				await TokensAsync(map, role.Value)));
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
				return Forbid();
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
			if (!MapRules.CanMove(role.Value, await OwnsAsync(token.CharacterId), map.Shown, token.Hidden))
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
				query = query.Include(m => m.Tokens);
			}
			var map = await query.FirstOrDefaultAsync();
			if (map is null || (!CampaignRules.RunsTheTable(role) && !map.Shown))
			{
				return (null, null);
			}
			return (map, role);
		}

		private async Task<List<MapTokenDto>> TokensAsync(CampaignMap map, CampaignRole role)
		{
			var runs = CampaignRules.RunsTheTable(role);
			var characterIds = map.Tokens.Where(t => t.CharacterId is not null).Select(t => t.CharacterId!.Value).ToList();
			var mine = characterIds.Count == 0 ? new HashSet<Guid>() : (await _context.Characters.AsNoTracking()
				.Where(c => characterIds.Contains(c.Id) && c.OwnerId == UserId).Select(c => c.Id).ToListAsync()).ToHashSet();
			return map.Tokens
				.Where(t => runs || !t.Hidden)
				.OrderBy(t => t.Kind).ThenBy(t => t.Label)
				.Select(t => ToDto(t, MapRules.CanMove(role, t.CharacterId is { } id && mine.Contains(id), map.Shown, t.Hidden)))
				.ToList();
		}

		private async Task<bool> OwnsAsync(Guid? characterId) =>
			characterId is { } id && await _context.Characters.AnyAsync(c => c.Id == id && c.OwnerId == UserId);

		private static MapTokenDto ToDto(CampaignToken t, bool canMove) =>
			new(t.Id, t.Label, t.Color, t.Kind, t.CharacterId, t.MonsterId, t.X, t.Y, t.Size, t.Hidden, canMove);

		private static bool OnMap(CampaignMap map, int x, int y, int size) =>
			x >= 0 && y >= 0
			&& x + size <= MapRules.Columns(map.Width, map.GridSize, map.GridOffsetX) + 1
			&& y + size <= MapRules.Rows(map.Height, map.GridSize, map.GridOffsetY) + 1;

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
			if (dto.GridSize is < MapRules.MinGrid or > MapRules.MaxGrid || dto.GridOffsetX < 0 || dto.GridOffsetY < 0
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
			if (!Enum.IsDefined(dto.Kind) || dto.Size is < 1 or > MapRules.MaxTokenSize || !OnMap(map, dto.X, dto.Y, dto.Size))
			{
				return "Unknown kind, size out of range or outside the map.";
			}
			if (dto.Color is { } color && !System.Text.RegularExpressions.Regex.IsMatch(color, "^#[0-9a-fA-F]{6}$"))
			{
				return "The colour must be #rrggbb.";
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
