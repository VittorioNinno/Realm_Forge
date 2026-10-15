using Microsoft.JSInterop;

namespace RealmForge.Client.Services
{
	public record AuthTokens(string AccessToken, string RefreshToken, DateTimeOffset ExpiresAt);

	///	<summary>
	///	Keeps the bearer tokens in memory and in localStorage, so the session survives a page reload.
	///	</summary>
	public class TokenStore
	{
		private const string StorageKey = "realmforge.auth";

		private readonly IJSRuntime _js;
		private AuthTokens? _tokens;

		//	Single shared read of localStorage: concurrent callers (API calls and the auth state provider
		//	both ask at startup) must all wait for the same load instead of seeing "no token" too early
		private Task? _loadTask;

		public TokenStore(IJSRuntime js)
		{
			_js = js;
		}

		//	Raised when the user logs in, logs out or the session expires
		public event Action? OnChange;

		public async Task<AuthTokens?> GetAsync()
		{
			await (_loadTask ??= LoadAsync());
			return _tokens;
		}

		private async Task LoadAsync()
		{
			try
			{
				var json = await _js.InvokeAsync<string?>("localStorage.getItem", StorageKey);
				_tokens = string.IsNullOrEmpty(json) ? null : System.Text.Json.JsonSerializer.Deserialize<AuthTokens>(json);
			}
			catch
			{
				_tokens = null;
			}
		}

		public async Task SetAsync(AuthTokens tokens)
		{
			_tokens = tokens;
			_loadTask = Task.CompletedTask;
			await _js.InvokeVoidAsync("localStorage.setItem", StorageKey, System.Text.Json.JsonSerializer.Serialize(tokens));
			OnChange?.Invoke();
		}

		public async Task ClearAsync()
		{
			var hadTokens = _tokens != null;
			_tokens = null;
			_loadTask = Task.CompletedTask;
			await _js.InvokeVoidAsync("localStorage.removeItem", StorageKey);

			if (hadTokens)
			{
				OnChange?.Invoke();
			}
		}
	}
}
