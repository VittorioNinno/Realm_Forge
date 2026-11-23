using Microsoft.JSInterop;
using RealmForge.Client.Components;

namespace RealmForge.Client.Services
{
	///	<summary>
	///	The 3D dice of this device (wwwroot/js/dice3d.js): real dice thrown across the screen that land on the faces of a
	///	roll already decided. The settings (on or off, colour, material, sound, the rolls of the others at the table) stay
	///	in the browser; without WebGL or with reduced motion the flat dice of the tray stay.
	///	</summary>
	public sealed class Dice3dService
	{
		public static readonly string[] Colors = { "forge", "ivory", "obsidian", "ruby", "emerald", "sapphire", "amethyst" };
		public static readonly string[] Materials = { "plastic", "metal", "wood", "glass" };

		private readonly IJSRuntime _js;

		public Dice3dService(IJSRuntime js)
		{
			_js = js;
		}

		public sealed class Settings
		{
			public bool Enabled { get; set; } = true;
			public string Color { get; set; } = "forge";
			public string Material { get; set; } = "plastic";
			public bool Sound { get; set; } = true;
			public bool Others { get; set; } = true;
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
			try
			{
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
