using System.Net.Http.Json;
using System.Text.Json;
using RealmForge.Shared.DTOs;
using RealmForge.Shared.Enums;

namespace RealmForge.Client.Services
{
	///	<summary>The outcome of sending a file: the answer, or the reason the server gave (its title and detail).</summary>
	public sealed record TransferResult<T>(T? Value, string? Title, string? Detail);

	///	<summary>
	///	Characters and Homebrew to a JSON file and back (the files of another RealmForge too), and the account's own
	///	Homebrew with the languages of its texts.
	///	</summary>
	public class TransferDataService
	{
		private readonly HttpClient _http;
		private readonly ILogger<TransferDataService> _logger;

		public TransferDataService(HttpClient http, ILogger<TransferDataService> logger)
		{
			_http = http;
			_logger = logger;
		}

		public Task<TransferResult<CharacterExportDto>> ExportCharacterAsync(Guid id) =>
			SendAsync<CharacterExportDto>(() => _http.GetAsync($"api/characters/{id}/export"), "export character");

		public Task<TransferResult<CharacterDto>> ImportCharacterAsync(CharacterExportDto file) =>
			SendAsync<CharacterDto>(() => _http.PostAsJsonAsync("api/characters/import", file), "import character");

		public Task<TransferResult<List<MyHomebrewDto>>> MineAsync(LanguageCode lang) =>
			SendAsync<List<MyHomebrewDto>>(() => _http.GetAsync($"api/content/mine?lang={(int)lang}"), "my homebrew");

		public Task<TransferResult<HomebrewExportDto>> ExportHomebrewAsync(IEnumerable<HomebrewRefDto> entries, LanguageCode lang) =>
			SendAsync<HomebrewExportDto>(() => _http.PostAsJsonAsync($"api/content/export?lang={(int)lang}", new HomebrewExportRequestDto { Entries = entries.ToList() }), "export homebrew");

		public Task<TransferResult<List<HomebrewImportedDto>>> ImportHomebrewAsync(HomebrewExportDto file, LanguageCode lang) =>
			SendAsync<List<HomebrewImportedDto>>(() => _http.PostAsJsonAsync($"api/content/import?lang={(int)lang}", file), "import homebrew");

		public Task<TransferResult<HomebrewImportedDto>> ForkAsync(string kind, Guid id, LanguageCode lang) =>
			SendAsync<HomebrewImportedDto>(() => _http.PostAsync($"api/content/{kind}/{id}/fork?lang={(int)lang}", null), "fork");

		//	The entry this one was cloned from (none: no answer)
		public async Task<TransferResult<ContentOriginDto>> OriginAsync(string kind, Guid id, LanguageCode lang)
		{
			try
			{
				var response = await _http.GetAsync($"api/content/{kind}/{id}/origin?lang={(int)lang}");
				return response.StatusCode == System.Net.HttpStatusCode.OK
					? new TransferResult<ContentOriginDto>(await response.Content.ReadFromJsonAsync<ContentOriginDto>(), null, null)
					: new TransferResult<ContentOriginDto>(default, null, null);
			}
			catch (Exception)
			{
				return new TransferResult<ContentOriginDto>(default, null, "network");
			}
		}

		private async Task<TransferResult<T>> SendAsync<T>(Func<Task<HttpResponseMessage>> send, string what)
		{
			try
			{
				var response = await send();
				if (response.IsSuccessStatusCode)
				{
					return new TransferResult<T>(await response.Content.ReadFromJsonAsync<T>(), null, null);
				}
				string? title = null, detail = null;
				try
				{
					var problem = await response.Content.ReadFromJsonAsync<JsonElement>();
					title = problem.TryGetProperty("title", out var t) ? t.GetString() : null;
					detail = problem.TryGetProperty("detail", out var d) ? d.GetString() : null;
				}
				catch (Exception)
				{
				}
				return new TransferResult<T>(default, title ?? $"HTTP {(int)response.StatusCode}", detail);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Transfer {What} failed", what);
				return new TransferResult<T>(default, null, "network");
			}
		}
	}
}
