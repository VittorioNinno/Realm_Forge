using System.Text.Json;
using Microsoft.JSInterop;

namespace RealmForge.Client.Services
{
	///	<summary>A page pinned to the side menu: where it is, its name, its icon.</summary>
	public sealed record PinnedPage(string Href, string Label, string Icon);

	///	<summary>
	///	The pages pinned to the side menu (a character, a campaign, a list of the compendium), kept in this browser: the
	///	newest last, at most MaxPins. The menu and the pin button of the top bar listen to its changes.
	///	</summary>
	public class PinService
	{
		public const int MaxPins = 12;
		private const string Key = "rf-pins";

		private readonly IJSRuntime _js;
		private List<PinnedPage>? pins;

		public PinService(IJSRuntime js)
		{
			_js = js;
		}

		public event Action? Changed;

		public IReadOnlyList<PinnedPage> Pins => pins ?? new List<PinnedPage>();

		public bool IsFull => Pins.Count >= MaxPins;

		public bool IsPinned(string href) => Pins.Any(p => Same(p.Href, href));

		public async Task LoadAsync()
		{
			if (pins is not null)
			{
				return;
			}
			try
			{
				var json = await _js.InvokeAsync<string?>("localStorage.getItem", Key);
				pins = string.IsNullOrEmpty(json) ? new() : JsonSerializer.Deserialize<List<PinnedPage>>(json) ?? new();
			}
			catch (Exception)
			{
				pins = new();
			}
			pins = pins.Where(p => !string.IsNullOrWhiteSpace(p.Href) && !string.IsNullOrWhiteSpace(p.Label)).Take(MaxPins).ToList();
			Changed?.Invoke();
		}

		public async Task PinAsync(string href, string label, string icon)
		{
			await LoadAsync();
			if (IsPinned(href) || IsFull)
			{
				return;
			}
			pins!.Add(new PinnedPage(href, label.Length > 60 ? label[..60] : label, icon));
			await SaveAsync();
		}

		public async Task UnpinAsync(string href)
		{
			await LoadAsync();
			if (pins!.RemoveAll(p => Same(p.Href, href)) > 0)
			{
				await SaveAsync();
			}
		}

		private async Task SaveAsync()
		{
			try
			{
				await _js.InvokeVoidAsync("localStorage.setItem", Key, JsonSerializer.Serialize(pins));
			}
			catch (Exception)
			{
				//	Storage refused (private browsing): the pins last until the page is closed
			}
			Changed?.Invoke();
		}

		private static bool Same(string a, string b) => string.Equals(a.TrimEnd('/'), b.TrimEnd('/'), StringComparison.OrdinalIgnoreCase);

		///	<summary>The icon of a page, from the first part of its address.</summary>
		public static string IconOf(string href) => href.Split('?', '#')[0].Split('/')[0].ToLowerInvariant() switch
		{
			"characters" => "characters",
			"campaigns" => "campaigns",
			"search" => "search",
			"rules" => "rules",
			"subspecies" => "species",
			"species" or "backgrounds" or "feats" or "spells" or "classes" or "equipment" or "magic-items" or "monsters" or "npcs" or "modules" => href.Split('?', '#')[0].Split('/')[0].ToLowerInvariant(),
			"" => "home",
			_ => "pin-angle"
		};
	}
}
