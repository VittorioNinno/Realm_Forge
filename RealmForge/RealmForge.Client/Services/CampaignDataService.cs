using System.Net;
using System.Net.Http.Json;
using Microsoft.Extensions.Logging;
using RealmForge.Shared.Campaigns;
using RealmForge.Shared.DTOs;
using RealmForge.Shared.Enums;

namespace RealmForge.Client.Services
{
	///	<summary>
	///	Outcome of a campaign request: the status code when it failed (null: network error).
	///	</summary>
	public sealed record CampaignResult(bool Ok, HttpStatusCode? Status = null);

	///	<summary>
	///	Client for /api/campaigns: campaigns, invitations (e-mail and link), members and roles, characters, shared content.
	///	</summary>
	public class CampaignDataService
	{
		private readonly HttpClient _http;
		private readonly ILogger<CampaignDataService> _logger;

		public CampaignDataService(HttpClient http, ILogger<CampaignDataService> logger)
		{
			_http = http;
			_logger = logger;
		}

		private async Task<T?> GetAsync<T>(string url) where T : class
		{
			try
			{
				return await _http.GetFromJsonAsync<T>(url);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Campaign request {Url} failed", url);
				return null;
			}
		}

		private async Task<CampaignResult> SendAsync(Func<Task<HttpResponseMessage>> send, string what)
		{
			try
			{
				var response = await send();
				return new CampaignResult(response.IsSuccessStatusCode, response.IsSuccessStatusCode ? null : response.StatusCode);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Campaign request {What} failed", what);
				return new CampaignResult(false);
			}
		}

		public Task<List<CampaignSummaryDto>?> GetCampaignsAsync() => GetAsync<List<CampaignSummaryDto>>("api/campaigns");

		public Task<List<CampaignInvitationDto>?> GetInvitationsAsync() => GetAsync<List<CampaignInvitationDto>>("api/campaigns/invitations");

		public Task<CampaignDetailDto?> GetCampaignAsync(Guid id, LanguageCode lang) => GetAsync<CampaignDetailDto>($"api/campaigns/{id}?lang={(int)lang}");

		public Task<List<ShareableEntryDto>?> GetShareableAsync(Guid id, LanguageCode lang) => GetAsync<List<ShareableEntryDto>>($"api/campaigns/{id}/shareable?lang={(int)lang}");

		public Task<CampaignJoinPreviewDto?> GetJoinPreviewAsync(string code) => GetAsync<CampaignJoinPreviewDto>($"api/campaigns/join/{Uri.EscapeDataString(code)}");

		public async Task<(CampaignDetailDto? Campaign, HttpStatusCode? Status)> CreateAsync(SaveCampaignDto dto, LanguageCode lang)
		{
			try
			{
				var response = await _http.PostAsJsonAsync($"api/campaigns?lang={(int)lang}", dto);
				return response.IsSuccessStatusCode ? (await response.Content.ReadFromJsonAsync<CampaignDetailDto>(), null) : (null, response.StatusCode);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Creating a campaign failed");
				return (null, null);
			}
		}

		public Task<CampaignResult> UpdateAsync(Guid id, SaveCampaignDto dto) => SendAsync(() => _http.PutAsJsonAsync($"api/campaigns/{id}", dto), "update");

		public Task<CampaignResult> DeleteAsync(Guid id) => SendAsync(() => _http.DeleteAsync($"api/campaigns/{id}"), "delete");

		public Task<CampaignResult> InviteAsync(Guid id, string email, CampaignRole role) =>
			SendAsync(() => _http.PostAsJsonAsync($"api/campaigns/{id}/invites", new CampaignInviteRequestDto { Email = email.Trim(), Role = role }), "invite");

		public Task<CampaignResult> AcceptAsync(Guid inviteId) => SendAsync(() => _http.PostAsync($"api/campaigns/invitations/{inviteId}/accept", null), "accept");

		public Task<CampaignResult> DeleteInviteAsync(Guid inviteId) => SendAsync(() => _http.DeleteAsync($"api/campaigns/invitations/{inviteId}"), "decline");

		public Task<CampaignResult> NewInviteCodeAsync(Guid id) => SendAsync(() => _http.PostAsync($"api/campaigns/{id}/invite-code", null), "invite code");

		public Task<CampaignResult> DisableInviteCodeAsync(Guid id) => SendAsync(() => _http.DeleteAsync($"api/campaigns/{id}/invite-code"), "disable code");

