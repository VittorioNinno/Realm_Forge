using Microsoft.JSInterop;

namespace RealmForge.Client.Services
{
	///	<summary>
	///	Messages between the RealmForge tabs open in the same browser (BroadcastChannel, see index.html).
	///	A link from an e-mail always opens a new tab; that tab tells the others what happened so they update
	///	themselves, and then it can close itself.
	///	</summary>
	public class CrossTabService : IAsyncDisposable
	{
		public const string EmailConfirmed = "email-confirmed";

		private readonly IJSRuntime _js;
		private DotNetObjectReference<CrossTabService>? _reference;

		public CrossTabService(IJSRuntime js)
		{
			_js = js;
		}

		///	<summary>
		///	Raised when another tab reports that the e-mail address was confirmed.
		///	</summary>
		public event Action? OnEmailConfirmed;

		public async Task StartAsync()
		{
			if (_reference != null)
			{
				return;
			}

			_reference = DotNetObjectReference.Create(this);
			await _js.InvokeVoidAsync("realmForge.tabs.listen", _reference);
		}

		public ValueTask AnnounceAsync(string message) => _js.InvokeVoidAsync("realmForge.tabs.announce", message);

		public ValueTask<bool> HasOtherTabsAsync() => _js.InvokeAsync<bool>("realmForge.tabs.hasOtherTabs");

		public ValueTask TryCloseAsync() => _js.InvokeVoidAsync("realmForge.tabs.tryClose");

		[JSInvokable]
		public void OnTabMessage(string message)
		{
			if (message == EmailConfirmed)
			{
				OnEmailConfirmed?.Invoke();
			}
		}

		public ValueTask DisposeAsync()
		{
			_reference?.Dispose();
			return ValueTask.CompletedTask;
		}
	}
}
