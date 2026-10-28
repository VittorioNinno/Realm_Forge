using System.Net.Http.Json;
using Microsoft.Extensions.Logging;
using RealmForge.Shared.DTOs;
using RealmForge.Shared.Enums;

namespace RealmForge.Client.Services
{
	///	<summary>
	///	Client for /api/magic-items: list (kept in memory per language and edition, the character sheet reads it often)
	///	and detail.
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
	}
}
