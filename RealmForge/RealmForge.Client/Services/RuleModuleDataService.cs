using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using RealmForge.Shared.DTOs;
using RealmForge.Shared.Enums;

namespace RealmForge.Client.Services
{
	///	<summary>
	///	Client for /api/modules: the Homebrew rule modules (list, detail, create, update, delete).
	///	</summary>
	public class RuleModuleDataService
	{
		private readonly HttpClient _http;
		private readonly ILogger<RuleModuleDataService> _logger;

		public RuleModuleDataService(HttpClient http, ILogger<RuleModuleDataService> logger)
		{
			_http = http;
			_logger = logger;
		}

		//	The result of a save: the error code of the effects (RuleEffectRules.Validate) when the API refuses them
		public sealed record SaveResult(bool Ok, string? Code = null);

		public async Task<List<RuleModuleResponseDto>> GetModulesAsync(LanguageCode language)
		{
			try
			{
				return await _http.GetFromJsonAsync<List<RuleModuleResponseDto>>($"api/modules?lang={(int)language}") ?? new();
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Failed to load the rule modules");
				return new();
			}
		}

		public async Task<RuleModuleDetailDto?> GetModuleAsync(Guid id, LanguageCode language)
		{
			try
			{
				return await _http.GetFromJsonAsync<RuleModuleDetailDto>($"api/modules/{id}?lang={(int)language}");
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Failed to load the rule module {Id}", id);
				return null;
			}
		}

		public async Task<SaveResult> SaveAsync(Guid? id, SaveRuleModuleDto dto)
		{
			try
			{
				var response = id is { } existing
					? await _http.PutAsJsonAsync($"api/modules/{existing}", dto)
					: await _http.PostAsJsonAsync("api/modules", dto);
				if (response.IsSuccessStatusCode)
				{
					return new SaveResult(true);
				}
				string? code = null;
				try
				{
					using var problem = JsonDocument.Parse(await response.Content.ReadAsStringAsync());
					if (problem.RootElement.TryGetProperty("detail", out var detail) && detail.ValueKind == JsonValueKind.String)
					{
						code = detail.GetString();
					}
				}
				catch (JsonException)
				{
				}
				return new SaveResult(false, code);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Failed to save the rule module");
				return new SaveResult(false);
			}
		}

		public async Task<bool> DeleteAsync(Guid id)
		{
			try
			{
				return (await _http.DeleteAsync($"api/modules/{id}")).IsSuccessStatusCode;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Failed to delete the rule module {Id}", id);
				return false;
			}
		}
	}
}
