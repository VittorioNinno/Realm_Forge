using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

namespace RealmForge.Client.Services
{
	///	<summary>
	///	Exposes the logged-in user to Blazor (AuthorizeView, CascadingAuthenticationState).
	///	Identity bearer tokens are opaque, so the user's email is read from /api/auth/manage/info.
	///	</summary>
	public class TokenAuthenticationStateProvider : AuthenticationStateProvider, IDisposable
	{
		private static readonly AuthenticationState Anonymous = new(new ClaimsPrincipal(new ClaimsIdentity()));

		private readonly AuthService _auth;
		private readonly TokenStore _tokens;
		private Task<AuthenticationState>? _cached;

		public TokenAuthenticationStateProvider(AuthService auth, TokenStore tokens)
		{
			_auth = auth;
			_tokens = tokens;
			_tokens.OnChange += HandleTokensChanged;
		}

		public override Task<AuthenticationState> GetAuthenticationStateAsync() =>
			_cached ??= LoadAsync();

		private async Task<AuthenticationState> LoadAsync()
		{
			var email = await _auth.GetCurrentEmailAsync();
			if (email is null)
			{
				return Anonymous;
			}

			var identity = new ClaimsIdentity(new[]
			{
				new Claim(ClaimTypes.Name, email),
				new Claim(ClaimTypes.Email, email)
			}, authenticationType: "Bearer");

			return new AuthenticationState(new ClaimsPrincipal(identity));
		}

		private void HandleTokensChanged()
		{
			_cached = null;
			NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
		}

		public void Dispose()
		{
			_tokens.OnChange -= HandleTokensChanged;
		}
	}
}