		public async Task<Guid?> JoinAsync(string code)
		{
			try
			{
				var response = await _http.PostAsJsonAsync("api/campaigns/join", new CampaignJoinRequestDto { Code = code });
				return response.IsSuccessStatusCode ? await response.Content.ReadFromJsonAsync<Guid>() : null;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Joining a campaign failed");
				return null;
			}
		}

		public Task<CampaignResult> ChangeRoleAsync(Guid id, string userId, CampaignRole role) =>
			SendAsync(() => _http.PutAsJsonAsync($"api/campaigns/{id}/members/{Uri.EscapeDataString(userId)}", new CampaignRoleRequestDto { Role = role }), "role");

		public Task<CampaignResult> RemoveMemberAsync(Guid id, string userId) =>
			SendAsync(() => _http.DeleteAsync($"api/campaigns/{id}/members/{Uri.EscapeDataString(userId)}"), "remove member");

		///	<summary>
		///	Brings a character to the table. When it does not meet the campaign's requirements, Check lists the reasons.
		///	</summary>
		public async Task<(CampaignResult Result, CampaignCharacterCheckDto? Check)> AddCharacterAsync(Guid id, Guid characterId, LanguageCode lang)
		{
			try
			{
				var response = await _http.PostAsJsonAsync($"api/campaigns/{id}/characters?lang={(int)lang}", new CampaignCharacterRequestDto { CharacterId = characterId });
				if (response.StatusCode == HttpStatusCode.UnprocessableEntity)
				{
					return (new CampaignResult(false, response.StatusCode), await response.Content.ReadFromJsonAsync<CampaignCharacterCheckDto>());
				}
				return (new CampaignResult(response.IsSuccessStatusCode, response.IsSuccessStatusCode ? null : response.StatusCode), null);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Bringing a character failed");
				return (new CampaignResult(false), null);
			}
		}

		public Task<List<CampaignNoteDto>?> GetNotesAsync(Guid id) => GetAsync<List<CampaignNoteDto>>($"api/campaigns/{id}/notes");

		public Task<CampaignResult> AddNoteAsync(Guid id, SaveCampaignNoteDto note) =>
			SendAsync(() => _http.PostAsJsonAsync($"api/campaigns/{id}/notes", note), "add note");

		public Task<CampaignResult> UpdateNoteAsync(Guid id, Guid noteId, SaveCampaignNoteDto note) =>
			SendAsync(() => _http.PutAsJsonAsync($"api/campaigns/{id}/notes/{noteId}", note), "update note");

		public Task<CampaignResult> DeleteNoteAsync(Guid id, Guid noteId) =>
			SendAsync(() => _http.DeleteAsync($"api/campaigns/{id}/notes/{noteId}"), "delete note");

		public Task<CampaignResult> RemoveCharacterAsync(Guid id, Guid characterId) =>
			SendAsync(() => _http.DeleteAsync($"api/campaigns/{id}/characters/{characterId}"), "remove character");

		public Task<CampaignResult> SetCharacterActiveAsync(Guid id, Guid characterId, bool active) =>
			SendAsync(() => _http.PutAsJsonAsync($"api/campaigns/{id}/characters/{characterId}/active", new CampaignCharacterActiveDto { Active = active }), "set character active");

		public Task<CampaignResult> ShareAsync(Guid id, Guid entityId) =>
			SendAsync(() => _http.PostAsJsonAsync($"api/campaigns/{id}/contents", new CampaignContentRequestDto { EntityId = entityId }), "share");

		public Task<CampaignResult> ApproveAsync(Guid id, Guid entityId) =>
			SendAsync(() => _http.PostAsync($"api/campaigns/{id}/contents/{entityId}/approve", null), "approve");

		public Task<CampaignResult> RemoveContentAsync(Guid id, Guid entityId) =>
			SendAsync(() => _http.DeleteAsync($"api/campaigns/{id}/contents/{entityId}"), "remove content");

		// ===== Sessions =====

		public Task<List<CampaignSessionDto>?> GetSessionsAsync(Guid id) => GetAsync<List<CampaignSessionDto>>($"api/campaigns/{id}/sessions");

		public Task<CampaignResult> SaveSessionAsync(Guid id, Guid? sessionId, SaveCampaignSessionDto session) =>
			SendAsync(() => sessionId is { } existing
				? _http.PutAsJsonAsync($"api/campaigns/{id}/sessions/{existing}", session)
				: _http.PostAsJsonAsync($"api/campaigns/{id}/sessions", session), "save session");

