using System.Net;
using System.Net.Http.Json;
using Microsoft.Extensions.Logging;
using RealmForge.Shared.DTOs;

namespace RealmForge.Client.Services
{
	///	<summary>
	///	Outcome of sharing with an e-mail: the account, or why it failed (no account, invalid address, limits…).
	///	</summary>
	public sealed record ShareResult(ShareUserDto? User, HttpStatusCode? Status);

	///	<summary>
	///	Requests shared by the Homebrew and the character sharing.
	///	</summary>
	public static class ShareRequests
	{
		public static async Task<List<ShareUserDto>?> GetUsersAsync(HttpClient http, string url, ILogger logger)
		{
			try
			{
				return await http.GetFromJsonAsync<List<ShareUserDto>>(url) ?? new List<ShareUserDto>();
			}
			catch (Exception ex)
			{
				logger.LogError(ex, "Failed to load the people of {Url}", url);
				return null;
			}
		}

		public static async Task<ShareResult> AddAsync(HttpClient http, string url, string email, ILogger logger)
		{
			try
			{
				var response = await http.PostAsJsonAsync(url, new ShareRequestDto { Email = email.Trim() });
				return response.IsSuccessStatusCode
					? new ShareResult(await response.Content.ReadFromJsonAsync<ShareUserDto>(), null)
					: new ShareResult(null, response.StatusCode);
			}
			catch (Exception ex)
			{
				logger.LogError(ex, "Failed to share {Url}", url);
				return new ShareResult(null, HttpStatusCode.ServiceUnavailable);
			}
		}

		public static async Task<bool> RemoveAsync(HttpClient http, string url, ILogger logger)
		{
			try
			{
				return (await http.DeleteAsync(url)).IsSuccessStatusCode;
			}
			catch (Exception ex)
			{
				logger.LogError(ex, "Failed to stop sharing {Url}", url);
				return false;
			}
		}
	}

	///	<summary>
	///	Client for /api/shares: the Homebrew shared with me (kept until something changes), the people an author shared an
	///	entry with, and the link-only entries I add to my collection.
	///	</summary>
	public class ShareDataService
	{
		private readonly HttpClient _http;
		private readonly ILogger<ShareDataService> _logger;
		private Task<List<SharedEntryDto>?>? _mine;

		public ShareDataService(HttpClient http, ILogger<ShareDataService> logger)
		{
			_http = http;
			_logger = logger;
		}

		public Task<List<SharedEntryDto>?> GetMineAsync() => _mine ??= FetchMineAsync();

		private async Task<List<SharedEntryDto>?> FetchMineAsync()
		{
			try
			{
				var response = await _http.GetAsync("api/shares/content/mine");
				return response.IsSuccessStatusCode ? await response.Content.ReadFromJsonAsync<List<SharedEntryDto>>() : null;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Failed to load the entries shared with me");
				return null;
			}
		}

		public Task<List<ShareUserDto>?> GetSharesAsync(Guid entityId) => ShareRequests.GetUsersAsync(_http, $"api/shares/content/{entityId}", _logger);

		public Task<ShareResult> ShareAsync(Guid entityId, string email) => ShareRequests.AddAsync(_http, $"api/shares/content/{entityId}", email, _logger);

		public Task<bool> UnshareAsync(Guid entityId, string userId) => ShareRequests.RemoveAsync(_http, $"api/shares/content/{entityId}/{Uri.EscapeDataString(userId)}", _logger);

		public async Task<bool> CollectAsync(Guid entityId)
		{
			try
			{
				var ok = (await _http.PostAsync($"api/shares/content/{entityId}/collect", null)).IsSuccessStatusCode;
				_mine = null;
				return ok;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Failed to add {EntityId} to the collection", entityId);
				return false;
			}
		}

		public async Task<bool> LeaveAsync(Guid entityId)
		{
			var ok = await UnshareAsync(entityId, "me");
			_mine = null;
			return ok;
		}
	}
}
