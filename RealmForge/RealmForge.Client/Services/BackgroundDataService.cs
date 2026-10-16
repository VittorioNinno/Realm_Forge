using System.Net.Http.Json;
using Microsoft.Extensions.Logging;
using RealmForge.Shared.DTOs;
using RealmForge.Shared.Enums;

namespace RealmForge.Client.Services
{
	public class BackgroundDataService
	{
		private readonly HttpClient _http;
		private readonly ILogger<BackgroundDataService> _logger;

		public BackgroundDataService(HttpClient http, ILogger<BackgroundDataService> logger)
		{
			_http = http;
			_logger = logger;
		}

		public async Task<List<BackgroundResponseDto>> GetBackgroundsAsync(LanguageCode language, RulesetVersion? ruleset = null)
		{
			try
			{
				var url = $"api/backgrounds?lang={(int)language}";
				if (ruleset.HasValue)
				{
					url += $"&ruleset={(int)ruleset.Value}";
				}

				return await _http.GetFromJsonAsync<List<BackgroundResponseDto>>(url) ?? new List<BackgroundResponseDto>();
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Failed to load backgrounds for language {Language}", language);
				return new List<BackgroundResponseDto>();
			}
		}

		public async Task<BackgroundDetailResponseDto?> GetBackgroundAsync(Guid id, LanguageCode language)
		{
			try
			{
				return await _http.GetFromJsonAsync<BackgroundDetailResponseDto>($"api/backgrounds/{id}?lang={(int)language}");
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Failed to load background {BackgroundId}", id);
				return null;
			}
		}

		public async Task<bool> CreateAsync(SaveBackgroundDto dto)
		{
			try
			{
				var response = await _http.PostAsJsonAsync("api/backgrounds", dto);
				return response.IsSuccessStatusCode;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Failed to create background");
				return false;
			}
		}

		public async Task<bool> UpdateAsync(Guid id, SaveBackgroundDto dto)
		{
			try
			{
				var response = await _http.PutAsJsonAsync($"api/backgrounds/{id}", dto);
				return response.IsSuccessStatusCode;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Failed to update background {BackgroundId}", id);
				return false;
			}
		}

		public async Task<bool> DeleteAsync(Guid id)
		{
			try
			{
				var response = await _http.DeleteAsync($"api/backgrounds/{id}");
				return response.IsSuccessStatusCode;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Failed to delete background {BackgroundId}", id);
				return false;
			}
		}
	}
}
