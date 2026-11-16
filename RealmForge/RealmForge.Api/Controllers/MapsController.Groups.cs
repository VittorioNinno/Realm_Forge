using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealmForge.Api.Security;
using RealmForge.Domain.Entities;
using RealmForge.Shared.Campaigns;
using RealmForge.Shared.DTOs;
using RealmForge.Shared.Enums;

namespace RealmForge.Api.Controllers
{
	///	<summary>
	///	The masters' monster drawer: groups of monsters kept for the campaign (a goblin patrol), and monsters placed on a
	///	map in one go around a point (the middle of the master's view), each with its hit points, its size and the picture
	///	the master chose for it; numbered when there is more than one of the same. One step to undo.
	///	</summary>
	public partial class MapsController
	{
		//	GET: api/campaigns/{campaignId}/maps/groups — masters and co-masters
		[HttpGet("groups")]
		public async Task<ActionResult<List<MonsterGroupDto>>> GetGroups(Guid campaignId, [FromQuery] LanguageCode lang = LanguageCode.It)
		{
			if (await CampaignAccess.RoleAsync(_context, campaignId, UserId) is not { } role || !CampaignRules.RunsTheTable(role))
			{
				return NotFound();
			}
			var groups = await _context.CampaignMonsterGroups.AsNoTracking().Where(g => g.CampaignId == campaignId).OrderBy(g => g.Name).ToListAsync();
			var entries = groups.ToDictionary(g => g.Id, g => ReadEntries(g.Entries));
			var names = await MonsterNamesAsync(entries.Values.SelectMany(e => e).Select(e => e.MonsterId), lang);
			return Ok(groups.Select(g => new MonsterGroupDto(g.Id, g.Name, entries[g.Id],
				entries[g.Id].Select(e => names.TryGetValue(e.MonsterId, out var name) ? name : "?").ToList())).ToList());
		}

