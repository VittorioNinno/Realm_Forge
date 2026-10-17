using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

namespace RealmForge.Client.Services
{
	///	<summary>
	///	Exposes the logged-in user to Blazor (AuthorizeView, CascadingAuthenticationState).
	///	Identity bearer tokens are opaque, so the user's e-mail and its confirmation status are read once from
	///	/api/auth/manage/info and kept as claims until the tokens change or <see cref="Refresh"/> is called.
	///	</summary>
	public class TokenAuthenticationStateProvider : AuthenticationStateProvider, IDisposable
	{
		///	<summary>
		///	Claim with "true" or "false": whether the signed-in user's e-mail address is confirmed.
		///	</summary>
		public const string EmailConfirmedClaim = "realmforge:email_confirmed";

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
			var user = await _auth.GetCurrentUserAsync();
			if (user is null)
			{
				return Anonymous;
			}

			var identity = new ClaimsIdentity(new[]
			{
				new Claim(ClaimTypes.Name, user.Email),
				new Claim(ClaimTypes.Email, user.Email),
				new Claim(EmailConfirmedClaim, user.EmailConfirmed ? "true" : "false")
			}, authenticationType: "Bearer");

			return new AuthenticationState(new ClaimsPrincipal(identity));
		}

		///	<summary>
		///	Reloads the user from the API (e.g. after the e-mail was confirmed in another tab) and notifies the UI.
		///	</summary>
		public void Refresh() => HandleTokensChanged();

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
