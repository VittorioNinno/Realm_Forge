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

		public Task<List<CampaignRollDto>?> GetRollsAsync(Guid id, DateTimeOffset? after = null) =>
			GetAsync<List<CampaignRollDto>>($"api/campaigns/{id}/rolls" + (after is { } since ? $"?after={Uri.EscapeDataString(since.ToUniversalTime().ToString("O"))}" : string.Empty));

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

		public Task<CampaignResult> ClearRollsAsync(Guid id) =>
			SendAsync(() => _http.DeleteAsync($"api/campaigns/{id}/rolls"), "clear rolls");
	}
}
