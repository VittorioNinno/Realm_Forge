using Microsoft.JSInterop;
using RealmForge.Client.Localization;

namespace RealmForge.Client.Components
{
	///	<summary>
	///	The connection to the table, shown at the top: live while the server answers the waits for changes, reconnecting
	///	after a wait that did not get through, offline after a few in a row or when the browser says the network is gone.
	///	Back online, the map is read again at once.
	///	</summary>
	public partial class CampaignMap
	{
		public enum TableLink
		{
			Live,
			Reconnecting,
			Offline
		}

		//	The waits in a row that did not reach the server; the last time one did
		private int pollFailures;
		private DateTime lastContact = DateTime.UtcNow;
		private bool browserOffline;
		private bool netWatched;

		private TableLink Connection => browserOffline || pollFailures >= 3 ? TableLink.Offline : pollFailures > 0 ? TableLink.Reconnecting : TableLink.Live;

		//	A wait reached the server (or not): the indicator follows; back after failures, the map is read again
		private async Task ContactAsync(bool reached)
		{
			var before = Connection;
			if (reached)
			{
				pollFailures = 0;
				lastContact = DateTime.UtcNow;
			}
			else
			{
				pollFailures++;
			}
			if (Connection != before)
			{
				if (reached && before != TableLink.Live)
				{
					await RefreshAsync();
				}
				await InvokeAsync(StateHasChanged);
			}
		}

		//	How long to wait before trying again: a little longer after each failure, at most 15 seconds
		private TimeSpan RetryDelay => TimeSpan.FromMilliseconds(Math.Min(15000, 2000 * Math.Max(1, pollFailures)));

		[JSInvokable]
		public async Task NetworkChanged(bool online)
		{
			var was = browserOffline;
			browserOffline = !online;
			if (was && online)
			{
				//	The network is back: no need to wait for the next try
				pollFailures = 0;
				await RefreshAsync();
			}
			await InvokeAsync(StateHasChanged);
		}

		private async Task WatchNetworkAsync()
		{
			if (netWatched || self is null)
			{
				return;
			}
			netWatched = true;
			try
			{
				await JS.InvokeVoidAsync("rfNet.watch", self);
			}
			catch (JSException)
			{
			}
		}

		private async Task UnwatchNetworkAsync()
		{
			if (!netWatched || self is null)
			{
				return;
			}
			try
			{
				await JS.InvokeVoidAsync("rfNet.unwatch", self);
			}
			catch (Exception)
			{
				//	The page is going away
			}
		}

		private string ConnectionTitle => Connection switch
		{
			TableLink.Live => UiText.VttConnectionLive(Lang),
			TableLink.Reconnecting => UiText.VttConnectionRetry(Lang),
			_ => UiText.VttConnectionLost(lastContact.ToLocalTime(), Lang)
		};
	}
}