		public Task<CampaignResult> DeleteSessionAsync(Guid id, Guid sessionId) =>
			SendAsync(() => _http.DeleteAsync($"api/campaigns/{id}/sessions/{sessionId}"), "delete session");

		// ===== Dice log =====

		public Task<List<CampaignRollDto>?> GetRollsAsync(Guid id, DateTimeOffset? after = null, bool wait = false) =>
			GetAsync<List<CampaignRollDto>>($"api/campaigns/{id}/rolls" + (after is { } since ? $"?after={Uri.EscapeDataString(since.ToUniversalTime().ToString("O"))}{(wait ? "&wait=true" : string.Empty)}" : string.Empty));

		public async Task<(CampaignRollDto? Roll, HttpStatusCode? Status)> RollAsync(Guid id, NewCampaignRollDto roll)
		{
			try
			{
				var response = await _http.PostAsJsonAsync($"api/campaigns/{id}/rolls", roll);
				return response.IsSuccessStatusCode ? (await response.Content.ReadFromJsonAsync<CampaignRollDto>(), null) : (null, response.StatusCode);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Rolling in campaign {CampaignId} failed", id);
				return (null, null);
			}
		}

		public async Task<CampaignRollDto?> RevealRollAsync(Guid id, Guid rollId)
		{
			try
			{
				var response = await _http.PostAsync($"api/campaigns/{id}/rolls/{rollId}/reveal", null);
				return response.IsSuccessStatusCode ? await response.Content.ReadFromJsonAsync<CampaignRollDto>() : null;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Revealing roll {RollId} failed", rollId);
				return null;
			}
		}

		// ===== Virtual tabletop =====

		public Task<List<CampaignMapSummaryDto>?> GetMapsAsync(Guid id) => GetAsync<List<CampaignMapSummaryDto>>($"api/campaigns/{id}/maps");

		public Task<CampaignMapDto?> GetMapAsync(Guid id, Guid mapId) => GetAsync<CampaignMapDto>($"api/campaigns/{id}/maps/{mapId}");

		public Task<MapStateDto?> GetMapStateAsync(Guid id, Guid mapId) => GetAsync<MapStateDto>($"api/campaigns/{id}/maps/{mapId}/state");

		//	The state of a map as soon as it changes after a moment (the API waits up to 20 seconds). Reached false: the
		//	API did not answer (try again a bit later); a null state that was reached: the map is gone or hidden.
		public async Task<(MapStateDto? State, bool Reached)> WaitMapStateAsync(Guid id, Guid mapId, DateTimeOffset after, CancellationToken cancel)
		{
			try
			{
				var response = await _http.GetAsync($"api/campaigns/{id}/maps/{mapId}/state?after={Uri.EscapeDataString(after.ToString("O"))}", cancel);
				if (response.StatusCode is System.Net.HttpStatusCode.NotFound or System.Net.HttpStatusCode.Forbidden)
				{
					return (null, true);
				}
				return response.IsSuccessStatusCode ? (await response.Content.ReadFromJsonAsync<MapStateDto>(cancel), true) : (null, false);
			}
			catch (OperationCanceledException)
			{
				throw;
			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex, "Waiting for map {MapId} failed", mapId);
				return (null, false);
			}
		}

		public async Task<CampaignMapSummaryDto?> CreateMapAsync(Guid id, SaveMapDto map)
		{
			try
			{
				var response = await _http.PostAsJsonAsync($"api/campaigns/{id}/maps", map);
				return response.IsSuccessStatusCode ? await response.Content.ReadFromJsonAsync<CampaignMapSummaryDto>() : null;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Creating a map in campaign {CampaignId} failed", id);
				return null;
			}
		}

		public Task<CampaignResult> UpdateMapAsync(Guid id, Guid mapId, SaveMapDto map) =>
			SendAsync(() => _http.PutAsJsonAsync($"api/campaigns/{id}/maps/{mapId}", map), "update map");

		public async Task<CampaignMapSummaryDto?> DuplicateMapAsync(Guid id, Guid mapId, string name)
		{
			try
			{
				var response = await _http.PostAsync($"api/campaigns/{id}/maps/{mapId}/duplicate?name={Uri.EscapeDataString(name)}", null);
				return response.IsSuccessStatusCode ? await response.Content.ReadFromJsonAsync<CampaignMapSummaryDto>() : null;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Duplicating map {MapId} failed", mapId);
				return null;
			}
		}

