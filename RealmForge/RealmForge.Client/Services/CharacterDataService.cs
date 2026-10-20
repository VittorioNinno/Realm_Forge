using System.Net.Http.Json;
using Microsoft.Extensions.Logging;
using RealmForge.Shared.Characters;
using RealmForge.Shared.DTOs;
using RealmForge.Shared.Enums;

namespace RealmForge.Client.Services
{
	///	<summary>
	///	Client for /api/characters: the rules context of an edition (kept for a few minutes), the characters of the
	///	signed-in user, creation, rules updates (edit, level up), sheet state and deletion.
	///	</summary>
	public class CharacterDataService
	{
		private static readonly TimeSpan ContextLifetime = TimeSpan.FromMinutes(5);

		private readonly HttpClient _http;
		private readonly ILogger<CharacterDataService> _logger;
		private readonly Dictionary<(RulesetVersion, LanguageCode), (DateTime Loaded, Task<CharacterContextDto?> Load)> _contexts = new();

		public CharacterDataService(HttpClient http, ILogger<CharacterDataService> logger)
		{
			_http = http;
			_logger = logger;
		}

		public Task<CharacterContextDto?> GetContextAsync(RulesetVersion ruleset, LanguageCode language, bool refresh = false)
		{
			var key = (ruleset, language);
			if (!refresh && _contexts.TryGetValue(key, out var cached) && DateTime.UtcNow - cached.Loaded < ContextLifetime
				&& (!cached.Load.IsCompleted || cached.Load.Result is not null))
			{
				return cached.Load;
			}

			var load = FetchContextAsync(ruleset, language);
			_contexts[key] = (DateTime.UtcNow, load);
			return load;
		}

		private async Task<CharacterContextDto?> FetchContextAsync(RulesetVersion ruleset, LanguageCode language)
		{
			try
			{
				return await _http.GetFromJsonAsync<CharacterContextDto>($"api/characters/context?ruleset={(int)ruleset}&lang={(int)language}");
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Failed to load the character rules for {Ruleset}", ruleset);
				return null;
			}
		}

		public async Task<List<CharacterSummaryDto>?> GetCharactersAsync(LanguageCode language)
		{
			try
			{
				return await _http.GetFromJsonAsync<List<CharacterSummaryDto>>($"api/characters?lang={(int)language}") ?? new List<CharacterSummaryDto>();
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Failed to load characters for language {Language}", language);
				return null;
			}
		}

		public async Task<CharacterDto?> GetCharacterAsync(Guid id)
		{
			try
			{
				return await _http.GetFromJsonAsync<CharacterDto>($"api/characters/{id}");
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Failed to load character {CharacterId}", id);
				return null;
			}
		}

		///	<summary>
		///	Creates (id null) or updates a character. Returns it, or the API message explaining why it was refused.
		///	</summary>
		public async Task<(CharacterDto? Character, string? Error)> SaveCharacterAsync(Guid? id, SaveCharacterDto dto)
		{
			try
			{
				var response = id is { } existing
					? await _http.PutAsJsonAsync($"api/characters/{existing}", dto)
					: await _http.PostAsJsonAsync("api/characters", dto);
				if (response.IsSuccessStatusCode)
				{
					return (await response.Content.ReadFromJsonAsync<CharacterDto>(), null);
				}

				return (null, await ReadProblemTitleAsync(response) ?? response.ReasonPhrase ?? response.StatusCode.ToString());
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error saving character");
				return (null, ex.Message);
			}
		}

		public async Task<CharacterSavedDto?> SaveSheetAsync(Guid id, CharacterSheetState sheet)
		{
			try
			{
				var response = await _http.PutAsJsonAsync($"api/characters/{id}/sheet", sheet);
				return response.IsSuccessStatusCode ? await response.Content.ReadFromJsonAsync<CharacterSavedDto>() : null;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Failed to save the sheet of character {CharacterId}", id);
				return null;
			}
		}

		public async Task<bool> DeleteCharacterAsync(Guid id)
		{
			try
			{
				var response = await _http.DeleteAsync($"api/characters/{id}");
				return response.IsSuccessStatusCode;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Failed to delete character {CharacterId}", id);
				return false;
			}
		}

		private static async Task<string?> ReadProblemTitleAsync(HttpResponseMessage response)
		{
			try
			{
				var problem = await response.Content.ReadFromJsonAsync<ProblemTitle>();
				return string.IsNullOrWhiteSpace(problem?.Title) ? null : problem.Title;
			}
			catch
			{
				return null;
			}
		}

		private sealed class ProblemTitle
		{
			public string? Title { get; set; }
		}
	}
}
