using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealmForge.Api.Security;
using RealmForge.Domain.Entities;
using RealmForge.Shared.Campaigns;
using RealmForge.Shared.DTOs;

namespace RealmForge.Api.Controllers
{
	///	<summary>
	///	Taking back the masters' edits of a map, one at a time, the last first: tokens placed, moved, changed or removed,
	///	doors opened, drawings added or erased, the terrain and the fog painted. What a token or a drawing was before the
	///	edit is kept as JSON (CampaignMapEdit); each master takes back only their own edits, the last MaxUndo of each map.
	///	The fights are not taken back (the damage, the turns): a token goes back where it was, its turn stays as it is.
	///	</summary>
	public partial class MapsController
	{
		public const int MaxUndo = 40;

		//	The edits the account can take back on the map of this request (sent with the table to the masters)
		private int undoLeft;

		//	The handout revealed last in the campaign (the players' screens open it when it is new to them)
		private HandoutShownDto? shownHandout;

		//	The handout shown to the table in place of the map (theater of the mind)
		private Guid? scene;

		private sealed record UndoItem(Guid Id, JsonElement? Values);

		private sealed record UndoItems(List<UndoItem> Items);

		private sealed record UndoTerrain(List<int> Cells, bool Blocks);

		private sealed record UndoFog(bool Enabled, List<double> Fog);

		//	POST: api/campaigns/{campaignId}/maps/{mapId}/undo — a master takes back their last edit of the map
		[HttpPost("{mapId:guid}/undo")]
		public async Task<ActionResult<MapUndoDto>> Undo(Guid campaignId, Guid mapId)
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
			var edit = await _context.CampaignMapEdits.Where(e => e.MapId == map.Id && e.UserId == UserId).OrderByDescending(e => e.At).FirstOrDefaultAsync();
			if (edit is null)
			{
				return Problem(statusCode: StatusCodes.Status409Conflict, title: "Nothing to undo.");
			}
			try
			{
				switch (edit.Kind)
				{
					case MapUndoKinds.Tokens:
						foreach (var item in JsonSerializer.Deserialize<UndoItems>(edit.Payload, GearJson)?.Items ?? new())
						{
							await RestoreTokenAsync(map, item);
						}
						break;
					case MapUndoKinds.Shapes:
						foreach (var item in JsonSerializer.Deserialize<UndoItems>(edit.Payload, GearJson)?.Items ?? new())
						{
							RestoreShape(map, item);
						}
						break;
					case MapUndoKinds.Terrain when JsonSerializer.Deserialize<UndoTerrain>(edit.Payload, GearJson) is { } terrain:
						map.Terrain = terrain.Cells;
						map.TerrainBlocks = terrain.Blocks;
						break;
					case MapUndoKinds.Fog when JsonSerializer.Deserialize<UndoFog>(edit.Payload, GearJson) is { } fog:
						map.FogEnabled = fog.Enabled;
						map.Fog = fog.Fog;
						break;
				}
			}
			catch (JsonException)
			{
				//	A step written by an older version: dropped
			}
			_context.CampaignMapEdits.Remove(edit);
			map.UpdatedAt = DateTimeOffset.UtcNow;
			await _context.SaveChangesAsync();
			var left = await _context.CampaignMapEdits.CountAsync(e => e.MapId == map.Id && e.UserId == UserId);
			return Ok(new MapUndoDto(edit.Kind, left));
		}

		// ----- Keeping the steps -----

		//	The values of a token or a drawing as JSON (all its columns but the time of its last change)
		private string ValuesOf(object entity)
		{
			var values = _context.Entry(entity).CurrentValues;
			var map = values.Properties.Where(p => p.Name != nameof(CampaignToken.UpdatedAt)).ToDictionary(p => p.Name, p => values[p]);
			return JsonSerializer.Serialize(map, GearJson);
		}

		//	What the tokens were before an edit (only a master's edits are kept)
		private Dictionary<Guid, string>? TokensBefore(CampaignMap map, CampaignRole role) =>
			CampaignRules.RunsTheTable(role) ? map.Tokens.ToDictionary(t => t.Id, t => ValuesOf(t)) : null;

		private Dictionary<Guid, string>? ShapesBefore(CampaignMap map, CampaignRole role) =>
			CampaignRules.RunsTheTable(role) ? map.Shapes.ToDictionary(s => s.Id, s => ValuesOf(s)) : null;

		//	The step of an edit of the tokens: those it changed or removed as they were, those it placed (to remove). The
		//	list is copied first: looking at a token that changed map moves it out of the map's tokens
		private Task RememberTokensAsync(CampaignMap map, Dictionary<Guid, string>? before, params CampaignToken[] placed)
		{
			if (before is null)
			{
				return Task.CompletedTask;
			}
			var items = Changed(before, map.Tokens.ToList().Where(t => _context.Entry(t).State != EntityState.Deleted).Concat(placed).DistinctBy(t => t.Id).ToDictionary(t => t.Id, t => (object)t));
			return RememberAsync(map, MapUndoKinds.Tokens, new UndoItems(items));
		}

