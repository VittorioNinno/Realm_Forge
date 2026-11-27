using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using RealmForge.Shared.DTOs;

namespace RealmForge.Client.Services
{
	///	<summary>
	///	The achievements of the account (/api/account/achievements): the list of the profile, the ones earned and not told
	///	yet, and the person's own clock sent once per visit (for the achievements made at night).
	///	</summary>
	public sealed class AchievementDataService
	{
		private readonly HttpClient _http;
		private readonly IJSRuntime _js;
		private readonly AuthenticationStateProvider _auth;
		private static bool clockSent;

		public AchievementDataService(HttpClient http, IJSRuntime js, AuthenticationStateProvider auth)
		{
			_http = http;
			_js = js;
			_auth = auth;
		}

		///	<summary>An achievement was earned and told: the pages that show the dice read them again.</summary>
		public static event Action? Earned;

		private async Task<bool> SignedInAsync() => (await _auth.GetAuthenticationStateAsync()).User.Identity?.IsAuthenticated == true;

		public async Task<List<AchievementDto>?> GetAsync()
		{
			try
			{
				return await _http.GetFromJsonAsync<List<AchievementDto>>("api/account/achievements");
			}
			catch (Exception)
			{
				return null;
			}
		}

		///	<summary>Earned and not told yet (nothing for a visitor, or when the server cannot be reached).</summary>
		public async Task<List<AchievementDto>> NewsAsync()
		{
			try
			{
				if (!await SignedInAsync())
				{
					return new();
				}
				await SendClockAsync();
				var response = await _http.GetAsync("api/account/achievements/news");
				return response.IsSuccessStatusCode ? await response.Content.ReadFromJsonAsync<List<AchievementDto>>() ?? new() : new();
			}
			catch (Exception)
			{
				return new();
			}
		}

		public async Task SeenAsync(IEnumerable<string> keys)
		{
			try
			{
				await _http.PostAsJsonAsync("api/account/achievements/seen", new AchievementsSeenDto { Keys = keys.ToList() });
				Earned?.Invoke();
			}
			catch (Exception)
			{
			}
		}

		private async Task SendClockAsync()
		{
			if (clockSent)
			{
				return;
			}
			var zone = await _js.InvokeAsync<string>("rfClock.zone");
			if (!string.IsNullOrEmpty(zone))
			{
				var response = await _http.PutAsJsonAsync("api/account/timezone", new TimeZoneDto { TimeZone = zone });
				clockSent = true;
			}
		}
	}
}
