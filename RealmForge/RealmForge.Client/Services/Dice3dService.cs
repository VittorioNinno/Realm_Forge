using System.Net;
using System.Net.Http.Json;
using Microsoft.JSInterop;
using RealmForge.Client.Components;
using RealmForge.Shared.Dice;
using RealmForge.Shared.DTOs;

namespace RealmForge.Client.Services
{
	///	<summary>
	///	The 3D dice of this device (wwwroot/js/dice3d.js): real dice thrown across the screen that land on the faces of a
	///	roll already decided. The settings (on or off, the look, the colour, sound, the rolls of the others at the table)
	///	stay in the browser; the special dice unlocked with a code belong to the account. Without WebGL or with reduced
	///	motion the flat dice of the tray stay.
	///	</summary>
	public sealed class Dice3dService
	{
		public static readonly string[] Colors = { "forge", "ivory", "graphite", "ruby", "emerald", "sapphire", "amethyst", "teal" };

		private readonly IJSRuntime _js;
		private readonly HttpClient _http;

		//	The special dice of the account, read once per session and given to the page
		private static Task<List<string>>? unlocked;

		public Dice3dService(IJSRuntime js, HttpClient http)
		{
			_js = js;
			_http = http;
		}

		public sealed class Settings
		{
			public bool Enabled { get; set; } = true;
			//	resin, or a special die unlocked by the account
			public string Skin { get; set; } = DiceSkins.Resin;
			//	A colour of the palette or "#rrggbb" (resin only)
			public string Color { get; set; } = "forge";
			public bool Sound { get; set; } = true;
			public bool Others { get; set; } = true;
		}

		///	<summary>The special dice of the account (read once, then given to the page so the throws use them).</summary>
		public async Task<List<string>> UnlockedAsync(bool reload = false)
		{
			if (reload || unlocked is null || unlocked.IsFaulted)
			{
				unlocked = LoadUnlockedAsync();
			}
			var list = await unlocked;
			try
			{
				await _js.InvokeVoidAsync("rfDice3d.unlocked", list);
			}
			catch (Exception)
			{
			}
			return list;
		}

		private async Task<List<string>> LoadUnlockedAsync()
		{
			try
			{
				var response = await _http.GetAsync("api/account/dice");
				return response.IsSuccessStatusCode ? (await response.Content.ReadFromJsonAsync<DiceSkinsDto>())?.Unlocked ?? new() : new();
			}
			catch (Exception)
			{
				return new();
			}
		}

		///	<summary>A code tried: what it unlocked, or why not (TooManyRequests, Unknown).</summary>
		public async Task<(DiceUnlockResultDto? Result, string? Error)> UnlockAsync(string code)
		{
			try
			{
				var response = await _http.PostAsJsonAsync("api/account/dice/unlock", new DiceUnlockDto { Code = code });
				if (response.StatusCode == HttpStatusCode.TooManyRequests)
				{
					return (null, "TooManyRequests");
				}
				var result = response.IsSuccessStatusCode ? await response.Content.ReadFromJsonAsync<DiceUnlockResultDto>() : null;
				if (result is null)
				{
					return (null, "Unknown");
				}
				unlocked = Task.FromResult(result.Unlocked);
				await _js.InvokeVoidAsync("rfDice3d.unlocked", result.Unlocked);
				return (result, null);
			}
			catch (Exception)
			{
				return (null, "Unknown");
			}
		}

		public async Task<Settings> GetAsync()
		{
			try
			{
				return await _js.InvokeAsync<Settings>("rfDice3d.settings");
			}
			catch (Exception)
			{
				return new Settings { Enabled = false };
			}
		}

		public async Task<Settings> SaveAsync(Settings settings)
		{
			try
			{
				return await _js.InvokeAsync<Settings>("rfDice3d.save", settings);
			}
			catch (Exception)
			{
				return settings;
			}
		}

		//	Whether this browser can show them (WebGL, no reduced motion)
		public async Task<bool> AvailableAsync()
		{
			try
			{
				return await _js.InvokeAsync<bool>("rfDice3d.available");
			}
			catch (Exception)
			{
				return false;
			}
		}

		///	<summary>
		///	Throws the dice of a roll and waits until they rest: false when they are not shown (switched off, not
		///	available, a die it cannot draw), and the tray animates as before. A roll of someone else at the table
		///	(Remote) follows the reader's setting for those, in its own colour when given.
		///	</summary>
		public async Task<bool> RollAsync(IEnumerable<DieFace> dice, bool remote = false, string? color = null, CancellationToken cancel = default)
		{
			using var rolling = DiceActivity.Hold();
			try
			{
				//	The first throw of the session learns the special dice of the account (not the dice of others)
				if (!remote && unlocked is null)
				{
					await Task.WhenAny(UnlockedAsync(), Task.Delay(1500, cancel));
				}
				var list = dice.Select(d => new { sides = d.Sides, value = d.Value }).ToList();
				return list.Count > 0 && await _js.InvokeAsync<bool>("rfDice3d.roll", cancel, list, new { remote, color });
			}
			catch (Exception)
			{
				return false;
			}
		}

		public async Task ClearAsync()
		{
			try
			{
				await _js.InvokeVoidAsync("rfDice3d.clear");
			}
			catch (Exception)
			{
			}
		}
	}
}
