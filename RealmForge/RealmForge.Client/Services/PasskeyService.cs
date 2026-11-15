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

		//	Options read before the click (Safari only shows the dialog for a fresh click: nothing may be awaited between
		//	the click and the browser's call), used once, good for a few minutes (the API accepts them for 10)
		private sealed record Ready(PasskeyOptionsDto Options, DateTime At);

		private static readonly TimeSpan Fresh = TimeSpan.FromMinutes(4);
		private Ready? signInReady;
		private Ready? createReady;

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
				return await _js.InvokeAsync<bool>("rfPasskeys.supported", (string?)null);
			}
			catch (JSException)
			{
				return false;
			}
		}

		///	<summary>
		///	Reads the options for a sign-in (creating: for a new passkey) ahead of the click, and tells whether passkeys
		///	work on this address (the browser, and the site's domain: a preview address cannot use them).
		///	</summary>
		public async Task<bool> PrepareAsync(bool creating)
		{
			var ready = await OptionsAsync(creating, keep: true);
			if (ready is null)
			{
				return await IsSupportedAsync();
			}
			try
			{
				return await _js.InvokeAsync<bool>("rfPasskeys.supported", RelyingParty(ready.Options.Options));
			}
			catch (JSException)
			{
				return false;
			}
		}

		//	The options kept from before (fresh), else read now; kept again for the next click when asked
		private async Task<Ready?> OptionsAsync(bool creating, bool keep)
		{
			var held = creating ? createReady : signInReady;
			if (held is not null && DateTime.UtcNow - held.At < Fresh)
			{
				if (!keep)
				{
					Forget(creating);
				}
				return held;
			}
			var response = await _http.PostAsync(creating ? "api/passkeys/creation-options" : "api/passkeys/request-options", null);
			if (!response.IsSuccessStatusCode)
			{
				lastError = await CodeAsync(response);
				return null;
			}
			var ready = new Ready((await response.Content.ReadFromJsonAsync<PasskeyOptionsDto>())!, DateTime.UtcNow);
			if (keep)
			{
				if (creating)
				{
					createReady = ready;
				}
				else
				{
					signInReady = ready;
				}
			}
			return ready;
		}

		private string? lastError;

		//	Another account signed in or out: the options read for the previous one are dropped
		public void Reset()
		{
			signInReady = null;
			createReady = null;
		}

		private void Forget(bool creating)
		{
			if (creating)
			{
				createReady = null;
			}
			else
			{
				signInReady = null;
			}
		}

		//	The domain the passkeys belong to: rp.id of the creation options, rpId of the request options
		private static string? RelyingParty(string optionsJson)
		{
			try
			{
				using var doc = System.Text.Json.JsonDocument.Parse(optionsJson);
				var root = doc.RootElement;
				if (root.TryGetProperty("rpId", out var rpId) && rpId.ValueKind == System.Text.Json.JsonValueKind.String)
				{
					return rpId.GetString();
				}
				return root.TryGetProperty("rp", out var rp) && rp.TryGetProperty("id", out var id) && id.ValueKind == System.Text.Json.JsonValueKind.String
					? id.GetString() : null;
			}
			catch (System.Text.Json.JsonException)
			{
				return null;
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
				var ready = await OptionsAsync(creating: true, keep: false);
				if (ready is null)
				{
					return AuthResult.Fail(lastError ?? "PasskeyFailed");
				}
				var options = ready.Options;
				var browser = await _js.InvokeAsync<BrowserResult>("rfPasskeys.create", options.Options);
				if (!browser.Ok)
				{
					_ = PrepareQuietlyAsync(creating: true);
					return AuthResult.Fail(BrowserCode(browser.Error, creating: true));
				}
				var saved = await _http.PostAsJsonAsync("api/passkeys", new PasskeyCredentialDto { Credential = browser.Credential!, State = options.State, Name = name });
				//	The next attempt has its options ready before its click (this passkey among those left out)
				_ = PrepareQuietlyAsync(creating: true);
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
				var ready = await OptionsAsync(creating: false, keep: false);
				if (ready is null)
				{
					return AuthResult.Fail(lastError ?? "PasskeyFailed");
				}
				var options = ready.Options;
				var browser = await _js.InvokeAsync<BrowserResult>("rfPasskeys.get", options.Options);
				if (!browser.Ok)
				{
					_ = PrepareQuietlyAsync(creating: false);
					return AuthResult.Fail(BrowserCode(browser.Error, creating: false));
				}
				return await FinishSignInAsync(options, browser.Credential!);
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

		///	<summary>
		///	The passkeys offered by the e-mail field, where the browser can (Safari on iPhone above the keyboard, the
		///	desktop browsers in the autofill list): waits until one is picked; null when the browser cannot, or when it was
		///	stopped (a click on the passkey button, the page left).
		///	</summary>
		public async Task<AuthResult?> AutofillAsync()
		{
			try
			{
				if (!await _js.InvokeAsync<bool>("rfPasskeys.autofillAvailable"))
				{
					return null;
				}
				//	The same options as the button (one request per visit): only one of the two is ever answered
				var ready = await OptionsAsync(creating: false, keep: true);
				if (ready is null)
				{
					return null;
				}
				var browser = await _js.InvokeAsync<BrowserResult>("rfPasskeys.autofill", ready.Options.Options);
				if (!browser.Ok)
				{
					return browser.Error is "AbortError" or "NotAllowedError" ? null : AuthResult.Fail(BrowserCode(browser.Error, creating: false));
				}
				return await FinishSignInAsync(ready.Options, browser.Credential!);
			}
			catch (HttpRequestException)
			{
				return null;
			}
			catch (JSException)
			{
				return null;
			}
		}

		public async Task StopAutofillAsync()
		{
			try
			{
				await _js.InvokeVoidAsync("rfPasskeys.stop");
			}
			catch (JSException)
			{
			}
			catch (JSDisconnectedException)
			{
			}
		}

		private async Task PrepareQuietlyAsync(bool creating)
		{
			try
			{
				await OptionsAsync(creating, keep: true);
			}
			catch (Exception)
			{
				//	Read again at the click
			}
		}

		//	The browser's answer to the API: the usual tokens (an HTTP failure is caught by the callers)
		private async Task<AuthResult> FinishSignInAsync(PasskeyOptionsDto options, string credential)
		{
			{
				var response = await _http.PostAsJsonAsync("api/passkeys/sign-in", new PasskeyCredentialDto { Credential = credential, State = options.State });
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
