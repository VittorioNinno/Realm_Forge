using System.Net;
using System.Net.Http.Json;
using Microsoft.Extensions.Logging;
using RealmForge.Shared.DTOs;
using RealmForge.Shared.Enums;

namespace RealmForge.Client.Services
{
	///	<summary>
	///	Client for /api/admin (figures, accounts, Homebrew moderation) and for the global search of the compendium.
	///	</summary>
	public class AdminDataService
	{
		private readonly HttpClient _http;
		private readonly ILogger<AdminDataService> _logger;

		public AdminDataService(HttpClient http, ILogger<AdminDataService> logger)
		{
			_http = http;
			_logger = logger;
		}

		private async Task<(T? Value, HttpStatusCode? Status)> GetAsync<T>(string url) where T : class
		{
			try
			{
				var response = await _http.GetAsync(url);
				return response.IsSuccessStatusCode ? (await response.Content.ReadFromJsonAsync<T>(), null) : (null, response.StatusCode);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Request {Url} failed", url);
				return (null, null);
			}
		}

		private async Task<HttpStatusCode?> SendAsync(Func<Task<HttpResponseMessage>> send, string what)
		{
			try
			{
				var response = await send();
				return response.IsSuccessStatusCode ? null : response.StatusCode;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Admin request {What} failed", what);
				return HttpStatusCode.ServiceUnavailable;
			}
		}

		public Task<(AdminStatsDto? Value, HttpStatusCode? Status)> GetStatsAsync() => GetAsync<AdminStatsDto>("api/admin/stats");

		public Task<(List<AdminUserDto>? Value, HttpStatusCode? Status)> GetUsersAsync(string? query) =>
			GetAsync<List<AdminUserDto>>("api/admin/users" + (string.IsNullOrWhiteSpace(query) ? string.Empty : $"?q={Uri.EscapeDataString(query.Trim())}"));

		public Task<(List<AdminHomebrewDto>? Value, HttpStatusCode? Status)> GetHomebrewAsync(ContentVisibility? visibility, LanguageCode lang) =>
			GetAsync<List<AdminHomebrewDto>>($"api/admin/homebrew?lang={(int)lang}" + (visibility is { } v ? $"&visibility={(int)v}" : string.Empty));

		//	null when it worked, otherwise the status of the failure
		public Task<HttpStatusCode?> LockAsync(string userId, int days) =>
			SendAsync(() => _http.PutAsJsonAsync($"api/admin/users/{Uri.EscapeDataString(userId)}/lock", new AdminLockDto { Days = days }), "lock");

		public Task<HttpStatusCode?> DeleteUserAsync(string userId) =>
			SendAsync(() => _http.DeleteAsync($"api/admin/users/{Uri.EscapeDataString(userId)}"), "delete user");

		public Task<HttpStatusCode?> SetVisibilityAsync(Guid id, ContentVisibility visibility) =>
			SendAsync(() => _http.PutAsJsonAsync($"api/admin/homebrew/{id}/visibility", new AdminVisibilityDto { Visibility = visibility }), "visibility");

		private static string KindsQuery(IReadOnlyCollection<string>? kinds) =>
			kinds is { Count: > 0 } ? $"&kinds={Uri.EscapeDataString(string.Join(',', kinds))}" : string.Empty;

		public async Task<SearchResultDto?> RandomAsync(LanguageCode lang, IReadOnlyCollection<string>? kinds = null)
		{
			try
			{
				return await _http.GetFromJsonAsync<SearchResultDto>($"api/compendium/random?lang={(int)lang}{KindsQuery(kinds)}");
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Random entry failed");
				return null;
			}
		}

		public async Task<List<CompendiumSectionCountDto>?> CountsAsync()
		{
			try
			{
				return await _http.GetFromJsonAsync<List<CompendiumSectionCountDto>>("api/compendium/counts");
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Compendium counts failed");
				return null;
			}
		}

		public async Task<List<SearchResultDto>?> SearchAsync(string text, LanguageCode lang, IReadOnlyCollection<string>? kinds = null, CancellationToken token = default)
		{
			try
			{
				return await _http.GetFromJsonAsync<List<SearchResultDto>>(
					$"api/compendium/search?q={Uri.EscapeDataString(text.Trim())}&lang={(int)lang}{KindsQuery(kinds)}", token);
			}
			catch (OperationCanceledException)
			{
				return null;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Search failed");
				return null;
			}
		}
	}
}
