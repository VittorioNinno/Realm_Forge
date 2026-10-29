using System.Net;
using System.Net.Http.Json;
using Microsoft.Extensions.Logging;
using RealmForge.Shared.DTOs;
using RealmForge.Shared.Enums;

namespace RealmForge.Client.Services
{
	///	<summary>
	///	Outcome of a restore: the restored entry, or the status and (on 409) the kind of what it depends on.
	///	</summary>
	public sealed record TrashRestoreResult(TrashRestoredDto? Restored, HttpStatusCode? Status = null, string? MissingKind = null);

	///	<summary>
	///	Client for /api/trash: what I deleted in the last days, restored or deleted for good.
	///	</summary>
	public class TrashDataService
	{
		private readonly HttpClient _http;
		private readonly ILogger<TrashDataService> _logger;

		public TrashDataService(HttpClient http, ILogger<TrashDataService> logger)
		{
			_http = http;
			_logger = logger;
		}

		public async Task<List<TrashEntryDto>?> GetAsync(LanguageCode lang)
		{
			try
			{
				return await _http.GetFromJsonAsync<List<TrashEntryDto>>($"api/trash?lang={(int)lang}");
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Failed to load the bin");
				return null;
			}
		}

		public async Task<TrashRestoreResult> RestoreAsync(Guid id, LanguageCode lang)
		{
			try
			{
				var response = await _http.PostAsync($"api/trash/{id}/restore?lang={(int)lang}", null);
				if (response.IsSuccessStatusCode)
				{
					return new TrashRestoreResult(await response.Content.ReadFromJsonAsync<TrashRestoredDto>());
				}
				string? missing = null;
				if (response.StatusCode == HttpStatusCode.Conflict)
				{
					try
					{
						var problem = await response.Content.ReadFromJsonAsync<ProblemBody>();
						missing = problem?.Detail;
					}
					catch (Exception)
					{
						//	No body: the generic message
					}
				}
				return new TrashRestoreResult(null, response.StatusCode, missing);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Failed to restore {Id}", id);
				return new TrashRestoreResult(null);
			}
		}

		public async Task<bool> PurgeAsync(Guid id)
		{
			try
			{
				return (await _http.DeleteAsync($"api/trash/{id}")).IsSuccessStatusCode;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Failed to purge {Id}", id);
				return false;
			}
		}

		private sealed class ProblemBody
		{
			public string? Detail { get; set; }
		}
	}
}
