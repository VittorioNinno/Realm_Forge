using System.Net.Http.Json;
using Microsoft.Extensions.Logging;
using RealmForge.Shared.DTOs;
using RealmForge.Shared.Enums;

namespace RealmForge.Client.Services
{
	///	<summary>
	///	Client for /api/characters: the characters of the signed-in user (list, sheet, creation and deletion).
	///	</summary>
	public class CharacterDataService
	{
		private readonly HttpClient _http;
		private readonly ILogger<CharacterDataService> _logger;

		public CharacterDataService(HttpClient http, ILogger<CharacterDataService> logger)
		{
			_http = http;
			_logger = logger;
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

		public async Task<CharacterDetailDto?> GetCharacterAsync(Guid id, LanguageCode language)
		{
			try
			{
				return await _http.GetFromJsonAsync<CharacterDetailDto>($"api/characters/{id}?lang={(int)language}");
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Failed to load character {CharacterId}", id);
				return null;
			}
		}

		///	<summary>
		///	Saves a new character. Returns its id, or the API message explaining why the choices were refused.
		///	</summary>
		public async Task<(Guid? Id, string? Error)> CreateCharacterAsync(SaveCharacterDto dto)
		{
			try
			{
				var response = await _http.PostAsJsonAsync("api/characters", dto);
				if (response.IsSuccessStatusCode)
				{
					var created = await response.Content.ReadFromJsonAsync<CharacterSummaryDto>();
					return (created?.Id, null);
				}

				var problem = await ReadProblemTitleAsync(response);
				return (null, problem ?? response.ReasonPhrase ?? response.StatusCode.ToString());
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error creating character");
				return (null, ex.Message);
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
