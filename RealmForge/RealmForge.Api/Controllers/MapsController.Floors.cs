using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealmForge.Api.Security;
using RealmForge.Domain.Entities;
using RealmForge.Shared.Campaigns;
using RealmForge.Shared.DTOs;

namespace RealmForge.Api.Controllers
{
	///	<summary>
	///	Floors and teleports: stairs and portals (props) linked to other stairs or portals, on the same map or another one
	///	(a floor of a building is a map). A creature next to one goes through: it lands next to the other end, with its
	///	riders; on another map it leaves this map (a character's other token there gives way). When the last character
	///	leaves the map the players see, the table follows it to the new one.
	///	</summary>
	public partial class MapsController
	{
		//	GET: api/campaigns/{campaignId}/maps/links — the stairs and portals of every map, for the masters to link them
		[HttpGet("links")]
		public async Task<ActionResult<List<MapLinkDto>>> GetLinks(Guid campaignId)
		{
			if (await CampaignAccess.RoleAsync(_context, campaignId, UserId) is not { } role || !CampaignRules.RunsTheTable(role))
			{
				return NotFound();
			}
			var links = await _context.CampaignTokens.AsNoTracking()
				.Where(t => t.Map.CampaignId == campaignId && t.Kind == TokenKind.Prop && (t.PropType == PropType.Stairs || t.PropType == PropType.Portal))
				.OrderBy(t => t.Map.Name).ThenBy(t => t.Label)
				.Select(t => new MapLinkDto(t.Id, t.MapId, t.Map.Name, t.Label, t.PropType!.Value))
				.ToListAsync();
			return Ok(links);
		}

		//	PUT: api/campaigns/{campaignId}/maps/{mapId}/tokens/{tokenId}/link — where stairs or a portal lead (and back)
		[HttpPut("{mapId:guid}/tokens/{tokenId:guid}/link")]
		public async Task<IActionResult> SaveLink(Guid campaignId, Guid mapId, Guid tokenId, [FromBody] SaveLinkDto dto)
		{
			var (map, role) = await LoadAsync(campaignId, mapId, withTokens: true);
			var token = map?.Tokens.FirstOrDefault(t => t.Id == tokenId);
			if (map is null || role is null || token is null || !PropRules.Leads(token.PropType))
			{
				return NotFound();
			}
			if (!CampaignRules.RunsTheTable(role.Value))
			{
				return Forbid();
			}
			CampaignToken? target = null;
			if (dto.TargetId is { } targetId)
			{
				target = await _context.CampaignTokens.FirstOrDefaultAsync(t => t.Id == targetId && t.Map.CampaignId == campaignId);
				if (target is null || target.Id == token.Id || !PropRules.Leads(target.PropType))
				{
					return Problem(statusCode: StatusCodes.Status400BadRequest, title: "Link it to other stairs or another portal.");
				}
			}
			var gear = ReadGear(token.Gear);
			gear.LinkTo = target?.Id;
			WriteGear(token, gear);
			if (target is not null && dto.BothWays)
			{
				var back = ReadGear(target.Gear);
				back.LinkTo = token.Id;
				WriteGear(target, back);
				target.UpdatedAt = DateTimeOffset.UtcNow;
			}
			token.UpdatedAt = map.UpdatedAt = DateTimeOffset.UtcNow;
			await _context.SaveChangesAsync();
			return NoContent();
		}

