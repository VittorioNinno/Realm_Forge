using System.Net.Http.Json;
using Microsoft.Extensions.Logging;
using RealmForge.Shared.DTOs;
using RealmForge.Shared.Enums;

namespace RealmForge.Client.Services
{
	///	<summary>
	///	Client for /api/spells: list, detail and Homebrew create/update/delete.
	///	</summary>
	public class SpellDataService
	{
		private readonly HttpClient _http;
		private readonly ILogger<SpellDataService> _logger;

		public SpellDataService(HttpClient http, ILogger<SpellDataService> logger)
		{
			_http = http;
			_logger = logger;
		}

		public async Task<List<SpellResponseDto>> GetSpellsAsync(LanguageCode language, RulesetVersion? ruleset = null)
		{
			try
			{
				var url = $"api/spells?lang={(int)language}";
				if (ruleset.HasValue)
				{
					url += $"&ruleset={(int)ruleset.Value}";
				}

				return await _http.GetFromJsonAsync<List<SpellResponseDto>>(url) ?? new List<SpellResponseDto>();
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Failed to load spells from API for language {Language}", language);
				return new List<SpellResponseDto>();
			}
		}

		public async Task<SpellDetailResponseDto?> GetSpellDetailAsync(Guid id, LanguageCode language)
		{
			try
			{
				return await _http.GetFromJsonAsync<SpellDetailResponseDto>($"api/spells/{id}?lang={(int)language}");
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Failed to load spell {SpellId} for language {Language}", id, language);
				return null;
			}
		}

		public async Task<bool> CreateSpellAsync(SaveSpellDto dto)
		{
			try
			{
				var response = await _http.PostAsJsonAsync("api/spells", dto);
				return response.IsSuccessStatusCode;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error creating spell");
				return false;
			}
		}

		public async Task<bool> UpdateSpellAsync(Guid id, SaveSpellDto dto)
		{
			try
			{
				var response = await _http.PutAsJsonAsync($"api/spells/{id}", dto);
				return response.IsSuccessStatusCode;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Failed to update spell {SpellId}", id);
				return false;
			}
		}

		public async Task<bool> DeleteSpellAsync(Guid id)
		{
			try
			{
				var response = await _http.DeleteAsync($"api/spells/{id}");
				return response.IsSuccessStatusCode;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Failed to delete spell {SpellId}", id);
				return false;
			}
		}
	}
}