		private Task RememberShapesAsync(CampaignMap map, Dictionary<Guid, string>? before, params CampaignMapShape[] placed)
		{
			if (before is null)
			{
				return Task.CompletedTask;
			}
			var items = Changed(before, map.Shapes.ToList().Where(s => _context.Entry(s).State != EntityState.Deleted).Concat(placed).DistinctBy(s => s.Id).ToDictionary(s => s.Id, s => (object)s));
			return RememberAsync(map, MapUndoKinds.Shapes, new UndoItems(items));
		}

		private List<UndoItem> Changed(Dictionary<Guid, string> before, Dictionary<Guid, object> now)
		{
			var items = new List<UndoItem>();
			foreach (var (id, was) in before)
			{
				if (!now.TryGetValue(id, out var entity) || ValuesOf(entity) != was)
				{
					items.Add(new UndoItem(id, JsonDocument.Parse(was).RootElement.Clone()));
				}
			}
			items.AddRange(now.Keys.Where(id => !before.ContainsKey(id)).Select(id => new UndoItem(id, null)));
			return items;
		}

		private Task RememberTerrainAsync(CampaignMap map, CampaignRole role) =>
			CampaignRules.RunsTheTable(role) ? RememberAsync(map, MapUndoKinds.Terrain, new UndoTerrain(map.Terrain.ToList(), map.TerrainBlocks)) : Task.CompletedTask;

		private Task RememberFogAsync(CampaignMap map, CampaignRole role) =>
			CampaignRules.RunsTheTable(role) ? RememberAsync(map, MapUndoKinds.Fog, new UndoFog(map.FogEnabled, map.Fog.ToList())) : Task.CompletedTask;

		//	A new step (nothing changed: none); the oldest past MaxUndo go
		private async Task RememberAsync(CampaignMap map, string kind, object payload)
		{
			if (payload is UndoItems { Items.Count: 0 })
			{
				return;
			}
			_context.CampaignMapEdits.Add(new CampaignMapEdit { MapId = map.Id, UserId = UserId, Kind = kind, Payload = JsonSerializer.Serialize(payload, GearJson) });
			var old = await _context.CampaignMapEdits.Where(e => e.MapId == map.Id && e.UserId == UserId)
				.OrderByDescending(e => e.At).Skip(MaxUndo - 1).ToListAsync();
			_context.CampaignMapEdits.RemoveRange(old);
		}

		// ----- Taking a step back -----

		private async Task RestoreTokenAsync(CampaignMap map, UndoItem item)
		{
			//	A token that went through stairs or a portal is on another map now: it comes back from there
			var token = map.Tokens.FirstOrDefault(t => t.Id == item.Id)
				?? await _context.CampaignTokens.FirstOrDefaultAsync(t => t.Id == item.Id && t.Map.CampaignId == map.CampaignId);
			if (item.Values is not { } values)
			{
				if (token is not null)
				{
					_context.CampaignTokens.Remove(token);
				}
				return;
			}
			if (token is null)
			{
				if (map.Tokens.Count >= MapRules.MaxTokens)
				{
					return;
				}
				token = new CampaignToken();
				SetValues(token, values, withKey: true);
				token.MapId = map.Id;
				_context.CampaignTokens.Add(token);
			}
			else
			{
				SetValues(token, values, withKey: false);
			}
			token.UpdatedAt = DateTimeOffset.UtcNow;
		}

		private void RestoreShape(CampaignMap map, UndoItem item)
		{
			var shape = map.Shapes.FirstOrDefault(s => s.Id == item.Id);
			if (item.Values is not { } values)
			{
				if (shape is not null)
				{
					_context.CampaignMapShapes.Remove(shape);
				}
				return;
			}
			if (shape is null)
			{
				shape = new CampaignMapShape();
				SetValues(shape, values, withKey: true);
				shape.MapId = map.Id;
				_context.CampaignMapShapes.Add(shape);
			}
			else
			{
				SetValues(shape, values, withKey: false);
			}
		}

		//	The columns written back from the JSON (those it does not have stay as they are): through the tracking of a token
		//	still there, on the object of one coming back (its key with it)
		private void SetValues(object entity, JsonElement values, bool withKey)
		{
			if (withKey)
			{
				foreach (var property in _context.Model.FindEntityType(entity.GetType())!.GetProperties())
				{
					if (property.PropertyInfo is { CanWrite: true } info && values.TryGetProperty(property.Name, out var value))
					{
						info.SetValue(entity, value.Deserialize(property.ClrType, GearJson));
					}
				}
				return;
			}
			var current = _context.Entry(entity).CurrentValues;
			foreach (var property in current.Properties)
			{
				if (property.IsPrimaryKey() || !values.TryGetProperty(property.Name, out var value))
				{
					continue;
				}
				current[property] = value.Deserialize(property.ClrType, GearJson);
			}
		}
	}
}
