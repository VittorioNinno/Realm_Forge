using System.Net;
using System.Net.Http.Json;
using Microsoft.Extensions.Logging;
using RealmForge.Shared.DTOs;

namespace RealmForge.Client.Services
{
	///	<summary>
	///	Outcome of saving an encounter: the encounter as stored, or the status of the failure; on 409 Current is the
	///	version someone else saved meanwhile.
	///	</summary>
	public sealed record EncounterSaveResult(EncounterDto? Encounter, HttpStatusCode? Status, EncounterDto? Current = null)
	{
		public bool Ok => Encounter is not null;
	}

	///	<summary>
	///	Client for /api/campaigns/{id}/encounters.
	///	</summary>
	public class EncounterDataService
	{
		private readonly HttpClient _http;
		private readonly ILogger<EncounterDataService> _logger;

		public EncounterDataService(HttpClient http, ILogger<EncounterDataService> logger)
		{
			_http = http;
			_logger = logger;
		}

		public async Task<List<EncounterSummaryDto>?> GetEncountersAsync(Guid campaignId)
		{
			try
			{
				return await _http.GetFromJsonAsync<List<EncounterSummaryDto>>($"api/campaigns/{campaignId}/encounters");
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Loading the encounters of {CampaignId} failed", campaignId);
				return null;
			}
		}

		public async Task<EncounterDto?> GetEncounterAsync(Guid campaignId, Guid id)
		{
			try
			{
				var response = await _http.GetAsync($"api/campaigns/{campaignId}/encounters/{id}");
				return response.IsSuccessStatusCode ? await response.Content.ReadFromJsonAsync<EncounterDto>() : null;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Loading encounter {EncounterId} failed", id);
				return null;
			}
		}

		public async Task<EncounterSaveResult> SaveAsync(Guid campaignId, Guid? id, SaveEncounterDto dto)
		{
			try
			{
				var response = id is { } existing
					? await _http.PutAsJsonAsync($"api/campaigns/{campaignId}/encounters/{existing}", dto)
					: await _http.PostAsJsonAsync($"api/campaigns/{campaignId}/encounters", dto);
				if (response.IsSuccessStatusCode)
				{
					return new EncounterSaveResult(await response.Content.ReadFromJsonAsync<EncounterDto>(), null);
				}
				if (response.StatusCode == HttpStatusCode.Conflict && id is not null)
				{
					EncounterDto? current = null;
					try
					{
						current = await response.Content.ReadFromJsonAsync<EncounterDto>();
					}
					catch (Exception)
					{
						//	A 409 without the encounter (the campaign limit): nothing to reload
					}
					return new EncounterSaveResult(null, response.StatusCode, current);
				}
				return new EncounterSaveResult(null, response.StatusCode);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Saving encounter {EncounterId} failed", id);
				return new EncounterSaveResult(null, null);
			}
		}

		public async Task<bool> DeleteAsync(Guid campaignId, Guid id)
		{
			try
			{
				return (await _http.DeleteAsync($"api/campaigns/{campaignId}/encounters/{id}")).IsSuccessStatusCode;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Deleting encounter {EncounterId} failed", id);
				return false;
			}
		}
	}
}
