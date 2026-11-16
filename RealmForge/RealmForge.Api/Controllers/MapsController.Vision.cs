using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealmForge.Api.Security;
using RealmForge.Domain.Entities;
using RealmForge.Shared.Campaigns;
using RealmForge.Shared.DTOs;

namespace RealmForge.Api.Controllers
{
	///	<summary>
	///	Lights and sight at the table: the light of a map (bright, dim, dark), the lights carried by the tokens, their
	///	darkvision; with dynamic vision on, each player sees only what their creatures see (MapVision) and the creatures
	///	out of their sight are not sent to them. The masters see everything, and what the characters see together.
	///	</summary>
	public partial class MapsController
	{
		//	What the account's creatures see, worked out with the tokens of this request (TableOf sends it)
		private MapVisionDto? vision;

		//	PUT: api/campaigns/{campaignId}/maps/{mapId}/lighting — masters and co-masters
		[HttpPut("{mapId:guid}/lighting")]
		public async Task<IActionResult> SaveLighting(Guid campaignId, Guid mapId, [FromBody] SaveLightingDto dto)
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
			if (!Enum.IsDefined(dto.Lighting))
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "Unknown lighting.");
			}
			map.Lighting = dto.Lighting;
			map.DynamicVision = dto.DynamicVision;
			map.UpdatedAt = DateTimeOffset.UtcNow;
			await _context.SaveChangesAsync();
			return NoContent();
		}

		//	PUT: api/campaigns/{campaignId}/maps/{mapId}/tokens/{tokenId}/vision — the light a token carries and its darkvision:
		//	whoever controls it, a master any
		[HttpPut("{mapId:guid}/tokens/{tokenId:guid}/vision")]
		public async Task<IActionResult> SaveTokenVision(Guid campaignId, Guid mapId, Guid tokenId, [FromBody] SaveTokenVisionDto dto)
		{
			var (map, role) = await LoadAsync(campaignId, mapId, withTokens: true);
			var token = map?.Tokens.FirstOrDefault(t => t.Id == tokenId);
			if (map is null || role is null || token is null || (!CampaignRules.RunsTheTable(role.Value) && token.Hidden))
			{
				return NotFound();
			}
			if (!CampaignRules.RunsTheTable(role.Value) && !await ControlsAsync(token))
			{
				return Forbid();
			}
			var name = (dto.Name ?? string.Empty).Trim();
			if (dto.Bright is < 0 or > TokenLight.MaxFeet || dto.Dim is < 0 or > TokenLight.MaxFeet || name.Length > 60 || dto.Darkvision is < -1 or > 300)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "Invalid light.");
			}
			var gear = ReadGear(token.Gear);
			if (dto.Bright is not null || dto.Dim is not null)
			{
				var (bright, dim) = (dto.Bright ?? 0, dto.Dim ?? 0);
				gear.Light = bright + dim == 0 ? null : new TokenLight { Name = name, Bright = bright, Dim = dim };
			}
			if (dto.Darkvision is { } darkvision)
			{
				gear.Darkvision = darkvision < 0 ? null : darkvision;
			}
			WriteGear(token, gear);
			token.UpdatedAt = map.UpdatedAt = DateTimeOffset.UtcNow;
			await _context.SaveChangesAsync();
			return NoContent();
		}

		private static bool Creature(TokenKind kind) => kind is TokenKind.Character or TokenKind.Npc or TokenKind.Monster;

		//	The tokens as the account sees them under dynamic vision: the viewers are its creatures (none on the map: the
		//	characters, as the masters see them); a player is sent only the creatures its viewers see
		private async Task<List<MapTokenDto>> SeenAsync(CampaignMap map, bool runs, List<MapTokenDto> tokens, IReadOnlyDictionary<Guid, int> characterDarkvision)
		{
			vision = null;
			if (!map.DynamicVision)
			{
				return tokens;
			}
			var viewers = runs ? new List<MapTokenDto>() : tokens.Where(t => t.Controlled && Creature(t.Kind) && t.Layer == TokenLayer.Tokens).ToList();
			if (viewers.Count == 0)
			{
				viewers = tokens.Where(t => t.Kind == TokenKind.Character && t.Layer == TokenLayer.Tokens && !t.Hidden).ToList();
			}
			var monsterIds = viewers.Concat(tokens.Where(t => runs || t.Controlled)).Where(t => t.MonsterId is not null && t.CharacterId is null).Select(t => t.MonsterId!.Value).Distinct().ToList();
			var senses = monsterIds.Count == 0 ? new Dictionary<Guid, int>()
				: (await _context.MonsterTranslations.AsNoTracking().Where(t => monsterIds.Contains(t.MonsterId)).Select(t => new { t.MonsterId, t.Senses }).ToListAsync())
					.GroupBy(t => t.MonsterId).ToDictionary(g => g.Key, g => g.Max(t => MapVision.DarkvisionOf(t.Senses)));
			var gears = map.Tokens.ToDictionary(t => t.Id, t => ReadGear(t.Gear));
			int DarkvisionOf(MapTokenDto t) =>
				gears.TryGetValue(t.Id, out var g) && g.Darkvision is { } set ? set
				: (t.CharacterId ?? t.SheetCharacterId) is { } c && characterDarkvision.TryGetValue(c, out var fromSheet) ? fromSheet
				: t.MonsterId is { } m && senses.TryGetValue(m, out var fromSenses) ? fromSenses
				: 0;
			var closed = map.Tokens.Where(t => t.Kind == TokenKind.Prop && t.PropType is { } type && MapTerrain.Closes(type, t.PropState))
				.SelectMany(t => MapTerrain.Footprint(map.GridType, t.X, t.Y, t.Size));
			var board = new MapVision.Board(map.GridType, map.GridSize, map.GridOffsetX, map.GridOffsetY, map.Width, map.Height, MapVision.Blocking(map.Terrain, closed));
			var lights = map.Tokens.Where(t => gears[t.Id].Light is not null)
				.Select(t => new MapVision.Light(t.X, t.Y, t.Size, gears[t.Id].Light!.Bright, gears[t.Id].Light!.Dim)).ToList();
			var looking = viewers.Select(t => new MapVision.Viewer(t.X, t.Y, t.Size, DarkvisionOf(t), t.Conditions?.Contains("blinded") == true)).ToList();
			var (bright, dim) = MapVision.Seen(board, map.Lighting, looking, lights);
			vision = new MapVisionDto(bright.SelectMany(c => new[] { c.Col, c.Row }).ToList(), dim.SelectMany(c => new[] { c.Col, c.Row }).ToList());
			var knows = tokens.Where(t => runs || t.Controlled).Select(t => t.Id).ToHashSet();
			var shown = tokens.Select(t => knows.Contains(t.Id) ? t with { Darkvision = DarkvisionOf(t) } : t).ToList();
			return runs ? shown : shown.Where(t => t.Controlled || !Creature(t.Kind) || MapVision.Spotted(map.GridType, t.X, t.Y, t.Size, bright, dim)).ToList();
		}
	}
}