		//	POST: api/campaigns/{campaignId}/maps/{mapId}/tokens/{tokenId}/travel — a creature next to stairs or a portal
		//	goes through: whoever controls it when the players may use it, a master any
		[HttpPost("{mapId:guid}/tokens/{tokenId:guid}/travel")]
		public async Task<ActionResult<TravelResultDto>> Travel(Guid campaignId, Guid mapId, Guid tokenId, [FromBody] TravelDto dto)
		{
			var (map, role) = await LoadAsync(campaignId, mapId, withTokens: true);
			var way = map?.Tokens.FirstOrDefault(t => t.Id == tokenId);
			var traveller = map?.Tokens.FirstOrDefault(t => t.Id == dto.TokenId);
			var runs = role is { } r && CampaignRules.RunsTheTable(r);
			if (map is null || role is null || way is null || traveller is null || !PropRules.Leads(way.PropType) || traveller.Kind == TokenKind.Prop
				|| (!runs && (way.Hidden || traveller.Hidden)))
			{
				return NotFound();
			}
			if (!runs && (!way.PlayersInteract || !await ControlsAsync(traveller)))
			{
				return Forbid();
			}
			if (way.PropState != PropState.Open)
			{
				return Problem(statusCode: StatusCodes.Status409Conflict, title: "It does not lead anywhere now.", detail: "inactive");
			}
			if (TableCombat.Gap(map.GridType, traveller.X, traveller.Y, traveller.Size, way.X, way.Y, way.Size) > 1)
			{
				return Problem(statusCode: StatusCodes.Status409Conflict, title: "Too far: get next to it.", detail: "far");
			}
			if (!runs && traveller.CombatantId is { } moverId && await FightAsync(map, track: false) is { } current && current.Encounter.Round > 0
				&& current.Encounter.CurrentId != moverId && current.Combatants.Any(c => c.Id == moverId))
			{
				return Problem(statusCode: StatusCodes.Status409Conflict, title: "Not its turn.", detail: "turn");
			}
			if (ReadGear(way.Gear).LinkTo is not { } linkId
				|| await _context.CampaignTokens.FirstOrDefaultAsync(t => t.Id == linkId && t.Map.CampaignId == campaignId) is not { } end)
			{
				return Problem(statusCode: StatusCodes.Status409Conflict, title: "It leads nowhere yet.", detail: "nowhere");
			}
			var there = end.MapId == map.Id ? map
				: await _context.CampaignMaps.Include(m => m.Tokens).FirstAsync(m => m.Id == end.MapId);
			var before = TokensBefore(map, role.Value);
			var riders = map.Tokens.Where(t => t.Id != traveller.Id && ReadGear(t.Gear).MountedOn == traveller.Id).ToList();
			var moving = riders.Append(traveller).Select(t => t.Id).ToHashSet();
			var terrain = MapTerrain.Read(there.Terrain);
			var taken = there.Tokens.Where(t => t.Kind != TokenKind.Prop && t.Layer == TokenLayer.Tokens && !moving.Contains(t.Id))
				.SelectMany(t => MapTerrain.Footprint(there.GridType, t.X, t.Y, t.Size)).ToHashSet();
			var size = there.GridType == GridType.Square ? traveller.Size : 1;
			if (FreeNear(there, terrain, taken, (end.X, end.Y), size) is not { } landing)
			{
				return Problem(statusCode: StatusCodes.Status409Conflict, title: "No room at the other end.", detail: "full");
			}
			var now = DateTimeOffset.UtcNow;
			var gear = ReadGear(traveller.Gear);
			if (gear.MountedOn is not null)
			{
				gear.MountedOn = null;
				WriteGear(traveller, gear);
			}
			foreach (var t in riders.Append(traveller))
			{
				if (there.Id != map.Id)
				{
					//	A character has one token on a map: the one already there gives way
					if (t.CharacterId is { } characterId)
					{
						_context.CampaignTokens.RemoveRange(there.Tokens.Where(o => o.CharacterId == characterId && o.Id != t.Id));
					}
					t.MapId = there.Id;
					if (there.EncounterId != map.EncounterId)
					{
						t.CombatantId = null;
					}
				}
				(t.X, t.Y) = landing;
				t.UpdatedAt = now;
			}
			//	The last character gone from the map the players see: the table follows it
			var displayed = false;
			if (there.Id != map.Id && map.Shown && traveller.Kind == TokenKind.Character
				&& !map.Tokens.Any(t => t.Kind == TokenKind.Character && !moving.Contains(t.Id)))
			{
				foreach (var other in await _context.CampaignMaps.Where(m => m.CampaignId == campaignId && m.Id != there.Id && m.Shown).ToListAsync())
				{
					other.Shown = false;
					other.UpdatedAt = now;
				}
				there.Shown = true;
				displayed = true;
			}
			map.UpdatedAt = there.UpdatedAt = now;
			await RememberTokensAsync(map, before);
			await _context.SaveChangesAsync();
			return Ok(new TravelResultDto(there.Id, there.Name, landing.Col, landing.Row, displayed));
		}

		//	Where the stairs and portals of the map lead, by token (the name of the other end and of its map)
		private async Task<Dictionary<Guid, (Guid Id, string Label)>> LinksOfAsync(CampaignMap map)
		{
			var links = map.Tokens.Where(t => PropRules.Leads(t.PropType))
				.Select(t => (t.Id, Link: ReadGear(t.Gear).LinkTo)).Where(l => l.Link is not null).ToList();
			if (links.Count == 0)
			{
				return new();
			}
			var ids = links.Select(l => l.Link!.Value).Distinct().ToList();
			var ends = await _context.CampaignTokens.AsNoTracking().Where(t => ids.Contains(t.Id) && t.Map.CampaignId == map.CampaignId)
				.Select(t => new { t.Id, t.Label, MapName = t.Map.Name, t.MapId }).ToDictionaryAsync(t => t.Id);
			return links.Where(l => ends.ContainsKey(l.Link!.Value))
				.ToDictionary(l => l.Id, l =>
				{
					var end = ends[l.Link!.Value];
					return (end.Id, end.MapId == map.Id ? end.Label : $"{end.MapName} · {end.Label}");
				});
		}
	}
}
