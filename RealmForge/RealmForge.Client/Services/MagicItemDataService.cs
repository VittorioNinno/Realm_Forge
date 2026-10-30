using System.Net;
using System.Net.Http.Json;
using Microsoft.Extensions.Logging;
using RealmForge.Shared.DTOs;
using RealmForge.Shared.Enums;

namespace RealmForge.Client.Services
{
	///	<summary>
	///	Client for /api/magic-items: list (kept in memory per language and edition, the character sheet reads it often)
	///	and detail, and the Homebrew items (create, update, delete).
	///	</summary>
	public class MagicItemDataService
	{
		private readonly HttpClient _http;
		private readonly ILogger<MagicItemDataService> _logger;
		private readonly Dictionary<(LanguageCode, RulesetVersion?), List<MagicItemResponseDto>> _lists = new();

		public MagicItemDataService(HttpClient http, ILogger<MagicItemDataService> logger)
		{
			_http = http;
			_logger = logger;
		}

		public async Task<List<MagicItemResponseDto>> GetMagicItemsAsync(LanguageCode language, RulesetVersion? ruleset = null)
		{
			if (_lists.TryGetValue((language, ruleset), out var cached))
			{
				return cached;
			}
			try
			{
				var url = $"api/magic-items?lang={(int)language}";
				if (ruleset.HasValue)
				{
					url += $"&ruleset={(int)ruleset.Value}";
				}

				var list = await _http.GetFromJsonAsync<List<MagicItemResponseDto>>(url) ?? new List<MagicItemResponseDto>();

				//	An empty answer is not kept: the next call tries again
				if (list.Count > 0)
				{
					_lists[(language, ruleset)] = list;
				}
				return list;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Failed to load magic items from API for language {Language}", language);
				return new List<MagicItemResponseDto>();
			}
		}

		public async Task<MagicItemDetailResponseDto?> GetMagicItemAsync(Guid id, LanguageCode language)
		{
			try
			{
				return await _http.GetFromJsonAsync<MagicItemDetailResponseDto>($"api/magic-items/{id}?lang={(int)language}");
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Failed to load magic item {ItemId} for language {Language}", id, language);
				return null;
			}
		}

		//	The item as the editor saves it (both languages); null when it cannot be read
		public async Task<SaveMagicItemDto?> GetForEditAsync(Guid id)
		{
			try
			{
				return await _http.GetFromJsonAsync<SaveMagicItemDto>($"api/magic-items/{id}/edit");
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Failed to load magic item {ItemId} for editing", id);
				return null;
			}
		}

		///	<summary>
		///	Creates (id null) or updates a Homebrew magic item; returns its id, or null with the status of the failure.
		///	</summary>
		public async Task<(Guid? Id, HttpStatusCode? Status)> SaveAsync(Guid? id, SaveMagicItemDto dto)
		{
			try
			{
				var response = id is { } existing
					? await _http.PutAsJsonAsync($"api/magic-items/{existing}", dto)
					: await _http.PostAsJsonAsync("api/magic-items", dto);
				if (!response.IsSuccessStatusCode)
				{
					return (null, response.StatusCode);
				}
				_lists.Clear();
				if (id is { } updated)
				{
					return (updated, null);
				}
				var created = await response.Content.ReadFromJsonAsync<MagicItemDetailResponseDto>();
				return (created?.Id, null);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Saving magic item {ItemId} failed", id);
				return (null, null);
			}
		}

		public async Task<bool> DeleteAsync(Guid id)
		{
			try
			{
				var response = await _http.DeleteAsync($"api/magic-items/{id}");
				if (response.IsSuccessStatusCode)
				{
					_lists.Clear();
				}
				return response.IsSuccessStatusCode;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Deleting magic item {ItemId} failed", id);
				return false;
			}
		}
	}
}
