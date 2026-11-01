using System.Net;
using System.Net.Http.Json;
using Microsoft.JSInterop;
using RealmForge.Shared.DTOs;

namespace RealmForge.Client.Services
{
	///	<summary>
	///	Passkeys of the account (/api/passkeys) and the sign-in with a passkey. The browser part (navigator.credentials)
	///	runs in window.rfPasskeys (index.html). Error codes for UiText.AuthError: PasskeyUnsupported, PasskeyCancelled
	///	(the person closed the browser's dialog), PasskeyExists (already on this device), PasskeyExpired, PasskeyFailed,
	///	LockedOut, TooManyRequests, Unreachable.
	///	</summary>
	public class PasskeyService
	{
		private sealed record BrowserResult(bool Ok, string? Credential, string? Error);

		private readonly HttpClient _http;
		private readonly TokenStore _tokens;
		private readonly IJSRuntime _js;

		public PasskeyService(HttpClient http, TokenStore tokens, IJSRuntime js)
		{
			_http = http;
			_tokens = tokens;
			_js = js;
		}

		public async Task<bool> IsSupportedAsync()
		{
			try
			{
				return await _js.InvokeAsync<bool>("rfPasskeys.supported");
			}
			catch (JSException)
			{
				return false;
			}
		}

		public async Task<List<PasskeyDto>?> GetPasskeysAsync()
		{
			try
			{
				return await _http.GetFromJsonAsync<List<PasskeyDto>>("api/passkeys");
			}
			catch (Exception)
			{
				return null;
			}
		}

		//	Creates a passkey on this device for the signed-in account
		public async Task<AuthResult> AddAsync(string? name)
		{
			try
			{
				var optionsResponse = await _http.PostAsync("api/passkeys/creation-options", null);
				if (!optionsResponse.IsSuccessStatusCode)
				{
					return AuthResult.Fail(await CodeAsync(optionsResponse));
				}
				var options = (await optionsResponse.Content.ReadFromJsonAsync<PasskeyOptionsDto>())!;
				var browser = await _js.InvokeAsync<BrowserResult>("rfPasskeys.create", options.Options);
				if (!browser.Ok)
				{
					return AuthResult.Fail(BrowserCode(browser.Error, creating: true));
				}
				var saved = await _http.PostAsJsonAsync("api/passkeys", new PasskeyCredentialDto { Credential = browser.Credential!, State = options.State, Name = name });
				return saved.IsSuccessStatusCode ? AuthResult.Ok() : AuthResult.Fail(await CodeAsync(saved));
			}
			catch (HttpRequestException)
			{
				return AuthResult.Fail("Unreachable");
			}
			catch (JSException)
			{
				return AuthResult.Fail("PasskeyUnsupported");
			}
		}

		public async Task<bool> RenameAsync(string id, string name)
		{
			try
			{
				return (await _http.PutAsJsonAsync($"api/passkeys/{Uri.EscapeDataString(id)}", new RenamePasskeyDto { Name = name })).IsSuccessStatusCode;
			}
			catch (HttpRequestException)
			{
				return false;
			}
		}

		public async Task<bool> RemoveAsync(string id)
		{
			try
			{
				return (await _http.DeleteAsync($"api/passkeys/{Uri.EscapeDataString(id)}")).IsSuccessStatusCode;
			}
			catch (HttpRequestException)
			{
				return false;
			}
		}

		//	Sign-in: the browser offers the passkeys it has for this site; the API answers with the usual tokens
		public async Task<AuthResult> SignInAsync()
		{
			try
			{
				var optionsResponse = await _http.PostAsync("api/passkeys/request-options", null);
				if (!optionsResponse.IsSuccessStatusCode)
				{
					return AuthResult.Fail(await CodeAsync(optionsResponse));
				}
				var options = (await optionsResponse.Content.ReadFromJsonAsync<PasskeyOptionsDto>())!;
				var browser = await _js.InvokeAsync<BrowserResult>("rfPasskeys.get", options.Options);
				if (!browser.Ok)
				{
					return AuthResult.Fail(BrowserCode(browser.Error, creating: false));
				}
				var response = await _http.PostAsJsonAsync("api/passkeys/sign-in", new PasskeyCredentialDto { Credential = browser.Credential!, State = options.State });
				if (!response.IsSuccessStatusCode)
				{
					return AuthResult.Fail(await CodeAsync(response));
				}
				var tokens = await response.Content.ReadFromJsonAsync<AccessTokenResponse>();
				if (tokens is null)
				{
					return AuthResult.Fail("PasskeyFailed");
				}
				await _tokens.SetAsync(tokens.ToTokens());
				return AuthResult.Ok();
			}
			catch (HttpRequestException)
			{
				return AuthResult.Fail("Unreachable");
			}
			catch (JSException)
			{
				return AuthResult.Fail("PasskeyUnsupported");
			}
		}

		//	NotAllowedError: dialog closed or timed out; InvalidStateError while creating: this device already has one
		private static string BrowserCode(string? error, bool creating) => error switch
		{
			"NotAllowedError" or "AbortError" => "PasskeyCancelled",
			"InvalidStateError" when creating => "PasskeyExists",
			"NotSupportedError" or "SecurityError" => "PasskeyUnsupported",
			_ => "PasskeyFailed"
		};

		private static async Task<string> CodeAsync(HttpResponseMessage response)
		{
			if (response.StatusCode == HttpStatusCode.TooManyRequests)
			{
				return "TooManyRequests";
			}
			var body = await response.Content.ReadAsStringAsync();
			foreach (var code in new[] { "LockedOut", "PasskeyExpired", "NotAllowed" })
			{
				if (body.Contains(code, StringComparison.Ordinal))
				{
					return code == "NotAllowed" ? "PasskeyFailed" : code;
				}
			}
			return "PasskeyFailed";
		}
	}
}
