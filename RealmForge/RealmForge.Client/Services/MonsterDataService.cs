using System.Net;
using System.Net.Http.Json;
using Microsoft.Extensions.Logging;
using RealmForge.Shared.DTOs;
using RealmForge.Shared.Enums;

namespace RealmForge.Client.Services
{
	///	<summary>
	///	Client for /api/monsters: list (kept in memory per language and edition, the encounter builder reads it often),
	///	statblock, and Homebrew create/update/delete (which empty the cache).
	///	</summary>
	public class MonsterDataService
	{
		private readonly HttpClient _http;
		private readonly ILogger<MonsterDataService> _logger;
		private readonly Dictionary<(LanguageCode, RulesetVersion?), List<MonsterResponseDto>> _lists = new();

		public MonsterDataService(HttpClient http, ILogger<MonsterDataService> logger)
		{
			_http = http;
			_logger = logger;
		}

		public async Task<List<MonsterResponseDto>> GetMonstersAsync(LanguageCode language, RulesetVersion? ruleset = null)
		{
			if (_lists.TryGetValue((language, ruleset), out var cached))
			{
				return cached;
			}
			try
			{
				var url = $"api/monsters?lang={(int)language}";
				if (ruleset.HasValue)
				{
					url += $"&ruleset={(int)ruleset.Value}";
				}
				var list = await _http.GetFromJsonAsync<List<MonsterResponseDto>>(url) ?? new List<MonsterResponseDto>();

				//	An empty answer is not kept: the next call tries again
				if (list.Count > 0)
				{
					_lists[(language, ruleset)] = list;
				}
				return list;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Failed to load monsters for language {Language}", language);
				return new List<MonsterResponseDto>();
			}
		}

		public async Task<MonsterDetailDto?> GetMonsterAsync(Guid id, LanguageCode language)
		{
			try
			{
				return await _http.GetFromJsonAsync<MonsterDetailDto>($"api/monsters/{id}?lang={(int)language}");
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Failed to load monster {MonsterId}", id);
				return null;
			}
		}

		///	<summary>
		///	Creates (id null) or updates a Homebrew monster; returns its id, or null with the status of the failure.
		///	</summary>
		public async Task<(Guid? Id, HttpStatusCode? Status)> SaveAsync(Guid? id, SaveMonsterDto dto)
		{
			try
			{
				var response = id is { } existing
					? await _http.PutAsJsonAsync($"api/monsters/{existing}", dto)
					: await _http.PostAsJsonAsync("api/monsters", dto);
				if (!response.IsSuccessStatusCode)
				{
					return (null, response.StatusCode);
				}
				_lists.Clear();
				if (id is { } updated)
				{
					return (updated, null);
				}
				var created = await response.Content.ReadFromJsonAsync<MonsterDetailDto>();
				return (created?.Id, null);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Saving monster {MonsterId} failed", id);
				return (null, null);
			}
		}

		public async Task<bool> DeleteAsync(Guid id)
		{
			try
			{
				var response = await _http.DeleteAsync($"api/monsters/{id}");
				if (response.IsSuccessStatusCode)
				{
					_lists.Clear();
				}
				return response.IsSuccessStatusCode;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Deleting monster {MonsterId} failed", id);
				return false;
			}
		}
	}
}