		//	The map the players see at the table (the others are hidden from them)
		public Task<CampaignResult> DisplayMapAsync(Guid id, Guid mapId) =>
			SendAsync(() => _http.PostAsync($"api/campaigns/{id}/maps/{mapId}/display", null), "display map");

		public Task<CampaignResult> DeleteMapAsync(Guid id, Guid mapId) =>
			SendAsync(() => _http.DeleteAsync($"api/campaigns/{id}/maps/{mapId}"), "delete map");

		public async Task<MapTokenDto?> AddTokenAsync(Guid id, Guid mapId, SaveTokenDto token)
		{
			try
			{
				var response = await _http.PostAsJsonAsync($"api/campaigns/{id}/maps/{mapId}/tokens", token);
				return response.IsSuccessStatusCode ? await response.Content.ReadFromJsonAsync<MapTokenDto>() : null;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Adding a token to map {MapId} failed", mapId);
				return null;
			}
		}

		public Task<CampaignResult> UpdateTokenAsync(Guid id, Guid mapId, Guid tokenId, SaveTokenDto token) =>
			SendAsync(() => _http.PutAsJsonAsync($"api/campaigns/{id}/maps/{mapId}/tokens/{tokenId}", token), "update token");

		public Task<CampaignResult> MoveTokenAsync(Guid id, Guid mapId, Guid tokenId, int x, int y) =>
			SendAsync(() => _http.PostAsJsonAsync($"api/campaigns/{id}/maps/{mapId}/tokens/{tokenId}/move", new MoveTokenDto { X = x, Y = y }), "move token");

		public Task<CampaignResult> DeleteTokenAsync(Guid id, Guid mapId, Guid tokenId) =>
			SendAsync(() => _http.DeleteAsync($"api/campaigns/{id}/maps/{mapId}/tokens/{tokenId}"), "delete token");

		public async Task<MapShapeDto?> AddShapeAsync(Guid id, Guid mapId, SaveShapeDto shape)
		{
			try
			{
				var response = await _http.PostAsJsonAsync($"api/campaigns/{id}/maps/{mapId}/shapes", shape);
				return response.IsSuccessStatusCode ? await response.Content.ReadFromJsonAsync<MapShapeDto>() : null;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Drawing on map {MapId} failed", mapId);
				return null;
			}
		}

		public async Task<MapShapeDto?> MoveShapeAsync(Guid id, Guid mapId, Guid shapeId, List<double> points)
		{
			try
			{
				var response = await _http.PutAsJsonAsync($"api/campaigns/{id}/maps/{mapId}/shapes/{shapeId}/move", new MoveShapeDto { Points = points });
				return response.IsSuccessStatusCode ? await response.Content.ReadFromJsonAsync<MapShapeDto>() : null;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Moving a text on map {MapId} failed", mapId);
				return null;
			}
		}

		// ===== The table open now =====

		public Task<List<CampaignLiveTableDto>?> GetLiveTablesAsync() => GetAsync<List<CampaignLiveTableDto>>("api/campaigns/live");

		public async Task<CampaignLiveTableDto?> OpenTableAsync(Guid id)
		{
			try
			{
				var response = await _http.PostAsync($"api/campaigns/{id}/table", null);
				return response.IsSuccessStatusCode ? await response.Content.ReadFromJsonAsync<CampaignLiveTableDto>() : null;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Opening the table of campaign {CampaignId} failed", id);
				return null;
			}
		}

		public Task<CampaignResult> CloseTableAsync(Guid id) =>
			SendAsync(() => _http.DeleteAsync($"api/campaigns/{id}/table"), "close table");

		public Task<CampaignResult> DeleteShapeAsync(Guid id, Guid mapId, Guid shapeId) =>
			SendAsync(() => _http.DeleteAsync($"api/campaigns/{id}/maps/{mapId}/shapes/{shapeId}"), "delete shape");

		public Task<CampaignResult> ClearShapesAsync(Guid id, Guid mapId) =>
			SendAsync(() => _http.DeleteAsync($"api/campaigns/{id}/maps/{mapId}/shapes"), "clear shapes");

		public Task<CampaignResult> SaveFogAsync(Guid id, Guid mapId, bool enabled, List<double> fog) =>
			SendAsync(() => _http.PutAsJsonAsync($"api/campaigns/{id}/maps/{mapId}/fog", new SaveFogDto { Enabled = enabled, Fog = fog }), "save fog");

