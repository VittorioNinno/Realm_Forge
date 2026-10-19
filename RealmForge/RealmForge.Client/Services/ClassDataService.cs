using System.Net.Http.Json;
using Microsoft.Extensions.Logging;
using RealmForge.Shared.DTOs;
using RealmForge.Shared.Enums;

namespace RealmForge.Client.Services
{
	///	<summary>
	///	Client for /api/classes and /api/subclasses: list, detail and Homebrew create/update/delete.
	///	</summary>
	public class ClassDataService
	{
		private readonly HttpClient _http;
		private readonly ILogger<ClassDataService> _logger;

		public ClassDataService(HttpClient http, ILogger<ClassDataService> logger)
		{
			_http = http;
			_logger = logger;
		}

		public async Task<List<ClassResponseDto>> GetClassesAsync(LanguageCode language, RulesetVersion? ruleset = null)
		{
			try
			{
				var url = $"api/classes?lang={(int)language}";
				if (ruleset.HasValue)
				{
					url += $"&ruleset={(int)ruleset.Value}";
				}

				return await _http.GetFromJsonAsync<List<ClassResponseDto>>(url) ?? new List<ClassResponseDto>();
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Failed to load classes from API for language {Language}", language);
				return new List<ClassResponseDto>();
			}
		}

		public async Task<ClassDetailResponseDto?> GetClassDetailAsync(Guid id, LanguageCode language)
		{
			try
			{
				return await _http.GetFromJsonAsync<ClassDetailResponseDto>($"api/classes/{id}?lang={(int)language}");
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Failed to load class {ClassId} for language {Language}", id, language);
				return null;
			}
		}

		public async Task<SubclassResponseDto?> GetSubclassAsync(Guid id, LanguageCode language)
		{
			try
			{
				return await _http.GetFromJsonAsync<SubclassResponseDto>($"api/subclasses/{id}?lang={(int)language}");
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Failed to load subclass {SubclassId} for language {Language}", id, language);
				return null;
			}
		}

		public Task<bool> CreateClassAsync(SaveClassDto dto) => SendAsync(() => _http.PostAsJsonAsync("api/classes", dto), "creating class");

		public Task<bool> UpdateClassAsync(Guid id, SaveClassDto dto) => SendAsync(() => _http.PutAsJsonAsync($"api/classes/{id}", dto), "updating class");

		public Task<bool> DeleteClassAsync(Guid id) => SendAsync(() => _http.DeleteAsync($"api/classes/{id}"), "deleting class");

		public Task<bool> CreateSubclassAsync(SaveSubclassDto dto) => SendAsync(() => _http.PostAsJsonAsync("api/subclasses", dto), "creating subclass");

		public Task<bool> UpdateSubclassAsync(Guid id, SaveSubclassDto dto) => SendAsync(() => _http.PutAsJsonAsync($"api/subclasses/{id}", dto), "updating subclass");

		public Task<bool> DeleteSubclassAsync(Guid id) => SendAsync(() => _http.DeleteAsync($"api/subclasses/{id}"), "deleting subclass");

		private async Task<bool> SendAsync(Func<Task<HttpResponseMessage>> send, string operation)
		{
			try
			{
				var response = await send();
				return response.IsSuccessStatusCode;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error {Operation}", operation);
				return false;
			}
		}
	}
}