		//	POST: api/campaigns/{campaignId}/maps/groups — a new group (one of the same name is replaced)
		[HttpPost("groups")]
		public async Task<ActionResult<MonsterGroupDto>> SaveGroup(Guid campaignId, [FromBody] SaveMonsterGroupDto dto, [FromQuery] LanguageCode lang = LanguageCode.It)
		{
			if (await CampaignAccess.RoleAsync(_context, campaignId, UserId) is not { } role)
			{
				return NotFound();
			}
			if (!CampaignRules.RunsTheTable(role))
			{
				return Forbid();
			}
			var name = (dto.Name ?? string.Empty).Trim();
			var entries = Merge(dto.Entries);
			if (name.Length is 0 or > 80 || entries is null || entries.Count == 0)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "A name and from 1 to 12 monsters are needed.");
			}
			var names = await MonsterNamesAsync(entries.Select(e => e.MonsterId), lang);
			if (entries.Any(e => !names.ContainsKey(e.MonsterId)))
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "Unknown monster.");
			}
			var group = await _context.CampaignMonsterGroups.FirstOrDefaultAsync(g => g.CampaignId == campaignId && g.Name == name);
			if (group is null)
			{
				if (await _context.CampaignMonsterGroups.CountAsync(g => g.CampaignId == campaignId) >= MonsterGroups.MaxGroups)
				{
					return Problem(statusCode: StatusCodes.Status400BadRequest, title: $"At most {MonsterGroups.MaxGroups} groups.");
				}
				group = new CampaignMonsterGroup { CampaignId = campaignId, Name = name };
				_context.CampaignMonsterGroups.Add(group);
			}
			group.Entries = JsonSerializer.Serialize(entries, GearJson);
			await _context.SaveChangesAsync();
			return Ok(new MonsterGroupDto(group.Id, group.Name, entries, entries.Select(e => names[e.MonsterId]).ToList()));
		}

		//	DELETE: api/campaigns/{campaignId}/maps/groups/{groupId}
		[HttpDelete("groups/{groupId:guid}")]
		public async Task<IActionResult> DeleteGroup(Guid campaignId, Guid groupId)
		{
			if (await CampaignAccess.RoleAsync(_context, campaignId, UserId) is not { } role)
			{
				return NotFound();
			}
			if (!CampaignRules.RunsTheTable(role))
			{
				return Forbid();
			}
			var group = await _context.CampaignMonsterGroups.FirstOrDefaultAsync(g => g.Id == groupId && g.CampaignId == campaignId);
			if (group is null)
			{
				return NotFound();
			}
			_context.CampaignMonsterGroups.Remove(group);
			await _context.SaveChangesAsync();
			return NoContent();
		}

		//	POST: api/campaigns/{campaignId}/maps/{mapId}/tokens/monsters — monsters placed in one go around a point
		[HttpPost("{mapId:guid}/tokens/monsters")]
		public async Task<ActionResult<List<MapTokenDto>>> PlaceMonsters(Guid campaignId, Guid mapId, [FromBody] PlaceMonstersDto dto, [FromQuery] LanguageCode lang = LanguageCode.It)
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
			var entries = Merge(dto.Entries);
			var total = entries?.Sum(e => e.Count) ?? 0;
			if (entries is null || total is 0 or > MonsterGroups.MaxPlaced || double.IsNaN(dto.X) || double.IsNaN(dto.Y))
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: $"From 1 to {MonsterGroups.MaxPlaced} monsters.");
			}
			if (map.Tokens.Count + total > MapRules.MaxTokens)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: $"At most {MapRules.MaxTokens} tokens per map.");
			}
			var ids = entries.Select(e => e.MonsterId).ToList();
			var monsters = await _context.Monsters.AsNoTracking().Where(m => ids.Contains(m.Id))
				.Select(m => new { m.Id, m.Size, m.IsNpc, m.HitPoints }).ToDictionaryAsync(m => m.Id);
			if (entries.Any(e => !monsters.ContainsKey(e.MonsterId)))
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "Unknown monster.");
			}
			var names = await MonsterNamesAsync(ids, lang);
			var images = await _context.MonsterImageChoices.AsNoTracking().Where(c => c.OwnerId == UserId && ids.Contains(c.MonsterId))
				.ToDictionaryAsync(c => c.MonsterId, c => c.ImageId);
			var before = TokensBefore(map, role.Value);
			var terrain = MapTerrain.Read(map.Terrain);
			var taken = map.Tokens.Where(t => t.Kind != TokenKind.Prop && t.Layer == TokenLayer.Tokens)
				.SelectMany(t => MapTerrain.Footprint(map.GridType, t.X, t.Y, t.Size)).ToHashSet();
			var start = MapGeometry.Nearest(map.GridType, map.GridSize, map.GridOffsetX, map.GridOffsetY, Math.Clamp(dto.X, 0, map.Width), Math.Clamp(dto.Y, 0, map.Height));
			var placed = new List<CampaignToken>();
			foreach (var entry in entries)
			{
				var monster = monsters[entry.MonsterId];
				var size = map.GridType == GridType.Square ? monster.Size switch { CreatureSize.Large => 2, CreatureSize.Huge => 3, CreatureSize.Gargantuan => 4, _ => 1 } : 1;
				var name = names.TryGetValue(entry.MonsterId, out var found) && found.Length > 0 ? found : "?";
				var same = map.Tokens.Count(t => t.MonsterId == entry.MonsterId);
				for (var i = 0; i < entry.Count; i++)
				{
					if (FreeNear(map, terrain, taken, start, size) is not { } cell)
					{
						break;
					}
					same++;
					var token = new CampaignToken
					{
						MapId = map.Id,
						Label = Cut(same == 1 ? name : $"{name} {same}", 100),
						Kind = monster.IsNpc ? TokenKind.Npc : TokenKind.Monster,
						MonsterId = monster.Id,
						Color = monster.IsNpc ? "#ab47bc" : "#dc3545",
						X = cell.Col,
						Y = cell.Row,
						Size = size,
						Hidden = dto.Hidden,
						ImageId = images.TryGetValue(monster.Id, out var image) ? image : null,
						MaxHp = monster.HitPoints > 0 ? monster.HitPoints : null,
						Hp = monster.HitPoints > 0 ? monster.HitPoints : null
					};
					taken.UnionWith(MapTerrain.Footprint(map.GridType, cell.Col, cell.Row, size));
					_context.CampaignTokens.Add(token);
					map.Tokens.Add(token);
					placed.Add(token);
				}
			}
			if (placed.Count == 0)
			{
				return Problem(statusCode: StatusCodes.Status409Conflict, title: "No room on the map.");
			}
			map.UpdatedAt = DateTimeOffset.UtcNow;
			await RememberTokensAsync(map, before, placed.ToArray());
			await _context.SaveChangesAsync();
			return Ok(placed.Select(t => ToDto(t, true)).ToList());
		}

		//	The nearest free place for a creature of that size: the cells around the point ring by ring, on the map, out of
		//	the walls and the cover that is not crossed, and not under another creature
		private static (int Col, int Row)? FreeNear(CampaignMap map, IReadOnlyDictionary<(int Col, int Row), TerrainKind> terrain,
			HashSet<(int Col, int Row)> taken, (int Col, int Row) start, int size)
		{
			var seen = new HashSet<(int Col, int Row)> { start };
			var ring = new List<(int Col, int Row)> { start };
			for (var step = 0; step < 40 && ring.Count > 0; step++)
			{
				foreach (var cell in ring.OrderBy(c => c.Row).ThenBy(c => c.Col))
				{
					if (OnMap(map, cell.Col, cell.Row, size) && MapTerrain.Footprint(map.GridType, cell.Col, cell.Row, size)
						.All(c => !taken.Contains(c) && terrain.GetValueOrDefault(c) is not (TerrainKind.Wall or TerrainKind.ThreeQuarterCover)))
					{
						return cell;
					}
				}
				ring = ring.SelectMany(c => MapTerrain.Neighbours(map.GridType, c)).Where(seen.Add).ToList();
			}
			return null;
		}

		//	The entries of a group: the same monster once (its counts added), at most MaxEntries kinds, MaxCount each; null
		//	when out of range
		private static List<MonsterGroupEntryDto>? Merge(List<MonsterGroupEntryDto>? entries)
		{
			if (entries is null || entries.Any(e => e.Count is < 1 or > MonsterGroups.MaxCount))
			{
				return null;
			}
			var merged = entries.GroupBy(e => e.MonsterId)
				.Select(g => new MonsterGroupEntryDto { MonsterId = g.Key, Count = Math.Min(MonsterGroups.MaxCount, g.Sum(e => e.Count)) }).ToList();
			return merged.Count > MonsterGroups.MaxEntries ? null : merged;
		}

		private static List<MonsterGroupEntryDto> ReadEntries(string json)
		{
			try
			{
				return JsonSerializer.Deserialize<List<MonsterGroupEntryDto>>(json, GearJson) ?? new();
			}
			catch (JsonException)
			{
				return new();
			}
		}

		//	The names of the monsters in the language asked (else the other one)
		private async Task<Dictionary<Guid, string>> MonsterNamesAsync(IEnumerable<Guid> monsterIds, LanguageCode lang)
		{
			var ids = monsterIds.Distinct().ToList();
			return await _context.Monsters.AsNoTracking().Where(m => ids.Contains(m.Id))
				.Select(m => new { m.Id, Name = m.Translations.OrderBy(t => t.Language == lang ? 0 : 1).Select(t => t.Name).FirstOrDefault() })
				.ToDictionaryAsync(m => m.Id, m => m.Name ?? "?");
		}
	}
}