		public async Task<MapTerrainDto?> SaveTerrainAsync(Guid id, Guid mapId, SaveTerrainDto terrain)
		{
			try
			{
				var response = await _http.PutAsJsonAsync($"api/campaigns/{id}/maps/{mapId}/terrain", terrain);
				return response.IsSuccessStatusCode ? await response.Content.ReadFromJsonAsync<MapTerrainDto>() : null;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Saving the terrain of map {MapId} failed", mapId);
				return null;
			}
		}

		public Task<CampaignResult> LockPlayersAsync(Guid id, Guid mapId, bool locked) =>
			SendAsync(() => _http.PutAsJsonAsync($"api/campaigns/{id}/maps/{mapId}/lock", new PlayersLockDto { Locked = locked }), "lock players");

		public Task<CampaignResult> SetTokenExtrasAsync(Guid id, Guid mapId, Guid tokenId, List<string> conditions, bool? showHp, int? armorClass) =>
			SendAsync(() => _http.PutAsJsonAsync($"api/campaigns/{id}/maps/{mapId}/tokens/{tokenId}/state", new TokenStateDto { Conditions = conditions, ShowHp = showHp, ArmorClass = armorClass }), "token extras");

		//	A request of the table that may be refused with a reason (out of reach, the action already used): the reason
		private async Task<(T? Value, string? Error)> TableAsync<T>(Func<Task<HttpResponseMessage>> send, string what)
		{
			try
			{
				var response = await send();
				if (response.IsSuccessStatusCode)
				{
					return (response.StatusCode == HttpStatusCode.NoContent || typeof(T) == typeof(bool) ? default : await response.Content.ReadFromJsonAsync<T>(), null);
				}
				string? title = null;
				try
				{
					title = (await response.Content.ReadFromJsonAsync<System.Text.Json.JsonElement>()).TryGetProperty("title", out var t) ? t.GetString() : null;
				}
				catch (Exception)
				{
					title = null;
				}
				return (default, response.StatusCode == HttpStatusCode.Conflict && !string.IsNullOrWhiteSpace(title) ? title : string.Empty);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Table request {What} failed", what);
				return (default, string.Empty);
			}
		}

		public Task<(MapAttackResultDto? Value, string? Error)> AttackAsync(Guid id, Guid mapId, MapAttackDto dto, LanguageCode lang) =>
			TableAsync<MapAttackResultDto>(() => _http.PostAsJsonAsync($"api/campaigns/{id}/maps/{mapId}/attack?lang={(int)lang}", dto), "attack");

		public Task<(MapTokenDto? Value, string? Error)> DropItemAsync(Guid id, Guid mapId, Guid tokenId, DropItemDto dto) =>
			TableAsync<MapTokenDto>(() => _http.PostAsJsonAsync($"api/campaigns/{id}/maps/{mapId}/tokens/{tokenId}/drop", dto), "drop item");

		public async Task<string?> TakeItemAsync(Guid id, Guid mapId, Guid tokenId, Guid byTokenId, int index, LanguageCode lang, bool equip = false) =>
			(await TableAsync<bool>(() => _http.PostAsJsonAsync($"api/campaigns/{id}/maps/{mapId}/tokens/{tokenId}/take?lang={(int)lang}", new TakeItemDto { ByTokenId = byTokenId, Index = index, Equip = equip }), "take item")).Error;

		public Task<CampaignResult> SaveLootAsync(Guid id, Guid mapId, Guid tokenId, SaveLootDto dto) =>
			SendAsync(() => _http.PutAsJsonAsync($"api/campaigns/{id}/maps/{mapId}/tokens/{tokenId}/loot", dto), "save loot");

		public Task<CampaignResult> PingAsync(Guid id, Guid mapId, double x, double y) =>
			SendAsync(() => _http.PostAsJsonAsync($"api/campaigns/{id}/maps/{mapId}/ping", new MapPointDto { X = x, Y = y }), "ping");

		public Task<CampaignResult> FocusAsync(Guid id, Guid mapId, double x, double y, double zoom) =>
			SendAsync(() => _http.PostAsJsonAsync($"api/campaigns/{id}/maps/{mapId}/focus", new MapPointDto { X = x, Y = y, Zoom = zoom }), "focus");

