using System.Net.Http.Json;
using Microsoft.Extensions.Logging;
using RealmForge.Shared.DTOs;
using RealmForge.Shared.Enums;

namespace RealmForge.Client.Services
{
	///	<summary>
	///	Client for /api/equipment: list, detail and Homebrew create/update/delete.
	///	</summary>
	public class EquipmentDataService
	{
		private readonly HttpClient _http;
		private readonly ILogger<EquipmentDataService> _logger;

		public EquipmentDataService(HttpClient http, ILogger<EquipmentDataService> logger)
		{
			_http = http;
			_logger = logger;
		}

		public async Task<List<EquipmentResponseDto>> GetEquipmentAsync(LanguageCode language, RulesetVersion? ruleset = null)
		{
			try
			{
				var url = $"api/equipment?lang={(int)language}";
				if (ruleset.HasValue)
				{
					url += $"&ruleset={(int)ruleset.Value}";
				}

				return await _http.GetFromJsonAsync<List<EquipmentResponseDto>>(url) ?? new List<EquipmentResponseDto>();
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Failed to load equipment from API for language {Language}", language);
				return new List<EquipmentResponseDto>();
			}
		}

		public async Task<EquipmentDetailResponseDto?> GetItemAsync(Guid id, LanguageCode language)
		{
			try
			{
				return await _http.GetFromJsonAsync<EquipmentDetailResponseDto>($"api/equipment/{id}?lang={(int)language}");
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Failed to load item {ItemId} for language {Language}", id, language);
				return null;
			}
		}

		public async Task<bool> CreateItemAsync(SaveEquipmentDto dto)
		{
			try
			{
				var response = await _http.PostAsJsonAsync("api/equipment", dto);
				return response.IsSuccessStatusCode;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error creating item");
				return false;
			}
		}

		public async Task<bool> UpdateItemAsync(Guid id, SaveEquipmentDto dto)
		{
			try
			{
				var response = await _http.PutAsJsonAsync($"api/equipment/{id}", dto);
				return response.IsSuccessStatusCode;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Failed to update item {ItemId}", id);
				return false;
			}
		}

		public async Task<bool> DeleteItemAsync(Guid id)
		{
			try
			{
				var response = await _http.DeleteAsync($"api/equipment/{id}");
				return response.IsSuccessStatusCode;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Failed to delete item {ItemId}", id);
				return false;
			}
		}
	}
}