		public Task<CampaignResult> StartCombatAsync(Guid id, Guid mapId, Guid encounterId) =>
			SendAsync(() => _http.PostAsJsonAsync($"api/campaigns/{id}/maps/{mapId}/combat", new StartCombatDto { EncounterId = encounterId }), "start combat");

		public Task<CampaignResult> NextTurnAsync(Guid id, Guid mapId) =>
			SendAsync(() => _http.PostAsync($"api/campaigns/{id}/maps/{mapId}/combat/next", null), "next turn");

		public Task<CampaignResult> EndCombatAsync(Guid id, Guid mapId) =>
			SendAsync(() => _http.PostAsync($"api/campaigns/{id}/maps/{mapId}/combat/end", null), "end combat");

		public Task<CampaignResult> SetTokenStateAsync(Guid id, Guid mapId, Guid tokenId, List<string> conditions, int? hp, int? tempHp = null, int? maxHp = null) =>
			SendAsync(() => _http.PutAsJsonAsync($"api/campaigns/{id}/maps/{mapId}/tokens/{tokenId}/state", new TokenStateDto { Conditions = conditions, Hp = hp, TempHp = tempHp, MaxHp = maxHp }), "token state");

		public Task<CampaignResult> HideMapAsync(Guid id, Guid mapId) =>
			SendAsync(() => _http.DeleteAsync($"api/campaigns/{id}/maps/{mapId}/display"), "hide map");

		public Task<CampaignResult> BeginCombatAsync(Guid id, Guid mapId) =>
			SendAsync(() => _http.PostAsync($"api/campaigns/{id}/maps/{mapId}/combat/begin", null), "begin combat");

		public Task<CampaignResult> PreviousTurnAsync(Guid id, Guid mapId) =>
			SendAsync(() => _http.PostAsync($"api/campaigns/{id}/maps/{mapId}/combat/previous", null), "previous turn");

		public Task<CampaignResult> ShowCombatHealthAsync(Guid id, Guid mapId, bool show) =>
			SendAsync(() => _http.PutAsJsonAsync($"api/campaigns/{id}/maps/{mapId}/combat/health", new CombatHealthDto { Show = show }), "combat health");

		public Task<CampaignResult> EraseAreaAsync(Guid id, Guid mapId, double x, double y, double width, double height) =>
			SendAsync(() => _http.PostAsJsonAsync($"api/campaigns/{id}/maps/{mapId}/shapes/erase", new EraseAreaDto { X = x, Y = y, Width = width, Height = height }), "erase area");

		public Task<CampaignResult> QuickCombatAsync(Guid id, Guid mapId, List<Guid> tokenIds) =>
			SendAsync(() => _http.PostAsJsonAsync($"api/campaigns/{id}/maps/{mapId}/combat/quick", new QuickCombatDto { TokenIds = tokenIds }), "quick combat");

		public Task<CampaignResult> JoinFightAsync(Guid id, Guid mapId, Guid tokenId) =>
			SendAsync(() => _http.PostAsync($"api/campaigns/{id}/maps/{mapId}/combat/tokens/{tokenId}", null), "join fight");

		public Task<CampaignResult> LeaveFightAsync(Guid id, Guid mapId, Guid tokenId) =>
			SendAsync(() => _http.DeleteAsync($"api/campaigns/{id}/maps/{mapId}/combat/tokens/{tokenId}"), "leave fight");

		public Task<CampaignResult> SetInitiativeAsync(Guid id, Guid mapId, Guid combatantId, int initiative) =>
			SendAsync(() => _http.PutAsJsonAsync($"api/campaigns/{id}/maps/{mapId}/combat/initiative", new SetInitiativeDto { CombatantId = combatantId, Initiative = initiative }), "initiative");

		//	Opens or closes an object; Stuck: it is locked or barred
		public async Task<(MapTokenDto? Token, bool Stuck)> InteractAsync(Guid id, Guid mapId, Guid tokenId)
		{
			try
			{
				var response = await _http.PostAsync($"api/campaigns/{id}/maps/{mapId}/tokens/{tokenId}/interact", null);
				if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
				{
					return (null, true);
				}
				return response.IsSuccessStatusCode ? (await response.Content.ReadFromJsonAsync<MapTokenDto>(), false) : (null, false);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Using object {TokenId} failed", tokenId);
				return (null, false);
			}
		}

		public Task<CampaignResult> ClearRollsAsync(Guid id) =>
			SendAsync(() => _http.DeleteAsync($"api/campaigns/{id}/rolls"), "clear rolls");
	}
}
